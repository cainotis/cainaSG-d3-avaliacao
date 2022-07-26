using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace authenticator.Logging
{
	public class Logger
	{
		private string path;
		private LoggingLevels level;

		public enum LoggingLevels: ushort
		{
			DEBUG = 0,
			INFO = 1,
			WARN = 2,
			ERROR = 3
		}

		public Logger(string log_path = "auth.log", string log_level = "INFO")
		{	
			path = log_path;
			if(Enum.TryParse<LoggingLevels>(log_level, out level) == false)
				level = LoggingLevels.INFO;
		}

		public void debug(string message)
		{
			if(level >= LoggingLevels.DEBUG){
				log("DEBUG\t" + message);
			}
		}
		public void info(string message)
		{
			if (level >= LoggingLevels.INFO)
			{
				log("INFO\t" + message);
			}
		}
		public void warn(string message)
		{
			if (level >= LoggingLevels.WARN)
			{
				log("WARN\t" + message);
			}
		}
		public void error(string message)
		{
			if (level >= LoggingLevels.ERROR)
			{
				log("ERROR\t" + message);
			}
		}

		public void log(string message)
		{
			write(DateTime.Now.ToString()+"\t"+message);
		}

		private void write(string message)
		{
			using (StreamWriter sw = File.AppendText(path))
			{
				sw.WriteLine(message);
			}
		}
	}
}