using Marina.Presentation.DTO;

namespace Marina.Task {
	public interface IAuthenticationTask {
		DisplayResponseLineDTO AuthenticateUserUsing( LoginCredentialsDTO credentials );
	}
}