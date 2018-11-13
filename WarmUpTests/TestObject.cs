using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace WarmUpTests
{
    public class TestContainer
    {
        public IEnumerable<TestObject> Tests { get; set; }
    }

    public class TestObject 
    {
        public string Name;
        [JsonProperty("type")]
        [JsonConverter(typeof(StringEnumConverter))]
        public TestType TestType;
        public string Path;
        public string Expression;
        public object Expectation;

        public TestObject()
        {
                
        }

        public override string ToString()
        {
            return this.Name;
        }
    }
}