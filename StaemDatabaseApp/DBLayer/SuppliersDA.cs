using MySql.Data.MySqlClient;
using StaemDatabaseApp.Helper;
using StaemDatabaseApp.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaemDatabaseApp.DBLayer
{
    class SuppliersDA
    {
        private static MySqlCommand cmd = null;
        private static DataTable dt;
        private static MySqlDataAdapter sda;

        public static Supplier retrieveSupplierByName(string supplierName)
        {
            string query = "SELECT * FROM staem.suppliers where Supplier_name = (@supplierName) limit 1";
            //cmd = DBHelper.RunQuery(query, supplierName);
            Supplier supplier = null;
            if(cmd != null)
            {
                dt = new DataTable();
                sda = new MySqlDataAdapter(cmd);
                sda.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    string id = dr["ID"].ToString();
                    string name = dr["Supplier_name"].ToString();
                    string address = dr["Supplier_address"].ToString();
                    string contact = dr["Supplier_contact"].ToString();
                    supplier = new Supplier(id, name, address, contact);
                }
            }
            return supplier;
        }

        public static Supplier retrieveSupplierByID(int supplierID)
        {
            string query = "SELECT * FROM staem.suppliers where Supplier_id = (@supplierID) limit 1";
            cmd = DBHelper.RunQuery(query, supplierID);
            Supplier supplier = null;
            if (cmd != null)
            {
                dt = new DataTable();
                sda = new MySqlDataAdapter(cmd);
                sda.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    string id = dr["ID"].ToString();
                    string name = dr["Supplier_name"].ToString();
                    string address = dr["Supplier_address"].ToString();
                    string contact = dr["Supplier_contact"].ToString();
                    supplier = new Supplier(id, name, address, contact);
                }
            }
            return supplier;
        }

        public static List<Supplier> retrieveAllSuppliers()
        {
            string query = "SELECT * FROM staem.suppliers";
            cmd = DBHelper.RunQueryNoParameters(query);
            List<Supplier> suppliers = new List<Supplier>();
            if (cmd != null)
            {
                dt = new DataTable();
                sda = new MySqlDataAdapter(cmd);
                sda.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    string id = dr["ID"].ToString();
                    string name = dr["Supplier_name"].ToString();
                    string address = dr["Supplier_address"].ToString();
                    string contact = dr["Supplier_contact"].ToString();
                    Supplier supplier = new Supplier(id, name, address, contact);
                    suppliers.Add(supplier);
                }
            }
            return suppliers;
        }
    }
}
