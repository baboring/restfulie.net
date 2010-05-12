﻿using System.Collections.Generic;
using NUnit.Framework;
using Restfulie.Server.Marshalling.Serializers;
using Restfulie.Server.Tests.Fixtures;

namespace Restfulie.Server.Tests.Marshalling.Serializers
{
    [TestFixture]
    public class XmlAndHypermediaSerializerTests
    {
        private XmlAndHypermediaSerializer serializer;

        [SetUp]
        public void SetUp()
        {
            serializer = new XmlAndHypermediaSerializer();   
        }

        [Test]
        public void ShouldSerializeAllDataInResource()
        {
            var resource = new SomeResource {Amount = 123.45, Name = "John Doe"};
            
            var xml = serializer.Serialize(resource, new List<Transition>());

            Assert.That(xml.Contains("<Name>John Doe</Name>"));
            Assert.That(xml.Contains("<Amount>123.45</Amount>"));
        }
        
        [Test]
        public void ShouldSerializeAllTransitions()
        {
            var resource = new SomeResource { Amount = 123.45, Name = "John Doe" };

            var xml = serializer.Serialize(resource,
                                           new List<Transition> { new Transition("pay", "controller", "action", "http://some/url") });

            Assert.That(xml.Contains("rel=\"pay\""));
            Assert.That(xml.Contains("<atom:link"));
            Assert.That(xml.Contains("http://some/url")); 
        }
    }
}