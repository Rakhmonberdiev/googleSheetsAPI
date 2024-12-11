using googleSheetsAPI.Models;

namespace googleSheetsAPI.Helpers
{
    public static class Mapper
    {
        public static List<IList<object>> MapToRangeData(UserData model)
        {
            var objectList = new List<object>() { model.Name, model.PhoneNumber, model.CreatedD };
            var rangeData = new List<IList<object>> { objectList };
            return rangeData;
        }
    }
}
