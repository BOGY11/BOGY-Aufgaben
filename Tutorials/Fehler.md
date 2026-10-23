
# Fehler abfangen
Mithilfe der `try` Methode kann man verhindern dass das Programm abstürzt. Dabei versucht das Programm zunächst den Code auszuführen, und bricht diesen ab wenn ein bestimmter Fehler im Programm auftritt. 
```csharp
Console.Write("Gib eine Zahl ein: ");
try
{
    int nummer = int.Parse(Console.ReadLine());
    Console.WriteLine($"Du hast die Zahl {nummer} eingegeben!");
}
catch (FormatException)
{
    Console.WriteLine
}
```
Im Fall `int.Parse()` gibt es auch eine sicherere Variante, welche direkt in die Methode integriert ist. 
```csharp
if(int.TryParse(Console.ReadLine(), out int value))
{
    Console.WriteLine($"Erlaubt: {value}");
}
else 
{  
    Console.WriteLine("Diese Eingabe ist nicht erlaubt.");
}
```
Die if-Methode überprüft in diesem Fall, ob `int.TryParse()` eine Variable `int value` ausgibt. Ist dies der Fall fährt der Code innerhalb der Verzweigung fort. \
Wenn `int.TryParse()` etwas anderes als einen int-Wert zurück gibt, fährt das Programm mit der `else` Verzweigung fort. \
Durch `int.TryParse()` wird das Problem gelöst, dass der Nutzer etwas anderes als eine Zahl eingibt, was wenn man nur `int.Parse()` nutzen würde zu einem Absturz des Programms führen würde. 