using Formula1YonetimSistemi.Common.DTO;
using Formula1YonetimSistemi.Common.Helpers;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace Formula1YonetimSistemi.Entity
{
    public class ETakim
    {
        public bool TakimEkle(Takim takim)
        {
            try
            {
                using (SqlConnection connection = SqlHelper.GetConnection())
                {
                    using (SqlCommand command = new SqlCommand("sp_TakimEkle", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@TakimAdi", takim.TakimAdi);
                        command.Parameters.AddWithValue("@MerkezUlke", takim.MerkezUlke);
                        command.Parameters.AddWithValue("@KurulusYili", takim.KurulusYili);
                        command.Parameters.AddWithValue("@KisaAd", takim.KisaAd);

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

        public Takim GetirTakimById(Takim takim)
        {
            try
            {
                using (SqlConnection connection = SqlHelper.GetConnection())
                {
                    using (SqlCommand command = new SqlCommand("sp_TakimGetir", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@TakimId", takim.TakimId);

                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new Takim
                                {
                                    TakimId = (int)reader["TakimId"],
                                    TakimAdi = (string)reader["TakimAdi"],
                                    MerkezUlke = (string)reader["MerkezUlke"],
                                    KurulusYili = (int)reader["KurulusYili"],
                                    KisaAd = (string)reader["KisaAd"]
                                };
                            }
                            return null;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Takım getirme işleminde hata oluştu! TakimId: {takim.TakimId}", ex);
            }
        }

        public bool TakimGuncelle(Takim takim)
        {
            try
            {
                using (SqlConnection connection = SqlHelper.GetConnection())
                {
                    using (SqlCommand command = new SqlCommand("sp_TakimGuncelle", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        
                        command.Parameters.AddWithValue("@TakimId", takim.TakimId);
                        command.Parameters.AddWithValue("@TakimAdi", takim.TakimAdi);
                        command.Parameters.AddWithValue("@MerkezUlke", takim.MerkezUlke);
                        command.Parameters.AddWithValue("@KurulusYili", takim.KurulusYili);
                        command.Parameters.AddWithValue("@KisaAd", takim.KisaAd);

                        connection.Open();
                        int result = command.ExecuteNonQuery();
                        return result > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Takım güncelleme işleminde hata oluştu! TakimId: {takim.TakimId}", ex);
            }
        }

        public bool TakimSil(int takimId)
        {
            try
            {
                using (SqlConnection connection = SqlHelper.GetConnection())
                {
                    using (SqlCommand command = new SqlCommand("sp_TakimSil", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@TakimId", takimId);

                        connection.Open();
                        int result = command.ExecuteNonQuery();
                        return result > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Takım silme işleminde hata oluştu! TakımId: {takimId}", ex);
            }
        }

        public List<Takim> TakimlariGetir(string? takimAdi = null)
        {
            List<Takim> takimlar = new List<Takim>();

            try
            {
                using (SqlConnection connection = SqlHelper.GetConnection())
                {
                    using (SqlCommand command = new SqlCommand("sp_TakimlariGetir", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@TakimAdi", takimAdi != null ? (object)takimAdi : DBNull.Value);

                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                takimlar.Add(new Takim
                                {
                                    TakimId = (int)reader["TakimId"],
                                    TakimAdi = (string)reader["TakimAdi"],
                                    MerkezUlke = (string)reader["MerkezUlke"],
                                    KurulusYili = (int)reader["KurulusYili"],
                                    KisaAd = (string)reader["KisaAd"],
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Takımları listeleme işleminde hata oluştu!", ex);
            }

            return takimlar;
        }

    }
}