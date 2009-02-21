using System;

namespace Marina.Presentation.DTO {
	[Serializable]
	public class LoginCredentialsDTO {
		private readonly string username;
		private readonly string password;

		private LoginCredentialsDTO() {}

		public LoginCredentialsDTO( string username, string password ) {
			this.username = username;
			this.password = password;
		}

		public string Username {
			get { return username; }
		}

		public string Password {
			get { return password; }
		}
	}
}