using System;
using Xunit;
using Pets;

namespace NewTypesTests
{
    public class PetTests
    {
        [Fact]
        public void DogTalkToOwnerReturnsWoof()
        {
            string expected = "Woof!";
            string actual = new Dog().TalkToOwner();

//            Assert.NotEqual(expected, actual);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void CatTalkToOwnerReturnsMeow()
        {
            string expected = "Meow!";
            string actual = new Cat().TalkToOwner();

            //            Assert.NotEqual(expected, actual);
            Assert.Equal(expected, actual);
        }
    }
}
