using SplitStringLib;

namespace SplitStringTest
{
    [TestClass]
    public class StringSplitTest1
    {        
        [TestMethod]
        public void TestStringSplitJoinVersion()
        {
            TestImp( WaysOfSplitString.StringSplitJoinVersion);            
        }

        [TestMethod]
        public void TestSpanRangeVersion()
        {
            TestImp(WaysOfSplitString.SpanRangeVersion);
        }

        [TestMethod]
        public void TestSpanVersion()
        {
            TestImp(WaysOfSplitString.SpanVersion);
        }


        private void TestImp(Action<string> imp)
        {
            StringWriter consoleOut = new StringWriter();
            Console.SetOut(consoleOut);
            imp("A web application that generates random text that you can use   in Sample web pages or  typography samples.");

            var written = consoleOut.ToString();

            Assert.AreEqual("samples. typography or pages web Sample in use can you that text random generates that application web A" + Environment.NewLine, written);
            consoleOut.Close();
        }
    }
}