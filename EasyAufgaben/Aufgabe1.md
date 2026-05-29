# Ticketautomat Chatbot:
## Schritt 1 (Projekt erstellen)
Erstelle ein neues Projekt in Visual Studio mit dem namen 'TicketautomatChatbot'.\
[Neues Projekt Tutorial](../Tutorials/NewProject.md)

## Schritt 2 (Variablen)
Füge oben diese Variablen hinzu:
```
string kundenName;
bool istKundeErwachsen;
int anzahlAnWaben;
string ticketart;
```

## Schritt 3 (Kundenname Eingeben)
Erstelle eine Konsoleneingabe und speicher das Ergebnis in `kundenName`.\
[Konsoleneingabe Tutorial](../Tutorials/ConsolenEingabe.md)

## Schritt 4 (Abfrage erwachsen/kind)
Füge eine Konsolenausgabe hinzu, welche den Benutzer auffordert einzugeben ob er eine Erwachsenen- oder eine Kinder-Karte
kaufen will.\
Z.B.:
```
Console.WriteLine("Bitte eingeben ob reisende Person erwachsen oder ein Kind ist.");
Console.WriteLine("Eingabemöglichkeiten: 'erwachsen', 'Kind'");
```
Füge nun eine Eingabe hinzu und setze `istKundeErwachsen` entsprechend der Eingabe.

:warning: **Achtung** du kannst nicht dierekt `istKundeErwachsen = Console.ReadLine();` machen!\
`istKundeErwachsen` ist **`bool`** und nicht **`string`**.

:exclamation: Wenn der Benutzer eine falsche Eingabe macht, sollte er darauf hingewiesen werden und erneut eine Eingabe machen können.


## Schritt 5 (Eingabe parsen)
Die nächste Eingabe ist für die Anzahl an Waben.\
Hierfür müssen wir die Eingabe parsen: von `string` zu `int`.\
Erstelle zuerst eine temporäre variable, in der die Eingabe als string gespeichert wird.
```
var eingabeAlsString = Console.ReadLine();
```
**Tipp:** Vergesse nicht dem Benutzer zu sagen was er eingibt.

Jetzt können wir die Eingabe parsen
([Tutorial zu Parsing](../Tutorials/Parsing.md))\
und in `anzahlAnWaben` speichern.

:exclamation: Wenn der Benutzer eine falsche Eingabe macht, sollte er darauf hingewiesen werden und erneut eine Eingabe machen können.


## Schritt 6 (Abfrage Ticketart)
Erstelle eine abfrage nach der Ticketart.
Dabei gib es **Tages-, Monats-** und **Jahresticket**.
Speicher das ergebnis in `ticketart`.

:exclamation: Wenn der Benutzer eine falsche Eingabe macht, sollte er darauf hingewiesen werden und erneut eine Eingabe machen können.

## Schritt 7 (Preisberechnung)
Berechne nun mit den Variablen (`kundenName`, `istKundeErwachsen`, `anzahlAnWaben` und `ticketart`)
den Ticketpreis mit folgendem Schema:
### Berechnung:
Grundpreis = 3,00 €

**Tagesticket:**\
Für eine warbe ist der preis der Grundpreis, für jede warbe die dazukommt werden 2,50€ dazu berechnet.

**Monatsticket:**\
Wird immer für 20 Tage berechnet mit 30% Rabatt

**Jahresticket:**\
Wird für 12 Monate berechnet mit 25% Rabatt

Ab **5 Waben** soll sich der Preis nicht mehr erhöhen.

Für Kinder gibt es einen zusätslichen rabatt von 30%.

Gebe anschließend den Berechneten Preis aus.

## Schritt 8 (Überprüfen)
Überprüfe Deine ergebnisse mit der Tabelle:\
**Preis Erwachsen:**

| Waben | Tagesticketpreis | Monatsticketpreis | Jahresticketpreis |
| :---: | ---------------: | ----------------: | ----------------: |
| 1     | 3,00 €           | 42,00 €           | 378,00 €          |
| 2     | 8,00 €           | 112,00 €          | 1008,00 €         |
| 3     | 10,50 €          | 147,00 €          | 1323,00 €         |
| 4     | 13,00 €          | 182,00 €          | 1638,00 €         |
| 5     | 15,50 €          | 217,00 €          | 1953,00 €         |
| 6     | 15,50 €          | 217,00 €          | 1953,00 €         |

**Preis Kind:**

| Waben | Tagesticketpreis | Monatsticketpreis | Jahresticketpreis |
| :---: | ---------------: | ----------------: | ----------------: |
| 1     | 2,10 €           | 29,40 €           | 264,60 €          |
| 2     | 5,60 €           | 78,40 €           | 705,60 €          |
| 3     | 7,35 €           | 102,90 €          | 926,10 €          |
| 4     | 9,10 €           | 127,40 €          | 1146,60 €         |
| 5     | 10,85 €          | 151,90 €          | 1367,10 €         |
| 6     | 10,85 €          | 151,90 €          | 1367,10 €         |

## [Lösung](code/EasyAufgabe1/Aufgabe1.cs)

## Extra-Schritt 9
Füge eine möglichkeit hinzu, dass der Benutzer mehrere Tickets kaufen kann.\
Er sollte nach jeder auswahl eine übersicht angezeigt bekommen, welche tickets er gekauft hat.\
Zeige den Einzelpreis jedes Tickets und den Gesamtpreis an.

## [Lösung mit extra-Schritt](code/EasyAufgabe1/Aufgabe1MitExtraschritt.cs)