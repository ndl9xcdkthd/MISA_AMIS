using AMIS.DAO.Interfaces;
using Common.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AMIS.DAO
{
    public class DepartmentDAO : DbConnector<Department>, IDepartmentDAO
    {

        public Department GetDepartmentById(string id)
        {
            var entity = base.GetById(id);
            return entity;
        }

        public string GetDepartmentNameById(string id)
        {
            var result = db.Query<Department>($"Select DepartmentName from Department Where DepartmentId = '{id}'").FirstOrDefault();
            return result.ToString();
        }

        public IEnumerable<Department> GetDepartments()
        {
            DbConnector<Department> db = new DbConnector<Department>();
            var department = db.getAllData();
            return department;
        }
    }
}
