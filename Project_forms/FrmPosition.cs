﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using DAL;

namespace Project_forms
{
    public partial class FrmPosition : Form
    {
        public FrmPosition()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
        private void btnSave_Click(object sender, EventArgs e)
        {
            if(txtPosition.Text.Trim() == "")
            {
                MessageBox.Show("Empty position name.");

            }else if (cmbDepartment.SelectedIndex == -1)
            {

                MessageBox.Show("Select department.");
            }
            else
            {
                POSITION position = new POSITION();
                position.PositionName = txtPosition.Text;
                position.DepartmentID = Convert.ToInt32(cmbDepartment.SelectedValue);
                BLL.PositionBLL.AddPosition(position);
                MessageBox.Show("Position added");
                txtPosition.Clear();
                cmbDepartment.SelectedIndex = -1;

            }




        }
        List<DEPARTMENT> departmentList = new List<DEPARTMENT>();
        private void FrmPosition_Load(object sender, EventArgs e)
        {
            departmentList = DepartmentBLL.GetDepartment();
            cmbDepartment.DataSource = departmentList;
            cmbDepartment.DisplayMember = "DepartmentName";
            cmbDepartment.ValueMember = "ID";
            cmbDepartment.SelectedIndex = -1;
        }
    }
}
