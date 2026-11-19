---
title: 09 - Vertiefung Klassen und Objekte
parent: 09 - Klassen und Objekte
nav_order: 1
---
# Kapitel 9 – Klassen und Objekte (Vertiefung)

[← Zurück zu Kapitel 9](../Kapitel/09-Klassen.md) | [Übersicht](../README.md) | [Weiter: Fehler abfangen Vertiefung →](10-Fehler-abfangen-Vertiefung.md)

Die objektorientierte Programmierung (OOP) ist das Herzstück von C#. Wenn der Unterschied zwischen einer "Klasse" und einem "Objekt" einmal Klick gemacht hat, wird die gesamte Softwareentwicklung plötzlich viel klarer.

---

## 1. Bauplan vs. Echtes Haus

- **Die Klasse (`class`):** Ist die **technische Zeichnung** (der Bauplan). Auf dem Plan steht, dass jedes Haus eine Wandfarbe, eine Anzahl Fenster und eine Tür hat. Der Bauplan selbst ist aber kein Haus – man kann darin nicht wohnen!
- **Das Objekt (`object` / Instanz):** Ist das **echte, gebaute Haus** aus Stein und Mörtel, das nach dem Bauplan errichtet wurde. Aus einem einzigen Bauplan kannst du 100 verschiedene Häuser bauen: eines ist blau, eines rot, eines hat 4 Fenster.

```csharp
// Der Bauplan:
class Auto
{
    public string Marke;
    public int Geschwindigkeit;
}

// Das Erschaffen der echten Objekte mit "new":
Auto meinGolf = new Auto();
meinGolf.Marke = "VW";

Auto meinTesla = new Auto();
meinTesla.Marke = "Tesla";
```

---

## 2. Was macht `new` eigentlich?

Das Schlüsselwort `new` ist die Baufirma:
1. Es reserviert frischen Speicherplatz auf dem Arbeitsspeicher (auf dem sogenannten *Heap*).
2. Es ruft den **Konstruktor** der Klasse auf, um Startwerte zu setzen.
3. Es gibt eine **Referenz** (eine Art Adresse) auf das neue Objekt zurück.

---

## 3. Die Referenz-Falle: Vorsicht bei Zuweisungen!

Objekte verhalten sich ganz anders als einfache Zahlen:

```csharp
Auto a1 = new Auto();
a1.Marke = "BMW";

Auto a2 = a1; // ACHTUNG! Hier wird KEIN zweites Auto gebaut!
a2.Marke = "Audi";

Console.WriteLine(a1.Marke); // Ausgabe: Audi!
```
*Warum steht bei a1 jetzt auch Audi?*
Weil `a1` und `a2` wie zwei Fernbedienungen für **dasselbe Auto** sind. `a2 = a1` kopiert nicht das Auto, sondern nur die Fernbedienung! Beide zeigen auf denselben Speicherplatz.

---

## 4. Kapselung: Warum Properties (`{ get; set; }`) wichtig sind

Warum schreiben wir nicht einfach `public int guthaben;`?
Weil dann jeder von außen unsinnige Dinge tun könnte:
```csharp
meinKonto.guthaben = -999999; // Plötzlich riesige Schulden ohne Prüfung!
```
Mit Properties und Methoden schützen wir das Objekt:
```csharp
class Bankkonto
{
    public double Kontostand { get; private set; } // Lesen darf jeder, ändern nur das Konto selbst!

    public void Einzahlen(double betrag)
    {
        if (betrag > 0)
        {
            Kontostand += betrag;
        }
    }
}
```

---

## 5. Vertiefungsaufgaben mit Tipps

### Aufgabe 9.1: Klasse `Rechteck`
Erstelle eine Klasse `Rechteck` mit:
- Den Properties `Breite` (`double`) und `Hoehe` (`double`).
- Einem Konstruktor `Rechteck(double breite, double hoehe)`.
- Einer Methode `double BerechneFlaeche()`, die $Breite \times Hoehe$ zurückgibt.
- Einer Methode `double BerechneUmfang()`, die $2 \times (Breite + Hoehe)$ zurückgibt.

Erstelle im Hauptprogramm zwei Rechtecke und gib Fläche und Umfang aus.

{% capture tipp %}
**Lösung / Tipp zu 9.1:**

Hier ist der Bauplan und die Verwendung der Klasse `Rechteck`:

```csharp
class Rechteck
{
    public double Breite { get; set; }
    public double Hoehe { get; set; }

    public Rechteck(double breite, double hoehe)
    {
        Breite = breite;
        Hoehe = hoehe;
    }

    public double BerechneFlaeche()
    {
        return Breite * Hoehe;
    }

    public double BerechneUmfang()
    {
        return 2 * (Breite + Hoehe);
    }
}

// Hauptprogramm:
Rechteck r1 = new Rechteck(5.0, 3.0);
Console.WriteLine($"Rechteck 1: Fläche = {r1.BerechneFlaeche()}, Umfang = {r1.BerechneUmfang()}");

Rechteck r2 = new Rechteck(10.0, 2.5);
Console.WriteLine($"Rechteck 2: Fläche = {r2.BerechneFlaeche()}, Umfang = {r2.BerechneUmfang()}");
```
{% endcapture %}
{% include tipp.html inhalt=tipp %}

---

### Aufgabe 9.2: Ein einfacher RPG-Held
Erstelle eine Klasse `Held` mit:
- `string Name`
- `int Lebenspunkte`
- Einer Methode `NimmSchaden(int schaden)`, die die Lebenspunkte verringert. Die Lebenspunkte dürfen aber **nicht unter 0** fallen!
- Einer Methode `LebtNoch()`, die `true` liefert, wenn `Lebenspunkte > 0` ist.

{% capture tipp %}
**Lösung / Tipp zu 9.2:**

So kannst du sicherstellen, dass die Lebenspunkte nicht ins Minus rutschen:

```csharp
class Held
{
    public string Name { get; set; }
    public int Lebenspunkte { get; private set; }

    public Held(string name, int startLeben)
    {
        Name = name;
        Lebenspunkte = startLeben;
    }

    public void NimmSchaden(int schaden)
    {
        Lebenspunkte -= schaden;
        if (Lebenspunkte < 0)
        {
            Lebenspunkte = 0;
        }
        Console.WriteLine($"{Name} erleidet {schaden} Schaden. Verbleibendes Leben: {Lebenspunkte}");
    }

    public bool LebtNoch()
    {
        return Lebenspunkte > 0;
    }
}

// Test:
Held ritter = new Held("Lancelot", 25);
ritter.NimmSchaden(10);
ritter.NimmSchaden(20); // Sinkt auf 0, nicht auf -5!
Console.WriteLine($"Lebt Lancelot noch? {ritter.LebtNoch()}");
```
{% endcapture %}
{% include tipp.html inhalt=tipp %}
