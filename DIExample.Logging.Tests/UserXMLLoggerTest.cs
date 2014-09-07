using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using DIExample.Business;
using System.IO;
using System.Xml;
using DIExample.Logging.Xml;

namespace DIExample.Logging.Tests
{
    [TestFixture]
    public class UserXMLLoggerTest
    {
        [SetUp]
        public void Setup()
        {
            if (File.Exists("user_log.xml"))
            {
                File.Delete("user_log.xml");
            }
        }

        [Test]
        public void xml_file_will_be_created_if_none_exists()
        {
            var logger = new UserXMLLogger();

            var user = new User
            {
                UserName = "Jim",
                Email = "jiim.aho@gmail.com"
            };

            logger.Log(user);

            Assert.That(File.Exists("user_log.xml"));
        }

        [Test]
        public void logging_a_user_will_save_it_to_file()
        {
            var logger = new UserXMLLogger();

            var user = new User
            {
                UserName = "Jim",
                Email = "jiim.aho@gmail.com"
            };

            logger.Log(user);

            Assert.That(File.Exists("user_log.xml"));
            var doc = new XmlDocument();
            doc.Load("user_log.xml");
            XmlNode node = doc.DocumentElement.FirstChild;
            Assert.That(node.Attributes["name"].Value, Is.EqualTo("Jim"));
            Assert.That(node.Attributes["email"].Value, Is.EqualTo("jiim.aho@gmail.com"));
        }
    }
}
