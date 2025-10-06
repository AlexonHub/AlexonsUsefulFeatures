using FluentAssertions;
using NUnit.Framework;

namespace Alexon.UsefulFeatures.Tests
{
    [TestFixture()]
    public class ZipHelperTests
    {
        [Test()]
        public void UnzipTest()
        {
            string testFolder = $@"{TestContext.CurrentContext.TestDirectory}\TestLocations\";
            string archiveFile = "TestArchive.zip";

            ZipHelper.Unzip($"{testFolder}{archiveFile}", testFolder);

            var unzipped = Directory.GetFiles(testFolder, "*.txt");
            unzipped.Length.Should().Be(3);

            //clean up destination folder
            foreach (var file in unzipped)
            {
                File.Delete(file);
            }
        }
    }
}