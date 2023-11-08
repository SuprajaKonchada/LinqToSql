using System;
using System.Linq;
using System.Data.Linq;

namespace LinqToSql
{
    class Program
    {
        static void Main(string[] args)
        {

            string connectString = "Data Source=COGNINE-L31\\SQLEXPRESS ; database = CompanyDB ; Integrated Security=true";

            LinqToSqldbmlDataContext db = new LinqToSqldbmlDataContext(connectString);

            //Create new Employee

            Employee newEmployee = new Employee();
            
            newEmployee.Ename = "Supraja";
            newEmployee.Job = "ASE";
            newEmployee.Salary = 850000;
            newEmployee.Dname = "Delivery";

            //Add new Employee to database
            db.Employees.InsertOnSubmit(newEmployee);

            //Save changes to Database.
            db.SubmitChanges();

            //Get new Inserted Employee            
            Employee insertedEmployee = db.Employees.FirstOrDefault(e => e.Ename.Equals("Supraja"));

            Console.WriteLine("Employee ID = {0},  Name = {1}, Email = {2}, ContactNo = {3}, Address = {4}", insertedEmployee.Eno,
                              insertedEmployee.Ename, insertedEmployee.Job,
                             insertedEmployee.Salary, insertedEmployee.Dname);
            Console.ReadKey();
        }
    }
}