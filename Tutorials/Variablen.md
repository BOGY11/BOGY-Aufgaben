Eine Variable ist ein benannter Platzhalter welcher unterschiedliche Werte speichert.
```
string name = "Anna";       // Text
int alter = 25;             // Ganze Zahlen
double höhe = 1.72;        // Dezimalzahlen
bool istSchüler = true;    // Wahr oder Falsch ( true oder false)
char note = 'A';            // Ein einziger Buchstabe

Console.WriteLine($"Mein Name ist {name} und ich bin {alter} Jahre alt.");
Console.WriteLine("Mein Name ist " + name + " und ich bin " + alter + " Jahre alt.");
```
Beide Console.WriteLines geben das gleiche aus. $"..." wird genutzt um die Werte von Variablen in einen Text zu schreiben indem man den Namen der Variable in geschweifte Klammern "{}" schreibt. 

Der Variablentyp "var" kann für jeden Variablentyp genutzt werden. Dabei ermittelt C# den Typ. 
Beispiel: `var stadt = "Berlin";` wird zu einem string. 

Mit dem Modifikator `const` wird eine Variable erstellt dessen Wert sich nicht ändern kann. \
`const double Pi = 3.14159;`
