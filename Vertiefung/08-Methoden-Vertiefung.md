---
title: 08 - Vertiefung Methoden
parent: 08 - Methoden
nav_order: 1
---
# Kapitel 8 – Methoden (Vertiefung)

[← Zurück zu Kapitel 8](../Kapitel/08-Methoden.md) | [Übersicht](../README.md) | [Weiter: Klassen Vertiefung →](09-Klassen-Vertiefung.md)

Methoden sind abgeschlossene Bausteine. Sie helfen dir, doppelten Code zu vermeiden und komplexe Programme in kleine, leicht verständliche Häppchen zu zerlegen.

---

## 1. Das Kaffeemaschinen-Modell

Stell dir eine Methode wie eine Kaffeemaschine vor:
- **Eingabe (Parameter):** Kaffeebohnen und Wasser.
- **Verarbeitung (Körper `{ ... }`):** Mahlen, Erhitzen, Filtern.
- **Ausgabe (`return`):** Die Tasse fertiger Kaffee.

```csharp
// Rückgabetyp   Name        Parameter (Zutaten)
int             Addiere     (int a, int b)
{
    int ergebnis = a + b;
    return ergebnis; // Das fertige Produkt wird zurückgegeben!
}
```

### Was ist `void`?
`void` bedeutet auf Englisch „leer“ oder „ungültig“.
Eine Methode mit `void`:
- **Tut etwas** (z. B. Text ausgeben, Datei speichern, Ton abspielen).
- **Gibt aber keinen Wert zurück**, mit dem man weiterrechnen könnte.

```csharp
void Begruesse(string name)
{
    Console.WriteLine($"Hallo {name}!");
    // Kein return nötig!
}
```

---

## 2. Der Gültigkeitsbereich (Scope) von Variablen

Variablen leben **nur innerhalb der geschweiften Klammern `{ }`**, in denen sie deklariert wurden!

```csharp
void TuEtwas()
{
    int geheimnis = 42;
}

Console.WriteLine(geheimnis); // FEHLER! Der Name "geheimnis" ist hier nicht bekannt!
```
Sobald die Methode zu Ende ist (bei der schließenden Klammer `}`), wird die Variable `geheimnis` aus dem Speicher gelöscht. Sie ist außerhalb unsichtbar.

---

## 3. Call by Value: Methoden arbeiten mit Kopien

Wenn du eine Zahl an eine Methode übergibst:
```csharp
void Erhoehe(int x)
{
    x = x + 10;
}

int zahl = 5;
Erhoehe(zahl);
Console.WriteLine(zahl); // Ausgabe: 5 (NICHT 15!)
```
*Warum bleibt `zahl` gleich 5?*
Weil C# den Wert `5` **kopiert** und in den Parameter `x` legt. Die Methode verändert nur ihre eigene Kopie `x`, nicht deine Originalvariable `zahl`!
Wenn du das Ergebnis haben willst, musst du es mit `return` zurückgeben:
```csharp
int Erhoehe(int x)
{
    return x + 10;
}
zahl = Erhoehe(zahl); // Jetzt ist zahl = 15!
```

---

## 4. Vertiefungsaufgaben mit Tipps

### Aufgabe 8.1: Temperatur-Umrechner
Schreibe zwei Methoden:
1. `double CelsiusZuFahrenheit(double celsius)`: Formel: celsius * 1.8 + 32
2. `double FahrenheitZuCelsius(double fahrenheit)`: Formel: (fahrenheit - 32) / 1.8

Teste beide Methoden im Hauptprogramm mit verschiedenen Werten und gib das Ergebnis aus.

{% capture tipp %}
**Lösung / Tipp zu 8.1:**

Hier ist die Implementierung der beiden Rechenmethoden:

```csharp
double CelsiusZuFahrenheit(double celsius)
{
    return (celsius * 1.8) + 32;
}

double FahrenheitZuCelsius(double fahrenheit)
{
    return (fahrenheit - 32) / 1.8;
}

// Testaufrufe:
double c = 20.0;
double f = CelsiusZuFahrenheit(c);
Console.WriteLine($"{c} °C sind {f:F1} °F"); // 68.0 °F

double zurueck = FahrenheitZuCelsius(f);
Console.WriteLine($"{f} °F sind {zurueck:F1} °C"); // 20.0 °C
```
{% endcapture %}
{% include tipp.html inhalt=tipp %}

---

### Aufgabe 8.2: Die Schranke (Guard Clause)
Schreibe eine Methode `bool IstPasswortSicher(string passwort)`.
Das Passwort gilt als sicher, wenn:
- Es mindestens **8 Zeichen** lang ist (`passwort.Length >= 8`)
- Es **nicht** das Wort `"passwort"` oder `"12345678"` ist.

Nutze sogenannte *Guard Clauses* (frühe `return false;`-Abbrüche), um die Lesbarkeit zu verbessern.

{% capture tipp %}
**Lösung / Tipp zu 8.2:**

Guard Clauses prüfen Fehlerfälle sofort am Anfang der Methode und brechen direkt mit `return false` ab:

```csharp
bool IstPasswortSicher(string passwort)
{
    // Zu kurz? Sofort ablehnen!
    if (passwort.Length < 8)
    {
        return false;
    }

    // Bekanntes unsicheres Passwort? Sofort ablehnen!
    string klein = passwort.ToLower();
    if (klein == "passwort" || klein == "12345678")
    {
        return false;
    }

    // Wenn alle Prüfungen überstanden sind:
    return true;
}

// Test:
Console.WriteLine(IstPasswortSicher("abc"));            // False (zu kurz)
Console.WriteLine(IstPasswortSicher("passwort"));       // False (unsicher)
Console.WriteLine(IstPasswortSicher("MeinSicheresPw1")); // True
```
{% endcapture %}
{% include tipp.html inhalt=tipp %}
