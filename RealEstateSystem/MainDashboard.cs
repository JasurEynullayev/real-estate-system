using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.MonthCalendar;

namespace RealEstateSystem
{
    public partial class MainDashboard : Form
    {
        private DataTable propertyTable;

        public MainDashboard()
        {
            InitializeComponent();
            InitializeDataTable();
        }

        private bool ValidateFields()
        {
            if (string.IsNullOrWhiteSpace(txtID.Text) ||
                string.IsNullOrWhiteSpace(txtArea.Text) ||
                string.IsNullOrWhiteSpace(txtPrice.Text) ||
                string.IsNullOrWhiteSpace(cmbType.Text) ||
                string.IsNullOrWhiteSpace(txtAddress.Text) ||
                string.IsNullOrWhiteSpace(txtComments.Text))
            {
                MessageBox.Show("Bütün sahələri doldurun!", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private string GetSelectedFeature()
        {
            if (radioBalcony.Checked) return "Balcony";
            if (radioFireplace.Checked) return "Fireplace";
            if (radioBackyard.Checked) return "Backyard";
            if (radioGarage.Checked) return "Garage";
            if (radioPool.Checked) return "Pool";

            return "No Feature Selected";
        }



        private void InitializeDataTable()
        {
            propertyTable = new DataTable();
            propertyTable.Columns.Add("ID", typeof(int));
            propertyTable.Columns.Add("Area", typeof(double));
            propertyTable.Columns.Add("Price", typeof(decimal));
            propertyTable.Columns.Add("Type", typeof(string));
            propertyTable.Columns.Add("Bedrooms", typeof(int));
            propertyTable.Columns.Add("Bathrooms", typeof(int));
            propertyTable.Columns.Add("Dining Rooms", typeof(int));
            propertyTable.Columns.Add("Features", typeof(string));
            propertyTable.Columns.Add("Address", typeof(string));
            propertyTable.Columns.Add("Comments", typeof(string));
        }

 

    


        // Yeni sətir əlavə etmək üçün metod
        private void AddProperty()
        {

        }


        private void ClearFields()
        {
            txtID.Clear();
            txtArea.Clear();
            txtPrice.Clear();
            cmbType.SelectedIndex = -1;
            numericBedrooms.Value = 0;
            numericBathrooms.Value = 0;
            numericDiningRooms.Value = 0;
            txtAddress.Clear();
            txtComments.Clear();
            radioBalcony.Checked = false;
            radioFireplace.Checked = false;
            radioBackyard.Checked = false;
            radioGarage.Checked = false;
            radioPool.Checked = false;
        }





        private void MainDashboard_Load(object sender, EventArgs e)
        {

        }

        private void lbldashboard_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (ValidateFields()) 
            {
                try
                {
                    DataRow row = propertyTable.NewRow();

                    if (!int.TryParse(txtID.Text, out int id))
                    {
                        MessageBox.Show("ID sahəsinə yalnız rəqəm daxil edin!", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    if (!double.TryParse(txtArea.Text, out double area))
                    {
                        MessageBox.Show("Area sahəsinə yalnız rəqəm daxil edin!", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    if (!decimal.TryParse(txtPrice.Text, out decimal price))
                    {
                        MessageBox.Show("Price sahəsinə yalnız rəqəm daxil edin!", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    row["ID"] = id;
                    row["Area"] = area;
                    row["Price"] = price;
                    row["Type"] = cmbType.Text;
                    row["Bedrooms"] = numericBedrooms.Value;
                    row["Bathrooms"] = numericBathrooms.Value;
                    row["Dining Rooms"] = numericDiningRooms.Value;
                    row["Features"] = GetSelectedFeature();
                    row["Address"] = txtAddress.Text;
                    row["Comments"] = txtComments.Text;

                    propertyTable.Rows.Add(row);

                    MessageBox.Show("Mülk uğurla əlavə edildi!", "Uğur", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearFields();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Xəta baş verdi: {ex.Message}", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Bütün xanaları düzgün doldurun!", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            PropertyList propertyListForm = new PropertyList(propertyTable);
            propertyListForm.ShowDialog();
        }
    }
}
