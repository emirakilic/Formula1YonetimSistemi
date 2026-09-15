using Formula1YonetimSistemi.Common.DTO;
using Formula1YonetimSistemi.Common.Helpers;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;
using Formula1YonetimSistemi.Common;

namespace Formula1YonetimSistemi.Entity
{
    public class ERapor
    {
        public List<PilotSiralama> PilotSampiyonasiSiralamasiGetir(int sezon)
        {
            List<PilotSiralama> liste = new List<PilotSiralama>();

            using (SqlConnection connection = SqlHelper.GetConnection())
            {
                using (SqlCommand command = new SqlCommand("sp_PilotSampiyonasiSiralamasi", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Sezon", sezon);

                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            liste.Add(new PilotSiralama
                            {
                                // Not: DTO içindeki ismin PilotAdi mi PilotAdSoyad mı olduğuna göre burayı kendi sınıfına uydurabilirsin
                                PilotAdi = reader["PilotAdi"].ToString(),
                                ToplamPuan = Convert.ToInt32(reader["ToplamPuan"])
                            });
                        }
                    }
                }
            }
            return liste;
        }

        // Metodun içine 'int sezon' ekledik
        public List<TakimSiralama> TakimSampiyonasiSiralamasiGetir(int sezon)
        {
            List<TakimSiralama> liste = new List<TakimSiralama>();

            using (SqlConnection connection = SqlHelper.GetConnection())
            {
                using (SqlCommand command = new SqlCommand("sp_TakimSampiyonasiSiralamasi", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    // SQL'deki @Sezon parametresine C#'tan gelen yılı gönderiyoruz!
                    command.Parameters.AddWithValue("@Sezon", sezon);

                    connection.Open();

                    // İşte senin kodunda eksik olan o "Geri kalan okuma" kısmı burası:
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            liste.Add(new TakimSiralama
                            {
                                TakimAdi = reader["TakimAdi"].ToString(),
                                ToplamPuan = Convert.ToInt32(reader["ToplamPuan"])
                            });
                        }
                    }
                }
            }
            return liste; // Hatayı çözen sihirli satır
        }

        public List<Formula1YonetimSistemi.Common.DTO.Istikrar> PilotIstikrariGetir(int pilotId, int sezon)
        {
            List<Formula1YonetimSistemi.Common.DTO.Istikrar> istikrarListesi = new List<Formula1YonetimSistemi.Common.DTO.Istikrar>();

            using (SqlConnection connection = SqlHelper.GetConnection())
            {
                using (SqlCommand command = new SqlCommand("sp_PilotIstikrari", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    // Parametreleri SQL'e yolluyoruz
                    command.Parameters.AddWithValue("@PilotId", pilotId);
                    command.Parameters.AddWithValue("@Sezon", sezon);

                    connection.Open();

                    // Verileri SQL'den okuyoruz
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            istikrarListesi.Add(new Formula1YonetimSistemi.Common.DTO.Istikrar
                            {
                                GrandPrix = reader["GrandPrix"].ToString(),
                                Pozisyon = Convert.ToInt32(reader["Pozisyon"])
                            });
                        }
                    }
                }
            }

            return istikrarListesi; // CS0161 Hatasını çözen sihirli satır!
        } // CS1513 Hatasını çözen kapanış parantezi!
    }
}
