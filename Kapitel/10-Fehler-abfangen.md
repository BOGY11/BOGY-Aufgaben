---
title: 10 - Fehler abfangen
parent: Kapitel
has_children: true
has_toc: false
nav_order: 10
---
# Kapitel 10 – Fehler abfangen

[← Klassen und Objekte](09-Klassen.md) | [Übersicht](../README.md) | [Weiter: Abschlussprojekt →](11-Abschlussprojekt.md)

## Ziel

Nach diesem Kapitel kannst du:

- erklären, was eine **Exception** ist
- Abstürze mit `try` / `catch` verhindern
- Eingaben mit `int.TryParse` sicher prüfen
- deine alten Programme absturzsicher machen

---

## Erklärung

### Was ist eine Exception?

Wenn während des Programms etwas schiefgeht, „wirft“ C# eine **Exception** (Ausnahme). Wird sie nicht abgefangen, **stürzt das Programm ab**.
Einige davon hast du schon kennengelernt:

| Exception | Wann sie auftritt |
|---|---|
| `FormatException` | `int.Parse("abc")` – der Text ist keine Zahl |
| `IndexOutOfRangeException` | Zugriff auf einen Array-Platz, den es nicht gibt |
| `DivideByZeroException` | Eine ganze Zahl wird durch 0 geteilt |

### `try` / `catch` – „Versuch es, und wenn es schiefgeht …“

```csharp
Console.Write("Gib eine Zahl ein: ");
try
{
    int nummer = int.Parse(Console.ReadLine());
    Console.WriteLine($"Du hast die Zahl {nummer} eingegeben!");
}
catch (FormatException)
{
    Console.WriteLine("Das war leider keine Zahl.");
}
```

1. Der Code im `try`-Block wird ausgeführt.
2. Tritt dabei eine `FormatException` auf, springt das Programm **sofort** in den `catch`-Block – statt abzustürzen.
3. Danach läuft das Programm ganz normal weiter.

Mit `catch (Exception)` fängst du **jede** Art von Fehler ab. Besser ist es aber, genau den Fehler anzugeben, den du erwartest.

### `int.TryParse` – die elegante Lösung für Eingaben

Für Zahleneingaben gibt es eine einfachere und sicherere Variante:

```csharp
Console.Write("Gib eine Zahl ein: ");
if (int.TryParse(Console.ReadLine(), out int zahl))
{
    Console.WriteLine($"Erlaubt: {zahl}");
}
else
{
    Console.WriteLine("Diese Eingabe ist nicht erlaubt.");
}
```

`int.TryParse` macht zwei Dinge gleichzeitig:

1. Es **versucht**, den Text in eine Zahl umzuwandeln, und gibt `true` (hat geklappt) oder `false` (hat nicht geklappt) zurück. **Es stürzt nie ab.**
2. Hat es geklappt, steht die Zahl danach in der Variable hinter `out` – hier `zahl`.

Für Kommazahlen gibt es genauso `double.TryParse`.

### So lange fragen, bis die Eingabe stimmt

```csharp
Console.Write("Gib eine Zahl ein: ");
int zahl;
while (!int.TryParse(Console.ReadLine(), out zahl))
{
    Console.Write("Das war keine Zahl. Bitte nochmal: ");
}
Console.WriteLine($"Danke! Du hast {zahl} eingegeben.");
```

---

{% capture notiz %}
| Fehler | Was passiert |
|---|---|
| `catch` für die falsche Exception | Der Fehler wird nicht abgefangen – das Programm stürzt trotzdem ab |
| Leerer `catch`-Block | Der Fehler wird „verschluckt“, niemand merkt etwas. Gib immer eine Meldung aus! |
| Variable im `try`-Block angelegt und danach benutzt | Fehler – Variablen aus `{ }` gibt es nur innerhalb der Klammern |
{% endcapture %}
{%include notiz.html typ="warning" titel="Typische Fehler" offen=false inhalt=notiz %}

---

## Aufgaben

### Aufgabe 10.1 – Absturz provozieren

Nimm dir drei deiner bisherigen Programme vor und versuche, sie absichtlich **zum Absturz zu bringen**.
Notiere jeweils: Welche Eingabe? Welche Exception?

### Aufgabe 10.2 – `LiesZahl` absturzsicher machen

Baue deine Methode `LiesZahl` aus Aufgabe 8.3 so um, dass sie **so lange nachfragt, bis eine gültige Zahl eingegeben wurde**.

```
Erste Zahl: abc
Das war keine gültige Zahl. Bitte nochmal: 12
```

Schreibe danach eine zweite Methode `double LiesKommazahl(string frage)`, die genauso funktioniert.

### Aufgabe 10.3 – Alte Programme reparieren

Mach diese Programme mit deinen neuen Methoden absturzsicher:

1. den **Temperatur-Umrechner** (4.2)
2. die **Zahlenstatistik** (7.3)

{% capture tipp %}
Für Aufgabe 3 kannst du die Bedingung der `while`-Schleife erweitern:
„Wiederholen, solange die Eingabe **keine Zahl** ist **oder** die Zahl **kleiner als 1** ist **oder** **größer als 6**.“
{% endcapture %}
{% include tipp.html inhalt=tipp %}


### Bonus-Aufgabe 10.4 – Teilen durch null

1. Teile im Mini-Rechner (4.3) durch `0`. Was passiert?
2. Probiere dasselbe mit `double`-Werten aus. Was wird jetzt ausgegeben?
3. Verhindere den Absturz – einmal mit `try`/`catch` und einmal mit einem `if` **vor** der Rechnung.
   Welche Lösung findest du besser? Warum?

---

## Checkliste

- [ ] Ich weiß, was eine Exception ist, und kenne mindestens drei Arten.
- [ ] Ich kann einen `try`/`catch`-Block schreiben.
- [ ] Ich kann `int.TryParse` benutzen und erklären, was `out` bedeutet.
- [ ] Meine `LiesZahl`-Methode stürzt bei falschen Eingaben nicht mehr ab.

---

Hast du noch weitere Fragen, bist bei einzelnen Themen noch unsicher oder möchtest einfach mehr Aufgaben zu diesem Kapitel bearbeiten? Schau dir gerne das Vertiefungskapitel an: \
[Klicke hier, um zur Vertiefung zu gelangen](../Vertiefung/10-Fehler-abfangen-Vertiefung.md)

---

[← Klassen und Objekte](09-Klassen.md) | [Übersicht](../README.md) | [Weiter: Abschlussprojekt →](11-Abschlussprojekt.md)
