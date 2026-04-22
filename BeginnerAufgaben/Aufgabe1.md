# Variablen
Ziel ist es zu verstehen, was variablen sind und wie man diese verändert.

## Phase 1 (Project erstellen)
Öffne Visual Studio und drücke auf 'Neues Project erstellen', bzw. 'Create new Project'. \
Wähle dann 'Console App', bzw. 'Consolenanwendung'.\
Gebe als Projectname 'Variablen' ein.\
Falls du noch keinen hast erstelle im laufwerk O: ein neuen Ordner mit deinem Namen.\
Diesen wählst du dann als speicherort für dein project.
Die restlichen einstellungen kannst du so lassen, wie sie sind.

Es öffnet sich eine datei in der so etwas drin steht:
``` 
// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
```
Das bitte entfernen;

## Phase 2 (Variablen erstellen und wert speichern)
Nun erstellen wir eine Variable. \
Gebe ein:\
`int a;`\
Damit haben wir eine Variable vom typ int erstellt.\
Das bedeutet, dass c Ganzzahlen speichern kann.\
Propiere es aus indem du c einen wert gibts.\
Z.B.:\
`a = 15;`\
und gebe diesen wert anschließend in der Console aus:\
`Console.WriteLine(a);`

Führe das Programm aus.

## Phase 3 (Variablen zusammenrechnen)
Füge nun unten eine neue Variable vom typ int mit den Namen `b` hinzu und gebe ihr einen wert.\
Füge darunter noch eine neue variable vom typ int mit dem namen `c`.\
Gebe `c` folgenden wert:\
`c = a + b;`\
Gebe die werte für `a`, `b` und `c` au:
```
Console.WriteLine(a);
Console.WriteLine(b);
Console.WriteLine(c);
```
Führe das Programm aus.\
Gebe anschließend verschiedene werte für `a` und `b` an und schau was passiert, wenn du das Programm ausführst.

## Phase 3 (Fläche eines Rechtecks berechnen)
Ändere den wert von `c` so ab, dass es das Volumen des Rechtecks mit der grundseite `a` und der höhe `b` berechnet.\
Die Formel dafür lautet:
Fläche $= a \times b$

Führe das Programm aus.
