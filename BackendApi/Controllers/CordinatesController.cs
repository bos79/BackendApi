using AutoMapper;
using BackendApi.Entities;
using BackendApi.Models;
using BackendApi.Services;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace BackendApi.Controllers
{
    [Route("api/grids/{gridId}/cordinates")]
    [ApiController]
    public class CordinatesController : ControllerBase
    {
        private readonly IGridInfoRepository gridInfoRepository;
        private readonly IMapper mapper;

        public CordinatesController(IGridInfoRepository gridInfoRepository, IMapper mapper) 
        {
            this.gridInfoRepository = gridInfoRepository ?? throw new ArgumentNullException(nameof(gridInfoRepository));
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        [HttpGet]
        public async Task< ActionResult<IEnumerable<Cordinates>>> GetCordinates(int gridId)
        {
            var cordinatesForGrid = await gridInfoRepository.GetCordinatesForGridAsync(gridId);
           return Ok(mapper.Map<IEnumerable<CordinatesDto>>(cordinatesForGrid));
        }
        [HttpPost]
        public async Task<ActionResult<CordinatesDto>> CreateCordinates(
           int gridId,
           string status,
           int row,
           int col)
        {
            if (!await gridInfoRepository.GridExistsAsync(gridId))
            {
                return NotFound();
            }
            if(await gridInfoRepository.CordinateExistsAsync(row, col, status))
            {
              var newCordId =  gridInfoRepository.GetCordinatIdAsync(row, col, gridId);
                 var CordinatsEntity = await gridInfoRepository.GetCordinateForGridAsync(gridId, newCordId);
                if (CordinatsEntity == null)
                {
                    return NotFound();
                }
                CordinatsEntity.Status = status;
                CordinatsEntity.Col = CordinatsEntity.Col;
                CordinatsEntity.Row = CordinatsEntity.Row;


                await gridInfoRepository.SaveChangesAsync();
            } 
            else { 
                var cordinates = new CordinatesForCreationDto
                {
                        Status = status,
                        Row = row,
                        Col = col
                 };

                var finalCordinats = mapper.Map<Entities.Cordinates>(cordinates);

                await gridInfoRepository.AddCordinatsForGridAsync(
                    gridId, finalCordinats);

                await gridInfoRepository.SaveChangesAsync();
                var createdCordinatsToReturn = 
                mapper.Map<Models.CordinatesDto>(finalCordinats);
             return Ok(createdCordinatsToReturn);
             }
            return Ok();
        }

        [HttpPut("{cordinatsId}")]
        public async Task<ActionResult> UpdateCordinats(int gridId, int cordinatsId, string status,
            CordinatesForUpdateDto cordinats)
        {
            if (!await gridInfoRepository.GridExistsAsync(gridId))
            {
                return NotFound();
            }

            var CordinatsEntity = await gridInfoRepository.GetCordinateForGridAsync(gridId, cordinatsId);
            if (CordinatsEntity == null)
            {
                return NotFound();
            }
            CordinatsEntity.Status = status;
            CordinatsEntity.Col = CordinatsEntity.Col;
            CordinatsEntity.Row = CordinatsEntity.Row;

            //mapper.Map(cordinats, CordinatsEntity);

            await gridInfoRepository.SaveChangesAsync();

            return NoContent();
        }
    }
}
