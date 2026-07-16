# Blackjack
## Schritt 1:
Erstelle ein neues Project.\
**WICHTIG**: Erstelle ein WinForms Project! Wähle WinForms aus anstatt Konsolenanwendung.\
[Neues Project Tutorial](../Tutorials/NewProject.md)

## Schritt 2:
Öffne die Toolbox:

![image](Bilder/Toolbox.png)

Öffne jetzt an der rechten seite (die Toolbox) den reiter All Windows Forms und füge mit drag and drop ein button und ein Textfeld hinzu.

Der button soll dazu da sein um Karten zu ziehen.\
Mache auf den butten ein rechts-cklick und drücke auf Properties.\
In dem Fenster, welches sich unten rchts geöffnet hat änderst du unter dem Reiter 'Appearance' bei 'Text' 'button1' -> 'Karte ziehen'.\
Ändere die größe des buttons so, dass die wörter auch zu sehen sind.\
Ändere ebenfalls im Fenster unten rechts unter dem Reiter 'Design' den '(Name)' 'button1' zu 'karteZiehen'.

Mache rechts-klick auf das Textfeld und drücke auf Properties. Ändere hier, wie beim button den '(Name)' zu 'aktuelleKarten'.

## Schritt 3:
mache ein doppel-klick auf den button.\
Es sollte sich so ein Fenster öffnen:\
![image](Bilder/ButtonDoubleClick.png)

Füge über dem Konstruktor eine Private Liste `_kartenStapel` hinzu, welcher als Kartenstapel diehnt:
```
private List<(string name, int wert)> _kartenStapel;
```

In `_kartenStapel` ist der Wert (`int`) und Name (`string`) jeder ´Karte im Kartenstapel gespeichert.

Füge nun im Kostructor `Form1()` code hinzu, welcher alle Karten generiert.

## Schritt 4:
Die Methode '`karteZiehen_Click()`' wird ausgeführt, wenn der Button gedrükt wird.\
Füge in dieser Metode code hinzu, welcher eine [zufällige](../Tutorials/Random.md) Karrte aus dem Kartenstapel auswählt und diese vom Stapel entfernt.

Anschließend soll die ausgewählte Karte beim textFeld aktuelleKarten angezeigt werden.
Benutze hierfür `aktuelleKarten.Text`.

## Schritt 5:
Füge unter dem `_kartenStapel` ein weiteres privates feld `private int _score` hinzu, welcher den wert aller bereits gezogenen Karten zusammengezählt speichert.

Erstelle ein weiteres Textfeld und zeige dort den Score an.

Wenn der score größer oder gleich 21 ist kann man keine weitere Karte ziehen.

## Schritt 6:
Füge im Form-Designer ein neuen Button 'Keine Karte' und zwei neue TextFelder hinzu, welcher die Karten des Bots repräsentieren;

Wenn 'Keine Karte' gedrückt wurde sollen zufällige karten gezogen und beim neuen TextFeld angezeigt werden, bis der wert der gezogenen Karten min. 16 ist.

Mache es so, dass sobald der Button 'Keine Karte' gedrückt wurde die Buttons nicht mehr funktionieren.

Wenn der Spieler 21 oder mehr punkte hat soll der knopf 'Keine Karte Automatich gedrückt werden.

## Schritt 7:
Füge ein neues Textfeld mit den name 'coins' hinzu. Hier werden die Coins des spielers gespeichert.\
Hier kannst du ein startwert von 100 eingeben.

Füge ein weiteres TextFeld 'einsatz' neben dran hinzu in dem die in einer runde gesetzten coins stehen.
Hier darf der spieler etwas reinschreiben.

Füge im Construktor hinzu:
```
einsatz.KeyDown += Einsatz_KeyDown;
```
Und erstelle die `methode Einsatz_KeyDown`\
Diese Methode wird ausgeführt falls der spieler eine taste drückt.\
füge eine if-abfrage hinzu welche erkennt ob die enter-taste gedrückt wurde:
```
if (e.KeyCode == Keys.Enter)
{

}
```
Der Spieler sollte nur ganze zahlen die kleiner als oder gleich sein coin-stand ist eingeben.\
Sobald der Spiler enter gedrückt hat kann er das nicht direkt nochmal und er kann den Text nicht ändern (Tipp: .ReadOnly).\
Der eigegebene wert wird von den coins abgezogen.

Der Spiler kann die Buttons erst benutzen wenn er etwas eingesetzt hat.

## Schritt 8
Nach rundenende wird der einsatz zurückgesetzt aber der Spieler kann noch nicht ein neuen einsatz machen.

Falls der Spieler gewonnen hat bekommt er das doppelte seines Einsatzes wieder zurück.\
Falls der Spieler mit 2 Karten 21 hat (Also ein Black Jack) bekommt er das 2,5-fache.


## Schritt 9
Der Bot hat an anfang der Runde Bereits eine Karte.\
Mache es so, dass am anfang der Bot eine Karte zieht, sobald der Spieler ein einsatz gemacht hat.

## Schrit 10
Füge ein Button 'NeueRunde' hinzu.\
Er kann nur am ende nach der Gewinnberechnung gedrückt werden.\
Wenn er gedrückt wird werden der wert und die gezogenen karten des Spielers und Computers zurückgesetzt.\
Jetzt kann der spieler wieder ein einsatz machen und eine neue runde spielen.

Füge auch ein Textfeld hinzu, welches anzeigt, wie viele karten noch im kartenstapel sind.

## Schritt 11
Füge ein Button 'Zurücksetzen' hinzu welcer alles auf den anfangsstand zurücksetzt.

## Schritt 12
Beim originalen Black-Jack kann man entscheiden, ob der wert von einem Ass 11 oder 1 ist.\
Die runde sollte also erstmal nicht direkt beendet werden, wenn der spieler mehr als 21 punkte hat.

Fübe jetzt 4 neue buttons hinzu.\
Nenne sie Ass1, Ass2, usw.\
Stelle bei den Properties der Button Visible auf false.\
achte darauf, dass die Buttons groß genug sind, dass der Text 'Kreuz-Ass Wert ändern' sichtbar rein passt.

Wenn der Spieler ein Ass zieht soll der Button Ass1 sichtbar werden und der Text soll zu '(Karten-Name vom ass) Wert ändern' werden.\
Wenn witere Asse gezogen werden, soll das dann auch mit den nächsten Buttons passieren.