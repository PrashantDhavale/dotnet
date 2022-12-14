using Newtonsoft.Json.Linq;
using System;
using System.Linq;

namespace JsonPaths
{
    class Program
    {
        public static void Main()
        {
            string json = @"
            {
              ""Level1"": [
                {
                  ""Level2"": {
                    ""A"": ""something1"",
                    ""B"": 1,
					""C"": [""foo"", ""bar""]
                  },
                  ""Level3"": [
                    {
                      ""3A"": ""content""
                    }
                  ],
                  ""Level41"": null,
                  ""Level42"": null,
                  ""Level43"": null,
                  ""Level44"": ""content"",
                  ""Level45"": ""content"",
                  ""Level46"": ""content""
                },
                {
                  ""Level2"": {
                    ""A"": ""something1"",
                    ""B"": 2,
					""C"": [""whiz"", ""bang""]
                  },
                  ""Level3"": [
                    {
                      ""3A"": ""morecontent""
                    }
                  ],
                  ""Level41"": null,
                  ""Level42"": null,
                  ""Level43"": null,
                  ""Level44"": ""content"",
                  ""Level45"": ""morecontent"",
                  ""Level46"": ""content""
                }
              ]
            }";

            var obj = JObject.Parse(json);

            var paths = obj.DescendantsAndSelf()
                           //.OfType<JProperty>()
                           //.Where(jp => jp.Value is JValue)
                           .Select(jp => jp.Path.Replace('.', '/'))
                           .Distinct()
                           .ToList();

            Console.WriteLine(string.Join("\n", paths));


            Console.WriteLine("------------------");

        }

    }
}
