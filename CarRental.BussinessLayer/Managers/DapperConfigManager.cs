using CarRental.BussinessLayer.Interfaces;
using CarRental.Data.Managers;

namespace CarRental.BussinessLayer.Managers
{
    public class DapperConfigManager : DapperConfigurationManager, IDapperConfiguration
    {
        public string GetCachedAndFormat(int maxCach, object value)
        {
            string formatString = DateTime.Now.ToString();

            List<Tuple<string, string, int>> sqls = Dapper.SqlMapper.GetCachedSQL(maxCach).ToList();

            string result = sqls[0].Item1 + formatString;

            return result;
        }
    }
}
