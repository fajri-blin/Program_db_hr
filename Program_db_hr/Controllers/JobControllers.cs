using Program_db_hr.Models;
using Program_db_hr.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program_db_hr.Controllers;

public class JobControllers
{
    private Models.Job _job = new Models.Job();
    public void GetAll()
    {
        bool result = false;
        var list = _job.GetAll();

        if (list != null)
        {
            result = true;
            foreach (var data in list)
            {
                JobViews.Result(data.Id, data.Title, data.MinSalary, data.MaxSalary);
            }
        }
        else
        {
            StatusViews.AllDataNotFound();
        }
    }
}
