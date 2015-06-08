using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TeaRoom.MemberServices;
using DevExpress.XtraEditors;

namespace TeaRoom.Modules
{
    public partial class Member_Add : UserControl
    {

        private string _operatID = string.Empty;
        public string OperatID
        {
            get { return _operatID; }
            set { _operatID = value; }
        }

        public Member_Add()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (this.splashScreenManager1.IsSplashFormVisible == false)
                this.splashScreenManager1.ShowWaitForm();

            dxErrorProvider1.ClearErrors();
            if (this.txtName.Text.Trim() == "") {
                dxErrorProvider1.SetError(txtName, "请输入用户名", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Information);
            }

            if (this.txtCardNumber.Text.Trim() == "") {
                dxErrorProvider1.SetError(txtCardNumber, "请输入会员卡号", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Information);
            }

            if (this.txtBrithday.Text.Trim() == "") {
                dxErrorProvider1.SetError(txtBrithday, "请设置会员生日是", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Information);
            }

            if (this.txtAmount.Text.Trim() == "")
            {
                dxErrorProvider1.SetError(txtAmount, "请输入金额", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Information);
            }


            if (dxErrorProvider1.HasErrors == true) {
                if (this.splashScreenManager1.IsSplashFormVisible == true)
                    this.splashScreenManager1.CloseWaitForm();
                return;
            }
            MemberServicesSoapClient Services = new MemberServicesSoapClient();
            Services.AddMembersCompleted += new EventHandler<AddMembersCompletedEventArgs>(Services_AddMemberCompleted);
            Services.AddMembersAsync(this.txtName.Text, this.rad_Sex.EditValue.ToString() ,this.txtCardNumber.Text, this.txtBrithday.Text, this.txtTel.Text, Convert.ToDecimal(this.txtAmount.Text), OperatID);
        }



        void Services_AddMemberCompleted(object sender, AddMembersCompletedEventArgs e)
        {
            if (e.Result.Status == 1)
            {
                XtraMessageBox.Show("会员添加成功");
                this.txtAmount.Text = "";
                this.txtBrithday.Text = "";
                this.txtCardNumber.Text = "";
                this.txtName.Text = "";
                this.txtTel.Text = "";
            }
            else
            {
                XtraMessageBox.Show(e.Result.MessageString);
            }

            if (this.splashScreenManager1.IsSplashFormVisible == true)
                this.splashScreenManager1.CloseWaitForm();
        }
    }
}
