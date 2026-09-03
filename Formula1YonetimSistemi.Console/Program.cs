using Formula1YonetimSistemi.Common.DTO;
using Formula1YonetimSistemi.Common.Helpers;
using Formula1YonetimSistemi.Service;

// Global Exception Handler
AppDomain.CurrentDomain.UnhandledException += (sender, e) =>
{
    ExceptionHandler.YazdiExcepsionu(e.ExceptionObject as Exception);
    Environment.Exit(1);
};

try
{
    // Araç Getirme
    Arac arac = new Arac { AracId = 1 };
    arac = new SArac().SGetirAracById(arac);

    if (arac != null)
    {
        ExceptionHandler.YazdiBasari("Araç başarıyla bulundu!");
        Console.WriteLine($"ID: {arac.AracId}, Şasi: {arac.AracSasiKodu}, Motor: {arac.AracMotorTedarikcisi}");
    }
    else
    {
        ExceptionHandler.YazdiUyari("Araç bulunamadı!");
    }
}
catch (Exception ex)
{
    ExceptionHandler.YazdiExcepsionu(ex);
}
