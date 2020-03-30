using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ecommerce.Model;
using System.Net;
using System.Xml.Linq;

namespace ecommerce.Controllers
{
    [Route("/api/haha/[controller]")]
    [ApiController]
    public class ValidateController : ControllerBase
    {
        // GET: api/Validate
        [HttpGet]
        public IEnumerable<Address> Get()
        {
            List<Address> addresses = new List<Address>();
            // address need to validdate
            XDocument requestDoc = new XDocument(
                new XElement("AddressValidateRequest",
                    new XAttribute("USERID", "798STUDE0649"),
                    new XElement("Revision", "1"),
                    new XElement("Address",
                        new XAttribute("ID", "0"),
                        new XElement("Address1", "8200 broadway"),
                        new XElement("Address2", "apt 711N"),
                        new XElement("City", "Houston"),
                        new XElement("State", "tx"),
                        new XElement("Zip5", ""),
                        new XElement("Zip4", "")
                    )
                )
            );
            try
            {

                var usps_url = "http://production.shippingapis.com/ShippingAPI.dll?API=Verify&XML=" + requestDoc;
                var client = new WebClient();
                var response = client.DownloadString(usps_url);

                var xdoc = XDocument.Parse(response.ToString());
                Console.WriteLine(xdoc.ToString());
                foreach (XElement element in xdoc.Descendants("Address"))
                {
                    addresses.Add(
                        new Address()
                        {
                            Name = "thuy",
                            Address1 = "Address1:	" + GetXMLElement(element, "Address2"),
                            Address2 = "Address2:	" + GetXMLElement(element, "Address1"),
                            City = "City:		" + GetXMLElement(element, "City"),
                            State = "State:		" + GetXMLElement(element, "State"),
                            Zip5 = "Zip5: " + GetXMLElement(element, "Zip5"),
                            Zip4 = "Zip4: " + GetXMLElement(element, "Zip4")
                        }
                    );             
                }
            }
            catch (WebException e)
            {
                Console.WriteLine(e.ToString());
            }

            return addresses;

            //
            static string GetXMLElement(XElement element, string name)
            {
                var el = element.Element(name);
                if (el != null)
                {
                    return el.Value;
                }
                return "";
            }

            static string GetXMLAttribute(XElement element, string name)
            {
                var el = element.Attribute(name);
                if (el != null)
                {
                    return el.Value;
                }
                return "";
            }


        }

        // GET: api/Validate/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Validate
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Validate/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
