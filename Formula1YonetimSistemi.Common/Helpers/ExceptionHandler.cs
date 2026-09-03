using System;
using Microsoft.Data.SqlClient;

namespace Formula1YonetimSistemi.Common.Helpers
{
    /// <summary>
    /// Console uygulamasında oluşan exception'ları detaylı olarak göstermek için helper sınıfı
    /// </summary>
    public class ExceptionHandler
    {
        /// <summary>
        /// Exception'ı console'a renklendirerek ve detaylı şekilde yazdırır
        /// </summary>
        /// <param name="exception">Yazılacak exception</param>
        public static void YazdiExcepsionu(Exception exception)
        {
            YazdiExcepsionu(exception, 0);
        }

        /// <summary>
        /// Exception'ı çeşitli seviyelerde yazdırır (iç hatalar için recursive)
        /// </summary>
        /// <param name="exception">Yazılacak exception</param>
        /// <param name="seviye">Hata seviyesi (0 = ana hata, 1+ = iç hatalar)</param>
        private static void YazdiExcepsionu(Exception exception, int seviye = 0)
        {
            if (exception == null) return;

            // Ana hata başlığı
            if (seviye == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n╔════════════════════════════════════════════════════════════════╗");
                Console.WriteLine("║                       ⚠️  HATA OLUŞTU!  ⚠️                     ║");
                Console.WriteLine("╚════════════════════════════════════════════════════════════════╝\n");
            }

            string girintili = new string(' ', seviye * 2);

            // Hata Tipi
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"{girintili}❌ [{seviye}] Hata Tipi: {exception.GetType().Name}");
            Console.WriteLine($"{girintili}📝 Hata Mesajı: {exception.Message}");

            // SQL Exception özellikleri
            if (exception is SqlException sqlEx)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine($"{girintili}🗄️  SQL Error Number: {sqlEx.Number}");
                Console.WriteLine($"{girintili}🗄️  SQL Error Line: {sqlEx.LineNumber}");

                if (!string.IsNullOrEmpty(sqlEx.Procedure))
                {
                    Console.WriteLine($"{girintili}🗄️  SQL Procedure: {sqlEx.Procedure}");
                }
            }

            // Stack Trace
            Console.ForegroundColor = ConsoleColor.Red;
            if (!string.IsNullOrEmpty(exception.StackTrace))
            {
                Console.WriteLine($"{girintili}🔍 Stack Trace:");
                var stackLines = exception.StackTrace.Split('\n');
                foreach (var line in stackLines)
                {
                    if (!string.IsNullOrWhiteSpace(line))
                    {
                        Console.WriteLine($"{girintili}   {line.Trim()}");
                    }
                }
            }

            // İç Hatalar
            if (exception.InnerException != null)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"\n{girintili}└─ İÇ HATA DETAYI:");
                Console.ResetColor();
                YazdiExcepsionu(exception.InnerException, seviye + 1);
            }

            // Ana hata kapanış
            if (seviye == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n╔════════════════════════════════════════════════════════════════╗");
                Console.ResetColor();
            }
        }

        /// <summary>
        /// Başarı mesajını yeşil renkte ekrana yazdırır
        /// </summary>
        /// <param name="mesaj">Mesaj metni</param>
        public static void YazdiBasari(string mesaj)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\n✅ {mesaj}\n");
            Console.ResetColor();
        }

        /// <summary>
        /// Uyarı mesajını sarı renkte ekrana yazdırır
        /// </summary>
        /// <param name="mesaj">Mesaj metni</param>
        public static void YazdiUyari(string mesaj)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"\n⚠️  {mesaj}\n");
            Console.ResetColor();
        }

        /// <summary>
        /// Bilgi mesajını mavi renkte ekrana yazdırır
        /// </summary>
        /// <param name="mesaj">Mesaj metni</param>
        public static void YazdiBilgi(string mesaj)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"\nℹ️  {mesaj}\n");
            Console.ResetColor();
        }

        /// <summary>
        /// Hata mesajını kırmızı renkte ekrana yazdırır
        /// </summary>
        /// <param name="mesaj">Mesaj metni</param>
        public static void YazdiHata(string mesaj)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"\n❌ {mesaj}\n");
            Console.ResetColor();
        }
    }
}
