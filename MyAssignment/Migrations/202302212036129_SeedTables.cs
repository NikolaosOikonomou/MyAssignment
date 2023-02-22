namespace MyAssignment.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedTables : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Employees (FirstName, LastName, Age, Salary, Country, ManagerId) VALUES ('Nikos', 'Oikonomou', 33, 24000, 1, 1)");
            Sql("INSERT INTO Employees (FirstName, LastName, Age, Salary, Country, ManagerId) VALUES ('Kwstas', 'Oikonomou', 30, 25000, 1, 1)");
            Sql("INSERT INTO Employees (FirstName, LastName, Age, Salary, Country, ManagerId) VALUES ('Petros', 'Oikonomou', 35, 27000, 2, 1)");
            Sql("INSERT INTO Employees (FirstName, LastName, Age, Salary, Country, ManagerId) VALUES ('Giannis', 'Rabo', 36, 25000, 2, 1)");
            Sql("INSERT INTO Employees (FirstName, LastName, Age, Salary, Country, ManagerId) VALUES ('Hector', 'Balboa', 31, 35000, 3, 1)");
            Sql("INSERT INTO Employees (FirstName, LastName, Age, Salary, Country, ManagerId) VALUES ('John', 'Smith', 33, 24000, 3, 2)");
            Sql("INSERT INTO Employees (FirstName, LastName, Age, Salary, Country, ManagerId) VALUES ('Antwnis', 'Liagos', 30, 25000, 4, 2)");
            Sql("INSERT INTO Employees (FirstName, LastName, Age, Salary, Country, ManagerId) VALUES ('Spuros', 'Spurou', 35, 27000, 4, 2)");
            Sql("INSERT INTO Employees (FirstName, LastName, Age, Salary, Country, ManagerId) VALUES ('Elenh', 'Sou', 36, 25000, 0, 2)");
            Sql("INSERT INTO Employees (FirstName, LastName, Age, Salary, Country, ManagerId) VALUES ('Vasilis', 'Mpou', 31, 35000, 0, 2)");

            Sql("INSERT INTO Managers (FirstName, LastName, Age, Salary, Country) VALUES ('Hector', 'Gatsos', 31, 35000, 5)");
            Sql("INSERT INTO Managers (FirstName, LastName, Age, Salary, Country) VALUES ('Manos', 'Thodos', 31, 35000, 5)");
        }
        
        public override void Down()
        {
        }
    }
}
