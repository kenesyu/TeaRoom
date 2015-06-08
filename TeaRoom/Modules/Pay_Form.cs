using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Drawing.Printing;

namespace TeaRoom.Modules
{
    public partial class Pay_Form : DevExpress.XtraEditors.XtraForm
    {
        private DataTable dt_dataSource;
        public DataTable DataSource {
            set { dt_dataSource = value; }
            get { return dt_dataSource; }
        }

        public Pay_Form()
        {
            InitializeComponent();
        }

        private void radioGroup1_EditValueChanged(object sender, EventArgs e)
        {
            if (this.rad_PayWay.EditValue.ToString() == "3")
            {
                this.txtCardNo.Enabled = true;
                this.btnSearch.Enabled = true;
            }
            else {
                this.txtCardNo.Text = "";
                this.txtCardNo.Enabled = false;
                this.lbl_yuer.Text = "";
                this.btnSearch.Enabled = false;
            }
            CalculateAmount();
        }

        private void Pay_Form_Load(object sender, EventArgs e)
        {
            this.gridControl1.DataSource = DataSource;
            CalculateAmount();
        }

        private void CalculateAmount() {
            decimal amount = 0;
            if (this.rad_PayWay.EditValue.ToString() == "3")
            {
                foreach (DataRow dr in dt_dataSource.Rows) {
                    if (dr["MemberPrice"].ToString()!="0")
                        amount += int.Parse(dr["Qty"].ToString()) * decimal.Parse(dr["MemberPrice"].ToString());
                }
            }
            else {
                foreach (DataRow dr in dt_dataSource.Rows)
                {
                    if (dr["Price"].ToString() != "0")
                        amount += int.Parse(dr["Qty"].ToString()) * decimal.Parse(dr["Price"].ToString());
                }
            }
            this.txtAmount.Text = amount.ToString();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (this.txtCardNo.Text.Trim() != "") {
                MemberServices.MemberServicesSoapClient Service = new MemberServices.MemberServicesSoapClient();
                Service.GetMemberByCardNoCompleted += new EventHandler<MemberServices.GetMemberByCardNoCompletedEventArgs>(Service_GetMemberByCardNoCompleted);
                Service.GetMemberByCardNoAsync(this.txtCardNo.Text.Trim());
            }
        }

        void Service_GetMemberByCardNoCompleted(object sender, MemberServices.GetMemberByCardNoCompletedEventArgs e)
        {
            if (e.Result.MemberID != 0)
            {
                this.lbl_yuer.Text = e.Result.Amount.ToString();
            }
            else {
                XtraMessageBox.Show("没有找到该会员卡信息！");
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            //PrintPos();
        }

        private void PrintPos(){
            //打印预览            

            PrintPreviewDialog ppd = new PrintPreviewDialog();

            PrintDocument pd = new PrintDocument();



            //设置边距

            Margins margin = new Margins(20, 20, 10, 10);

            pd.DefaultPageSettings.Margins = margin;



            ////纸张设置默认

            PaperSize pageSize = new PaperSize("First custom size", getYc(58), 600);

            pd.DefaultPageSettings.PaperSize = pageSize;



            //打印事件设置            

            pd.PrintPage += new PrintPageEventHandler(pd_PrintPage); //、、new PrintPageEventHandler(this.GetPrintStr);

            ppd.Document = pd;

            ppd.ShowDialog();



            try
            {

                //pd.Print();

            }

            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "打印出错", MessageBoxButtons.OK, MessageBoxIcon.Error);

                pd.PrintController.OnEndPrint(pd, new PrintEventArgs());

            }
        
        }

        void pd_PrintPage(object sender, PrintPageEventArgs e)
        {
            //*如果需要改变自己 可以在new Font(new FontFamily("宋体"),11）中的“宋体”改成自己要的字体就行了，宋体 后面的数字代表字体的大小System.Drawing.Brushes.Blue , 170, 10 中的 System.Drawing.Brushes.Blue 为颜色，后面的为输出的位置 */
            //e.Graphics.DrawString("新乡市三月软件公司入库单", new Font(new FontFamily("宋体"),11), System.Drawing.Brushes.Black, 170, 10);
            e.Graphics.DrawString("欢迎光临大连北苑茶楼", new Font(new FontFamily("宋体"), 11), System.Drawing.Brushes.Black, 10, 12);
            //信息的名称
            e.Graphics.DrawLine(Pens.Black, 6, 30, 460, 30);
            e.Graphics.DrawString("名称" , new Font(new FontFamily("宋体"), 8), System.Drawing.Brushes.Black, 6, 35);
            e.Graphics.DrawString("数量", new Font(new FontFamily("宋体"), 8), System.Drawing.Brushes.Black, 100, 35);
            e.Graphics.DrawString("单价", new Font(new FontFamily("宋体"), 8), System.Drawing.Brushes.Black, 160, 35);
            //e.Graphics.DrawString("单价", new Font(new FontFamily("宋体"), 8), System.Drawing.Brushes.Black, 330, 35);
            //e.Graphics.DrawString("总金额", new Font(new FontFamily("宋体"), 8), System.Drawing.Brushes.Black, 400, 35);
            e.Graphics.DrawLine (Pens.Black ,6,50,460,50);
            //产品信息

            int StartHeight = 35;

            for (int i = 0; i < this.dt_dataSource.Rows.Count; i++) {
                StartHeight += 20;
                e.Graphics.DrawString(dt_dataSource.Rows[i]["ProductName"].ToString(), new Font(new FontFamily("宋体"), 8), System.Drawing.Brushes.Black, 6, StartHeight);
                e.Graphics.DrawString(dt_dataSource.Rows[i]["Qty"].ToString(), new Font(new FontFamily("宋体"), 8), System.Drawing.Brushes.Black, 100, StartHeight);
                if(this.rad_PayWay.SelectedIndex == 2) //会员结帐显示会员价
                    e.Graphics.DrawString(printAmount(dt_dataSource.Rows[i]["MemberPrice"].ToString()), new Font(new FontFamily("宋体"), 8), System.Drawing.Brushes.Black, 160, StartHeight);
                else
                    e.Graphics.DrawString(printAmount(dt_dataSource.Rows[i]["Price"].ToString()), new Font(new FontFamily("宋体"), 8), System.Drawing.Brushes.Black, 160, StartHeight);
            }

            StartHeight += 18;
            e.Graphics.DrawLine(Pens.Black, 6, StartHeight, 460, StartHeight);
            StartHeight += 5;
            e.Graphics.DrawString("支付类型:" + this.rad_PayWay.Properties.Items[this.rad_PayWay.SelectedIndex].Description, new Font(new FontFamily("黑体"), 8), System.Drawing.Brushes.Black, 6, StartHeight);
            StartHeight += 20;
            e.Graphics.DrawString("消费金额:" + this.txtAmount.Text, new Font(new FontFamily("黑体"), 8), System.Drawing.Brushes.Black, 6, StartHeight);
            StartHeight += 20;
            e.Graphics.DrawString("欢迎下次光临 " + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"), new Font(new FontFamily("黑体"), 8), System.Drawing.Brushes.Black, 6, StartHeight);
        }

        private int getYc(double cm)
        {
            return (int)(cm / 25.4) * 100;
        }

        private string printAmount(string Amount){
            if(Amount.Length == 6){
                return Amount;
            }
            else{
                int addcount = 6 - Amount.Length;
                for (int i = 0; i < addcount; i++)
                {
                    Amount = " " + Amount;
                }
                return Amount;
            }
        }
    }
}