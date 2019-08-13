using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.Start
{
    public interface IEmployeeService
    {
        Employee GetEmployee(int id);
        IEnumerable<Employee> GetDirectReports(int managerId);
    }

    public class EmployeeService : IEmployeeService
    {
        public Employee GetEmployee(int id)
        {
            var employee = _employees.SingleOrDefault(x => x.Id == id);
            Task.Delay(100); // simulate db delay
            return employee;
        }

        public IEnumerable<Employee> GetDirectReports(int managerId)
        {
            var ids = _employees.Where(x=>x.ManagerId == managerId).Select(x=>x.Id);
            Task.Delay(100);
            foreach(var id in ids)
            {
                yield return GetEmployee(id);
            }
        }

        private List<Employee> _employees = new List<Employee>
        {
            new SoftwareEngineer(1, "Alan Turing", "2/15/2004") { ManagerId = 8, Skill = TechnicalSkill.Whitespace},
            new SoftwareEngineer(2, "Linus Torvalds", "12/10/2005") { ManagerId = 8, Skill = TechnicalSkill.JavaScript },
            new SoftwareEngineer(3, "Scott Guthrie", "9/19/2008") { ManagerId = 6, Skill = TechnicalSkill.CSharp },
            new SoftwareEngineer(4, "Bjarne Soustrup", "6/30/2009") { ManagerId = 8, Skill = TechnicalSkill.CSharp },
            new SoftwareEngineer(5, "Anders Hejlsberg", "8/19/2010") { ManagerId = 6, Skill = TechnicalSkill.CSharp },
            new Manager(6, "Bill Gates", "3/2/2011"),
            new SoftwareEngineer(7, "Ada Lovelace", "1/10/2012") { ManagerId = 6, Skill = TechnicalSkill.VisualBasic },
            new Manager(8, "Steve Jobs", "6/21/2014"),
            new BusinessAnalyst(9, "Alan Bradley", "9/22/2014") { ManagerId = 8, Area = BusinessArea.Security },
            new SoftwareEngineer(10, "Bob Martin", "11/22/2014") { ManagerId = 6, Skill = TechnicalSkill.CSharp},
            new BusinessAnalyst(11, "Dabney Coleman", "8/21/2015") { ManagerId = 8, Area = BusinessArea.ThermonuclearWarfare },
            new BusinessAnalyst(12, "Agent Smith", "4/16/2016") { ManagerId = 6, Area = BusinessArea.SalesSystem },
            new SoftwareEngineer(13, "Donald Knuth", "3/25/2017") { ManagerId = 8, Skill = TechnicalSkill.JavaScript},
            new BusinessAnalyst(14, "Kevin Flynn", "5/24/2018") { ManagerId = 6, Area = BusinessArea.OrderFulfillment},
        };        
    }
}