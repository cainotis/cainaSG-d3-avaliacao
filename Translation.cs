namespace authenticator.Translation{
	public class Translator{

		private Dictionary<string, string> translation = new Dictionary<string, string>();

		public Translator(string lang = "PT"){
			if (lang == "PT"){
				translation["UNAUTHENTICATED"] = "1 - Acessar \n2 - Cancelar";
				translation["AUTHENTICATED"] = "1 - Deslogar \n2 - Encerrar";
				translation["UNVALID"] = "Opção invalida";
				translation["INSERT_EMAIL"] = "digite o email:";
				translation["INSERT_PASSWORD"] = "digite a senha:";
				translation["ACCESS_DENIED"] = "credenciais invalidas";
				translation["ACCESS_GRANTED"] = "logado";
			}
		}

		public string? Get(string key){
			return translation[key];
		}
	}
}