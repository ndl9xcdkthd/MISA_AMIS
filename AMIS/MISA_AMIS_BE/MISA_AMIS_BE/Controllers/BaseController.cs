using AMIS.BL.Interfaces;
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
    public class BaseController<T> : ControllerBase
    {
        IBaseBL<T> _baseBL;

        public BaseController(IBaseBL<T> baseBL)
        {
            _baseBL = baseBL;
        }

        // GET: api/<BaseController>
        [HttpGet]
        public IActionResult Get()
        {
            var result = _baseBL.getAllData();
            var entities = result.Data as List<T>;
            if (result.Success)
            {
                if (entities.Count == 0)
                    return StatusCode(204, entities);
                else
                    return StatusCode(200, entities);
            }
            else
            {
                return StatusCode(404, entities);
            }
        }

        // GET api/<BaseController>/5
        [HttpGet("{id}")]
        public IActionResult Get(String id)
        {
            var result = _baseBL.getById(id);
            if (result.Success)
            {
                if (result.Data ==null)
                    return StatusCode(204, result.Data);
                else
                    return StatusCode(200, result.Data);
            }
            else
            {
                return StatusCode(404, result.Data);
            }
        }

        // POST api/<BaseController>
        [HttpPost]
        public IActionResult Post([FromBody] T entity)
        {
            var result = _baseBL.InsertData(entity);
            if (result.Success == false)
            {
                return StatusCode(400, result.Data);
            }
            return StatusCode(200, result.Data);

        }

        // PUT api/<BaseController>/5
        [HttpPut]
        public IActionResult Put([FromBody] T entity)
        {
            var result = _baseBL.UpdateData(entity);
            if (result.Success == false)
            {
                return StatusCode(400, result.Data);
            }
            else
            {
                if (result.Success == true && (int)result.Data > 0)
                    return StatusCode(201, result.Data);
            }
            return StatusCode(200, result.Data);
        }

        /// <summary>
        /// Xoá bản ghi
        /// </summary>
        /// <param name="id">id của đối tượng cần xoá</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(String id)
        {
            var result = _baseBL.DeleteData(id);
            if (!result.Success)
            {
                return StatusCode(400, result.Data);
            }
            return StatusCode(200, result.Data);
        }
    }
}
