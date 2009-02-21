using Marina.Infrastructure.Logging.Interfaces;
using Marina.Infrastructure.Logging.TextWriterLogging;
using MbUnit.Framework;

namespace Marina.Test.Unit.Infrastructure.TextWriterLogging {
	[TestFixture]
	public class TextWriterLogFactoryTest {
		[Test]
		public void Should_create_a_text_writer_log( ) {
			ILog log = CreateSUT( ).CreateFor( this.GetType( ) );
			Assert.IsNotNull( log );
			Assert.IsInstanceOfType( typeof( TextWriterLog ), log );
		}

		private ILogFactory CreateSUT( ) {
			return new TextWriterLogFactory( );
		}
	}
}