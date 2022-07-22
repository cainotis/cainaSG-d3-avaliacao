namespace autenticator.Translation{
	public class Translator{

		private Dictionary<string, string> translation = new Dictionary<string, string>();

		public Translator(string lang = "PT"){
			if (lang == "PT"){
				translation["UNAUTHENTICATED"] = "1 - Acessar \n2 - Cancelar";
				translation["AUTHENTICATED"] = "1 - Deslogar \n2 - Encerrar";
				translation["UNVALID"] = "Opção invalida";
			}
		}

		public string? Get(string key){
			return translation[key];
		}
	}
}