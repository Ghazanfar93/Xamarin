using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PharmaGuideApp.Models;

namespace PharmaGuideApp.Data
{
    public interface IRestService
    {
        Task<List<BrandInfo>> GetBrandInfoAsync();
        void SaveBrandInfoAsync(BrandInfo item, bool isNewItem);

    }
}
