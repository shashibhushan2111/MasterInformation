using MasterInformation.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MasterInformation.DAL
{
    public class DataAccessLayer
    {
        public IEnumerable<tblUserDetail> GetAllData()
        {
            List<tblUserDetail> data = new List<tblUserDetail>();
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MyCon"].ToString());
            SqlCommand cmd = new SqlCommand("SP_SelectAllData", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
           while (dr.Read())
            {
                tblUserDetail userDetail = new tblUserDetail();
                userDetail.ID = Convert.ToInt32(dr["ID"]); 
                userDetail.Name = dr["Name"].ToString();
                userDetail.Email = dr["Email"].ToString();
                userDetail.DOB = Convert.ToDateTime(dr["DOB"]);
                userDetail.Image = dr["Image"].ToString();
                userDetail.Hobby = dr["Hobby"].ToString();   
                userDetail.CountryID = (int)Convert.ToInt64(dr["CountryID"]);
                userDetail.StateID = (int)Convert.ToInt64(dr["StateID"]);
                userDetail.CityID = (int)Convert.ToInt64(dr["CityID"]);
                data.Add(userDetail);
            }
            con.Close();
            return data;
        }
        public tblUserDetail GetDataById(int id)
        {
            tblUserDetail userDetail = new tblUserDetail();
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MyCon"].ToString());
            SqlCommand cmd = new SqlCommand("SP_SelectByID", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID",id);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                userDetail.ID = Convert.ToInt32(dr["ID"]);
                userDetail.Name = dr["Name"].ToString();
                userDetail.Email = dr["Email"].ToString();
                userDetail.DOB = Convert.ToDateTime(dr["DOB"]);
                userDetail.Image = dr["Image"].ToString();
                userDetail.Hobby = dr["Hobby"].ToString();
                userDetail.CountryID = (int)Convert.ToInt64(dr["CountryID"]);
                userDetail.StateID = (int)Convert.ToInt64(dr["StateID"]);
                userDetail.CityID = (int)Convert.ToInt64(dr["CityID"]);
            }
            con.Close();
            return userDetail;
        }
        public void InsertData(tblUserDetail userDetail)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MyCon"].ToString());
            SqlCommand cmd = new SqlCommand("SP_Insert",con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Name",userDetail.Name);
            cmd.Parameters.AddWithValue("@Email", userDetail.Email);
            cmd.Parameters.AddWithValue("@DOB", userDetail.DOB);
            cmd.Parameters.AddWithValue("@Image", userDetail.Image);
            cmd.Parameters.AddWithValue("@Hobby", userDetail.Hobby);
            cmd.Parameters.AddWithValue("@CountryID", userDetail.CountryID);
            cmd.Parameters.AddWithValue("@StateID", userDetail.StateID);
            cmd.Parameters.AddWithValue("@CityID", userDetail.CityID);
            cmd.Parameters.AddWithValue("@CreatedBy", 0);
            cmd.Parameters.AddWithValue("@CreatedDate", userDetail.CreatedDate);
            cmd.Parameters.AddWithValue("@ModifiedBy", 0);
            cmd.Parameters.AddWithValue("@ModifiedDate", userDetail.ModifiedDate);
            cmd.Parameters.AddWithValue("IsDeleted", false);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void UpdateData(tblUserDetail userDetail)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MyCon"].ToString());
            SqlCommand cmd = new SqlCommand("SP_Update", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID", userDetail.ID);
            cmd.Parameters.AddWithValue("@Name", userDetail.Name);
            cmd.Parameters.AddWithValue("@Email", userDetail.Email);
            cmd.Parameters.AddWithValue("@DOB", userDetail.DOB);
            cmd.Parameters.AddWithValue("@Image", userDetail.Image);
            cmd.Parameters.AddWithValue("@Hobby", userDetail.Hobby);
            cmd.Parameters.AddWithValue("@CountryID", userDetail.CountryID);
            cmd.Parameters.AddWithValue("@StateID", userDetail.StateID);
            cmd.Parameters.AddWithValue("@CityID", userDetail.CityID);
            //cmd.Parameters.AddWithValue("@CreatedBy", 0);
            //cmd.Parameters.AddWithValue("@ModifiedBy", 0);
            //cmd.Parameters.AddWithValue("IsDeleted", false);
            cmd.Parameters.AddWithValue("@ModifiedDate", userDetail.ModifiedDate);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public IEnumerable<tblCountry> GetAllCountry()
        {
            List<tblCountry> data = new List<tblCountry>();
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MyCon"].ToString());
            SqlCommand cmd = new SqlCommand("SP_Country", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                tblCountry country = new tblCountry();
                country.CountryID = Convert.ToInt32(dr["CountryID"]);
                country.CountryName = dr["CountryName"].ToString();
                data.Add(country);
            }
            con.Close();
            return data;
        }
        public IEnumerable<tblState> GetAllState()
        {
            List<tblState> data = new List<tblState>();
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MyCon"].ToString());
            SqlCommand cmd = new SqlCommand("SP_State", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                tblState states = new tblState();
                states.StateID= Convert.ToInt32(dr["StateID"]);
                states.StateName = dr["StateName"].ToString();
                data.Add(states);
            }
            con.Close();
            return data;
        }
        public IEnumerable<tblCity> GetAllCity()
        {
            List<tblCity> data = new List<tblCity>();
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MyCon"].ToString());
            SqlCommand cmd = new SqlCommand("SP_City", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                tblCity country = new tblCity();
                country.CityID = Convert.ToInt32(dr["CityID"]);
                country.CityName = dr["CityName"].ToString();
                data.Add(country);
            }
            con.Close();
            return data;
        }
    }
}