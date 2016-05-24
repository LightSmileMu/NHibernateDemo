using System;
using System.Collections.Generic;
using MathDemo;
using NUnit.Framework;
using Xunit.Extensions;
using Assert = Xunit.Assert;

namespace MathDemoTest
{
    public class Class1
    {
        private readonly Form1 _form1;

        public Class1()
        {
            _form1 = new Form1();
        }

        [Xunit.Extensions.Theory(DisplayName = "求和测试")]
        [InlineData(1, 1, 2)]
        [InlineData(1, 2, 3)]
        [InlineData(1, 1, 3)]
        public void SumTest(int a,int b,int result)
        {
            Assert.Equal(result, _form1.Sum(a,b));
        }

        [Test]
        public void MyListTest()
        {
            var list = new MyList<int>();
            list.OnAdded += (sender, args) =>
            {
                var itemArgs = args as ItemAddedEventArgs<int>;
                if (itemArgs != null)
                {
                    Console.WriteLine(@"Item {0} is added!", itemArgs.Item);
                }
            };

            list.Add(1);
            list.Add(2);
            list.Add(3);
        }

        private void TupleTest()
        {
            Tuple<int,int> tuple = new Tuple<int, int>(1,2);

        }

        [Test]
        public void PersonTest()
        {
            var person = new Person();

            dynamic staticPerson = new Person();

            //person.GetFullName("John", "Smith");
            staticPerson.GetFullName("John", "Smith");
        }

        public void Dispose()
        {
            //if (_form1 != null)
            //{
            //    _form1.Dispose();
            //    Console.WriteLine("Form is disposed.");
            //}
        }
    }

    public class MyList<T> : List<T>
    {
        public event EventHandler OnAdded;

        private void OnAddedHandler(object sender,EventArgs args)
        {
            if (OnAdded != null)
            {
                OnAdded(sender, args);
            }
        }

        new public void Add(T item)
        {
            OnAddedHandler(this, new ItemAddedEventArgs<T>(item));
            base.Add(item);
        }

    }

    public class ItemAddedEventArgs<T> : EventArgs
    {
        private readonly T _item;

        public ItemAddedEventArgs(T item)
        {
            _item = item;
        }

        /// <summary>
        /// Item
        /// </summary>
        public T Item
        {
            get
            {
                return _item;
            }
        }
    }

    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string GetFullName()
        {
            return string.Concat(FirstName, " ", LastName);
        }
    }
}
