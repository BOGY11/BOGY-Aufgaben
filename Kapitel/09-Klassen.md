---
title: 09 - Klassen und Objekte
parent: Kapitel
has_children: true
has_toc: false
nav_order: 9
---
# Kapitel 9 – Klassen und Objekte

*Einführung in die objektorientierte Programmierung*

[← Methoden](08-Methoden.md) | [Übersicht](../README.md) | [Weiter: Fehler abfangen →](10-Fehler-abfangen.md)

## Ziel

Nach diesem Kapitel kannst du:

- den Unterschied zwischen **Klasse** und **Objekt** erklären
- eine eigene Klasse mit Eigenschaften, Konstruktor und Methoden schreiben
- Objekte erzeugen und benutzen

---

## Erklärung

### Bauplan und Bauwerk

Eine **Klasse** ist ein **Bauplan**. Ein **Objekt** ist ein Ding, das nach diesem Bauplan gebaut wurde.

Vergleich: Eine **Ausstechform** (Klasse) legt fest, wie ein Plätzchen aussieht. Damit kannst du beliebig viele **Plätzchen** (Objekte) ausstechen – jedes kann eine andere Glasur haben.

| Begriff | Bedeutung | Beispiel `Hund` |
|---|---|---|
| **Klasse** | Der Bauplan | `Hund` |
| **Eigenschaft** (Property) | Was ein Objekt **hat** | `Name`, `Alter` |
| **Methode** | Was ein Objekt **kann** | `Bellen()` |
| **Konstruktor** | Wird beim **Erzeugen** aufgerufen und setzt die Startwerte | `Hund(string name, int alter)` |
| **Objekt** | Ein konkretes Ding nach dem Bauplan | `Rex`, 3 Jahre |

### Eine Klasse anlegen

Wenn du nicht weißt, wie du eine Klasse erstellst, schau dir das Tutorial [Neue Klasse erstellen](../Tutorials/CreateClass.md) an.

### Beispiel: Die Klasse `Hund`

**Datei `Hund.cs`:**

```csharp
namespace MeinProjekt;   // Diese Zeile erstellt Visual Studio automatisch – sie darf bleiben.

public class Hund
{
    // Eigenschaften
    public string Name { get; set; }
    public int Alter { get; set; }

    // Konstruktor – heißt GENAU wie die Klasse
    public Hund(string name, int alter)
    {
        Name = name;
        Alter = alter;
    }

    // Methode
    public void Bellen()
    {
        Console.WriteLine($"{Name} sagt: Wuff!");
    }
}
```

**Datei `Program.cs`:**

```csharp
using MeinProjekt;   // Name deines Projekts – nötig, damit Program.cs die Klasse findet

Hund meinHund = new Hund("Rex", 3);
Hund nachbarsHund = new Hund("Bello", 7);

meinHund.Bellen();       // Rex sagt: Wuff!
nachbarsHund.Bellen();   // Bello sagt: Wuff!
Console.WriteLine($"{meinHund.Name} ist {meinHund.Alter} Jahre alt.");
```

- Ein Objekt erzeugst du **immer** mit `new KlassenName(...)`. Dabei musst du alle Parameter des Konstruktors angeben.
- Auf Eigenschaften und Methoden eines Objekts greifst du mit einem **Punkt** zu: `meinHund.Name`, `meinHund.Bellen()`.
- Beide Hunde haben **denselben Bauplan**, aber **eigene Werte**.

### `public` und `private set`

- `public` bedeutet: Von außen (z. B. aus `Program.cs`) darf man darauf zugreifen.
- Mit `{ get; private set; }` darf man den Wert von außen **lesen**, aber nur die Klasse selbst darf ihn **ändern**. Das schützt wichtige Werte – du brauchst das gleich beim Bankkonto.

---

{% capture notiz %}
| Fehler | Was passiert |
|---|---|
| Konstruktor heißt anders als die Klasse | Fehler – der Konstruktor muss **genau** wie die Klasse heißen |
| `Hund` ist in `Program.cs` rot unterstrichen | Es fehlt `using MeinProjekt;` ganz oben (mit dem Namen deines Projekts). Tipp: Mit **Strg + .** schlägt Visual Studio die Lösung vor. |
| `public` vergessen | Fehler: Auf die Eigenschaft oder Methode kann man von außen nicht zugreifen |
| `new` vergessen | Fehler – ohne `new` wird kein Objekt erzeugt |
{% endcapture %}
{%include notiz.html typ="warning" titel="Typische Fehler" offen=false inhalt=notiz %}

---

## Aufgaben

### Aufgabe 9.1 – Dein erster Hund

1. Baue das `Hund`-Beispiel nach und erzeuge **zwei** verschiedene Hunde.
2. Füge eine Methode `Geburtstag()` hinzu, die das Alter um 1 erhöht und ausgibt: `Bello hat Geburtstag und ist jetzt 8 Jahre alt!`

### Aufgabe 9.2 – Bankkonto

Erstelle eine Klasse `BankKonto` mit:

| Bestandteil | Beschreibung |
|---|---|
| `Besitzer` | Name des Kontoinhabers (wird im Konstruktor gesetzt) |
| `Kontostand` | Startet bei `0`. Darf von außen nur **gelesen** werden (`private set`). |
| `Einzahlen(double betrag)` | Erhöht den Kontostand. Negative Beträge sind nicht erlaubt. |
| `Abheben(double betrag)` | Verringert den Kontostand. Der Kontostand darf **nie unter 0** fallen. Gibt `true` zurück, wenn es geklappt hat, sonst `false`. |
| `Anzeigen()` | Gibt Besitzer und Kontostand aus |

Teste deine Klasse mit diesem Programm:

```csharp
BankKonto konto = new BankKonto("Lea");
konto.Einzahlen(100);

if (konto.Abheben(30))
{
    Console.WriteLine("30 € abgehoben.");
}
if (!konto.Abheben(100))
{
    Console.WriteLine("Nicht genug Geld auf dem Konto!");
}

konto.Anzeigen();
```

Erwartete Ausgabe:
```
30 € abgehoben.
Nicht genug Geld auf dem Konto!
Lea: 70,00 €
```

{% capture tipp %}
- Mit `{Kontostand:0.00}` in einem `$"..."`-Text wird der Betrag immer mit zwei Nachkommastellen angezeigt.
- Warum `private set`? Probiere in `Program.cs` einmal `konto.Kontostand = 1000000;` aus.
{% endcapture %}
{% include tipp.html inhalt=tipp %}


### Bonus-Aufgabe 9.3 – Überweisungen

1. Füge eine Methode `Ueberweisen(BankKonto ziel, double betrag)` hinzu. Sie hebt das Geld vom eigenen Konto ab und zahlt es auf das Zielkonto ein – aber nur, wenn genug Geld da ist.
2. Lege drei Konten in einer `List<BankKonto>` an, mache ein paar Überweisungen und gib am Ende alle Konten mit einer `foreach`-Schleife aus.

### Bonus-Aufgabe 9.4 – Deine eigene Klasse

Denk dir selbst eine Klasse aus, zum Beispiel:

- `Spielfigur` mit `Name`, `Leben`, `Angriff` und einer Methode `Angreifen(Spielfigur gegner)`
- `Auto` mit `Marke`, `Tankfuellung` und einer Methode `Fahren(int kilometer)`, die Benzin verbraucht

---

## Checkliste

- [ ] Ich kann den Unterschied zwischen Klasse und Objekt erklären.
- [ ] Ich kann eine Klasse in einer eigenen Datei anlegen.
- [ ] Ich weiß, was ein Konstruktor ist und wie er heißen muss.
- [ ] Ich kann mit `new` Objekte erzeugen und mit `.` auf sie zugreifen.
- [ ] Ich weiß, wofür `private set` gut ist.

---

Hast du noch weitere Fragen, bist bei einzelnen Themen noch unsicher oder möchtest einfach mehr Aufgaben zu diesem Kapitel bearbeiten? Schau dir gerne das Vertiefungskapitel an: \
[Klicke hier, um zur Vertiefung zu gelangen](../Vertiefung/09-Klassen-Vertiefung.md)

---

[← Methoden](08-Methoden.md) | [Übersicht](../README.md) | [Weiter: Fehler abfangen →](10-Fehler-abfangen.md)
