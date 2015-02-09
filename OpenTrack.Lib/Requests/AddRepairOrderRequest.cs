using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace OpenTrack.Requests
{
    public class AddRepairOrderRequest : IRequest<OpenTrack.Responses.AddRepairOrderResponse>
    {
        public AddRepairOrderRequest(String EnterpriseCode, String DealerCode)
            : base(EnterpriseCode, DealerCode)
        {
        }

        public AddRepairOrderRequest(String EnterpriseCode, String DealerCode, String ServerName)
            : base(EnterpriseCode, DealerCode, ServerName)
        {
        }

        public RepairOrder RO { get; set; }

        internal override XElement Elements
        {
            get
            {
                return new XElement("AddRepairOrder",
                    this.Dealer,
                    SerializeToXml<RepairOrder>(this.RO)
                    );
            }
        }
    }

    public class AddRepairOrderLinesRequest : IRequest<OpenTrack.Responses.AddRepairOrderLinesResponse>
    {
        public AddRepairOrderLinesRequest(String EnterpriseCode, String DealerCode)
            : base(EnterpriseCode, DealerCode)
        {
            this.LineItems = new List<LineItem>();
        }

        public AddRepairOrderLinesRequest(String EnterpriseCode, String DealerCode, String ServerName)
            : base(EnterpriseCode, DealerCode, ServerName)
        {
            this.LineItems = new List<LineItem>();
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

        public String ServiceWriterID { get; set; }

        public IEnumerable<LineItem> LineItems { get; set; }

        internal override XElement Elements
        {
            get
            {
                return new XElement("AddRepairOrderLines",
                    this.Dealer,
                    new XElement("RepairOrderNumber", this.RepairOrderNumber),
                    new XElement("VIN", this.VIN),
                    new XElement("CustomerNumber", this.CustomerNumber),
                    new XElement("ServiceWriterID", this.ServiceWriterID),
                    new XElement("LineItems", this.LineItems.Select(i =>
                        new XElement("LineItem",
                            new XElement("LaborOpCode", i.LaborOpCode),
                            new XElement("ServiceLineNumber", i.ServiceLineNumber),
                            new XElement("LineType", i.LineType),
                            new XElement("TransCode", i.TransCode),
                            new XElement("Comments", i.Comments),
                            new XElement("LineStatus", i.LineStatus),
                            new XElement("ServiceType", i.ServiceType)
                            )
                            )
                        )
                    );
            }
        }
    }

    public class RepairOrder
    {
        private string _vin;

        /// <summary>
        /// The VIN to be decoded
        /// </summary>
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

        /// <summary>
        /// The odometer value before the RO
        /// </summary>
        public String OdometerIn { get; set; }

        /// <summary>
        /// A unique identifier for a previously created customer. If this is a new customer, use the
        /// CustomerAdd method before adding the repair order.
        /// </summary>
        public String CustomerNumber { get; set; }

        /// <summary>
        /// The service writer who entered the line item. NOTE: Use the ServiceWritersTable Request to determine the list of active service writers.
        /// </summary>
        public String ServiceWriterID { get; set; }

        /// <summary>
        /// The date & time of the forecasted repair order completion. Must be greater than the current Date and Time.
        /// If no PromisedDateTime tag is sent in repair order will be created as a waiter.
        /// </summary>
        public String PromisedDateTime { get; set; }

        /// <summary>
        /// Tag Number
        /// </summary>
        public String TagNumber { get; set; }

        /// <summary>
        /// The individual line item details (can be multiple)
        /// </summary>
        public List<LineItem> LineItems { get; set; }

        public RepairOrder()
        {
            this.LineItems = new List<LineItem>();
        }
    }

    public class LineItem
    {
        /// <summary>
        /// The labor operation code. Use the ServiceLaborOpcodesTable request to obtain the current list of code.
        /// “*” can be used for undefined. If "*" undefined used then <Comments> tag is required.
        /// </summary>
        public String LaborOpCode { get; set; }

        /// <summary>
        /// The line number this detail refers to. LineItems are grouped together by ServiceLineNumber.
        /// </summary>
        public String ServiceLineNumber { get; set; }

        /// <summary>
        /// The line item type. Valid options include: A = Labor op code line desc, also used for adding comments to a service line. P = Parts
        /// </summary>
        public String LineType { get; set; }

        /// <summary>
        /// The transaction code. Valid options include: CP=Customer Pay, IS=RO Internal Sale, WS=Warranty Service
        /// </summary>
        public String TransCode { get; set; }

        /// <summary>
        /// The line item description/comments. To add multiple comments (up to five) use duplicate LineItems with
        /// 'A' LineType and the same ServiceLineNumber, TransCode, ServiceType, & LaborOpCode.
        /// </summary>
        public String Comments { get; set; }

        /// <summary>
        /// The line status code. Valid options include: I = Unassigned, C = Complete
        /// </summary>
        public String LineStatus { get; set; }

        /// <summary>
        /// The service type. Valid options include: MR = Mechanical Repair (This currently is the only supported type. Others may be added later.)
        /// </summary>
        public String ServiceType { get; set; }

        /// <summary>
        /// Labor Rate Estimate Override
        /// </summary>
        public String OverrideLaborRate { get; set; }

        /// <summary>
        /// Details about the individual part added. Only used for LineType Part(P).
        /// </summary>
        public Part Part { get; set; }

        /// <summary>
        /// The parts counter person associated with this line item. Required for LineType Part(P), Parts line.
        /// Only used for LineType Part(P). NOTE: Use the PartsCounterPersonTableRequest to determine the list of active counter persons.
        /// </summary>
        public String CounterPersonID { get; set; }
    }

    public class Part
    {
        /// <summary>
        /// The Part number
        /// </summary>
        public String PartNumber { get; set; }

        /// <summary>
        /// The manufacturer of the part. Use the PartsManufacturersTableRequest method to obtain the current list of manufacturer codes.
        /// </summary>
        public String Manufacturer { get; set; }

        /// <summary>
        /// The quantity of this part
        /// </summary>
        public int Quantity { get; set; }
    }
}