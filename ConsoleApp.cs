using authenticator.Configuration;
using authenticator.Logging;
using authenticator.Translation;
using authenticator.Repositories;
using authenticator.Models;

using Microsoft.AspNetCore.Identity;

namespace authenticator.ConsoleApp
{
	
	public class App
	{
		private Config config;
		private Translator translator;
		private Logger logger;
		private UserRepository user_repository;
		private PasswordHasher<string> hasher;

		private User? user_logged;

		public App(Config config,
				   Translator translator,
				   Logger logger,
				   UserRepository user_repository,
                   PasswordHasher<string> hasher)
		{
			this.config = config;
			this.translator = translator;
			this.logger = logger;
			this.user_repository = user_repository;
			this.hasher = hasher;
		}

		public void run()
		{
			bool run = true;
			user_logged = null;
			while (run)
			{
				if(user_logged == null)
				{
					run = Unauthenticated();
				}
				else
				{
					run = Authentified();
				}
			}
		}

		private bool Unauthenticated()
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
					if (email != null && password != null)
					{
						User? user = user_repository!.GetByEmail(email);
						if (user != null && hasher.VerifyHashedPassword(user.email, user.password, password) == PasswordVerificationResult.Success)
						{
							user_logged = user;
							Console.WriteLine(translator.Get("ACCESS_GRANTED"));
							logger.info(string.Format("login user: {0} name: {1}", user.userId, user.name));
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
		private bool Authentified()
		{
			string? option;
			Console.WriteLine(translator.Get("AUTHENTICATED"));
			option = Console.ReadLine();
			switch (option)
			{
				case "1":
                    logger.info(string.Format("logout user: {0} name: {1}", user_logged!.userId, user_logged.name));
					user_logged = null;
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