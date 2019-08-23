using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DENTALMIS.Utility
{
  public  class AppConfig
  {
      //public const int PageSize = 10;
      public static int PageSize
      {
          get
          {
              var appSettingPageSize = ConfigurationManager.AppSettings["PageSize"];
              if (string.IsNullOrEmpty(appSettingPageSize)) return 0;
              var pageSize = Convert.ToInt16(appSettingPageSize);
              return pageSize >= 0 ? pageSize : 0;
          }
      }


      //public static int PageSize
      //{
      //    get
      //    {
      //        var appSettingPazeSize = ConfigurationManager.AppSettings["PageSize"];
      //        if (string.IsNullOrEmpty(appSettingPazeSize)) return 0;

      //        var pageSize = Convert.ToInt16(appSettingPazeSize);

      //        return pageSize >= 0 ? pageSize : 0;


      //    }
      //}
  }
}
