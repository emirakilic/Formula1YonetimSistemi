using Formula1YonetimSistemi.Common.DTO;
using Formula1YonetimSistemi.Common.Helpers;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;

namespace Formula1YonetimSistemi.Entity
{
    public class EArac
    {
        public EArac()
        {
            
        }

        public bool AracEkle(Arac arac)
        {
            try
            {
                using (SqlConnection connection = SqlHelper.GetConnection())
                {
                    using (SqlCommand command = new SqlCommand("sp_AracEkle", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@AracSasiKodu", arac.AracSasiKodu);
                        command.Parameters.AddWithValue("@AracMotorTedarikcisi", arac.AracMotorTedarikcisi);
                        command.Parameters.AddWithValue("@TakimId", arac.TakimId);

                        connection.Open();
                        int result = command.ExecuteNonQuery();
                        return result > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Araç ekleme işleminde hata oluştu! Şasi: {arac.AracSasiKodu}, Motor: {arac.AracMotorTedarikcisi}", ex);
            }
        }

        public Arac GetirAracById(Arac arac)
        {
            try
            {
                using (SqlConnection connection = SqlHelper.GetConnection())
                {
                    using (SqlCommand command = new SqlCommand("sp_AracGetirById", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@AracId", arac.AracId);

                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new Arac
                                {
                                    AracId = (int)reader["AracId"],
                                    AracSasiKodu = (string)reader["AracSasiKodu"],
                                    AracMotorTedarikcisi = (string)reader["AracMotorTedarikcisi"],
                                    TakimId = (int)reader["TakimId"],
                                    TakimAdi = reader["TakimAdi"] != DBNull.Value ? (string)reader["TakimAdi"] : ""
                                };
                            }
                            return null;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Araç getirme işleminde hata oluştu! AracId: {arac.AracId}", ex);
            }
        }

        public bool AracGuncelle(Arac arac)
        {
            try
            {
                using (SqlConnection connection = SqlHelper.GetConnection())
                {
                    using (SqlCommand command = new SqlCommand("sp_AracGuncelle", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@AracId", arac.AracId);
                        command.Parameters.AddWithValue("@AracSasiKodu", arac.AracSasiKodu);
                        command.Parameters.AddWithValue("@AracMotorTedarikcisi", arac.AracMotorTedarikcisi);
                        command.Parameters.AddWithValue("@TakimId", arac.TakimId);

                        connection.Open();
                        int result = command.ExecuteNonQuery();
                        return result > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Araç güncelleme işleminde hata oluştu! AracId: {arac.AracId}", ex);
            }
        }

        public bool AracSil(int aracId)
        {
            try
            {
                using (SqlConnection connection = SqlHelper.GetConnection())
                {
                    using (SqlCommand command = new SqlCommand("sp_AracSil", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@AracId", aracId);

                        connection.Open();
                        int result = command.ExecuteNonQuery();
                        return result > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Araç silme işleminde hata oluştu! AracId: {aracId}", ex);
            }
        }

        public List<Arac> AraclariGetir(Arac aramaKriteri = null)
        {
            List<Arac> araclar = new List<Arac>();
            try
            {
                using (SqlConnection connection = SqlHelper.GetConnection())
                {
                    using (SqlCommand command = new SqlCommand("sp_AraclariGetir", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        object p_takimId = DBNull.Value;

                        // DTO'nun içi doluysa ve bir takım seçildiyse, o ID'yi alıyoruz
                        if (aramaKriteri != null && aramaKriteri.TakimId > 0)
                        {
                            p_takimId = aramaKriteri.TakimId;
                        }

                        command.Parameters.AddWithValue("@TakimId", p_takimId);
                        // Motor parametresi SQL'de varsa hata vermemesi için null geçiyoruz
                        command.Parameters.AddWithValue("@AracMotorTedarikcisi", DBNull.Value);

                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                araclar.Add(new Arac
                                {
                                    AracId = (int)reader["AracId"],
                                    AracSasiKodu = (string)reader["AracSasiKodu"],
                                    AracMotorTedarikcisi = (string)reader["AracMotorTedarikcisi"],
                                    TakimId = (int)reader["TakimId"],
                                    TakimAdi = reader["TakimAdi"] != DBNull.Value ? (string)reader["TakimAdi"] : ""
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Araçları listeleme işleminde hata oluştu!", ex);
            }
            return araclar;
        }
    }
}