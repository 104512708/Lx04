using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;
using System.Data;
using Dapper;
using Microsoft.Extensions.Configuration;

namespace DAL
{
    public class Activity
    {
        private Activity() { }
        private static Activity _instance = new Activity();
        public static Activity Instance
        {
            get
            {
                return _instance;
            }
        } //复制UserInfo类对应代码，将其中的UserInfo全改为Activity

        string cns = AppConfigurtaionServices.Configuration.GetConnectionString("cns");
        public Model.Activity GetModel(int id)
        {
            using (IDbConnection cn = new MySqlConnection(cns))
            {
                string sql = "select * from Activity where ActivityID=@id";
                return cn.QueryFirstOrDefault<Model.Activity>(sql, new { id = id });
            }//复制UserInfo类对应代码，UserInfo全改为Activity（包括SQL语句内的），SQL语句中的where子句改为where ActivityID=@id
            //return语句参数改为new { id = id }
        }
        public IEnumerable<Model.Activity> GetAll()
        {
            using (IDbConnection cn = new MySqlConnection(cns))
            {
                string sql = "select * from Activity";
                return cn.Query<Model.Activity>(sql);
            }//复制UserInfo类对应代码，UserInfo全改为Activity（包括SQL语句内的）
        }
        public int Add(Model.Activity active)
        {
            using (IDbConnection cn = new MySqlConnection(cns))
            {
                string sql = "insert into Activity(ActivityName,EndTime,ActivityPicture,ActivityIntroduction,Summary,ActivityVerify,ActivityStatus,UserName) values(@ActivityName,@EndTime,@ActivityPicture,@ActivityIntroduction,@Summary,@ActivityVerify,@ActivityStatus,@UserName);"; //sql语句可复制题目给出的SQL
                sql += "SELECT @@IDENTITY";
                return cn.ExecuteScalar<int>(sql, active);
            }
        }
        public int Update(Model.Activity active)
        {
            using (IDbConnection cn = new MySqlConnection(cns))
            {
                string sql = "update Activity set ActivityName=@ActivityName,EndTime=@EndTime,ActivityPicture=@ActivityPicture,ActivityIntroduction=@ActivityIntroduction,Summary=@Summary,ActivityVerify=@ActivityVerify,ActivityStatus=@ActivityStatus where ActivityID=@ActivityID";
                return cn.Execute(sql, active);
            }//复制UserInfo类对应代码，UserInfo全改为Activity,user全改为active
            //sql语句可复制题目给出的SQL
        }
        public int Delete(int id)
        {
            using (IDbConnection cn = new MySqlConnection(cns))
            {
                string sql = "delete from Activity where ActivityID=@id";
                return cn.Execute(sql, new { id = id });
            }//复制UserInfo类对应代码，UserInfo全改为Activity（包括SQL语句内的），SQL语句中的where子句改为where ActivityID=@id
            //return语句参数改为new { id = id }
        }
    }
}
