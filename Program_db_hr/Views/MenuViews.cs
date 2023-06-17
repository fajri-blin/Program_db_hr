using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program_db_hr.Views;

public class MenuViews
{
    public static void MainMenu()
    {
        Console.WriteLine("MAIN MENU ");
        Console.WriteLine("==================================================");
        Console.WriteLine("1. Country");
        Console.WriteLine("2. Department");
        Console.WriteLine("3. Employee");
        Console.WriteLine("4. History");
        Console.WriteLine("5. Job");
        Console.WriteLine("6. Locations");
        Console.WriteLine("7. Region");
        Console.WriteLine("0. Exit");
        Console.WriteLine("==================================================");
        Console.Write("Select Menu : ");
    }

    public static void SubMenu()
    {
        Console.WriteLine("--------------------------------------------------");
        Console.WriteLine("SUB MENU");
        Console.WriteLine("==================================================");
        Console.WriteLine("1. Get Data By Id");
        Console.WriteLine("2. Create Data");
        Console.WriteLine("3. Update Data By Id");
        Console.WriteLine("4. Delete Data By Id");
        Console.WriteLine("0. Exit");
        Console.WriteLine("==================================================");
        Console.Write("Select Menu : ");
    }

    public static void ExitMenu()
    {
        Console.WriteLine("--------------------------------------------------");
        Console.WriteLine("SUB MENU");
        Console.WriteLine("==================================================");
        Console.WriteLine("0. Exit");
        Console.WriteLine("==================================================");
        Console.Write("Select Menu : ");
    }
}
