using Db4objects.Db4o;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Db4objects.Db4o.Linq;

namespace DB4OLab
{
    public partial class frmMain : Form
    {
        IObjectContainer Database = null;
        public frmMain()
        {
            InitializeComponent();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            Student sv = new Student
            {
                StudentId = txtMaSV.Text,
                FullName = txtHoTen.Text,
                Mark = double.Parse(txtDiem.Text),
                RegisterYear = int.Parse(txtNamNhapHoc.Text),
                BirthDate = dtpNgaySinh.Value
            };

            DBHelper.InsertObject<Student>(sv);
        }


        private void frmMain_Load(object sender, EventArgs e)
        {
            //DBHelper.OpenDatabase();
            //Database = DBHelper.Database;
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            //DBHelper.CloseDatabase();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Tìm SV có tên chứa chữ A - txtHoTen và nhập học năm 2016
            DBHelper.OpenDatabase();
            IList<Student> students = DBHelper.Database.Query(delegate (Student sv)
            {
                if (sv.FullName.ToLower().Contains(txtHoTen.Text.ToLower()) && sv.RegisterYear == 2016)
                    return true;

                return false;
            }).ToList();
            DBHelper.CloseDatabase();
            dataGridView1.DataSource = students;
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            DBHelper.OpenDatabase();
            var data = (from Student sv in DBHelper.Database
                       where (
sv.FullName.ToLower().Contains(txtHoTen.Text.ToLower()) && sv.RegisterYear == 2016)
                       select sv).ToList();
            dataGridView1.DataSource = data;
            DBHelper.CloseDatabase();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            DBHelper.OpenDatabase();
            IList<Student> students = DBHelper.Database.Query(delegate (Student sv)
            {
                return true;
            }).ToList();
            DBHelper.CloseDatabase();
            dataGridView1.DataSource = students;
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            DBHelper.OpenDatabase();
            IList<Student> students = DBHelper.Database.Query(delegate (Student sv){
                if (sv.RegisterYear == 2013)
                {
                    return true;
                }
                return false;
            }).ToList();
            DBHelper.CloseDatabase();
            dataGridView1.DataSource = students;
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            DBHelper.OpenDatabase();
            IList<Student> students = DBHelper.Database.Query(delegate (Student sv) {
                if (sv.FullName.Contains("A"))
                {
                    return true;
                }
                return false;
            }).ToList();
            DBHelper.CloseDatabase();
            dataGridView1.DataSource = students;
        }

        private void Button6_Click(object sender, EventArgs e)
        {

            DBHelper.OpenDatabase();
            IList<Student> students = DBHelper.Database.Query(delegate (Student sv) {
                if (sv.Age < 20)
                {
                    return true;
                }
                return false;
            });
            DBHelper.CloseDatabase();
            dataGridView1.DataSource = students;
        }

        private void Button7_Click(object sender, EventArgs e)
        {

            DBHelper.OpenDatabase();
            IList<Student> students = DBHelper.Database.Query(delegate (Student sv) {
                if (sv.FullName.ToLower().Contains("a"))
                {
                    return true;
                }
                return false;
            }).ToList();
            DBHelper.CloseDatabase();
            dataGridView1.DataSource = students;
        }
    }
}
