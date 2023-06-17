using Program_db_hr.Models;
using Program_db_hr.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program_db_hr.Controllers;

public class LocationControllers
{
    private Models.Location _location = new Models.Location();
    public void GetAll()
    {
        bool result = false;
        var list = _location.GetAll();

        if (list != null)
        {
            result = true;
            foreach (var data in list)
            {
                LocationViews.Result(data.Id, data.StreetAdress, data.PostalCode, data.City, data.StateProvince, data.CountryId);
            }
        }
        else
        {
            StatusViews.AllDataNotFound();
        }
    }
}
