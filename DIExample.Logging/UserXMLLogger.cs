using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.IO;

using DIExample.Business;

namespace DIExample.Logging
{
    public class UserXMLLogger : IUserLogger
    {
        public void Log(User user)
        {
            XmlDocument doc = new XmlDocument();
            if(!File.Exists("user_log.xml"))
            {
                doc.AppendChild(doc.CreateElement("users"));
                doc.Save("user_log.xml");
            }
            doc.Load("user_log.xml");
            var userNode = doc.CreateElement("user");
            var nameAttribute = doc.CreateAttribute("name");
            nameAttribute.Value = user.UserName;
            userNode.Attributes.Append(nameAttribute);

            var emailAttribute = doc.CreateAttribute("email");
            emailAttribute.Value = user.Email;
            userNode.Attributes.Append(emailAttribute);

            doc.DocumentElement.AppendChild(userNode);
            doc.Save(@"user_log.xml");

        }
    }
}
