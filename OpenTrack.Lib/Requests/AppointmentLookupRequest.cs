using System;
using System.Xml.Linq;

namespace OpenTrack.Requests
{
    /// <summary>
    /// The AppointmentLookup request is used to retrieve appointment information from the Service Department application.
    /// With the AppointmentLookup request, you can request appointments by appointment number, VIN, stock number, customer name, and or date range.
    /// If you remove all of the search parameters, the AppointmentLookup request will return the entire appointment list.
    /// </summary>
    public class AppointmentLookupRequest : IRequest<OpenTrack.Responses.AppointmentLookupResponse>
    {
        public AppointmentLookupRequest(String EnterpriseCode, String DealerCode)
            : base(EnterpriseCode, DealerCode)
        {
        }

        public AppointmentLookupRequest(String EnterpriseCode, String DealerCode, String ServerName)
            : base(EnterpriseCode, DealerCode, ServerName)
        {
        }

        public String AppointmentNumber { get; set; }

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

        public String StockNumber { get; set; }

        public String CustomerName { get; set; }

        public DateTime? DateFrom { get; set; }

        public DateTime? DateTo { get; set; }

        public DateTime? CreatedDateTimeStart { get; set; }

        public DateTime? CreatedDateTimeEnd { get; set; }

        internal override XElement Elements
        {
            get
            {
                return new XElement("AppointmentLookup",
                    this.Dealer,
                    new XElement("LookupParms",
                        new XElement("AppointmentNumber", this.AppointmentNumber),
                        new XElement("VIN", this.VIN),
                        new XElement("StockNumber", this.StockNumber),
                        new XElement("CustomerName", this.CustomerName),
                        new XElement("DateFrom", this.DateFrom.HasValue ? this.DateFrom.Value.ToString(DateFormat) : null),
                        new XElement("DateTo", this.DateTo.HasValue ? this.DateTo.Value.ToString(DateFormat) : null),
                        new XElement("CreatedDateTimeStart", this.CreatedDateTimeStart.HasValue ? this.CreatedDateTimeStart.Value.ToString(DateFormat) : null),
                        new XElement("CreatedDateTimeEnd", this.CreatedDateTimeEnd.HasValue ? this.CreatedDateTimeEnd.Value.ToString(DateFormat) : null)
                        )
                    );
            }
        }
    }
}