using System;
using System.Collections.Generic;
using System.Text;

namespace WMS_DataAccess.Ryan_DataAccess
{
    public interface IRyanIDA
    {
        //显示
        List<T> Show<T>(string sql) where T : class, new();

    }
}
