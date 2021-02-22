using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace AMIS.DAO.Interfaces
{
    public interface IDbConnector<T>
    {
        /// <summary>
        /// Lấy tất cả dữ liệu
        /// </summary>
        /// <param name="sqlCommand">Câu truy vấn hoặc store</param>
        /// <param name="parameters">Đối tượng cần lọc</param>
        /// <param name="commandType">kiểu query hoặc store</param>
        /// <returns>Danh sách dữ liệu</returns>
        IEnumerable<T> getAllData(string sqlCommand = null, object parameters = null, CommandType commandType = CommandType.Text);

        /// <summary>
        /// Lấy 1 bản ghi theo id
        /// </summary>
        /// <param name="id">id của đối tượng</param>
        /// <returns>1 bản ghi </returns>
        public T GetById(String id, string sqlCommand = null, object parameters = null, CommandType commandType = CommandType.Text);

        /// <summary>
        /// Thêm mới bản ghi
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public int InsertData(T entity);

        /// <summary>
        /// Cập nhật bản ghi
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public int UpdateData(T entity);

        /// <summary>
        /// Xoá bản ghi
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public int DeleteData(String id);

    }
}
