---
title: 4 - Snackautomat
parent: Zusatzaufgaben
nav_order: 4
---
# Zusatzaufgabe 4 – Snackautomat

**Schwierigkeit:** Mittel · **Dauer:** ca. 2 Stunden

[← Zusatzaufgabe 1 – Galgenraten](Galgenraten.md) | [Übersicht](../README.md) | [Weiter: Zusatzaufgabe 3 – Tic-Tac-Toe →](TicTacToe.md)

## Ziel

Du programmierst einen **Snackautomaten**, wie er in der Schule oder im Büro steht:
Produkte anzeigen, Münzen einwerfen, Wechselgeld zurückgeben – und ein geheimer **Admin-Modus** zum Auffüllen.

Neu ist hier: Mehrere Klassen-Objekte arbeiten mit Menü, Schleifen und Methoden zusammen.
Außerdem lernst du, warum man mit Geld **nicht** in `double` rechnen sollte.

---

## Was du brauchst

| Thema | Kapitel |
|---|---|
| Rechnen, besonders `/` und `%` | [3](../Kapitel/03-Rechnen-und-Vergleichen.md) |
| `switch` und Schleifen | [5](../Kapitel/05-Verzweigungen.md), [6](../Kapitel/06-Schleifen.md) |
| Listen | [7](../Kapitel/07-Collections.md) |
| Methoden | [8](../Kapitel/08-Methoden.md) |
| Klassen, `private set` | [9](../Kapitel/09-Klassen.md) |
| `LiesZahl` mit `int.TryParse` | [10](../Kapitel/10-Fehler-abfangen.md) |

---

## Neu: Geld in Cent speichern

Probier mal das hier aus:

```csharp
Console.WriteLine(0.1 + 0.2);   // 0,30000000000000004 
```

`double` kann viele Kommazahlen nur **ungefähr** speichern. Bei einem Automaten, der tausendmal rechnet, fehlt dann irgendwann ein Cent.
Deshalb rechnen Programmierer bei Geld oft in **Cent** mit `int`:

```csharp
int preis = 150;        // 1,50 €
int eingeworfen = 200;  // 2,00 €
int rueckgabe = eingeworfen - preis;   // 50 – exakt, ohne Rundungsfehler
```

Nur für die **Anzeige** wird in Euro umgerechnet:

```csharp
string AlsEuro(int cent)
{
    return $"{cent / 100.0:0.00} €";   // 150 → "1,50 €"
}
```

	
{% capture notiz %}
Schreibe `100.0` und nicht `100`! Sonst ist es eine Ganzzahl-Division (Kapitel 3) und aus `150 / 100` wird `1`.
{% endcapture %}
{%include notiz.html typ="warning" titel="Bitte beachten" offen=true inhalt=notiz %}

### Neu: Text in Spalten ausrichten

Mit einer Zahl hinter einem Komma kannst du festlegen, wie **breit** ein Wert in einem `$"..."`-Text ist:

```csharp
Console.WriteLine($"{"Cola",-14}|");     // "Cola          |"  → links ausgerichtet, 14 Zeichen breit
Console.WriteLine($"{"1,50 €",8}|");     // "  1,50 €|"        → rechts ausgerichtet, 8 Zeichen breit
```

---

## Die Stufen

### Stufe 1 – Die Klasse `Produkt`

Lege eine Klasse `Produkt` in einer eigenen Datei an:

| Bestandteil | Beschreibung |
|---|---|
| `Name` | Name des Produkts |
| `PreisInCent` | Preis als `int`, z. B. `150` |
| `Bestand` | Wie viele Stück noch da sind. Darf von außen nur **gelesen** werden (`private set`). |
| Konstruktor | Setzt Name, Preis und Anfangsbestand |
| `bool IstAusverkauft()` | `true`, wenn der Bestand 0 ist |
| `bool Verkaufen()` | Verringert den Bestand um 1. Gibt `false` zurück, wenn nichts mehr da ist. |
| `void Auffuellen(int menge)` | Erhöht den Bestand. Negative Mengen sind nicht erlaubt. |

Lege in `Program.cs` eine `List<Produkt>` mit mindestens **5 Produkten** an (eins davon mit Bestand 0) und zeige sie als Menü an:

```
===== SNACKAUTOMAT =====
1) Cola             1,50 €   5 Stück
2) Wasser           1,00 €   8 Stück
3) Schokoriegel     1,20 €   3 Stück
4) Chips            1,80 €   2 Stück
5) Apfelschorle     1,60 €   AUSVERKAUFT
0) Beenden
```

{% capture notiz %}
Wähle nur Preise, die durch 10 teilbar sind (z. B. 120, nicht 125). Der Automat nimmt nur 10-Cent-Münzen und größere an.
{% endcapture %}
{%include notiz.html typ="note" titel="Hinweis" offen=true inhalt=notiz %}

{% capture tipp %}
- Für die Nummern im Menü brauchst du den Index. Nimm deshalb eine `for`-Schleife statt `foreach` und gib `i + 1` aus.
- Schreibe eine Methode `void ZeigeProdukte(List<Produkt> liste)`. Du brauchst sie später im Admin-Modus noch einmal.
{% endcapture %}
{% include tipp.html inhalt=tipp %}


### Stufe 2 – Kaufen

- Das Menü läuft in einer Schleife, bis der Benutzer `0` wählt.
- Wählt der Benutzer ein Produkt, erfährt er den Preis und wirft **so lange Münzen ein, bis genug Geld drin ist**.
- Der Automat nimmt nur **10, 20, 50, 100 und 200 Cent** an. Andere Münzen werden abgelehnt.
- Mit `0` bricht der Benutzer den Kauf ab und bekommt sein eingeworfenes Geld zurück.
- Ausverkaufte Produkte können nicht gekauft werden. Ungültige Nummern ergeben einen Hinweis.

```
Deine Wahl: 1
Cola kostet 1,50 €.
Eingeworfen: 0,00 € – noch 1,50 €
Münze einwerfen (10, 20, 50, 100, 200 Cent | 0 = Abbruch): 100
Eingeworfen: 1,00 € – noch 0,50 €
Münze einwerfen (10, 20, 50, 100, 200 Cent | 0 = Abbruch): 30
Diese Münze nimmt der Automat nicht an.
Eingeworfen: 1,00 € – noch 0,50 €
Münze einwerfen (10, 20, 50, 100, 200 Cent | 0 = Abbruch): 200
Bitte entnimm dein Produkt: Cola
Rückgabe: 1,50 €
```

{% capture tipp %}
- Schreibe eine Methode `int Kaufen(Produkt produkt)`. Sie gibt den **Betrag zurück, der in der Kasse bleibt** (den Preis, oder `0` bei Abbruch). Den brauchst du in Stufe 4.
- Achtung, Index: Menüpunkt `1` ist `produkte[0]`!
- Für die Münzprüfung bietet sich eine Methode `bool IstGueltigeMuenze(int cent)` an.
{% endcapture %}
{% include tipp.html inhalt=tipp %}


### Stufe 3 – Wechselgeld in Münzen

Der Automat soll das Wechselgeld nicht nur als Betrag ausgeben, sondern **in Münzen** – und zwar mit **möglichst wenigen**:

```
Rückgabe: 1,70 €
  1x 1,00 €
  1x 0,50 €
  1x 0,20 €
```

Schreibe dafür eine Methode `void GibWechselgeld(int betrag)`. Sie wird auch beim Abbruch aufgerufen.

{% capture tipp %}
Fang mit der **größten** Münze an. Erinnerst du dich an das Sekunden-Umrechnen aus Kapitel 3?

- `betrag / 200` → so viele 2-€-Münzen passen hinein
- `betrag % 200` → das bleibt übrig, damit geht es mit der nächsten Münze weiter

Speichere die Münzen in einem Array `{ 200, 100, 50, 20, 10 }` und geh mit `foreach` durch.
{% endcapture %}
{% include tipp.html inhalt=tipp %}


### Stufe 4 – Der geheime Admin-Modus

- Zähle in einer Variablen `kasse` mit, wie viel Geld der Automat insgesamt eingenommen hat.
- Gibt man im Hauptmenü die geheime Nummer `9999` ein, wird nach einer **PIN** gefragt. Die PIN legst du selbst fest.
- Nach **3 falschen Versuchen** geht es zurück zum normalen Menü.
- Im Admin-Menü (mit `switch`) kann man:
  - die Einnahmen ansehen,
  - ein Produkt auswählen und auffüllen,
  - zurück zum Automaten.

```
Deine Wahl: 9999
PIN: 1234
Falsche PIN (1 von 3).
PIN: 4711

--- ADMIN ---
Einnahmen: 4,50 €
1) Produkt auffüllen
0) Zurück
Wahl: 1
...
Welches Produkt? 5
Wie viele Stück? 10
Aufgefüllt.
```

---

## Typische Fehler

| Fehler | Was passiert |
|---|---|
| Geld als `double` gespeichert | Rundungsfehler, z. B. `0,30000000000000004 €` |
| `cent / 100` statt `cent / 100.0` | `1,50 €` wird als `1,00 €` angezeigt |
| `produkte[wahl]` statt `produkte[wahl - 1]` | Falsches Produkt – oder Absturz beim letzten Menüpunkt |
| `Bestand` hat ein öffentliches `set` | Jeder könnte von außen `cola.Bestand = 1000;` schreiben |

---

## Extras

- **Münzvorrat:** Der Automat hat nur eine begrenzte Anzahl jeder Münze zum Wechseln. Eingeworfene Münzen kommen dazu. Kann er nicht passend herausgeben, zeigt er `Bitte passend zahlen` an.
- **Happy Hour:** Im Admin-Modus kann man eine Rabatt-Aktion starten (z. B. 20 % auf alles). Denk an das Runden auf 10 Cent!
- **Klasse `Automat`:** Verschiebe Produktliste, Kasse und PIN in eine eigene Klasse `Automat`. `Program.cs` enthält danach fast nur noch das Menü.

---

## Checkliste

- [ ] Ich kann erklären, warum man Geld besser in Cent als `int` speichert.
- [ ] Ich habe eine Klasse mit `private set` und mehreren Methoden geschrieben.
- [ ] Ich kann mit `/` und `%` einen Betrag in Münzen aufteilen.
- [ ] Mein Automat stürzt bei keiner Eingabe ab.

[← Taschenrechner](Taschenrechner.md) | [Übersicht](../README.md) | [Vokabeltrainer →](Vokabeltrainer.md)
