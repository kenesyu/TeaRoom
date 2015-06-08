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


namespace TeaRoom
{
    public partial class aaaaa : RibbonForm
    {
        public aaaaa()
        {
            InitializeComponent();
            //InitSkinGallery();

        }
        //void InitSkinGallery()
        //{
        //    SkinHelper.InitSkinGallery(rgbiSkins, true);
        //}

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            System.Environment.Exit(0); 
        }

    }
}