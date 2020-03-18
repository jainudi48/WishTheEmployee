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
        string CUR_USER_NAME;
        const string LOCAL_USER = @"C:\Users\";
        const string MICROSOFT_OUTLOOK = @"\AppData\Local\Microsoft\Outlook\";
        public Form1()
        {
            InitializeComponent();


            CUR_USER_NAME = Environment.UserName;
            serializedFileName = LOCAL_USER + CUR_USER_NAME + MICROSOFT_OUTLOOK + @"EmployeeProfilesDatabase.txt";
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

            ClearAllFields();
        }

        private void SerializeEmpProfile(EmployeeProfile empProfile)
        {
            string existingJsonString;
            EmployeeProfiles empProfiles = new EmployeeProfiles();
            empProfiles.listOfEmployeeProfiles = new List<EmployeeProfile>();
            if (!File.Exists(serializedFileName))
            {
                FileStream fs = File.Create(serializedFileName);
                fs.Close();
            }
            else
            {
                existingJsonString = File.ReadAllText(serializedFileName);
                if (!existingJsonString.Equals(""))
                    empProfiles = JsonConvert.DeserializeObject<EmployeeProfiles>(existingJsonString);
            }

            if(empProfiles.listOfEmployeeProfiles == null)
            {
                empProfiles.listOfEmployeeProfiles = new List<EmployeeProfile>();
            }

            empProfiles.listOfEmployeeProfiles.Add(empProfile);
            
            string jsonString = JsonConvert.SerializeObject(empProfiles, Formatting.Indented);
            File.WriteAllText(serializedFileName, jsonString);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ClearAllFields();
        }

        private void ClearAllFields()
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
