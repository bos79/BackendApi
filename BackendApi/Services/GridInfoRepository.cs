using BackendApi.DbContexts;
using BackendApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace BackendApi.Services
{
    public class GridInfoRepository : IGridInfoRepository
    {
        private readonly GridInfoContext _context;

        public GridInfoRepository(GridInfoContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<Grid>> GetGridsAsync()
        {
            return await _context.Grids.ToListAsync();
        }


        public async Task<Grid?> GetGridAsync(int gridId)
        {
            
                return await _context.Grids
                    .Where(c => c.Id == gridId).FirstOrDefaultAsync();
        }

        public async Task<bool> GridExistsAsync(int gridId)
        {
            return await _context.Grids.AnyAsync(c => c.Id == gridId);
        }
         public async Task<bool> CordinateExistsAsync(int row, int col, string status)
        {
            // Check if a coordinate with the given row, column, and status exists in the database
            return await _context.Cells.AnyAsync(c => c.Row == row && c.Col == col);
        }
          public int GetCordinatIdAsync(int row, int col, int gridId)
        {
            var cell = _context.Cells.Where(c => c.Row == row && c.Col == col && c.GridId == gridId).FirstOrDefault();
            if (cell != null)
            {
                return cell.Id;
            }
            return 0;
        }

        public async Task<Cordinates> GetCordinateForGridAsync(
            int gridId,
            int cordinateId)
        {

            var cell = await _context.Cells
               .Where(p => p.GridId == gridId && p.Id == cordinateId)
               .FirstOrDefaultAsync();
             if (cell != null)
            {
                return cell;
            }
            return null;
        }
        

        public async Task<IEnumerable<Cordinates>> GetCordinatesForGridAsync(
            int gridId)
        {
            return await _context.Cells
                           .Where(p => p.GridId == gridId).ToListAsync();
        }

         public async Task AddGrid(Grid grid)
        {
            if (grid != null)
            {
                 _context.Grids.Add(grid);
                await _context.SaveChangesAsync();
            }
            
        }


        public async Task AddCordinatsForGridAsync(int gridId,
            Cordinates cordinates)
        {
            var grid = await GetGridAsync(gridId);
            if (grid != null)
            {
                grid.Cordinates.Add(cordinates);
            }
            
        }
        public  async void DeleteGrid(int gridId)
        {
            var grid = await GetGridAsync(gridId);
             if (grid != null)
            {
                 var coordinates = _context.Cells.Where(c => c.GridId == gridId);
                _context.Cells.RemoveRange(coordinates);
                _context.Grids.Remove(grid);
               await _context.SaveChangesAsync();
            }
            
        }
        public async Task<bool> IsNameUnique(string name)
        {
            return await _context.Grids.AllAsync(grid => grid.Name != name);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync() >= 0);
        }
    }
}
