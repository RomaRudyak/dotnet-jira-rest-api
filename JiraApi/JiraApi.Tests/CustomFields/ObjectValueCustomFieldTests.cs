using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using JiraApi.CustomFields;

namespace JiraApi.Tests.CustomFields
{
    [TestClass]
    public class ObjectValueCustomFieldTests
    {
        [TestMethod]
        public void IdIsNotNullTest()
        {
            var id = "12345";
            var value = "";

            var custonfield = new ObjectValueCustomField(id, value);

            Assert.IsNotNull(custonfield.Id);
        }

        [TestMethod]
        public void IdAreEqualTest()
        {
            var id = "12345";
            var value = "";

            var custonfield = new ObjectValueCustomField(id, value);

            Assert.AreEqual(id, custonfield.Id);
        }


        [TestMethod]
        public void FullNameIsNotNullTest()
        {
            var id = "12345";
            var value = "";

            var custonfield = new ObjectValueCustomField(id, value);

            Assert.IsNotNull(custonfield.FullName);
        }

        [TestMethod]
        public void FullNameIsInAppropriateFormatTest()
        {
            var id = "12345";
            var expectedFullName = "customfield_12345";
            var value = "";

            var custonfield = new ObjectValueCustomField(id, value);

            Assert.AreEqual(expectedFullName, custonfield.FullName);
        }

        [TestMethod]
        public void ValueIsNotNullTest()
        {
            var id = "12345";
            var value = "";

            var custonfield = new ObjectValueCustomField(id, value);

            Assert.IsNotNull(custonfield.Value);
        }

        [TestMethod]
        public void ValueSerializedToJsonObectWithEmptyValueProperyTest()
        {
            var id = "12345";
            var value = "";
            var expected = "{\"value\":\"\"}";

            var custonfield = new ObjectValueCustomField(id, value);

            Assert.AreEqual(expected, custonfield.Value);
        }

        [TestMethod]
        public void ValueSerializedToJsonObectWithValueProperyTest()
        {
            var id = "12345";
            var value = "some_value";
            var expected = "{\"value\":\"some_value\"}";

            var custonfield = new ObjectValueCustomField(id, value);

            Assert.AreEqual(expected, custonfield.Value);
        }


        [TestMethod]
        public void ToStringTest()
        {
            var id = "12345";
            var value = "some_value";
            var expected = "\"customfield_12345\":{\"value\":\"some_value\"}";

            var custonfield = new ObjectValueCustomField(id, value);

            Assert.AreEqual(expected, custonfield.ToString());
        }
    }
}
