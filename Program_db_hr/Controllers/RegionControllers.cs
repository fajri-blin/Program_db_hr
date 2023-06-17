using Program_db_hr.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Program_db_hr.Views;

namespace Program_db_hr.Controllers;

public class RegionControllers
{
    private Models.Region _region = new Models.Region();

    public void GetAll()
    {
        bool result = false;
        var list = _region.GetAll();

        if (list != null)
        {
            result = true;
            foreach(var data in list)
            {
                RegionViews.Result(data.Id, data.Name);
            }
        }
        else
        {
            StatusViews.AllDataNotFound();
        }
    }

    public Region GetByID()
    {
        RegionViews.InputID();
        int id = Convert.ToInt32(Console.ReadLine());

        var data = _region.GetById(id);
        bool result = false;

        if (data != null)
        {
            RegionViews.Result(data.Id, data.Name);
            result = true;
        }
        else 
        {
            StatusViews.DataNotFoundByID(id);
        }
        return data;
    }

    public void Create()
    {

        RegionViews.InputName();
        _region.Name = Console.ReadLine();

        int result = _region.Create(_region.Name);

        if (result != 0)
        {
            StatusViews.InsertSuccess();
        }else
        {
            StatusViews.InsertFailed();
        }
    }

    public void Update()
    {
        var data = GetByID();

        if(data != null)
        {
            RegionViews.InputName();
            _region.Name = Console.ReadLine();


            int status = _region.Update(data.Id, _region.Name);
            if (status != 0)
            {
                StatusViews.UpdateSuccess();
            }
            else
            {
                StatusViews.ProcessFailed();
            }
        }
        else
        {
            StatusViews.UpdateFailed();
        }
    }

    public void Delete()
    {
        var data = GetByID();
        if (data != null)
        {

            int status = _region.Delete(data.Id);
            if (status != 0)
            {
                StatusViews.DeleteSuccess();
            }
            else 
            { 
                StatusViews.ProcessFailed(); 
            }
        }
        else
        {
            StatusViews.DeleteFailed();
        }
    }
}
