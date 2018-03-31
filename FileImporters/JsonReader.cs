using Bytes2you.Validation;
using SportscardSystem.DTO.JSON;
using SportscardSystem.FileImporters.Utils.Contracts;
using System.Collections.Generic;

namespace SportscardSystem.FileImporters
{
    public class JsonReader
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
        
        public IEnumerable<SportscardJsonDto> ImportSportscards()
        {
            using (this.streamReaderWrapper.GetStreamReader())
            {
                return this.jsonDeserializerWrapper.Deserialize(this.streamReaderWrapper.GetStreamReader().ReadToEnd());
            }
        }
    }
}
