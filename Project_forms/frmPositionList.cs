using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL.DTO;
using BLL;

namespace Project_forms
{
    public partial class frmPositionList : Form
    {
        public frmPositionList()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        List<PositionDTO> positioList = new List<PositionDTO>();
        private void btnNew_Click(object sender, EventArgs e)
        {
            FrmPosition frm = new FrmPosition();
            this.Hide();
            frm.ShowDialog();
            this.Visible = true;
            FillGrid();

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            FrmPosition frm = new FrmPosition();
            this.Hide();
            frm.ShowDialog();
            this.Visible = true;
            FillGrid();

        }
        void FillGrid()
        {
           
            positioList = PositionBLL.GetPosition();
            dataGridView1.DataSource = positioList;

        }
        
        private void frmPositionList_Load(object sender, EventArgs e)
        {
            FillGrid();
            dataGridView1.Columns[0].HeaderText = "Department name";
            dataGridView1.Columns[1].Visible = false;
            dataGridView1.Columns[2].HeaderText = "Position name";
            dataGridView1.Columns[3].Visible = false;
            


        }
    }
}
