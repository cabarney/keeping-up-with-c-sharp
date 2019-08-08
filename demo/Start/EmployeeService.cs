using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.Start
{
    public interface IEmployeeService
    {
        Task<Employee> GetEmployee(int id);
        Task<IEnumerable<Employee>> GetDirectReports(int managerId);
    }

    public class EmployeeService : IEmployeeService
    {
        public async Task<Employee> GetEmployee(int id)
        {
            var employee = _employees.SingleOrDefault(x => x.Id == id);
            await Task.Delay(100); // simulate db delay
            // if(employee.GetType() == typeof(Manager))
            // {
            //     var manager = employee as Manager;
            //     manager.DirectReports = (await GetDirectReports(manager.Id)).ToList();
            // }
            return employee;
        }

        public async Task<IEnumerable<Employee>> GetDirectReports(int managerId)
        {
            var ids = _employees.Where(x=>x.ManagerId == managerId).Select(x=>x.Id);
            await Task.Delay(100);
            var directReports = new List<Employee>();
            foreach(var id in ids)
            {
                directReports.Add(await GetEmployee(id));
            }
            return directReports;
        }

        private List<Employee> _employees = new List<Employee>
        {
            new SoftwareEngineer(1, "Alan Turing") { HireDate = DateTime.Parse("2/15/2004"), ManagerId = 8, Skill = TechnicalSkill.Whitespace},
            new SoftwareEngineer(2, "Linus Torvalds") { HireDate = DateTime.Parse("12/10/2005"), ManagerId = 8, Skill = TechnicalSkill.JavaScript },
            new SoftwareEngineer(3, "Scott Guthrie") { HireDate = DateTime.Parse("9/19/2008"), ManagerId = 6, Skill = TechnicalSkill.CSharp },
            new SoftwareEngineer(4, "Bjarne Soustrup") { HireDate = DateTime.Parse("6/30/2009"), ManagerId = 8, Skill = TechnicalSkill.CSharp },
            new SoftwareEngineer(5, "Anders Hejlsberg") { HireDate = DateTime.Parse("8/19/2010"), ManagerId = 6, Skill = TechnicalSkill.CSharp },
            new Manager(6, "Bill Gates") { HireDate = DateTime.Parse("3/2/2011") },
            new SoftwareEngineer(7, "Ada Lovelace") { HireDate = DateTime.Parse("1/10/2012"), ManagerId = 6, Skill = TechnicalSkill.VisualBasic },
            new Manager(8, "Steve Jobs") { HireDate = DateTime.Parse("6/21/2014") },
            new BusinessAnalyst(9, "Alan Bradley") { HireDate = DateTime.Parse("9/22/2014"), ManagerId = 8, Area = BusinessArea.Security },
            new SoftwareEngineer(10, "Bob Martin") { HireDate = DateTime.Parse("11/22/2014"), ManagerId = 6, Skill = TechnicalSkill.CSharp},
            new BusinessAnalyst(11, "Dabney Coleman") { HireDate = DateTime.Parse("8/21/2015"), ManagerId = 8, Area = BusinessArea.ThermonuclearWarfare },
            new BusinessAnalyst(12, "Agent Smith") { HireDate = DateTime.Parse("4/16/2016"), ManagerId = 6, Area = BusinessArea.SalesSystem },
            new SoftwareEngineer(13, "Donald Knuth") { HireDate = DateTime.Parse("3/25/2017"), ManagerId = 8, Skill = TechnicalSkill.JavaScript},
            new BusinessAnalyst(14, "Kevin Flynn") { HireDate = DateTime.Parse("5/24/2018"), ManagerId = 6, Area = BusinessArea.OrderFulfillment},
        };        
    }
}