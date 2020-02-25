using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json.Converters;

namespace WishTheEmployee
{
    public partial class Form1 : Form
    {
        EmployeeProfile empProfile;
        string serializedFileName;
        public Form1()
        {
            InitializeComponent();

            serializedFileName = "EmployeeProfilesDatabase.txt";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string alias = tbAlias.Text.ToString().Trim().ToLower();
            string name = tbName.Text.ToString().Trim().ToUpper();
            DateTime dob = dtpDOB.Value.Date;
            DateTime doj = dtpDOJ.Value.Date;

            empProfile = new EmployeeProfile();
            empProfile.Alias = alias;
            empProfile.EmpName = name;
            empProfile.DateOfBirthday = dob;
            empProfile.DateOfJoining = doj;

            SerializeEmpProfile(empProfile);
        }

        private void SerializeEmpProfile(EmployeeProfile empProfile)
        {
            string existingJsonString;
            EmployeeProfiles listOfEmpProfiles = new EmployeeProfiles();
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

            listOfEmpProfiles.employeeProfiles.Add(empProfile);
            
            string jsonString = JsonConvert.SerializeObject(listOfEmpProfiles, Formatting.Indented);
            File.WriteAllText(serializedFileName, jsonString);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            tbAlias.Clear();
            tbName.Clear();
            dtpDOB.ResetText();
            dtpDOJ.ResetText();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            Form formEdit = new Form2(serializedFileName);
            formEdit.Visible = Enabled;
            formEdit.BringToFront();
        }
    }
}
