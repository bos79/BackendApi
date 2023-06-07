using AutoMapper;
using BackendApi.Entities;
using BackendApi.Models;
using BackendApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace BackendApi.Api.Controllers
{
    [ApiController]
    [Route("api/grids")]
    public class GridController : ControllerBase
    {
        private readonly IGridInfoRepository _gridInfoRepository;
        private readonly IMapper mapper;

        public GridController(IGridInfoRepository gridInfoRepository, IMapper mapper) 
        { 
            _gridInfoRepository = gridInfoRepository ??
                throw new ArgumentNullException(nameof(gridInfoRepository));
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GridDto>>> GetGrids()
        {
            var gridEntities = await _gridInfoRepository.GetGridsAsync();
            return Ok(mapper.Map<IEnumerable<GridDto>>(gridEntities));
        }
        [HttpGet("{id}")]
        public async Task< ActionResult<GridDto>> GetGrid(int id) 
        {
            //find grid
            var gridToReturn = await _gridInfoRepository.GetGridAsync(id);
            if (gridToReturn == null)
            {
                return NotFound();
            }
            return Ok(gridToReturn);
        }
        [HttpPost("{name}")]
        public async Task<ActionResult<GridDto>> CreateGrid(string name, int gridId)
        {
            try
            {
                // Validate the input parameters
                if (string.IsNullOrEmpty(name) )
                {
                    return BadRequest("Invalid grid data.");
                }
                
                if (!await _gridInfoRepository.IsNameUnique(name))
                {
                    return BadRequest("Invalid name, It alredy exists.");
                }

                // Map the input parameters to your GridDto or Grid entity
                var grid = new GridForCreationDto
                {
                    Name = name,
                    Description = "Grid"
                };
                  var finalGrid = mapper.Map<Entities.Grid>(grid);

                await _gridInfoRepository.AddGrid(finalGrid);
                var cordinats =  await _gridInfoRepository.GetCordinatesForGridAsync(gridId);
                foreach (var c in cordinats)
                {
                     var coppyCord = new Cordinates(c.Status)
                {
                  
                    Col = c.Col,
                    Row = c.Row,
                    GridId = finalGrid.Id,
                  
                   
                };
                    await _gridInfoRepository.AddCordinatsForGridAsync(finalGrid.Id, coppyCord);
                }
                
                await _gridInfoRepository.SaveChangesAsync();
                // Return the created grid in the response
                return Ok(grid);
            }
            catch (Exception ex)
            {
                // Handle any exceptions that occurred during grid creation
                return StatusCode(500, $"An error occurred while creating the grid: {ex.Message}");
            }
        }

        
        //public async Task<ActionResult<GridDto>> CreateGrid(GridDto gridDto)
        //{
        //    int newGridId = await _gridInfoRepository.AddGrid(gridDto);
        //    return CreatedAtAction(nameof(GetGrid), new { id = newGridId }, gridDto);
        //}
        // [HttpPost("{string}")]
        //public async Task<ActionResult<GridDto>> CreateGrid(string name, string description)
        //{

        //    var finalGrid = mapper.Map<Entities.Grid>(grid);

        //    await _gridInfoRepository.AddGrid(
        //         finalGrid);

        //    await _gridInfoRepository.SaveChangesAsync();
        //    return Ok(finalGrid);

        //    //var createdCordinatsToReturn = 
        //    //    mapper.Map<Models.CordinatesDto>(finalCordinats);

        //    //return CreatedAtRoute("GetCordinats",
        //    //     new
        //    //     {
        //    //         gridId = gridId,
        //    //         cordinatsId = createdCordinatsToReturn.Id
        //    //     },
        //    //     createdCordinatsToReturn);
        //}
        //[HttpPut("{id}")]
        //public IActionResult UpdateGrid(int id, GridDto gridDto)
        //{
        //    bool isUpdated = GridDataStore.UpdateGrid(id, gridDto);
        //    if (!isUpdated)
        //        return NotFound();

        //    return NoContent();
        //}

        [HttpDelete("{id}")]
        public void DeleteGrid(int id)
        {
              _gridInfoRepository.DeleteGrid(id);

        }
        // [HttpDelete("{id]")]
        //public ActionResult<GridDto> DeleteGrid(int id)
        //{
        //    var grid = GridDataStore.Current.Grids.FirstOrDefault(m => m.Id == id);
        //    if (grid == null)
        //    {
        //        return NotFound();
        //    }
        //    GridDataStore.Current.Grids.Remove(grid);
        //    return NoContent();
        //}
    }
}
