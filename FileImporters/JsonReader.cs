using System.Collections.Generic;
using System.IO;
using Bytes2you.Validation;
using LibrarySystem.FileImporters.Utils.Contracts;
using LibrarySystem.Models.DTOs.JSON;

namespace SportscardSystem.FileImporters
{
    /// <summary>
    /// Represent a <see cref="JsonReader"/> class.
    /// </summary>
    public class JsonReader
    {
        /// <summary>
        /// Stream reader object handle.
        /// </summary>
        private StreamReader streamReaderWrapper;

        /// <summary>
        /// JSON Journals deserializer object handle.
        /// </summary>
        private IJsonDeserializer jsonDeserializerWrapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="JsonReader"/> class.
        /// </summary>
        /// <param name="streamReaderWrapper">Stream reader wrapper to be used for reading text data.</param>
        /// <param name="jsonDeserializerWrapper">JSON deserializer wrapper to be used for converting JSON text.</param>
        public JsonReader(IStreamReader streamReaderWrapper, IJsonDeserializer jsonDeserializerWrapper)
        {
            Guard.WhenArgument(streamReaderWrapper, "JsonReader").IsNull().Throw();

            Guard.WhenArgument(jsonDeserializerWrapper, "JsonReader").IsNull().Throw();

            this.streamReaderWrapper = streamReaderWrapper;
            this.jsonDeserializerWrapper = jsonDeserializerWrapper;
        }

        /// <summary>
        /// Imports the specified collection of Journal DTOs from JSON text file.
        /// </summary>
        /// <returns>Collection of Journal DTOs.</returns>
        public IEnumerable<JournalJsonDto> ImportJournals()
        {
            using (this.streamReaderWrapper.GetStreamReader())
            {
                return this.jsonDeserializerWrapper.Deserialize(this.streamReaderWrapper.GetStreamReader().ReadToEnd());
            }
        }
    }
}