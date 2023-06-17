using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program_db_hr.Views;

public class RegionViews
{
    public static void InputID()
    {
        Console.Write("Input the ID               : ");
    }
    public static void InputName()
    {
        Console.Write("Enter the Name of Region  : ");
    }
    public static void Result(int id, string name)
    {
        Console.WriteLine($"|ID : {id} | Country : {name}");
    }
}
