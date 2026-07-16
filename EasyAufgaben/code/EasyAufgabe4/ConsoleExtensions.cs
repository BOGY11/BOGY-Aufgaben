namespace EinarmigerBandit;

internal static class ConsoleExtensions
{
	extension(Console)
	{
		public static void ClearLine()
		{
			int currentLine = Console.CursorTop;
			Console.SetCursorPosition(0, currentLine);
			Console.Write(new string(' ', Console.WindowWidth));
			Console.SetCursorPosition(0, currentLine);
		}
	}
}
