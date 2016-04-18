using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using JiraApi.CustomFields;

namespace JiraApi.Tests.CustomFields
{
    [TestClass]
    public class ObjectIdCustomFieldTests
    {
        [TestMethod]
        public void IdIsNotNullTest()
        {
            var id = "12345";
            var value = "";

            var custonfield = new ObjectIdCustomField(id, value);

            Assert.IsNotNull(custonfield.Id);
        }

        [TestMethod]
        public void IdAreEqualTest()
        {
            var id = "12345";
            var value = "";

            var custonfield = new ObjectIdCustomField(id, value);

            Assert.AreEqual(id, custonfield.Id);
        }


        [TestMethod]
        public void FullNameIsNotNullTest()
        {
            var id = "12345";
            var value = "";

            var custonfield = new ObjectIdCustomField(id, value);

            Assert.IsNotNull(custonfield.FullName);
        }

        [TestMethod]
        public void FullNameIsInAppropriateFormatTest()
        {
            var id = "12345";
            var expectedFullName = "customfield_12345";
            var value = "";

            var custonfield = new ObjectIdCustomField(id, value);

            Assert.AreEqual(expectedFullName, custonfield.FullName);
        }

        [TestMethod]
        public void ValueIsNotNullTest()
        {
            var id = "12345";
            var value = "";

            var custonfield = new ObjectIdCustomField(id, value);

            Assert.IsNotNull(custonfield.Value);
        }

        [TestMethod]
        public void ValueSerializedToJsonObectWithEmptyIdProperyTest()
        {
            var id = "12345";
            var value = "";
            var expected = "{\"id\":\"\"}";

            var custonfield = new ObjectIdCustomField(id, value);

            Assert.AreEqual(expected, custonfield.Value);
        }

        [TestMethod]
        public void ValueSerializedToJsonObectWithIdProperyTest()
        {
            var id = "12345";
            var value = "some_value";
            var expected = "{\"id\":\"some_value\"}";

            var custonfield = new ObjectIdCustomField(id, value);

            Assert.AreEqual(expected, custonfield.Value);
        }

        [TestMethod]
        public void ToStringTest()
        {
            var id = "12345";
            var value = "some_value";
            var expected = "\"customfield_12345\":{\"id\":\"some_value\"}";

            var custonfield = new ObjectIdCustomField(id, value);

            Assert.AreEqual(expected, custonfield.ToString());
        }
    }
}
