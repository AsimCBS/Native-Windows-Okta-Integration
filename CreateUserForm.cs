using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsRestAPI
{
    public partial class CreateBrowserLoginForm : MetroFramework.Forms.MetroForm
    {
        private WinFormRestAPI mainForm;
        public CreateBrowserLoginForm()
        {
            InitializeComponent();
        }
        public CreateBrowserLoginForm (WinFormRestAPI form)
        {
            InitializeComponent();
            this.mainForm = form;
        }

        private void btnCreateUser_Click(object sender, EventArgs e)
        {
            string firstName = this.textFirstName.Text;
            string lastName = this.textLastName.Text;
            string email = this.textUserEmail.Text;
            string login = this.textUserLogin.Text;
            string mobileNumber = this.textUserMobile.Text;

            string oktaBase = ConfigurationManager.AppSettings["tenantUrl"];
            string endpoint = oktaBase + "/api/v1/users?activate=false";
            string postdata = "{ \"profile\": { \"firstName\": \"" + firstName + "\",\"lastName\": \"" + lastName + "\",\"email\": \"" + email + "\",\"login\": \"" + login + "\",\"mobilePhone\": \"" + mobileNumber +"\"}}";
            string newUser = mainForm.CreateNewUser(endpoint, "POST", postdata);

            MessageBox.Show(newUser, "Creating User");
            this.Close();
        }
    }
}
