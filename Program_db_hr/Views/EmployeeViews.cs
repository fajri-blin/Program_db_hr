using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program_db_hr.Views;

public class EmployeeViews
{
    public static void Result(params object[] args)
    {
        Console.WriteLine($"ID            : {args[0]} | ");
        Console.WriteLine($"Fullname      : {args[1]} | ");
        Console.WriteLine($"Email         : {args[2]} | ");
        Console.WriteLine($"Phone Number  : {args[3]} | ");
        Console.WriteLine($"Hire Date     : {args[4]} | ");
        Console.WriteLine($"Salary        : {args[5]} | ");
        Console.WriteLine($"Commisiom PCT : {args[6]} | ");
        Console.WriteLine($"Manager ID    : {args[7]} | ");
        Console.WriteLine($"Job ID        : {args[8]} | ");
        Console.WriteLine($"Department ID : {args[9]} | ");
        Console.WriteLine("==========================================");
    }
}
