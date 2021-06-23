using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars
{
    class CarData
    {

        string strConnection;
        public CarData()
        {
            strConnection = getConnectionString();
        }
        //phuong thuc chuoi ket noi
        public string getConnectionString()
        {
            string strConnection = "server=.;database=Inventory;uid=sa;pwd=123";
            return strConnection;
        }
        //phuong thuc lay tat ca cac danh sach
        public DataTable getCars()
        {
            string sql = "Select * from Inventory";
            SqlConnection cnn = new SqlConnection(strConnection);
            SqlCommand cmd = new SqlCommand(sql, cnn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dtBook = new DataTable();
            try
            {
                if (cnn.State == ConnectionState.Closed)
                {
                    cnn.Open();
                }
                da.Fill(dtBook);
            }
            catch (SqlException e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                cnn.Close();
            }
            return dtBook;
        }
        public bool getCarByCarID(Cars car)
        {
            SqlConnection cnn = new SqlConnection(strConnection);
            string sql = "Select carID from Inventory";
            SqlCommand cmd = new SqlCommand(sql, cnn);
            cmd.Parameters.AddWithValue("@ID", car.CarID);
            cmd.Parameters.AddWithValue("@Make", car.Make);
            cmd.Parameters.AddWithValue("@Color", car.Color);
            cmd.Parameters.AddWithValue("@PetName", car.PetName);
            if (cnn.State == ConnectionState.Closed)
            {
                cnn.Open();
            }
            int count = cmd.ExecuteNonQuery();
            return (count > 0);
            
        }
        //phuong thuc them danh sach moi
        public bool addNewCar(Cars car)
        {

            SqlConnection cnn = new SqlConnection(strConnection);
            string sql = "Insert Inventory values(@ID,@Make,@Color,@PetName)";
            SqlCommand cmd = new SqlCommand(sql, cnn);
            cmd.Parameters.AddWithValue("@ID", car.CarID);
            cmd.Parameters.AddWithValue("@Make", car.Make);
            cmd.Parameters.AddWithValue("@Color", car.Color);
            cmd.Parameters.AddWithValue("@PetName", car.PetName);
            if (cnn.State == ConnectionState.Closed)
            {
                cnn.Open();
            }
            int count = cmd.ExecuteNonQuery();
            return (count > 0);

        }
        //phuong thuc update
        public bool updateCar(Cars car)
        {
            SqlConnection cnn = new SqlConnection(strConnection);
            string sql = "Update Inventory set Make=@Make,Color=@Color," +
                "PetName=@PetName where CarID=@CarID";
            SqlCommand cmd = new SqlCommand(sql, cnn);
            cmd.Parameters.AddWithValue("@CarID", car.CarID);
            cmd.Parameters.AddWithValue("@Make", car.Make);
            cmd.Parameters.AddWithValue("@Color", car.Color);
            cmd.Parameters.AddWithValue("@PetName", car.PetName);
            if (cnn.State == ConnectionState.Closed)
            {
                cnn.Open();
            }
            int count = cmd.ExecuteNonQuery();
            return (count > 0);
        }
        //Phuong thuc xoa sach
        public bool deleteCar(int CarID)
        {
            SqlConnection cnn = new SqlConnection(strConnection);
            string sql = "Delete Inventory where CarID=@ID";
            SqlCommand cmd = new SqlCommand(sql, cnn);
            cmd.Parameters.AddWithValue("@ID", CarID);

            if (cnn.State == ConnectionState.Closed)
            {
                cnn.Open();
            }
            int count = cmd.ExecuteNonQuery();
            return (count > 0);
        }
    }
}
