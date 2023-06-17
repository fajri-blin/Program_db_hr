using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program_db_hr.Views;

public class DepartmentViews
{
    public static void Result(params object[] args)
    {
        Console.Write($"ID : {args[0]} | ");
        Console.Write($"Department Name : {args[1]} | ");
        Console.Write($"Location ID : {args[2]} | ");
        Console.Write($"Manager ID : {args[3]} | ");
        Console.WriteLine("");
    }
}
