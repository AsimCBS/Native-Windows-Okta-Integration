namespace WindowsRestAPI
{
    partial class LoginForm
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
            this.btnLogin = new MetroFramework.Controls.MetroButton();
            this.textPassword = new MetroFramework.Controls.MetroTextBox();
            this.textUserName = new MetroFramework.Controls.MetroTextBox();
            this.label6 = new MetroFramework.Controls.MetroLabel();
            this.lblPassword = new MetroFramework.Controls.MetroLabel();
            this.lblUserName = new MetroFramework.Controls.MetroLabel();
            this.btnLoginAPI = new MetroFramework.Controls.MetroButton();
            this.SuspendLayout();
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(59, 182);
            this.btnLogin.Margin = new System.Windows.Forms.Padding(2);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(291, 33);
            this.btnLogin.TabIndex = 3;
            this.btnLogin.Text = "Login with Okta SDK";
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // textPassword
            // 
            this.textPassword.CustomBackground = true;
            this.textPassword.Location = new System.Drawing.Point(161, 137);
            this.textPassword.Margin = new System.Windows.Forms.Padding(2);
            this.textPassword.Name = "textPassword";
            this.textPassword.PasswordChar = '*';
            this.textPassword.Size = new System.Drawing.Size(189, 17);
            this.textPassword.TabIndex = 59;
            this.textPassword.Text = "Arebareb1";
            // 
            // textUserName
            // 
            this.textUserName.CustomBackground = true;
            this.textUserName.Location = new System.Drawing.Point(161, 96);
            this.textUserName.Margin = new System.Windows.Forms.Padding(2);
            this.textUserName.Name = "textUserName";
            this.textUserName.Size = new System.Drawing.Size(189, 17);
            this.textUserName.TabIndex = 58;
            this.textUserName.Text = "irecondo@dcirecondo.co.uk";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(59, 158);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(0, 0);
            this.label6.TabIndex = 57;
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(59, 135);
            this.lblPassword.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(63, 19);
            this.lblPassword.TabIndex = 56;
            this.lblPassword.Text = "Password";
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Location = new System.Drawing.Point(59, 96);
            this.lblUserName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(68, 19);
            this.lblUserName.TabIndex = 55;
            this.lblUserName.Text = "Username";
            // 
            // btnLoginAPI
            // 
            this.btnLoginAPI.Location = new System.Drawing.Point(59, 234);
            this.btnLoginAPI.Margin = new System.Windows.Forms.Padding(2);
            this.btnLoginAPI.Name = "btnLoginAPI";
            this.btnLoginAPI.Size = new System.Drawing.Size(291, 33);
            this.btnLoginAPI.TabIndex = 60;
            this.btnLoginAPI.Text = "Login with Okta API";
            this.btnLoginAPI.Click += new System.EventHandler(this.btnLoginAPI_Click);
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(426, 300);
            this.Controls.Add(this.btnLoginAPI);
            this.Controls.Add(this.textPassword);
            this.Controls.Add(this.textUserName);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.lblUserName);
            this.Controls.Add(this.btnLogin);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "LoginForm";
            this.Padding = new System.Windows.Forms.Padding(13, 60, 13, 13);
            this.Text = "Login Form";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroButton btnLogin;
        private MetroFramework.Controls.MetroTextBox textPassword;
        private MetroFramework.Controls.MetroTextBox textUserName;
        private MetroFramework.Controls.MetroLabel label6;
        private MetroFramework.Controls.MetroLabel lblPassword;
        private MetroFramework.Controls.MetroLabel lblUserName;
        private MetroFramework.Controls.MetroButton btnLoginAPI;
    }
}