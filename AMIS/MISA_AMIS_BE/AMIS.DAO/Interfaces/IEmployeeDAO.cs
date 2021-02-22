using Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AMIS.DAO.Interfaces
{
    public interface IEmployeeDAO:IDbConnector<Employee>
    {
        /// <summary>
        /// Lấy danh sách nhân viên
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Employee> getEmployees();

        /// <summary>
        /// Lấy nhân viên theo id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Employee getById(String id);

        /// <summary>
        /// Thêm mới nhân viên
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        public int InsertEmployee(Employee e);

        /// <summary>
        /// Cập nhật nhân viên
        /// </summary>
        /// <param name="e">Nhân viên cần cập nhật</param>
        /// <returns></returns>
        public int UpdateEmployee(Employee e);

        /// <summary>
        /// Xoá bản ghi theo mã
        /// </summary>
        /// <param name="id">mã của bản ghi cần xoá</param>
        /// <returns></returns>
        public int DeleteEmployee(String id);
    }
}
