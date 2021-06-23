using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cars
{
    public partial class Form1 : Form
    {
        CarData car = new CarData();
        DataTable dtCar;
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'inventoryDataSet.Inventory' table. You can move, or remove it, as needed.
          
        }
        private void getAllCars()
        {
            dtCar = car.getCars();
            txtCarID.DataBindings.Clear();
            txtMake.DataBindings.Clear();
            txtColor.DataBindings.Clear();
            txtPetName.DataBindings.Clear();
            //rang buoc du lieu tren cac TextBoxes
            txtCarID.DataBindings.Add("Text", dtCar, "CarID");
            txtMake.DataBindings.Add("Text", dtCar, "Make");
            txtColor.DataBindings.Add("Text", dtCar, "Color");
            txtPetName.DataBindings.Add("Text", dtCar, "PetName");
            //Rang buoc du lieu cho GirdView
            dvgCar.DataSource = dtCar;
            //Tinh tong so luong sach
            //lbTotalQuantity.Text = "TotalQuantity :" +
            //     dtBook.Compute("SUM(BookQuantity", string.Empty);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

            int ID = int.Parse(txtCarID.Text);
            string Make = txtMake.Text;
            string color = txtColor.Text;
            string petname = txtPetName.Text;
            Cars ca = new Cars
            {
                CarID = ID,
                Make = Make,
                Color = color,
                PetName = petname
            };
            //goi phuong thuc cap nhat
            bool c = car.addNewCar(ca);
            string s = (c == true ? "successful" : "fail");
            MessageBox.Show("Add" + s);
            //refresh du lieu
            getAllCars();
        }

        private void txtCarID_TextChanged(object sender, EventArgs e)
        {

        }

        private void dvgCar_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            getAllCars();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int ID = int.Parse(txtCarID.Text);
            string Make = txtMake.Text;
            string color = txtColor.Text;
            string petname = txtPetName.Text;
            Cars ca = new Cars
            {
                CarID = ID,
                Make = Make,
                Color = color,
                PetName = petname
            };
            //goi phuong thuc cap nhat
            bool c = car.updateCar(ca);
            string s = (c == true ? "successful" : "fail");
            MessageBox.Show("Update" + s);
            //refresh du lieu
            getAllCars();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int ID = int.Parse(txtCarID.Text);
            bool c = car.deleteCar(ID);
            string s = (c == true ? "successful" : "fail");
            MessageBox.Show("Delete" + s);
            //refresh du lieu
            getAllCars();
        }
    }
}
