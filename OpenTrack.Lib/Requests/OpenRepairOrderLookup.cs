using System;
using System.Xml.Linq;

namespace OpenTrack.Requests
{
    /// <summary>
    /// A request for the open repair orders listed in the DMS.
    /// </summary>
    public class OpenRepairOrderLookup : IRequest<OpenTrack.Responses.OpenRepairOrderLookupResponse>
    {
        public OpenRepairOrderLookup(String EnterpriseCode, String DealerCode)
            : base(EnterpriseCode, DealerCode)
        {
        }

        public OpenRepairOrderLookup(String EnterpriseCode, String DealerCode, String ServerName)
            : base(EnterpriseCode, DealerCode, ServerName)
        {
        }

        public String RepairOrderNumber { get; set; }

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

        public String CustomerNumber { get; set; }

        public String CustomerName { get; set; }

        public String TagNumber { get; set; }

        public Boolean InternalOnly { get; set; }

        public DateTime? CreatedDateTimeStart { get; set; }

        public DateTime? CreatedDateTimeEnd { get; set; }

        public DateTime? ModifiedAfter { get; set; }

        internal override XElement Elements
        {
            get
            {
                return new XElement("OpenRepairOrderLookup",
                    this.Dealer,
                    new XElement("LookupParms",
                        new XElement("RepairOrderNumber", this.RepairOrderNumber),
                        new XElement("VIN", this.VIN),
                        new XElement("StockNumber", this.StockNumber),
                        new XElement("CustomerNumber", this.CustomerNumber),
                        new XElement("CustomerName", this.CustomerName),
                        new XElement("TagNumber", this.TagNumber),
                        new XElement("InternalOnly", this.InternalOnly ? "Y" : "N"),
                        new XElement("CreatedDateTimeStart", this.CreatedDateTimeStart.HasValue ? this.CreatedDateTimeStart.Value.ToString(DateTimeBracketFormat) : null),
                        new XElement("CreatedDateTimeEnd", this.CreatedDateTimeEnd.HasValue ? this.CreatedDateTimeEnd.Value.ToString(DateTimeBracketFormat) : null),
                        new XElement("ModifiedAfter", this.ModifiedAfter.HasValue ? this.ModifiedAfter.Value.ToString(DateTimeBracketFormat) : null)
                        )
                    );
            }
        }
    }
}