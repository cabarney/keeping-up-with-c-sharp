using System.Threading.Tasks;

namespace Demo.Finish
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
            var employee = _employeeRepository.GetEmployee(employeeId);
            salary = CalculateSalary(employee);
            bonus = CalculateBonus(employee);
        }

        public (int salary, int bonus) GetCompensation(Employee employee) => (CalculateSalary(employee), CalculateBonus(employee));

        public async Task<int> CalculateTeamTotalCompensation(int managerId)
        {
            var total = 0;
            await foreach( var employee in _employeeRepository.GetDirectReportsAsync(managerId))
            {
                var comp = GetCompensation(employee);
                total = total + comp.salary + comp.bonus;
            }
            return total;
        }

        private const int BaseSalary = 90000;
        private int CalculateSalary(Employee employee)
        {
            var yearsOnJob = (int)(employee.TimeWithCompany.TotalDays / 365);

            var yearlyMultiplier = employee switch
            {
                Manager _ => 5000,
                SoftwareEngineer _ => 4000,
                BusinessAnalyst _ => 3000,
                _ => 0
            };

            return BaseSalary + yearlyMultiplier * yearsOnJob + employee switch
            {
                Manager manager when manager.DirectReports.Count > 5 => 10000,
                SoftwareEngineer {Skill: TechnicalSkill.CSharp} => 20000,
                SoftwareEngineer {Skill: TechnicalSkill.VisualBasic} => -5000,
                SoftwareEngineer {} => 10000,
                BusinessAnalyst {Area : BusinessArea.ThermonuclearWarfare} => 25000,
                _ => 0
            };

            #region step1
            // switch(employee)
            // {
            //     case Manager manager when manager.DirectReports.Count > 5:
            //         salary += 10000;
            //     break;
            //     case SoftwareEngineer engineer:
            //         salary += engineer switch
            //         {
            //             {Skill : TechnicalSkill.CSharp} => 20000,
            //             {Skill : TechnicalSkill.JavaScript} => 10000,
            //             _ => -5000
            //         };
            //     break;
            //     case BusinessAnalyst ba when ba.Area == BusinessArea.ThermonuclearWarfare:
            //             salary += 25000;
            //     break;
            // }
            // return (int)salary;
            #endregion
        }

        private int CalculateBonus(Employee employee)
        {
            var years = (int)(employee.TimeWithCompany.TotalDays / 365);
            var bonus = CalculateYearlyBonus(years);

            if(employee is Manager manager)
            {
                bonus += manager.DirectReports.Count * 5000;
            }         
            
            return bonus;
        }

        private int CalculateYearlyBonus(int years)
        {
            if(years >= 1 && years < 5) return 5000;
            if(years >= 5 && years < 10) return 10000;
            if(years >= 10) return 15000;
            return 0;            
        }
    }
}