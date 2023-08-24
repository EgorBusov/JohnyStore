using JohnyStoreApi.Models.Style;

namespace JohnyStoreApi.Services.Interfaces.DataInterfaces
{
    public interface IStyleDataService
    {
        List<StyleModel> GetStyles();
        StyleModel GetStyleById(int id);
        bool AddStyle(StyleModel model);
        bool EditStyle(StyleModel model);
        bool DeleteStyle(int id);
    }
}
