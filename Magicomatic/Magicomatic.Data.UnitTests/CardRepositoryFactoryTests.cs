using System.IO;
using System.Reflection;
using NUnit.Framework;
using NSubstitute;
using Magicomatic.Data.Tools;

namespace Magicomatic.Data.UnitTests
{
    [TestFixture]
    class CardRepositoryFactoryTests : AssertionHelper
    {
        private string filePath;
        private FileManager fileManager;

        private CardRepositoryFactory target;

        [SetUp]
        public void Before_Each_Test()
        {
            this.filePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "/Data/EMN.csv";
            this.fileManager = Substitute.For<FileManager>();

            this.target = new CardRepositoryFactory(this.fileManager);
        }

        [Test]
        public void Creates_CardFileFactory_If_File_Exists()
        {
            this.fileManager.FileExists(Arg.Any<string>()).Returns(true);

            var actual = this.target.CreateRepository(filePath);

            Expect(actual, Is.TypeOf(typeof(CardFileRepository)));
        }

        [Test]
        public void Creates_CardOnlineRepository_If_File_Do_Not_Exists()
        {
            this.fileManager.FileExists(Arg.Any<string>()).Returns(false);

            var actual = this.target.CreateRepository(filePath);

            Expect(actual, Is.TypeOf(typeof(CardOnlineRepository)));
        }
    }
}
