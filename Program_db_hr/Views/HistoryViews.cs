using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program_db_hr.Views;

public class HistoryViews
{
    public static void Result(params object[] args)
    {
        Console.WriteLine($"Start Date    : {args[0]} | ");
        Console.WriteLine($"Employee ID   : {args[1]} | ");
        Console.WriteLine($"End Date      : {args[2]} | ");
        Console.WriteLine($"Department ID : {args[3]} | ");
        Console.WriteLine($"Job ID        : {args[4]} | ");
        Console.WriteLine("==========================================");
    }
}
