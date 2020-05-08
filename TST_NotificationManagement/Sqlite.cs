using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using NotificationManagementDBEntity.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace NotificationManagementTestCases
{
   public  class Sqlite
    {
        public NotificationDBContext CreateSqliteConnection()
        {
            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();
            var option = new DbContextOptionsBuilder<NotificationDBContext>().UseSqlite(connection).Options;
            var context = new NotificationDBContext(option);
            if (context != null)
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
            }
            return context;
        }

    }
}
