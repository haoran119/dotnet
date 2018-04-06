using System;
using Xunit;
using Moq;

namespace XUnitTestProjectMoq
{
    // Assumptions:

    public interface IFoo
    {
        Bar Bar { get; set; }
        string Name { get; set; }
        int Value { get; set; }
        bool DoSomething(string value);
        bool DoSomething(int number, string value);
        string DoSomethingStringy(string value);
        bool TryParse(string value, out string outputValue);
        bool Submit(ref Bar bar);
        int GetCount();
        bool Add(int value);
    }

    public class Bar
    {
        public virtual Baz Baz { get; set; }
        public virtual bool Submit() { return false; }
    }

    public class Baz
    {
        public virtual string Name { get; set; }
    }

    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            // lazy evaluating return value
            var mock = new Mock<IFoo>();
            var count = 1;
            mock.Setup(foo => foo.GetCount()).Returns(() => count);

            //Console.WriteLine(mock.Object.GetCount());

            Assert.Equal(1, mock.Object.GetCount());
        }

        [Fact]
        public void Test2()
        {
            // returning different values on each invocation
            var mock = new Mock<IFoo>();
            var calls = 0;
            mock.Setup(foo => foo.GetCount())
                .Returns(() => calls)
                .Callback(() => calls++);

            // returns 0 on first invocation, 1 on the next, and so on
            //Console.WriteLine(mock.Object.GetCount());

            Assert.Equal(0, mock.Object.GetCount());
        }
    }
}
