
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
            var actual = fileManager.ReadLines(FilePath);
            var expected = File.ReadLines(FilePath);

            Expect(actual, Is.EqualTo(expected));
        }

        [Test]
        public void Return_True_If_File_Exists()
        {
            var actual = fileManager.FileExists(FilePath);

            Expect(actual, Is.True);
        }

        [Test]
        public void Return_False_If_File_Do_Not_Exists()
        {
            string fakeFilePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "/Data/AER.csv";
            var actual = fileManager.FileExists(fakeFilePath);

            Expect(actual, Is.False);
        }
    }
}
