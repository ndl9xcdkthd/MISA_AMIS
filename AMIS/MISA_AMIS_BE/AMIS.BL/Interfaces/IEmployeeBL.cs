using Common;
using Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AMIS.BL.Interfaces
{
    public interface IEmployeeBL:IBaseBL<Employee>
    {
        public ServiceResult getAllData();
    }
}
