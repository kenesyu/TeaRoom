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
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraSplashScreen;

namespace TeaRoom.Modules
{
    public partial class Member_List : UserControl
    {
        public int currentPage;
        public int PageSize = 10;
        private string _operatID = string.Empty;
        public string OperatID
        {
            get { return _operatID; }
            set { _operatID = value; }
        }

        public Member_List(string OperatID)
        {
            InitializeComponent();
            #region Add Members
            Member_Add form = new Member_Add();
            form.OperatID = OperatID;
            form.Dock = DockStyle.Fill;
            this.panel_AddMember.Controls.Add(form);
            #endregion
        }

        private void Member_List_Load(object sender, EventArgs e)
        {
            Search(1, PageSize);
            //currentPage = 1;
        }

        void Services_GetMemberListCompleted(object sender, GetMemberListCompletedEventArgs e)
        {
            if (e.Result.Length > 0)
            {
                this.gridControl1.DataSource = e.Result;
                int TotalPage = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(e.TotalCount) / PageSize));
                this.PageInfo.Text = "共" + e.TotalCount.ToString() + "条信息 第" + currentPage + "/" + TotalPage + "页";
                if (currentPage == 1) { this.btnUp.Enabled = false; }
                else { this.btnUp.Enabled = true; }
                if (currentPage == TotalPage) { this.btnDown.Enabled = false; }
                else { this.btnDown.Enabled = true; }
            }
            else {
                XtraMessageBox.Show("没有找到您要查询的数据");
            }
            if (this.splashScreenManager1.IsSplashFormVisible == true)
                this.splashScreenManager1.CloseWaitForm();
        }

        private void Search(int Page,int PageSize) {
            if (this.splashScreenManager1.IsSplashFormVisible == false)
                this.splashScreenManager1.ShowWaitForm();
            currentPage = Page;
            MemberServicesSoapClient Services = new MemberServicesSoapClient();
            Services.GetMemberListCompleted += new EventHandler<GetMemberListCompletedEventArgs>(Services_GetMemberListCompleted);
            Services.GetMemberListAsync(Page, PageSize, this.txtCardNo.Text);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Search(1, PageSize);
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            Search(currentPage - 1, PageSize);
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            Search(currentPage + 1, PageSize);
        }

        private void repositoryItemButtonEdit1_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            if (this.splashScreenManager1.IsSplashFormVisible == false)
                this.splashScreenManager1.ShowWaitForm();
            T_Members member = (T_Members)this.gridView1.GetFocusedRow();
            MemberServicesSoapClient Services = new MemberServicesSoapClient();
            Services.MemberUpdateCompleted +=new EventHandler<MemberUpdateCompletedEventArgs>(Services_MemberUpdateCompleted);
            Services.MemberUpdateAsync(member.MemberID, member.Name, member.Sex ,Convert.ToDateTime(member.Birthday).ToString("yyyy-MM-dd"), member.Tel);
        }

        void Services_MemberUpdateCompleted(object sender, MemberUpdateCompletedEventArgs e){
            if (e.Result.Status == 1)
            {
                XtraMessageBox.Show("保存成功");
            }
            else { 
            
            }
            if (this.splashScreenManager1.IsSplashFormVisible == true)
                this.splashScreenManager1.CloseWaitForm();
        }

        private void repositoryItemButtonEdit2_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            ButtonEdit editor = sender as ButtonEdit;
            if (editor.EditValue.ToString() == null)
                return;
            decimal amount = Convert.ToDecimal(editor.EditValue.ToString());
            T_Members member = (T_Members)this.gridView1.GetFocusedRow();
            var confirmResult = XtraMessageBox.Show("确定为会员 " + member.Name + " 卡号[" + member.CardNo + "] 充值 ￥" + amount + " ?",
                                     "会员充值!!", MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                if (this.splashScreenManager1.IsSplashFormVisible == false)
                    this.splashScreenManager1.ShowWaitForm();
                MemberServicesSoapClient Services = new MemberServicesSoapClient();
                Services.MemberRechargeCompleted += new EventHandler<MemberRechargeCompletedEventArgs>(Services_MemberRechargeCompleted);
                Services.MemberRechargeAsync(member.MemberID, amount.ToString(), OperatID);
            }
            else
            {
                editor.EditValue = "";
            }
        }

        void Services_MemberRechargeCompleted(object sender, MemberRechargeCompletedEventArgs e) {
            if (e.Result.Status == 1)
            {
                this.btnSearch.PerformClick();
                XtraMessageBox.Show("充值成功");
            }
            else {
                XtraMessageBox.Show(e.Result.MessageString);
            }
            if (this.splashScreenManager1.IsSplashFormVisible == true)
                this.splashScreenManager1.CloseWaitForm();
        }
    }
}
