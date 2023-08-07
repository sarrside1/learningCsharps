using HRAdministrationAPI;
namespace SchoollHRAdministration
{
    public enum EmployeeType
    {
        Teacher,
        HeadOfDepartment,
        DeputyHeadMaster,
        HeadMaster
    }
    class Program
    {
        static void Main(String[] args)
        {
            List<IEmployee> employees = new List<IEmployee>();

            SeedData(employees);
            /*
            decimal totalSalaries = 0;
            foreach (IEmployee employee in employees)
            {
                totalSalaries += employee.Salary;
            }
            Console.WriteLine($"Total annual salaries (including bonus): {totalSalaries}");
            */
            Console.WriteLine($"Total annual salaries (including bonus): {employees.Sum(e => e.Salary)}");
            Console.ReadKey();
        }
        static void SeedData(List<IEmployee> employees)
        {
            IEmployee teacher1 = EmployeeFactory.GetEmployeeInstance(EmployeeType.Teacher, 1, "Sidé", "Sarr", 1750);
            employees.Add(teacher1);
            IEmployee teacher2 = EmployeeFactory.GetEmployeeInstance(EmployeeType.Teacher, 2, "Moustapha", "Faye", 1900);
            employees.Add(teacher2);
            IEmployee headOfDepartment1 = EmployeeFactory.GetEmployeeInstance(EmployeeType.HeadOfDepartment, 3, "Papa Moussa", "Thiam", 2500);
            employees.Add(headOfDepartment1);
            IEmployee deputyHeadMaster = EmployeeFactory.GetEmployeeInstance(EmployeeType.DeputyHeadMaster, 4, "Lathyrol", "Ndong", 2750);
            employees.Add(deputyHeadMaster);
            IEmployee headMaster = EmployeeFactory.GetEmployeeInstance(EmployeeType.Teacher, 5, "Diégane", "Ngom", 3000);
            employees.Add(headMaster);
        }
    }
    public class Teacher : EmployeeBase
    {
        public override decimal Salary { get => base.Salary + base.Salary * 0.02m; }
    }

    public class HeadOfDepartment : EmployeeBase
    {
        public override decimal Salary { get => base.Salary + base.Salary * 0.03m; }
    }

    public class DeputyHeadMaster : EmployeeBase
    {
        public override decimal Salary { get => base.Salary + base.Salary * 0.04m; }
    }

    public class HeadMaster : EmployeeBase
    {
        public override decimal Salary { get => base.Salary + base.Salary * 0.05m; }
    }

    public static class EmployeeFactory
    {
        public static IEmployee GetEmployeeInstance(EmployeeType employeeType, int id, string firstname, string lastname, decimal salary)
        {
            IEmployee employee = null;
            switch (employeeType)
            {
                case EmployeeType.Teacher:
                    employee = FactoryPattern<IEmployee, Teacher>.GetInstance();
                    break;
                case EmployeeType.DeputyHeadMaster:
                    employee = FactoryPattern<IEmployee, DeputyHeadMaster>.GetInstance();
                    break;
                case EmployeeType.HeadMaster:
                    employee = FactoryPattern<IEmployee, HeadMaster>.GetInstance();
                    break;
                case EmployeeType.HeadOfDepartment:
                    employee = FactoryPattern<IEmployee, HeadOfDepartment>.GetInstance();
                    break;
                default:
                    break;
            }
            if(employee != null)
            {
                employee.Id = id;
                employee.FirstName = firstname;
                employee.LastName = lastname;
                employee.Salary = salary;
            }
            else
            {
                throw new ArgumentNullException();
            }
            return employee;
        }
    }
}

