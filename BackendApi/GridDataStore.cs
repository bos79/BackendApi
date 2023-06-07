using BackendApi.Models;
using BackendApi.Helpers;
using System.Runtime.CompilerServices;
using System.Security.Principal;

namespace BackendApi
{
    public class GridDataStore
    {
        public List<GridDto> Grids { get; set; }

        int[,] grid = new int[6, 6];

        public static GridDataStore Current { get; } = new GridDataStore();

                        // Add dummy data to the grid
                       
        //public GridDataStore() 
        //{
        //    Grids = new List<GridDto>();
           
        //    GridDto gridDto1 = new GridDto();
        //    gridDto1.Id = 1;
        //    gridDto1.Name = "Grid1";
        //    gridDto1.Description = "Sample grid";

        //    gridDto1.CordinatesDto = new CordinatesDto[6][];
        //    var count = 0;
        //    // Add dummy data to the CoordinatesDto array
        //    for (int row = 0; row < 6; row++)
        //    {
        //        gridDto1.CordinatesDto[row] = new CordinatesDto[6];
        //        for (int col = 0; col < 6; col++)
        //        {
        //            gridDto1.CordinatesDto[row][col] = new CordinatesDto
        //            {
        //                Id = count++,
        //                Row = row,
        //                Col = col,
        //                Status = Status.OK.ToString() 
        //            };
        //        }
        //    }
        //    Grids.Add(gridDto1);
        //}

    }
}
