using Program_db_hr.Models;
using Program_db_hr.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program_db_hr.Controllers;

public class HistoryControllers
{
    private Models.History _history = new Models.History();
    public void GetAll()
    {
        bool result = false;
        var list = _history.GetAll();

        if (list != null)
        {
            result = true;
            foreach (var data in list)
            {
                HistoryViews.Result(data.StartDate, data.EmployeeId, data.EndDate, data. DepartmentId, data.JobId);
            }
        }
        else
        {
            StatusViews.AllDataNotFound();
        }
    }
}
