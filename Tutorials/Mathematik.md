
# Mathematik und Operationen

## Mathematik
```csharp
int a = 10;
int b = 3;

Console.WriteLine(a + b);   // Addition
Console.WriteLine(a - b);   // Subtraktion
Console.WriteLine(a * b);   // Multiplikation
Console.WriteLine(a / b);   // Division
Console.WriteLine(a % b);   // Modulo (Gibt den Rest der Division zurück)

int score = 0;
score = score + 5;  // Erhöht 'score' um 5
score += 5;         // Gleich wie score = score + 5
score++;            // Erhöht score um 1
```

## Operatoren
Operatoren werden genutzt um zwei Aussagen oder Variablen zu vergleichen. \
Das Ergebnis eines Operators ist immer `true` oder `false`.

### Vergleichsoperatoren
Um zwei Werte miteinander zu vergleichen nutzt man Vergleichsoperatoren.\
Folgende Operatoren stehen in C# zur Verfügung: \
`==` Gleich: Vergleicht ob zwei Werte exakt gleich sind. Gibt `true` zurück wenn beide gleich sind. \
`!=` Ungleich: Vergleicht ob sich zwei Werte unterscheiden. Gibt `true` zurück wenn es zwei unterschiedliche Werte sind. \
`>`  Größer: Vergleicht zwei Zahlen und gibt `true` zurück wenn Variable `a` größer als Variable `b` ist. \
`<`  Kleiner: Vergleicht zwei Zahlen und gibt `true` zurück wenn Variable `a` kleiner als Variable `b` ist. \
`>=` und `<=` Größer gleich und Kleiner gleich: Wie `Größer` und `Kleiner`, gibt allerdings auch `true` zurück wenn die Werte gleich sind. 

### Logikoperatoren
Um zwei Aussagen miteinander zu vergleichen nutzt man Logikoperatoren. \
Es gibt drei Logikoperatoren in C#: \
`&&` Und: Gibt `true` zurück wenn beide Aussagen wahr sind.
`||` Oder: Gibt `true` zurück wenn mindestens eine der beiden Aussagen wahr ist.
`!`  Nicht: Wird vor eine Aussage geschrieben und kehrt den Wert um. `true` wird zu `false` und `false` wird zu `true`.
