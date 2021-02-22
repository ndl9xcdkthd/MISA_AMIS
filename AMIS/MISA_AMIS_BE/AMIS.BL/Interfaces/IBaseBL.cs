using Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace AMIS.BL.Interfaces
{
    public interface IBaseBL<T>
    {
        /// <summary>
        /// Lấy tất cả dữ liệu
        /// </summary>
        /// <returns>Service Result</returns>
        public ServiceResult getAllData();

        /// <summary>
        /// Lấy theo id
        /// </summary>
        /// <returns></returns>
        public ServiceResult getById(String id);

        /// <summary>
        /// Thêm mới bản ghi
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public ServiceResult InsertData(T entity);

        /// <summary>
        /// Cập nhật bản ghi
        /// </summary>
        /// <param name="entity">đối tượng cần cập nhật</param>
        /// <returns></returns>
        public ServiceResult UpdateData(T entity);

        /// <summary>
        /// Xoá bản ghi
        /// </summary>
        /// <param name="id">mã của đối tượng</param>
        /// <returns></returns>
        public ServiceResult DeleteData(String id);
    }
}
