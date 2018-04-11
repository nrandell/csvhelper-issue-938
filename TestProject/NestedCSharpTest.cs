using System.Collections;
using System.IO;
using System.Text;
using CsvHelper;
using Xunit;

namespace TestProject
{
    public class NestedCSharpTest
    {
        public class Nested
        {
            public string A { get; set; }
            public string B { get; set; }
        }

        public class Container
        {
            public string Key { get; set; }
            public Nested Nested1 { get; set; }
            public Nested Nested2 { get; set; }
        }

        public class NestedLikeFSharp : IStructuralEquatable
        {
            public bool Equals(object other, IEqualityComparer comparer) => false;
            public int GetHashCode(IEqualityComparer comparer) => 0;

            public string A { get; }
            public string B { get; }
            public NestedLikeFSharp(string a, string b) {
                A = a;
                B = b;
            }
        }

        public class ContainerWithFSharpLikeNested {
            public string Key { get; set; }
            public NestedLikeFSharp Nested1 { get; set; }
            public NestedLikeFSharp Nested2 { get; set; }
            
        }

        [Fact]
        public void TestCSharpNested()
        {
            var container = new Container
            {
                Key = "key1",
                Nested1 = new Nested
                {
                    A = "n1a",
                    B = "n1b"
                },
                Nested2 = new Nested
                {
                    A = "n2a",
                    B = "n2b"
                }
            };
            var records = new[] { container };
            Helper.TestContainer(records);
        }
        [Fact]
        public void TestNestedLikeFSharp()
        {
            var container = new ContainerWithFSharpLikeNested
            {
                Key = "key1",
                Nested1 = new NestedLikeFSharp("n1a", "n1b"),
                Nested2 = new NestedLikeFSharp("n2a", "n2b")
            };
            var records = new[] { container };
            Helper.TestContainer(records);
        }
    }
}