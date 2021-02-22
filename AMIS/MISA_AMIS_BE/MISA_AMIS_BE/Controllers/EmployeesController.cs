using AMIS.BL.Interfaces;
using Common.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MISA_AMIS_BE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : BaseController<Employee>
    {
        IEmployeeBL employeeBL;
        public EmployeesController(IEmployeeBL _employeeBL) :base(_employeeBL)
        {
            employeeBL = _employeeBL;
        }

    }
}
