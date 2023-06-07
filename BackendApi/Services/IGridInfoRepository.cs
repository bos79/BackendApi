using BackendApi.Entities;

namespace BackendApi.Services
{
    public interface IGridInfoRepository
    {
        Task<IEnumerable<Grid>> GetGridsAsync();
        Task<Grid?> GetGridAsync(int gridId);
        Task<bool> GridExistsAsync(int gridId);
        Task<bool> CordinateExistsAsync(int row, int col, string status);
        int GetCordinatIdAsync(int row, int col, int gridId);
        Task<bool> IsNameUnique(string name);
        Task<IEnumerable<Cordinates>> GetCordinatesForGridAsync(int gridId);
        Task<Cordinates> GetCordinateForGridAsync(int gridId, int cordinatsId);
        Task AddGrid(Grid grid);
        Task AddCordinatsForGridAsync(int gridId, Cordinates cordinates);
        void DeleteGrid(int gridId);
        Task<bool> SaveChangesAsync();
    }
}
