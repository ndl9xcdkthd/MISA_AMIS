using AMIS.DAO.Interfaces;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Dapper;
using System.Linq;

namespace AMIS.DAO
{
    public class DbConnector<T>:IDbConnector<T>
    {
        public string connectionString = "User Id=dev;password = 12345678;" +
                                "Host=47.241.69.179;port = 3306;" +
                                "Database = MF720_NDLuu_AMIS;" +
                                "Character Set=utf8";
        protected IDbConnection db;
        public DbConnector()
        {
            db = new MySqlConnection(connectionString);
        }

        /// <summary>
        /// Xoá bản ghi
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public virtual int DeleteData(String id)
        {
            var tableName = typeof(T).Name;
            var store = $"Proc_Delete{tableName}";
            DynamicParameters dynamic = new DynamicParameters();
            dynamic.Add($"@{tableName}Id",id);
            var result = db.Execute(store, dynamic, commandType: CommandType.StoredProcedure);
            return result;
        }

        /// <summary>
        /// Lấy danh sách đối tượng
        /// </summary>
        /// <param name="sqlCommand"></param>
        /// <param name="parameters"></param>
        /// <param name="commandType"></param>
        /// <returns>Danh sách đối tượng</returns>
        public IEnumerable<T> getAllData(string sqlCommand = null, object parameters = null, CommandType commandType = CommandType.Text)
        {
            var tableName = typeof(T).Name;
            if(sqlCommand == null)
            {
                sqlCommand = $"SELECT * FROM {tableName} Order by CreatedDate DESC";
            }
            var entity = db.Query<T>(sqlCommand,parameters,commandType:commandType).ToList();
            return entity;
        }

        /// <summary>
        /// Lấy dữ liệu theo id
        /// </summary>
        /// <param name="id">id của đối tượng</param>
        /// <param name="sqlCommand"></param>
        /// <param name="parameters"></param>
        /// <param name="commandType"></param>
        /// <returns>1 bản ghi có id = id</returns>
        public virtual T GetById(String id, string sqlCommand = null, object parameters = null, CommandType commandType = CommandType.Text)
        {
            var tableName = typeof(T).Name;
            if (sqlCommand == null)
            {
                sqlCommand = $"Select * From {tableName} where {tableName}Id = '{id}'";
            }
            var entity = db.Query<T>(sqlCommand,parameters,commandType:commandType).FirstOrDefault();
            return entity;
        }

        /// <summary>
        /// Thêm mới bản ghi
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        /// CreatyBy NDLuu(21/2/2021)
        public virtual int InsertData(T entity)
        {
            var tableName = typeof(T).Name;
            var store = $"Proc_Insert{tableName}";
            var result = db.Execute(store, entity, commandType: CommandType.StoredProcedure);
            return result;
        }

        /// <summary>
        /// Cập nhật bản ghi
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        /// CreatedBy NDLuu(21/2/2021)
        public virtual int UpdateData(T entity)
        {
            var tableName = typeof(T).Name;
            var store = $"Proc_Update{tableName}";
            var result = db.Execute(store, entity, commandType: CommandType.StoredProcedure);
            return result;
        }
    }
}
