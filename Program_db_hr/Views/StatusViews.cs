using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program_db_hr.Views;

public class StatusViews
{
    public static void InsertSuccess()
    {
        Console.WriteLine("Insert Success");
    }

    public static void InsertFailed()
    {
        Console.WriteLine("Insert Failed");
    }
    public static void UpdateSuccess()
    {
        Console.WriteLine("Update Success");
    }

    public static void UpdateFailed()
    {
        Console.WriteLine("Update Failed");
    }
    public static void DeleteSuccess()
    {
        Console.WriteLine("Delete Success");
    }

    public static void DeleteFailed()
    {
        Console.WriteLine("Delete Failed");
    }

    public static void AllDataNotFound()
    {
        Console.WriteLine("Data Not Found");
    }

    public static void DataNotFoundByID(object id)
    {
        Console.WriteLine($"The ID {id} not Found.");
    }

    public static void ProcessFailed()
    {
        Console.WriteLine("Process Failed");
    }

    public static void InputUnknown()
    {
        Console.WriteLine("Input Unknown");
    }
}
