using System;
using System.Xml.Linq;

namespace OpenTrack.Requests
{
    /// <summary>
    /// The VehicleLookup request is used to get a specific vehicle record from the DMS vehicle database or as part of the process for the VehicleUpdate request.
    /// The VehicleSearch request returns a list of truncated records from the DMS vehicle database with a VIN for each record.
    /// Use the VehicleLookup request with the VIN to obtain the entire vehicle record.
    /// </summary>
    public class VehicleSearchRequest : IRequest<OpenTrack.Responses.VehicleSearchResponse>
    {
        public VehicleSearchRequest(String EnterpriseCode, String DealerCode)
            : base(EnterpriseCode, DealerCode)
        {
        }

        public VehicleSearchRequest(String EnterpriseCode, String DealerCode, String ServerName)
            : base(EnterpriseCode, DealerCode, ServerName)
        {
        }

        private string _vin;
        public String VIN
        {
            get
            {
                return (this._vin ?? "").Trim().ToUpper();
            }
            set
            {
                this._vin = (value ?? "").Trim().ToUpper();
            }
        }

        public String LastSixOfVIN { get; set; }

        public String StockNumber { get; set; }

        public String Make { get; set; }

        public String Model { get; set; }

        public String ModelYear { get; set; }

        public String Type { get; set; }

        public String StockDateStart { get; set; }

        public String StockDateEnd { get; set; }

        public String InspectionMonth { get; set; }

        public String DeliveredDateStart { get; set; }

        public String DeliveredDateEnd { get; set; }

        public String InServiceDateStart { get; set; }

        public String InServiceDateEnd { get; set; }

        public String LastServiceDateStart { get; set; }

        public String LastServiceDateEnd { get; set; }

        internal override XElement Elements
        {
            get
            {
                return new XElement("VehicleSearch",
                    this.Dealer,
                    new XElement("SearchParms",
                        new XElement("VIN", this.VIN),
                        new XElement("LastSixOfVIN", this.LastSixOfVIN),
                        new XElement("StockNumber", this.StockNumber),
                        new XElement("Make", this.Make),
                        new XElement("Model", this.Model),
                        new XElement("ModelYear", this.ModelYear),
                        new XElement("Type", this.Type),
                        new XElement("StockDateStart", this.StockDateStart),
                        new XElement("StockDateEnd", this.StockDateEnd),
                        new XElement("InspectionMonth", this.InspectionMonth),
                        new XElement("DeliveredDateStart", this.DeliveredDateStart),
                        new XElement("DeliveredDateEnd", this.DeliveredDateEnd),
                        new XElement("InServiceDateStart", this.InServiceDateStart),
                        new XElement("InServiceDateEnd", this.InServiceDateEnd),
                        new XElement("LastServiceDateStart", this.LastServiceDateStart),
                        new XElement("LastServiceDateEnd", this.LastServiceDateEnd)
                        )
                    );
            }
        }
    }
}