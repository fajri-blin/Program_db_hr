using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program_db_hr.Views;

public class JobViews
{
    public static void Result(params object[] args)
    {
        Console.WriteLine($"ID            : {args[0]} | ");
        Console.WriteLine($"Job Title     : {args[1]} | ");
        Console.WriteLine($"Min Salary    : {args[2]} | ");
        Console.WriteLine($"Max Salary    : {args[3]} | ");
        Console.WriteLine("==========================================");
    }
}
