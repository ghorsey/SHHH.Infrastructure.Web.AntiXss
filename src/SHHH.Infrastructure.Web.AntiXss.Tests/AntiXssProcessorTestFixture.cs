namespace SHHH.Infrastructure.Web.AntiXss.Tests
{
    using System;

    using NUnit.Framework;

    /// <summary>
    /// The test fixture for the <see cref="IAntiXssProcessor"/> object
    /// </summary>
    [TestFixture]
    public class AntiXssProcessorTestFixture
    {
        /// <summary>
        /// Tests the process object method.
        /// </summary>
        [Test]
        public void TestProcessObjectMethod()
        {
            IAntiXssProcessor processor = new AntiXssProcessor();

            var testObject = new SampleTestObject
                             {
                                 IntProperty = 23,
                                 ObjectField = Guid.NewGuid(),
                                 StringField =
                                     "string <script>alert('boo!');</script> with some potentially dangerous code",
                                 StringProperty =
                                     "<a href='#' onclick='alert(\"ooo\")'>A link with some potentially dangerous code</a>"
                             };

            processor.ProcessObject(testObject);

            Assert.AreEqual(23, testObject.IntProperty);
            Assert.IsNotNull(testObject.ObjectField);
            Assert.AreEqual(
                "string <script>alert('boo!');</script> with some potentially dangerous code",
                testObject.StringField);
            Assert.AreEqual("<a href='#'>A link with some potentially dangerous code</a>", testObject.StringProperty);
        }
        
    }
}
