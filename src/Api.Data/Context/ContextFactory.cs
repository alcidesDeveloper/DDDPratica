using Api.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Context
{
    public class ContextFactory : IDesignTimeDbContextFactory<MyContext>
    {
        public MyContext CreateDbContext(string[] args)
        {
            //Incluir a conexão
            var conn = "Data Source=.\\SQLEXPRESS;Initial Catalog=Test;Integrated Security=True;MultipleActiveResultSets=true";
            var optionBuilder = new DbContextOptionsBuilder<MyContext>();
            optionBuilder.UseSqlServer(conn);

            return new MyContext(optionBuilder.Options);
        }
    }
}
