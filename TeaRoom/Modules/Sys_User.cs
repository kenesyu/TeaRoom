using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TeaRoom.OperatServices;
using DevExpress.XtraEditors;


namespace TeaRoom.Modules
{
    public partial class Sys_User : UserControl
    {
        public Sys_User()
        {
            InitializeComponent();
        }

        private void Sys_User_Load(object sender, EventArgs e)
        {
            this.radUserGroup.Properties.Items.Add(new DevExpress.XtraEditors.Controls.RadioGroupItem("2", "收银员"));
            this.radUserGroup.Properties.Items.Add(new DevExpress.XtraEditors.Controls.RadioGroupItem("1", "系统管理员"));
            this.radUserGroup.SelectedIndex = 0;
            OperatServices.OperatServicesSoapClient Service = new OperatServices.OperatServicesSoapClient();
            Service.GetOperatListCompleted += new EventHandler<OperatServices.GetOperatListCompletedEventArgs>(Service_GetOperatListCompleted);
            Service.GetOperatListAsync();
        }

        void Service_GetOperatListCompleted(object sender, OperatServices.GetOperatListCompletedEventArgs e)
        {
            if (e.Result.Length > 0)
            {
                this.gridControl1.DataSource = e.Result;
            }
        }

        private void repositoryItemButtonEdit1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            T_Operat_User op = (T_Operat_User)this.gridView1.GetFocusedRow();
            this.txtOperatID.Text = op.OperatID.ToString();
            this.txtUserName.Text = op.UserName;
            this.txtPassword.Text = op.PassWord;
            this.txtName.Text = op.OperatName;
            this.txtTel.Text = op.Tel;
            if (op.Active == 1)
            {
                this.toggleSwitch1.IsOn = true;
            }
            else
            {
                this.toggleSwitch1.IsOn = false;
            }
            this.radUserGroup.EditValue = op.OperatGroup.ToString();
            this.btnAdd.Text = "修改";
        }

        /// <summary>
        /// Save Or Update
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (this.txtPassword.Text.Trim() == "") {
                XtraMessageBox.Show("密码不能为空");
                return;
            }

            if (this.txtUserName.Text.Trim() == "")
            {
                XtraMessageBox.Show("用户名不能为空");
                return;
            }

            string Active = "0";
            if (this.toggleSwitch1.EditValue.ToString() == "True") {
                Active = "1";
            }
            OperatServices.OperatServicesSoapClient Service = new OperatServices.OperatServicesSoapClient();
            Service.SaveOrUpdateOperatCompleted += new EventHandler<SaveOrUpdateOperatCompletedEventArgs>(Service_SaveOrUpdateOperatCompleted);
            Service.SaveOrUpdateOperatAsync(this.txtPassword.Text, this.txtUserName.Text.Trim(), this.txtName.Text, this.txtTel.Text,
                Active, this.radUserGroup.EditValue.ToString(), this.txtOperatID.Text);
        }

        void Service_SaveOrUpdateOperatCompleted(object sender, SaveOrUpdateOperatCompletedEventArgs e)
        {
            if (e.Result == 1)
            {
                this.btnCancel.PerformClick();
                XtraMessageBox.Show("操作成功");
                OperatServices.OperatServicesSoapClient Service = new OperatServices.OperatServicesSoapClient();
                Service.GetOperatListCompleted += new EventHandler<OperatServices.GetOperatListCompletedEventArgs>(Service_GetOperatListCompleted);
                Service.GetOperatListAsync();
            }
            else {
                XtraMessageBox.Show("该用户名已存！");
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            this.txtOperatID.Text = "";
            this.txtUserName.Text = "";
            this.txtTel.Text = "";
            this.txtPassword.Text = "";
            this.txtName.Text = "";
            this.radUserGroup.SelectedIndex = 0;
            this.toggleSwitch1.IsOn = true;
            this.btnAdd.Text = "添加";
        }
    }
}
