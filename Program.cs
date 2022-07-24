// See https://aka.ms/new-console-template for more information
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SQLite;


using authenticator.Configuration;
using authenticator.Logging;
using authenticator.Translation;
using authenticator.Repositories;
using authenticator.Models;

namespace authenticator {
	public class Program {

		private static Config config = ConfigManager.Loader();
		private static Translator translator = new Translator(lang: config.Language);
		private static Logger logger = new Logger(log_path: config.LogPath, log_level: config.LogLevel);
		private static UserRepository? userRepository;

		private static bool auth = false;

		public static void Main(){
			bool run = true;
			// logger.info("system started");
			using (SQLiteConnection conn = new SQLiteConnection(config.ConnectionString))
			{
				conn.Open();
                // logger.info("connected to database");
                userRepository = new UserRepository(connection:conn);
				
                while (run)
                {
                    if (auth)
                    {
                        run = Authentified();
                    }
                    else
                    {
                        run = Unauthenticated();
                    }
                }
			}
			
		}

		private static bool Unauthenticated()
		{
			string? option;
			Console.WriteLine(translator.Get("UNAUTHENTICATED"));
			option = Console.ReadLine();
			switch (option)
			{
				case "1":
					Console.WriteLine(translator.Get("INSERT_EMAIL"));
					string? email = Console.ReadLine();
                    Console.WriteLine(translator.Get("INSERT_PASSWORD"));
                    string? password = Console.ReadLine();
					if(email != null && password != null){
						User? user = userRepository!.GetByEmail(email);
						if(user != null && user.password == password){
							auth = true;
                            Console.WriteLine(translator.Get("ACCESS_GRANTED"));
							break;
						}
					}
                    Console.WriteLine(translator.Get("ACCESS_DENIED"));
					break;
				case "2":
					return false;
				default:
					Console.WriteLine(translator.Get("UNVALID"));
					break;
			}
			return true;
			
		}
        private static bool Authentified()
		{
            string? option;
            Console.WriteLine(translator.Get("AUTHENTICATED"));
            option = Console.ReadLine();
            switch (option)
            {
                case "1":
                    auth = false;
                    break;
                case "2":
                    return false;
                default:
                    Console.WriteLine(translator.Get("UNVALID"));
                    break;
            }
            return true;
        }
	}
}