using AMIS.BL.Interfaces;
using AMIS.DAO.Interfaces;
using Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace AMIS.BL
{
    public class BaseBL<T> : IBaseBL<T>
    {
        IDbConnector<T> _db;
        protected ServiceResult _service;

        #region Constructor
        public BaseBL(IDbConnector<T> dbConnector){
            _service = new ServiceResult();
            _db = dbConnector;
        }
        #endregion

        


        /// <summary>
        /// Lấy tất cả các bản ghi
        /// </summary>
        /// <returns></returns>
        public virtual ServiceResult getAllData()
        {
            _service.Success = true;
            _service.Data = _db.getAllData();
            return _service;
        }

        /// <summary>
        /// Lấy bản ghi theo id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual ServiceResult getById(string id)
        {
            _service.Success = true;
            _service.Data = _db.GetById(id);
            return _service;
        }


        /// <summary>
        /// Thêm mới dữ liệu
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public virtual ServiceResult InsertData(T entity)
        {
            var errMsg = new ErrorMsg();
            var isValidated = ValidateInsertData(entity, errMsg);
            if (isValidated)
            {
                _service.Success = true;
                _service.Data = _db.InsertData(entity);
            }
            else
            {
                _service.Success = false;
                _service.Data = errMsg;
            }


            return _service;
        }

        /// <summary>
        /// Cập nhật dữ liệu
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public virtual ServiceResult UpdateData(T entity)
        {
            var errMsg = new ErrorMsg();
            var isValid = ValidateUpdateData(entity,errMsg);
            if (isValid)
            {
                _service.Success = true;
                _service.Data = _db.UpdateData(entity);
            }
            else
            {
                _service.Success = false;
                _service.Data = errMsg;
            }
            return _service;
        }

        /// <summary>
        /// Xoá bản ghi
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual ServiceResult DeleteData(String id)
        {
            _service.Data = _db.DeleteData(id);
            if ((int)_service.Data > 0)
            {
                _service.Success = true;
            }
            else
            {
                _service.Success = false;
            }
            return _service;

        }

        protected virtual bool ValidateInsertData(T entity, ErrorMsg error)
        {
            return true;
        }

        protected virtual bool ValidateUpdateData(T entity, ErrorMsg error)
        {
            return true;
        }

        
    }
}
