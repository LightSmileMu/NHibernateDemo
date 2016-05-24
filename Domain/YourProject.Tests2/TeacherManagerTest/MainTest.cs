using System;
using System.Diagnostics;
using System.Threading;
using NUnit.Framework;

namespace TeacherManagerTest
{
    public class MainTest
    {
        //private  MainFrame _frame;


        [Test]
        [STAThread]
        public void Init()
        {
            Trace.WriteLine(string.Format("Current thread:id = {0}", Thread.CurrentThread.ManagedThreadId));

            //MainFrame _frame = new MainFrame();

            //Assert.False(_frame.Login);
        }

        [Test]
        public void LoginTest()
        {
            Trace.WriteLine(string.Format("Current thread:id = {0}", Thread.CurrentThread.ManagedThreadId));
            //Assert.True(_frame.Login);
        }
    }
}