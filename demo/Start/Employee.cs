using System;
using System.Collections.Generic;

namespace Demo.Start
{
    public class Employee : Person
    {
        public Employee(int id, string name) : base(id, name) { }

        public DateTime HireDate { get; set; }

        public TimeSpan TimeWithCompany => DateTime.Now - HireDate;

        public int? ManagerId { get; set; }
        public Manager Manager { get; set; }
    }

    public class Manager : Employee
    {
        public Manager(int id, string name) : base(id, name) { }

        public List<Employee> DirectReports { get; set; }
    }

    public class SoftwareEngineer : Employee
    {
        public SoftwareEngineer(int id, string name) : base(id, name) { }

        public TechnicalSkill Skill { get; set; }
    }

    public class BusinessAnalyst : Employee
    {
        public BusinessAnalyst(int id, string name) : base(id, name) { }

        public BusinessArea Area { get; set; }
    }

    public enum BusinessArea
    {
        SalesSystem,
        OrderFulfillment,
        Security,
        ThermonuclearWarfare
    }

    public enum TechnicalSkill
    {
        CSharp,
        JavaScript,
        VisualBasic,
        Whitespace
    }
}