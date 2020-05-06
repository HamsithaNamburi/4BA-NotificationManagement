using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NotificationManagementDBEntity.Models;
using NuitUserTest;
using NUnit.Framework;
using NUnit.Framework.Internal;
using System;
using System.Collections.Generic;
using System.Text;

namespace NuitUserTest.Tests
{
    [TestFixture]
    public class SqLiteTests
    {

        

        [Test]


        public void GetAllUsersTest()
        {

            var connection = new SqliteConnection("Data Source=DESKTOP-FA0USB5/SQLEXPRESS;Initial Catalog=NotificationDB;Persist Security Info=True;User ID=sa;Password=***********");
            connection.Open();

            var options = new DbContextOptionsBuilder<NotificationDBContext>().UseSqlite(connection).Options;

            using (var context = new NotificationDBContext(options))
            {
                context.Database.EnsureCreated();
            }
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.Fail();
        }
    }
}