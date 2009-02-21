using System.IO;
using System.Text;
using Marina.Infrastructure.Logging.Interfaces;
using Marina.Infrastructure.Logging.TextWriterLogging;
using MbUnit.Framework;

namespace Marina.Test.Unit.Infrastructure.TextWriterLogging {
	[TestFixture]
	public class TextWriterLogTest {
		[Test]
		public void Should_log_message_to_backing_store( ) {
			string expectedMessage = "Message";

			StringWriter writer = new StringWriter( new StringBuilder( ) );

			ILog consoleLogger = CreateSUT( writer );
			consoleLogger.Informational( expectedMessage );

			Assert.AreEqual( expectedMessage, writer.ToString( ).Trim( ) );
		}

		private ILog CreateSUT( TextWriter writer ) {
			return new TextWriterLog( writer );
		}
	}
}