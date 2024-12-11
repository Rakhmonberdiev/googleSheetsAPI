using Google.Apis.Sheets.v4;
using Google.Apis.Sheets.v4.Data;
using googleSheetsAPI.Helpers;
using static Google.Apis.Sheets.v4.SpreadsheetsResource.ValuesResource;
using System.Reflection;
using googleSheetsAPI.Models;

namespace googleSheetsAPI.Services
{
    public class GoogleSheetsService : IGoogleSheetsService
    {
        static readonly string SPREADSHEET_ID = "18zC1WwTsc58hcHdzU17i6sid3y_hNoWZOA1w2nmli5I";

        SpreadsheetsResource.ValuesResource _googleSheetValues;
        public GoogleSheetsService(GoogleSheetsHelper googleSheetsHelper)
        {
            _googleSheetValues = googleSheetsHelper.Service.Spreadsheets.Values;
        }
        public Task<bool> Create(UserData model)
        {
            try
            {
                var range = $"!A:C";
                var valueRange = new ValueRange
                {
                    Values = Mapper.MapToRangeData(model)
                };
                var appendRequest = _googleSheetValues.Append(valueRange, SPREADSHEET_ID, range);
                appendRequest.ValueInputOption = AppendRequest.ValueInputOptionEnum.USERENTERED;
                appendRequest.Execute();
                return Task.FromResult(true);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return Task.FromResult(false);
            }
         
        }
    }
}
