using AMIS.BL.Interfaces;
using AMIS.DAO;
using AMIS.DAO.Interfaces;
using Common;
using Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AMIS.BL
{
    public class EmployeeBL : BaseBL<Employee>, IEmployeeBL
    {

        IEmployeeDAO _employeeDAO;
        public EmployeeBL(IEmployeeDAO employeeDAO) : base(employeeDAO)
        {
            _employeeDAO = employeeDAO;
        }

        public override ServiceResult getAllData()
        {
            _service.Success = true;
            _service.Data = _employeeDAO.getAllData();
            return _service;
        }


        /// <summary>
        /// Xoá dữ liệu
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public override ServiceResult DeleteData(String id)
        {
            var result = _employeeDAO.DeleteEmployee(id);
            if (result > 0)
            {
                _service.Success = true;
            }
            else
            {
                _service.Success = false;
            }
            return _service;
        }

        /// <summary>
        /// Check các thông tin nhập vào khi thêm mới
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="error"></param>
        /// <returns>true nếu các thông tin nhập vào đúng, false nếu sai</returns>
        protected override bool ValidateInsertData(Employee entity, ErrorMsg error)
        {
            var employeeDAO = new EmployeeDAO();
            var isValid = true;
            //Check mã trống
            if(String.IsNullOrEmpty(entity.EmployeeCode))
            {
                error.UserMsg = Common.Properties.Resources.EmployeeCodeException;
                isValid = false;
                return isValid;
            }
            //Check trống họ và tên
            if (String.IsNullOrEmpty(entity.FullName))
            {
                error.UserMsg = Common.Properties.Resources.FullNameException;
                isValid = false;
                return isValid;
            }
            //Check trống Phòng ban
            if (String.IsNullOrEmpty(entity.DepartmentId.ToString()))
            {
                error.UserMsg = Common.Properties.Resources.DepartmentIdException;
                isValid = false;
                return isValid;
            }

            //Check trùng mã
            if (employeeDAO.CheckDupplicateCode(entity.EmployeeCode))
            {
                error.UserMsg = Common.Properties.Resources.EmployeeCodeException;
                isValid = false;
                return isValid;
            }


            return isValid;
        }

        /// <summary>
        /// Kiểm tra thông tin nhập vào khi update
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="error"></param>
        /// <returns>True nếu thông tin nhập vào là đúng, false nếu sai</returns>
        protected override bool ValidateUpdateData(Employee entity, ErrorMsg error)
        {
            var employeeDAO = new EmployeeDAO();
            var isValid = true;
            //Check mã trống
            if (String.IsNullOrEmpty(entity.EmployeeCode))
            {
                error.UserMsg = Common.Properties.Resources.EmployeeCodeException;
                isValid = false;
                return isValid;
            }
            //Check trống họ và tên
            if (String.IsNullOrEmpty(entity.FullName))
            {
                error.UserMsg = Common.Properties.Resources.FullNameException;
                isValid = false;
                return isValid;
            }
            //Check trống Phòng ban
            if (String.IsNullOrEmpty(entity.DepartmentId.ToString()))
            {
                error.UserMsg = Common.Properties.Resources.DepartmentIdException;
                isValid = false;
                return isValid;
            }

            //Check trùng mã
            if (employeeDAO.CheckDupplicateCodeUpdate(entity.EmployeeCode,entity.EmployeeId.ToString()))
            {
                error.UserMsg = Common.Properties.Resources.EmployeeCodeException;
                isValid = false;
                return isValid;
            }


            return isValid;
        }
    }
}
