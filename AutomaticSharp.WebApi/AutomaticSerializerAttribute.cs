using System;
using System.Linq;
using System.Net.Http.Formatting;
using System.Web.Http.Controllers;
using AutomaticSharp.JsonUtils;
using Newtonsoft.Json;

namespace AutomaticSharp.WebApi
{
    public class AutomaticSerializerAttribute : Attribute, IControllerConfiguration
    {
        public void Initialize(HttpControllerSettings controllerSettings, HttpControllerDescriptor controllerDescriptor)
        {
            var formatters = controllerSettings.Formatters.OfType<JsonMediaTypeFormatter>().ToArray();

            foreach (var jsonMediaTypeFormatter in formatters)
            {
                controllerSettings.Formatters.Remove(jsonMediaTypeFormatter);
            }

            controllerSettings.Formatters.Add(new JsonMediaTypeFormatter
            {
                SerializerSettings = new JsonSerializerSettings
                {
                    ContractResolver = new UnderscorePropertyNamesContractResolver()
                }
            });
        }
    }
}
