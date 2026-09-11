using Formula1YonetimSistemi.Common.DTO;
using Formula1YonetimSistemi.Common.Helpers;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Text;

namespace Formula1YonetimSistemi.Entity
{
    public class EPilot
    {
        public EPilot()
        {

        }

        public bool PilotEkle(Pilot pilot)
        {
            try
            {
                using (SqlConnection connection = SqlHelper.GetConnection())
                {
                    using (SqlCommand command = new SqlCommand("sp_PilotEkle", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@PilotAdSoyad", pilot.PilotAdSoyad);
                        command.Parameters.AddWithValue("@PilotNo", pilot.PilotNo);
                        command.Parameters.AddWithValue("@PilotAktifMi", pilot.PilotAktifMi);
                        command.Parameters.AddWithValue("@TakimId", pilot.TakimId);

                        connection.Open();
                        int result = command.ExecuteNonQuery();
                        return result > 0;
                    }

                }
            }
            catch (Exception ex)
            {
                throw new Exception(message: $"Pilot ekleme işleminde hata oluştu! Pilot: {pilot.PilotAdSoyad}, Pilot No: {pilot.PilotNo}");
            }
        }

        public Pilot GetirPilotById(Pilot pilot)
        {
            try
            {
                using (SqlConnection connection = SqlHelper.GetConnection())
                {
                    using (SqlCommand command = new SqlCommand("sp_PilotGetirById", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@PilotId", pilot.PilotId);

                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new Pilot
                                {
                                    PilotId = (int)reader["PilotId"],
                                    PilotAdSoyad = (string)reader["PilotAdSoyad"],
                                    PilotNo = (int)reader["PilotNo"],
                                    PilotAktifMi = (bool)reader["PilotAktifMi"],
                                    TakimId = (int)reader["TakimId"]
                                };
                            }
                            return null;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Pilot getirme işleminde hata oluştu! PilotId: {pilot.PilotId}", ex);
            }
        }


        public bool PilotGuncelle(Pilot pilot)
        {
            try
            {
                using (SqlConnection connection = SqlHelper.GetConnection())
                {
                    using (SqlCommand command = new SqlCommand("sp_PilotGuncelle", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@PilotId", pilot.PilotId);
                        command.Parameters.AddWithValue("@PilotAdSoyad", pilot.PilotAdSoyad);
                        command.Parameters.AddWithValue("@PilotNo", pilot.PilotNo);
                        command.Parameters.AddWithValue("@PilotAktifMi", pilot.PilotAktifMi);
                        command.Parameters.AddWithValue("@TakimId", pilot.TakimId);

                        connection.Open();
                        int result = command.ExecuteNonQuery();
                        return result > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Pilot güncelleme işleminde hata oluştu! PilotId: {pilot.PilotId}", ex);
            }
        }

        public bool PilotSil(int pilotId)
        {
            try
            {
                using (SqlConnection connection = SqlHelper.GetConnection())
                {
                    using (SqlCommand command = new SqlCommand("sp_PilotSil", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@PilotId", pilotId);

                        connection.Open();
                        int result = command.ExecuteNonQuery();
                        return result > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("SQL HATA DETAYI: " + ex.Message);
            }
        }
        public List<Pilot> PilotlariGetir(int? takimId = null, string pilotAdSoyad = null)
        {
            List<Pilot> pilotlar = new List<Pilot>();

            try
            {
                using (SqlConnection connection = SqlHelper.GetConnection())
                {
                    using (SqlCommand command = new SqlCommand("sp_PilotlariGetir", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@TakimId", takimId != null ? (object)takimId : DBNull.Value);
                        command.Parameters.AddWithValue("@PilotAdSoyad", pilotAdSoyad != null ? (object)pilotAdSoyad : DBNull.Value);

                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                pilotlar.Add(new Pilot
                                {
                                    PilotId = (int)reader["PilotId"],
                                    PilotNo = (int)reader["PilotNo"],
                                    PilotAdSoyad = (string)reader["PilotAdSoyad"],
                                    PilotAktifMi = (bool)reader["PilotAktifMi"],
                                    TakimId = (int)reader["TakimId"],

                                    TakimAdi = reader["TakimAdi"] != DBNull.Value ? reader["TakimAdi"].ToString() : "Takımsız"
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Pilotları listeleme işleminde hata oluştu!", ex);
            }

            return pilotlar;
        }

        public bool PilotPasifeAl(int pilotId)
        {
            try
            {
                using (SqlConnection connection = SqlHelper.GetConnection())
                {
                    using (SqlCommand command = new SqlCommand("sp_PilotPasifeAl", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@PilotId", pilotId);

                        connection.Open();
                        int result = command.ExecuteNonQuery();
                        return result > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Pilot pasife alma işleminde hata oluştu! PilotId: {pilotId}", ex);
            }
        }

        public List<Pilot> TakiminPilotlariniGetir(int takimId)
        {
            List<Pilot> pilotlar = new List<Pilot>();

            try
            {
                using (SqlConnection connection = SqlHelper.GetConnection())
                {
                    using (SqlCommand command = new SqlCommand("sp_TakiminPilotlariniGetir", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@TakimId", takimId);

                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                pilotlar.Add(new Pilot
                                {
                                    PilotId = (int)reader["PilotId"],
                                    PilotAdSoyad = (string)reader["PilotAdSoyad"],
                                    PilotNo = (int)reader["PilotNo"],
                                    PilotAktifMi = (bool)reader["PilotAktifMi"],
                                    TakimId = (int)reader["TakimId"]
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Takımın pilotlarını getirme işleminde hata oluştu! TakimId: {takimId}", ex);
            }

            return pilotlar;
        }
    }
}


