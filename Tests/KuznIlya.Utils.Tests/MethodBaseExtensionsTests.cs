using System;
using System.Reflection;
using NUnit.Framework;

namespace KuznIlya.Utils.Tests
{
    [TestFixture]
    public class MethodBaseExtensionsTests
    {
        [Test]
        public void InvokeAndHoistBaseExceptionTest()
        {
            var methodInfo = GetType().GetMethod(nameof(ThrowException), BindingFlags.NonPublic | BindingFlags.Static);
            Assert.Throws(Is.TypeOf<ArgumentException>(), () => methodInfo.InvokeAndHoistBaseException(null));
        }

        [Test]
        public void InvokeAndHoistBaseExceptionGenericResultTest()
        {
            var methodInfo = GetType().GetMethod(nameof(ThrowException), BindingFlags.NonPublic | BindingFlags.Static);
            Assert.Throws(Is.TypeOf<ArgumentException>(), () => methodInfo.InvokeAndHoistBaseException<int>(null));
        }

        private static int ThrowException()
        {
            throw new ArgumentException();
        }
    }
}
