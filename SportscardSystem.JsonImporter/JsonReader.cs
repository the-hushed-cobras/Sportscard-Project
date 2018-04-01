using Bytes2you.Validation;
using SportscardSystem.DTO;
using SportscardSystem.JsonImporter.Utils.Contracts;
using System.Collections.Generic;

namespace SportscardSystem.JsonImporter
{
    public class JsonReader : IJsonReader
    {
        private IStreamReader streamReaderWrapper;

        private IJsonDeserializer jsonDeserializerWrapper;
        
        public JsonReader(IStreamReader streamReaderWrapper, IJsonDeserializer jsonDeserializerWrapper)
        {
            Guard.WhenArgument(streamReaderWrapper, "JsonReader").IsNull().Throw();

            Guard.WhenArgument(jsonDeserializerWrapper, "JsonReader").IsNull().Throw();

            this.streamReaderWrapper = streamReaderWrapper;
            this.jsonDeserializerWrapper = jsonDeserializerWrapper;
        }
        
        public IEnumerable<SportscardDto> ImportSportscards()
        {
            using (this.streamReaderWrapper.GetStreamReader())
            {
                return this.jsonDeserializerWrapper.Deserialize(this.streamReaderWrapper.GetStreamReader().ReadToEnd());
            }
        }
    }
}
