using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace OpenTrack.Requests
{
    public class VehicleAddRequest : IRequest<OpenTrack.Responses.VehicleAddResponse>
    {
        public VehicleAddRequest(string EnterpriseCode, string CompanyNumber) : base(EnterpriseCode, CompanyNumber)
        {
        }

        public VehicleAddRequest(string EnterpriseCode, string CompanyNumber, string ServerName) : base(EnterpriseCode, CompanyNumber, ServerName)
        {
        }

        internal override XElement Elements
        {
            get
            {
                return new XElement("VehicleAdd",
                    this.Dealer,
                    SerializeToXml<Vehicle>(this.Vehicle)
                );
            }
        }

        public Vehicle Vehicle { get; set; }
    }

    public class Vehicle
    {
        public string CompanyNumber { get; set; }

        private string _vin;
        public string VIN
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

        public string StockNumber { get; set; }

        public string DocumentNumber { get; set; }

        public string Status { get; set; }

        public string GLApplied { get; set; }

        public string TypeNU { get; set; }

        public string BusinessOfficeFranchiseCode { get; set; }

        public string ServiceFranchiseCode { get; set; }

        public string ManufactureCode { get; set; }

        public string VehicleCode { get; set; }

        public string ModelYear { get; set; }

        public string Make { get; set; }

        public string ModelCode { get; set; }

        public string Model { get; set; }

        public string BodyStyle { get; set; }

        public string Color { get; set; }

        public string Trim { get; set; }

        public string FuelType { get; set; }

        public string MPG { get; set; }

        public string Cylinders { get; set; }

        public string Truck { get; set; }

        public string FourWheelDrive { get; set; }

        public string DealerCode { get; set; }

        public string Location { get; set; }

        public int Odometer { get; set; }

        public string DateInInventory { get; set; }

        public string DateInService { get; set; }

        public string DateDelivered { get; set; }

        public string DateOrdered { get; set; }

        public string SaleAccount { get; set; }

        public string InventoryAccount { get; set; }

        public string DemoName { get; set; }

        public int WarrentyMonths { get; set; }

        public int WarrentyMiles { get; set; }

        public int WarrentyDeduct { get; set; }

        public decimal ListPrice { get; set; }

        public decimal VehicleCost { get; set; }

        public string OptionPackage { get; set; }

        public string LicenseNumber { get; set; }

        public decimal GrossWeight { get; set; }

        public decimal WorkInProcess { get; set; }

        public int InspectionMonth { get; set; }

        public string OdometerActual { get; set; }

        public string CustomerKey { get; set; }

        public string KeyToCAPExplosionData { get; set; }

        public string CO2EmissionCode { get; set; }

        public string RegistrationDate { get; set; }

        public string FundingExpirationDate { get; set; }

        public string InspectionDate { get; set; }

        public string DriverSide { get; set; }

        public int FreeFlooringPeriod { get; set; }

        public string OrderedStatus { get; set; }

        public string PublishVehicleInfoToWeb { get; set; }

        public string Sale { get; set; }

        public string CertifiedUsedCar { get; set; }

        public string LastServiceDate { get; set; }

        public string NextServiceDate { get; set; }

        public List<VehicleOptionalField> OptionalFields { get; set; }

        public List<VehicleOption> Options { get; set; } 
    }

    public class VehicleOption
    {
        public string OptionCode { get; set; }

        public string Description { get; set; }
    }

    public class VehicleOptionalField
    {
        public int OptionNumber { get; set; }

        public string Description { get; set; }

        public string FieldType { get; set; }

        public string AlphaFieldValue { get; set; }

        public decimal NumericFieldValue { get; set; }

        public string DateFieldValue { get; set; }

        public string AddToCostFlag { get; set; }
    }
}