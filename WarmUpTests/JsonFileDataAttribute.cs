using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Xunit.Sdk;

//taken and modified from https://github.com/andrewlock/blog-examples/tree/master/XUnitTheoryTests

namespace WarmUpTests
{
    public class JsonFileDataAttribute : DataAttribute
    {
        private readonly string _filePath;

        /// <summary>
        ///     Load data from a JSON file as the data source for a theory
        /// </summary>
        /// <param name="filePath">The absolute or relative path to the JSON file to load</param>
        public JsonFileDataAttribute(string filePath)
        {
            _filePath = filePath;
        }


        /// <inheritDoc />
        public override IEnumerable<object[]> GetData(MethodInfo testMethod)
        {
            if (testMethod == null)
            {
                throw new ArgumentNullException(nameof(testMethod));
            }

            // Get the absolute path to the JSON file
            var path = Path.IsPathRooted(_filePath)
                ? _filePath
                : Path.GetRelativePath(Directory.GetCurrentDirectory(), _filePath);

            if (!File.Exists(path))
            {
                throw new ArgumentException($"Could not find file at path: {path}");
            }

            // Load the file
            var fileData = File.ReadAllText(_filePath);


            var container = JsonConvert.DeserializeObject<TestContainer>(fileData);

            return container.Tests.Select(x => new[] {(object) x});
        }
    }
}
