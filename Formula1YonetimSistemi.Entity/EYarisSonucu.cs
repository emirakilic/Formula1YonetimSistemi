using Formula1YonetimSistemi.Common.DTO;
using Formula1YonetimSistemi.Common.Helpers;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;

namespace Formula1YonetimSistemi.Entity
{
    public class EYarisSonucu
    {
        public EYarisSonucu()
        {
            
        }

        public bool YarisSonucuEkle(YarisSonucu sonuc)
        {
            try
            {
                using (SqlConnection connection = SqlHelper.GetConnection())
                {
                    using (SqlCommand command = new SqlCommand("sp_YarisSonucuEkle", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@YarisPozisyon", sonuc.YarisPozisyon);
                        command.Parameters.AddWithValue("@YarisPuani", sonuc.YarisPuani);
                        command.Parameters.AddWithValue("@YarisEnHizliTurZamani", sonuc.YarisEnHizliTurZamani);
                        command.Parameters.AddWithValue("@YarisId", sonuc.YarisId);
                        command.Parameters.AddWithValue("@PilotId", sonuc.PilotId);

                        connection.Open();
                        int result = command.ExecuteNonQuery();
                        return result > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Yarış sonucu ekleme işleminde hata oluştu! Yarış ID: {sonuc.YarisId}, Pilot ID: {sonuc.PilotId}", ex);
            }
        }

        public YarisSonucu GetirYarisSonucuById(YarisSonucu sonuc)
        {
            try
            {
                using (SqlConnection connection = SqlHelper.GetConnection())
                {
                    using (SqlCommand command = new SqlCommand("sp_YarisSonucuGetirById", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@YarisSonucuId", sonuc.YarisSonucId);

                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new YarisSonucu
                                {
                                    YarisSonucId = (int)reader["YarisSonucuId"],
                                    YarisPozisyon = (int)reader["YarisPozisyon"],
                                    YarisPuani = (decimal)reader["YarisPuani"],
                                    YarisEnHizliTurZamani = (string)reader["YarisEnHizliTurZamani"],
                                    YarisId = (int)reader["YarisId"],
                                    PilotId = (int)reader["PilotId"]
                                };
                            }
                            return null;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Yarış sonucu getirme işleminde hata oluştu! YarisSonucuId: {sonuc.YarisSonucId}", ex);
            }
        }

        public bool YarisSonucuGuncelle(YarisSonucu sonuc)
        {
            try
            {
                using (SqlConnection connection = SqlHelper.GetConnection())
                {
                    using (SqlCommand command = new SqlCommand("sp_YarisSonucuGuncelle", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@YarisSonucuId", sonuc.YarisSonucId);
                        command.Parameters.AddWithValue("@YarisPozisyon", sonuc.YarisPozisyon);
                        command.Parameters.AddWithValue("@YarisPuani", sonuc.YarisPuani);
                        command.Parameters.AddWithValue("@YarisEnHizliTurZamani", sonuc.YarisEnHizliTurZamani);
                        command.Parameters.AddWithValue("@YarisId", sonuc.YarisId);
                        command.Parameters.AddWithValue("@PilotId", sonuc.PilotId);

                        connection.Open();
                        int result = command.ExecuteNonQuery();
                        return result > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Yarış sonucu güncelleme işleminde hata oluştu! YarisSonucuId: {sonuc.YarisSonucId}", ex);
            }
        }

        public bool YarisSonucuSil(int yarisSonucuId)
        {
            try
            {
                using (SqlConnection connection = SqlHelper.GetConnection())
                {
                    using (SqlCommand command = new SqlCommand("sp_YarisSonucuSil", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@YarisSonucuId", yarisSonucuId);

                        connection.Open();
                        int result = command.ExecuteNonQuery();
                        return result > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Yarış sonucu silme işleminde hata oluştu! YarisSonucuId: {yarisSonucuId}", ex);
            }
        }

        // Listeleme işlemi genellikle belirli bir yarışın sonuçlarını getirmek için kullanılır.
        public List<YarisSonucu> YarisSonuclariniGetir(YarisSonucu sonucSorgusu)
        {
            List<YarisSonucu> sonuclar = new List<YarisSonucu>();

            try
            {
                using (SqlConnection connection = SqlHelper.GetConnection())
                {
                    using (SqlCommand command = new SqlCommand("sp_YarisSonuclariniGetir", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@PistAdi", string.IsNullOrEmpty(sonucSorgusu.PistAdi) ? DBNull.Value : (object)sonucSorgusu.PistAdi);
                        command.Parameters.AddWithValue("@PilotId", sonucSorgusu.PilotId > 0 ? (object)sonucSorgusu.PilotId : DBNull.Value);

                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                sonuclar.Add(new YarisSonucu
                                {
                                    YarisSonucId = (int)reader["YarisSonucId"],
                                    YarisPozisyon = (int)reader["YarisPozisyon"],
                                    YarisPuani = (decimal)reader["YarisPuani"],
                                    YarisEnHizliTurZamani = reader["YarisEnHizliTurZamani"] != DBNull.Value ? reader["YarisEnHizliTurZamani"].ToString() : "",
                                    YarisId = (int)reader["YarisId"],
                                    PilotId = (int)reader["PilotId"],

                                    // SQL'den gelen isimlerle C# okuması burada eşleşmeli:
                                    PistAdi = reader["PistAdi"].ToString(),
                                    PilotAdi = reader["PilotAdi"].ToString(),           // SQL'de 'AS PilotAdi' dedik
                                    PilotNumarasi = (int)reader["PilotNumarasi"], // "PilotNo" yerine "PilotNumarasi" yaptık             // veya SQL'deki durumuna göre
                                    TakimAdi = reader["TakimAdi"] != DBNull.Value ? reader["TakimAdi"].ToString() : ""
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Yarış sonuçlarını listeleme işleminde hata oluştu: " + ex.Message, ex);
            }

            return sonuclar;
        }
    }
}