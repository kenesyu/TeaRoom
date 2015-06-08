using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using TeaRoom.Modules;
using System.Drawing.Printing;
using DevExpress.XtraSplashScreen;

namespace TeaRoom
{
    public partial class MainForm : DevExpress.XtraEditors.XtraForm
    {

        public MainForm(int OperatID)
        {
            InitializeComponent();
            this.txtOperatID.Text = OperatID.ToString();
            //this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            //this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            System.Environment.Exit(0);
        }

        /// <summary>
        /// 添加会员
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddMembers_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Panel_MainBox.Controls.Clear();
            Member_Add form = new Member_Add();
            form.OperatID = this.txtOperatID.Text;
            form.Dock = DockStyle.Fill;
            this.Panel_MainBox.Controls.Add(form);
        }

        /// <summary>
        /// 会员管理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Panel_MainBox.Controls.Clear();
            Member_List form = new Member_List(this.txtOperatID.Text);
            form.Dock = DockStyle.Fill;
            form.OperatID = this.txtOperatID.Text;
            this.Panel_MainBox.Controls.Add(form);
        }

        /// <summary>
        /// 快速下单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Panel_MainBox.Controls.Clear();
            Order_Main form = new Order_Main();
            form.Dock = DockStyle.Fill;
            form.OperatID = this.txtOperatID.Text;
            this.Panel_MainBox.Controls.Add(form);
        }

        /// <summary>
        /// 系统用户
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Panel_MainBox.Controls.Clear();
            Sys_User form = new Sys_User();
            form.Dock = DockStyle.Fill;
            this.Panel_MainBox.Controls.Add(form);
        }

        #region 打印

        //int lineSize = 20;                   //设置每行打印字数
        //int lineHeight = 22;                 //行高  1/100 英寸
        //int fontSize = 12;                   //字体大小 1/英寸
        //List<string> textList;       //打印内容行
        //private void simpleButton1_Click(object sender, EventArgs e)
        //{


        //    if (string.IsNullOrWhiteSpace("afdsaf\r\rfafadfaf\r\rdafasdfasfas\r\r"))
        //    {
        //        return;
        //    }

        //    //原文字行或者段落内容
        //    var sourceTexts = "afdsaf\r\rfafadfaf\r\rdafasdfasfas\r\r".Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

        //    //重新把文字进行分行树立
        //    textList = new List<string>();
        //    foreach (var item in sourceTexts)
        //    {
        //        if (!string.IsNullOrWhiteSpace(item))
        //        {
        //            if (item.Length > lineSize)
        //            {
        //                textList.AddRange(GetArr(lineSize, item));
        //            }
        //            else
        //            {
        //                textList.Add(item);
        //            }
        //        }
        //    }


        //    PrintDocument pd = new PrintDocument();
        //    pd.PrintPage += new PrintPageEventHandler(Print_Content);
        //    //纸张设置默认
        //    PaperSize pageSize = new PaperSize("自定义纸张", fontSize * lineSize, (textList.Count * lineHeight));
        //    pd.DefaultPageSettings.PaperSize = pageSize;
        //    try
        //    {
        //        pd.Print();
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("打印失败." + ex.Message);
        //    }
        //}

        ///// <summary>
        ///// 打印内容事件
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void Print_Content(object sender, PrintPageEventArgs e)
        //{
        //    var mark = 0;
        //    foreach (var item in textList)
        //    {
        //        e.Graphics.DrawString(item, new Font(new FontFamily("宋体"), fontSize), System.Drawing.Brushes.Black, 0, mark * lineSize);
        //        mark++;
        //    }
        //}

        ///// <summary>
        ///// 根据内容进行分行
        ///// </summary>
        ///// <param name="linelen">每行字数</param>
        ///// <param name="text">原文字行（段落）文字</param>
        ///// <returns></returns>
        //private List<string> GetArr(int linelen, string text)
        //{
        //    var list = new List<string>();
        //    int listcount = text.Length % linelen == 0 ? text.Length / linelen : (text.Length / linelen) + 1;
        //    for (int j = 0; j < listcount; j++)
        //    {
        //        try
        //        {
        //            list.Add(text.Substring(j * linelen, linelen));
        //        }
        //        catch (Exception)
        //        {
        //            list.Add(text.Substring(j * linelen));
        //        }
        //    }
        //    return list;
        //}

        #endregion
    }
}