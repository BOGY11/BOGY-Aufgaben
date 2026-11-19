---
title: "3 - Taschenrechner"
parent: Zusatzaufgaben
nav_order: 3
---

# Zusatzaufgabe 3 - Taschenrechner

| | |
|---|---|
| **Schwierigkeit** | Leicht bis Mittel (Stufe 4) |
| **Dauer** | ca. 1,5 Stunden |
| **Benötigte Kapitel** | 1–8 und 10 |

## Ziel

Du baust einen Konsolen-Taschenrechner. Er beginnt ganz einfach mit zwei Zahlen und einem Rechenzeichen. Am Ende kann man ganze Rechnungen wie `12 * 3` in einer Zeile eingeben, mit dem letzten Ergebnis weiterrechnen und sich den Verlauf anzeigen lassen.

Dabei übst du:
- `double` und Kommazahlen
- `switch` mit Zeichenketten
- Methoden mit Parametern und Rückgabewert
- Fehler abfangen (Division durch 0, falsche Eingaben)
- `List<string>` und `Split`

---

## Was du dafür brauchst

**Kommazahlen einlesen**

```csharp
if (double.TryParse(Console.ReadLine(), out double zahl))
{
    Console.WriteLine($"Du hast {zahl} eingegeben.");
}
```

Auf einem deutschen Windows schreibst du Kommazahlen mit **Komma**: `2,5`. Bei `2.5` wird daraus `25`!

**Einen Text an Leerzeichen zerlegen**

```csharp
string eingabe = "12 * 3";
string[] teile = eingabe.Split(' ');
// teile[0] = "12", teile[1] = "*", teile[2] = "3"
```

**Nützliche Methoden aus `Math`**

| Methode | Bedeutung | Beispiel |
|---|---|---|
| `Math.Pow(a, b)` | a hoch b | `Math.Pow(2, 3)` → 8 |
| `Math.Sqrt(a)` | Wurzel | `Math.Sqrt(16)` → 4 |
| `Math.Round(a, 2)` | Runden auf 2 Stellen | `Math.Round(3.14159, 2)` → 3,14 |

---

## Aufgaben

### Stufe 1: Eine Rechnung

Frage nach zwei Zahlen und einem Rechenzeichen (`+`, `-`, `*`, `/`) und gib das Ergebnis aus. Verwende dafür ein `switch`.

```text
=== Taschenrechner ===
Erste Zahl: 7,5
Rechenzeichen (+ - * /): *
Zweite Zahl: 2
Ergebnis: 7,5 * 2 = 15
```

{% capture tipp %}
Das Rechenzeichen liest du als `string` ein und verwendest es direkt im `switch`:

```csharp
switch (zeichen)
{
    case "+":
        ergebnis = a + b;
        break;
    case "-":
        ergebnis = a - b;
        break;
    // ...
    default:
        Console.WriteLine("Unbekanntes Rechenzeichen!");
        break;
}
```
{% endcapture %}
{% include tipp.html inhalt=tipp %}

### Stufe 2: Methoden und Fehler abfangen

Räume dein Programm mit Methoden auf:

1. `static double LiesZahl(string frage)` fragt so lange, bis eine gültige Zahl eingegeben wurde.
2. `static string LiesZeichen()` akzeptiert nur `+`, `-`, `*`, `/`.
3. `static double Rechne(double a, string zeichen, double b)` gibt das Ergebnis zurück.

Bei einer **Division durch 0** soll das Programm nicht `∞` ausgeben, sondern eine verständliche Fehlermeldung.

```text
Erste Zahl: zehn
Das ist keine Zahl. Nochmal: 10
Rechenzeichen (+ - * /): %
Nur + - * / erlaubt. Nochmal: /
Zweite Zahl: 0
Durch 0 kann man nicht teilen!
```

{% capture tipp %}
Bei `double` stürzt eine Division durch 0 **nicht** ab, sondern ergibt `∞` (unendlich). Du musst das also selbst prüfen, bevor du rechnest:

```csharp
if (zeichen == "/" && b == 0)
{
    Console.WriteLine("Durch 0 kann man nicht teilen!");
}
```

Alternative für Fortgeschrittene: In `Rechne` mit `throw new DivideByZeroException();` einen Fehler auslösen und ihn im Hauptprogramm mit `try`/`catch` abfangen (Kapitel 10).
{% endcapture %}
{% include tipp.html titel="Tipp zur Division durch 0" inhalt=tipp %}

### Stufe 3: Weiterrechnen und Verlauf

Der Taschenrechner läuft jetzt in einer Schleife mit Menü:

```text
1) Neue Rechnung
2) Mit Ergebnis weiterrechnen
3) Verlauf anzeigen
4) Beenden
```

- Bei **2** wird das letzte Ergebnis als erste Zahl verwendet. Gab es noch keine Rechnung, erscheint ein Hinweis.
- Jede Rechnung wird als Text in einer `List<string>` gespeichert, z. B. `"7,5 * 2 = 15"`.
- Bei **3** wird der Verlauf nummeriert angezeigt. Ist er leer, steht dort „Noch keine Rechnungen“.

```text
=== Verlauf ===
1. 7,5 * 2 = 15
2. 15 - 3 = 12
3. 12 / 4 = 3
```

{% capture tipp %}
Ob es schon ein Ergebnis gibt, merkst du dir am einfachsten mit einer `bool`-Variable:

```csharp
double letztesErgebnis = 0;
bool hatErgebnis = false;
```

Nach jeder erfolgreichen Rechnung setzt du `hatErgebnis = true;`.
{% endcapture %}
{% include tipp.html inhalt=tipp %}

### Stufe 4: Rechnung in einer Zeile

Statt drei einzelner Fragen gibt man die Rechnung in **einer Zeile** ein:

```text
Rechnung (oder "exit"): 12 * 3
= 36
Rechnung (oder "exit"): 2,5 + 4
= 6,5
Rechnung (oder "exit"): 5 +
Format: Zahl Zeichen Zahl, z. B. 3 + 4
Rechnung (oder "exit"): exit
```

Zerlege die Eingabe mit `Split`, prüfe, ob es genau **3 Teile** sind, und wandle Teil 1 und Teil 3 in Zahlen um. Nutze dafür deine Methode `Rechne` aus Stufe 2.

{% capture tipp %}
Wenn jemand aus Versehen zwei Leerzeichen tippt (`12  * 3`), entstehen leere Teile. Das verhinderst du so:

```csharp
string[] teile = eingabe.Split(' ', StringSplitOptions.RemoveEmptyEntries);

if (teile.Length != 3)
{
    Console.WriteLine("❌ Format: Zahl Zeichen Zahl, z. B. 3 + 4");
    continue;
}
```
{% endcapture %}
{% include tipp.html titel="Tipp zu Split" inhalt=tipp %}

---

## Typische Fehler

| Fehler | Was passiert | Lösung |
|---|---|---|
| `int` statt `double` | `7 / 2` ergibt `3` | Für den Taschenrechner überall `double` verwenden |
| `2.5` eingegeben | Das Ergebnis ist zehnmal zu groß | Auf deutschem Windows `2,5` eingeben |
| `break` im `switch` vergessen | Fehler beim Kompilieren | Jeder `case` endet mit `break;` |
| Ergebnis wird auch bei Fehler gespeichert | Im Verlauf steht `5 / 0 = 0` | Nur nach erfolgreicher Rechnung in die Liste schreiben |
| `teile[2]` ohne Längenprüfung | Absturz mit `IndexOutOfRangeException` | Vorher `teile.Length == 3` prüfen |

---

## Extras

1. **Mehr Rechenarten:** Potenz (`^`), Wurzel (`sqrt 16`) und Prozent (`200 % 15` = 15 % von 200).
2. **Schöne Ausgabe:** Runde Ergebnisse auf höchstens 4 Nachkommastellen, damit nicht `0,30000000000000004` erscheint.
3. **Lange Rechnungen:** Erlaube Rechnungen wie `2 + 3 * 4 - 1` und rechne einfach von links nach rechts.
4. **Für Profis:** Beachte Punkt-vor-Strich, sodass `2 + 3 * 4` richtig `14` ergibt. Tipp: Rechne zuerst alle `*` und `/` aus und ersetze sie in einer Liste durch ihr Ergebnis.

---

## Checkliste

- [ ] Alle vier Grundrechenarten funktionieren, auch mit Kommazahlen
- [ ] Buchstaben oder falsche Rechenzeichen bringen das Programm nicht zum Absturz
- [ ] Division durch 0 ergibt eine verständliche Fehlermeldung
- [ ] Ich kann mit dem letzten Ergebnis weiterrechnen
- [ ] Der Verlauf zeigt alle erfolgreichen Rechnungen
- [ ] Eine Rechnung wie `12 * 3` in einer Zeile wird richtig erkannt

---

[← Schere-Stein-Papier](Schere-Stein-Papier.md) · [Übersicht](index.md) · [Snackautomat →](Snackautomat.md)
