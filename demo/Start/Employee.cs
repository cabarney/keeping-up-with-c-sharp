using System;
using System.Collections.Generic;

namespace Demo.Start
{
    public class Employee : Person
    {
        public Employee(int id, string name, string hireDate) : base(id, name) 
        {
            DateTime parsedDate;
            if(DateTime.TryParse(hireDate, out parsedDate))
            {
                HireDate = parsedDate;
            }
        }

        public DateTime HireDate { get; set; }
        public TimeSpan TimeWithCompany => DateTime.Now - HireDate;
        public int? ManagerId { get; set; }
        public Manager Manager { get; set; }

        public override string ToString()
        {
            return string.Format("{0} ( Hired {1:MM/dd/yyyy}, Manager: {2})", FullName, HireDate, Manager.FullName);
        }
    }

    public class Manager : Employee
    {
        public Manager(int id, string name, string hireDate) : base(id, name, hireDate) { }
        public List<Employee> DirectReports { get; set; }
    }

    public class SoftwareEngineer : Employee
    {
        public SoftwareEngineer(int id, string name, string hireDate) : base(id, name, hireDate) { }
        public TechnicalSkill Skill { get; set; }
    }

    public class BusinessAnalyst : Employee
    {
        public BusinessAnalyst(int id, string name, string hireDate) : base(id, name, hireDate) { }
        public BusinessArea Area { get; set; }
    }
}