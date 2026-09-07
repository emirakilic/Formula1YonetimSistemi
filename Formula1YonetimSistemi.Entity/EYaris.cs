using Formula1YonetimSistemi.Common.DTO;
using Formula1YonetimSistemi.Common.Helpers;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;

namespace Formula1YonetimSistemi.Entity
{
    public class EYaris
    {
        public bool YarisEkle(Yaris yaris)
        {
            try
            {
                using (SqlConnection connection = SqlHelper.GetConnection())
                {
                    using (SqlCommand command = new SqlCommand("sp_YarisEkle", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@PistAdi", yaris.PistAdi);
                        command.Parameters.AddWithValue("@YarisTarihi", yaris.YarisTarihi);
                        command.Parameters.AddWithValue("@TurSayisi", yaris.TurSayisi);
                        command.Parameters.AddWithValue("@Sezon", yaris.Sezon);
                        command.Parameters.AddWithValue("@SezonAyagi", yaris.SezonAyagi);

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

        public Yaris GetirYarisById(Yaris yaris)
        {
            try
            {
                using (SqlConnection connection = SqlHelper.GetConnection())
                {
                    using (SqlCommand command = new SqlCommand("sp_YarisGetir", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@YarisId", yaris.YarisId);

                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new Yaris
                                {
                                    YarisId = (int)reader["YarisId"],
                                    PistAdi = (string)reader["PistAdi"],
                                    YarisTarihi = (DateTime)reader["YarisTarihi"],
                                    TurSayisi = (int)reader["TurSayisi"],
                                    Sezon = (int)reader["Sezon"],
                                    SezonAyagi = (int)reader["SezonAyagi"]
                                };
                            }
                            return null;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Yarış getirme işleminde hata oluştu! YarisId: {yaris.YarisId}", ex);
            }
        }

        public bool YarisGuncelle(Yaris yaris)
        {
            try
            {
                using (SqlConnection connection = SqlHelper.GetConnection())
                {
                    using (SqlCommand command = new SqlCommand("sp_YarisGuncelle", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@YarisId", yaris.YarisId);
                        command.Parameters.AddWithValue("@PistAdi", yaris.PistAdi);
                        command.Parameters.AddWithValue("@YarisTarihi", yaris.YarisTarihi);
                        command.Parameters.AddWithValue("@TurSayisi", yaris.TurSayisi);
                        command.Parameters.AddWithValue("@Sezon", yaris.Sezon);
                        command.Parameters.AddWithValue("@SezonAyagi", yaris.SezonAyagi);

                        connection.Open();
                        int result = command.ExecuteNonQuery();
                        return result > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Yarış güncelleme işleminde hata oluştu! YarisId: {yaris.YarisId}", ex);
            }
        }

        public bool YarisSil(int yarisId)
        {
            try
            {
                using (SqlConnection connection = SqlHelper.GetConnection())
                {
                    using (SqlCommand command = new SqlCommand("sp_YarisSil", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@YarisId", yarisId);

                        connection.Open();
                        int result = command.ExecuteNonQuery();
                        return result > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Yarış silme işleminde hata oluştu! YarisId: {yarisId}", ex);
            }
        }

        public List<Yaris> YarislariGetir(int? sezon = null)
        {
            List<Yaris> yarislar = new List<Yaris>();

            try
            {
                using (SqlConnection connection = SqlHelper.GetConnection())
                {
                    using (SqlCommand command = new SqlCommand("sp_YarislariGetir", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                yarislar.Add(new Yaris
                                {
                                    YarisId = (int)reader["YarisId"],
                                    PistAdi = (string)reader["PistAdi"],
                                    YarisTarihi = (DateTime)reader["YarisTarihi"],
                                    TurSayisi = (int)reader["TurSayisi"],
                                    Sezon = (int)reader["Sezon"],
                                    SezonAyagi = (int)reader["SezonAyagi"]
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("SQL HATA DETAYI: " + ex.Message);
            }

            return yarislar;
        }
    }
}