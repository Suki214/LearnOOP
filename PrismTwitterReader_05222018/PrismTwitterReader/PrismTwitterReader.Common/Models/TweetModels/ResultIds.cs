using Newtonsoft.Json;

namespace PrismTwitterReader.Common
{
    public class ResultIds
    {
        private long[] _ids;

        [JsonProperty("ids")]
        public long[] Ids
        {
            get { return _ids ?? new long[0]; }
            set { _ids = value; }
        }
    }
}