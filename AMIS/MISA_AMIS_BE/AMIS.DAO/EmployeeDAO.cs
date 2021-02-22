using AMIS.DAO.Interfaces;
using Common.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AMIS.DAO
{
    public class EmployeeDAO : DbConnector<Employee>, IEmployeeDAO
    {
        /// <summary>
        /// Lấy nhân viên theo id
        /// </summary>
        /// <param name="id">id nhân viên</param>
        /// <returns>nhân viên có id trùng với id truyền vào</returns>
        public Employee getById(string id)
        {
            DbConnector<Employee> db = new DbConnector<Employee>();
            var entity = db.GetById(id);
            return entity;
        }

        /// <summary>
        /// Lấy tất cả nhân viên
        /// </summary>
        /// <returns>Danh sách nhân viên</returns>
        public IEnumerable<Employee> getEmployees()
        {
            DbConnector<Employee> db = new DbConnector<Employee>();
            var employees = db.getAllData();
            return employees;
        }

        /// <summary>
        /// Thêm nhân viên
        /// </summary>
        /// <param name="e">Nhân viên cần thêm</param>
        /// <returns></returns>
        public int InsertEmployee(Employee e)
        {
            //var db = new DbConnector<Employee>();
            int result = base.InsertData(e);
            return result;
        }

        /// <summary>
        /// Cập nhật nhân viên
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        public int UpdateEmployee(Employee e)
        {
            //var db = new DbConnector<Employee>();
            int result = base.UpdateData(e);

            return result;
        }

        /// <summary>
        /// Xoá nhân viên theo mã
        /// </summary>
        /// <param name="id">mã nhân viên cân xoá</param>
        /// <returns></returns>
        public int DeleteEmployee(string id)
        {
            var result = base.DeleteData(id);
            return result;
        }

        /// <summary>
        /// Check trùng mã nhân viên khi thêm mới
        /// </summary>
        /// <param name="code">mã nhân viên</param>
        /// <returns>true nếu trùng, false nếu không trùng</returns>
        public bool CheckDupplicateCode(String code)
        {
            var x = db.Query<Employee>($"Select * From Employee Where EmployeeCode = '{code}'").FirstOrDefault();
            if (x == null)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Check trùng mã nhân viên khi cập nhật
        /// </summary>
        /// <param name="code">mã nhân viên</param>
        /// <returns>true nếu trùng, false nếu không trùng</returns>
        public bool CheckDupplicateCodeUpdate(String code,String id)
        {
            var x = db.Query<Employee>($"Select * From Employee Where EmployeeCode = '{code}' and EmployeeId!='{id}'").FirstOrDefault();
            if (x == null)
            {
                return false;
            }
            return true;
        }

        
    }
}
