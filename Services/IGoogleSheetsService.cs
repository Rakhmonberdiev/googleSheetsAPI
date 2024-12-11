using googleSheetsAPI.Models;

namespace googleSheetsAPI.Services
{
    public interface IGoogleSheetsService
    {
        Task<bool> Create(UserData model);
    }
}
