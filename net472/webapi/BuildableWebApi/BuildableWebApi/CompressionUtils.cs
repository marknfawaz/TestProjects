using Ionic;
using Ionic.Crc;
using Ionic.Zip;
using System.IO;

namespace BuildableWebApi
{
    public class CompressionUtils
    {
        public void CompressFiles()
        {
            var fileSelector = new FileSelector("");
            var readOptions = new ReadOptions();
            var crc32 = new CRC32();
            var inputStream = new Ionic.BZip2.BZip2InputStream(new FileStream("", FileMode.Open));
        }
    }
}