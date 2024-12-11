namespace NearestTeachers.Controllers
{

    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using NearestTeachers.Services;
    using WebApplication1.Data;

    [Route("api/[controller]")]
    [ApiController]
    public class TeachersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        //public TeachersController(ApplicationDbContext context)
        //{
        //    _context = context;
        //}

        //[HttpGet("nearby")]
        //public async Task<IActionResult> GetNearbyTeachers([FromQuery] double lat, [FromQuery] double lng, [FromQuery] double radius)
        //{
        //    var teachers = await _context.Teachers
        //        .Where(t =>
        //            EF.Functions.Distance(
        //                EF.Functions.Point(t.Latitude, t.Longitude),
        //                EF.Functions.Point(lat, lng)
        //            ) <= radius
        //        ).ToListAsync();

        //    return Ok(teachers);
        //}

        //[HttpGet("nearby")]
        //public async Task<IActionResult> GetNearbyTeachers([FromQuery] double lat, [FromQuery] double lng, [FromQuery] double radius)
        //{
        //    var teachers = await _context.Teachers
        //        .FromSqlRaw(@"
        //    SELECT 
        //        Id, Name, Latitude, Longitude, Subject 
        //    FROM 
        //        Teachers
        //    WHERE 
        //        (6371 * acos(cos(radians(@lat)) 
        //        * cos(radians(Latitude)) 
        //        * cos(radians(Longitude) - radians(@lng)) 
        //        + sin(radians(@lat)) 
        //        * sin(radians(Latitude)))) <= @radius")
        //        .ToListAsync();

        //    return Ok(teachers);
        //}
        private readonly IPlaceService _placeService;

        public TeachersController(IPlaceService placeService)
        {
            _placeService = placeService;
        }

        [HttpGet("nearby")]
        public async Task<IActionResult> GetNearbyTeachers([FromQuery] double lat, [FromQuery] double lng, [FromQuery] double radius)
        {
            var places = await _placeService.GetNearbyPlacesAsync(lat, lng, radius);
            return Ok(places);
        }

    }


}
