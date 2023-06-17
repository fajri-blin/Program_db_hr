using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program_db_hr.Views;

public class LocationViews
{
    public static void Result(params object[] args)
    {
        Console.WriteLine($"ID             : {args[0]} | ");
        Console.WriteLine($"Street Address : {args[1]} | ");
        Console.WriteLine($"Postal Code    : {args[2]} | ");
        Console.WriteLine($"City           : {args[3]} | ");
        Console.WriteLine($"State Province : {args[4]} | ");
        Console.WriteLine($"Country ID     : {args[5]} | ");
        Console.WriteLine("==========================================");
    }
}
