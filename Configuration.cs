using System.Text.Json;
using System.Text.Json.Serialization;

namespace authenticator.Configuration
{
	public class Config
	{
		public string LogLevel {get; set;} = "";
		public string LogPath { get; set; } = "";
		public string ConnectionString { get; set; } = "";
		public string Language { get; set; } = "";
	}

	public class ConfigManager
	{
		public static Config Loader()
		{
			string jsonString = File.ReadAllText("config.json");
			Config? config = JsonSerializer.Deserialize<Config>(jsonString);

			if(config == null){
				throw new ArgumentNullException("config.json not found");
			}

			return config;
		}
	}
}