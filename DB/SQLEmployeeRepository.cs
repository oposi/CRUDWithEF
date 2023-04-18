using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace CRUDWithEF.DB
{
    class SQLEmployeeRepository 
    {
        private ModelContext db;

        public SQLEmployeeRepository()
        {
            this.db = new ModelContext();
        }

        public IEnumerable<Employee> GetEmployeeList()
        {
            return db.EmpList;
        }

        public Employee GetEmployee(int id)
        {
            return db.EmpList.Find(id);
        }

        public void Create (Employee employee)
        {
            db.EmpList.Add(employee);
        }

        public void Update (Employee employee)
        {
            db.Entry(employee).State = EntityState.Modified;
        }

        public void Delete (int id)
        {
            Employee employee = db.EmpList.Find(id);
            if (employee != null)
                db.EmpList.Remove(employee);
        }

        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;
        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}

