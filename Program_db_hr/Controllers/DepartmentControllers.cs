using Program_db_hr.Models;
using Program_db_hr.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program_db_hr.Controllers;

public class DepartmentControllers
{
    private Models.Department _department = new Models.Department();
    public void GetAll()
    {
        bool result = false;
        var list = _department.GetAll();

        if (list != null)
        {
            result = true;
            foreach (var data in list)
            {
                DepartmentViews.Result(data.Id, data.Name, data.LocationId, data.ManagerId);
            }
        }
        else
        {
            StatusViews.AllDataNotFound();
        }
    }
}
