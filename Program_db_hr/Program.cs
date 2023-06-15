using System.Data.SqlClient;

namespace Program_db_hr.TableDB
{
    public class Program
    {

        public static void Main(string[] args)
        {
            //Check the method of the system
            //Please uncomment some of these
            //Pull this from GitHub Online Website

            //LINQ TASK


            /* TASK 1
             * Create LINQ method to show data with criteria include :
             * 1. Employees Data
             * 2. Add informations about departments name
             * 3. Add informations about country
             * 4. Add informations about region
             * 5. Show only 5 data
             * Columns that shows : id, full_name, email, phone, salary, department_name, street_address, country_name, region_name.
             */


            /* Task 2
             * 1. Count Employee from each department
             * 2. Add information about lowest salary, highest salary, and average salary from each department
             * 3. Show the department that have employees more than 3
             * Columns that shows : department_name, total_employee, min_salary, max_salary, average_salary
             */

            Employee employee = new Employee();
            Department department = new Department();
            Location location = new Location();
            Country country = new Country();
            Region region = new Region();

            var task1 = (from emp in employee.GetAllEmployees() 
                         join dept in department.GetAllDepartments() on emp.DepartmentId equals dept.Id
                         join loc in location.GetAllLocations() on dept.LocationId equals loc.Id
                         join cou in country.GetAllCountries() on loc.CountryId equals cou.Id
                         join reg in region.GetAllRegions() on cou.RegionId equals reg.Id
                         select new
                         {
                             id = emp.Id,
                             full_name = string.Concat(emp.FirstName," ", emp.LastName),
                             email = emp.Email,
                             phone = emp.PhoneNumber,
                             salary = emp.Salary,
                             department_name = dept.Name,
                             street_address = loc.StreetAdress,
                             country_name = cou.Name,
                             region_name = reg.Name
                         }).Take(5).ToList();

            var task2 = (from dept in department.GetAllDepartments()
                         join emp in employee.GetAllEmployees() on dept.Id equals emp.DepartmentId into empGroup
                         where empGroup.Count() > 3
                         select new
                         {
                             department_name = dept.Name,
                             total_employee = empGroup.Count(),
                             min_salary = empGroup.Min(emp => emp.Salary),
                             max_salary = empGroup.Max(emp => emp.Salary),
                             average_salary = empGroup.Average(emp => emp.Salary),
                         }).ToList();


            //Tugas LINQ 1
            Console.WriteLine("Tugas LINQ 1");
            foreach (var data in task1)
            {
                Console.Write($"| {data.id} |");
                Console.Write($" {data.full_name} |");
                Console.Write($" {data.email} |");
                Console.Write($"  {data.phone}  |");
                Console.Write($"  {data.salary}  |");
                Console.Write($" {data.department_name} |");
                Console.Write($"  {data.street_address}  |");
                Console.Write($"  {data.country_name}  |");
                Console.Write($"  {data.region_name}  |");
                Console.WriteLine("\n==============================================================================================================================================================================");
            }

            //Tugas LINQ 2
            Console.WriteLine("Tugas LINQ 2");
            foreach( var data in task2)
            {
                Console.WriteLine($"Departement Name : {data.department_name}");
                Console.WriteLine($"Total Employees  : {data.total_employee}");
                Console.WriteLine($"Min Salary       : {data.min_salary}");
                Console.WriteLine($"Max Salary       : {data.max_salary}");
                Console.WriteLine($"Average Salary   : {data.average_salary}");

            }

        }
    }
}
