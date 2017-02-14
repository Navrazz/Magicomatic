
using System.IO;
using System.Reflection;
using NUnit.Framework;
using Magicomatic.Data.Tools;

namespace Magicomatic.Data.UnitTests.Tools
{
    [TestFixture]
    class FileManagerTests : AssertionHelper
    {
        private string FilePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "/Data/EMN.csv";
        private FileManager fileManager;

        [SetUp]
        public void Before_Each_Test()
        {
            this.fileManager = new FileManager();
        }

        [Test]
        public void Reads_Lines_From_File()
        {
            var dir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            var actual = fileManager.ReadLines(FilePath);
            var expected = File.ReadLines(FilePath);

            Expect(actual, Is.EqualTo(expected));
        }
    }
}
