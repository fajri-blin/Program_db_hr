using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program_db_hr.Views;

public class ErrorViews
{
    public static void ErrorHandlings(Exception ex)
    {
        Console.WriteLine("Error!!!");
        Console.WriteLine(ex.Message);
        Console.WriteLine(ex.StackTrace);
        Console.WriteLine("\n");
    }
}
