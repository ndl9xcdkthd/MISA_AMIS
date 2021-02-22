using AMIS.BL.Interfaces;
using AMIS.DAO.Interfaces;
using Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AMIS.BL
{
    public class DepartmentBL:BaseBL<Department>,IDepartmentBL
    {
        public DepartmentBL(IDbConnector<Department> _department) : base(_department)
        {

        }

    }
}
