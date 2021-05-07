using System;
using System.Data;
using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
namespace mini_proj_final.Model
{
      public class SubjectRepository
      {
            private string connectionString;
            public SubjectRepository()
            {
                  connectionString=@"Data Source=MW-LT-026\JATIN;Initial Catalog=DapperDB;Integrated Security=True;";
            }
            public IDbConnection Connection
            {
                  get
                  {
                        return new SqlConnection(connectionString);
                        
                  }
            }

            public void Add(Subject sub)
            {
                  using(IDbConnection dbConnection=Connection)
                  {
                        string sQuery=@"Insert into subject(Name,Marks,Grade) values (@Name,@Marks,@Grade)";
                        dbConnection.Open();
                        dbConnection.Execute(sQuery,sub);
                  }
            }
            public IEnumerable<Subject>GetAll()
            {
                  using(IDbConnection dbConnection=Connection)
                  {
                        string sQuery=@"Select * from subject";
                        dbConnection.Open();
                        return dbConnection.Query<Subject>(sQuery);
                  }
            }
            public Subject GetById(int id)
            {
                  using(IDbConnection dbConnection=Connection)
                  {
                        string sQuery=@"Select * from subject where Code=@Code";
                        dbConnection.Open();
                        return dbConnection.Query<Subject>(sQuery,new {Code=id}).FirstOrDefault();
                  }
            }
            public void Delete(int id)
            {
                  using(IDbConnection dbConnection=Connection)
                  {
                        string sQuery=@"Delete from subject where Code=@Code";
                        dbConnection.Open();
                        dbConnection.Execute(sQuery, new {Code = id});
                  }
            }
            public void Update(Subject sub)
            {
                  using(IDbConnection dbConnection=Connection)
                  {
                        string sQuery=@"Update subject set Name=@Name, Marks=@Marks, Grade=@Grade where Code=@Code";
                        dbConnection.Open();
                        dbConnection.Query(sQuery, sub);
                  }
            }


      
      }
}
