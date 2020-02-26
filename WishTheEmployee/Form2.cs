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

            // Populate the Combo Box
            cbAlias.ValueMember = listOfEmpProfiles.employeeProfiles.FirstOrDefault<EmployeeProfile>().Alias;
            cbAlias.DataSource = listOfEmpProfiles.employeeProfiles;
           
        }

        private void btnSaveChanges_Click(object sender, EventArgs e)
        {
            // Below two lines need to be changed 
            string selectedEmpProfile;
            selectedEmpProfile = listOfEmpProfiles.employeeProfiles.FirstOrDefault<EmployeeProfile>().Alias;


            foreach (var empProfile in listOfEmpProfiles.employeeProfiles)
            {
                if(empProfile.Alias.Equals(selectedEmpProfile))
                {
                    empProfile.EmpName = tbName.Text.ToString().Trim().ToUpper();
                    empProfile.DateOfBirthday = dtpDOB.Value.Date;
                    empProfile.DateOfJoining = dtpDOJ.Value.Date;
                }
            }

            // Serialize the modified objects
            //string existingJsonString;
            //if (!File.Exists(serializedFileName))
            //{
            //    FileStream fs = File.Create(serializedFileName);
            //    fs.Close();
            //}
            //else
            //{
            //    existingJsonString = File.ReadAllText(serializedFileName);
            //    if (!existingJsonString.Equals(""))
            //        listOfEmpProfiles = JsonConvert.DeserializeObject<EmployeeProfiles>(existingJsonString);
            //    else
            //        MessageBox.Show("Error! Database file does not contain anything.");
            //}

            string jsonString = JsonConvert.SerializeObject(listOfEmpProfiles, Formatting.Indented);
            File.WriteAllText(serializedFileName, jsonString);
        }

        
        private void cbAlias_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            // Below two lines need to be changed 
            string selectedEmpProfile;
            selectedEmpProfile = listOfEmpProfiles.employeeProfiles.FirstOrDefault<EmployeeProfile>().Alias;


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
    }
}
