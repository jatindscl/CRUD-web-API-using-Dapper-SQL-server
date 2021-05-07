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
      public class Subject
      {
            [Key]
            public string Name { get; set; }
            public int Code { get; set; }
            public int Marks { get; set; }
            public string Grade { get; set; }
            
      }
}
