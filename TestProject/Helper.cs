using System.IO;
using System.Text;
using CsvHelper;
using Xunit;

namespace TestProject
{
    public static class Helper
    {
        public static void TestContainer<T>(T[] records)
        {
            using (var stream = new MemoryStream())
            {
                using (var writer = new StreamWriter(stream, Encoding.UTF8, 1024, true))
                using (var csv = new CsvWriter(writer))
                {
                    csv.Configuration.ReferenceHeaderPrefix = (type, name) => $"{name}.";
                    csv.WriteRecords(records);
                }
                stream.Position = 0;
                using (var reader = new StreamReader(stream))
                {
                    var line = reader.ReadLine();
                    Assert.Equal("Key,Nested1.A,Nested1.B,Nested2.A,Nested2.B", line);

                    line = reader.ReadLine();
                    Assert.Equal("key1,n1a,n1b,n2a,n2b", line);

                    line = reader.ReadLine();
                    Assert.Null(line);
                }
            }

        }
    }
}
