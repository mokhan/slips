using System;

namespace Marina.Infrastructure.Container {
	public class InterfaceResolutionException : Exception {
		public const string ExceptionMessageFormat = "Failed to resolve an implementation of an {0}";

		public InterfaceResolutionException( Exception innerException, Type interfaceThatCouldNotBeResolvedForSomeReason )
			: base(
				string.Format( ExceptionMessageFormat, interfaceThatCouldNotBeResolvedForSomeReason.FullName ), innerException ) {}
	}
}