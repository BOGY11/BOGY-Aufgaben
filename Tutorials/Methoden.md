
# Methoden
Methoden sind eine Möglichkeit, einmal geschriebenen Code einfach wieder zu verwenden, ohne ihn jedes mal schreiben zu müssen. \
Eine Methode wird normalerweise genutzt, um genau eine Aufgabe auszuführen. \
Methoden können Rückgabewerte haben. Eine Methode wird wie folgt implementiert: 
```csharp
void MethodenName(Parameter 1, Parameter 2, ...) // Beispiel einer Methode ohne Rückgabewert
{
    //Auszuführender Code...
}

int Addiere(int x, int y) // Methode gibt einen Wert int zurück
{
    int z = x + y
    return z;
}

void Grüße(string name)
{
    Console.WriteLine($"Hallo, {name}!");
}

Grüße("Dein Name");
int ergebnis = Addiere(3, 4);
Console.WriteLine(ergebnis);
```
