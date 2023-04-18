using System;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;

namespace CRUDWithEF
{
    public partial class Form1 : MetroFramework.Forms.MetroForm
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            using (ModelContext db = new ModelContext())
            {
                employeeBindingSource2.DataSource = db.EmpList.ToList();
            }
            metroPanel.Enabled = false;
            Employee obj = employeeBindingSource2.Current as Employee;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            metroPanel.Enabled = true;
            employeeBindingSource2.Add(new Employee());
            employeeBindingSource2.MoveLast();
            txtName.Focus();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            metroPanel.Enabled = true;
            txtName.Focus();
            Employee obj = employeeBindingSource2.Current as Employee;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            metroPanel.Enabled = false;
            employeeBindingSource2.ResetBindings(false);
            Form1_Load(sender, e);
        }

        private void metroGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Employee obj = employeeBindingSource2.Current as Employee;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if(MetroFramework.MetroMessageBox.Show(this,"Are you sure about that?", "Message",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
            {
                using (ModelContext db = new ModelContext())
                {
                    Employee obj = employeeBindingSource2.Current as Employee;
                    if(obj != null)
                    {
                        if (db.Entry<Employee>(obj).State == EntityState.Detached)
                            db.Set<Employee>().Attach(obj);
                        db.Entry<Employee>(obj).State = EntityState.Deleted;
                        db.SaveChanges();
                        MetroFramework.MetroMessageBox.Show(this, "Deleted Successfuly");
                        employeeBindingSource2.RemoveCurrent();
                        metroPanel.Enabled = false;
                    }
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            using(ModelContext db = new ModelContext())
            {
                Employee obj = employeeBindingSource2.Current as Employee;
                if (obj != null)
                {
                    if (db.Entry<Employee>(obj).State == EntityState.Detached)
                        db.Set<Employee>().Attach(obj);
                    if (obj.EmpId == 0)
                        db.Entry<Employee>(obj).State = EntityState.Added;
                    else
                        db.Entry<Employee>(obj).State = EntityState.Modified;
                    db.SaveChanges();
                    MetroFramework.MetroMessageBox.Show(this, "Saved Successfully");
                    metroGrid.Refresh();
                    metroPanel.Enabled = false;
                }
            }
        }
    }
}
