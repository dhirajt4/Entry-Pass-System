using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business_ObjectLayer
{
    public class Business_ObjectLayerClass
    {


        private int loginID;

        public int LoginID
        {
            get { return loginID; }
            set { loginID = value; }
        }


        private string menuName;

        public string MenuName
        {
            get { return menuName; }
            set { menuName = value; }
        }

        private int roleLevel;

        public int RoleLevel
        {
            get { return roleLevel; }
            set { roleLevel = value; }
        }

        private int permissionPageLevel;

        public int PermissionPageLevel
        {
            get { return permissionPageLevel; }
            set { permissionPageLevel = value; }
        }


        private int permissionID;
        public int PermissionID
        {
            get { return permissionID; }
            set { permissionID = value; }
        }
        private string role;
        public string Role
        {
            get { return role; }
            set { role = value; }
        }
        private string permissionPage;

        public string PermissionPage
        {
            get { return permissionPage; }
            set { permissionPage = value; }
        }
        private string permission;

        public string Permission
        {
            get { return permission; }
            set { permission = value; }
        }
        private int roleid;

        public int Roleid
        {
            get { return roleid; }
            set { roleid = value; }
        }
      


        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private int pageTitleID;

        public int PageTitleID
        {
            get { return pageTitleID; }
            set { pageTitleID = value; }
        }

        private int facilityCode;

        public int FacilityCode
        {
            get { return facilityCode; }
            set { facilityCode = value; }
        }

        private int partyCode;

        public int PartyCode
        {
            get { return partyCode; }
            set { partyCode = value; }
        }

        private string billStatus;

        public string BillStatus
        {
            get { return billStatus; }
            set { billStatus = value; }
        }

        private string billType;

        public string BillType
        {
            get { return billType; }
            set { billType = value; }
        }

        private DateTime searchDateTo;

        public DateTime SearchDateTo
        {
            get { return searchDateTo; }
            set { searchDateTo = value; }
        }

        private DateTime searchDateFrom;

        public DateTime SearchDateFrom
        {
            get { return searchDateFrom; }
            set { searchDateFrom = value; }
        }

        private decimal insertWatchAmount;

        public decimal InsertWatchAmount
        {
            get { return insertWatchAmount; }
            set { insertWatchAmount = value; }
        }

        private DateTime insertWtTime;

        public DateTime InsertWtTime
        {
            get { return insertWtTime; }
            set { insertWtTime = value; }
        }

        private DateTime insertWfTime;

        public DateTime InsertWfTime
        {
            get { return insertWfTime; }
            set { insertWfTime = value; }
        }

        private DateTime arrivalDate;

        public DateTime ArrivalDate
        {
            get { return arrivalDate; }
            set { arrivalDate = value; }
        }

        private string aircraftTypeReg;

        public string AircraftTypeReg
        {
            get { return aircraftTypeReg; }
            set { aircraftTypeReg = value; }
        }

        private string operators;

        public string Operators
        {
            get { return operators; }
            set { operators = value; }
        }

        private int airportID;

        public int AirportID
        {
            get { return airportID; }
            set { airportID = value; }
        }

        private string currentAirport;

        public string CurrentAirport
        {
            get { return currentAirport; }
            set { currentAirport = value; }
        }

        private int station;

        public int Station
        {
            get { return station; }
            set { station = value; }
        }

        private int sau;

        public int Sau
        {
            get { return sau; }
            set { sau = value; }
        }

        private int rau;

        public int Rau
        {
            get { return rau; }
            set { rau = value; }
        }

        private string subPartyType;

        public string SubPartyType
        {
            get { return subPartyType; }
            set { subPartyType = value; }
        }

        private int menuID;

        public int MenuID
        {
            get { return menuID; }
            set { menuID = value; }
        }

        private string panNumber;

        public string PanNumber
        {
            get { return panNumber; }
            set { panNumber = value; }
        }

        private int tenderCode;

        public int TenderCode
        {
            get { return tenderCode; }
            set { tenderCode = value; }
        }

        private DateTime actionDateTime;

        public DateTime ActionDateTime
        {
            get { return actionDateTime; }
            set { actionDateTime = value; }
        }

        private string url;

        public string Url
        {
            get { return url; }
            set { url = value; }
        }

        private DateTime partyMasterApprovedDate;

        public DateTime PartyMasterApprovedDate
        {
            get { return partyMasterApprovedDate; }
            set { partyMasterApprovedDate = value; }
        }

        private string partyMasterApprovedBY;

        public string PartyMasterApprovedBY
        {
            get { return partyMasterApprovedBY; }
            set { partyMasterApprovedBY = value; }
        }

        private DateTime partyMasterCreatedDate;

        public DateTime PartyMasterCreatedDate
        {
            get { return partyMasterCreatedDate; }
            set { partyMasterCreatedDate = value; }
        }

        private string partyMasterCreatedBY;

        public string PartyMasterCreatedBY
        {
            get { return partyMasterCreatedBY; }
            set { partyMasterCreatedBY = value; }
        }

        private string partyMasterActive;

        public string PartyMasterActive
        {
            get { return partyMasterActive; }
            set { partyMasterActive = value; }
        }

        private string partyMasterContact;

        public string PartyMasterContact
        {
            get { return partyMasterContact; }
            set { partyMasterContact = value; }
        }

        private string partyMasterEmail;

        public string PartyMasterEmail
        {
            get { return partyMasterEmail; }
            set { partyMasterEmail = value; }
        }

        private string partyMasterPin;

        public string PartyMasterPin
        {
            get { return partyMasterPin; }
            set { partyMasterPin = value; }
        }

        private string partyMasterState;

        public string PartyMasterState
        {
            get { return partyMasterState; }
            set { partyMasterState = value; }
        }

        private string partyMasterTown;

        public string PartyMasterTown
        {
            get { return partyMasterTown; }
            set { partyMasterTown = value; }
        }

        private string partyMasterAddress;

        public string PartyMasterAddress
        {
            get { return partyMasterAddress; }
            set { partyMasterAddress = value; }
        }

        private string partyMasterType;

        public string PartyMasterType
        {
            get { return partyMasterType; }
            set { partyMasterType = value; }
        }

        private string partyMasterName;

        public string PartyMasterName
        {
            get { return partyMasterName; }
            set { partyMasterName = value; }
        }

        private int partyMasterCode;

        public int PartyMasterCode
        {
            get { return partyMasterCode; }
            set { partyMasterCode = value; }
        }

        private string action;

        public string Action
        {
            get { return action; }
            set { action = value; }
        }

        private string ipaddress;

        public string Ipaddress
        {
            get { return ipaddress; }
            set { ipaddress = value; }
        }

        private string logUid;

        public string LogUid
        {
            get { return logUid; }
            set { logUid = value; }
        }

        private string userID;

        public string UserID
        {
            get { return userID; }
            set { userID = value; }
        }

        private string userName;

        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }

        private int billingID;

        public int BillingID
        {
            get { return billingID; }
            set { billingID = value; }
        }

        private string cashNoncash;

        public string CashNoncash
        {
            get { return cashNoncash; }
            set { cashNoncash = value; }
        }

        private string billGenerated;

        public string BillGenerated
        {
            get { return billGenerated; }
            set { billGenerated = value; }
        }

        private int numberOfPaxDollar;

        public int NumberOfPaxDollar
        {
            get { return numberOfPaxDollar; }
            set { numberOfPaxDollar = value; }
        }

        private int numberOfPaxInr;

        public int NumberOfPaxInr
        {
            get { return numberOfPaxInr; }
            set { numberOfPaxInr = value; }
        }

        private int totalRecords;

        public int TotalRecords
        {
            get { return totalRecords; }
            set { totalRecords = value; }
        }

        private int totalWeight;

        public int TotalWeight
        {
            get { return totalWeight; }
            set { totalWeight = value; }
        }

        private int totalPieces;

        public int TotalPieces
        {
            get { return totalPieces; }
            set { totalPieces = value; }
        }

        private string departureFlightNo;

        public string DepartureFlightNo
        {
            get { return departureFlightNo; }
            set { departureFlightNo = value; }
        }

        private string departureTo;

        public string DepartureTo
        {
            get { return departureTo; }
            set { departureTo = value; }
        }

        private string arrivalFrom;

        public string ArrivalFrom
        {
            get { return arrivalFrom; }
            set { arrivalFrom = value; }
        }

        private string arrivalFlightNo;

        public string ArrivalFlightNo
        {
            get { return arrivalFlightNo; }
            set { arrivalFlightNo = value; }
        }

        private DateTime departureTime;

        public DateTime DepartureTime
        {
            get { return departureTime; }
            set { departureTime = value; }
        }

        private DateTime arrivalTime;

        public DateTime ArrivalTime
        {
            get { return arrivalTime; }
            set { arrivalTime = value; }
        }

        private string partyName;

        public string PartyName
        {
            get { return partyName; }
            set { partyName = value; }
        }

        private int manifestID;

        public int ManifestID
        {
            get { return manifestID; }
            set { manifestID = value; }
        }

        private string uid;

        public string Uid
        {
            get { return uid; }
            set { uid = value; }
        }

        private string officialUse;

        public string OfficialUse
        {
            get { return officialUse; }
            set { officialUse = value; }
        }

        private string owner;

        public string Owner
        {
            get { return owner; }
            set { owner = value; }
        }

        private string useBy;

        public string UseBy
        {
            get { return useBy; }
            set { useBy = value; }
        }

        private string natureOfGoods;

        public string NatureOfGoods
        {
            get { return natureOfGoods; }
            set { natureOfGoods = value; }
        }

        private decimal weight;

        public decimal Weight
        {
            get { return weight; }
            set { weight = value; }
        }

        private int pieces;

        public int Pieces
        {
            get { return pieces; }
            set { pieces = value; }
        }

        private string airwayBill;

        public string AirwayBill
        {
            get { return airwayBill; }
            set { airwayBill = value; }
        }

        private int maniFestNo;

        public int ManiFestNo
        {
            get { return maniFestNo; }
            set { maniFestNo = value; }
        }

        int seatCapacity;

        public int SeatCapacity
        {
            get { return seatCapacity; }
            set { seatCapacity = value; }
        }

        int aircraftWeight;

        public int AircraftWeight
        {
            get { return aircraftWeight; }
            set { aircraftWeight = value; }
        }

        string aircraftType;

        public string AircraftType
        {
            get { return aircraftType; }
            set { aircraftType = value; }
        }

        int partCode;

        public int PartCode
        {
            get { return partCode; }
            set { partCode = value; }
        }

        string aircraftRegNumber;

        public string AircraftRegNumber
        {
            get { return aircraftRegNumber; }
            set { aircraftRegNumber = value; }
        }

        string loginEmailid;

        public string LoginEmailid
        {
            get { return loginEmailid; }
            set { loginEmailid = value; }
        }
        string loginPassword;

        public string LoginPassword
        {
            get { return loginPassword; }
            set { loginPassword = value; }
        }
        string txtfullname;

        public string Txtfullname
        {
            get { return txtfullname; }
            set { txtfullname = value; }
        }
        string txtemail;

        public string Txtemail
        {
            get { return txtemail; }
            set { txtemail = value; }
        }
        int ddlUserType;

        public int DdlUserType
        {
            get { return ddlUserType; }
            set { ddlUserType = value; }
        }
        int ddlSubParty;

        public int DdlSubParty
        {
            get { return ddlSubParty; }
            set { ddlSubParty = value; }
        }
        string pathurl;

        public string Pathurl
        {
            get { return pathurl; }
            set { pathurl = value; }
        }
        int companyid;

        public int Companyid
        {
            get { return companyid; }
            set { companyid = value; }
        }
        string ddlControlName;

        public string DdlControlName
        {
            get { return ddlControlName; }
            set { ddlControlName = value; }
        }
        string systempassword;

        public string Systempassword
        {
            get { return systempassword; }
            set { systempassword = value; }
        }
        string newpassword;

        public string Newpassword
        {
            get { return newpassword; }
            set { newpassword = value; }
        }
        int ResetPassworduserid;

        public int ResetPassworduserid1
        {
            get { return ResetPassworduserid; }
            set { ResetPassworduserid = value; }
        }
        string key;

        public string Key
        {
            get { return key; }
            set { key = value; }
        }
        int Edituserid;

        public int Edituserid1
        {
            get { return Edituserid; }
            set { Edituserid = value; }
        }
        int deleteuserid;

        public int Deleteuserid
        {
            get { return deleteuserid; }
            set { deleteuserid = value; }
        }
        string password;

        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        Boolean login_status;

        public Boolean Login_status
        {
            get { return login_status; }
            set { login_status = value; }
        }
        Boolean logout_status;

        public Boolean Logout_status
        {
            get { return logout_status; }
            set { logout_status = value; }
        }
        int logid;

        public int Logid
        {
            get { return logid; }
            set { logid = value; }
        }
        int ddlselectedvalue;

        public int Ddlselectedvalue
        {
            get { return ddlselectedvalue; }
            set { ddlselectedvalue = value; }
        }

        int exitlogout;

        public int Exitlogout
        {
            get { return exitlogout; }
            set { exitlogout = value; }
        }
        int ddlselectedvalue1;

        public int Ddlselectedvalue1
        {
            get { return ddlselectedvalue1; }
            set { ddlselectedvalue1 = value; }
        }
        int ddlselectedvalue2;

        public int Ddlselectedvalue2
        {
            get { return ddlselectedvalue2; }
            set { ddlselectedvalue2 = value; }
        }
        int ddlselectedvalue3;

        public int Ddlselectedvalue3
        {
            get { return ddlselectedvalue3; }
            set { ddlselectedvalue3 = value; }
        }
        int ddlselectedvalue4;

        public int Ddlselectedvalue4
        {
            get { return ddlselectedvalue4; }
            set { ddlselectedvalue4 = value; }
        }
        int ddlselectedvalue5;

        public int Ddlselectedvalue5
        {
            get { return ddlselectedvalue5; }
            set { ddlselectedvalue5 = value; }
        }
        int ddlselectedvalue6;

        public int Ddlselectedvalue6
        {
            get { return ddlselectedvalue6; }
            set { ddlselectedvalue6 = value; }
        }
        int ddlselectedvalue7;

        public int Ddlselectedvalue7
        {
            get { return ddlselectedvalue7; }
            set { ddlselectedvalue7 = value; }
        }

        string RefrenceNo;

        public string RefrenceNo1
        {
            get { return RefrenceNo; }
            set { RefrenceNo = value; }
        }
        DateTime RefrenceDate;

        public DateTime RefrenceDate1
        {
            get { return RefrenceDate; }
            set { RefrenceDate = value; }
        }
        string Location;

        public string Location1
        {
            get { return Location; }
            set { Location = value; }
        }
        decimal SecurityDeposite;

        public decimal SecurityDeposite1
        {
            get { return SecurityDeposite; }
            set { SecurityDeposite = value; }
        }
        decimal AdvanceLincense;

        public decimal AdvanceLincense1
        {
            get { return AdvanceLincense; }
            set { AdvanceLincense = value; }
        }
        decimal Electricity;

        public decimal Electricity1
        {
            get { return Electricity; }
            set { Electricity = value; }
        }
        decimal Water;

        public decimal Water1
        {
            get { return Water; }
            set { Water = value; }
        }
        decimal Rate;

        public decimal Rate1
        {
            get { return Rate; }
            set { Rate = value; }
        }
        DateTime ContractPeriodFrom;

        public DateTime ContractPeriodFrom1
        {
            get { return ContractPeriodFrom; }
            set { ContractPeriodFrom = value; }
        }
        DateTime ContractPeriodTo;

        public DateTime ContractPeriodTo1
        {
            get { return ContractPeriodTo; }
            set { ContractPeriodTo = value; }
        }
        int FacilityMaster;

        public int FacilityMaster1
        {
            get { return FacilityMaster; }
            set { FacilityMaster = value; }
        }
        string AreaUnitQuantity;

        public string AreaUnitQuantity1
        {
            get { return AreaUnitQuantity; }
            set { AreaUnitQuantity = value; }
        }

        string AreaUnit;

        public string AreaUnit1
        {
            get { return AreaUnit; }
            set { AreaUnit = value; }
        }
        int BillPeriod;

        public int BillPeriod1
        {
            get { return BillPeriod; }
            set { BillPeriod = value; }
        }
        int PartytypeName;

        public int PartytypeName1
        {
            get { return PartytypeName; }
            set { PartytypeName = value; }
        }
        int Revenueid;

        public int Revenueid1
        {
            get { return Revenueid; }
            set { Revenueid = value; }
        }
        string revenueStatus;

        public string RevenueStatus
        {
            get { return revenueStatus; }
            set { revenueStatus = value; }
        }
        int EditRevenueid;

        public int EditRevenueid1
        {
            get { return EditRevenueid; }
            set { EditRevenueid = value; }
        }
        string pdfFile;

        public string PdfFile
        {
            get { return pdfFile; }
            set { pdfFile = value; }
        }
        string SortingRevenueList;

        public string SortingRevenueList1
        {
            get { return SortingRevenueList; }
            set { SortingRevenueList = value; }
        }


        //-----------------------------------------------------------
        int ntbillingid;

        public int Ntbillingid
        {
            get { return ntbillingid; }
            set { ntbillingid = value; }
        }
        DateTime startdate;

        public DateTime Startdate
        {
            get { return startdate; }
            set { startdate = value; }
        }
        DateTime enddate;

        public DateTime Enddate
        {
            get { return enddate; }
            set { enddate = value; }
        }
        private DateTime contract;

        public DateTime Contract
        {
            get { return contract; }
            set { contract = value; }
        }
        private string revenueNarration;

        public string RevenueNarration
        {
            get { return revenueNarration; }
            set { revenueNarration = value; }
        }
        private string facilityname;

        public string Facilityname
        {
            get { return facilityname; }
            set { facilityname = value; }
        }
        private DateTime perioddate;

        public DateTime Perioddate
        {
            get { return perioddate; }
            set { perioddate = value; }
        }
        private int DisplayNTBillingID;

        public int DisplayNTBillingID1
        {
            get { return DisplayNTBillingID; }
            set { DisplayNTBillingID = value; }
        }
        private decimal AreaQty;

        public decimal AreaQty1
        {
            get { return AreaQty; }
            set { AreaQty = value; }
        }
        private decimal ElectrictyUnit;

        public decimal ElectrictyUnit2
        {
            get { return ElectrictyUnit; }
            set { ElectrictyUnit = value; }
        }

        public decimal ElectrictyUnit1
        {
            get { return ElectrictyUnit; }
            set { ElectrictyUnit = value; }
        }
        private decimal WaterUnit;

        public decimal WaterUnit1
        {
            get { return WaterUnit; }
            set { WaterUnit = value; }
        }




        private decimal WaterRate;

        public decimal WaterRate1
        {
            get { return WaterRate; }
            set { WaterRate = value; }
        }
        private decimal ElectrictyRate;

        public decimal ElectrictyRate1
        {
            get { return ElectrictyRate; }
            set { ElectrictyRate = value; }
        }
        private decimal AreaRate;

        public decimal AreaRate1
        {
            get { return AreaRate; }
            set { AreaRate = value; }
        }
        private decimal AreaAmount;

        public decimal AreaAmount1
        {
            get { return AreaAmount; }
            set { AreaAmount = value; }
        }
        private decimal WaterAmount;

        public decimal WaterAmount1
        {
            get { return WaterAmount; }
            set { WaterAmount = value; }
        }
        private decimal ElectricityAmount;

        public decimal ElectricityAmount1
        {
            get { return ElectricityAmount; }
            set { ElectricityAmount = value; }
        }
        private int NTBillingID;

        public int NTBillingID1
        {
            get { return NTBillingID; }
            set { NTBillingID = value; }
        }
        private int NTBillPrroveID;

        public int NTBillPrroveID1
        {
            get { return NTBillPrroveID; }
            set { NTBillPrroveID = value; }
        }

        private Byte[] userdigitalsign;

        public Byte[] Userdigitalsign
        {
            get { return userdigitalsign; }
            set { userdigitalsign = value; }
        }

        private string Digitalsign;

        public string Digitalsign1
        {
            get { return Digitalsign; }
            set { Digitalsign = value; }
        }
        private int deleteNTbillingID;

        public int DeleteNTbillingID
        {
            get { return deleteNTbillingID; }
            set { deleteNTbillingID = value; }
        }
        private string Transactionpasswotd;

        public string Transactionpasswotd1
        {
            get { return Transactionpasswotd; }
            set { Transactionpasswotd = value; }
        }
        private string CurrentPassword;

        public string CurrentPassword1
        {
            get { return CurrentPassword; }
            set { CurrentPassword = value; }
        }
        private string NewPassword;

        public string NewPassword1
        {
            get { return NewPassword; }
            set { NewPassword = value; }
        }

        private int passwordtype;

        public int Passwordtype
        {
            get { return passwordtype; }
            set { passwordtype = value; }
        }
        private int resetID;

        public int ResetID
        {
            get { return resetID; }
            set { resetID = value; }
        }
        private int uploadUserID;

        public int UploadUserID
        {
            get { return uploadUserID; }
            set { uploadUserID = value; }
        }
        private string uploadfilename;

        public string Uploadfilename
        {
            get { return uploadfilename; }
            set { uploadfilename = value; }
        }
        private int signid;

        public int Signid
        {
            get { return signid; }
            set { signid = value; }
        }

        // ------------------------------------------------------------

        private int approve_partycode;

        public int Approve_partycode
        {
            get { return approve_partycode; }
            set { approve_partycode = value; }
        }



        private int approveid;

        public int Approveid
        {
            get { return approveid; }
            set { approveid = value; }
        }
        private DateTime billfrom;

        public DateTime Billfrom
        {
            get { return billfrom; }
            set { billfrom = value; }
        }
        private DateTime billto;

        public DateTime Billto
        {
            get { return billto; }
            set { billto = value; }
        }
        private int invoice_company_id;

        public int Invoice_company_id
        {
            get { return invoice_company_id; }
            set { invoice_company_id = value; }
        }
        private int approvedBillNo;

        public int ApprovedBillNo
        {
            get { return approvedBillNo; }
            set { approvedBillNo = value; }
        }
        private DateTime billdate;

        public DateTime Billdate
        {
            get { return billdate; }
            set { billdate = value; }
        }
        private int patrycode;

        public int Patrycode
        {
            get { return patrycode; }
            set { patrycode = value; }
        }
        private string forgotemail;

        public string Forgotemail
        {
            get { return forgotemail; }
            set { forgotemail = value; }
        }
        private decimal fixLicenseFee;

        public decimal FixLicenseFee
        {
            get { return fixLicenseFee; }
            set { fixLicenseFee = value; }
        }
        private int active;
        public int Active
        {
            get { return active; }
            set { active = value; }
        }
        private string invoice_id;

        public string Invoice_id
        {
            get { return invoice_id; }
            set { invoice_id = value; }
        }
        private string billno;

        public string Billno
        {
            get { return billno; }
            set { billno = value; }
        }
        private int BillPartyCode;

        public int BillPartyCode1
        {
            get { return BillPartyCode; }
            set { BillPartyCode = value; }
        }
        private int BillArrear;

        public int BillArrear1
        {
            get { return BillArrear; }
            set { BillArrear = value; }
        }
        private DateTime BillPeriodfrom;

        public DateTime BillPeriodfrom1
        {
            get { return BillPeriodfrom; }
            set { BillPeriodfrom = value; }
        }

        private int Billoptions;

        public int Billoptions1
        {
            get { return Billoptions; }
            set { Billoptions = value; }
        }





        //------------------------entry pass------------------------------------



        private Int64 passno;

        public Int64 Passno
        {
            get { return passno; }
            set { passno = value; }
        }
        private DateTime issuedate;

        public DateTime Issuedate
        {
            get { return issuedate; }
            set { issuedate = value; }
        }
        private DateTime periodfrom;

        public DateTime Periodfrom
        {
            get { return periodfrom; }
            set { periodfrom = value; }
        }
        private DateTime periodto;

        public DateTime Periodto
        {
            get { return periodto; }
            set { periodto = value; }
        }
        private int terminal;

        public int Terminal
        {
            get { return terminal; }
            set { terminal = value; }
        }
        private string presentaddress;

        public string Presentaddress
        {
            get { return presentaddress; }
            set { presentaddress = value; }
        }
        private string address;

        public string Address
        {
            get { return address; }
            set { address = value; }
        }
        private DateTime dob;

        public DateTime Dob
        {
            get { return dob; }
            set { dob = value; }
        }
        private int airport;

        public int Airport
        {
            get { return airport; }
            set { airport = value; }
        }
        private string designation;

        public string Designation
        {
            get { return designation; }
            set { designation = value; }
        }
        private string purposeofvisit;

        public string Purposeofvisit
        {
            get { return purposeofvisit; }
            set { purposeofvisit = value; }
        }
        private string areazones;

        public string Areazones
        {
            get { return areazones; }
            set { areazones = value; }
        }
        private int policevarificationtype;

        public int Policevarificationtype
        {
            get { return policevarificationtype; }
            set { policevarificationtype = value; }
        }
        private string policeverficationdate;

        public string Policeverficationdate
        {
            get { return policeverficationdate; }
            set { policeverficationdate = value; }
        }
        private string applicantname;

        public string Applicantname
        {
            get { return applicantname; }
            set { applicantname = value; }
        }
        private string photo;

        public string Photo
        {
            get { return photo; }
            set { photo = value; }
        }
        private string sign;

        public string Sign
        {
            get { return sign; }
            set { sign = value; }
        }
        private string wife;

        public string Wife
        {
            get { return wife; }
            set { wife = value; }
        }
        private Int64 previouspassno;

        public Int64 Previouspassno
        {
            get { return previouspassno; }
            set { previouspassno = value; }
        }
        private int passtype;

        public int Passtype
        {
            get { return passtype; }
            set { passtype = value; }
        }
        private int agency;

        public int Agency
        {
            get { return agency; }
            set { agency = value; }
        }
        private string policeverificationdocument;

        public string Policeverificationdocument
        {
            get { return policeverificationdocument; }
            set { policeverificationdocument = value; }
        }
        private string policeverificationname;

        public string Policeverificationname
        {
            get { return policeverificationname; }
            set { policeverificationname = value; }
        }

        private string applicantphoto;

        public string Applicantphoto
        {
            get { return applicantphoto; }
            set { applicantphoto = value; }
        }
        private string applicantsign;

        public string Applicantsign
        {
            get { return applicantsign; }
            set { applicantsign = value; }
        }

        private Int64 searcholdpassno;

        public Int64 Searcholdpassno
        {
            get { return searcholdpassno; }
            set { searcholdpassno = value; }
        }
        private string searchapplicantname;

        public string Searchapplicantname
        {
            get { return searchapplicantname; }
            set { searchapplicantname = value; }
        }
        private DateTime searchdob;

        public DateTime Searchdob
        {
            get { return searchdob; }
            set { searchdob = value; }
        }

        private Int64 oldpassno;

        public Int64 Oldpassno
        {
            get { return oldpassno; }
            set { oldpassno = value; }
        }

        private string selectapssno;

        public string Selectapssno
        {
          get { return selectapssno; }
          set { selectapssno = value; }
        }

        private int selectprocess;

        public int Selectprocess
        {
            get { return selectprocess; }
            set { selectprocess = value; }
        }
        private decimal passAmount;

        public decimal PassAmount
        {
            get { return passAmount; }
            set { passAmount = value; }
        }
        private string RemarkDetail;

        public string RemarkDetail1
        {
            get { return RemarkDetail; }
            set { RemarkDetail = value; }
        }
        private int selectagency;

        public int Selectagency
        {
            get { return selectagency; }
            set { selectagency = value; }
        }
        private bool remark;

        public bool Remark
        {
            get { return remark; }
            set { remark = value; }
        }
        private string generateReceipt;

        public string GenerateReceipt
        {
            get { return generateReceipt; }
            set { generateReceipt = value; }
        }
        private string selectPass;

        public string SelectPass
        {
            get { return selectPass; }
            set { selectPass = value; }
        }
        private int verificationdays;

        public int Verificationdays
        {
            get { return verificationdays; }
            set { verificationdays = value; }
        }
        private bool FeeExemption;

        public bool FeeExemption1
        {
            get { return FeeExemption; }
            set { FeeExemption = value; }
        }
        private string selectremark;

        public string Selectremark
        {
            get { return selectremark; }
            set { selectremark = value; }
        }
        private decimal passfee;

        public decimal Passfee
        {
            get { return passfee; }
            set { passfee = value; }
        }
        private string paymenttype;

        public string Paymenttype
        {
            get { return paymenttype; }
            set { paymenttype = value; }
        }
        private string chequedate;

        public string Chequedate
        {
            get { return chequedate; }
            set { chequedate = value; }
        }
        private string chequeno;

        public string Chequeno
        {
            get { return chequeno; }
            set { chequeno = value; }
        }
        private string NameofAgency;

        public string NameofAgency1
        {
            get { return NameofAgency; }
            set { NameofAgency = value; }
        }
        private string reject_remark;

        public string Reject_remark
        {
            get { return reject_remark; }
            set { reject_remark = value; }
        }
        private string checkpass;

        public string Checkpass
        {
            get { return checkpass; }
            set { checkpass = value; }
        }
        private string statusregno;

        public string Statusregno
        {
            get { return statusregno; }
            set { statusregno = value; }
        }
        private string statusapplicant;

        public string Statusapplicant
        {
            get { return statusapplicant; }
            set { statusapplicant = value; }
        }

        private string Esctpassno;

        public string Esctpassno1
        {
            get { return Esctpassno; }
            set { Esctpassno = value; }
        }
        private string loginstatusid;

        public string Loginstatusid
        {
            get { return loginstatusid; }
            set { loginstatusid = value; }
        }
        private string permanentAEPNo;

        public string PermanentAEPNo
        {
            get { return permanentAEPNo; }
            set { permanentAEPNo = value; }
        }
        private string PermanentAEpid;

        public string PermanentAEpid1
        {
            get { return PermanentAEpid; }
            set { PermanentAEpid = value; }
        }
        private string excelaepno;

        public string Excelaepno
        {
            get { return excelaepno; }
            set { excelaepno = value; }
        }
        private string selectagencyname;

        public string Selectagencyname
        {
            get { return selectagencyname; }
            set { selectagencyname = value; }
        }
        private string agencyname;

        public string Agencyname
        {
            get { return agencyname; }
            set { agencyname = value; }
        }
        private string identityproofname;

        public string Identityproofname
        {
            get { return identityproofname; }
            set { identityproofname = value; }
        }
        private string identityproofno;

        public string Identityproofno
        {
            get { return identityproofno; }
            set { identityproofno = value; }
        }
        private Boolean bcasapproval;

        public Boolean Bcasapproval
        {
            get { return bcasapproval; }
            set { bcasapproval = value; }
        }
        private string applicantmobile;

        public string Applicantmobile
        {
            get { return applicantmobile; }
            set { applicantmobile = value; }
        }
        private string searchmobile;

        public string Searchmobile
        {
            get { return searchmobile; }
            set { searchmobile = value; }
        }
        private string angency_name;

        public string Angency_name
        {
            get { return angency_name; }
            set { angency_name = value; }
        }
        private string angency_address;

        public string Angency_address
        {
            get { return angency_address; }
            set { angency_address = value; }
        }
        private string agency_emailid;

        public string Agency_emailid
        {
            get { return agency_emailid; }
            set { agency_emailid = value; }
        }
        private string agency_PAN;

        public string Agency_PAN
        {
            get { return agency_PAN; }
            set { agency_PAN = value; }
        }
        private string agency_CIN;

        public string Agency_CIN
        {
            get { return agency_CIN; }
            set { agency_CIN = value; }
        }
        private string agency_mobile;

        public string Agency_mobile
        {
            get { return agency_mobile; }
            set { agency_mobile = value; }
        }
        private int agency_Type_id;

        public int Agency_Type_id
        {
            get { return agency_Type_id; }
            set { agency_Type_id = value; }
        }

        public bool Setting_signature1
        {
            get
            {
                return Setting_signature;
            }

            set
            {
                Setting_signature = value;
            }
        }

        private Boolean Setting_signature;
        private string error;

        public string Error
        {
            get { return error; }
            set { error = value; }
        }
        private int oldpassrenew;

        public int Oldpassrenew
        {
            get { return oldpassrenew; }
            set { oldpassrenew = value; }
        }
        private Boolean selfesct;

        public Boolean Selfesct
        {
            get { return selfesct; }
            set { selfesct = value; }
        }
  }
}
