---
title: 03 - Vertiefung Rechnen und Vergleichen
parent: 03 - Rechnen und Vergleichen
nav_order: 1
---
# Kapitel 3 – Rechnen und Vergleichen (Vertiefung)

[← Zurück zu Kapitel 3](../Kapitel/03-Rechnen-und-Vergleichen.md) | [Übersicht](../README.md) | [Weiter: Eingaben Vertiefung →](04-Eingaben-Vertiefung.md)

Rechnen und Vergleichen wirken auf den ersten Blick wie einfache Schulmathematik. In Programmiersprachen gibt es jedoch ein paar Besonderheiten, die regelmäßig zu Verwirrung führen.

---

## 1. Die Ganzzahldivision: Warum ist `7 / 2 = 3`?

Wenn du zwei ganze Zahlen (`int`) teilst, führt C# eine **Ganzzahldivision** durch:
```csharp
int ergebnis = 7 / 2;
Console.WriteLine(ergebnis); // Ausgabe: 3
```

*Warum nicht 3.5?*
Weil `7` ein `int` ist und `2` ein `int` ist. C# rechnet: `int / int = int`. Der Rest bzw. die Nachkommastelle wird einfach abgeschnitten (nicht gerundet!).

### Wie erreichst du eine echte Kommazahl?
Mindestens **eine** der beiden Zahlen muss ein `double` sein:
```csharp
double ergebnis1 = 7.0 / 2;   // 3.5
double ergebnis2 = 7 / 2.0;   // 3.5
double ergebnis3 = (double)7 / 2; // 3.5 (sogenannter "Cast")
```

---

## 2. Der Modulo-Operator `%` (Der Divisionsrest)

Modulo berechnet den **Rest** einer Ganzzahldivision.

**Anschauliches Beispiel:**
Du hast 14 Äpfel und packst sie in 4er-Tüten:
- 14 / 4 = 3 volle Tüten (das sind 12 Äpfel).
- Es bleiben **2 Äpfel übrig**.
- 14 % 4 = 2.

### Wichtigste Anwendungsfälle in der Praxis:
1. **Gerade oder ungerade Zahl prüfen:**
   ```csharp
   bool istGerade = (zahl % 2 == 0); // Rest 0 bei Teilung durch 2 -> gerade!
   ```
2. **Uhrzeit / Minuten umrechnen:**
   ```csharp
   int gesamtMinuten = 130;
   int stunden = gesamtMinuten / 60; // 2
   int restMinuten = gesamtMinuten % 60; // 10 (also 2 Stunden und 10 Minuten)
   ```

---

## 3. Zuweisung `=` vs. Vergleich `==`

Das ist eine der häufigsten Fehlerquellen überhaupt:

| Operator | Name | Bedeutung | Beispiel |
|---|---|---|---|
| `=` | Zuweisungsoperator | **Befehl:** "Speichere den rechten Wert in der linken Variable!" | `x = 5;` |
| `==` | Gleichheitsoperator | **Frage:** "Ist der linke Wert gleich dem rechten Wert?" | `x == 5` (ergibt `true` oder `false`) |

Merkregel:
- Ein `=` vergibt einen Wert.
- Zwei `==` fragen den Wert ab.

---

## 4. Logische Operatoren (`&&`, `||`, `!`)

- `&&` (UND): Beide Bedingungen müssen wahr sein.
- `||` (ODER): Mindestens eine Bedingung muss wahr sein.
- `!` (NICHT): Kehrt den Wahrheitswert um (`!true` wird zu `false`).

### Kurzschluss-Auswertung (Short-Circuit Evaluation)
C# ist clever:
- Bei `false && ...` schaut C# gar nicht mehr auf die zweite Bedingung, weil ein `UND` sowieso schon verloren ist.
- Bei `true || ...` schaut C# gar nicht mehr auf die zweite Bedingung, weil ein `ODER` sowieso schon gewonnen hat.

---

## 5. Vertiefungsaufgaben mit Tipps

### Aufgabe 3.1: Freizeitpark-Einlassprüfer
Eine Achterbahn darf nur betreten werden, wenn:
- Die Person mindestens **140 cm** groß ist **UND**
- Die Person mindestens **12 Jahre** alt ist **ODER** in Begleitung eines Erwachsenen ist.

Lege drei Variablen an:
```csharp
int groesseInCm = 135;
int alter = 10;
bool hatBegleitung = true;
```
Formuliere einen einzigen logischen Ausdruck, der in einem `bool darfMitfahren` speichert, ob die Person mitfahren darf.

{% capture tipp %}
**Lösung / Tipp zu 3.1:**

Achte auf die Klammern, damit `UND` und `ODER` in der richtigen Reihenfolge ausgewertet werden:

```csharp
int groesseInCm = 135;
int alter = 10;
bool hatBegleitung = true;

// Größe muss stimmen UND (Alter ODER Begleitung)
bool darfMitfahren = (groesseInCm >= 140) && (alter >= 12 || hatBegleitung);

Console.WriteLine($"Darf mitfahren: {darfMitfahren}");
// Hier: False, da groesseInCm (135) unter 140 liegt!
```
*Hinweis:* Ohne die Klammern um `(alter >= 12 || hatBegleitung)` würde C# wegen Operator-Vorrang zuerst das `&&` auswerten, was zu falschen Ergebnissen führen könnte.
{% endcapture %}
{% include tipp.html inhalt=tipp %}

