using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace OpenTrack.Requests
{
    /// <summary>
    /// The AppointmentAdd request is used in connection with the CustomerLookup request: the CustomerLookup request can be used to retrieve a customer key and VIN.
    /// Use the AppointmentAdd request to add an appointment with or without service lines on it.
    /// Once an appointment has been added, you cannot change anything but the appointment date/time and the service writer.
    /// Appointments will not be created if the appointment time falls outside of the hours the dealer has specified that they are open for service.
    /// You can use the AppointmentDelete request to remove an appointment.
    /// </summary>
    public class AppointmentAddRequest : IRequest<OpenTrack.Responses.AppointmentAddResponse>
    {
        /// <summary>
        /// YYYYMMDD format.
        /// </summary>
        public DateTime OpenTransactionDate { get; set; }

        public String CustomerKey { get; set; }

        public String CustomerName { get; set; }

        public String CustomerPhoneNumber { get; set; }

        public String ServiceWriterID { get; set; }

        public Decimal? TotalEstimate { get; set; }

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

        public Boolean Truck { get; set; }

        public String FranchiseCode { get; set; }

        public int? OdometerIn { get; set; }

        /// <summary>
        /// YYYYMMDDTTTT format
        /// </summary>
        public DateTime AppointmentDateTime { get; set; }

        public IList<AppointmentDetail> Details { get; set; }

        public AppointmentAddRequest(String EnterpriseCode, String DealerCode)
            : base(EnterpriseCode, DealerCode)
        {
            this.Details = new List<AppointmentDetail>();
        }

        public AppointmentAddRequest(String EnterpriseCode, String DealerCode, String ServerName)
            : base(EnterpriseCode, DealerCode, ServerName)
        {
            this.Details = new List<AppointmentDetail>();
        }

        internal override XElement Elements
        {
            get
            {
                return new XElement("AppointmentAdd",
                    this.Dealer,
                    new XElement("Appointment",
                        new XElement("CompanyNumber", this.CompanyNumber),
                        new XElement("OpenTransactionDate", this.OpenTransactionDate.ToString("yyyyMMdd")),
                        new XElement("CustomerKey", this.CustomerKey),
                        new XElement("CustomerName", this.CustomerName),
                        new XElement("CustomerPhoneNumber", this.CustomerPhoneNumber),
                        new XElement("ServiceWriterID", this.ServiceWriterID),
                        new XElement("TotalEstimate", this.TotalEstimate),
                        new XElement("VIN", this.VIN),
                        new XElement("StockNumber", this.StockNumber),
                        new XElement("Truck", this.Truck ? "Y" : "N"),
                        new XElement("FranchiseCode", this.FranchiseCode),
                        new XElement("OdometerIn", this.OdometerIn),
                        new XElement("AppointmentDateTime", this.AppointmentDateTime.ToString(AppointmentAddRequest.DateTimeFormat)),
                        new XElement("Details",
                            this.Details.Select(d =>
                                new XElement("AppointmentDetail",
                                    new XElement("ServiceLineNumber", d.ServiceLineNumber),
                                    new XElement("LineType", d.LineType),
                                    new XElement("SequenceNumber", d.SequenceNumber),
                                    new XElement("TransDate", d.TransDate),
                                    new XElement("Comments", d.Comments),
                                    new XElement("ServiceType", d.ServiceType),
                                    new XElement("LinePaymentMethod", d.LinePaymentMethod),
                                    new XElement("TechnicianID", d.TechnicianID),
                                    new XElement("LaborOpCode", d.LaborOpCode),
                                    new XElement("LaborHours", d.LaborHours),
                                    new XElement("LaborCostHours", d.LaborCostHours),
                                    new XElement("ActualRetailAmount", d.ActualRetailAmount)
                                    )
                                )
                            )
                        )
                    );
            }
        }

        public class AppointmentDetail
        {
            public String ServiceLineNumber { get; set; }

            public String LineType { get; set; }

            public String SequenceNumber { get; set; }

            public String TransDate { get; set; }

            public String Comments { get; set; }

            public String ServiceType { get; set; }

            /// <summary>
            /// C/I/W/S/P
            /// </summary>
            public String LinePaymentMethod { get; set; }

            public String TechnicianID { get; set; }

            public String LaborOpCode { get; set; }

            public Decimal? LaborHours { get; set; }

            public Decimal? LaborCostHours { get; set; }

            public Decimal? ActualRetailAmount { get; set; }
        }
    }

    /// <summary>
    /// The AppointmentUpdate request is used to update an open appointment the same elements in AppointmentAdd are available in this request.
    /// </summary>
    public class AppointmentUpdateRequest : IRequest<OpenTrack.Responses.AppointmentUpdateResponse>
    {
        public AppointmentUpdateRequest(String EnterpriseCode, String DealerCode)
            : base(EnterpriseCode, DealerCode)
        {
        }

        public AppointmentUpdateRequest(String EnterpriseCode, String DealerCode, String ServerName)
            : base(EnterpriseCode, DealerCode, ServerName)
        {
        }

        public String AppointmentNumber { get; set; }

        public String ServiceWriterID { get; set; }

        public DateTime AppointmentDateTime { get; set; }

        internal override XElement Elements
        {
            get
            {
                return new XElement("AppointmentUpdate",
                    this.Dealer,
                    new XElement("Appointment",
                        new XElement("CompanyNumber", this.CompanyNumber),
                        new XElement("AppointmentNumber", this.AppointmentNumber),
                        new XElement("ServiceWriterID", this.ServiceWriterID),
                        new XElement("AppointmentDateTime", this.AppointmentDateTime.ToString(AppointmentUpdateRequest.DateTimeFormat))
                        )
                    );
            }
        }
    }

    /// <summary>
    /// The AppointmentDelete request is used to delete an appointment from the DMS system.
    /// The only thing you need to delete an appointment is the DMS appointment number.
    /// An appointment cannot be deleted if it has been converted to a repair order.
    /// </summary>
    public class AppointmentDeleteRequest : IRequest<OpenTrack.Responses.AppointmentDeleteResponse>
    {
        public AppointmentDeleteRequest(String EnterpriseCode, String DealerCode)
            : base(EnterpriseCode, DealerCode)
        {
        }

        public AppointmentDeleteRequest(String EnterpriseCode, String DealerCode, String ServerName)
            : base(EnterpriseCode, DealerCode, ServerName)
        {
        }

        public String AppointmentNumber { get; set; }

        internal override XElement Elements
        {
            get
            {
                return new XElement("AppointmentDelete",
                    this.Dealer,
                    new XElement("AppointmentNumber", this.AppointmentNumber)
                    );
            }
        }
    }
}