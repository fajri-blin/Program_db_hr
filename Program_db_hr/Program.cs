using Program_db_hr.Controllers;
using Program_db_hr.Views;
using System.Data.SqlClient;

namespace Program_db_hr;

public class Program
{

    public static void Main(string[] args)
    {
        MenuControllers menuControllers = new MenuControllers();

        menuControllers.MainMenu();

    }
}
