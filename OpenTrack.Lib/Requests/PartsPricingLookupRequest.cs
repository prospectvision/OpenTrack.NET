using System;
using System.Collections.Generic;
using System.Linq;

namespace OpenTrack.Requests
{
    public class PartsPricingLookupRequest : IRequest
    {
        public int? CustomerKey { get; set; }

        public int? PriceLevel { get; set; }

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

        public IEnumerable<PartsAPI.PartsPricingLookupRequestPartType> Parts { get; set; }

        public PartsPricingLookupRequest(String EnterpriseCode, String DealerCode)
            : base(EnterpriseCode, DealerCode)
        {
            this.Parts = Enumerable.Empty<PartsAPI.PartsPricingLookupRequestPartType>();
        }

        public PartsPricingLookupRequest(String EnterpriseCode, String DealerCode, String ServerName)
            : base(EnterpriseCode, DealerCode, ServerName)
        {
            this.Parts = Enumerable.Empty<PartsAPI.PartsPricingLookupRequestPartType>();
        }

        internal virtual PartsAPI.PartsPricingLookupRequestLookupType Request
        {
            get
            {
                return new OpenTrack.PartsAPI.PartsPricingLookupRequestLookupType
                {
                    CustomerKey = this.CustomerKey,
                    PriceLevel = this.PriceLevel,
                    VIN = this.VIN,
                    Parts = this.Parts.ToArray()
                };
            }
        }
    }
}