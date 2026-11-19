---
title: "2 - Schere, Stein, Papier"
parent: Zusatzaufgaben
nav_order: 2
---

# Zusatzaufgabe 2 - Schere, Stein, Papier

| | |
|---|---|
| **Schwierigkeit** | Leicht |
| **Dauer** | ca. 1–1,5 Stunden |
| **Benötigte Kapitel** | 1–8 und 10 (Zufallszahlen kennst du aus Kapitel 11) |

## Ziel

Du programmierst das bekannte Spiel gegen den Computer. Am Ende spielt man „Best of 5“ (wer zuerst 3 Runden gewinnt) und bekommt eine kleine Statistik angezeigt.

Dabei übst du:
- Zufallszahlen mit `Random`
- Verzweigungen mit mehreren Bedingungen
- Schleifen, die erst bei einem bestimmten Punktestand enden
- Methoden mit Rückgabewert
- Arrays zum Zählen

---

## Was du dafür brauchst

**Zufallszahlen**

```csharp
Random zufall = new Random();
int wahl = zufall.Next(1, 4);   // 1, 2 oder 3 – die obere Grenze ist NICHT dabei
```

**Zahlen in Namen umwandeln mit einem Array**

```csharp
string[] namen = { "", "Schere", "Stein", "Papier" };
Console.WriteLine(namen[2]);   // Stein
```

Index 0 bleibt leer, damit die Zahl 1 direkt zu „Schere“ passt.

**Die Regeln**

| Wahl | schlägt |
|---|---|
| Schere | Papier |
| Stein | Schere |
| Papier | Stein |

---

## Aufgaben

### Stufe 1: Eine Runde

Das Programm fragt nach der Wahl des Spielers (1 = Schere, 2 = Stein, 3 = Papier), lässt den Computer zufällig wählen und gibt den Gewinner aus.

```text
=== Schere, Stein, Papier ===
1 = Schere, 2 = Stein, 3 = Papier
Deine Wahl: 2

Du: Stein
Computer: Schere
Du gewinnst!
```

{% capture tipp %}
Prüfe zuerst auf **Unentschieden** (`spieler == computer`). Danach reichen drei Fälle, in denen der Spieler gewinnt. In allen anderen Fällen gewinnt der Computer.

```csharp
if (spieler == computer)
{
    Console.WriteLine("Unentschieden!");
}
else if ((spieler == 1 && computer == 3) ||
         (spieler == 2 && computer == 1) ||
         (spieler == 3 && computer == 2))
{
    Console.WriteLine("Du gewinnst!");
}
else
{
    Console.WriteLine("Der Computer gewinnt!");
}
```
{% endcapture %}
{% include tipp.html inhalt=tipp %}

### Stufe 2: Absturzsicher und mit Methoden

Baue zwei Methoden:

1. `static int LiesWahl()` fragt so lange nach, bis eine Zahl von 1 bis 3 eingegeben wurde. Buchstaben, leere Eingaben und z. B. `7` dürfen das Programm **nicht** abstürzen lassen.
2. `static int ErmittleGewinner(int spieler, int computer)` gibt zurück:
   - `1`, wenn der Spieler gewinnt
   - `-1`, wenn der Computer gewinnt
   - `0` bei Unentschieden

Die Ausgabe („Du gewinnst!“ usw.) passiert **nicht** in `ErmittleGewinner`, sondern im Hauptprogramm.

```text
Deine Wahl: abc
Bitte gib 1, 2 oder 3 ein.
Deine Wahl: 5
Bitte gib 1, 2 oder 3 ein.
Deine Wahl: 3
```

{% capture tipp %}
Für `LiesWahl` kannst du deine `LiesZahl`-Methode aus Kapitel 10 als Vorlage nehmen. Ergänze nur die Prüfung, ob die Zahl zwischen 1 und 3 liegt:

```csharp
static int LiesWahl()
{
    while (true)
    {
        Console.Write("Deine Wahl: ");
        if (int.TryParse(Console.ReadLine(), out int wahl) && wahl >= 1 && wahl <= 3)
        {
            return wahl;
        }
        Console.WriteLine("Bitte gib 1, 2 oder 3 ein.");
    }
}
```
{% endcapture %}
{% include tipp.html titel="Tipp zu LiesWahl" inhalt=tipp %}

### Stufe 3: Best of 5

Es wird so lange gespielt, bis **einer 3 Runden gewonnen** hat. Unentschieden zählen nicht. Nach jeder Runde wird der Punktestand angezeigt, am Ende der Gesamtsieger.

```text
--- Runde 4 ---
Deine Wahl: 1
Du: Schere | Computer: Papier
Du gewinnst die Runde!
Stand: Du 3 : 1 Computer

Du hast das Spiel gewonnen!
```

{% capture tipp %}
Du brauchst zwei Zähler (`siegeSpieler`, `siegeComputer`) und eine `while`-Schleife:

```csharp
while (siegeSpieler < 3 && siegeComputer < 3)
{
    // eine Runde spielen
}
```

Überlege: Warum steht hier `&&` und nicht `||`?
{% endcapture %}
{% include tipp.html inhalt=tipp %}

### Stufe 4: Nochmal spielen und Statistik

Nach jedem Spiel fragt das Programm: `Nochmal spielen? (j/n)`. Wenn der Spieler aufhört, erscheint eine Statistik:

```text
=== Statistik ===
Gespielte Spiele: 4
Gewonnen: 3 (75 %)
Verloren: 1
Deine Lieblingswahl: Stein (9-mal)
```

{% capture tipp %}
Für die Lieblingswahl kannst du ein Array als Zähler verwenden. Jeder Platz zählt, wie oft eine Wahl gewählt wurde:

```csharp
int[] anzahlWahl = new int[4];   // Platz 1 = Schere, 2 = Stein, 3 = Papier
anzahlWahl[spieler]++;
```

Am Ende suchst du mit einer Schleife den Platz mit dem größten Wert.

Für die Prozentzahl: `gewonnen * 100 / spiele` funktioniert mit `int`. Achte darauf, nicht durch 0 zu teilen.
{% endcapture %}
{% include tipp.html inhalt=tipp %}

---

## Typische Fehler

| Fehler | Was passiert | Lösung |
|---|---|---|
| `zufall.Next(1, 3)` | Der Computer wählt nie Papier | Die obere Grenze ist exklusiv: `Next(1, 4)` |
| `new Random()` **in** der Schleife | Bei schnellen Runden kommt oft dieselbe Zahl | `Random` einmal **vor** der Schleife anlegen |
| `while (siegeSpieler < 3 \|\| siegeComputer < 3)` | Das Spiel hört nicht auf, wenn einer 3 Punkte hat | `&&` verwenden |
| Zähler werden beim „Nochmal spielen“ nicht zurückgesetzt | Das zweite Spiel ist sofort vorbei | `siegeSpieler = 0;` und `siegeComputer = 0;` am Anfang jedes Spiels |
| Antwort `J` statt `j` wird nicht erkannt | Das Programm beendet sich | `.ToLower()` auf die Eingabe anwenden |

---

## Extras

1. **Echse und Spock:** Erweitere das Spiel auf 5 Möglichkeiten (Schere, Stein, Papier, Echse, Spock). Die Regeln findest du im Internet unter „Rock Paper Scissors Lizard Spock“. Wie viele `if`-Bedingungen brauchst du jetzt? Fällt dir eine kürzere Lösung ein?
2. **Zwei Spieler:** Zwei Personen spielen gegeneinander. Damit Spieler 2 die Wahl von Spieler 1 nicht sieht, nutze `Console.Clear();` nach der ersten Eingabe.
3. **Lernender Computer:** Der Computer merkt sich, was du am häufigsten wählst, und wählt in 50 % der Fälle genau das, was dagegen gewinnt.
4. **Für Profis:** Die ganze Gewinner-Prüfung geht auch mit einer einzigen Rechnung: `(spieler - computer + 3) % 3`. Finde heraus, welches Ergebnis für Sieg, Niederlage und Unentschieden steht.

---

## Checkliste

- [ ] Der Computer wählt zufällig alle drei Möglichkeiten
- [ ] Falsche Eingaben bringen das Programm nicht zum Absturz
- [ ] `ErmittleGewinner` gibt nur einen Wert zurück und schreibt nichts auf die Konsole
- [ ] Das Spiel endet, sobald einer 3 Runden gewonnen hat
- [ ] Beim zweiten Spiel beginnt der Punktestand wieder bei 0
- [ ] Die Statistik zeigt Spiele, Siege, Quote und Lieblingswahl

---

[← Galgenraten](Galgenraten.md) · [Übersicht](index.md) · [Taschenrechner →](Taschenrechner.md)
