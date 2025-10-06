using System.IO.Compression;

namespace Alexon.UsefulFeatures
{
    public class ZipHelper
    {
        public static void Unzip(string zipFile, string outputFolder)
        {
            using (ZipArchive archive = ZipFile.OpenRead(zipFile))
            {
                foreach (ZipArchiveEntry entry in archive.Entries)
                {
                    entry.ExtractToFile(Path.Combine(outputFolder, entry.FullName));
                }
            }
        }
    }
}