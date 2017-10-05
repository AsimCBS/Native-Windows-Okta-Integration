namespace WindowsRestAPI
{
    partial class WinFormRestAPI
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            MetroFramework.Controls.MetroTextBox textOktaUrl;
            this.label1 = new MetroFramework.Controls.MetroLabel();
            this.btnClear = new MetroFramework.Controls.MetroButton();
            this.textApiToken = new MetroFramework.Controls.MetroTextBox();
            this.label6 = new MetroFramework.Controls.MetroLabel();
            this.txtResult = new System.Windows.Forms.RichTextBox();
            this.metroUserName = new MetroFramework.Components.MetroStyleManager(this.components);
            this.metroPassword = new MetroFramework.Components.MetroStyleManager(this.components);
            this.tabProfiles = new MetroFramework.Controls.MetroTabPage();
            this.metroBtnBrower = new MetroFramework.Controls.MetroButton();
            this.metroBtnDelUser = new MetroFramework.Controls.MetroButton();
            this.metroBtnAddUser = new MetroFramework.Controls.MetroButton();
            this.btnGroupsGet = new MetroFramework.Controls.MetroButton();
            this.dgwOktaGroupList = new System.Windows.Forms.DataGridView();
            this.btnClearSessions = new MetroFramework.Controls.MetroButton();
            this.btnResetFactors = new MetroFramework.Controls.MetroButton();
            this.metroBtnDeleteUser = new MetroFramework.Controls.MetroButton();
            this.metroBtnLogin = new MetroFramework.Controls.MetroButton();
            this.metroBtnUpdateUser = new MetroFramework.Controls.MetroButton();
            this.metroBtnCreateUser = new MetroFramework.Controls.MetroButton();
            this.btnCreateProfile = new MetroFramework.Controls.MetroButton();
            this.dgwOktaUserList = new System.Windows.Forms.DataGridView();
            this.btnProfilesGet = new MetroFramework.Controls.MetroButton();
            this.Apps = new MetroFramework.Controls.MetroTabControl();
            textOktaUrl = new MetroFramework.Controls.MetroTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.metroUserName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.metroPassword)).BeginInit();
            this.tabProfiles.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgwOktaGroupList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgwOktaUserList)).BeginInit();
            this.Apps.SuspendLayout();
            this.SuspendLayout();
            // 
            // textOktaUrl
            // 
            textOktaUrl.Location = new System.Drawing.Point(238, 42);
            textOktaUrl.Margin = new System.Windows.Forms.Padding(2);
            textOktaUrl.Name = "textOktaUrl";
            textOktaUrl.Size = new System.Drawing.Size(299, 17);
            textOktaUrl.TabIndex = 4;
            textOktaUrl.Text = "dcirecondo.okta.com";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(181, 44);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 19);
            this.label1.TabIndex = 2;
            this.label1.Text = "Org";
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(1012, 429);
            this.btnClear.Margin = new System.Windows.Forms.Padding(2);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(89, 26);
            this.btnClear.TabIndex = 21;
            this.btnClear.Text = "Clear";
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // textApiToken
            // 
            this.textApiToken.Location = new System.Drawing.Point(238, 63);
            this.textApiToken.Margin = new System.Windows.Forms.Padding(2);
            this.textApiToken.Name = "textApiToken";
            this.textApiToken.PasswordChar = '*';
            this.textApiToken.Size = new System.Drawing.Size(299, 17);
            this.textApiToken.TabIndex = 29;
            this.textApiToken.Text = "008GeeOTvQeJV6lDys_vZUsjo_mCYScL5Jtg7t4F6P";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(148, 63);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(66, 19);
            this.label6.TabIndex = 30;
            this.label6.Text = "API Token";
            // 
            // txtResult
            // 
            this.txtResult.Location = new System.Drawing.Point(55, 459);
            this.txtResult.Margin = new System.Windows.Forms.Padding(2);
            this.txtResult.Name = "txtResult";
            this.txtResult.Size = new System.Drawing.Size(1046, 245);
            this.txtResult.TabIndex = 38;
            this.txtResult.Text = "";
            // 
            // metroUserName
            // 
            this.metroUserName.Owner = null;
            // 
            // metroPassword
            // 
            this.metroPassword.Owner = null;
            // 
            // tabProfiles
            // 
            this.tabProfiles.Controls.Add(this.metroBtnBrower);
            this.tabProfiles.Controls.Add(this.metroBtnDelUser);
            this.tabProfiles.Controls.Add(this.metroBtnAddUser);
            this.tabProfiles.Controls.Add(this.btnGroupsGet);
            this.tabProfiles.Controls.Add(this.dgwOktaGroupList);
            this.tabProfiles.Controls.Add(this.btnClearSessions);
            this.tabProfiles.Controls.Add(this.btnResetFactors);
            this.tabProfiles.Controls.Add(this.metroBtnDeleteUser);
            this.tabProfiles.Controls.Add(this.metroBtnLogin);
            this.tabProfiles.Controls.Add(this.metroBtnUpdateUser);
            this.tabProfiles.Controls.Add(this.metroBtnCreateUser);
            this.tabProfiles.Controls.Add(this.btnCreateProfile);
            this.tabProfiles.Controls.Add(this.dgwOktaUserList);
            this.tabProfiles.Controls.Add(this.btnProfilesGet);
            this.tabProfiles.HorizontalScrollbarBarColor = true;
            this.tabProfiles.HorizontalScrollbarSize = 6;
            this.tabProfiles.Location = new System.Drawing.Point(4, 35);
            this.tabProfiles.Margin = new System.Windows.Forms.Padding(2);
            this.tabProfiles.Name = "tabProfiles";
            this.tabProfiles.Size = new System.Drawing.Size(1062, 290);
            this.tabProfiles.TabIndex = 4;
            this.tabProfiles.Text = "Users / Groups";
            this.tabProfiles.VerticalScrollbarBarColor = true;
            this.tabProfiles.VerticalScrollbarSize = 7;
            // 
            // metroBtnBrower
            // 
            this.metroBtnBrower.Location = new System.Drawing.Point(241, 246);
            this.metroBtnBrower.Margin = new System.Windows.Forms.Padding(2);
            this.metroBtnBrower.Name = "metroBtnBrower";
            this.metroBtnBrower.Size = new System.Drawing.Size(223, 31);
            this.metroBtnBrower.TabIndex = 106;
            this.metroBtnBrower.Text = "Signin With Embeeded Browser";
            this.metroBtnBrower.Click += new System.EventHandler(this.metroBtnBrower_Click);
            // 
            // metroBtnDelUser
            // 
            this.metroBtnDelUser.Location = new System.Drawing.Point(907, 180);
            this.metroBtnDelUser.Margin = new System.Windows.Forms.Padding(2);
            this.metroBtnDelUser.Name = "metroBtnDelUser";
            this.metroBtnDelUser.Size = new System.Drawing.Size(153, 21);
            this.metroBtnDelUser.TabIndex = 105;
            this.metroBtnDelUser.Text = "Remove User From Group";
            this.metroBtnDelUser.Click += new System.EventHandler(this.metroBtnDelUser_Click);
            // 
            // metroBtnAddUser
            // 
            this.metroBtnAddUser.Location = new System.Drawing.Point(751, 180);
            this.metroBtnAddUser.Margin = new System.Windows.Forms.Padding(2);
            this.metroBtnAddUser.Name = "metroBtnAddUser";
            this.metroBtnAddUser.Size = new System.Drawing.Size(153, 21);
            this.metroBtnAddUser.TabIndex = 104;
            this.metroBtnAddUser.Text = "Add User To Group";
            this.metroBtnAddUser.Click += new System.EventHandler(this.metroBtnAddUser_Click);
            // 
            // btnGroupsGet
            // 
            this.btnGroupsGet.Location = new System.Drawing.Point(545, 180);
            this.btnGroupsGet.Margin = new System.Windows.Forms.Padding(2);
            this.btnGroupsGet.Name = "btnGroupsGet";
            this.btnGroupsGet.Size = new System.Drawing.Size(95, 21);
            this.btnGroupsGet.TabIndex = 103;
            this.btnGroupsGet.Text = "Get Groups";
            this.btnGroupsGet.Click += new System.EventHandler(this.btnGroupsGet_Click);
            // 
            // dgwOktaGroupList
            // 
            this.dgwOktaGroupList.AllowUserToAddRows = false;
            this.dgwOktaGroupList.AllowUserToDeleteRows = false;
            this.dgwOktaGroupList.AllowUserToOrderColumns = true;
            this.dgwOktaGroupList.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgwOktaGroupList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgwOktaGroupList.Location = new System.Drawing.Point(545, 15);
            this.dgwOktaGroupList.Margin = new System.Windows.Forms.Padding(2);
            this.dgwOktaGroupList.MultiSelect = false;
            this.dgwOktaGroupList.Name = "dgwOktaGroupList";
            this.dgwOktaGroupList.ReadOnly = true;
            this.dgwOktaGroupList.RowTemplate.Height = 28;
            this.dgwOktaGroupList.Size = new System.Drawing.Size(515, 161);
            this.dgwOktaGroupList.TabIndex = 102;
            // 
            // btnClearSessions
            // 
            this.btnClearSessions.Location = new System.Drawing.Point(545, 246);
            this.btnClearSessions.Margin = new System.Windows.Forms.Padding(2);
            this.btnClearSessions.Name = "btnClearSessions";
            this.btnClearSessions.Size = new System.Drawing.Size(95, 31);
            this.btnClearSessions.TabIndex = 101;
            this.btnClearSessions.Text = "Clear Sessions";
            this.btnClearSessions.Click += new System.EventHandler(this.btnClearSessions_Click);
            // 
            // btnResetFactors
            // 
            this.btnResetFactors.Location = new System.Drawing.Point(644, 246);
            this.btnResetFactors.Margin = new System.Windows.Forms.Padding(2);
            this.btnResetFactors.Name = "btnResetFactors";
            this.btnResetFactors.Size = new System.Drawing.Size(95, 31);
            this.btnResetFactors.TabIndex = 100;
            this.btnResetFactors.Text = "Reset Factors";
            this.btnResetFactors.Click += new System.EventHandler(this.btnResetFactors_Click);
            // 
            // metroBtnDeleteUser
            // 
            this.metroBtnDeleteUser.Location = new System.Drawing.Point(434, 180);
            this.metroBtnDeleteUser.Margin = new System.Windows.Forms.Padding(2);
            this.metroBtnDeleteUser.Name = "metroBtnDeleteUser";
            this.metroBtnDeleteUser.Size = new System.Drawing.Size(95, 21);
            this.metroBtnDeleteUser.TabIndex = 99;
            this.metroBtnDeleteUser.Text = "Delete User";
            this.metroBtnDeleteUser.Click += new System.EventHandler(this.metroBtnDeleteUser_Click);
            // 
            // metroBtnLogin
            // 
            this.metroBtnLogin.Location = new System.Drawing.Point(14, 362);
            this.metroBtnLogin.Margin = new System.Windows.Forms.Padding(2);
            this.metroBtnLogin.Name = "metroBtnLogin";
            this.metroBtnLogin.Size = new System.Drawing.Size(299, 21);
            this.metroBtnLogin.TabIndex = 98;
            this.metroBtnLogin.Text = "Login";
            this.metroBtnLogin.Click += new System.EventHandler(this.metroBtnLogin_Click);
            // 
            // metroBtnUpdateUser
            // 
            this.metroBtnUpdateUser.Location = new System.Drawing.Point(336, 180);
            this.metroBtnUpdateUser.Margin = new System.Windows.Forms.Padding(2);
            this.metroBtnUpdateUser.Name = "metroBtnUpdateUser";
            this.metroBtnUpdateUser.Size = new System.Drawing.Size(95, 21);
            this.metroBtnUpdateUser.TabIndex = 96;
            this.metroBtnUpdateUser.Text = "Update User";
            this.metroBtnUpdateUser.Click += new System.EventHandler(this.metroBtnUpdateUser_Click);
            // 
            // metroBtnCreateUser
            // 
            this.metroBtnCreateUser.Location = new System.Drawing.Point(238, 180);
            this.metroBtnCreateUser.Margin = new System.Windows.Forms.Padding(2);
            this.metroBtnCreateUser.Name = "metroBtnCreateUser";
            this.metroBtnCreateUser.Size = new System.Drawing.Size(95, 21);
            this.metroBtnCreateUser.TabIndex = 93;
            this.metroBtnCreateUser.Text = "Create User";
            this.metroBtnCreateUser.Click += new System.EventHandler(this.metroBtnCreateUser_Click);
            // 
            // btnCreateProfile
            // 
            this.btnCreateProfile.Location = new System.Drawing.Point(14, 246);
            this.btnCreateProfile.Margin = new System.Windows.Forms.Padding(2);
            this.btnCreateProfile.Name = "btnCreateProfile";
            this.btnCreateProfile.Size = new System.Drawing.Size(223, 31);
            this.btnCreateProfile.TabIndex = 85;
            this.btnCreateProfile.Text = "Signin With API";
            this.btnCreateProfile.Click += new System.EventHandler(this.btnCreateProfile_Click);
            // 
            // dgwOktaUserList
            // 
            this.dgwOktaUserList.AllowUserToAddRows = false;
            this.dgwOktaUserList.AllowUserToDeleteRows = false;
            this.dgwOktaUserList.AllowUserToOrderColumns = true;
            this.dgwOktaUserList.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgwOktaUserList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgwOktaUserList.Location = new System.Drawing.Point(14, 15);
            this.dgwOktaUserList.Margin = new System.Windows.Forms.Padding(2);
            this.dgwOktaUserList.MultiSelect = false;
            this.dgwOktaUserList.Name = "dgwOktaUserList";
            this.dgwOktaUserList.ReadOnly = true;
            this.dgwOktaUserList.RowTemplate.Height = 28;
            this.dgwOktaUserList.Size = new System.Drawing.Size(515, 161);
            this.dgwOktaUserList.TabIndex = 91;
            // 
            // btnProfilesGet
            // 
            this.btnProfilesGet.Location = new System.Drawing.Point(14, 178);
            this.btnProfilesGet.Margin = new System.Windows.Forms.Padding(2);
            this.btnProfilesGet.Name = "btnProfilesGet";
            this.btnProfilesGet.Size = new System.Drawing.Size(95, 22);
            this.btnProfilesGet.TabIndex = 84;
            this.btnProfilesGet.Text = "Get Users";
            this.btnProfilesGet.Click += new System.EventHandler(this.btnUsersGet_Click);
            // 
            // Apps
            // 
            this.Apps.Controls.Add(this.tabProfiles);
            this.Apps.Location = new System.Drawing.Point(37, 96);
            this.Apps.Margin = new System.Windows.Forms.Padding(2);
            this.Apps.Name = "Apps";
            this.Apps.SelectedIndex = 0;
            this.Apps.Size = new System.Drawing.Size(1070, 329);
            this.Apps.TabIndex = 38;
            // 
            // WinFormRestAPI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BorderStyle = MetroFramework.Drawing.MetroBorderStyle.FixedSingle;
            this.ClientSize = new System.Drawing.Size(1141, 732);
            this.Controls.Add(this.Apps);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textApiToken);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.txtResult);
            this.Controls.Add(textOktaUrl);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "WinFormRestAPI";
            this.Padding = new System.Windows.Forms.Padding(13, 60, 13, 13);
            this.Resizable = false;
            this.ShadowType = MetroFramework.Forms.MetroForm.MetroFormShadowType.SystemShadow;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.Style = MetroFramework.MetroColorStyle.Blue;
            this.Text = "Okta API";
            this.Theme = MetroFramework.MetroThemeStyle.Light;
            ((System.ComponentModel.ISupportInitialize)(this.metroUserName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.metroPassword)).EndInit();
            this.tabProfiles.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgwOktaGroupList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgwOktaUserList)).EndInit();
            this.Apps.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroLabel label1;
        private MetroFramework.Controls.MetroButton btnClear;
        private MetroFramework.Controls.MetroTextBox textApiToken;
        private MetroFramework.Controls.MetroLabel label6;
        private System.Windows.Forms.RichTextBox txtResult;
        private MetroFramework.Components.MetroStyleManager metroUserName;
        private MetroFramework.Components.MetroStyleManager metroPassword;
        private MetroFramework.Controls.MetroTabPage tabProfiles;
        private MetroFramework.Controls.MetroButton metroBtnLogin;
        private MetroFramework.Controls.MetroButton metroBtnUpdateUser;
        private MetroFramework.Controls.MetroButton metroBtnCreateUser;
        private MetroFramework.Controls.MetroButton btnCreateProfile;
        private System.Windows.Forms.DataGridView dgwOktaUserList;
        private MetroFramework.Controls.MetroButton btnProfilesGet;
        private MetroFramework.Controls.MetroTabControl Apps;
        private MetroFramework.Controls.MetroButton metroBtnDeleteUser;
        private MetroFramework.Controls.MetroButton btnResetFactors;
        private MetroFramework.Controls.MetroButton btnClearSessions;
        private MetroFramework.Controls.MetroButton btnGroupsGet;
        private System.Windows.Forms.DataGridView dgwOktaGroupList;
        private MetroFramework.Controls.MetroButton metroBtnDelUser;
        private MetroFramework.Controls.MetroButton metroBtnAddUser;
        private MetroFramework.Controls.MetroButton metroBtnBrower;
    }
}

