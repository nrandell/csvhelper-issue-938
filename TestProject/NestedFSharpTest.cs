using Xunit;

namespace TestProject
{
    public class NestedFSharpTest {

        [Fact]
        public void TestFSharpNested() {
            Helper.TestContainer(FSharpRecords.records);

        }
    }
}