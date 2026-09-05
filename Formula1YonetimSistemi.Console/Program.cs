using Formula1YonetimSistemi.Common.DTO;
using Formula1YonetimSistemi.Common.Helpers;
using Formula1YonetimSistemi.Service;

// Global Exception Handler

AppDomain.CurrentDomain.UnhandledException += (sender, e) =>
{
    if (e.ExceptionObject is Exception ex)
    {
        ExceptionHandler.YazdiExcepsionu(exception: ex);
    }
    Environment.Exit(1);
}; 


try
{
    SPilot pilotServisi = new SPilot();

    Pilot arananPilot = new Pilot { PilotId = 3 }; 
    Pilot bulunanPilot = pilotServisi.SGetirPilotById(sorgulanacakPilot: arananPilot);

    if (bulunanPilot != null)
    {
        ExceptionHandler.YazdiBasari(mesaj: "Pilot başarıyla bulundu!");
        Console.WriteLine($"ID: {bulunanPilot.PilotId}, Ad Soyad: {bulunanPilot.PilotAdSoyad}, No: {bulunanPilot.PilotNo}");
    }
    else
    {
        ExceptionHandler.YazdiUyari(mesaj: "Pilot bulunamadı!");
    }


    Console.WriteLine("\n--- Ferrari (Takım ID: 8) Pilotları ---");
    List<Pilot> ferrariPilotlari = pilotServisi.SPilotlariGetir(takimId: 8);

    if (ferrariPilotlari.Count > 0)
    {
        foreach (var pilot in ferrariPilotlari)
        {
            Console.WriteLine($"- {pilot.PilotAdSoyad} (No: {pilot.PilotNo})");
        }
    }
    else
    {
        ExceptionHandler.YazdiUyari(mesaj: "Bu takımın kayıtlı pilotu yok.");
    }
}
catch (Exception ex)
{
    ExceptionHandler.YazdiExcepsionu(exception: ex);
}

Console.ReadLine();