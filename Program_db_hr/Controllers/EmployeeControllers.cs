using Program_db_hr.Models;
using Program_db_hr.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program_db_hr.Controllers;

public class EmployeeControllers
{
    private Models.Employee _employee = new Models.Employee();
    public void GetAll()
    {
        bool result = false;
        var list = _employee.GetAll();

        if (list != null)
        {
            result = true;
            foreach (var data in list)
            {
                EmployeeViews.Result(data.Id, string.Concat(data.FirstName," ",data.LastName), data.Email, data.PhoneNumber, data.HireDate, data.Salary, data.CommissionPCT, data.ManagerId, data.JobId, data.DepartmentId);
            }
        }
        else
        {
            StatusViews.AllDataNotFound();
        }
    }
}
