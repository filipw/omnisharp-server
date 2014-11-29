using NUnit.Framework;
using Should;

namespace OmniSharp.Tests.ImplementInterface
{
    [TestFixture]
    public class ImplementInterfaceTests
    {
        private string buffer = @"
namespace ConsoleApplication
{
    class Foo : IFoo {
    }

    interface IFoo 
    {
        void Hi();
    	string Bar {get; }
    }
}
";

        [Test]
        public void Should_implement_interface_from_right_location()
        {
            var response = buffer.GetImplementInterfaceResponse(line: 4, column: 19);
            response.Buffer.ShouldEqual(@"
namespace ConsoleApplication
{
    class Foo : IFoo {
    #region IFoo implementation
    public void Hi()
    {
        throw new System.NotImplementedException();
    }
    public string Bar
    {
        get
        {
            throw new System.NotImplementedException();
        }
    }
    #endregion
    }

    interface IFoo 
    {
        void Hi();
    	string Bar {get; }
    }
}
");
            response.ImplementedSuccessfully.ShouldBeTrue();
        }

        [Test]
        public void Should_not_implement_interface_from_incorrect_location()
        {
            var response = buffer.GetImplementInterfaceResponse(line: 1, column: 1);
            response.Buffer.ShouldEqual(buffer);
            response.ImplementedSuccessfully.ShouldBeFalse();
        }
    }
}