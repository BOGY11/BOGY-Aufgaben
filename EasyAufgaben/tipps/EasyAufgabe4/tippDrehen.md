```
var stoppuhr = new Stopwatch();
string[] symbole = new string[3];
stoppuhr.Start();
while (stoppuhr.Elapsed.TotalSeconds <= 3)
{
	if (stoppuhr.Elapsed.TotalSeconds <= 1)
		symbole = SetRandomSymbole(symbole, 3);

	if (stoppuhr.Elapsed.TotalSeconds <= 2 && stoppuhr.Elapsed.TotalSeconds > 1)
		symbole = SetRandomSymbole(symbole, 2);

	if (stoppuhr.Elapsed.TotalSeconds <= 3 && stoppuhr.Elapsed.TotalSeconds > 2)
		symbole = SetRandomSymbole(symbole, 1);

	Console.ClearLine();
	Console.Write($"[{symbole[0]}|{symbole[1]}|{symbole[2]}]");
	await Task.Delay(100);
}
stoppuhr.Stop();
return [Symbole.GetIndex(symbole[0]), Symbole.GetIndex(symbole[1]), Symbole.GetIndex(symbole[2])];
```