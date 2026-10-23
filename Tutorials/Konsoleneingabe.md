
# Konsoleneingabe

Beispiel: 
```csharp
Console.Write("Wie heißt du? ");
string name = Console.ReadLine();

Console.Write("Wie alt bist du? ");
int alter = int.Parse(Console.ReadLine());

Console.WriteLine($"Hallo {name}! Nächstes Jahr wirst du {alter + 1}.");
```
`Console.ReadLine` gibt immer einen `string` zurück. \
Um den `string` zu einer Nummer zu machen, konvertiert man die Eingabe mit `int.Parse(...)` oder `double.Parse(...)`. \
Siehe: [Variablen Parsen](../Tutorials/Parsing.md)