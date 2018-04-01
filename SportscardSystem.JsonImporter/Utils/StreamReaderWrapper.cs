using Bytes2you.Validation;
using SportscardSystem.JsonImporter.Utils.Contracts;
using System.IO;

namespace SportscardSystem.JsonImporter.Utils
{
    public class StreamReaderWrapper : IStreamReader
    {
        private StreamReader streamReader;

        public StreamReaderWrapper(string filePath)
        {
            Guard.WhenArgument(filePath, "StreamReaderWrapper").IsNullOrEmpty().Throw();

            this.streamReader = new StreamReader(filePath);
        }

        public StreamReader GetStreamReader()
        {
            return this.streamReader;
        }
    }
}