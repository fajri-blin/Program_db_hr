using Program_db_hr.Models;
using Program_db_hr.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program_db_hr.Controllers;

public class MenuControllers
{
    private CountryControllers _countryControllers = new CountryControllers();
    private RegionControllers _regionControllers = new RegionControllers();
    private DepartmentControllers _departmentControllers = new DepartmentControllers();
    private EmployeeControllers _employeeControllers = new EmployeeControllers();
    private HistoryControllers _historyControllers = new HistoryControllers();
    private JobControllers _jobControllers = new JobControllers();
    private LocationControllers _locationControllers = new LocationControllers();


    public void MainMenu()
    {
        bool status = true;
        do
        {
            Console.Clear();

            MenuViews.MainMenu();
            int SelectMenu = Convert.ToInt32(Console.ReadLine());
            switch (SelectMenu)
            {
                case 1:
                    //Country
                    SubMenuCountry();
                    break;
                case 2:
                    //Department
                    SubMenuDepartment();
                    break;
                case 3:
                    //Employee
                    SubMenuEmployee();
                    break;
                case 4:
                    //History
                    SubMenuHistory();
                    break;
                case 5:
                    //Job
                    SubMenuJob();
                    break;
                case 6:
                    //Location
                    SubMenuLocation();
                    break;
                case 7:
                    //Region
                    SubMenuRegion();
                    break;
                case 0:
                    status = false;
                    break;
            }
        } while (status);
    }

    public void SubMenuDepartment()
    {
        bool status = true;
        do
        {
            Console.Clear();
            _departmentControllers.GetAll();

            MenuViews.ExitMenu();
            int SelectMenu = Convert.ToInt32(Console.ReadLine());
            switch(SelectMenu)
            {
                case 0:
                    status = false;
                    break;
                default:
                    StatusViews.InputUnknown();
                    break;
            }
        } while (status);
    }
    public void SubMenuEmployee()
    {
        bool status = true;
        do
        {
            Console.Clear();
            _employeeControllers.GetAll();

            MenuViews.ExitMenu();
            int SelectMenu = Convert.ToInt32(Console.ReadLine());
            switch (SelectMenu)
            {
                case 0:
                    status = false;
                    break;
                default:
                    StatusViews.InputUnknown();
                    break;
            }
        } while (status);
    }

    public void SubMenuHistory()
    {
        bool status = true;
        do
        {
            Console.Clear();
            _historyControllers.GetAll();

            MenuViews.ExitMenu();
            int SelectMenu = Convert.ToInt32(Console.ReadLine());
            switch (SelectMenu)
            {
                case 0:
                    status = false;
                    break;
                default:
                    StatusViews.InputUnknown();
                    break;
            }
        } while (status);
    }
    public void SubMenuJob()
    {
        bool status = true;
        do
        {
            Console.Clear();
            _jobControllers.GetAll();

            MenuViews.ExitMenu();
            int SelectMenu = Convert.ToInt32(Console.ReadLine());
            switch (SelectMenu)
            {
                case 0:
                    status = false;
                    break;
                default:
                    StatusViews.InputUnknown();
                    break;
            }
        } while (status);
    }
    public void SubMenuLocation()
    {
        bool status = true;
        do
        {
            Console.Clear();
            _locationControllers.GetAll();

            MenuViews.ExitMenu();
            int SelectMenu = Convert.ToInt32(Console.ReadLine());
            switch (SelectMenu)
            {
                case 0:
                    status = false;
                    break;
                default:
                    StatusViews.InputUnknown();
                    break;
            }
        } while (status);
    }

    public void SubMenuCountry()
    {
        bool status = true;
        do
        {
            Console.Clear();
            _countryControllers.GetAll();

            MenuViews.SubMenu();
            int SelectMenu = Convert.ToInt32(Console.ReadLine());
            switch (SelectMenu)
            {
                case 1:
                    //Get All Data By ID
                    _countryControllers.GetByID();
                    Console.ReadLine();
                    break;
                case 2:
                    //Create Data
                    _countryControllers.Create();
                    Console.ReadLine();
                    break;
                case 3:
                    //Update Data By ID
                    _countryControllers.Update();
                    Console.ReadLine();
                    break;
                case 4:
                    //Delete Data By ID
                    _countryControllers.Delete();
                    Console.ReadLine();
                    break;
                case 0:
                    status = false;
                    break;
                default:
                    StatusViews.InputUnknown();
                    Console.ReadLine();
                    break;
            }
        }while (status);
    }

    public void SubMenuRegion()
    {
        bool status = true;
        do
        {
            Console.Clear();
            _regionControllers.GetAll();


            MenuViews.SubMenu();
            int SelectMenu = Convert.ToInt32(Console.ReadLine());
            switch (SelectMenu)
            {
                case 1:
                    //Get All Data By ID
                    _regionControllers.GetByID();
                    Console.ReadLine();
                    break;
                case 2:
                    //Create Data
                    _regionControllers.Create();
                    Console.ReadLine();
                    break;
                case 3:
                    //Update Data By ID
                    _regionControllers.Update();
                    Console.ReadLine();
                    break;
                case 4:
                    //Delete Data By ID
                    _regionControllers.Delete();
                    Console.ReadLine();
                    break;
                case 0:
                    status = false;
                    break;
                default:
                    StatusViews.InputUnknown();
                    Console.ReadLine();
                    break;
            }
        } while (status);
    }
}
