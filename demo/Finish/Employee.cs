using System;
using System.Collections.Generic;

namespace Demo.Finish
{
    #nullable enable
    public class Employee : Person
    {
        public Employee(int id, string name, string hireDate) : base(id, name) => 
            HireDate = DateTime.TryParse(hireDate, out var parsedDate) ? parsedDate : default;

        public DateTime HireDate { get; set; }
        public TimeSpan TimeWithCompany => DateTime.Now - HireDate;
        public int? ManagerId { get; set; }
        public Manager? Manager { get; set; }
        
        public override string ToString() => $"{FullName} ( Hired {HireDate:MM/dd/yyyy}, Manager: {Manager?.FullName ?? "None"} )";
    }

    public class Manager : Employee
    {
        public Manager(int id, string name, string hireDate) : base(id, name, hireDate) { }        
        public List<Employee> DirectReports { get; set; } = new List<Employee>();
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
    #nullable restore
}