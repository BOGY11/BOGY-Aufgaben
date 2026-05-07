// =========================================================
// --- SCHRITT 1: HIER KANNST DU DAS SYSTEM STEUERN ---
// =========================================================


string linie = "S3";
string zielHaltestelle = "Karlsruhe Hbf";
int minutenBisAbfahrt = 3;
bool fahrtFaelltAus = false;
string sonderMeldung = "";

while(minutenBisAbfahrt >= 0)
{

    // Das hier schreiben die Schülerinnen mit deiner Hilfe:
    string anzeigeText = "";
    if (minutenBisAbfahrt == 0)
    {
        anzeigeText = "SOFORT EINSTEIGEN!";
    }
    else
    {
        anzeigeText = minutenBisAbfahrt + " Min";
    }

// =========================================================
// --- SCHRITT 2: INIT-SYSTEM (Ab hier bitte nichts ändern) ---
// =========================================================
    Console.Clear();
    Console.CursorVisible = false;

    // Rahmen der Anzeige zeichnen
    Console.ForegroundColor = ConsoleColor.DarkGray;
    Console.WriteLine("╔══════════════════════════════════════════════════════╗");
    Console.WriteLine("║                 ABFAHRTSMONITOR KVV                  ║");
    Console.WriteLine("╠══════════════════════════════════════════════════════╣");

    // Die eigentliche Fahrtdarstellung
    Console.Write("║");
    if (fahrtFaelltAus)
    {
        Console.ForegroundColor = ConsoleColor.Red; // Warnfarbe bei Ausfall
        Console.Write($"{linie,-4} {zielHaltestelle,-30} {"FÄLLT AUS",15}");
    }
    else
    {
        Console.ForegroundColor = ConsoleColor.Yellow; // Klassisches DFI-Orange
        Console.Write($"{linie,-4} {zielHaltestelle,-30} {anzeigeText,15}");
    }
    Console.ForegroundColor = ConsoleColor.DarkGray;
    if (minutenBisAbfahrt > 0 )
        Console.WriteLine("   ║");
    else if(fahrtFaelltAus != true)
        Console.WriteLine("║");
    else
        Console.WriteLine("   ║");

    // Sondermeldung (Ticker)
    Console.WriteLine("╠══════════════════════════════════════════════════════╣");
    Console.Write("║ ");
    Console.ForegroundColor = ConsoleColor.Cyan;

    if (string.IsNullOrWhiteSpace(sonderMeldung))
    {
        Console.Write($"{"*** Gute Fahrt ***",-52}");
    }
    else
    {
        Console.Write($"{sonderMeldung,-52}");
    }
    Console.ForegroundColor = ConsoleColor.DarkGray;
    Console.WriteLine(" ║");
    Console.WriteLine("╚══════════════════════════════════════════════════════╝");

    // Reset für das System
    Console.ForegroundColor = ConsoleColor.White;
    
    Thread.Sleep(1000); // Wir tun so, als wäre eine Sekunde eine Minute
    minutenBisAbfahrt--;
}
