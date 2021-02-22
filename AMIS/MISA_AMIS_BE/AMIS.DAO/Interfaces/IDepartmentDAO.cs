using Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AMIS.DAO.Interfaces
{
    public interface IDepartmentDAO:IDbConnector<Department>
    {

        public IEnumerable<Department> GetDepartments();

        public Department GetDepartmentById(String id);

        public String GetDepartmentNameById(String id);

    }
}
