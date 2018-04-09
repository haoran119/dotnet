using System;
using Xunit;
using Moq;
using FluentAssertions;
using System.Text.RegularExpressions;

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
        public void TestMethods()
        {
            var mock = new Mock<IFoo>();

            mock.Setup(foo => foo.DoSomething("ping")).Returns(true);

            Assert.True(mock.Object.DoSomething("ping"));


            // out arguments
            var outString = "ack";
            // TryParse will return true, and the out argument will return "ack", lazy evaluated
            mock.Setup(foo => foo.TryParse("ping", out outString)).Returns(true);

            Assert.True(mock.Object.TryParse("ping", out outString));
            Assert.Equal("ack", outString);


            // ref arguments
            var instance = new Bar();
            // Only matches if the ref argument to the invocation is the same instance
            mock.Setup(foo => foo.Submit(ref instance)).Returns(true);

            Assert.True(mock.Object.Submit(ref instance));


            // access invocation arguments when returning a value
            mock.Setup(x => x.DoSomethingStringy(It.IsAny<string>()))
                    .Returns((string s) => s.ToLower());

            Assert.Equal("test", mock.Object.DoSomethingStringy("TesT"));


            // Multiple parameters overloads available
            // throwing when invoked with specific parameters
            mock.Setup(foo => foo.DoSomething("reset")).Throws<InvalidOperationException>();
            mock.Setup(foo => foo.DoSomething("")).Throws(new ArgumentException("command"));

            Assert.Throws<InvalidOperationException>(() => mock.Object.DoSomething("reset"));
            Assert.Throws<ArgumentException> (() => mock.Object.DoSomething(""));

            // FluentAssertions 
            Action doSomethingIOE = () => mock.Object.DoSomething("reset");
            doSomethingIOE.Should().Throw<InvalidOperationException>();

            Action doSomethingAE = () => mock.Object.DoSomething("");
            doSomethingAE.Should().Throw<ArgumentException>().WithMessage("command");


            // returning different values on each invocation
            var calls = 0;
            mock.Setup(foo => foo.GetCount())
                .Returns(() => calls)
                .Callback(() => calls++);

            // returns 0 on first invocation, 1 on the next, and so on
            Assert.Equal(0, mock.Object.GetCount());

            
            // lazy evaluating return value
            var count = 10;
            mock.Setup(foo => foo.GetCount()).Returns(() => count);

            Assert.Equal(10, mock.Object.GetCount());
        }

        [Fact]
        public void TestMatchingArguments()
        {
            var mock = new Mock<IFoo>();

            // any value
            mock.Setup(foo => foo.DoSomething(It.IsAny<string>())).Returns(true);

            Assert.True(mock.Object.DoSomething("test"));


            // any value passed in a `ref` parameter (requires Moq 4.8 or later):
            mock.Setup(foo => foo.Submit(ref It.Ref<Bar>.IsAny)).Returns(true);

            var _bar = new Bar();

            Assert.True(mock.Object.Submit(ref _bar));


            // matching Func<int>, lazy evaluated
            mock.Setup(foo => foo.Add(It.Is<int>(i => i % 2 == 0))).Returns(true);

            Assert.True(mock.Object.Add(2));
            Assert.False(mock.Object.Add(1));


            // matching ranges
            mock.Setup(foo => foo.Add(It.IsInRange<int>(0, 10, Range.Inclusive))).Returns(true);

            Assert.True(mock.Object.Add(5));
            var result = mock.Object.Add(100);
            Assert.False(result); // ? Why true returned


            // matching regex
            mock.Setup(x => x.DoSomethingStringy(It.IsRegex("[a-d]+", RegexOptions.IgnoreCase))).Returns("foo");

            Assert.Equal("foo", mock.Object.DoSomethingStringy("c"));
            Assert.NotEqual("foo", mock.Object.DoSomethingStringy("z"));
        }

        [Fact]
        public void TestProperties()
        {
            var mock = new Mock<IFoo>();

            mock.Setup(f => f.Name).Returns("bar");

            // Now you can do:

            IFoo foo = mock.Object;

            Assert.Equal("bar", foo.Name);


            // auto-mocking hierarchies (a.k.a. recursive mocks)
            mock.Setup(f => f.Bar.Baz.Name).Returns("baz");

            Assert.Equal("baz", foo.Bar.Baz.Name);


            // expects an invocation to set the value to "foo"
            mock.SetupSet(f => f.Name = "foo");

            foo.Name = "foo";

            // or verify the setter directly
            mock.VerifySet(f => f.Name = "foo");


            // start "tracking" sets/gets to this property
            mock.SetupProperty(f => f.Name);

            // alternatively, provide a default value for the stubbed property
            mock.SetupProperty(f => f.Name, "foo");

            // Initial value was stored
            Assert.Equal("foo", foo.Name);


            // New value set which changes the initial value
            foo.Name = "bar";
            Assert.Equal("bar", foo.Name);


            // Stub all properties on a mock (not available on Silverlight):
            mock.SetupAllProperties();

            // Initial value was stored
            Assert.Null(foo.Name);


            // New value set which changes the initial value
            foo.Name = "test";
            Assert.Equal("test", foo.Name);
        }
    }
}