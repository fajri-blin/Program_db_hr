using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program_db_hr.Views;

public class CountryViews
{
    public static void InputID()
    {
        Console.Write("Input the ID               : ");
    }
    public static void InputName()
    {
        Console.Write("Enter the Name of Country  : ");
    }
    public static void InputRegionID()
    {
        Console.Write("Enter the ID of Region     : ");
    }
    public static void Result(string id, string name, int regionId)
    {
        Console.WriteLine($"|ID : {id} | Country : {name} | Region ID : {regionId}");
    }
}
