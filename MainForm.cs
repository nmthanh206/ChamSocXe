﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChamSocXe
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }
        Form children;

        private void quảnLýThợToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QuanLyTho qltf = new QuanLyTho();
            openForm(qltf);
    
        }
        void openForm(Form form)
        {
           
            children = form;
            form.FormBorderStyle = FormBorderStyle.None;
            form.TopLevel = false;
            form.AutoScroll = true;
            this.pnContainer.Controls.Add(form);

            form.Show();

        }
        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //bool a=children.Visible;
            //this.panel1.Controls.Remove(children);
            //FormCollection fc = Application.OpenForms;
            //foreach (Form frm in fc)
            //{
            //    //iterate through
            //    if (frm.Visible && frm.Name != "MainForm")
            //    {
            //        this.panel1.Controls.Remove(frm);
            //        //   frm.Close();
            //    }
            //}
      
         //   pnContainer.Controls.Clear();
            foreach (Control c in pnContainer.Controls)
                c.Dispose();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }
    }
}