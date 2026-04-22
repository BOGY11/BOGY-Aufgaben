// =========================================================
// --- SCHRITT 1: HIER KANNST DU DAS SYSTEM STEUERN ---
// =========================================================

string linie = "S3";
string zielHaltestelle = "Karlsruhe Hbf";
int minutenBisAbfahrt = 120;
bool fahrtFaelltAus = false;
string sonderMeldung = "";

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
        Console.Write($"{linie,-4} {zielHaltestelle,-30} {minutenBisAbfahrt + " Min ",15}");
    }
    Console.ForegroundColor = ConsoleColor.DarkGray;
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
    Console.ReadLine();
