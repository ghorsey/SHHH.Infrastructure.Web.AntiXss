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
                                     "string <script>alert('boo!');</script> with <b>some potentially</b> dangerous code",
                                 StringProperty =
                                     "<a href='#' onclick='alert(\"ooo\")'>A link with some potentially dangerous code</a>",
                                 AllowUnsafe = "string <script>alert('boo!');</script> with <b>some potentially</b> dangerous code" 
                             };

            processor.ProcessObject(testObject);

            Assert.AreEqual(23, testObject.IntProperty);
            Assert.IsNotNull(testObject.ObjectField);
            Assert.AreEqual(
                "string with <b>some potentially</b> dangerous code",
                testObject.StringField);
            Assert.AreEqual("<a href=\"\">A link with some potentially dangerous code</a>", testObject.StringProperty);

            Assert.AreEqual("This is unsafe", testObject.PrivateSetProperty);
            Assert.AreEqual(
                "string <script>alert('boo!');</script> with <b>some potentially</b> dangerous code",
                testObject.AllowUnsafe);
        }
        
    }
}
