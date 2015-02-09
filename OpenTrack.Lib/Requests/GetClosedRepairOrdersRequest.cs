using System;

namespace OpenTrack.Requests
{
    /// <summary>
    /// Use this request to get closed repair order header information.
    /// </summary>
    public class GetClosedRepairOrdersRequest : IRequest
    {
        public GetClosedRepairOrdersRequest(String EnterpriseCode, String DealerCode)
            : base(EnterpriseCode, DealerCode)
        {
        }

        public GetClosedRepairOrdersRequest(String EnterpriseCode, String DealerCode, String ServerName)
            : base(EnterpriseCode, DealerCode, ServerName)
        {
        }

        public string RepairOrderNumber { get; set; }

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

        public int CustomerNumber { get; set; }

        public DateTime? CloseDate { get; set; }

        public DateTime? CreatedDateTimeStart { get; set; }

        public DateTime? CreatedDateTimeEnd { get; set; }

        public DateTime? FinalCloseDateStart { get; set; }

        public DateTime? FinalCloseDateEnd { get; set; }

        internal virtual ServiceAPI.GetClosedRepairOrdersRequest Request
        {
            get
            {
                return new ServiceAPI.GetClosedRepairOrdersRequest
                {
                    CloseDate = this.CloseDate,
                    RepairOrderNumber = this.RepairOrderNumber,
                    VIN = this.VIN,
                    CustomerNumber = this.CustomerNumber,
                    CreatedDateTimeStart = this.CreatedDateTimeStart,
                    CreatedDateTimeEnd = this.CreatedDateTimeEnd,
                    FinalCloseDateStart = this.FinalCloseDateStart,
                    FinalCloseDateEnd = this.FinalCloseDateEnd ?? DateTime.MinValue
                };
            }
        }
    }
}