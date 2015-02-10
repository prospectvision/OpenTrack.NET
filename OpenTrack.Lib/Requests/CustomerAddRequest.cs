using System;
using System.Xml.Linq;

namespace OpenTrack.Requests
{
    public class CustomerAddRequest : IRequest<OpenTrack.Responses.CustomerAddResponse>
    {
        public CustomerAddRequest(String EnterpriseCode, String DealerCode)
            : base(EnterpriseCode, DealerCode)
        {
        }

        public CustomerAddRequest(String EnterpriseCode, String DealerCode, String ServerName)
            : base(EnterpriseCode, DealerCode, ServerName)
        {
        }

        public Customer Customer { get; set; }

        internal override XElement Elements
        {
            get
            {
                return new XElement("CustomerAdd",
                    this.Dealer,
                    SerializeToXml<Customer>(this.Customer)
                );
            }
        }
    }

    public class CustomerUpdateRequest : IRequest<OpenTrack.Responses.CustomerUpdateResponse>
    {
        public CustomerUpdateRequest(String EnterpriseCode, String DealerCode)
            : base(EnterpriseCode, DealerCode)
        {
        }

        public CustomerUpdateRequest(String EnterpriseCode, String DealerCode, String ServerName)
            : base(EnterpriseCode, DealerCode, ServerName)
        {
        }

        public Customer Customer { get; set; }

        internal override XElement Elements
        {
            get
            {
                return new XElement("CustomerUpdate",
                    this.Dealer,
                    SerializeToXml<Customer>(this.Customer)
                    );
            }
        }
    }

    public class Customer
    {
        public String CustomerNumber { get; set; }
        
        public String TypeCode { get; set; }

        public String LastName { get; set; }

        public String FirstName { get; set; }

        public String MiddleName { get; set; }

        public String Salutation { get; set; }

        public String Gender { get; set; }

        public String Language { get; set; }

        public String Address1 { get; set; }

        public String Address2 { get; set; }

        public String Address3 { get; set; }

        public String City { get; set; }

        public String County { get; set; }

        public String StateCode { get; set; }

        public String ZipCode { get; set; }

        public String PhoneNumber { get; set; }

        public String BusinessPhone { get; set; }

        public String BusinessExt { get; set; }

        public String FaxNumber { get; set; }

        public String BirthDate { get; set; }

        public String DriversLicense { get; set; }

        public String Contact { get; set; }

        public String PreferredContact { get; set; }

        public String MailCode { get; set; }

        public String TaxExmptNumber { get; set; }

        public String AssignedSalesperson { get; set; }

        public String CustomerType { get; set; }

        public String PreferredPhone { get; set; }

        public String CellPhone { get; set; }

        public String PagePhone { get; set; }

        public String OtherPhone { get; set; }

        public String OtherPhoneDesc { get; set; }

        public String Email1 { get; set; }

        public String Email2 { get; set; }

        public String OptionalField { get; set; }

        public String AllowContactByPostal { get; set; }

        public String AllowContactByPhone { get; set; }

        public String AllowContactByEmail { get; set; }

        public String BusinessPhoneExtension { get; set; }

        public String InternationalBusinessPhone { get; set; }

        public String InternationalCellPhone { get; set; }

        public String ExternalCrossReferenceKey { get; set; }

        public String InternationalFaxNumber { get; set; }

        public String InternationalOtherPhone { get; set; }

        public String InternationalHomePhone { get; set; }

        public String CustomerPreferredName { get; set; }

        public String InternationalPagerPhone { get; set; }

        public String PreferredLanguage { get; set; }

        public String InternationalZipCode { get; set; }

        /// <summary>
        /// Token retrieved from customer search or lookup. Not used for CustomerUpdateRequest.
        /// </summary>
        public String DataToken { get; set; }
    }
}