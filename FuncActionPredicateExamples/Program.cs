namespace FuncActionPredicateExamplels
{
    class Program
    {
        delegate TResult Func2<out TResult>();
        delegate TResult Func2<in T1, out TResult>(T1 arg);
        delegate TResult Func2<in T1, in T2, out TResult>(T1 arg1, T2 arg2);
        delegate TResult Func2<in T1, in T2, in T3, out TResult>(T1 arg1, T2 arg2, T3 arg3);
        static void Main(string[] args)
        {
            MathClass mathClass = new MathClass();

            //Func2<int, int, int> calc = mathClass.Sum;
            //Func<int, int, int> calc1 = delegate (int a, int b) { return a + b; };
            //Func<int, int, int> calc2 = (int a, int b) =>  a + b;
            //int result = calc(1, 2);
            //int result2 = calc(1, 2);
            //Console.WriteLine($"Result1: {result}");
            //Console.WriteLine($"Result2: {result2}");

            //float d = 2.3f, e = 4.56f;
            //int f = 5;
            //Func<float, float, int, float> calc2 = (arg1, arg2, arg3) => (arg1 + arg2) * arg3;
            //float res = calc2(d, e, f);
            //Console.WriteLine($"Result1: {res}");
            Func<decimal, decimal, decimal> calSalary = (annualSalary, bonusPercentage) => annualSalary + (annualSalary * (bonusPercentage / 100));
            Console.WriteLine($"Results: {calSalary(1250, 3)}");
            Action<int, string, string, decimal, char, bool> displayEmployeeRecords = (arg1, arg2, arg3, arg4, arg5, arg6) => Console.WriteLine($"Id: {arg1} FirstName: {arg2}{Environment.NewLine}LastName: {arg3} {Environment.NewLine}Annual Salary: {arg4} Gender: {arg4} {Environment.NewLine}Is Manager: {arg6}");
            //displayEmployeeRecords(1, "Sidé", "SARR", 12500);

            List<Employee> employees = new List<Employee>();
            employees.Add(new Employee { Id = 1, FirstName = "Sidé", LastName = "SARR", Gender = 'm', AnnualSalary = 1500, IsManager = false });
            employees.Add(new Employee { Id = 2, FirstName = "Papa Moussa", LastName = "THIAM", Gender = 'm', AnnualSalary = 1700, IsManager = true });
            employees.Add(new Employee { Id = 3, FirstName = "Moustapha", LastName = "FAYE", Gender = 'm', AnnualSalary = 2500, IsManager = true });
            employees.Add(new Employee { Id = 4, FirstName = "Lathyrole", LastName = "NDONG", Gender = 'm', AnnualSalary = 1750, IsManager = false });
            //List<Employee> employeesFiltered = FilterEmployees(employees, e => e.Gender == 'm');
            List<Employee> employeesFiltered = employees.FilterEmployees(e => e.Gender == 'm');
            foreach (var item in employeesFiltered)
            {
                displayEmployeeRecords(item.Id, item.FirstName, item.LastName, item.AnnualSalary, item.Gender, item.IsManager);
                Console.WriteLine();
            }
            Console.ReadKey();
        }
    }

    public static class Extension
    {
        public static List<Employee> FilterEmployees(this List<Employee> employees, Predicate<Employee> predicate)
        {
            List<Employee> filterEmployees = new List<Employee>();
            foreach (var employee in employees)
            {
                if (predicate(employee))
                {
                    filterEmployees.Add(employee);
                }
            }
            return filterEmployees;
        }
    }

    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal AnnualSalary { get; set; }
        public char Gender { get; set; }
        public bool IsManager { get; set; }
    }

    public class MathClass
    {
        public int Sum(int a, int b)
        {
            return a + b;
        }
    }
}