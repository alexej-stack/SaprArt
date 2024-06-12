namespace SaprArt.Infrastructure;

public static class Logger
{
	private static StreamWriter _logFile;

	public static void SetupLogging(bool logToFile = false, string filename = "app.log")
	{
		if (logToFile)
		{
			File.Delete(filename);
			_logFile = new StreamWriter(filename, append: true) { AutoFlush = true };
		}
	}

	public static void Log(string message)
	{
		var logMessage = $"{DateTime.Now} - {message}";


		if (_logFile != null)
		{
			_logFile.WriteLine(logMessage);
		}
		else
		{
			System.Console.WriteLine(logMessage);
		}
	}
}