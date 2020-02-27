using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WishTheEmployee
{
    public partial class Form2 : Form
    {
        string serializedFileName;
        EmployeeProfiles listOfEmpProfiles;
        public Form2(string filepath)
        {
            InitializeComponent();
            serializedFileName = filepath;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            FillFormWithLatestChanged();
        }

        private void FillFormWithLatestChanged()
        {
            string existingJsonString;
            listOfEmpProfiles = new EmployeeProfiles();
            listOfEmpProfiles.employeeProfiles = new List<EmployeeProfile>();
            if (!File.Exists(serializedFileName))
            {
                FileStream fs = File.Create(serializedFileName);
                fs.Close();
            }
            else
            {
                existingJsonString = File.ReadAllText(serializedFileName);
                if (!existingJsonString.Equals(""))
                    listOfEmpProfiles = JsonConvert.DeserializeObject<EmployeeProfiles>(existingJsonString);
                else
                    MessageBox.Show("Error! Database file does not contain anything.");
            }

            // Check if data source has no items
            if (listOfEmpProfiles.employeeProfiles.Count == 0)
                ClearForm();

            // Populate the Combo Box
            cbAlias.DataSource = listOfEmpProfiles.employeeProfiles;
            cbAlias.DisplayMember = "Alias";
        }

        private void btnSaveChanges_Click(object sender, EventArgs e)
        {
            // Get selected item
            string selectedEmpProfile;
            selectedEmpProfile = cbAlias.Text.ToString();
             
            foreach (var empProfile in listOfEmpProfiles.employeeProfiles)
            {
                if(empProfile.Alias.Equals(selectedEmpProfile))
                {
                    empProfile.EmpName = tbName.Text.ToString().Trim().ToUpper();
                    empProfile.DateOfBirthday = dtpDOB.Value.Date;
                    empProfile.DateOfJoining = dtpDOJ.Value.Date;
                }
            }

            string jsonString = JsonConvert.SerializeObject(listOfEmpProfiles, Formatting.Indented);
            File.WriteAllText(serializedFileName, jsonString);

            FillFormWithLatestChanged();
        }

        private void ClearForm()
        {
            cbAlias.ResetText();
            tbName.Clear();
            dtpDOB.ResetText();
            dtpDOJ.ResetText();
        }

        private void cbAlias_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            // Get selected item
            string selectedEmpProfile;
            selectedEmpProfile = cbAlias.Text.ToString();

            // code here to pull other properties of selected object


            // Find selected item
            foreach (var empProfile in listOfEmpProfiles.employeeProfiles)
            {
                if (empProfile.Alias.Equals(selectedEmpProfile))
                {
                    tbName.Text = empProfile.EmpName;
                    dtpDOB.Value = empProfile.DateOfBirthday;
                    dtpDOJ.Value = empProfile.DateOfJoining;
                }
            }
        }

        private void btnDeleteSelected_Click(object sender, EventArgs e)
        {
            string selectedEmpProfile;
            selectedEmpProfile = cbAlias.Text.Trim();

            listOfEmpProfiles.employeeProfiles.RemoveAll(x => x.Alias.Equals(selectedEmpProfile));

            string jsonString = JsonConvert.SerializeObject(listOfEmpProfiles, Formatting.Indented);
            File.WriteAllText(serializedFileName, jsonString);

            FillFormWithLatestChanged();
        }
    }
}
