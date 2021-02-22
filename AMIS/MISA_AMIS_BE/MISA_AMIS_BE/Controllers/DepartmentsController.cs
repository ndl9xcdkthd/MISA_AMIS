using AMIS.BL.Interfaces;
using Common.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA_AMIS_BE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : BaseController<Department>
    {

        public DepartmentsController(IDepartmentBL _departmentBL) : base(_departmentBL)
        {

        }
    }
}
