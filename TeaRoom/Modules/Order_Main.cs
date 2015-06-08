using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TeaRoom.ProductServices;

namespace TeaRoom.Modules
{
    public partial class Order_Main : UserControl
    {
        private string _operatID = string.Empty;

        public DataTable dtSource = new DataTable();


        public string OperatID
        {
            get { return _operatID; }
            set { _operatID = value; }
        }

        public Order_Main()
        {
            InitializeComponent();
            GetProduct();
            InitDataTable();
        }


        private void GetProduct() {
            if (this.splashScreenManager1.IsSplashFormVisible == false)
                this.splashScreenManager1.ShowWaitForm();
            ProdctServicesSoapClient Services = new ProdctServicesSoapClient();
            Services.GetProductListCompleted +=new EventHandler<GetProductListCompletedEventArgs>(Services_GetProductListCompleted);
            Services.GetProductListAsync();
        }

        private void InitDataTable() {
            dtSource.Columns.Add("ID");
            dtSource.Columns.Add("ProductName");
            dtSource.Columns.Add("Qty");
            dtSource.Columns.Add("Price");
            dtSource.Columns.Add("MemberPrice");
        }
        

        void Services_GetProductListCompleted(object sender, GetProductListCompletedEventArgs e)
        {
            if (e.Result.Length > 0) {
                int sx = 5;
                int sy = 5;

                int btnx = 5;
                int btny = 20;
                T_Products[] productList = e.Result;

                int retTR = 1;


                string strLable = string.Empty;
                for (int i = 1; i <= productList.Length; i++)
                {
                    if (productList[i - 1].ProductTypeName != strLable)
                    {
                        strLable = productList[i - 1].ProductTypeName;
                        //DevExpress.XtraEditors.GroupControl group = new DevExpress.XtraEditors.GroupControl();
                        GroupBox group = new GroupBox();
                        group.Text = productList[i - 1].ProductTypeName;
                        group.Name = "group_" + productList[i - 1].ProductTypeID;
                        group.Location = new Point(sx, sy);
                        group.Width = 630;
                        group.Height = 80;
                        group.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
                        this.panelControl2.Controls.Add(group);
                        sy += 80;
                        retTR = 1;
                        btnx = 5;
                        btny = 20;
                    }


                    if (retTR!=1 && retTR % 6 == 1)
                    {
                        btny += 54;
                        btnx = 5;
                        sy += 54;
                        this.panelControl2.Controls.Find("group_" + productList[i - 1].ProductTypeID, true)[0].Height += 54;
                    }


                    DevExpress.XtraEditors.SimpleButton btnMenu = new DevExpress.XtraEditors.SimpleButton();
                    btnMenu.Tag = productList[i - 1].ProductID + ","
                        + productList[i - 1].Price + ","
                        + productList[i - 1].MemberPrice;
                    btnMenu.Text = productList[i - 1].ProductName;
                    btnMenu.Width = 100;
                    btnMenu.Height = 50;
                    btnMenu.Location = new Point(btnx, btny);
                    btnMenu.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Default;
                    btnMenu.Click += new EventHandler(aa_Click);
                    this.panelControl2.Controls.Find("group_" + productList[i - 1].ProductTypeID,true)[0].Controls.Add(btnMenu);
                    btnx += 104;
                    


                    retTR += 1;

                    //DevExpress.XtraEditors.SimpleButton btnMenu = new DevExpress.XtraEditors.SimpleButton();
                    //btnMenu.Tag = productList[i - 1].ProductID + ","
                    //    + productList[i - 1].Price + ","
                    //    + productList[i - 1].MemberPrice;
                    //btnMenu.Text = productList[i - 1].ProductName;
                    //btnMenu.Width = 100;
                    //btnMenu.Height = 50;
                    //btnMenu.Location = new Point(sx, sy);
                    //btnMenu.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Default;
                    //btnMenu.Click += new EventHandler(aa_Click);
                    ////btnMenu.DataBindings = productList[i - 1];
                    //this.panelControl2.Controls.Add(btnMenu);

                    //sx += 104;
                    //if (i % 6 == 0)
                    //{
                    //    sy += 54;
                    //    sx = 5;
                    //}
                }

            }
            if (this.splashScreenManager1.IsSplashFormVisible == true)
                this.splashScreenManager1.CloseWaitForm();
        }

        void aa_Click(object sender, EventArgs e)
        {
            DevExpress.XtraEditors.SimpleButton button = sender as DevExpress.XtraEditors.SimpleButton;
            if (dtSource.Select("id = '" + button.Tag.ToString().Split(',')[0] + "'").Length == 0) {
                DataRow dr = dtSource.NewRow();
                dr["id"] = button.Tag.ToString().Split(',')[0];
                dr["ProductName"] = button.Text;
                dr["Qty"] = 1;
                dr["Price"] = button.Tag.ToString().Split(',')[1];
                dr["MemberPrice"] = button.Tag.ToString().Split(',')[2];
                this.dtSource.Rows.Add(dr);
            }
            this.gridControl1.DataSource = dtSource;
            this.gridControl1.RefreshDataSource();
        }

        private void repositoryItemButtonEdit1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            //int[] delIndex = this.gridView1.GetSelectedRows();
            gridView1.DeleteSelectedRows();
        }

        private void repositoryItemSpinEdit1_EditValueChanged(object sender, EventArgs e)
        {
            int[] currentIndex = this.gridView1.GetSelectedRows();
            dtSource.Rows[currentIndex[0]]["Qty"] = (sender as DevExpress.XtraEditors.SpinEdit).EditValue;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            Pay_Form pay = new Pay_Form();
            pay.DataSource = dtSource;
            pay.ShowDialog();
        }
    }
}
