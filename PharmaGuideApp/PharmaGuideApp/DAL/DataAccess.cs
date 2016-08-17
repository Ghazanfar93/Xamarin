using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PharmaGuideApp.Models;
using PharmaGuideApp.Data;
using SQLite.Net;
using Xamarin.Forms;

namespace PharmaGuideApp.DAL
{
    public class DataAccess
    {

        private SQLiteConnection _connection;
        IRestService restService;

        public DataAccess(IRestService service)
        {
            _connection = DependencyService.Get<ISQLite>().GetConnection();
            _connection.CreateTable<BrandInfo>();
            restService = service;
        }

        public IEnumerable<BrandInfo> GetBrandsInfo()
        {
            return (from t in _connection.Table<BrandInfo>()
                    select t).ToList();
        }

        public BrandInfo GetBrandInfo(int id)
        {
            return _connection.Table<BrandInfo>().FirstOrDefault(t => t.ID == id);
        }

        public void DeleteBrandInfo(int id)
        {
            _connection.Delete<BrandInfo>(id);
        }

        public void AddBrandInfo(string _brandName)
        {
            var newBrandInfo = new BrandInfo
            {
                BrandName = _brandName,
                // ID = id,
                //CreatedOn = DateTime.Now
            };

            _connection.Insert(newBrandInfo);
        }


        public BrandInfo EditPerson(BrandInfo brandInfo)
        {
            var id = _connection.Update(brandInfo);
            return brandInfo;
        }

        public void SaveBrandInfo(BrandInfo _brandInfo)
        {
            _connection.Insert(_brandInfo);
        }

        public Task<List<BrandInfo>> GetTasksAsync()
        {
            return restService.GetBrandInfoAsync();
        }

        public void SaveTaskAsync(BrandInfo item, bool isNewItem)
        {
            restService.SaveBrandInfoAsync(item, isNewItem);
        }

    }
}
