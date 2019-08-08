using System.Collections.Generic;
using System.Threading.Tasks;

namespace Demo.Start
{
    public class CompensationCalculator
    {
        private readonly IEmployeeService _employeeRepository;

        public CompensationCalculator(IEmployeeService employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public void GetCompensation(int employeeId, out int salary, out int bonus)
        {
            var employee = _employeeRepository.GetEmployee(employeeId).Result;
            salary = CalculateSalary(employee);
            bonus = CalculateBonus(employee);
        }

#region later...
        public (int salary, int bonus) GetCompensation(Employee employee) => (CalculateSalary(employee), CalculateBonus(employee));

        public async Task<int> CalculateTeamTotalCompensation(int managerId)
        {
            var total = 0;
            foreach( var employee in await _employeeRepository.GetDirectReports(managerId))
            {
                var comp = GetCompensation(employee);
                total = total + comp.salary + comp.bonus;
            }
            return total;
        }
#endregion

        private const double BaseSalary = 90000;
        private int CalculateSalary(Employee employee)
        {
            var salary = BaseSalary;

            if(employee.GetType() == typeof(Manager))
            {
                var manager = employee as Manager;
                salary += (manager.TimeWithCompany.TotalDays / 365) * 5000;
                if(manager.DirectReports.Count > 5)
                    salary += 10000;
            }
            else if (employee.GetType() == typeof(SoftwareEngineer))
            {
                var engineer = employee as SoftwareEngineer;
                salary += (engineer.TimeWithCompany.TotalDays / 365) * 4000;
                switch (engineer.Skill)
                {
                    case TechnicalSkill.CSharp:
                        salary += 20000;
                        break;
                    case TechnicalSkill.JavaScript:
                        salary += 10000;
                        break;
                    case TechnicalSkill.VisualBasic:
                    case TechnicalSkill.Whitespace:
                        salary -= 5000;
                        break;
                }
            }
            else if (employee.GetType() == typeof(BusinessAnalyst))
            {
                var ba = employee as BusinessAnalyst;
                salary += (ba.TimeWithCompany.TotalDays / 365) * 3000;
                if(ba.Area == BusinessArea.ThermonuclearWarfare)
                    salary += 25000;
            }

            return (int)salary;
        }

        private int CalculateBonus(Employee employee)
        {
            var years = (int)employee.TimeWithCompany.TotalDays / 365;
            var bonus = CalculateYearlyBonus(years);

            if(employee.GetType() == typeof(Manager))
            {
                var manager = employee as Manager;
                bonus = manager.DirectReports.Count * 5000;
            }         
            
            return bonus;
        }

        private int CalculateYearlyBonus(int years)
        {
            if(years >= 1 && years < 5) return 5000;
            if(years >= 5 && years < 10) return 1000;
            if(years >= 10) return 15000;
            return 0;            
        }
    }
}