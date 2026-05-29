//Schritt 2
string kundenName;
bool istKundeErwachsen = false;
int anzahlAnWaben = 0;
string ticketart = "";

//Schritt 2
Console.WriteLine("Bitte follständigen Namen eingeben");
kundenName = Console.ReadLine();

//Schritt 4
Console.WriteLine("Bitte eingeben ob reisende Person erwachsen oder ein Kind ist.");
Console.WriteLine("Eingabemöglichkeiten: 'erwachsen', 'Kind'");

bool eingabeWiederholen = true;
while (eingabeWiederholen)
{
	var eingabeErwachsenOderKind = Console.ReadLine();

	if (eingabeErwachsenOderKind == "erwachsen")
	{
		istKundeErwachsen = true;
		eingabeWiederholen = false;
	}
	else if (eingabeErwachsenOderKind == "Kind")
	{
		istKundeErwachsen = false;
		eingabeWiederholen = false;
	}
	else
	{
		Console.WriteLine("Bitte Eingabemöglichkeiten beachten: 'erwachsen', 'Kind'");
	}
}

//Schritt 5
Console.WriteLine("Bitte Anzahl an Waben eigeben");

eingabeWiederholen = true;
while (eingabeWiederholen)
{
	var eingabeAnzahlAnWaben = Console.ReadLine();
	if (int.TryParse(eingabeAnzahlAnWaben, out anzahlAnWaben))
	{
		eingabeWiederholen = false;
	}
	else
	{
		Console.WriteLine("Bitte nur Ganzzahlen eingeben.");
	}
}

//Schritt 6
Console.WriteLine("Möchtest du ein Tages- Moants- oder Jahresticket kausfen?");
Console.WriteLine("Bitte 'Tag', 'Monat' oder 'Jahr' eingeben.");

eingabeWiederholen = true;
while (eingabeWiederholen)
{
	var eingabeTicketart = Console.ReadLine();
	if (eingabeTicketart == "Tag" || eingabeTicketart == "Monat" || eingabeTicketart == "Jahr")
	{
		ticketart = eingabeTicketart;
		eingabeWiederholen = false;
	}
	else
	{
		Console.WriteLine("Bitte Eingabemöglichkeiten beachten: 'Tag', 'Monat', 'Jahr'");
	}
}

//Schritt 7
double preis = 0;

if (ticketart == "Tag")
{
	if (anzahlAnWaben < 5)
	{
		preis = 3 + (2.5 * anzahlAnWaben);
	}
	else
	{
		preis = 3 + (2.5 * 5);
	}
}
if (ticketart == "Monat")
{
	if (anzahlAnWaben < 5)
	{
		preis = (3 + (2.5 * anzahlAnWaben)) * 20 * 0.7;
	}
	else
	{
		preis = (3 + (2.5 * 5)) * 20 * 0.7;
	}
}
if (ticketart == "Jahr")
{
	if (anzahlAnWaben < 5)
	{
		preis = (3 + (2.5 * anzahlAnWaben)) * 20 * 0.7 * 12 * 0.75;
	}
	else
	{
		preis = (3 + (2.5 * 5)) * 20 * 0.7 * 12 * 0.75;
	}
}

if (!istKundeErwachsen)
{
	preis = preis * 0.7;
}

Console.WriteLine($"Das Ticket Kostet {preis:f2} EUR");
