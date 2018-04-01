using Bytes2you.Validation;
using SportscardSystem.FileImporters.Utils.Contracts;
using System.IO;

namespace SportscardSystem.FileImporters.Utils
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