using System.Collections.Generic;
using System.Text;
using Ionic;
using Ionic.BZip2;
using Ionic.Crc;
using Ionic.Zip;
using Ionic.Zlib;

namespace IonicZipSample
{
    public class TestApis
    {
        private ZipEntry _zipEntry;
        private ZipFile _zipFile;
        private ZipOutputStream _zipOutputStream;
        private DeflateStream _deflateStream;
        private GZipStream _gZipStream;
        private byte _byte;
        private byte[] _bytes;
        private CrcCalculatorStream _stream;
        private bool _flag;
        private IEnumerable<string> _enumerable;
        private Encoding _encoding;
        private ExtractExistingFileAction _fileAction;

        private FileSelector _fileSelector;
        private CRC32 _crc32Algorithm;
        private BZip2InputStream _bZip2InputStream;
        private BZip2OutputStream _bZip2OutputStream;
        private ParallelBZip2OutputStream _parallelBZip2OutputStream;

        public void CallApis()
        {
            // Ionic namespace
            string criteria = _fileSelector.SelectionCriteria;
            bool traverseReparsePoints = _fileSelector.TraverseReparsePoints;
            ICollection<ZipEntry> entries = _fileSelector.SelectEntries(_zipFile);
            ICollection<string> files = _fileSelector.SelectFiles(string.Empty);

            // Crc namespace
            int crc32Result = _crc32Algorithm.Crc32Result;
            long totalBytesRead = _crc32Algorithm.TotalBytesRead;
            int computeCrc32 = _crc32Algorithm.ComputeCrc32(0, _byte);
            int getCrc32 = _crc32Algorithm.GetCrc32(_parallelBZip2OutputStream);
            int getCrc32AndCopy = _crc32Algorithm.GetCrc32AndCopy(_bZip2InputStream, _bZip2OutputStream);
            _crc32Algorithm.Combine(0, 0);
            _crc32Algorithm.Reset();
            _crc32Algorithm.SlurpBlock(_bytes, 0, 0);
            _crc32Algorithm.UpdateCRC(_byte, 0);

            // Used apis
            _zipEntry.Extract(string.Empty);
            _zipEntry.Extract(string.Empty);
            _zipEntry.Extract(_stream);
            _zipEntry.ExtractWithPassword(string.Empty, _fileAction, string.Empty);
            _zipEntry.OpenReader();
            _zipFile.AddEntry(string.Empty, _bytes);
            _zipFile.AddEntry(string.Empty, string.Empty);
            _zipFile.AddEntry(string.Empty, string.Empty, _encoding);
            _zipFile.AddFile(string.Empty, string.Empty);
            _zipFile.AddFiles(_enumerable, _flag, string.Empty);
            _zipFile.ExtractAll(string.Empty);
            _zipFile.ExtractAll(string.Empty, _fileAction);
            ZipFile.IsZipFile(string.Empty);
            ZipFile.Read(string.Empty);
            ZipFile.Read(_stream);
            _zipFile.Save();
            _zipFile.Save(string.Empty);
            _zipFile.Save(_stream);
            _zipFile.UpdateFile(string.Empty, string.Empty);
            _zipOutputStream.PutNextEntry(string.Empty);
            _zipOutputStream.Write(_bytes, 0, 0);
            _deflateStream.Write(_bytes, 0, 0);
            _gZipStream.Write(_bytes, 0, 0);
        }
    }
}
