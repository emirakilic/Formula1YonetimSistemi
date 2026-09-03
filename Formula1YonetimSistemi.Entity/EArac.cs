using Formula1YonetimSistemi.Common.DTO;
using Formula1YonetimSistemi.Common.Helpers;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace Formula1YonetimSistemi.Entity
{
    public class EArac
    {
        public EArac()
        {

        }

        /// <summary>
        /// Yeni bir araç ekler
        /// </summary>
        public bool AracEkle(string aracSasiKodu, string aracMotorTedarikcisi, int takimId)
        {
            try
            {
                using (SqlConnection connection = SqlHelper.GetConnection())
                {
                    using (SqlCommand command = new SqlCommand("sp_AracEkle", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@AracSasiKodu", aracSasiKodu);
                        command.Parameters.AddWithValue("@AracMotorTedarikcisi", aracMotorTedarikcisi);
                        command.Parameters.AddWithValue("@TakimId", takimId);

                        connection.Open();
                        int result = command.ExecuteNonQuery();
                        return result > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                string hataDetayi = $"Araç ekleme işleminde hata oluştu!\n" +
                    $"Stored Procedure: sp_AracEkle\n" +
                    $"Parametreler - Şasi Kodu: {aracSasiKodu}, Motor Tedarikçisi: {aracMotorTedarikcisi}, Takım ID: {takimId}\n" +
                    $"Orijinal Hata: {ex.Message}";

                throw new Exception(hataDetayi, ex);
            }
        }

        /// <summary>
        /// ID'ye göre araç getirir
        /// </summary>
        public Arac GetirAracById(int sorgulanacakAracId)
        {
            try
            {
                using (SqlConnection connection = SqlHelper.GetConnection())
                {
                    using (SqlCommand command = new SqlCommand("sp_AracGetirById", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@AracId", sorgulanacakAracId);

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
                // SQL Exception bilgilerini detaylı olarak gönder
                string hataDetayi = $"Araç getirme işleminde hata oluştu!\n" +
                    $"Stored Procedure: sp_AracGetirById\n" +
                    $"Parametre - AracId: {sorgulanacakAracId}\n" +
                    $"Orijinal Hata: {ex.Message}";

                throw new Exception(hataDetayi, ex);
            }
        }

        /// <summary>
        /// Araç bilgilerini günceller
        /// </summary>
        public bool AracGuncelle(int aracId, string aracSasiKodu, string aracMotorTedarikcisi, int takimId)
        {
            try
            {
                using (SqlConnection connection = SqlHelper.GetConnection())
                {
                    using (SqlCommand command = new SqlCommand("sp_AracGuncelle", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@AracId", aracId);
                        command.Parameters.AddWithValue("@AracSasiKodu", aracSasiKodu);
                        command.Parameters.AddWithValue("@AracMotorTedarikcisi", aracMotorTedarikcisi);
                        command.Parameters.AddWithValue("@TakimId", takimId);

                        connection.Open();
                        int result = command.ExecuteNonQuery();
                        return result > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                string hataDetayi = $"Araç güncelleme işleminde hata oluştu!\n" +
                    $"Stored Procedure: sp_AracGuncelle\n" +
                    $"Parametreler - Araç ID: {aracId}, Şasi Kodu: {aracSasiKodu}, Motor Tedarikçisi: {aracMotorTedarikcisi}, Takım ID: {takimId}\n" +
                    $"Orijinal Hata: {ex.Message}";

                throw new Exception(hataDetayi, ex);
            }
        }

        /// <summary>
        /// Araç silir
        /// </summary>
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
                string hataDetayi = $"Araç silme işleminde hata oluştu!\n" +
                    $"Stored Procedure: sp_AracSil\n" +
                    $"Parametre - Araç ID: {aracId}\n" +
                    $"Orijinal Hata: {ex.Message}";

                throw new Exception(hataDetayi, ex);
            }
        }

        /// <summary>
        /// Araçları listeler (TakımId ve Motor Tedarikçisine göre filtrleme yapılabilir)
        /// </summary>
        public List<Arac> AraclariGetir(int? takimId = null, string aracMotorTedarikcisi = null)
        {
            List<Arac> araclar = new List<Arac>();

            try
            {
                using (SqlConnection connection = SqlHelper.GetConnection())
                {
                    using (SqlCommand command = new SqlCommand("sp_AraclariGetir", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@TakimId", takimId != null ? (object)takimId : DBNull.Value);
                        command.Parameters.AddWithValue("@AracMotorTedarikcisi", aracMotorTedarikcisi != null ? (object)aracMotorTedarikcisi : DBNull.Value);

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
                                    TakimId = (int)reader["TakimId"]
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                string hataDetayi = $"Araçları listeleme işleminde hata oluştu!\n" +
                    $"Stored Procedure: sp_AraclariGetir\n" +
                    $"Parametreler - Takım ID: {(takimId != null ? takimId.ToString() : "NULL")}, Motor Tedarikçisi: {(aracMotorTedarikcisi ?? "NULL")}\n" +
                    $"Orijinal Hata: {ex.Message}";

                throw new Exception(hataDetayi, ex);
            }

            return araclar;
        }
    }
}
