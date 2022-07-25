using System.Data.SqlClient;
using System.Data.SQLite;

using Microsoft.AspNetCore.Identity;

using authenticator.Configuration;
using authenticator.Logging;
using authenticator.Translation;
using authenticator.Repositories;
using authenticator.Models;
using authenticator.ConsoleApp;

namespace authenticator {
	public class Program {

		public static void Main(){

            Config config = ConfigManager.Loader();
			Translator translator = new Translator(lang: config.Language);
			Logger logger = new Logger(log_path: config.LogPath, log_level: config.LogLevel);
			UserRepository user_repository;
            PasswordHasher<string> hasher = new PasswordHasher<string>();

			logger.info("system started");

			using (SQLiteConnection conn = new SQLiteConnection(config.ConnectionString))
			{
				conn.Open();
                logger.info("connected to database");
                user_repository = new UserRepository(connection:conn);
				
                App app = new App(
					config: config,
					translator: translator,
					logger: logger,
                    user_repository: user_repository,
					hasher: hasher
				);

				app.run();
			}
			
		}

		
	}
}