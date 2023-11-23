using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Product.Management.DataAccessLayer.MariaDB
{
    public interface ICoreData
    {
        T[] ConvertToList<T>(DataTable dataTable);
    }
}
