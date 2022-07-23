// See https://aka.ms/new-console-template for more information
using System;
using System.Collections.Generic;

using autenticator.Translation;
using autenticator.Logging;

namespace autenticator {
	public class Program {

		private static Translator translator = new Translator();
		private static Logger logger = new Logger();
		 
		private static bool auth = false;

		public static void Main(){
			bool run = true;
			while(run){
				if(auth){
					run = Authentified();
				}
				else {
					run = Unauthenticated();
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
					auth = true;
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