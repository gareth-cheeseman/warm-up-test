using System.Collections;
using System.Collections.Generic;

namespace WarmUpTests
{
    public class TestContainer
    {
        public IEnumerable<TestObject> Tests { get; set; }
    }

    public class TestObject 
    {
        public string Name;
        public TestType TestType;
        public string Path;
        public string Expression;
        public object Expectation;

        public TestObject()
        {
                
        }

        public TestObject(string name, TestType testType, string path, bool expectation, string expression = null)
        {
            Name = name;
            TestType = testType;
            Path = path;
            Expression = expression;
            Expectation = expectation;
        }

    }
}