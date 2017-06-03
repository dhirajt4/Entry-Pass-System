using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business_ObjectLayer;
using System.Data;
using System.Data.SqlClient;

namespace Business_DataLayer
{
    public class Business_DataLayerClass
    {

        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-8J5KATN\SQLEXPRESS;Initial Catalog=entrypass;Integrated Security=True;Connect Timeout=15; ");
       

        public int Set_Permission(Business_ObjectLayerClass obj)
        {
            try
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                con.Open();
                SqlCommand cmd = new SqlCommand("PermissionPR", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@permissionid", SqlDbType.NVarChar).Value = obj.PermissionID;
                cmd.Parameters.AddWithValue("@roleid", SqlDbType.NVarChar).Value = obj.Roleid;
                cmd.Parameters.AddWithValue("@userid", SqlDbType.NVarChar).Value = obj.LoginID;
                cmd.Parameters.AddWithValue("@choice", SqlDbType.VarChar).Value = "6";
                cmd.Parameters.Add("@result", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                int i = Convert.ToInt32(cmd.Parameters["@result"].Value.ToString());
                return i;

            }
            catch
            {
                throw;
            }
            finally
            {
                con.Close();
            }

        }
        public int Permission_DeleteByRoleID(Business_ObjectLayerClass obj)
        {
            try
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                con.Open();
                SqlCommand cmd = new SqlCommand("PermissionPR", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@roleid", SqlDbType.Int).Value = obj.Roleid;
                cmd.Parameters.AddWithValue("@choice", SqlDbType.VarChar).Value = "8";
                cmd.Parameters.Add("@result", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                int i = Convert.ToInt32(cmd.Parameters["@result"].Value.ToString());
                return i;

            }
            catch
            {
                throw;
            }
            finally
            {
                con.Close();
            }

        }
        public SqlDataReader Fetch_PermissionByRoleID(Business_ObjectLayerClass obj)
        {
            try
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                con.Open();
                SqlCommand cmd = new SqlCommand("PermissionPR", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@roleid", SqlDbType.NVarChar).Value = obj.Roleid;
                cmd.Parameters.AddWithValue("@choice", SqlDbType.VarChar).Value = "7";
                cmd.Parameters.Add("@result", SqlDbType.Int).Direction = ParameterDirection.Output;
                //SqlDataAdapter da = new SqlDataAdapter(cmd);
                //DataSet ds = new DataSet();
                // da.Fill(ds);
                SqlDataReader dr = cmd.ExecuteReader();
                return dr;

            }
            catch
            {
                throw;
            }
            finally
            {

            }

        }
        public int Role_Update(Business_ObjectLayerClass obj)
        {
            try
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                con.Open();
                SqlCommand cmd = new SqlCommand("RolePR", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@role", SqlDbType.NVarChar).Value = obj.Role;
                cmd.Parameters.AddWithValue("@rolelevel", obj.RoleLevel);
                cmd.Parameters.AddWithValue("@roleid", SqlDbType.Int).Value = obj.Roleid;
                cmd.Parameters.AddWithValue("@choice", SqlDbType.VarChar).Value = "3";
                cmd.Parameters.Add("@result", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                int i = Convert.ToInt32(cmd.Parameters["@result"].Value.ToString());
                return i;

            }
            catch
            {
                throw;
            }
            finally
            {
                con.Close();
            }

        }
        public DataSet Fetch_RoleByID(Business_ObjectLayerClass obj)
        {
            try
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                con.Open();
                SqlCommand cmd = new SqlCommand("RolePR", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@roleid", SqlDbType.Int).Value = obj.Roleid;
                cmd.Parameters.AddWithValue("@choice", SqlDbType.VarChar).Value = "5";
                cmd.Parameters.Add("@result", SqlDbType.Int).Direction = ParameterDirection.Output;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;

            }
            catch
            {
                throw;
            }
            finally
            {
                con.Close();
            }

        }

        public DataSet Fetch_RoleForCreateUser(Business_ObjectLayerClass obj)
        {
            try
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                con.Open();
                SqlCommand cmd = new SqlCommand("RolePR", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@roleid", SqlDbType.Int).Value = obj.Roleid;
                cmd.Parameters.AddWithValue("@choice", SqlDbType.VarChar).Value = "7";
                cmd.Parameters.Add("@result", SqlDbType.Int).Direction = ParameterDirection.Output;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;

            }
            catch
            {
                throw;
            }
            finally
            {
                con.Close();
            }

        }

        public DataSet Fetch_MenuByID(Business_ObjectLayerClass obj)
        {
            try
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                con.Open();
                SqlCommand cmd = new SqlCommand("MenuPR", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", obj.MenuID);
                cmd.Parameters.AddWithValue("@choice", SqlDbType.VarChar).Value = "6";
                cmd.Parameters.Add("@result", SqlDbType.Int).Direction = ParameterDirection.Output;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;

            }
            catch
            {
                throw;
            }
            finally
            {
                con.Close();
            }

        }

        public int Role_Delete(Business_ObjectLayerClass obj)
        {
            try
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                con.Open();
                SqlCommand cmd = new SqlCommand("RolePR", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@roleid", SqlDbType.Int).Value = obj.Roleid;
                cmd.Parameters.AddWithValue("@choice", SqlDbType.VarChar).Value = "4";
                cmd.Parameters.Add("@result", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                int i = Convert.ToInt32(cmd.Parameters["@result"].Value.ToString());
                return i;

            }
            catch
            {
                throw;
            }
            finally
            {
                con.Close();
            }

        }
        public DataSet Fetch_Role(Business_ObjectLayerClass obj)
        {
            try
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                con.Open();
                SqlCommand cmd = new SqlCommand("RolePR", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@choice", SqlDbType.VarChar).Value = "2";
                cmd.Parameters.Add("@result", SqlDbType.Int).Direction = ParameterDirection.Output;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;

            }
            catch
            {
                throw;
            }
            finally
            {
                con.Close();
            }

        }

        public DataSet Fetch_AllMenu(Business_ObjectLayerClass obj)
        {
            try
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                con.Open();
                SqlCommand cmd = new SqlCommand("MenuPR", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@choice", SqlDbType.VarChar).Value = "4";
                cmd.Parameters.Add("@result", SqlDbType.Int).Direction = ParameterDirection.Output;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;

            }
            catch
            {
                throw;
            }
            finally
            {
                con.Close();
            }

        }

        public DataSet Fetch_AllLevels(Business_ObjectLayerClass obj)
        {
            try
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                con.Open();
                SqlCommand cmd = new SqlCommand("RolePR", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@choice", SqlDbType.VarChar).Value = "6";
                cmd.Parameters.Add("@result", SqlDbType.Int).Direction = ParameterDirection.Output;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;

            }
            catch
            {
                throw;
            }
            finally
            {
                con.Close();
            }

        }

        public DataSet FetchPermissionIDByRoleID(Business_ObjectLayerClass obj)
        {
            try
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                con.Open();
                SqlCommand cmd = new SqlCommand("PermissionPR", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@roleid", SqlDbType.NVarChar).Value = obj.Roleid;
                cmd.Parameters.AddWithValue("@choice", SqlDbType.VarChar).Value = "11";
                cmd.Parameters.Add("@result", SqlDbType.Int).Direction = ParameterDirection.Output;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;

            }
            catch
            {
                throw;
            }
            finally
            {
                con.Close();
            }

        }
        public DataSet FetchPermissionIDByPageName(Business_ObjectLayerClass obj)
        {
            try
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                con.Open();
                SqlCommand cmd = new SqlCommand("PermissionPR", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@permissionpage", SqlDbType.NVarChar).Value = obj.PermissionPage;
                cmd.Parameters.AddWithValue("@choice", SqlDbType.VarChar).Value = "10";
                cmd.Parameters.Add("@result", SqlDbType.Int).Direction = ParameterDirection.Output;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;

            }
            catch
            {
                throw;
            }
            finally
            {
                con.Close();
            }

        }

        public int Check_PermissionByUserPageNameUserID(Business_ObjectLayerClass obj)
        {
            try
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                con.Open();
                SqlCommand cmd = new SqlCommand("PermissionPR", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@permissionpage", SqlDbType.NVarChar).Value = obj.PermissionPage;
                cmd.Parameters.AddWithValue("@roleid", obj.Roleid);
                cmd.Parameters.AddWithValue("@id", obj.Id);
                cmd.Parameters.AddWithValue("@Loginstatusid", obj.Loginstatusid);
                cmd.Parameters.AddWithValue("@choice", SqlDbType.VarChar).Value = "12";
                cmd.Parameters.Add("@result", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                int i = Convert.ToInt32(cmd.Parameters["@result"].Value.ToString());
                return i;
                //SqlDataAdapter da = new SqlDataAdapter(cmd);
                //DataSet ds = new DataSet();
                //da.Fill(ds);
                //return ds;

            }
            catch
            {
                throw;
            }
            finally
            {
                con.Close();
            }

        }

        public int Permission_Delete(Business_ObjectLayerClass obj)
        {
            try
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                con.Open();
                SqlCommand cmd = new SqlCommand("PermissionPR", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@permissionid", SqlDbType.Int).Value = obj.PermissionID;
                cmd.Parameters.AddWithValue("@choice", SqlDbType.VarChar).Value = "4";
                cmd.Parameters.Add("@result", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                int i = Convert.ToInt32(cmd.Parameters["@result"].Value.ToString());
                return i;

            }
            catch
            {
                throw;
            }
            finally
            {
                con.Close();
            }

        }
        public DataSet Fetch_Permission(Business_ObjectLayerClass obj)
        {
            try
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                con.Open();
                SqlCommand cmd = new SqlCommand("PermissionPR", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@choice", SqlDbType.VarChar).Value = "2";
                cmd.Parameters.Add("@result", SqlDbType.Int).Direction = ParameterDirection.Output;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;

            }
            catch
            {
                throw;
            }
            finally
            {
                con.Close();
            }

        }
        public int Permission_Update(Business_ObjectLayerClass obj)
        {
            try
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                con.Open();
                SqlCommand cmd = new SqlCommand("PermissionPR", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@permission", SqlDbType.NVarChar).Value = obj.Permission;
                cmd.Parameters.AddWithValue("@permissionpage", SqlDbType.NVarChar).Value = obj.PermissionPage;
                cmd.Parameters.AddWithValue("@permissionid", SqlDbType.Int).Value = obj.PermissionID;
                cmd.Parameters.AddWithValue("@permissionlevel", SqlDbType.NVarChar).Value = obj.PermissionPageLevel;
                cmd.Parameters.AddWithValue("@choice", SqlDbType.VarChar).Value = "3";
                cmd.Parameters.Add("@result", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                int i = Convert.ToInt32(cmd.Parameters["@result"].Value.ToString());
                return i;

            }
            catch
            {
                throw;
            }
            finally
            {
                con.Close();
            }

        }
        public DataSet Fetch_PermissionByID(Business_ObjectLayerClass obj)
        {
            try
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                con.Open();
                SqlCommand cmd = new SqlCommand("PermissionPR", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@permissionid", SqlDbType.NVarChar).Value = obj.PermissionID;
                cmd.Parameters.AddWithValue("@choice", SqlDbType.VarChar).Value = "5";
                cmd.Parameters.Add("@result", SqlDbType.Int).Direction = ParameterDirection.Output;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;

            }
            catch
            {
                throw;
            }
            finally
            {
                con.Close();
            }

        }
        public int Insert_Permission(Business_ObjectLayerClass obj)
        {
            try
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                con.Open();
                SqlCommand cmd = new SqlCommand("PermissionPR", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@permissionid", obj.PermissionID);
                cmd.Parameters.AddWithValue("@menuid", obj.MenuID);
                cmd.Parameters.AddWithValue("@companyid", obj.Companyid);
                cmd.Parameters.AddWithValue("@permission", SqlDbType.NVarChar).Value = obj.Permission;
                cmd.Parameters.AddWithValue("@permissionpage", SqlDbType.NVarChar).Value = obj.PermissionPage;
                cmd.Parameters.AddWithValue("@permissionlevel", obj.PermissionPageLevel);
                cmd.Parameters.AddWithValue("@choice", SqlDbType.VarChar).Value = "1";
                cmd.Parameters.Add("@result", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                int i = Convert.ToInt32(cmd.Parameters["@result"].Value.ToString());
                return i;

            }
            catch
            {
                throw;
            }
            finally
            {
                con.Close();
            }

        }
        public int Insert_Role(Business_ObjectLayerClass obj)
        {
            try
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                con.Open();
                SqlCommand cmd = new SqlCommand("RolePR", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@roleid", obj.Roleid);
                cmd.Parameters.AddWithValue("@role", SqlDbType.NVarChar).Value = obj.Role;
                cmd.Parameters.AddWithValue("@rolelevel", obj.RoleLevel);
                cmd.Parameters.AddWithValue("@choice", SqlDbType.VarChar).Value = "1";
                cmd.Parameters.Add("@result", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                int i = Convert.ToInt32(cmd.Parameters["@result"].Value.ToString());
                return i;

            }
            catch
            {
                throw;
            }
            finally
            {
                con.Close();
            }

        }

        public int Insert_Menu(Business_ObjectLayerClass obj)
        {
            try
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                con.Open();
                SqlCommand cmd = new SqlCommand("MenuPR", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", obj.MenuID);
                cmd.Parameters.AddWithValue("@menuname", obj.MenuName);
                cmd.Parameters.AddWithValue("@companyid", obj.Companyid);
                cmd.Parameters.AddWithValue("@choice", SqlDbType.VarChar).Value = "5";
                cmd.Parameters.Add("@result", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                int i = Convert.ToInt32(cmd.Parameters["@result"].Value.ToString());
                return i;

            }
            catch
            {
                throw;
            }
            finally
            {
                con.Close();
            }

        }

        public int InsertAircraftRegistration(Business_ObjectLayerClass obj)
        {
            try
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                con.Open();
                SqlCommand cmd = new SqlCommand("AircraftRegistrationPR", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@registrationno", SqlDbType.VarChar).Value = obj.AircraftRegNumber;
                cmd.Parameters.AddWithValue("@partycode", obj.PartCode);
                cmd.Parameters.AddWithValue("@aircrafttype", SqlDbType.VarChar).Value = obj.AircraftType;
                cmd.Parameters.AddWithValue("@aircraftweight", obj.AircraftWeight);
                cmd.Parameters.AddWithValue("@seatcapacity", obj.SeatCapacity);
                cmd.Parameters.AddWithValue("@choice", SqlDbType.VarChar).Value = "3";
                cmd.Parameters.AddWithValue("@result", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                int i = Convert.ToInt32(cmd.Parameters["@result"].Value.ToString());
                return i;

            }
            catch
            {
                throw;
            }
            finally
            {
                con.Close();
            }
        }

        public DataTable AircraftRegNo(Business_ObjectLayerClass obj)
        {
            try
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                con.Open();
                SqlCommand cmd = new SqlCommand("select * from CA12Registration_Master where Registration_No like @Name+'%'", con);
                cmd.Parameters.AddWithValue("@Name", SqlDbType.VarChar).Value = obj.AircraftRegNumber;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;

            }
            catch
            {
                throw;
            }
            finally
            {
                con.Close();
            }
        }

        public DataSet FetchAircraftRegNo(Business_ObjectLayerClass obj)
        {
            try
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                con.Open();
                SqlCommand cmd = new SqlCommand("SP_BIND_AIRCRAFT_DETAIL", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@key", SqlDbType.VarChar).Value = obj.AircraftRegNumber;
                cmd.Parameters.AddWithValue("@choice", SqlDbType.VarChar).Value = "1";
                cmd.Parameters.AddWithValue("@result", SqlDbType.Int).Direction = ParameterDirection.Output;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;

            }
            catch
            {
                throw;
            }
            finally
            {
                con.Close();
            }
        }

        public DataSet FetchAircraftRegNoAll(Business_ObjectLayerClass obj)
        {
            try
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                con.Open();
                SqlCommand cmd = new SqlCommand("AircraftRegistrationPR", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@choice", SqlDbType.VarChar).Value = "4";
                cmd.Parameters.AddWithValue("@result", SqlDbType.Int).Direction = ParameterDirection.Output;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;

            }
            catch
            {
                throw;
            }
            finally
            {
                con.Close();
            }
        }

        public DataSet FetchAircraftRegNoWithParty(Business_ObjectLayerClass obj)
        {
            try
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                con.Open();
                SqlCommand cmd = new SqlCommand("AircraftRegistrationPR", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@partyname", obj.PartCode);
                cmd.Parameters.AddWithValue("@choice", SqlDbType.VarChar).Value = "6";
                cmd.Parameters.AddWithValue("@result", SqlDbType.Int).Direction = ParameterDirection.Output;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;

            }
            catch
            {
                throw;
            }
            finally
            {
                con.Close();
            }
        }

        public DataSet FetchPartyName(Business_ObjectLayerClass obj)
        {
            try
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                con.Open();
                SqlCommand cmd = new SqlCommand("AircraftRegistrationPR", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@choice", SqlDbType.VarChar).Value = "1";
                cmd.Parameters.AddWithValue("@result", SqlDbType.Int).Direction = ParameterDirection.Output;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;

            }
            catch
            {
                throw;
            }
            finally
            {
                con.Close();
            }
        }

        public DataSet FetchAircraftType(Business_ObjectLayerClass obj)
        {
            try
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                con.Open();
                SqlCommand cmd = new SqlCommand("AircraftRegistrationPR", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@choice", SqlDbType.VarChar).Value = "2";
                cmd.Parameters.AddWithValue("@result", SqlDbType.Int).Direction = ParameterDirection.Output;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;

            }
            catch
            {
                throw;
            }
            finally
            {
                con.Close();
            }
        }

        public int InsertCargoManifest(Business_ObjectLayerClass obj)
        {
            try
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                con.Open();
                SqlCommand cmd = new SqlCommand("CargoManifestsPR", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@uid", obj.Uid);
                cmd.Parameters.AddWithValue("@manifestno", obj.ManiFestNo);
                cmd.Parameters.AddWithValue("@airwaybill", obj.AirwayBill);
                cmd.Parameters.AddWithValue("@pieces", obj.Pieces);
                cmd.Parameters.AddWithValue("@weight", obj.Weight);
                cmd.Parameters.AddWithValue("@natureofgoods", obj.NatureOfGoods);
                cmd.Parameters.AddWithValue("@useby", obj.UseBy);
                cmd.Parameters.AddWithValue("@owner", obj.Owner);
                cmd.Parameters.AddWithValue("@officialuse", obj.OfficialUse);
                cmd.Parameters.AddWithValue("@MOPER", obj.Operators);
                cmd.Parameters.AddWithValue("@arrivaldate", obj.ArrivalDate);
                cmd.Parameters.AddWithValue("@choice", SqlDbType.VarChar).Value = "1";
                cmd.Parameters.AddWithValue("@result", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                int i = Convert.ToInt32(cmd.Parameters["@result"].Value.ToString());
                return i;

            }
            catch
            {
                throw;
            }
            finally
            {
                con.Close();
            }
        }

        public DataSet FetchCargoManifestByID(Business_ObjectLayerClass obj)
        {
            try
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                con.Open();
                SqlCommand cmd = new SqlCommand("CargoManifestsPR", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@uid", obj.Uid);
                cmd.Parameters.AddWithValue("@choice", SqlDbType.VarChar).Value = "2";
                cmd.Parameters.AddWithValue("@result", SqlDbType.Int).Direction = ParameterDirection.Output;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;

            }
            catch
            {
                throw;
            }
            finally
            {
                con.Close();
            }
        }

        public DataSet FetchCargoManifestTotalByID(Business_ObjectLayerClass obj)
        {
            try
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                con.Open();
                SqlCommand cmd = new SqlCommand("CargoManifestsPR", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@uid", obj.Uid);
                cmd.Parameters.AddWithValue("@choice", SqlDbType.VarChar).Value = "7";
                cmd.Parameters.AddWithValue("@result", SqlDbType.Int).Direction = ParameterDirection.Output;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;

            }
            catch
            {
                throw;
            }
            finally
            {
                con.Close();
            }
        }

        public DataSet FetchCargoManifestByManifestID(Business_ObjectLayerClass obj)
        {
            try
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                con.Open();
                SqlCommand cmd = new SqlCommand("CargoManifestsPR", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@menifestid", obj.ManifestID);
                cmd.Parameters.AddWithValue("@choice", SqlDbType.VarChar).Value = "3";
                cmd.Parameters.AddWithValue("@result", SqlDbType.Int).Direction = ParameterDirection.Output;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;

            }
            catch
            {
                throw;
            }
            finally
            {
                con.Close();
            }
        }

        public int UpdateCargoManifest(Business_ObjectLayerClass obj)
        {
            try
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                con.Open();
                SqlCommand cmd = new SqlCommand("CargoManifestsPR", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@menifestid", obj.ManifestID);
                cmd.Parameters.AddWithValue("@manifestno", obj.ManiFestNo);
                cmd.Parameters.AddWithValue("@airwaybill", obj.AirwayBill);
                cmd.Parameters.AddWithValue("@pieces", obj.Pieces);
                cmd.Parameters.AddWithValue("@weight", obj.Weight);
                cmd.Parameters.AddWithValue("@natureofgoods", obj.NatureOfGoods);
                cmd.Parameters.AddWithValue("@useby", obj.UseBy);
                cmd.Parameters.AddWithValue("@owner", obj.Owner);
                cmd.Parameters.AddWithValue("@officialuse", obj.OfficialUse);
                cmd.Parameters.AddWithValue("@MOPER", obj.Operators);
                cmd.Parameters.AddWithValue("@arrivaldate", obj.ArrivalDate);
                cmd.Parameters.AddWithValue("@choice", SqlDbType.VarChar).Value = "4";
                cmd.Parameters.AddWithValue("@result", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                int i = Convert.ToInt32(cmd.Parameters["@result"].Value.ToString());
                return i;

            }
            catch
            {
                throw;
            }
            finally
            {
                con.Close();
            }
        }

        public DataSet FetchAirportName(Business_ObjectLayerClass obj)
        {
            try
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                con.Open();
                SqlCommand cmd = new SqlCommand("AircraftRegistrationPR", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@choice", SqlDbType.VarChar).Value = "5";
                cmd.Parameters.AddWithValue("@result", SqlDbType.Int).Direction = ParameterDirection.Output;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;

            }
            catch
            {
                throw;
            }
            finally
            {
                con.Close();
            }
        }

        public DataSet FetchAirportNameByID(Business_ObjectLayerClass obj)
        {
            try
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                con.Open();
                SqlCommand cmd = new SqlCommand("AircraftRegistrationPR", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@airportid", SqlDbType.Int).Value = obj.AirportID;
                cmd.Parameters.AddWithValue("@choice", SqlDbType.VarChar).Value = "7";
                cmd.Parameters.AddWithValue("@result", SqlDbType.Int).Direction = ParameterDirection.Output;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;

            }
            catch
            {
                throw;
            }
            finally
            {
                con.Close();
            }
        }

        public DataSet ShowBillingInfo(Business_ObjectLayerClass obj)
        {
            try
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                con.Open();
                SqlCommand cmd = new SqlCommand("BillingInformationPR", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@choice", SqlDbType.VarChar).Value = "1";
                cmd.Parameters.AddWithValue("@result", SqlDbType.Int).Direction = ParameterDirection.Output;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;

            }
            catch
            {
                throw;
            }
            finally
            {
                con.Close();
            }
        }

        public int InsertBillingInformation(Business_ObjectLayerClass obj)
        {
            try
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                con.Open();
                SqlCommand cmd = new SqlCommand("BillingInformationPR", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@registrationno", obj.AircraftRegNumber);
                cmd.Parameters.AddWithValue("@aircrafttype", obj.AircraftType);
                cmd.Parameters.AddWithValue("@arrivalfrom", obj.ArrivalFrom);
                cmd.Parameters.AddWithValue("@arrivalflightno", obj.ArrivalFlightNo);
                cmd.Parameters.AddWithValue("@aircraftweight", obj.Weight);
                cmd.Parameters.AddWithValue("@partycode", obj.PartCode);
                cmd.Parameters.AddWithValue("@seatcapacity", obj.SeatCapacity);
                cmd.Parameters.AddWithValue("@arrivaltime", obj.ArrivalTime);
                cmd.Parameters.AddWithValue("@departureto", obj.DepartureTo);
                cmd.Parameters.AddWithValue("@departureflightno", obj.DepartureFlightNo);
                cmd.Parameters.AddWithValue("@numberofpaxinr", obj.NumberOfPaxInr);
                cmd.Parameters.AddWithValue("@numberofpaxdollar", obj.NumberOfPaxDollar);
                cmd.Parameters.AddWithValue("@departuretime", obj.DepartureTime);
                cmd.Parameters.AddWithValue("@uid", obj.Uid);
                cmd.Parameters.AddWithValue("@totalpieces", obj.TotalPieces);
                cmd.Parameters.AddWithValue("@totalrecords", obj.TotalRecords);
                cmd.Parameters.AddWithValue("@billgenerated", obj.BillGenerated);
                cmd.Parameters.AddWithValue("@cash", obj.CashNoncash);
                cmd.Parameters.AddWithValue("@userid", obj.UserID);
                cmd.Parameters.AddWithValue("@ip", obj.Ipaddress);
                cmd.Parameters.AddWithValue("@address", obj.Url);
                cmd.Parameters.AddWithValue("@sau", obj.Sau);
                cmd.Parameters.AddWithValue("@rau", obj.Rau);
                cmd.Parameters.AddWithValue("@station", obj.Station);
                cmd.Parameters.AddWithValue("@partytype", obj.SubPartyType);
                cmd.Parameters.AddWithValue("@currentairport", obj.CurrentAirport);
                cmd.Parameters.AddWithValue("@operator", obj.Operators);
                cmd.Parameters.AddWithValue("@choice", SqlDbType.VarChar).Value = "2";
                cmd.Parameters.AddWithValue("@result", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                int i = Convert.ToInt32(cmd.Parameters["@result"].Value.ToString());
                return i;

            }
            catch
            {
                throw;
            }
            finally
            {
                con.Close();
            }
        }

        public int InsertBillApproval(Business_ObjectLayerClass obj)
        {
            try
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                con.Open();
                SqlCommand cmd = new SqlCommand("BillGeneratePR", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@transactionpwd", obj.Transactionpasswotd1);
                cmd.Parameters.AddWithValue("@userid", obj.Id);
                cmd.Parameters.AddWithValue("@choice", SqlDbType.VarChar).Value = "4";
                cmd.Parameters.AddWithValue("@result", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                int i = Convert.ToInt32(cmd.Parameters["@result"].Value.ToString());
                return i;

            }
            catch
            {
                throw;
            }
            finally
            {
                con.Close();
            }
        }

        public DataSet FetchBillingDetailsByID(Business_ObjectLayerClass obj)
        {
            try
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                con.Open();
                SqlCommand cmd = new SqlCommand("BillingInformationPR", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", obj.BillingID);
                cmd.Parameters.AddWithValue("@choice", SqlDbType.VarChar).Value = "3";
                cmd.Parameters.AddWithValue("@result", SqlDbType.Int).Direction = ParameterDirection.Output;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;

            }
            catch
            {
                throw;
            }
            finally
            {
                con.Close();
            }
        }

        public int DeleteBillingDetails(Business_ObjectLayerClass obj)
        {
            try
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                con.Open();
                SqlCommand cmd = new SqlCommand("BillingInformationPR", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@uid", obj.Uid);
                cmd.Parameters.AddWithValue("@choice", SqlDbType.VarChar).Value = "4";
                cmd.Parameters.AddWithValue("@result", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                int i = Convert.ToInt32(cmd.Parameters["@result"].Value.ToString());
                return i;

            }
            catch
            {
                throw;
            }
            finally
            {
                con.Close();
            }
        }

        public int UpdateBillingInformation(Business_ObjectLayerClass obj)
        {
            try
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                con.Open();
                SqlCommand cmd = new SqlCommand("BillingInformationPR", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", obj.BillingID);
                cmd.Parameters.AddWithValue("@registrationno", obj.AircraftRegNumber);
                cmd.Parameters.AddWithValue("@aircrafttype", obj.AircraftType);
                cmd.Parameters.AddWithValue("@arrivalfrom", obj.ArrivalFrom);
                cmd.Parameters.AddWithValue("@arrivalflightno", obj.ArrivalFlightNo);
                cmd.Parameters.AddWithValue("@aircraftweight", obj.Weight);
                cmd.Parameters.AddWithValue("@partycode", obj.PartCode);
                cmd.Parameters.AddWithValue("@seatcapacity", obj.SeatCapacity);
                cmd.Parameters.AddWithValue("@arrivaltime", obj.ArrivalTime);
                cmd.Parameters.AddWithValue("@departureto", obj.DepartureTo);
                cmd.Parameters.AddWithValue("@departureflightno", obj.DepartureFlightNo);
                cmd.Parameters.AddWithValue("@numberofpaxinr", obj.NumberOfPaxInr);
                cmd.Parameters.AddWithValue("@numberofpaxdollar", obj.NumberOfPaxDollar);
                cmd.Parameters.AddWithValue("@departuretime", obj.DepartureTime);
                cmd.Parameters.AddWithValue("@uid", obj.Uid);
                cmd.Parameters.AddWithValue("@totalpieces", obj.TotalPieces);
                cmd.Parameters.AddWithValue("@totalrecords", obj.TotalRecords);
                //cmd.Parameters.AddWithValue("@billgenerated", obj.BillGenerated);
                cmd.Parameters.AddWithValue("@cash", obj.CashNoncash);
                cmd.Parameters.AddWithValue("@operator", obj.Operators);
                cmd.Parameters.AddWithValue("@choice", SqlDbType.VarChar).Value = "5";
                cmd.Parameters.AddWithValue("@result", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                int i = Convert.ToInt32(cmd.Parameters["@result"].Value.ToString());
                return i;

            }
            catch
            {
                throw;
            }
            finally
            {
                con.Close();
            }
        }

        public int DeleteCargoRecordByManifestID(Business_ObjectLayerClass obj)
        {
            try
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                con.Open();
                SqlCommand cmd = new SqlCommand("CargoManifestsPR", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@menifestid", obj.ManifestID);
                cmd.Parameters.AddWithValue("@choice", SqlDbType.VarChar).Value = "5";
                cmd.Parameters.AddWithValue("@result", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                int i = Convert.ToInt32(cmd.Parameters["@result"].Value.ToString());
                return i;

            }
            catch
            {
                throw;
            }
            finally
            {
                con.Close();
            }
        }

        public int DeleteCargoRecordByUID(Business_ObjectLayerClass obj)
        {
            try
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                con.Open();
                SqlCommand cmd = new SqlCommand("CargoManifestsPR", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@uid", obj.Uid);
                cmd.Parameters.AddWithValue("@choice", SqlDbType.VarChar).Value = "6";
                cmd.Parameters.AddWithValue("@result", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                int i = Convert.ToInt32(cmd.Parameters["@result"].Value.ToString());
                return i;

            }
            catch
            {
                throw;
            }
            finally
            {
                con.Close();
            }
        }

        public int InsertLogInsertFile(Business_ObjectLayerClass obj)
        {
            try
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                con.Open();
                SqlCommand cmd = new SqlCommand("LogFilePR", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@username", obj.UserName);
                cmd.Parameters.AddWithValue("@userid", obj.UserID);
                cmd.Parameters.AddWithValue("@uid", obj.LogUid);
                cmd.Parameters.AddWithValue("@ipaddress", obj.Ipaddress);
                cmd.Parameters.AddWithValue("@action", obj.Action);
                cmd.Parameters.AddWithValue("@address", obj.Url);
                cmd.Parameters.AddWithValue("@datetime", obj.ActionDateTime);
                cmd.Parameters.AddWithValue("@choice", SqlDbType.VarChar).Value = "1";
                cmd.Parameters.AddWithValue("@result", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                int i = Convert.ToInt32(cmd.Parameters["@result"].Value.ToString());
                return i;

            }
            catch
            {
                throw;
            }
            finally
            {
                con.Close();
            }
        }

        public int InsertApproval(Business_ObjectLayerClass obj)
        {
            try
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                con.Open();
                SqlCommand cmd = new SqlCommand("BillGeneratePR", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@choice", SqlDbType.VarChar).Value = "3";
                cmd.Parameters.AddWithValue("@result", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                int i = Convert.ToInt32(cmd.Parameters["@result"].Value.ToString());
                return i;

            }
            catch
            {
                throw;
            }
            finally
            {
                con.Close();
            }
        }

        public int InsertUnApproval(Business_ObjectLayerClass obj)
        {
            try
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                con.Open();
                SqlCommand cmd = new SqlCommand("BillGeneratePR", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@choice", SqlDbType.VarChar).Value = "5";
                cmd.Parameters.AddWithValue("@result", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                int i = Convert.ToInt32(cmd.Parameters["@result"].Value.ToString());
                return i;

            }
            catch
            {
                throw;
            }
            finally
            {
                con.Close();
            }
        }

        public int InsertPartyMaster(Business_ObjectLayerClass obj)
        {
            try
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                con.Open();
                SqlCommand cmd = new SqlCommand("PartyMasterPR", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@partyname", obj.PartyMasterName);
                cmd.Parameters.AddWithValue("@partytype", obj.PartyMasterType);
                cmd.Parameters.AddWithValue("@address", obj.PartyMasterAddress);
                cmd.Parameters.AddWithValue("@town", obj.PartyMasterTown);
                cmd.Parameters.AddWithValue("@state", obj.PartyMasterState);
                cmd.Parameters.AddWithValue("@pin", obj.PartyMasterPin);
                cmd.Parameters.AddWithValue("@emailid", obj.PartyMasterEmail);
                cmd.Parameters.AddWithValue("@contact", obj.PartyMasterContact);
                cmd.Parameters.AddWithValue("@createdby", obj.PartyMasterCreatedBY);
                cmd.Parameters.AddWithValue("@createddate", obj.PartyMasterCreatedDate);
                cmd.Parameters.AddWithValue("@pan", obj.PanNumber);
                cmd.Parameters.AddWithValue("@choice", SqlDbType.VarChar).Value = "1";
                cmd.Parameters.AddWithValue("@result", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                int i = Convert.ToInt32(cmd.Parameters["@result"].Value.ToString());
                return i;

            }
            catch
            {
                throw;
            }
            finally
            {
                con.Close();
            }
        }

        public int InsertContractor(Business_ObjectLayerClass obj)
        {
            try
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                con.Open();
                SqlCommand cmd = new SqlCommand("ContractorPR", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@tendercode", obj.TenderCode);
                cmd.Parameters.AddWithValue("@choice", SqlDbType.VarChar).Value = "1";
                cmd.Parameters.AddWithValue("@result", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                int i = Convert.ToInt32(cmd.Parameters["@result"].Value.ToString());
                return i;

            }
            catch
            {
                throw;
            }
            finally
            {
                con.Close();
            }
        }

        public DataSet FetchMenu(Business_ObjectLayerClass obj)
        {
            try
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                con.Open();
                SqlCommand cmd = new SqlCommand("MenuPR", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@roleid", obj.Roleid);
                cmd.Parameters.AddWithValue("@choice", SqlDbType.VarChar).Value = "1";
                cmd.Parameters.AddWithValue("@result", SqlDbType.Int).Direction = ParameterDirection.Output;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;

            }
            catch
            {
                throw;
            }
            finally
            {
                con.Close();
            }
        }

        public DataSet FetchMenuByID(Business_ObjectLayerClass obj)
        {
            try
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                con.Open();
                SqlCommand cmd = new SqlCommand("MenuPR", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@roleid", obj.Roleid);
                cmd.Parameters.AddWithValue("@id", SqlDbType.Int).Value = obj.MenuID;
                cmd.Parameters.AddWithValue("@choice", SqlDbType.VarChar).Value = "2";
                cmd.Parameters.AddWithValue("@result", SqlDbType.Int).Direction = ParameterDirection.Output;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;

            }
            catch
            {
                throw;
            }
            finally
            {
                con.Close();
            }
        }

        public DataSet FetchPageTitleByID(Business_ObjectLayerClass obj)
        {
            try
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                con.Open();
                SqlCommand cmd = new SqlCommand("MenuPR", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", SqlDbType.Int).Value = obj.PageTitleID;
                cmd.Parameters.AddWithValue("@choice", SqlDbType.VarChar).Value = "3";
                cmd.Parameters.AddWithValue("@result", SqlDbType.Int).Direction = ParameterDirection.Output;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;

            }
            catch
            {
                throw;
            }
            finally
            {
                con.Close();
            }
        }

        public int InsertAircraftType(Business_ObjectLayerClass obj)
        {
            try
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                con.Open();
                SqlCommand cmd = new SqlCommand("AircraftTypePR", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@aircrafttype", obj.AircraftTypeReg);
                cmd.Parameters.AddWithValue("@choice", SqlDbType.VarChar).Value = "1";
                cmd.Parameters.AddWithValue("@result", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                int i = Convert.ToInt32(cmd.Parameters["@result"].Value.ToString());
                return i;

            }
            catch
            {
                throw;
            }
            finally
            {
                con.Close();
            }
        }

        public DataSet CheckWatchHour(Business_ObjectLayerClass obj)
        {
            try
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                con.Open();
                SqlCommand cmd = new SqlCommand("WatchHourTimingPR", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@arrivaldate", obj.ArrivalDate);
                cmd.Parameters.AddWithValue("@choice", SqlDbType.VarChar).Value = "1";
                cmd.Parameters.AddWithValue("@result", SqlDbType.Int).Direction = ParameterDirection.Output;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;

            }
            catch
            {
                throw;
            }
            finally
            {
                con.Close();
            }
        }

        public DataSet ShowWatchHour(Business_ObjectLayerClass obj)
        {
            try
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                con.Open();
                SqlCommand cmd = new SqlCommand("WatchHourTimingPR", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@arrivaldate", obj.ArrivalDate);
                cmd.Parameters.AddWithValue("@choice", SqlDbType.VarChar).Value = "2";
                cmd.Parameters.AddWithValue("@result", SqlDbType.Int).Direction = ParameterDirection.Output;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;

            }
            catch
            {
                throw;
            }
            finally
            {
                con.Close();
            }
        }

        public int InsertWatchHour(Business_ObjectLayerClass obj)
        {
            try
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                con.Open();
                SqlCommand cmd = new SqlCommand("WatchHourTimingPR", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@wftime", obj.InsertWfTime);
                cmd.Parameters.AddWithValue("@wttime", obj.InsertWtTime);
                cmd.Parameters.AddWithValue("@amtperhour", obj.InsertWatchAmount);
                cmd.Parameters.AddWithValue("@arrivaldate", obj.ArrivalDate);
                cmd.Parameters.AddWithValue("@choice", SqlDbType.VarChar).Value = "3";
                cmd.Parameters.AddWithValue("@result", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                int i = Convert.ToInt32(cmd.Parameters["@result"].Value.ToString());
                return i;

            }
            catch
            {
                throw;
            }
            finally
            {
                con.Close();
            }
        }

        public DataSet FetchAeronauticalResults(Business_ObjectLayerClass obj)
        {
            try
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                con.Open();
                SqlCommand cmd = new SqlCommand("AeronauticalServicesPR", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@datefrom", obj.SearchDateFrom);
                cmd.Parameters.AddWithValue("@dateto", obj.SearchDateTo);
                cmd.Parameters.AddWithValue("@category", obj.BillType);
                cmd.Parameters.AddWithValue("@billstatus", obj.BillStatus);
                cmd.Parameters.AddWithValue("@choice", SqlDbType.VarChar).Value = "1";
                cmd.Parameters.AddWithValue("@result", SqlDbType.Int).Direction = ParameterDirection.Output;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;

            }
            catch
            {
                throw;
            }
            finally
            {
                con.Close();
            }
        }

        public DataSet FetchAeronauticalResultsAll(Business_ObjectLayerClass obj)
        {
            try
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                con.Open();
                SqlCommand cmd = new SqlCommand("AeronauticalServicesPR", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@datefrom", obj.SearchDateFrom);
                cmd.Parameters.AddWithValue("@dateto", obj.SearchDateTo);
                cmd.Parameters.AddWithValue("@billstatus", obj.BillStatus);
                cmd.Parameters.AddWithValue("@choice", SqlDbType.VarChar).Value = "2";
                cmd.Parameters.AddWithValue("@result", SqlDbType.Int).Direction = ParameterDirection.Output;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;

            }
            catch
            {
                throw;
            }
            finally
            {
                con.Close();
            }
        }

        public DataSet FetchAeronauticalResultDetails(Business_ObjectLayerClass obj)
        {
            try
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                con.Open();
                SqlCommand cmd = new SqlCommand("AeronauticalServicesPR", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@datefrom", obj.SearchDateFrom);
                cmd.Parameters.AddWithValue("@dateto", obj.SearchDateTo);
                cmd.Parameters.AddWithValue("@billstatus", obj.BillStatus);
                cmd.Parameters.AddWithValue("@partycode", obj.PartyCode);
                cmd.Parameters.AddWithValue("@facilitycode", obj.FacilityCode);
                cmd.Parameters.AddWithValue("@category", obj.BillType);
                //cmd.Parameters.AddWithValue("@choice", SqlDbType.VarChar).Value = "3";
                cmd.Parameters.AddWithValue("@result", SqlDbType.Int).Direction = ParameterDirection.Output;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;

            }
            catch
            {
                throw;
            }
            finally
            {
                con.Close();
            }
        }

        public DataSet FetchUnapproved(Business_ObjectLayerClass obj)
        {
            try
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                con.Open();
                SqlCommand cmd = new SqlCommand("AeronauticalServicesPR", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@choice", SqlDbType.VarChar).Value = "11";
                cmd.Parameters.AddWithValue("@result", SqlDbType.Int).Direction = ParameterDirection.Output;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;

            }
            catch
            {
                throw;
            }
            finally
            {
                con.Close();
            }
        }

        public DataSet Fetchapproved(Business_ObjectLayerClass obj)
        {
            try
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                con.Open();
                SqlCommand cmd = new SqlCommand("BillGeneratePR", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@choice", SqlDbType.VarChar).Value = "6";
                cmd.Parameters.AddWithValue("@result", SqlDbType.Int).Direction = ParameterDirection.Output;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;

            }
            catch
            {
                throw;
            }
            finally
            {
                con.Close();
            }
        }

        public DataSet FetchSlider(Business_ObjectLayerClass obj)
        {
            try
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                con.Open();
                SqlCommand cmd = new SqlCommand("SliderPR", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@choice", SqlDbType.VarChar).Value = "1";
                cmd.Parameters.AddWithValue("@result", SqlDbType.Int).Direction = ParameterDirection.Output;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;

            }
            catch
            {
                throw;
            }
            finally
            {
                con.Close();
            }
        }

        public DataSet FetchPartyTotal(Business_ObjectLayerClass obj)
        {
            try
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                con.Open();
                SqlCommand cmd = new SqlCommand("AeronauticalServicesPR", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@datefrom", obj.SearchDateFrom);
                cmd.Parameters.AddWithValue("@dateto", obj.SearchDateTo);
                cmd.Parameters.AddWithValue("@category", obj.BillType);
                cmd.Parameters.AddWithValue("@billstatus", obj.BillStatus);
                cmd.Parameters.AddWithValue("@choice", SqlDbType.VarChar).Value = "10";
                cmd.Parameters.AddWithValue("@result", SqlDbType.Int).Direction = ParameterDirection.Output;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;

            }
            catch
            {
                throw;
            }
            finally
            {
                con.Close();
            }
        }

        public int InsertBillProcess(Business_ObjectLayerClass obj)
        {
            try
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                con.Open();
                SqlCommand cmd = new SqlCommand("BillGeneratePR", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@category", obj.BillType);
                cmd.Parameters.AddWithValue("@dateto", obj.SearchDateTo);
                cmd.Parameters.AddWithValue("@choice", SqlDbType.VarChar).Value = "1";
                cmd.Parameters.AddWithValue("@result", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                int i = Convert.ToInt32(cmd.Parameters["@result"].Value.ToString());
                return i;

            }
            catch
            {
                throw;
            }
            finally
            {
                con.Close();
            }
        }

        public int CancelUnapproved(Business_ObjectLayerClass obj)
        {
            try
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                con.Open();
                SqlCommand cmd = new SqlCommand("BillGeneratePR", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@choice", SqlDbType.VarChar).Value = "2";
                cmd.Parameters.AddWithValue("@result", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                int i = Convert.ToInt32(cmd.Parameters["@result"].Value.ToString());
                return i;

            }
            catch
            {
                throw;
            }
            finally
            {
                con.Close();
            }
        }

        public int CheckBillGenerated(Business_ObjectLayerClass obj)
        {
            try
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                con.Open();
                SqlCommand cmd = new SqlCommand("AeronauticalServicesPR", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@choice", SqlDbType.VarChar).Value = "12";
                cmd.Parameters.AddWithValue("@result", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                int i = Convert.ToInt32(cmd.Parameters["@result"].Value.ToString());
                return i;

            }
            catch
            {
                throw;
            }
            finally
            {
                con.Close();
            }
        }

        //login panel


        public int Ckecklogin(Business_ObjectLayerClass obj)
        {
            try
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }

                SqlCommand cmd = new SqlCommand("spCheckLogin", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@loginemail", obj.LoginEmailid);
                cmd.Parameters.AddWithValue("@loginpassword", obj.LoginPassword);
                cmd.Parameters.AddWithValue("@loginstatus", obj.Login_status);
                cmd.Parameters.AddWithValue("@Loginstatusid", obj.Loginstatusid);
                cmd.Parameters.AddWithValue("@choice", SqlDbType.VarChar).Value = "1";
                cmd.Parameters.AddWithValue("@result", SqlDbType.Int).Direction = ParameterDirection.Output;
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                int i = Convert.ToInt32(cmd.Parameters["@result"].Value.ToString());
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
        public DataSet Ckecklogin1(Business_ObjectLayerClass obj)
        {
            try
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }

                SqlCommand cmd = new SqlCommand("spCheckLogin", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@loginemail", obj.LoginEmailid);
                cmd.Parameters.AddWithValue("@loginpassword", obj.LoginPassword);
                cmd.Parameters.AddWithValue("@choice", SqlDbType.VarChar).Value = "2";
                cmd.Parameters.AddWithValue("@result", SqlDbType.Int).Direction = ParameterDirection.Output;
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                con.Close();
                DataSet dt = new DataSet();
                da.Fill(dt);
                // int i = Convert.ToInt32(cmd.Parameters["@result"].Value.ToString());
                return dt;

            }
            catch
            {
                throw;
            }
            finally
            {

            }
        }
        public int User_Register(Business_ObjectLayerClass obj)
        {
            try
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                SqlCommand cmd = new SqlCommand("spUserRegistration", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@userid", obj.Txtemail);
                cmd.Parameters.AddWithValue("@empname", obj.Txtfullname);
                cmd.Parameters.AddWithValue("@Roleid", obj.Roleid);
                // cmd.Parameters.AddWithValue("@ddlusertype", obj.DdlUserType);
                cmd.Parameters.AddWithValue("@systempassword", obj.Systempassword);
                cmd.Parameters.AddWithValue("@password", obj.Password);
                cmd.Parameters.AddWithValue("@companyid", obj.Companyid);
                cmd.Parameters.AddWithValue("@choice", SqlDbType.VarChar).Value = "1";
                cmd.Parameters.AddWithValue("@result", SqlDbType.Int).Direction = ParameterDirection.Output;
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                int i = Convert.ToInt32(cmd.Parameters["@result"].Value.ToString());
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
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                SqlCommand cmd = new SqlCommand("spsetting", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Companyid", obj.Companyid);
                cmd.Parameters.AddWithValue("@Setting_signature", obj.Setting_signature1);
                cmd.Parameters.AddWithValue("@choice", SqlDbType.VarChar).Value = "1";
                cmd.Parameters.AddWithValue("@result", SqlDbType.Int).Direction = ParameterDirection.Output;
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                int i = Convert.ToInt32(cmd.Parameters["@result"].Value.ToString());
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
        public DataSet display_ddl(Business_ObjectLayerClass obj)
        {
            try
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }

                SqlCommand cmd = new SqlCommand("FillDropDown", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CompanyId", obj.Companyid);
                cmd.Parameters.AddWithValue("@FormName", obj.Pathurl);
                cmd.Parameters.AddWithValue("@ControlName", obj.DdlControlName);
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);

                con.Close();
                DataSet dt = new DataSet();
                da.Fill(dt);
                // Convert.ToInt32(cmd.Parameters["@result"].Value.ToString());
                return dt;

            }
            catch
            {
                throw;
            }
            finally
            {

            }
        }
        public DataSet display_ddl1(Business_ObjectLayerClass obj)
        {
            try
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }

                SqlCommand cmd = new SqlCommand("spUserRegistration", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@choice", SqlDbType.VarChar).Value = "9";
                cmd.Parameters.AddWithValue("@result", SqlDbType.Int).Direction = ParameterDirection.Output;
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);

                con.Close();
                DataSet dt = new DataSet();
                da.Fill(dt);
                // Convert.ToInt32(cmd.Parameters["@result"].Value.ToString());
                return dt;

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
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }

                SqlCommand cmd = new SqlCommand("spsetting", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CompanyId", obj.Companyid);
                cmd.Parameters.AddWithValue("@choice", SqlDbType.VarChar).Value = "2";
                cmd.Parameters.AddWithValue("@result", SqlDbType.Int).Direction = ParameterDirection.Output;
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);

                con.Close();
                DataSet dt = new DataSet();
                da.Fill(dt);
                return dt;

            }
            catch
            {
                throw;
            }
            finally
            {

            }
        }
        public DataSet Fetch_AllRegisterUsers(Business_ObjectLayerClass obj)
        {
            try
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }

                SqlCommand cmd = new SqlCommand("spUserRegistration", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CompanyId1", obj.Companyid);
                //cmd.Parameters.AddWithValue("@FormName", obj.Pathurl);
                //cmd.Parameters.AddWithValue("@ControlName", obj.DdlControlName);
                cmd.Parameters.AddWithValue("@choice", SqlDbType.VarChar).Value = "4";
                cmd.Parameters.AddWithValue("@result", SqlDbType.Int).Direction = ParameterDirection.Output;
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);

                con.Close();
                DataSet dt = new DataSet();
                da.Fill(dt);
                // Convert.ToInt32(cmd.Parameters["@result"].Value.ToString());
                return dt;

            }
            catch
            {
                throw;
            }
            finally
            {

            }
        }
        public DataSet send_information(int companyid)
        {
            try
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }

                SqlCommand cmd = new SqlCommand("spUserRegistration", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@companyid1", companyid);
                cmd.Parameters.AddWithValue("@choice", SqlDbType.VarChar).Value = "2";
                cmd.Parameters.AddWithValue("@result", SqlDbType.Int).Direction = ParameterDirection.Output;
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet dt = new DataSet();
                con.Close();
                da.Fill(dt);
                // int i = Convert.ToInt32(cmd.Parameters["@result"].Value.ToString());
                return dt;

            }
            catch
            {
                throw;
            }
            finally
            {

            }
        }
        public int Reset_Password(Business_ObjectLayerClass obj)
        {
            try
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }

                SqlCommand cmd = new SqlCommand("spUserRegistration", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@newpassword", obj.Newpassword);
                cmd.Parameters.AddWithValue("@id", obj.ResetPassworduserid1);
                cmd.Parameters.AddWithValue("@logoutstatus", obj.Logout_status);
                //cmd.Parameters.AddWithValue("@ddlsubparty", obj.DdlSubParty);
                //cmd.Parameters.AddWithValue("@ddlusertype", obj.DdlUserType);
                //cmd.Parameters.AddWithValue("@systempassword", obj.Systempassword);
                //cmd.Parameters.AddWithValue("@companyid", obj.Companyid);
                cmd.Parameters.AddWithValue("@choice", SqlDbType.VarChar).Value = "3";
                cmd.Parameters.AddWithValue("@result", SqlDbType.Int).Direction = ParameterDirection.Output;
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                int i = Convert.ToInt32(cmd.Parameters["@result"].Value.ToString());
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
        public int Delete_RegisterUser(Business_ObjectLayerClass obj)
        {
            try
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }

                SqlCommand cmd = new SqlCommand("spUserRegistration", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@deleteid", obj.Deleteuserid);
                cmd.Parameters.AddWithValue("@choice", SqlDbType.VarChar).Value = "5";
                cmd.Parameters.AddWithValue("@result", SqlDbType.Int).Direction = ParameterDirection.Output;
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                int i = Convert.ToInt32(cmd.Parameters["@result"].Value.ToString());
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
        public DataSet check_link(Business_ObjectLayerClass obj)
        {
            try
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }

                SqlCommand cmd = new SqlCommand("spUserRegistration", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@key", obj.Key);
                cmd.Parameters.AddWithValue("@choice", SqlDbType.VarChar).Value = "8";
                cmd.Parameters.AddWithValue("@result", SqlDbType.Int).Direction = ParameterDirection.Output;
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet dt = new DataSet();
                con.Close();
                da.Fill(dt);
                // int i = Convert.ToInt32(cmd.Parameters["@result"].Value.ToString());
                return dt;

            }
            catch
            {
                throw;
            }
            finally
            {

            }
        }
        public DataSet Edit_RegisterUser(Business_ObjectLayerClass obj)
        {
            try
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }

                SqlCommand cmd = new SqlCommand("spUserRegistration", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@editid", obj.Edituserid1);
                cmd.Parameters.AddWithValue("@choice", SqlDbType.VarChar).Value = "6";
                cmd.Parameters.AddWithValue("@result", SqlDbType.Int).Direction = ParameterDirection.Output;
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet dt = new DataSet();
                con.Close();
                da.Fill(dt);
                // int i = Convert.ToInt32(cmd.Parameters["@result"].Value.ToString());
                return dt;

            }
            catch
            {
                throw;
            }
            finally
            {

            }
        }
        public int update_RegisterUser(Business_ObjectLayerClass obj)
        {
            try
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }

                SqlCommand cmd = new SqlCommand("spUserRegistration", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Uuserid", obj.Txtemail);
                cmd.Parameters.AddWithValue("@Uempname", obj.Txtfullname);
                cmd.Parameters.AddWithValue("@Roleid", obj.Roleid);
                //cmd.Parameters.AddWithValue("@Uddlusertype", obj.DdlUserType);
                cmd.Parameters.AddWithValue("@Ueditid", obj.Edituserid1);
                cmd.Parameters.AddWithValue("@companyid", obj.Companyid);
                cmd.Parameters.AddWithValue("@choice", SqlDbType.VarChar).Value = "7";
                cmd.Parameters.AddWithValue("@result", SqlDbType.Int).Direction = ParameterDirection.Output;
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                int i = Convert.ToInt32(cmd.Parameters["@result"].Value.ToString());
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
        public int login_status(Business_ObjectLayerClass obj)
        {
            try
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }

                SqlCommand cmd = new SqlCommand("spUserRegistration", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@logoutstatus", obj.Logout_status);
                cmd.Parameters.AddWithValue("@logid", obj.Logid);
                // cmd.Parameters.AddWithValue("@companyid", obj.Companyid);
                cmd.Parameters.AddWithValue("@choice", SqlDbType.VarChar).Value = "10";
                cmd.Parameters.AddWithValue("@result", SqlDbType.Int).Direction = ParameterDirection.Output;
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                int i = Convert.ToInt32(cmd.Parameters["@result"].Value.ToString());
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
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }

                SqlCommand cmd = new SqlCommand("spagency", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Angency_address", obj.Angency_address);
                cmd.Parameters.AddWithValue("@Agency_CIN", obj.Agency_CIN);
                cmd.Parameters.AddWithValue("@Agency_emailid", obj.Agency_emailid);
                cmd.Parameters.AddWithValue("@Agency_mobile", obj.Agency_mobile);
                cmd.Parameters.AddWithValue("@Agency_PAN", obj.Agency_PAN);
                cmd.Parameters.AddWithValue("@CompanyId", obj.Companyid);
                cmd.Parameters.AddWithValue("@Angency_name", obj.Angency_name);
                cmd.Parameters.AddWithValue("@Agency_Type_id", obj.Agency_Type_id);
                cmd.Parameters.AddWithValue("@choice", SqlDbType.VarChar).Value = "1";
                cmd.Parameters.AddWithValue("@result", SqlDbType.Int).Direction = ParameterDirection.Output;
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                int i = Convert.ToInt32(cmd.Parameters["@result"].Value.ToString());
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
        public DataSet display_dropdown(Business_ObjectLayerClass obj)
        {
            try
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }

                SqlCommand cmd = new SqlCommand("FetchDropDown", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CompanyId", obj.Companyid);
                cmd.Parameters.AddWithValue("@choice", SqlDbType.VarChar).Value = "1";
                cmd.Parameters.AddWithValue("@result", SqlDbType.Int).Direction = ParameterDirection.Output;
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);

                con.Close();
                DataSet dt = new DataSet();
                da.Fill(dt);
                // Convert.ToInt32(cmd.Parameters["@result"].Value.ToString());
                return dt;

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
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }

                SqlCommand cmd = new SqlCommand("spagency", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Agency_Type_id", obj.Agency_Type_id);
                cmd.Parameters.AddWithValue("@CompanyId", obj.Companyid);
                cmd.Parameters.AddWithValue("@choice", SqlDbType.VarChar).Value = "2";
                cmd.Parameters.AddWithValue("@result", SqlDbType.Int).Direction = ParameterDirection.Output;
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                con.Close();
                DataSet dt = new DataSet();
                da.Fill(dt);
                return dt;

            }
            catch
            {
                throw;
            }
            finally
            {

            }
        }
        public DataSet display_dropdown2(Business_ObjectLayerClass obj)
        {
            try
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }

                SqlCommand cmd = new SqlCommand("FetchDropDown", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CompanyId", obj.Companyid);
                cmd.Parameters.AddWithValue("@Ddlselectedvalue", obj.Ddlselectedvalue);
                //cmd.Parameters.AddWithValue("@ControlName", obj.DdlControlName);
                cmd.Parameters.AddWithValue("@choice", SqlDbType.VarChar).Value = "2";
                cmd.Parameters.AddWithValue("@result", SqlDbType.Int).Direction = ParameterDirection.Output;
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);

                con.Close();
                DataSet dt = new DataSet();
                da.Fill(dt);
                // Convert.ToInt32(cmd.Parameters["@result"].Value.ToString());
                return dt;

            }
            catch
            {
                throw;
            }
            finally
            {

            }
        }
        public DataSet display_dropdown3(Business_ObjectLayerClass obj)
        {
            try
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }

                SqlCommand cmd = new SqlCommand("FetchDropDown", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CompanyId", obj.Companyid);
                cmd.Parameters.AddWithValue("@Ddlselectedvalue", obj.Ddlselectedvalue);
                //cmd.Parameters.AddWithValue("@FormName", obj.Pathurl);
                //cmd.Parameters.AddWithValue("@ControlName", obj.DdlControlName);
                cmd.Parameters.AddWithValue("@choice", SqlDbType.VarChar).Value = "3";
                cmd.Parameters.AddWithValue("@result", SqlDbType.Int).Direction = ParameterDirection.Output;
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);

                con.Close();
                DataSet dt = new DataSet();
                da.Fill(dt);
                // Convert.ToInt32(cmd.Parameters["@result"].Value.ToString());
                return dt;

            }
            catch
            {
                throw;
            }
            finally
            {

            }
        }
        public DataSet display_dropdown4(Business_ObjectLayerClass obj)
        {
            try
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }

                SqlCommand cmd = new SqlCommand("FetchDropDown", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CompanyId", obj.Companyid);
                cmd.Parameters.AddWithValue("@Ddlselectedvalue", obj.Ddlselectedvalue);
                //cmd.Parameters.AddWithValue("@FormName", obj.Pathurl);
                //cmd.Parameters.AddWithValue("@ControlName", obj.DdlControlName);
                cmd.Parameters.AddWithValue("@choice", SqlDbType.VarChar).Value = "4";
                cmd.Parameters.AddWithValue("@result", SqlDbType.Int).Direction = ParameterDirection.Output;
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);

                con.Close();
                DataSet dt = new DataSet();
                da.Fill(dt);
                // Convert.ToInt32(cmd.Parameters["@result"].Value.ToString());
                return dt;

            }
            catch
            {
                throw;
            }
            finally
            {

            }
        }
        public DataSet display_dropdown5(Business_ObjectLayerClass obj)
        {
            try
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }

                SqlCommand cmd = new SqlCommand("FetchDropDown", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CompanyId", obj.Companyid);
                cmd.Parameters.AddWithValue("@Ddlselectedvalue", obj.Ddlselectedvalue);
                //cmd.Parameters.AddWithValue("@FormName", obj.Pathurl);
                //cmd.Parameters.AddWithValue("@ControlName", obj.DdlControlName);
                cmd.Parameters.AddWithValue("@choice", SqlDbType.VarChar).Value = "5";
                cmd.Parameters.AddWithValue("@result", SqlDbType.Int).Direction = ParameterDirection.Output;
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);

                con.Close();
                DataSet dt = new DataSet();
                da.Fill(dt);
                // Convert.ToInt32(cmd.Parameters["@result"].Value.ToString());
                return dt;

            }
            catch
            {
                throw;
            }
            finally
            {

            }
        }
        public DataSet display_dropdown6(Business_ObjectLayerClass obj)
        {
            try
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }

                SqlCommand cmd = new SqlCommand("FetchDropDown", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CompanyId", obj.Companyid);
                cmd.Parameters.AddWithValue("@Ddlselectedvalue", obj.Ddlselectedvalue);
                //cmd.Parameters.AddWithValue("@FormName", obj.Pathurl);
                //cmd.Parameters.AddWithValue("@ControlName", obj.DdlControlName);
                cmd.Parameters.AddWithValue("@choice", SqlDbType.VarChar).Value = "6";
                cmd.Parameters.AddWithValue("@result", SqlDbType.Int).Direction = ParameterDirection.Output;
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);

                con.Close();
                DataSet dt = new DataSet();
                da.Fill(dt);
                // Convert.ToInt32(cmd.Parameters["@result"].Value.ToString());
                return dt;

            }
            catch
            {
                throw;
            }
            finally
            {

            }
        }
        public DataSet display_dropdown7(Business_ObjectLayerClass obj)
        {
            try
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }

                SqlCommand cmd = new SqlCommand("FetchDropDown", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CompanyId", obj.Companyid);
                cmd.Parameters.AddWithValue("@Ddlselectedvalue", obj.Ddlselectedvalue);
                //cmd.Parameters.AddWithValue("@FormName", obj.Pathurl);
                //cmd.Parameters.AddWithValue("@ControlName", obj.DdlControlName);
                cmd.Parameters.AddWithValue("@choice", SqlDbType.VarChar).Value = "7";
                cmd.Parameters.AddWithValue("@result", SqlDbType.Int).Direction = ParameterDirection.Output;
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);

                con.Close();
                DataSet dt = new DataSet();
                da.Fill(dt);
                // Convert.ToInt32(cmd.Parameters["@result"].Value.ToString());
                return dt;

            }
            catch
            {
                throw;
            }
            finally
            {

            }
        }
        public DataSet display_dropdown8(Business_ObjectLayerClass obj)
        {
            try
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }

                SqlCommand cmd = new SqlCommand("FetchDropDown", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CompanyId", obj.Companyid);
                cmd.Parameters.AddWithValue("@Ddlselectedvalue", obj.Ddlselectedvalue);
                //cmd.Parameters.AddWithValue("@FormName", obj.Pathurl);
                //cmd.Parameters.AddWithValue("@ControlName", obj.DdlControlName);
                cmd.Parameters.AddWithValue("@choice", SqlDbType.VarChar).Value = "8";
                cmd.Parameters.AddWithValue("@result", SqlDbType.Int).Direction = ParameterDirection.Output;
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);

                con.Close();
                DataSet dt = new DataSet();
                da.Fill(dt);
                // Convert.ToInt32(cmd.Parameters["@result"].Value.ToString());
                return dt;

            }
            catch
            {
                throw;
            }
            finally
            {

            }
        }
        public int exit_browser(Business_ObjectLayerClass obj)
        {
            try
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                con.Open();
                SqlCommand cmd = new SqlCommand("spCheckLogin", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@exitlogout", obj.Exitlogout);
                cmd.Parameters.AddWithValue("@choice", SqlDbType.VarChar).Value = "3";
                cmd.Parameters.AddWithValue("@result", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                int i = Convert.ToInt32(cmd.Parameters["@result"].Value.ToString());
                return i;

            }
            catch
            {
                throw;
            }
            finally
            {
                con.Close();
            }
        }
        public DataSet display_FacilityMaster(Business_ObjectLayerClass obj)
        {
            try
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }

                SqlCommand cmd = new SqlCommand("SPWorkoutMaster", con);
                cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Parameters.AddWithValue("@CompanyId", obj.Companyid);
                //cmd.Parameters.AddWithValue("@FormName", obj.Pathurl);
                //cmd.Parameters.AddWithValue("@ControlName", obj.DdlControlName);
                cmd.Parameters.AddWithValue("@choice", SqlDbType.VarChar).Value = "1";
                cmd.Parameters.AddWithValue("@result", SqlDbType.Int).Direction = ParameterDirection.Output;
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);

                con.Close();
                DataSet dt = new DataSet();
                da.Fill(dt);
                // Convert.ToInt32(cmd.Parameters["@result"].Value.ToString());
                return dt;

            }
            catch
            {
                throw;
            }
            finally
            {

            }
        }
        public DataSet display_PartyName(Business_ObjectLayerClass obj)
        {
            try
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }

                SqlCommand cmd = new SqlCommand("SPWorkoutMaster", con);
                cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Parameters.AddWithValue("@CompanyId", obj.Companyid);
                //cmd.Parameters.AddWithValue("@FormName", obj.Pathurl);
                //cmd.Parameters.AddWithValue("@ControlName", obj.DdlControlName);
                cmd.Parameters.AddWithValue("@choice", SqlDbType.VarChar).Value = "2";
                cmd.Parameters.AddWithValue("@result", SqlDbType.Int).Direction = ParameterDirection.Output;
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                con.Close();
                DataSet dt = new DataSet();
                da.Fill(dt);
                return dt;

            }
            catch
            {
                throw;
            }
            finally
            {

            }
        }
        public int insert_WorkOder(Business_ObjectLayerClass obj)
        {
            try
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }

                SqlCommand cmd = new SqlCommand("SPWorkoutMaster", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Water1", obj.Water1);
                cmd.Parameters.AddWithValue("@FixLicenseFee", obj.FixLicenseFee);
                //  cmd.Parameters.AddWithValue("@SecurityDeposite1", obj.SecurityDeposite1);
                cmd.Parameters.AddWithValue("@companyID", obj.Companyid);
                cmd.Parameters.AddWithValue("@RefrenceDate1", obj.RefrenceDate1);
                cmd.Parameters.AddWithValue("@Electricity1", obj.Electricity1);
                cmd.Parameters.AddWithValue("@ContractPeriodFrom1", obj.ContractPeriodFrom1);
                cmd.Parameters.AddWithValue("@ContractPeriodTo1", obj.ContractPeriodTo1);
                cmd.Parameters.AddWithValue("@Location1", obj.Location1);
                cmd.Parameters.AddWithValue("@Rate1", obj.Rate1);
                // cmd.Parameters.AddWithValue("@AdvanceLincense1", obj.AdvanceLincense1);
                cmd.Parameters.AddWithValue("@PartyName1", obj.PartytypeName1);
                cmd.Parameters.AddWithValue("@FacilityMaster1", obj.FacilityMaster1);
                cmd.Parameters.AddWithValue("@BillPeriod1", obj.BillPeriod1);
                cmd.Parameters.AddWithValue("@AreaUnit1", obj.AreaUnit1);
                cmd.Parameters.AddWithValue("@RefrenceNo1", obj.RefrenceNo1);
                cmd.Parameters.AddWithValue("@AreaUnitQuantity", obj.AreaUnitQuantity1);
                cmd.Parameters.AddWithValue("@PdfFile", obj.PdfFile);
                cmd.Parameters.AddWithValue("@narration", obj.RevenueNarration);
                cmd.Parameters.AddWithValue("@choice", SqlDbType.VarChar).Value = "3";
                cmd.Parameters.AddWithValue("@result", SqlDbType.Int).Direction = ParameterDirection.Output;
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                int i = Convert.ToInt32(cmd.Parameters["@result"].Value.ToString());
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
        public DataSet Display_RevenueDetails(Business_ObjectLayerClass obj)
        {
            try
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }

                SqlCommand cmd = new SqlCommand("SPWorkoutMaster", con);
                cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Parameters.AddWithValue("@CompanyId", obj.Companyid);
                //cmd.Parameters.AddWithValue("@FormName", obj.Pathurl);
                //cmd.Parameters.AddWithValue("@ControlName", obj.DdlControlName);
                cmd.Parameters.AddWithValue("@choice", SqlDbType.VarChar).Value = "8";
                cmd.Parameters.AddWithValue("@result", SqlDbType.Int).Direction = ParameterDirection.Output;
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                con.Close();
                DataSet dt = new DataSet();
                da.Fill(dt);
                return dt;

            }
            catch
            {
                throw;
            }
            finally
            {

            }
        }
        public int Delete_RevenueUser(Business_ObjectLayerClass obj)
        {
            try
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }

                SqlCommand cmd = new SqlCommand("SPWorkoutMaster", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@RevenueStatus", obj.RevenueStatus);
                cmd.Parameters.AddWithValue("@Revenueid1", obj.Revenueid1);
                cmd.Parameters.AddWithValue("@choice", SqlDbType.VarChar).Value = "5";
                cmd.Parameters.AddWithValue("@result", SqlDbType.Int).Direction = ParameterDirection.Output;
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                int i = Convert.ToInt32(cmd.Parameters["@result"].Value.ToString());
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
        public int Update_WorkOder(Business_ObjectLayerClass obj)
        {
            try
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }

                SqlCommand cmd = new SqlCommand("SPWorkoutMaster", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Water1", obj.Water1);
                cmd.Parameters.AddWithValue("@FixLicenseFee", obj.FixLicenseFee);
                // cmd.Parameters.AddWithValue("@SecurityDeposite1", obj.SecurityDeposite1);
                cmd.Parameters.AddWithValue("@RefrenceDate1", obj.RefrenceDate1);
                cmd.Parameters.AddWithValue("@Electricity1", obj.Electricity1);
                cmd.Parameters.AddWithValue("@ContractPeriodFrom1", obj.ContractPeriodFrom1);
                cmd.Parameters.AddWithValue("@ContractPeriodTo1", obj.ContractPeriodTo1);
                cmd.Parameters.AddWithValue("@Location1", obj.Location1);
                cmd.Parameters.AddWithValue("@Rate1", obj.Rate1);
                // cmd.Parameters.AddWithValue("@AdvanceLincense1", obj.AdvanceLincense1);
                cmd.Parameters.AddWithValue("@PartyName1", obj.PartytypeName1);
                cmd.Parameters.AddWithValue("@FacilityMaster1", obj.FacilityMaster1);
                cmd.Parameters.AddWithValue("@BillPeriod1", obj.BillPeriod1);
                cmd.Parameters.AddWithValue("@AreaUnit1", obj.AreaUnit1);
                cmd.Parameters.AddWithValue("@RefrenceNo1", obj.RefrenceNo1);
                cmd.Parameters.AddWithValue("@AreaUnitQuantity", obj.AreaUnitQuantity1);
                cmd.Parameters.AddWithValue("@Edituserid1", obj.Edituserid1);
                cmd.Parameters.AddWithValue("@PdfFile", obj.PdfFile);
                cmd.Parameters.AddWithValue("@narration", obj.RevenueNarration);
                cmd.Parameters.AddWithValue("@choice", SqlDbType.VarChar).Value = "6";
                cmd.Parameters.AddWithValue("@result", SqlDbType.Int).Direction = ParameterDirection.Output;
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                int i = Convert.ToInt32(cmd.Parameters["@result"].Value.ToString());
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
        public DataSet Edit_RevenueWorkout(Business_ObjectLayerClass obj)
        {
            try
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }

                SqlCommand cmd = new SqlCommand("SPWorkoutMaster", con);
                cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Parameters.AddWithValue("@CompanyId", obj.Companyid);
                // cmd.Parameters.AddWithValue("@FormName", obj.Pathurl);
                cmd.Parameters.AddWithValue("@EditRevenueid1", obj.EditRevenueid1);
                cmd.Parameters.AddWithValue("@choice", SqlDbType.VarChar).Value = "7";
                cmd.Parameters.AddWithValue("@result", SqlDbType.Int).Direction = ParameterDirection.Output;
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                con.Close();
                DataSet dt = new DataSet();
                da.Fill(dt);
                return dt;

            }
            catch
            {
                throw;
            }
            finally
            {

            }
        }
        public DataSet Sort_RevenueList(Business_ObjectLayerClass obj)
        {
            try
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }

                SqlCommand cmd = new SqlCommand("SPWorkoutMaster", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@SortingRevenueList1", SqlDbType.VarChar).Value = obj.SortingRevenueList1;
                cmd.Parameters.AddWithValue("@choice", SqlDbType.VarChar).Value = "8";
                cmd.Parameters.AddWithValue("@result", SqlDbType.Int).Direction = ParameterDirection.Output;
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                con.Close();
                DataSet dt = new DataSet();
                da.Fill(dt);
                return dt;

            }
            catch
            {
                throw;
            }
            finally
            {

            }
        }
        public DataSet display_sorting(Business_ObjectLayerClass obj)
        {
            try
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }

                SqlCommand cmd = new SqlCommand("SPWorkoutMaster", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@choice", SqlDbType.VarChar).Value = "13";
                cmd.Parameters.AddWithValue("@result", SqlDbType.Int).Direction = ParameterDirection.Output;
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                con.Close();
                DataSet dt = new DataSet();
                da.Fill(dt);
                return dt;

            }
            catch
            {
                throw;
            }
            finally
            {

            }
        }
        public DataSet Display_RevenueWorkout(Business_ObjectLayerClass obj)
        {
            try
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }

                SqlCommand cmd = new SqlCommand("SPNTBilling", con);
                cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Parameters.AddWithValue("@CompanyId", obj.Companyid);
                cmd.Parameters.AddWithValue("@facilityname", obj.Facilityname);
                cmd.Parameters.AddWithValue("@date", obj.Contract);
                cmd.Parameters.AddWithValue("@choice", SqlDbType.VarChar).Value = "1";
                cmd.Parameters.AddWithValue("@result", SqlDbType.Int).Direction = ParameterDirection.Output;
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                con.Close();
                DataSet dt = new DataSet();
                da.Fill(dt);
                return dt;

            }
            catch
            {
                throw;
            }
            finally
            {

            }
        }
        //--------------NEW---------------------

        public int Insert_NtBilling(Business_ObjectLayerClass obj)
        {
            try
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }

                SqlCommand cmd = new SqlCommand("SPNTBilling", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Ntbilling", obj.Ntbillingid);
                cmd.Parameters.AddWithValue("@Perioddate", obj.Perioddate);
                cmd.Parameters.AddWithValue("@Companyid", obj.Companyid);
                cmd.Parameters.AddWithValue("@choice", SqlDbType.VarChar).Value = "2";
                cmd.Parameters.AddWithValue("@result", SqlDbType.Int).Direction = ParameterDirection.Output;
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                int i = Convert.ToInt32(cmd.Parameters["@result"].Value.ToString());
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
        public DataSet Display_NTBilling(Business_ObjectLayerClass obj)
        {
            try
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }

                SqlCommand cmd = new SqlCommand("SPNTBilling", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@companyid", obj.Companyid);
                cmd.Parameters.AddWithValue("@approved", obj.Active);
                //cmd.Parameters.AddWithValue("@FormName", obj.Pathurl);
                //cmd.Parameters.AddWithValue("@ControlName", obj.DdlControlName);
                cmd.Parameters.AddWithValue("@choice", SqlDbType.VarChar).Value = "3";
                cmd.Parameters.AddWithValue("@result", SqlDbType.Int).Direction = ParameterDirection.Output;
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                con.Close();
                DataSet dt = new DataSet();
                da.Fill(dt);
                return dt;

            }
            catch
            {
                throw;
            }
            finally
            {

            }
        }
        public DataSet display_ddlFacilityName(Business_ObjectLayerClass obj)
        {
            try
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }

                SqlCommand cmd = new SqlCommand("SPNTBilling", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@choice", SqlDbType.VarChar).Value = "4";
                cmd.Parameters.AddWithValue("@result", SqlDbType.Int).Direction = ParameterDirection.Output;
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                con.Close();
                DataSet dt = new DataSet();
                da.Fill(dt);
                return dt;

            }
            catch
            {
                throw;
            }
            finally
            {

            }
        }
        public DataSet display_NTBilling(Business_ObjectLayerClass obj)
        {
            try
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }

                SqlCommand cmd = new SqlCommand("SPNTBilling", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", SqlDbType.VarChar).Value = obj.DisplayNTBillingID1;
                cmd.Parameters.AddWithValue("@choice", SqlDbType.VarChar).Value = "5";
                cmd.Parameters.AddWithValue("@result", SqlDbType.Int).Direction = ParameterDirection.Output;
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                con.Close();
                DataSet dt = new DataSet();
                da.Fill(dt);
                return dt;

            }
            catch
            {
                throw;
            }
            finally
            {

            }
        }
        public int update_NTBilling(Business_ObjectLayerClass obj)
        {
            try
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }

                SqlCommand cmd = new SqlCommand("SPNTBilling", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@WaterRate1", obj.WaterRate1);
                cmd.Parameters.AddWithValue("@WaterUnit1", obj.WaterUnit1);
                cmd.Parameters.AddWithValue("@ElectrictyRate1", obj.ElectrictyRate1);
                cmd.Parameters.AddWithValue("@ElectrictyUnit1", obj.ElectrictyUnit1);
                cmd.Parameters.AddWithValue("@AreaQty1", obj.AreaQty1);
                cmd.Parameters.AddWithValue("@AreaRate1", obj.AreaRate1);
                cmd.Parameters.AddWithValue("@ElectricityAmount1", obj.ElectricityAmount1);
                cmd.Parameters.AddWithValue("@WaterAmount1", obj.WaterAmount1);
                cmd.Parameters.AddWithValue("@AreaAmount1", obj.AreaAmount1);
                cmd.Parameters.AddWithValue("@NTBillingUpdateID", obj.NTBillingID1);
                cmd.Parameters.AddWithValue("@choice", SqlDbType.VarChar).Value = "6";
                cmd.Parameters.AddWithValue("@result", SqlDbType.Int).Direction = ParameterDirection.Output;
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                int i = Convert.ToInt32(cmd.Parameters["@result"].Value.ToString());
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
        public int updateNTBilling_Approved(Business_ObjectLayerClass obj)
        {
            try
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }

                SqlCommand cmd = new SqlCommand("SPNTBilling", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@WaterRate1", obj.WaterRate1);
                cmd.Parameters.AddWithValue("@WaterUnit1", obj.WaterUnit1);
                cmd.Parameters.AddWithValue("@ElectrictyRate1", obj.ElectrictyRate1);
                cmd.Parameters.AddWithValue("@ElectrictyUnit1", obj.ElectrictyUnit1);
                cmd.Parameters.AddWithValue("@AreaQty1", obj.AreaQty1);
                cmd.Parameters.AddWithValue("@AreaRate1", obj.AreaRate1);
                cmd.Parameters.AddWithValue("@ElectricityAmount1", obj.ElectricityAmount1);
                cmd.Parameters.AddWithValue("@WaterAmount1", obj.WaterAmount1);
                cmd.Parameters.AddWithValue("@AreaAmount1", obj.AreaAmount1);
                cmd.Parameters.AddWithValue("@NTBillingUpdateID", obj.NTBillingID1);
                cmd.Parameters.AddWithValue("@active", "1");
                cmd.Parameters.AddWithValue("@choice", SqlDbType.VarChar).Value = "6";
                cmd.Parameters.AddWithValue("@result", SqlDbType.Int).Direction = ParameterDirection.Output;
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                int i = Convert.ToInt32(cmd.Parameters["@result"].Value.ToString());
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
        public DataSet Display_Approved(Business_ObjectLayerClass obj)
        {
            try
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }

                SqlCommand cmd = new SqlCommand("SPNTBilling", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@companyid", SqlDbType.VarChar).Value = obj.Companyid;
                cmd.Parameters.AddWithValue("@choice", SqlDbType.VarChar).Value = "7";
                cmd.Parameters.AddWithValue("@result", SqlDbType.Int).Direction = ParameterDirection.Output;
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                con.Close();
                DataSet dt = new DataSet();
                da.Fill(dt);
                return dt;

            }
            catch
            {
                throw;
            }
            finally
            {

            }
        }

        public int Approved_Bill(Business_ObjectLayerClass obj)
        {
            try
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }

                SqlCommand cmd = new SqlCommand("SPEntryPass", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Transactionpasswotd1", obj.Transactionpasswotd1);
                cmd.Parameters.AddWithValue("@Approveid", obj.Approveid);
                cmd.Parameters.AddWithValue("@Selectapssno", obj.Selectapssno);
                cmd.Parameters.AddWithValue("@Companyid", obj.Companyid);
                cmd.Parameters.AddWithValue("@choice", SqlDbType.VarChar).Value = "8";
                cmd.Parameters.AddWithValue("@result", SqlDbType.Int).Direction = ParameterDirection.Output;
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                int i = Convert.ToInt32(cmd.Parameters["@result"].Value.ToString());
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
        public int Approve_pass(Business_ObjectLayerClass obj)
        {
            try
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }

                SqlCommand cmd = new SqlCommand("SPEntryPass", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Transactionpasswotd1", obj.Transactionpasswotd1);
                cmd.Parameters.AddWithValue("@Approveid", obj.Approveid);
                cmd.Parameters.AddWithValue("@Reject_remark", obj.Reject_remark);
                cmd.Parameters.AddWithValue("@Passfee", obj.Passfee);
                cmd.Parameters.AddWithValue("@FeeExemption1", obj.FeeExemption1);
                cmd.Parameters.AddWithValue("@Selectremark", obj.Selectremark);
                cmd.Parameters.AddWithValue("@selectprocess", obj.Selectprocess);
                cmd.Parameters.AddWithValue("@Selectapssno", obj.Selectapssno);
                cmd.Parameters.AddWithValue("@Companyid", obj.Companyid);
                cmd.Parameters.AddWithValue("@choice", SqlDbType.VarChar).Value = "6";
                cmd.Parameters.AddWithValue("@result", SqlDbType.Int).Direction = ParameterDirection.Output;
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                int i = Convert.ToInt32(cmd.Parameters["@result"].Value.ToString());
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
        public int InsertDigital_Sign(Business_ObjectLayerClass obj)
        {
            try
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }

                SqlCommand cmd = new SqlCommand("spUserRegistration", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PWD", obj.Password);
                cmd.Parameters.AddWithValue("@DigitalSign", obj.Userdigitalsign);
                cmd.Parameters.AddWithValue("@Digitalid", obj.UserID);
                cmd.Parameters.AddWithValue("@choice", SqlDbType.VarChar).Value = "12";
                cmd.Parameters.AddWithValue("@result", SqlDbType.Int).Direction = ParameterDirection.Output;
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                int i = Convert.ToInt32(cmd.Parameters["@result"].Value.ToString());
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
        public DataSet checkDigital_Sign(Business_ObjectLayerClass obj)
        {
            try
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }

                SqlCommand cmd = new SqlCommand("spUserRegistration", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Digitalid", obj.Signid);
                cmd.Parameters.AddWithValue("@choice", SqlDbType.VarChar).Value = "11";
                cmd.Parameters.AddWithValue("@result", SqlDbType.NVarChar).Direction = ParameterDirection.Output;
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                con.Close();
                DataSet dt = new DataSet();
                da.Fill(dt);
                return dt;

            }
            catch
            {
                throw;
            }
            finally
            {

            }
        }
        public int DeleteGenerate_Bill(Business_ObjectLayerClass obj)
        {
            try
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }

                SqlCommand cmd = new SqlCommand("SPNTBilling", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@DeleteNTbillingID", obj.DeleteNTbillingID);
                cmd.Parameters.AddWithValue("@Companyid", obj.Companyid);
                cmd.Parameters.AddWithValue("@choice", SqlDbType.VarChar).Value = "10";
                cmd.Parameters.AddWithValue("@result", SqlDbType.Int).Direction = ParameterDirection.Output;
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                int i = Convert.ToInt32(cmd.Parameters["@result"].Value.ToString());
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
        public int change_password(Business_ObjectLayerClass obj)
        {
            try
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }

                SqlCommand cmd = new SqlCommand("spCheckLogin", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CurrentPassword1", obj.CurrentPassword1);
                cmd.Parameters.AddWithValue("@NewPassword1", obj.NewPassword1);
                cmd.Parameters.AddWithValue("@ResetID", obj.ResetID);
                cmd.Parameters.AddWithValue("@Passwordtype", obj.Passwordtype);
                cmd.Parameters.AddWithValue("@choice", SqlDbType.VarChar).Value = "5";
                cmd.Parameters.AddWithValue("@result", SqlDbType.Int).Direction = ParameterDirection.Output;
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                int i = Convert.ToInt32(cmd.Parameters["@result"].Value.ToString());
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
        public int profilepic_Upload(Business_ObjectLayerClass obj)
        {
            try
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }

                SqlCommand cmd = new SqlCommand("spUserRegistration", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Uploadfilename", obj.Uploadfilename);
                cmd.Parameters.AddWithValue("@UploadUserID", obj.UploadUserID);
                // cmd.Parameters.AddWithValue("@Passwordtype", obj.Passwordtype);
                cmd.Parameters.AddWithValue("@choice", SqlDbType.VarChar).Value = "13";
                cmd.Parameters.AddWithValue("@result", SqlDbType.Int).Direction = ParameterDirection.Output;
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                int i = Convert.ToInt32(cmd.Parameters["@result"].Value.ToString());
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
        public DataSet invo_ice(Business_ObjectLayerClass obj)
        {
            try
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }

                SqlCommand cmd = new SqlCommand("SP_rpt_invoicentbilling", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CompanyID", obj.Invoice_company_id);
                cmd.Parameters.AddWithValue("@Invoice_id", obj.Invoice_id);
                //cmd.Parameters.AddWithValue("@choice", SqlDbType.VarChar).Value = "11";
                //cmd.Parameters.AddWithValue("@result", SqlDbType.NVarChar).Direction = ParameterDirection.Output;
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                con.Close();
                DataSet dt = new DataSet();
                da.Fill(dt);
                return dt;

            }
            catch
            {
                throw;
            }
            finally
            {

            }
        }
        public DataSet DisplayApproved_Bill(Business_ObjectLayerClass obj)
        {
            try
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }

                SqlCommand cmd = new SqlCommand("SPNTBilling", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Billdate", obj.Billdate);
                cmd.Parameters.AddWithValue("@PartyCode1", obj.PartyCode);
                cmd.Parameters.AddWithValue("@companyid", obj.Invoice_company_id);
                cmd.Parameters.AddWithValue("@ApprovedBillNo", obj.ApprovedBillNo);
                cmd.Parameters.AddWithValue("@choice", SqlDbType.VarChar).Value = "12";
                cmd.Parameters.AddWithValue("@result", SqlDbType.NVarChar).Direction = ParameterDirection.Output;
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                con.Close();
                DataSet dt = new DataSet();
                da.Fill(dt);
                return dt;

            }
            catch
            {
                throw;
            }
            finally
            {

            }
        }
        public DataSet displayParty_Nameddl(Business_ObjectLayerClass obj)
        {
            try
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }

                SqlCommand cmd = new SqlCommand("SPNTBilling", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@companyid", obj.Companyid);
                cmd.Parameters.AddWithValue("@choice", SqlDbType.VarChar).Value = "13";
                cmd.Parameters.AddWithValue("@result", SqlDbType.NVarChar).Direction = ParameterDirection.Output;
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                con.Close();
                DataSet dt = new DataSet();
                da.Fill(dt);
                return dt;

            }
            catch
            {
                throw;
            }
            finally
            {

            }
        }
        public int forgot_login(Business_ObjectLayerClass obj)
        {
            try
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }

                SqlCommand cmd = new SqlCommand("spCheckLogin", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@forgotemail", obj.Forgotemail);
                // cmd.Parameters.AddWithValue("@loginpassword", obj.LoginPassword);
                cmd.Parameters.AddWithValue("@loginstatus", obj.Login_status);
                cmd.Parameters.AddWithValue("@choice", SqlDbType.VarChar).Value = "4";
                cmd.Parameters.AddWithValue("@result", SqlDbType.Int).Direction = ParameterDirection.Output;
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                int i = Convert.ToInt32(cmd.Parameters["@result"].Value.ToString());
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
        public DataSet displayFixLicense_Fee(Business_ObjectLayerClass obj)
        {
            try
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }

                SqlCommand cmd = new SqlCommand("SPWorkoutMaster", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CompanyId", obj.Companyid);
                //cmd.Parameters.AddWithValue("@FormName", obj.Pathurl);
                //cmd.Parameters.AddWithValue("@ControlName", obj.DdlControlName);
                cmd.Parameters.AddWithValue("@choice", SqlDbType.VarChar).Value = "9";
                cmd.Parameters.AddWithValue("@result", SqlDbType.Int).Direction = ParameterDirection.Output;
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                con.Close();
                DataSet dt = new DataSet();
                da.Fill(dt);
                // Convert.ToInt32(cmd.Parameters["@result"].Value.ToString());
                return dt;

            }
            catch
            {
                throw;
            }
            finally
            {

            }
        }
        public DataSet fetchBill_id(Business_ObjectLayerClass obj)
        {
            try
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }

                SqlCommand cmd = new SqlCommand("SPNTBilling", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Billoptions1", obj.Billoptions1);
                cmd.Parameters.AddWithValue("@BillPartyCode1", obj.BillPartyCode1);
                cmd.Parameters.AddWithValue("@BillPeriodfrom1", obj.BillPeriodfrom1);
                cmd.Parameters.AddWithValue("@BillArrear1", obj.BillArrear1);
                cmd.Parameters.AddWithValue("@Billno", obj.Billno);
                cmd.Parameters.AddWithValue("@choice", SqlDbType.VarChar).Value = "14";
                cmd.Parameters.AddWithValue("@result", SqlDbType.NVarChar).Direction = ParameterDirection.Output;
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                con.Close();
                DataSet dt = new DataSet();
                da.Fill(dt);
                return dt;

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

       
        public int insertnew_pass(Business_ObjectLayerClass obj)
        {
            try
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }

                SqlCommand cmd = new SqlCommand("SPEntryPass", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Selfesct", obj.Selfesct);
                cmd.Parameters.AddWithValue("@Oldpassrenew", obj.Oldpassrenew);
                cmd.Parameters.AddWithValue("@Applicantmobile", obj.Applicantmobile);
                cmd.Parameters.AddWithValue("@Bcasapproval", obj.Bcasapproval);
                cmd.Parameters.AddWithValue("@Identityproofname", obj.Identityproofname);
                cmd.Parameters.AddWithValue("@Identityproofno", obj.Identityproofno);
                cmd.Parameters.AddWithValue("@Esctpassno1", obj.Esctpassno1);
                cmd.Parameters.AddWithValue("@PassAmount", obj.PassAmount);
                cmd.Parameters.AddWithValue("@Remark", obj.Remark);
                cmd.Parameters.AddWithValue("@RemarkDetail1", obj.RemarkDetail1);
                cmd.Parameters.AddWithValue("@Active", obj.Active);
                cmd.Parameters.AddWithValue("@CompanyId", obj.Companyid);
                cmd.Parameters.AddWithValue("@Address", obj.Address);
                cmd.Parameters.AddWithValue("@Agency", obj.Agency);
                cmd.Parameters.AddWithValue("@NameofAgency1", obj.NameofAgency1);
                cmd.Parameters.AddWithValue("@Airport", obj.Airport);
                cmd.Parameters.AddWithValue("@Applicantname", obj.Applicantname);
                cmd.Parameters.AddWithValue("@Areazones", obj.Areazones);
                cmd.Parameters.AddWithValue("@Designation", obj.Designation);
                cmd.Parameters.AddWithValue("@Dob", obj.Dob);
                cmd.Parameters.AddWithValue("@Oldpassno", obj.Oldpassno);
                cmd.Parameters.AddWithValue("@Passno", obj.Passno);
                cmd.Parameters.AddWithValue("@Passtype", obj.Passtype);
                cmd.Parameters.AddWithValue("@Periodfrom", obj.Periodfrom);
                cmd.Parameters.AddWithValue("@Periodto", obj.Periodto);
                cmd.Parameters.AddWithValue("@Photo", obj.Photo);
                cmd.Parameters.AddWithValue("@Policevarificationtype", obj.Policevarificationtype);
                cmd.Parameters.AddWithValue("@Policeverficationdate", obj.Policeverficationdate);
                cmd.Parameters.AddWithValue("@Policeverificationdocument", obj.Policeverificationdocument);
                cmd.Parameters.AddWithValue("@Policeverificationname", obj.Policeverificationname);
                cmd.Parameters.AddWithValue("@Presentaddress", obj.Presentaddress);
                cmd.Parameters.AddWithValue("@Sign", obj.Sign);
                cmd.Parameters.AddWithValue("@Purposeofvisit", obj.Purposeofvisit);
                cmd.Parameters.AddWithValue("@Terminal", obj.Terminal);
                cmd.Parameters.AddWithValue("@Wife", obj.Wife);
                cmd.Parameters.AddWithValue("@choice", SqlDbType.VarChar).Value = "2";
                cmd.Parameters.AddWithValue("@result", SqlDbType.Int).Direction = ParameterDirection.Output;
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                int i = Convert.ToInt32(cmd.Parameters["@result"].Value.ToString());
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

        public DataSet searchOldPass_Detail(Business_ObjectLayerClass obj)
        {
            try
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }

                SqlCommand cmd = new SqlCommand("SPEntryPass", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Searchmobile", obj.Searchmobile);
                cmd.Parameters.AddWithValue("@CompanyId", obj.Companyid);
                cmd.Parameters.AddWithValue("@Searchapplicantname", obj.Searchapplicantname);
                cmd.Parameters.AddWithValue("@Searchdob", obj.Searchdob);
                cmd.Parameters.AddWithValue("@Searcholdpassno", obj.Searcholdpassno);
                cmd.Parameters.AddWithValue("@choice", SqlDbType.VarChar).Value = "1";
                cmd.Parameters.AddWithValue("@result", SqlDbType.Int).Direction = ParameterDirection.Output;
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);

                con.Close();
                DataSet dt = new DataSet();
                da.Fill(dt);
                // Convert.ToInt32(cmd.Parameters["@result"].Value.ToString());
                return dt;

            }
            catch
            {
                throw;
            }
            finally
            {

            }
        }
        public DataSet ShowSelectOldpass_Detail(Business_ObjectLayerClass obj)
        {
            try
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }

                SqlCommand cmd = new SqlCommand("SPEntryPass", con);
                cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Parameters.AddWithValue("@CompanyId", obj.Companyid);
                //cmd.Parameters.AddWithValue("@Searchapplicantname", obj.Searchapplicantname);
                //cmd.Parameters.AddWithValue("@Searchdob", obj.Searchdob);
                cmd.Parameters.AddWithValue("@Oldpassno", obj.Oldpassno);
                cmd.Parameters.AddWithValue("@choice", SqlDbType.VarChar).Value = "3";
                cmd.Parameters.AddWithValue("@result", SqlDbType.Int).Direction = ParameterDirection.Output;
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);

                con.Close();
                DataSet dt = new DataSet();
                da.Fill(dt);
                // Convert.ToInt32(cmd.Parameters["@result"].Value.ToString());
                return dt;

            }
            catch
            {
                throw;
            }
            finally
            {

            }
        }

        public int Update_pass(Business_ObjectLayerClass obj)
        {
            try
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }

                SqlCommand cmd = new SqlCommand("SPEntryPass", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Applicantmobile", obj.Applicantmobile);
                cmd.Parameters.AddWithValue("@Bcasapproval", obj.Bcasapproval);
                cmd.Parameters.AddWithValue("@Identityproofname", obj.Identityproofname);
                cmd.Parameters.AddWithValue("@Identityproofno", obj.Identityproofno);
                cmd.Parameters.AddWithValue("@PassAmount", obj.PassAmount);
                cmd.Parameters.AddWithValue("@Remark", obj.Remark);
                cmd.Parameters.AddWithValue("@RemarkDetail1", obj.RemarkDetail1);
                cmd.Parameters.AddWithValue("@Active", obj.Active);
                cmd.Parameters.AddWithValue("@CompanyId", obj.Companyid);
                cmd.Parameters.AddWithValue("@Address", obj.Address);
                cmd.Parameters.AddWithValue("@Agency", obj.Agency);
                cmd.Parameters.AddWithValue("@NameofAgency1", obj.NameofAgency1);
                cmd.Parameters.AddWithValue("@Airport", obj.Airport);
                cmd.Parameters.AddWithValue("@Applicantname", obj.Applicantname);
                cmd.Parameters.AddWithValue("@Areazones", obj.Areazones);
                cmd.Parameters.AddWithValue("@Designation", obj.Designation);
                cmd.Parameters.AddWithValue("@Dob", obj.Dob);
                cmd.Parameters.AddWithValue("@Oldpassno", obj.Oldpassno);
                cmd.Parameters.AddWithValue("@Passno", obj.Passno);
                cmd.Parameters.AddWithValue("@Passtype", obj.Passtype);
                cmd.Parameters.AddWithValue("@Periodfrom", obj.Periodfrom);
                cmd.Parameters.AddWithValue("@Periodto", obj.Periodto);
                cmd.Parameters.AddWithValue("@Photo", obj.Photo);
                cmd.Parameters.AddWithValue("@Policevarificationtype", obj.Policevarificationtype);
                cmd.Parameters.AddWithValue("@Policeverficationdate", obj.Policeverficationdate);
                cmd.Parameters.AddWithValue("@Policeverificationdocument", obj.Policeverificationdocument);
                cmd.Parameters.AddWithValue("@Policeverificationname", obj.Policeverificationname);
                cmd.Parameters.AddWithValue("@Presentaddress", obj.Presentaddress);
                cmd.Parameters.AddWithValue("@Sign", obj.Sign);
                cmd.Parameters.AddWithValue("@Purposeofvisit", obj.Purposeofvisit);
                cmd.Parameters.AddWithValue("@Terminal", obj.Terminal);
                cmd.Parameters.AddWithValue("@Wife", obj.Wife);
                cmd.Parameters.AddWithValue("@choice", SqlDbType.VarChar).Value = "4";
                cmd.Parameters.AddWithValue("@result", SqlDbType.Int).Direction = ParameterDirection.Output;
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                int i = Convert.ToInt32(cmd.Parameters["@result"].Value.ToString());
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
        public DataSet Display_ApprovePass(Business_ObjectLayerClass obj)
        {
            try
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }

                SqlCommand cmd = new SqlCommand("SPEntryPass", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Applicantname", SqlDbType.VarChar).Value = obj.Applicantname;
                cmd.Parameters.AddWithValue("@selectagencyname", SqlDbType.VarChar).Value = obj.Selectagencyname;
                cmd.Parameters.AddWithValue("@companyid", SqlDbType.VarChar).Value = obj.Companyid;
                cmd.Parameters.AddWithValue("@Active", SqlDbType.VarChar).Value = obj.Active;
                cmd.Parameters.AddWithValue("@Action", SqlDbType.VarChar).Value = obj.Action;
                cmd.Parameters.AddWithValue("@Roleid", SqlDbType.VarChar).Value = obj.Roleid;
                cmd.Parameters.AddWithValue("@choice", SqlDbType.VarChar).Value = "5";
                cmd.Parameters.AddWithValue("@result", SqlDbType.Int).Direction = ParameterDirection.Output;
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                con.Close();
                DataSet dt = new DataSet();
                da.Fill(dt);
                return dt;

            }
            catch
            {
                throw;
            }
            finally
            {

            }
        }
        public DataSet Display_ApprovedPass(Business_ObjectLayerClass obj)
        {
            try
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }

                SqlCommand cmd = new SqlCommand("SPEntryPass", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@companyid", SqlDbType.VarChar).Value = obj.Companyid;
                cmd.Parameters.AddWithValue("@Active", SqlDbType.VarChar).Value = obj.Active;
                cmd.Parameters.AddWithValue("@choice", SqlDbType.VarChar).Value = "5";
                cmd.Parameters.AddWithValue("@result", SqlDbType.Int).Direction = ParameterDirection.Output;
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                con.Close();
                DataSet dt = new DataSet();
                da.Fill(dt);
                return dt;

            }
            catch
            {
                throw;
            }
            finally
            {

            }
        }
        public int sendfor_Approvel(Business_ObjectLayerClass obj)
        {
            try
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }

                SqlCommand cmd = new SqlCommand("SPEntryPass", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Active", obj.Active);
                cmd.Parameters.AddWithValue("@Passno", obj.Passno);
                cmd.Parameters.AddWithValue("@Companyid", obj.Companyid);
                cmd.Parameters.AddWithValue("@choice", SqlDbType.VarChar).Value = "8";
                cmd.Parameters.AddWithValue("@result", SqlDbType.Int).Direction = ParameterDirection.Output;
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                int i = Convert.ToInt32(cmd.Parameters["@result"].Value.ToString());
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
        public DataSet fetchpass_amount(Business_ObjectLayerClass obj)
        {
            try
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }

                SqlCommand cmd = new SqlCommand("SPEntryPass", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@companyid",  obj.Companyid);
                cmd.Parameters.AddWithValue("@Selectagency", obj.Selectagency); 
                cmd.Parameters.AddWithValue("@choice", SqlDbType.VarChar).Value = "9";
                cmd.Parameters.AddWithValue("@result", SqlDbType.Int).Direction = ParameterDirection.Output;
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                con.Close();
                DataSet dt = new DataSet();
                da.Fill(dt);
                return dt;

            }
            catch
            {
                throw;
            }
            finally
            {

            }
        }
        public int GenerateReceipt_no(Business_ObjectLayerClass obj)
        {
            try
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }

                SqlCommand cmd = new SqlCommand("SPEntryPass", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@GenerateReceipt", obj.GenerateReceipt);
                cmd.Parameters.AddWithValue("@CompanyId", obj.Companyid);
                cmd.Parameters.AddWithValue("@Paymenttype", obj.Paymenttype);
                cmd.Parameters.AddWithValue("@Chequedate", obj.Chequedate);
                cmd.Parameters.AddWithValue("@Chequeno", obj.Chequeno);
                cmd.Parameters.AddWithValue("@choice", SqlDbType.VarChar).Value = "10";
                cmd.Parameters.AddWithValue("@result", SqlDbType.Int).Direction = ParameterDirection.Output;
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                int i = Convert.ToInt32(cmd.Parameters["@result"].Value.ToString());
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
        public DataSet Print_pass(Business_ObjectLayerClass obj)
        {
            try
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }

                SqlCommand cmd = new SqlCommand("SPEntryPass", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@companyid", obj.Companyid);
                cmd.Parameters.AddWithValue("@Active", obj.Active);
                cmd.Parameters.AddWithValue("@Action", obj.Action);
                cmd.Parameters.AddWithValue("@SelectPass", obj.SelectPass);
                cmd.Parameters.AddWithValue("@choice", SqlDbType.VarChar).Value = "5";
                cmd.Parameters.AddWithValue("@result", SqlDbType.Int).Direction = ParameterDirection.Output;
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                con.Close();
                DataSet dt = new DataSet();
                da.Fill(dt);
                return dt;

            }
            catch
            {
                throw;
            }
            finally
            {

            }
        }
        public DataSet area_Zones(Business_ObjectLayerClass obj)
        {
            try
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }

                SqlCommand cmd = new SqlCommand("SPEntryPass", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@choice", SqlDbType.VarChar).Value = "12";
                cmd.Parameters.AddWithValue("@result", SqlDbType.Int).Direction = ParameterDirection.Output;
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                con.Close();
                DataSet dt = new DataSet();
                da.Fill(dt);
                return dt;

            }
            catch
            {
                throw;
            }
            finally
            {

            }
        }
        public DataSet fetchvarification_day(Business_ObjectLayerClass obj)
        {
            try
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }

                SqlCommand cmd = new SqlCommand("SPEntryPass", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@companyid", obj.Companyid);
                cmd.Parameters.AddWithValue("@Verificationdays", obj.Verificationdays);
                cmd.Parameters.AddWithValue("@choice", SqlDbType.VarChar).Value = "11";
                cmd.Parameters.AddWithValue("@result", SqlDbType.Int).Direction = ParameterDirection.Output;
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                con.Close();
                DataSet dt = new DataSet();
                da.Fill(dt);
                return dt;

            }
            catch
            {
                throw;
            }
            finally
            {

            }
        }
        public DataSet checkpass_valid(Business_ObjectLayerClass obj)
        {
            try
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }

                SqlCommand cmd = new SqlCommand("SPEntryPass", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@companyid", obj.Companyid);
                cmd.Parameters.AddWithValue("@Checkpass", obj.Checkpass);
                cmd.Parameters.AddWithValue("@choice", SqlDbType.VarChar).Value = "13";
                cmd.Parameters.AddWithValue("@result", SqlDbType.Int).Direction = ParameterDirection.Output;
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                con.Close();
                DataSet dt = new DataSet();
                da.Fill(dt);
                return dt;

            }
            catch
            {
                throw;
            }
            finally
            {

            }
        }
        public int delete_pass(Business_ObjectLayerClass obj)
        {
            try
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }

                SqlCommand cmd = new SqlCommand("SPEntryPass", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Passno", obj.Passno);
                cmd.Parameters.AddWithValue("@Companyid", obj.Companyid);
                cmd.Parameters.AddWithValue("@choice", SqlDbType.VarChar).Value = "14";
                cmd.Parameters.AddWithValue("@result", SqlDbType.Int).Direction = ParameterDirection.Output;
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                int i = Convert.ToInt32(cmd.Parameters["@result"].Value.ToString());
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
        public DataSet pass_status(Business_ObjectLayerClass obj)
        {
            try
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }

                SqlCommand cmd = new SqlCommand("SPEntryPass", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@companyid", obj.Companyid);
                cmd.Parameters.AddWithValue("@Statusapplicant", obj.Statusapplicant);
                cmd.Parameters.AddWithValue("@Statusregno", obj.Statusregno);
                cmd.Parameters.AddWithValue("@choice", SqlDbType.VarChar).Value = "15";
                cmd.Parameters.AddWithValue("@result", SqlDbType.Int).Direction = ParameterDirection.Output;
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                con.Close();
                DataSet dt = new DataSet();
                da.Fill(dt);
                return dt;

            }
            catch
            {
                throw;
            }
            finally
            {

            }
        }
        public int insertforgot_request(Business_ObjectLayerClass obj)
        {
            try
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }

                SqlCommand cmd = new SqlCommand("spUserRegistration", con);
                cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Parameters.AddWithValue("@ddlsubparty", obj.DdlSubParty);
                cmd.Parameters.AddWithValue("@Forgotemail", obj.Forgotemail);
                cmd.Parameters.AddWithValue("@systempassword", obj.Systempassword);
               // cmd.Parameters.AddWithValue("@companyid", obj.Companyid);
                cmd.Parameters.AddWithValue("@choice", SqlDbType.VarChar).Value = "14";
                cmd.Parameters.AddWithValue("@result", SqlDbType.Int).Direction = ParameterDirection.Output;
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                int i = Convert.ToInt32(cmd.Parameters["@result"].Value.ToString());
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
        public int session_expire(Business_ObjectLayerClass obj)
        {
            try
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }

                SqlCommand cmd = new SqlCommand("spCheckLogin", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@LoginID", obj.LoginEmailid);
                cmd.Parameters.AddWithValue("@choice", SqlDbType.VarChar).Value = "6";
                cmd.Parameters.AddWithValue("@result", SqlDbType.Int).Direction = ParameterDirection.Output;
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                int i = Convert.ToInt32(cmd.Parameters["@result"].Value.ToString());
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
        public int updatepermanent_pass(Business_ObjectLayerClass obj)
        {
            try
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }

                SqlCommand cmd = new SqlCommand("SPEntryPass", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@LoginID", obj.LoginID);
                cmd.Parameters.AddWithValue("@PermanentAEpid", obj.PermanentAEpid1);
                cmd.Parameters.AddWithValue("@PermanentAEPNo", obj.PermanentAEPNo);
                cmd.Parameters.AddWithValue("@Periodfrom", obj.Periodfrom);
                cmd.Parameters.AddWithValue("@Periodto", obj.Periodto);
                cmd.Parameters.AddWithValue("@choice", SqlDbType.VarChar).Value = "16";
                cmd.Parameters.AddWithValue("@result", SqlDbType.Int).Direction = ParameterDirection.Output;
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                int i = Convert.ToInt32(cmd.Parameters["@result"].Value.ToString());
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
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }

                SqlCommand cmd = new SqlCommand("SPagency", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Passno", obj.Passno);
                cmd.Parameters.AddWithValue("@Companyid", obj.Companyid);
                cmd.Parameters.AddWithValue("@choice", SqlDbType.VarChar).Value = "3";
                cmd.Parameters.AddWithValue("@result", SqlDbType.Int).Direction = ParameterDirection.Output;
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                int i = Convert.ToInt32(cmd.Parameters["@result"].Value.ToString());
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
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }

                SqlCommand cmd = new SqlCommand("SPagency", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Error", obj.Error);
                cmd.Parameters.AddWithValue("@id", obj.Id);
                cmd.Parameters.AddWithValue("@choice", SqlDbType.VarChar).Value = "4";
                cmd.Parameters.AddWithValue("@result", SqlDbType.Int).Direction = ParameterDirection.Output;
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                int i = Convert.ToInt32(cmd.Parameters["@result"].Value.ToString());
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
        public DataSet download_excel(Business_ObjectLayerClass obj)
        {
            try
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                SqlCommand cmd = new SqlCommand("SPEntryPass", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@companyid", obj.Companyid);
                cmd.Parameters.AddWithValue("@Excelaepno", obj.Excelaepno);
                cmd.Parameters.AddWithValue("@choice", SqlDbType.VarChar).Value = "17";
                cmd.Parameters.AddWithValue("@result", SqlDbType.Int).Direction = ParameterDirection.Output;
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                con.Close();
                DataSet dt = new DataSet();
                da.Fill(dt);
                return dt;
            }
            catch
            {
                throw;
            }
            finally
            {

            }
        }
        public DataSet fetchall_passdetail(Business_ObjectLayerClass obj)
        {
            try
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }

                SqlCommand cmd = new SqlCommand("SPEntryPass", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@companyid", SqlDbType.VarChar).Value = obj.Companyid;
                cmd.Parameters.AddWithValue("@choice", SqlDbType.VarChar).Value = "18";
                cmd.Parameters.AddWithValue("@result", SqlDbType.Int).Direction = ParameterDirection.Output;
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                con.Close();
                DataSet dt = new DataSet();
                da.Fill(dt);
                return dt;

            }
            catch
            {
                throw;
            }
            finally
            {

            }
        }
        public DataSet selectagency_name(Business_ObjectLayerClass obj)
        {
            try
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }

                SqlCommand cmd = new SqlCommand("SPEntryPass", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@agencyname", SqlDbType.VarChar).Value = obj.Agencyname;
                cmd.Parameters.AddWithValue("@companyid", SqlDbType.VarChar).Value = obj.Companyid;
                cmd.Parameters.AddWithValue("@choice", SqlDbType.VarChar).Value = "19";
                cmd.Parameters.AddWithValue("@result", SqlDbType.Int).Direction = ParameterDirection.Output;
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                con.Close();
                DataSet dt = new DataSet();
                da.Fill(dt);
                return dt;

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
            List<string> customers = new List<string>();
            try
            {

                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                con.Open();
                SqlCommand cmd = new SqlCommand("spsuggestion", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Search", pp);
                cmd.Parameters.AddWithValue("@choice", SqlDbType.VarChar).Value = "1";
                cmd.Parameters.AddWithValue("@result", SqlDbType.Int).Direction = ParameterDirection.Output;
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    customers.Add(sdr["designation"].ToString());
                }
                //  DataSet ds = new DataSet();
                //da.Fill(ds);
                //return da;
                return customers;

            }
            catch
            {
                throw;
            }
            finally
            {
                con.Close();
            }
        }
    }
}
