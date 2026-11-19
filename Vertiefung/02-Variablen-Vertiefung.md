---
title: 02 - Vertiefung Variablen und Datentypen
parent: 02 - Variablen und Datentypen
nav_order: 1
---
# Kapitel 2 – Variablen und Datentypen (Vertiefung)

[← Zurück zu Kapitel 2](../Kapitel/02-Variablen.md) | [Übersicht](../README.md) | [Weiter: Rechnen und Vergleichen Vertiefung →](03-Rechnen-und-Vergleichen-Vertiefung.md)

In diesem Vertiefungskapitel schauen wir uns genauer an, was im Arbeitsspeicher (RAM) passiert, warum C# so streng mit Datentypen ist und wie du typische Fehler vermeidest.

---

## 1. Was passiert im Arbeitsspeicher?

Stell dir den Arbeitsspeicher wie ein riesiges Regal mit nummerierten Fächern vor:

```text
[Fach 0x1A] -> "Anna"   (Typ: string)  Label: name
[Fach 0x2B] -> 25       (Typ: int)     Label: alter
```

Wenn du schreibst:
```csharp
int alter = 25;
```
passieren drei Dinge gleichzeitig:
1. **Deklaration:** Du reservierst ein Fach für eine ganze Zahl (`int`) und gibst ihm das Etikett `alter`.
2. **Zuweisungsoperator `=`:** Das Gleichheitszeichen bedeutet nicht mathematische Gleichheit, sondern: **„Nimm den Wert von rechts und packe ihn in das Fach links!“**
3. **Initialisierung:** Der Wert `25` wird zum ersten Mal in das Fach gelegt.

### Die `int`-Dopplungs-Falle
Ein sehr häufiger Anfängerfehler ist:
```csharp
int punkte = 10;
int punkte = 20; // FEHLER!
```
*Warum meckert C#?*
Mit dem Wort `int` sagst du: „Erstelle ein *neues* Fach mit diesem Namen“. Aber ein Fach mit dem Namen `punkte` existiert bereits!
Richtig ist:
```csharp
int punkte = 10;
punkte = 20; // Richtig: Greife auf das bestehende Fach zu und überschreibe den Inhalt
```

---

## 2. Die Unterschiede der Datentypen im Detail

### `char` vs. `string`
- **`char` (Character):** Genau ein einziges Zeichen. Wird immer mit **einfachen Anführungszeichen** `'A'` geschrieben.
- **`string` (Zeichenkette):** Eine Kette aus beliebig vielen Zeichen (auch 0 Zeichen `""` oder 1 Zeichen `"A"`). Wird immer mit **doppelten Anführungszeichen** `"..."` geschrieben.

```csharp
char buchstabe = 'A'; // Genau 1 Zeichen, einfache Quotes
string text = "A";    // Zeichenkette mit 1 Zeichen, doppelte Quotes
```

### `int` vs. `double`
- `int` schneidet Nachkommastellen gnadenlos ab – es kann keine Kommazahlen speichern.
- `double` speichert Gleitkommazahlen. Im Code schreibst du immer den **englischen Punkt** (`1.75`), nicht das deutsche Komma (`1,75`).

---

## 3. String-Interpolation verstehen: Was macht das `$`?

```csharp
string name = "Ben";
Console.WriteLine("Hallo {name}");  // Gibt aus: Hallo {name}
Console.WriteLine($"Hallo {name}"); // Gibt aus: Hallo Ben
```

Das Dollarzeichen `$` vor den Anführungszeichen ist wie ein Schalter:
- Ohne `$`: C# druckt die geschweiften Klammern `{name}` buchstabengetreu ab.
- Mit `$`: C# geht in den "Dolmetscher-Modus". Immer wenn `{ }` auftauchen, schaut C# nach, welche Variable gemeint ist, und setzt ihren aktuellen Wert ein.

---

## 4. Vertiefungsaufgaben mit Tipps

### Aufgabe 2.1: Der Drei-Gläser-Tausch (Swap)
Stell dir vor:
- Glas A enthält `Apfelsaft`.
- Glas B enthält `Orangensaft`.

Du möchtest den Inhalt tauschen, sodass in Glas A `Orangensaft` und in Glas B `Apfelsaft` ist.
Wenn du einfach schreibst:
```csharp
string glasA = "Apfelsaft";
string glasB = "Orangensaft";

glasA = glasB; // Jetzt ist in beiden Gläsern Orangensaft! Der Apfelsaft ist weg!
```
Wie kannst du den Tausch mit Hilfe einer **dritten Hilfsvariablen** sauber durchführen?

{% capture tipp %}
**Lösung / Tipp zu 2.1:**

Um zwei Variablen zu tauschen, brauchst du eine temporäre Zwischenspeicher-Variable (wie ein leeres drittes Glas):

```csharp
string glasA = "Apfelsaft";
string glasB = "Orangensaft";

// 1. Apfelsaft im Hilfsglas sichern
string zwischenspeicher = glasA;

// 2. Orangensaft nach Glas A füllen
glasA = glasB;

// 3. Den gesicherten Apfelsaft aus dem Hilfsglas nach Glas B füllen
glasB = zwischenspeicher;

Console.WriteLine($"Glas A: {glasA}, Glas B: {glasB}");
// Ausgabe: Glas A: Orangensaft, Glas B: Apfelsaft
```
{% endcapture %}
{% include tipp.html inhalt=tipp %}

---

### Aufgabe 2.2: Typ-Detektiv
Welcher Datentyp ist für folgende Informationen am besten geeignet? Begründe deine Wahl:
1. Das Geburtsjahr einer Person (z. B. `1998`)
2. Der Durchschnittspreis einer Kinokarte (z. B. `12.50`)
3. Ob das Licht im Raum an ist oder aus
4. Die Postleitzahl (z. B. `"01067"`)
5. Das Geschlecht als Kürzel (`'m'`, `'w'`, `'d'`)

{% capture tipp %}
**Lösung / Tipp zu V2.2:**

1. **`int`**: Ein Jahr ist immer eine ganze Zahl ohne Kommastellen.
2. **`double`**: Preise haben Cent-Beträge, also Nachkommastellen.
3. **`bool`**: Ein Lichtschalter hat nur zwei Zustände (`true` = an, `false` = aus).
4. **`string`** *(Achtung Falle!)*: Postleitzahlen wie `"01067"` in Dresden beginnen mit einer führenden Null. Ein `int` würde die Null weglassen (`1067`). Außerdem rechnet man nicht mit Postleitzahlen (man addiert keine Postleitzahlen). Daher ist `string` hier die richtige Wahl!
5. **`char`**: Es handelt sich um genau ein einzelnes Zeichen.
{% endcapture %}
{% include tipp.html inhalt=tipp %}

