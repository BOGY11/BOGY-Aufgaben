---
title: "7 - Bankautomat"
parent: Zusatzaufgaben
nav_order: 7
---

# Zusatzaufgabe 7 - Bankautomat

| | |
|---|---|
| **Schwierigkeit** | Schwer |
| **Dauer** | ca. 2,5–3 Stunden |
| **Benötigte Kapitel** | 1–10, vor allem 9 (Klassen) und 10 (Fehler abfangen) |

## Ziel

Du baust einen Geldautomaten für mehrere Kunden. Man meldet sich mit Kontonummer und PIN an, kann Geld einzahlen, abheben und überweisen und bekommt einen Kontoauszug. Nach drei falschen PINs wird das Konto gesperrt, und das Geld kommt in möglichst wenigen Scheinen heraus.

Dabei übst du:
- Klassen mit `private` Feldern und `private set`
- Methoden, die Regeln durchsetzen und `bool` zurückgeben
- `List<Konto>` durchsuchen
- `decimal` für Geldbeträge
- `/` und `%` für die Scheinausgabe
- Datum und Uhrzeit mit `DateTime.Now`

---

## Was du dafür brauchst

**`decimal` für Geld**

```csharp
decimal kontostand = 150.75m;   // das m am Ende macht die Zahl zu decimal
Console.WriteLine($"{kontostand:F2} €");   // 150,75 €
```

`double` rechnet bei Kommazahlen ungenau: `0.1 + 0.2` ergibt `0.30000000000000004`. Bei Geld darf das nicht passieren. `decimal` rechnet hier exakt.

**Etwas schützen mit `private`**

```csharp
class Konto
{
    private string pin;                          // von außen gar nicht sichtbar
    public decimal Kontostand { get; private set; }   // lesen ja, ändern nur in der Klasse
}
```

So kann niemand aus `Program.cs` einfach `konto.Kontostand = 1000000;` schreiben.

**Datum und Uhrzeit**

```csharp
string zeit = DateTime.Now.ToString("dd.MM.yyyy HH:mm");   // 27.10.2026 09:42
```

---

## Aufgaben

### Stufe 1: Ein Konto mit Menü

Starte mit **einem** Konto (Kontostand als `decimal`-Variable, Startwert 500 €) und diesem Menü in einer Schleife:

```text
=== INIT-Bank Geldautomat ===
1) Kontostand anzeigen
2) Einzahlen
3) Abheben
4) Beenden
Auswahl: 3
Betrag: 700
Nicht genug Guthaben. Verfügbar: 500,00 €
```

Regeln:
- Einzahlen und Abheben nur mit Beträgen **größer als 0**
- Der Kontostand darf **nie negativ** werden
- Buchstaben bringen das Programm nicht zum Absturz

{% capture tipp %}
Schreib dir eine Methode `static decimal LiesBetrag()`, die wie deine `LiesZahl` aus Kapitel 10 funktioniert, nur mit `decimal.TryParse`. Prüfe darin auch gleich, ob der Betrag größer als 0 ist.
{% endcapture %}
{% include tipp.html inhalt=tipp %}

### Stufe 2: Die Klasse `Konto`

Verschiebe alles, was zu einem Konto gehört, in eine Klasse:

| Mitglied | Bedeutung |
|---|---|
| `Kontonummer` (`string`, nur lesen) | z. B. `"DE1001"` |
| `Inhaber` (`string`, nur lesen) | z. B. `"Anna Schmidt"` |
| `pin` (`private string`) | die PIN, von außen nicht sichtbar |
| `Kontostand` (`decimal`, `private set`) | |
| Konstruktor `Konto(string kontonummer, string inhaber, string pin, decimal startguthaben)` | |
| `bool PinPruefen(string eingabe)` | `true`, wenn die PIN stimmt |
| `bool Einzahlen(decimal betrag)` | `false` bei Betrag ≤ 0 |
| `bool Abheben(decimal betrag)` | `false` bei zu wenig Guthaben oder ungültigem Betrag |

Zusätzliche Regeln beim **Abheben**, denn der Automat hat nur Scheine:
- nur Vielfache von **10 €**
- höchstens **1.000 € pro Abhebung**

```text
Betrag: 35
Der Automat gibt nur 10-€-Scheine und größer aus. Bitte ein Vielfaches von 10 eingeben.
Betrag: 1500
Höchstens 1.000 € pro Abhebung.
```

{% capture tipp %}
Die Methoden geben nur `true` oder `false` zurück. Die **Fehlermeldung** gibt das Hauptprogramm aus. So bleibt die Klasse unabhängig von der Konsole.

Ob ein Betrag ein Vielfaches von 10 ist, prüfst du mit dem Rest: `betrag % 10 == 0`. Das funktioniert auch mit `decimal`.
{% endcapture %}
{% include tipp.html titel="Tipp zur Klasse Konto" inhalt=tipp %}

### Stufe 3: Anmeldung mit mehreren Konten

Lege beim Start mindestens drei Konten in einer `List<Konto>` an. Vor dem Menü muss man sich anmelden:

```text
Kontonummer: DE1002
PIN: 0000
Falsche PIN. Noch 2 Versuche.
PIN: 1111
Falsche PIN. Noch 1 Versuch.
PIN: 9999
Konto gesperrt. Bitte wende dich an deine Filiale.
```

- Gibt es die Kontonummer nicht, erscheint „Konto nicht gefunden“.
- Nach **3 falschen PINs** wird das Konto gesperrt. Ein gesperrtes Konto kann sich auch später nicht mehr anmelden.
- Im Menü gibt es zusätzlich `Abmelden`, danach kann sich der nächste Kunde anmelden.
- Nach der Anmeldung steht im Menü `Hallo Anna Schmidt!`.

{% capture tipp %}
**Konto suchen:** Schreib eine Methode, die durch die Liste läuft und das passende Konto zurückgibt, oder `null`, wenn es keins gibt:

```csharp
static Konto SucheKonto(List<Konto> konten, string nummer)
{
    foreach (Konto k in konten)
    {
        if (k.Kontonummer == nummer)
        {
            return k;
        }
    }
    return null;
}
```

**Sperren:** Gib der Klasse eine Eigenschaft `public bool Gesperrt { get; private set; }` und ein privates Feld `fehlversuche`. Lass `PinPruefen` selbst mitzählen und das Konto beim dritten Fehler sperren. Prüfe `Gesperrt` **bevor** du nach der PIN fragst.
{% endcapture %}
{% include tipp.html inhalt=tipp %}

### Stufe 4: Überweisung, Kontoauszug und Scheine

**1. Überweisen**
Man gibt die Zielkontonummer und den Betrag ein. Das Geld wird vom eigenen Konto abgebucht und dem anderen gutgeschrieben.
- Das Zielkonto muss existieren.
- Überweisungen an sich selbst sind nicht erlaubt.
- Für Überweisungen gelten die 10-€-Regel und das Limit **nicht**, nur das Guthaben muss reichen.

**2. Kontoauszug**
Jede Buchung wird im Konto in einer `List<string>` gespeichert, mit Datum und neuem Kontostand:

```text
=== Kontoauszug DE1001 – Anna Schmidt ===
27.10.2026 09:42  Einzahlung            +200,00 €   Stand: 700,00 €
27.10.2026 09:43  Abhebung              -150,00 €   Stand: 550,00 €
27.10.2026 09:45  Überweisung an DE1002  -50,00 €   Stand: 500,00 €
```

Beim Empfänger erscheint entsprechend `Überweisung von DE1001`.

**3. Scheinausgabe**
Nach dem Abheben zeigt der Automat, welche Scheine herauskommen. Er verwendet 200-, 100-, 50-, 20- und 10-€-Scheine und davon möglichst wenige:

```text
Betrag: 380
Ausgabe: 1 x 200 €, 1 x 100 €, 1 x 50 €, 1 x 20 €, 1 x 10 €
```

{% capture tipp %}
**Scheine:** Geh die Scheine vom größten zum kleinsten durch. Mit `/` berechnest du, wie oft ein Schein passt, mit `%` den Rest, der übrig bleibt. Das kennst du vom Wechselgeld im Snackautomaten:

```csharp
int[] scheine = { 200, 100, 50, 20, 10 };
int rest = (int)betrag;

foreach (int schein in scheine)
{
    int anzahl = rest / schein;
    rest = rest % schein;
    // nur ausgeben, wenn anzahl > 0
}
```

**Überweisung:** Am saubersten ist eine Methode in `Konto`:
`public bool UeberweisenAn(Konto ziel, decimal betrag)`. Sie prüft das Guthaben, bucht ab, ruft eine Gutschrift beim Ziel auf und schreibt in **beide** Kontoauszüge.
{% endcapture %}
{% include tipp.html titel="Tipp zu Stufe 4" inhalt=tipp %}

---

## Typische Fehler

| Fehler | Was passiert | Lösung |
|---|---|---|
| `public decimal Kontostand { get; set; }` | Jeder Programmteil kann den Kontostand beliebig ändern | `private set` und Änderungen nur über Methoden |
| `double` für Geld | Es entstehen Beträge wie `99,99999999 €` | `decimal` und `m` an Zahlen: `500m` |
| Negative Beträge erlaubt | `Abheben(-100)` **erhöht** den Kontostand | In jeder Methode `betrag <= 0` ablehnen |
| PIN als `int` | Die PIN `0123` wird zu `123` | PIN als `string` speichern |
| `SucheKonto` gibt `null` zurück, und man greift trotzdem darauf zu | `NullReferenceException` | Vorher `if (konto == null)` prüfen |
| Bei der Überweisung wird nur abgebucht | Das Geld verschwindet | Immer abbuchen **und** gutschreiben |
| Fehlversuche werden im Hauptprogramm gezählt | Nach dem Abmelden fängt der Zähler wieder bei 0 an | Die Fehlversuche im `Konto` speichern |

---

## Extras

1. **Dispo:** Jedes Konto bekommt einen Dispokredit (z. B. 300 €). Der Kontostand darf bis `-300 €` sinken.
2. **PIN ändern:** Neuer Menüpunkt. Die alte PIN muss eingegeben werden, und die neue PIN muss genau 4 Ziffern haben.
3. **Tageslimit:** Pro Tag dürfen insgesamt höchstens 1.500 € abgehoben werden.
4. **Admin-Modus:** Mit einer geheimen Kontonummer kommt man in einen Admin-Bereich. Dort kann man Konten anlegen, gesperrte Konten entsperren und alle Kontostände sehen.
5. **Scheinvorrat:** Der Automat hat nur eine begrenzte Anzahl Scheine. Ist ein Schein leer, muss er mit kleineren Scheinen auszahlen oder den Betrag ablehnen.

---

## Checkliste

- [ ] Der Kontostand kann außerhalb der Klasse nicht direkt geändert werden
- [ ] Negative Beträge, Buchstaben und zu hohe Beträge werden abgelehnt
- [ ] Abheben geht nur in Vielfachen von 10 € und bis 1.000 €
- [ ] Nach 3 falschen PINs ist das Konto dauerhaft gesperrt
- [ ] Nach dem Abmelden kann sich ein anderer Kunde anmelden
- [ ] Bei einer Überweisung stimmt die Summe beider Konten vorher und nachher
- [ ] Der Kontoauszug zeigt alle Buchungen mit Datum
- [ ] Die Scheinausgabe verwendet möglichst wenige Scheine

---

[← Tic-Tac-Toe](TicTacToe.md) · [Übersicht](index.md)
