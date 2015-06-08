using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.Skins;
using DevExpress.LookAndFeel;
using DevExpress.UserSkins;
using DevExpress.XtraBars.Helpers;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using TeaRoom.OperatServices;
using DevExpress.XtraEditors;
using System.Threading;
using DevExpress.XtraSplashScreen;

namespace TeaRoom
{
    public partial class LoginForm : DevExpress.XtraEditors.XtraForm
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {

            if (this.txtUserName.Text.Trim() == "") {
                //dxErrorProvider1.SetError(txtUserName, "请输入用户名", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Information);//DXErrorProvider.SetError(验 证的控件,错误提示，提示图标)
                XtraMessageBox.Show("请输入用户名");
                return;
            }
            if (this.txtPassword.Text.Trim() == "")
            {
                XtraMessageBox.Show("请输入密码");
                return;
            }
            this.btnLogin.Enabled = false;
            OperatServices.OperatServicesSoapClient Services = new OperatServicesSoapClient();
            Services.UserLoginCompleted += new EventHandler<UserLoginCompletedEventArgs>(Services_UserLoginCompleted);
            Services.UserLoginAsync(this.txtUserName.Text,this.txtPassword.Text);
        }


        void Services_UserLoginCompleted(object sender, UserLoginCompletedEventArgs e)
        {
            if (e.Result.OperatID !=0)
            {
                MainForm form = new MainForm(e.Result.OperatID);
                form.Show();
                this.Hide();
            }
            else
            {
                this.btnLogin.Enabled = true;
                XtraMessageBox.Show("该用户不存在或已被禁用!");
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(0); 
        }
    }
}