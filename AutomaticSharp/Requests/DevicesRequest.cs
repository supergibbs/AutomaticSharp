using System.Collections.Generic;

namespace AutomaticSharp.Requests
{
    public class DevicesRequest : RequestWithPaging
    {
      public string UserId { get; set; }

      public string SerialNumber { get; set; }
        
      public override Dictionary<string, string> CreateParameters()
        {
            var parameters = base.CreateParameters();

            if (string.IsNullOrEmpty(SerialNumber))
                parameters.Add("device__serial_number", SerialNumber);

            return parameters;
        }
    }
}
