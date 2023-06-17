using Program_db_hr.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Program_db_hr.Views;

namespace Program_db_hr.Controllers;

public class CountryControllers
{
    private Models.Country _country = new Models.Country();

    public void GetAll()
    {
        bool result = false;
        var list = _country.GetAll();

        if (list != null)
        {
            result = true;
            foreach(var data in list)
            {
                CountryViews.Result(data.Id, data.Name, data.IdRegions);
            }
        }
        else
        {
            StatusViews.AllDataNotFound();
        }
    }

    public Country GetByID()
    {
        CountryViews.InputID();
        string id = Console.ReadLine();

        var data = _country.GetById(id);
        bool result = false;

        if (data != null)
        {
            CountryViews.Result(data.Id, data.Name, data.IdRegions);
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
        CountryViews.InputID();
        _country.Id = Console.ReadLine();

        CountryViews.InputName();
        _country.Name = Console.ReadLine();

        CountryViews.InputRegionID();
        _country.IdRegions = Convert.ToInt32(Console.ReadLine());

        int result = _country.Create(_country.Id, _country.Name, _country.IdRegions);

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
            CountryViews.InputID();
            _country.Id = Console.ReadLine();

            CountryViews.InputName();
            _country.Name = Console.ReadLine();

            CountryViews.InputRegionID();
            _country.IdRegions = Convert.ToInt32(Console.ReadLine());

            int status = _country.Update(data.Id,_country.Id, _country.Name, _country.IdRegions);
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

            int status = _country.Delete(data.Id);
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
