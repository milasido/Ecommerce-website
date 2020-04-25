using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ecommerce.Dtos;
using ecommerce.Model;
using System.Xml.Linq;
using System.Net;

namespace ecommerce.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ValidateController : ControllerBase
    {
        [HttpPost("validate")]
        public IActionResult Validate(AddressToValidate addressToValidate)
        {
            AddressToValidate result = new AddressToValidate();
            XDocument requestDoc = new XDocument(
                new XElement("AddressValidateRequest",
                    new XAttribute("USERID", "798STUDE0649"), // userid from USPS api reristered
                    new XElement("Revision", "1"),
                    new XElement("Address",
                        new XAttribute("ID", "0"),
                        new XElement("Address1", addressToValidate.Address1),
                        new XElement("Address2", addressToValidate.Address2),
                        new XElement("City", addressToValidate.City),
                        new XElement("State", addressToValidate.State),
                        new XElement("Zip5", addressToValidate.Zip5),
                        new XElement("Zip4", addressToValidate.Zip4)
                    )
                )
            );
            try
            {
                var usps_api_url = "http://production.shippingapis.com/ShippingAPI.dll?API=Verify&XML=" + requestDoc;
                var client = new WebClient();
                var response = client.DownloadString(usps_api_url);
                var xdoc = XDocument.Parse(response.ToString());
                foreach (XElement element in xdoc.Descendants("Address"))
                {
                    result.Name = addressToValidate.Name.ToUpper();
                    result.Address1 = GetXMLElement(element, "Address2");
                    result.Address2 = GetXMLElement(element, "Address1");
                    result.City = GetXMLElement(element, "City");
                    result.State = GetXMLElement(element, "State");
                    result.Zip5 = GetXMLElement(element, "Zip5");
                    result.Zip4 = GetXMLElement(element, "Zip4");                                      
                }
            }
            catch (WebException e)
            {
                Console.WriteLine(e.ToString());
            }
            return Ok(result);

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

        }
    }
}