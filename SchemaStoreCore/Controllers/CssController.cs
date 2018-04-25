using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IO;
using System.Xml;

namespace SchemaStoreCore.Controllers
{
    public class CssController : ControllerBase
    {
        private readonly IHostingEnvironment _env;

        public CssController(IHostingEnvironment env)
        {
            _env = env;
        }

        [HttpGet("/api/css/jsonapi")]
        public IActionResult JsonApi()
        {
            var path = Path.Combine(_env.WebRootPath, "api", "css", "css-main.xml");
            var doc = new XmlDocument();
            doc.Load(path);

            var list = new List<object>();

            foreach (XmlNode node in doc.SelectNodes("//CssModuleRef"))
            {
                string file = node.Attributes["file"].InnerText;
                list.Add(new
                {
                    name = file.Replace("css-module-", "").Replace(".xml", ""),
                    description = "",
                    url = "http://css.schemastore.org/" + file
                });
            }
            var api = new
            {
                version = "1.0",
                schemas = list
            };

            return Ok(api);
        }
    }
}
