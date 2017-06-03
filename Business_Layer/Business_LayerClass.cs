using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Business_ObjectLayer;
using Business_DataLayer;

namespace Business_Layer
{
    public class Business_LayerClass
    {
        Business_DataLayerClass da = new Business_DataLayerClass();

         public int SetPermission(Business_ObjectLayerClass obj)
        {
            try
            {
                int i = da.Set_Permission(obj);
                return i;
            }
            catch
            {
                throw;
            }
            finally
            {

            }
        }
        public int PermissionDeleteByRoleID(Business_ObjectLayerClass obj)
        {
            try
            {
                int i = da.Permission_DeleteByRoleID(obj);
                return i;
            }
            catch
            {
                throw;
            }
            finally
            {

            }
        }
        public SqlDataReader FetchPermissionByRoleID(Business_ObjectLayerClass obj)
        {
            try
            {
                SqlDataReader ds = da.Fetch_PermissionByRoleID(obj);
                return ds;
            }
            catch
            {
                throw;
            }
            finally
            {

            }
        }
        public int RoleUpdate(Business_ObjectLayerClass obj)
        {
            try
            {
                int i = da.Role_Update(obj);
                return i;
            }
            catch
            {
                throw;
            }
            finally
            {

            }
        }
        public DataSet FetchRoleByID(Business_ObjectLayerClass obj)
        {
            try
            {
                DataSet ds = da.Fetch_RoleByID(obj);
                return ds;
            }
            catch
            {
                throw;
            }
            finally
            {

            }
        }

        public DataSet FetchRoleForCreateUser(Business_ObjectLayerClass obj)
        {
            try
            {
                DataSet ds = da.Fetch_RoleForCreateUser(obj);
                return ds;
            }
            catch
            {
                throw;
            }
            finally
            {

            }
        }

        public DataSet FetchMenuByID(Business_ObjectLayerClass obj)
        {
            try
            {
                DataSet ds = da.Fetch_MenuByID(obj);
                return ds;
            }
            catch
            {
                throw;
            }
            finally
            {

            }
        }

        public int RoleDelete(Business_ObjectLayerClass obj)
        {
            try
            {
                int i = da.Role_Delete(obj);
                return i;
            }
            catch
            {
                throw;
            }
            finally
            {

            }
        }
        public DataSet FetchRole(Business_ObjectLayerClass obj)
        {
            try
            {
                DataSet ds = da.Fetch_Role(obj);
                return ds;
            }
            catch
            {
                throw;
            }
            finally
            {

            }
        }

        public DataSet FetchAllMenu(Business_ObjectLayerClass obj)
        {
            try
            {
                DataSet ds = da.Fetch_AllMenu(obj);
                return ds;
            }
            catch
            {
                throw;
            }
            finally
            {

            }
        }

        public DataSet FetchAllLevels(Business_ObjectLayerClass obj)
        {
            try
            {
                DataSet ds = da.Fetch_AllLevels(obj);
                return ds;
            }
            catch
            {
                throw;
            }
            finally
            {

            }
        }

        public DataSet FetchPermissionIDByRoleID(Business_ObjectLayerClass obj)
        {
            try
            {
                DataSet ds = da.FetchPermissionIDByRoleID(obj);
                return ds;
            }
            catch
            {
                throw;
            }
            finally
            {

            }
        }
        public DataSet FetchPermissionIDByPageName(Business_ObjectLayerClass obj)
        {
            try
            {
                DataSet ds = da.FetchPermissionIDByPageName(obj);
                return ds;
            }
            catch
            {
                throw;
            }
            finally
            {

            }
        }

        public int CheckPermissionByUserPageNameUserID(Business_ObjectLayerClass obj)
        {
            try
            {
                int ds = da.Check_PermissionByUserPageNameUserID(obj);
                return ds;
            }
            catch
            {
                throw;
            }
            finally
            {

            }
        }

        public int PermissionDelete(Business_ObjectLayerClass obj)
        {
            try
            {
                int i = da.Permission_Delete(obj);
                return i;
            }
            catch
            {
                throw;
            }
            finally
            {

            }
        }
        public DataSet FetchPermission(Business_ObjectLayerClass obj)
        {
            try
            {
                DataSet ds = da.Fetch_Permission(obj);
                return ds;
            }
            catch
            {
                throw;
            }
            finally
            {

            }
        }
        public int PermissionUpdate(Business_ObjectLayerClass obj)
        {
            try
            {
                int i = da.Permission_Update(obj);
                return i;
            }
            catch
            {
                throw;
            }
            finally
            {

            }
        }
        public DataSet FetchPermissionByID(Business_ObjectLayerClass obj)
        {
            try
            {
                DataSet ds = da.Fetch_PermissionByID(obj);
                return ds;
            }
            catch
            {
                throw;
            }
            finally
            {

            }
        }
        public int InsertPermission(Business_ObjectLayerClass obj)
        {
            try
            {
                int i = da.Insert_Permission(obj);
                return i;
            }
            catch
            {
                throw;
            }
            finally
            {

            }
        }
        public int InsertRole(Business_ObjectLayerClass obj)
        {
            try
            {
                int i = da.Insert_Role(obj);
                return i;
            }
            catch
            {
                throw;
            }
            finally
            {

            }
        }

        public int InsertMenu(Business_ObjectLayerClass obj)
        {
            try
            {
                int i = da.Insert_Menu(obj);
                return i;
            }
            catch
            {
                throw;
            }
            finally
            {

            }
        }

        public int Insert_AircraftRegistration(Business_ObjectLayerClass obj)
        {
            try
            {
                int i = da.InsertAircraftRegistration(obj);
                return i;
            }
            catch
            {
                throw;
            }
            finally
            {

            }
        }

        public DataSet Fetch_AircraftRegNo(Business_ObjectLayerClass obj)
        {
            try
            {
                DataSet i = da.FetchAircraftRegNo(obj);
                return i;
            }
            catch
            {
                throw;
            }
            finally
            {

            }
        }

        public DataSet Fetch_AircraftRegNoAll(Business_ObjectLayerClass obj)
        {
            try
            {
                DataSet i = da.FetchAircraftRegNoAll(obj);
                return i;
            }
            catch
            {
                throw;
            }
            finally
            {

            }
        }

        public DataSet Fetch_AircraftRegNoWithParty(Business_ObjectLayerClass obj)
        {
            try
            {
                DataSet i = da.FetchAircraftRegNoWithParty(obj);
                return i;
            }
            catch
            {
                throw;
            }
            finally
            {

            }
        }

        public DataSet Fetch_PartyName(Business_ObjectLayerClass obj)
        {
            try
            {
                DataSet i = da.FetchPartyName(obj);
                return i;
            }
            catch
            {
                throw;
            }
            finally
            {

            }
        }

        public DataSet Fetch_AircraftType(Business_ObjectLayerClass obj)
        {
            try
            {
                DataSet i = da.FetchAircraftType(obj);
                return i;
            }
            catch
            {
                throw;
            }
            finally
            {

            }
        }

        public int Insert_CargoManifest(Business_ObjectLayerClass obj)
        {
            try
            {
                int i = da.InsertCargoManifest(obj);
                return i;
            }
            catch
            {
                throw;
            }
            finally
            {

            }
        }

        public int Update_CargoManifest(Business_ObjectLayerClass obj)
        {
            try
            {
                int i = da.UpdateCargoManifest(obj);
                return i;
            }
            catch
            {
                throw;
            }
            finally
            {

            }
        }

        public DataSet Fetch_AirportName(Business_ObjectLayerClass obj)
        {
            try
            {
                DataSet i = da.FetchAirportName(obj);
                return i;
            }
            catch
            {
                throw;
            }
            finally
            {

            }
        }

        public DataSet Fetch_AirportNameByID(Business_ObjectLayerClass obj)
        {
            try
            {
                DataSet i = da.FetchAirportNameByID(obj);
                return i;
            }
            catch
            {
                throw;
            }
            finally
            {

            }
        }

        public DataSet Fetch_CargoManifestByID(Business_ObjectLayerClass obj)
        {
            try
            {
                DataSet i = da.FetchCargoManifestByID(obj);
                return i;
            }
            catch
            {
                throw;
            }
            finally
            {

            }
        }

        public DataSet Fetch_CargoManifestTotalByID(Business_ObjectLayerClass obj)
        {
            try
            {
                DataSet i = da.FetchCargoManifestTotalByID(obj);
                return i;
            }
            catch
            {
                throw;
            }
            finally
            {

            }
        }

        public DataSet Fetch_CargoManifestByManifestID(Business_ObjectLayerClass obj)
        {
            try
            {
                DataSet i = da.FetchCargoManifestByManifestID(obj);
                return i;
            }
            catch
            {
                throw;
            }
            finally
            {

            }
        }

        public DataSet Show_BillingInfo(Business_ObjectLayerClass obj)
        {
            try
            {
                DataSet i = da.ShowBillingInfo(obj);
                return i;
            }
            catch
            {
                throw;
            }
            finally
            {

            }
        }

        public int Insert_BillingInformation(Business_ObjectLayerClass obj)
        {
            try
            {
                int i = da.InsertBillingInformation(obj);
                return i;
            }
            catch
            {
                throw;
            }
            finally
            {

            }
        }

        public int Insert_BillApproval(Business_ObjectLayerClass obj)
        {
            try
            {
                int i = da.InsertBillApproval(obj);
                return i;
            }
            catch
            {
                throw;
            }
            finally
            {

            }
        }

        public DataSet Fetch_BillingDetailsByID(Business_ObjectLayerClass obj)
        {
            try
            {
                DataSet i = da.FetchBillingDetailsByID(obj);
                return i;
            }
            catch
            {
                throw;
            }
            finally
            {

            }
        }

        public int Delete_BillingDetails(Business_ObjectLayerClass obj)
        {
            try
            {
                int i = da.DeleteBillingDetails(obj);
                return i;
            }
            catch
            {
                throw;
            }
            finally
            {

            }
        }

        public int Update_BillingInformation(Business_ObjectLayerClass obj)
        {
            try
            {
                int i = da.UpdateBillingInformation(obj);
                return i;
            }
            catch
            {
                throw;
            }
            finally
            {

            }
        }

        public int Delete_CargoRecordByManifestID(Business_ObjectLayerClass obj)
        {
            try
            {
                int i = da.DeleteCargoRecordByManifestID(obj);
                return i;
            }
            catch
            {
                throw;
            }
            finally
            {

            }
        }

        public int Delete_CargoRecordByUID(Business_ObjectLayerClass obj)
        {
            try
            {
                int i = da.DeleteCargoRecordByUID(obj);
                return i;
            }
            catch
            {
                throw;
            }
            finally
            {

            }
        }

        public int Insert_LogInsertFile(Business_ObjectLayerClass obj)
        {
            try
            {
                int i = da.InsertLogInsertFile(obj);
                return i;
            }
            catch
            {
                throw;
            }
            finally
            {

            }
        }

        public int Insert_Approval(Business_ObjectLayerClass obj)
        {
            try
            {
                int i = da.InsertApproval(obj);
                return i;
            }
            catch
            {
                throw;
            }
            finally
            {

            }
        }

        public int Insert_UnApproval(Business_ObjectLayerClass obj)
        {
            try
            {
                int i = da.InsertUnApproval(obj);
                return i;
            }
            catch
            {
                throw;
            }
            finally
            {

            }
        }

        public int Insert_PartyMaster(Business_ObjectLayerClass obj)
        {
            try
            {
                int i = da.InsertPartyMaster(obj);
                return i;
            }
            catch
            {
                throw;
            }
            finally
            {

            }
        }

        public int Insert_Contractor(Business_ObjectLayerClass obj)
        {
            try
            {
                int i = da.InsertContractor(obj);
                return i;
            }
            catch
            {
                throw;
            }
            finally
            {

            }
        }

        public int Insert_AircraftType(Business_ObjectLayerClass obj)
        {
            try
            {
                int i = da.InsertAircraftType(obj);
                return i;
            }
            catch
            {
                throw;
            }
            finally
            {

            }
        }

        public DataSet Fetch_Menu(Business_ObjectLayerClass obj)
        {
            try
            {
                DataSet i = da.FetchMenu(obj);
                return i;
            }
            catch
            {
                throw;
            }
            finally
            {

            }
        }

        public DataSet Fetch_MenuByID(Business_ObjectLayerClass obj)
        {
            try
            {
                DataSet i = da.FetchMenuByID(obj);
                return i;
            }
            catch
            {
                throw;
            }
            finally
            {

            }
        }

        public DataSet Fetch_PageTitleByID(Business_ObjectLayerClass obj)
        {
            try
            {
                DataSet i = da.FetchPageTitleByID(obj);
                return i;
            }
            catch
            {
                throw;
            }
            finally
            {

            }
        }

        public DataSet Check_WatchHour(Business_ObjectLayerClass obj)
        {
            try
            {
                DataSet i = da.CheckWatchHour(obj);
                return i;
            }
            catch
            {
                throw;
            }
            finally
            {

            }
        }

        public DataSet Show_WatchHour(Business_ObjectLayerClass obj)
        {
            try
            {
                DataSet i = da.ShowWatchHour(obj);
                return i;
            }
            catch
            {
                throw;
            }
            finally
            {

            }
        }

        public int Insert_WatchHour(Business_ObjectLayerClass obj)
        {
            try
            {
                int i = da.InsertWatchHour(obj);
                return i;
            }
            catch
            {
                throw;
            }
            finally
            {

            }
        }

        public DataSet Fetch_AeronauticalResults(Business_ObjectLayerClass obj)
        {
            try
            {
                DataSet i = da.FetchAeronauticalResults(obj);
                return i;
            }
            catch
            {
                throw;
            }
            finally
            {

            }
        }

        public DataSet Fetch_AeronauticalResultsAll(Business_ObjectLayerClass obj)
        {
            try
            {
                DataSet i = da.FetchAeronauticalResultsAll(obj);
                return i;
            }
            catch
            {
                throw;
            }
            finally
            {

            }
        }

        public DataSet Fetch_AeronauticalResultDetails(Business_ObjectLayerClass obj)
        {
            try
            {
                DataSet i = da.FetchAeronauticalResultDetails(obj);
                return i;
            }
            catch
            {
                throw;
            }
            finally
            {

            }
        }

        public DataSet Fetch_Unapproved(Business_ObjectLayerClass obj)
        {
            try
            {
                DataSet i = da.FetchUnapproved(obj);
                return i;
            }
            catch
            {
                throw;
            }
            finally
            {

            }
        }

        public DataSet Fetch_approved(Business_ObjectLayerClass obj)
        {
            try
            {
                DataSet i = da.Fetchapproved(obj);
                return i;
            }
            catch
            {
                throw;
            }
            finally
            {

            }
        }

        public DataSet Fetch_Slider(Business_ObjectLayerClass obj)
        {
            try
            {
                DataSet i = da.FetchSlider(obj);
                return i;
            }
            catch
            {
                throw;
            }
            finally
            {

            }
        }

        public DataSet Fetch_PartyTotal(Business_ObjectLayerClass obj)
        {
            try
            {
                DataSet i = da.FetchPartyTotal(obj);
                return i;
            }
            catch
            {
                throw;
            }
            finally
            {

            }
        }

        public int Insert_BillProcess(Business_ObjectLayerClass obj)
        {
            try
            {
                int i = da.InsertBillProcess(obj);
                return i;
            }
            catch
            {
                throw;
            }
            finally
            {

            }
        }

        public int Cancel_Unapproved(Business_ObjectLayerClass obj)
        {
            try
            {
                int i = da.CancelUnapproved(obj);
                return i;
            }
            catch
            {
                throw;
            }
            finally
            {

            }
        }

        public int Check_BillGenerated(Business_ObjectLayerClass obj)
        {
            try
            {
                int i = da.CheckBillGenerated(obj);
                return i;
            }
            catch
            {
                throw;
            }
            finally
            {

            }
        }

        //login Panel
        public int Ckeck_login(Business_ObjectLayerClass obj)
        {
            try
            {
                int i = da.Ckecklogin(obj);
                return i;
            }
            catch
            {
                throw;
            }
            finally
            {

            }
        }
        public DataSet Ckeck_login1(Business_ObjectLayerClass obj)
        {
            try
            {
                DataSet i = da.Ckecklogin1(obj);
                return i;
            }
            catch
            {
                throw;
            }
            finally
            {

            }
        }
        public int UserRegister(Business_ObjectLayerClass obj)
        {
            try
            {
                int i = da.User_Register(obj);
                return i;
            }
            catch
            {
                throw;
            }
            finally
            {

            }
        }
        public int updatesetting_sign(Business_ObjectLayerClass obj)
        {
            try
            {
                int i = da.updatesetting_sign(obj);
                return i;
            }
            catch
            {
                throw;
            }
            finally
            {

            }
        }
        public DataSet displayddl(Business_ObjectLayerClass obj)
        {
            try
            {
                DataSet i = da.display_ddl(obj);
                return i;
            }
            catch
            {
                throw;
            }
            finally
            {

            }
        }
        public DataSet displayddl1(Business_ObjectLayerClass obj)
        {
            try
            {
                DataSet i = da.display_ddl1(obj);
                return i;
            }
            catch
            {
                throw;
            }
            finally
            {

            }
        }
        public DataSet fetchsetting(Business_ObjectLayerClass obj)
        {
            try
            {
                DataSet i = da.fetchsetting(obj);
                return i;
            }
            catch
            {
                throw;
            }
            finally
            {

            }
        }
        public DataSet FetchAllRegisterUsers(Business_ObjectLayerClass obj)
        {
            try
            {
                DataSet i = da.Fetch_AllRegisterUsers(obj);
                return i;
            }
            catch
            {
                throw;
            }
            finally
            {

            }
        }
        public DataSet sendinformation(int obj)
        {
            try
            {
                DataSet i = da.send_information(obj);
                return i;
            }
            catch
            {
                throw;
            }
            finally
            {

            }
        }
        public int ResetPassword(Business_ObjectLayerClass obj)
        {
            try
            {
                int i = da.Reset_Password(obj);
                return i;
            }
            catch
            {
                throw;
            }
            finally
            {

            }
        }
        public int DeleteRegisterUser(Business_ObjectLayerClass obj)
        {
            try
            {
                int i = da.Delete_RegisterUser(obj);
                return i;
            }
            catch
            {
                throw;
            }
            finally
            {

            }
        }
        public DataSet checklink(Business_ObjectLayerClass obj)
        {
            try
            {
                DataSet i = da.check_link(obj);
                return i;
            }
            catch
            {
                throw;
            }
            finally
            {

            }
        }
        public DataSet EditRegisterUser(Business_ObjectLayerClass obj)
        {
            try
            {
                DataSet i = da.Edit_RegisterUser(obj);
                return i;
            }
            catch
            {
                throw;
            }
            finally
            {

            }
        }
        public int updateRegisterUser(Business_ObjectLayerClass obj)
        {
            try
            {
                int i = da.update_RegisterUser(obj);
                return i;
            }
            catch
            {
                throw;
            }
            finally
            {

            }
        }
        public int loginstatus(Business_ObjectLayerClass obj)
        {
            try
            {
                int i = da.login_status(obj);
                return i;
            }
            catch
            {
                throw;
            }
            finally
            {

            }
        }
        public int insertagencyname(Business_ObjectLayerClass obj)
        {
            try
            {
                int i = da.insertagencyname(obj);
                return i;
            }
            catch
            {
                throw;
            }
            finally
            {

            }
        }
        public DataSet displaydropdown(Business_ObjectLayerClass obj)
        {
            try
            {
                DataSet i = da.display_dropdown(obj);
                return i;
            }
            catch
            {
                throw;
            }
            finally
            {

            }
        }
        public DataSet selectagenytype(Business_ObjectLayerClass obj)
        {
            try
            {
                DataSet i = da.selectagenytype(obj);
                return i;
            }
            catch
            {
                throw;
            }
            finally
            {

            }
        }
        public DataSet displaydropdown2(Business_ObjectLayerClass obj)
        {
            try
            {
                DataSet i = da.display_dropdown2(obj);
                return i;
            }
            catch
            {
                throw;
            }
            finally
            {

            }
        }
        public DataSet displaydropdown3(Business_ObjectLayerClass obj)
        {
            try
            {
                DataSet i = da.display_dropdown3(obj);
                return i;
            }
            catch
            {
                throw;
            }
            finally
            {

            }
        }
        public DataSet displaydropdown4(Business_ObjectLayerClass obj)
        {
            try
            {
                DataSet i = da.display_dropdown4(obj);
                return i;
            }
            catch
            {
                throw;
            }
            finally
            {

            }
        }
        public DataSet displaydropdown5(Business_ObjectLayerClass obj)
        {
            try
            {
                DataSet i = da.display_dropdown5(obj);
                return i;
            }
            catch
            {
                throw;
            }
            finally
            {

            }
        }
        public DataSet displaydropdown6(Business_ObjectLayerClass obj)
        {
            try
            {
                DataSet i = da.display_dropdown6(obj);
                return i;
            }
            catch
            {
                throw;
            }
            finally
            {

            }
        }
        public DataSet displaydropdown7(Business_ObjectLayerClass obj)
        {
            try
            {
                DataSet i = da.display_dropdown7(obj);
                return i;
            }
            catch
            {
                throw;
            }
            finally
            {

            }
        }
        public DataSet displaydropdown8(Business_ObjectLayerClass obj)
        {
            try
            {
                DataSet i = da.display_dropdown8(obj);
                return i;
            }
            catch
            {
                throw;
            }
            finally
            {

            }
        }
        public int exitbrowser(Business_ObjectLayerClass obj)
        {
            try
            {
                int i = da.exit_browser(obj);
                return i;
            }
            catch
            {
                throw;
            }
            finally
            {

            }
        }
        public DataSet displayFacilityMaster(Business_ObjectLayerClass obj)
        {
            try
            {
                DataSet i = da.display_FacilityMaster(obj);
                return i;
            }
            catch
            {
                throw;
            }
            finally
            {

            }
        }
        public DataSet displayPartyName(Business_ObjectLayerClass obj)
        {
            try
            {
                DataSet i = da.display_PartyName(obj);
                return i;
            }
            catch
            {
                throw;
            }
            finally
            {

            }
        }
        public int insertWorkOder(Business_ObjectLayerClass obj)
        {
            try
            {
                int i = da.insert_WorkOder(obj);
                return i;
            }
            catch
            {
                throw;
            }
            finally
            {

            }
        }
        public DataSet DisplayRevenueDetails(Business_ObjectLayerClass obj)
        {
            try
            {
                DataSet i = da.Display_RevenueDetails(obj);
                return i;
            }
            catch
            {
                throw;
            }
            finally
            {

            }
        }
        public int DeleteRevenueUser(Business_ObjectLayerClass obj)
        {
            try
            {
                int i = da.Delete_RevenueUser(obj);
                return i;
            }
            catch
            {
                throw;
            }
            finally
            {

            }
        }
        public int UpdateWorkOder(Business_ObjectLayerClass obj)
        {
            try
            {
                int i = da.Update_WorkOder(obj);
                return i;
            }
            catch
            {
                throw;
            }
            finally
            {

            }
        }
        public DataSet EditRevenueWorkout(Business_ObjectLayerClass obj)
        {
            try
            {
                DataSet i = da.Edit_RevenueWorkout(obj);
                return i;
            }
            catch
            {
                throw;
            }
            finally
            {

            }
        }
        public DataSet SortRevenueList(Business_ObjectLayerClass obj)
        {
            try
            {
                DataSet i = da.Sort_RevenueList(obj);
                return i;
            }
            catch
            {
                throw;
            }
            finally
            {

            }
        }
        public DataSet displaysorting(Business_ObjectLayerClass obj)
        {
            try
            {
                DataSet i = da.display_sorting(obj);
                return i;
            }
            catch
            {
                throw;
            }
            finally
            {

            }
        }
        public DataSet DisplayRevenueWorkout(Business_ObjectLayerClass obj)
        {
            try
            {
                DataSet i = da.Display_RevenueWorkout(obj);
                return i;
            }
            catch
            {
                throw;
            }
            finally
            {

            }
        }

        //----------------------------------


        public int InsertNtBilling(Business_ObjectLayerClass obj)
        {
            try
            {
                int i = da.Insert_NtBilling(obj);
                return i;
            }
            catch
            {
                throw;
            }
            finally
            {

            }
        }
        public DataSet DisplayNTBilling(Business_ObjectLayerClass obj)
        {
            try
            {
                DataSet i = da.Display_NTBilling(obj);
                return i;
            }
            catch
            {
                throw;
            }
            finally
            {

            }
        }
        public DataSet displayddlFacilityName(Business_ObjectLayerClass obj)
        {
            try
            {
                DataSet i = da.display_ddlFacilityName(obj);
                return i;
            }
            catch
            {
                throw;
            }
            finally
            {

            }
        }
        public DataSet displayNTBilling(Business_ObjectLayerClass obj)
        {
            try
            {
                DataSet i = da.display_NTBilling(obj);
                return i;
            }
            catch
            {
                throw;
            }
            finally
            {

            }
        }
        public int updateNTBilling(Business_ObjectLayerClass obj)
        {
            try
            {
                int i = da.update_NTBilling(obj);
                return i;
            }
            catch
            {
                throw;
            }
            finally
            {

            }
        }
        public int updateNTBillingApproved(Business_ObjectLayerClass obj)
        {
            try
            {
                int i = da.updateNTBilling_Approved(obj);
                return i;
            }
            catch
            {
                throw;
            }
            finally
            {

            }
        }
        public DataSet DisplayApproved(Business_ObjectLayerClass obj)
        {
            try
            {
                DataSet i = da.Display_Approved(obj);
                return i;
            }
            catch
            {
                throw;
            }
            finally
            {

            }
        }
        public int ApprovedBill(Business_ObjectLayerClass obj)
        {
            try
            {
                int i = da.Approved_Bill(obj);
                return i;
            }
            catch
            {
                throw;
            }
            finally
            {

            }
        }
        public int Approvepass(Business_ObjectLayerClass obj)
        {
            try
            {
                int i = da.Approve_pass(obj);
                return i;
            }
            catch
            {
                throw;
            }
            finally
            {

            }
        }
        public int InsertDigitalSign(Business_ObjectLayerClass obj)
        {
            try
            {
                int i = da.InsertDigital_Sign(obj);
                return i;
            }
            catch
            {
                throw;
            }
            finally
            {

            }
        }
        public DataSet checkDigitalSign(Business_ObjectLayerClass obj)
        {
            try
            {
                DataSet i = da.checkDigital_Sign(obj);
                return i;
            }
            catch
            {
                throw;
            }
            finally
            {

            }
        }
        public int DeleteGenerateBill(Business_ObjectLayerClass obj)
        {
            try
            {
                int i = da.DeleteGenerate_Bill(obj);
                return i;
            }
            catch
            {
                throw;
            }
            finally
            {

            }
        }
        public int changepassword(Business_ObjectLayerClass obj)
        {
            try
            {
                int i = da.change_password(obj);
                return i;
            }
            catch
            {
                throw;
            }
            finally
            {

            }
        }
        public int profilepicUpload(Business_ObjectLayerClass obj)
        {
            try
            {
                int i = da.profilepic_Upload(obj);
                return i;
            }
            catch
            {
                throw;
            }
            finally
            {

            }
        }
        public DataSet invoice(Business_ObjectLayerClass obj)
        {
            try
            {
                DataSet i = da.invo_ice(obj);
                return i;
            }
            catch
            {
                throw;
            }
            finally
            {

            }
        }
        public DataSet DisplayApprovedBill(Business_ObjectLayerClass obj)
        {
            try
            {
                DataSet i = da.DisplayApproved_Bill(obj);
                return i;
            }
            catch
            {
                throw;
            }
            finally
            {

            }
        }
        public DataSet displayPartyNameddl(Business_ObjectLayerClass obj)
        {
            try
            {
                DataSet i = da.displayParty_Nameddl(obj);
                return i;
            }
            catch
            {
                throw;
            }
            finally
            {

            }
        }
        public int forgotlogin(Business_ObjectLayerClass obj)
        {
            try
            {
                int i = da.forgot_login(obj);
                return i;
            }
            catch
            {
                throw;
            }
            finally
            {

            }
        }
        public DataSet displayFixLicenseFee(Business_ObjectLayerClass obj)
        {
            try
            {
                DataSet i = da.displayFixLicense_Fee(obj);
                return i;
            }
            catch
            {
                throw;
            }
            finally
            {

            }
        }
        public DataSet fetchBillid(Business_ObjectLayerClass obj)
        {
            try
            {
                DataSet i = da.fetchBill_id(obj);
                return i;
            }
            catch
            {
                throw;
            }
            finally
            {

            }
        }



        
        //------------------------entry pass------------------------------------

      
        public int insertnewpass(Business_ObjectLayerClass obj)
        {
            try
            {
                int i = da.insertnew_pass(obj);
                return i;
            }
            catch
            {
                throw;
            }
            finally
            {

            }
        }
        public DataSet searchOldPassDetail(Business_ObjectLayerClass obj)
        {
            try
            {
                DataSet i = da.searchOldPass_Detail(obj);
                return i;
            }
            catch
            {
                throw;
            }
            finally
            {

            }
        }
        public DataSet ShowSelectOldpassDetail(Business_ObjectLayerClass obj)
        {
            try
            {
                DataSet i = da.ShowSelectOldpass_Detail(obj);
                return i;
            }
            catch
            {
                throw;
            }
            finally
            {

            }
        }
        public int Updatepass(Business_ObjectLayerClass obj)
        {
            try
            {
                int i = da.Update_pass(obj);
                return i;
            }
            catch
            {
                throw;
            }
            finally
            {

            }
        }
        public DataSet DisplayApprovePass(Business_ObjectLayerClass obj)
        {
            try
            {
                DataSet i = da.Display_ApprovePass(obj);
                return i;
            }
            catch
            {
                throw;
            }
            finally
            {

            }
        }
        public DataSet DisplayApprovedPass(Business_ObjectLayerClass obj)
        {
            try
            {
                DataSet i = da.Display_ApprovedPass(obj);
                return i;
            }
            catch
            {
                throw;
            }
            finally
            {

            }
        }
        public int sendforApprovel(Business_ObjectLayerClass obj)
        {
            try
            {
                int i = da.sendfor_Approvel(obj);
                return i;
            }
            catch
            {
                throw;
            }
            finally
            {

            }
        }
        public DataSet fetchpassamount(Business_ObjectLayerClass obj)
        {
            try
            {
                DataSet i = da.fetchpass_amount(obj);
                return i;
            }
            catch
            {
                throw;
            }
            finally
            {

            }
        }
        public int GenerateReceiptno(Business_ObjectLayerClass obj)
        {
            try
            {
                int i = da.GenerateReceipt_no(obj);
                return i;
            }
            catch
            {
                throw;
            }
            finally
            {

            }
        }
        public DataSet Printpass(Business_ObjectLayerClass obj)
        {
            try
            {
                DataSet i = da.Print_pass(obj);
                return i;
            }
            catch
            {
                throw;
            }
            finally
            {

            }
        }
        public DataSet areaZones(Business_ObjectLayerClass obj)
        {
            try
            {
                DataSet i = da.area_Zones(obj);
                return i;
            }
            catch
            {
                throw;
            }
            finally
            {

            }
        }
        public DataSet fetchvarificationday(Business_ObjectLayerClass obj)
        {
            try
            {
                DataSet i = da.fetchvarification_day(obj);
                return i;
            }
            catch
            {
                throw;
            }
            finally
            {

            }
        }
        public DataSet checkpassvalid(Business_ObjectLayerClass obj)
        {
            try
            {
                DataSet i = da.checkpass_valid(obj);
                return i;
            }
            catch
            {
                throw;
            }
            finally
            {

            }
        }
        public int deletepass(Business_ObjectLayerClass obj)
        {
            try
            {
                int i = da.delete_pass(obj);
                return i;
            }
            catch
            {
                throw;
            }
            finally
            {

            }
        }
        public DataSet passstatus(Business_ObjectLayerClass obj)
        {
            try
            {
                DataSet i = da.pass_status(obj);
                return i;
            }
            catch
            {
                throw;
            }
            finally
            {

            }
        }
        public int insertforgotrequest(Business_ObjectLayerClass obj)
        {
            try
            {
                int i = da.insertforgot_request(obj);
                return i;
            }
            catch
            {
                throw;
            }
            finally
            {

            }
        }
        public int sessionexpire(Business_ObjectLayerClass obj)
        {
            try
            {
                int i = da.session_expire(obj);
                return i;
            }
            catch
            {
                throw;
            }
            finally
            {

            }
        }
        public int updatepermanentpass(Business_ObjectLayerClass obj)
        {
            try
            {
                int i = da.updatepermanent_pass(obj);
                return i;
            }
            catch
            {
                throw;
            }
            finally
            {

            }
        }
        public int passissue(Business_ObjectLayerClass obj)
        {
            try
            {
                int i = da.passissue(obj);
                return i;
            }
            catch
            {
                throw;
            }
            finally
            {

            }
        }
        public int insert_error(Business_ObjectLayerClass obj)
        {
            try
            {
                int i = da.insert_error(obj);
                return i;
            }
            catch
            {
                throw;
            }
            finally
            {

            }
        }
        public DataSet downloadexcel(Business_ObjectLayerClass obj)
        {
            try
            {
                DataSet i = da.download_excel(obj);
                return i;
            }
            catch
            {
                throw;
            }
            finally
            {

            }
        }
        public DataSet fetchallpassdetail(Business_ObjectLayerClass obj)
        {
            try
            {
                DataSet i = da.fetchall_passdetail(obj);
                return i;
            }
            catch
            {
                throw;
            }
            finally
            {

            }
        }
        public DataSet selectagencyname(Business_ObjectLayerClass obj)
        {
            try
            {
                DataSet i = da.selectagency_name(obj);
                return i;
            }
            catch
            {
                throw;
            }
            finally
            {

            }
        }
        public List<string> search(string pp)
        {
            try
            {
                List<string> i = da.search(pp);
                return i;
            }
            catch
            {
                throw;
            }
            finally
            {

            }
        }
    }
}

