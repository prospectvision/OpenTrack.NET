using System;
using System.Xml.Linq;

namespace OpenTrack.Requests
{
    /// <summary>
    /// The ClosedRepairOrderLookup request is used to get a single repair order or a set of repair orders by VIN number or customer number.
    /// </summary>
    [Obsolete("This method is being phased out")]
    public class GetClosedRepairOrderRequest : IRequest<OpenTrack.Responses.ClosedRepairOrderLookupResponse>
    {
        public GetClosedRepairOrderRequest(String EnterpriseCode, String DealerCode)
            : base(EnterpriseCode, DealerCode)
        {
        }

        public GetClosedRepairOrderRequest(String EnterpriseCode, String DealerCode, String ServerName)
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

        public String CustomerNumber { get; set; }

        /// <summary>
        /// When you use the daily request search parm you will get all of the closed repair orders on a specified day.
        /// The parm accepts zero or a positive integer. 0 will return today’s closed repair orders on inventory vehicles,
        /// 1 will return yesterdays, 2 will return current date – 2 days, etc.
        /// </summary>
        public String DailyRequest { get; set; }

        public DateTime? CreatedDateTimeStart { get; set; }

        public DateTime? CreatedDateTimeEnd { get; set; }

        public DateTime? FinalCloseDateStart { get; set; }

        public DateTime? FinalCloseDateEnd { get; set; }

        internal override XElement Elements
        {
            get
            {
                return new XElement("ClosedRepairOrderLookup",
                    this.Dealer,
                    new XElement("LookupParms",
                        new XElement("RepairOrderNumber", this.RepairOrderNumber),
                        new XElement("VIN", this.VIN),
                        new XElement("CustomerNumber", this.CustomerNumber),
                        new XElement("DailyRequest", this.DailyRequest),
                        new XElement("CreatedDateTimeStart", this.CreatedDateTimeStart.HasValue ? this.CreatedDateTimeStart.Value.ToString(DateTimeBracketFormat) : null),
                        new XElement("CreatedDateTimeEnd", this.CreatedDateTimeEnd.HasValue ? this.CreatedDateTimeEnd.Value.ToString(DateTimeBracketFormat) : null),
                        new XElement("FinalCloseDateStart", this.FinalCloseDateStart.HasValue ? this.FinalCloseDateStart.Value.ToString(DateTimeBracketFormat) : null),
                        new XElement("FinalCloseDateEnd", this.FinalCloseDateEnd.HasValue ? this.FinalCloseDateEnd.Value.ToString(DateTimeBracketFormat) : null)
                        )
                    );
            }
        }
    }
}