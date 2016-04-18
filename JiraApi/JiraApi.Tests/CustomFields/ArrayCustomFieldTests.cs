using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using JiraApi.CustomFields;

namespace JiraApi.Tests.CustomFields
{
    [TestClass]
    public class ArrayCustomFieldTests
    {
        [TestMethod]
        public void IdIsNotNullTest()
        {
            var id = "12345";
            var value = new string[0];

            var custonfield = new ArrayCustomField(id, value);

            Assert.IsNotNull(custonfield.Id);
        }

        [TestMethod]
        public void IdAreEqualTest()
        {
            var id = "12345";
            var value = new string[0];

            var custonfield = new ArrayCustomField(id, value);

            Assert.AreEqual(id, custonfield.Id);
        }


        [TestMethod]
        public void FullNameIsNotNullTest()
        {
            var id = "12345";
            var value = new string[0];

            var custonfield = new ArrayCustomField(id, value);

            Assert.IsNotNull(custonfield.FullName);
        }

        [TestMethod]
        public void FullNameIsInAppropriateFormatTest()
        {
            var id = "12345";
            var expectedFullName = "customfield_12345";
            var value = new string[0];

            var custonfield = new ArrayCustomField(id, value);

            Assert.AreEqual(expectedFullName, custonfield.FullName);
        }

        [TestMethod]
        public void ValueIsNotNullTest()
        {
            var id = "12345";
            var value = new string[0];

            var custonfield = new ArrayCustomField(id, value);

            Assert.IsNotNull(custonfield.Value);
        }
        
        [TestMethod]
        public void ValueSerializedToEmptyJsonArrayTest()
        {
            var id = "12345";
            var value = new string[0];
            var expected = "[]";

            var custonfield = new ArrayCustomField(id, value);

            Assert.AreEqual(expected, custonfield.Value);
        }

        [TestMethod]
        public void ValueSerializedToJsonArrayTest()
        {
            var id = "12345";
            var value = new[] { "val1", "val2", "val3" };
            var expected = "[\"val1\",\"val2\",\"val3\"]";

            var custonfield = new ArrayCustomField(id, value);

            Assert.AreEqual(expected, custonfield.Value);
        }

        [TestMethod]
        public void ToStringTest()
        {
            var id = "12345";
            var value = new[] { "val1", "val2", "val3" };
            var expected = "\"customfield_12345\":[\"val1\",\"val2\",\"val3\"]";

            var custonfield = new ArrayCustomField(id, value);

            Assert.AreEqual(expected, custonfield.ToString());
        }


    }
}
