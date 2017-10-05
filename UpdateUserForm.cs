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
    public partial class UpdateUserForm : MetroFramework.Forms.MetroForm
    {
        private WinFormRestAPI mainForm;
        private User user = new User();

        public UpdateUserForm()
        {
            InitializeComponent();
        }
        public UpdateUserForm(WinFormRestAPI form, User userItem)
        {
            InitializeComponent();
            this.mainForm = form;
            user = userItem;
            this.textFirstName.Text = user.FirstName;
            this.textLastName.Text = user.LastName;
            this.textUserEmail.Text = user.Email;
            this.textUserLogin.Text = user.Login;
            this.textUserMobile.Text = user.MobilePhone;
        }

        private void btnUpdateUser_Click(object sender, EventArgs e)
        {
            string firstName = this.textFirstName.Text;
            string lastName = this.textLastName.Text;
            string email = this.textUserEmail.Text;
            string login = this.textUserLogin.Text;
            string mobileNumber = this.textUserMobile.Text;

            string oktaBase = ConfigurationManager.AppSettings["tenantUrl"];
            string endpoint = oktaBase + "/api/v1/users/" + user.Id;
            string postdata = "{ \"profile\": { \"firstName\": \"" + firstName + "\",\"lastName\": \"" + lastName + "\",\"email\": \"" + email + "\",\"login\": \"" + login + "\",\"mobilePhone\": \"" + mobileNumber + "\"}}";
            string newUser = mainForm.UpdateUser(endpoint, "PUT", postdata);

            MessageBox.Show(newUser, "Updating User");
            this.Close();
        }
    }
}
