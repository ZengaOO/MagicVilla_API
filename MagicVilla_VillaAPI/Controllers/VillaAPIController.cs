﻿using MagicVilla_VillaAPI.Data;
//using MagicVilla_VillaAPI.Logging;
using MagicVilla_VillaAPI.Models;
using MagicVilla_VillaAPI.Models.Dto;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace MagicVilla_VillaAPI.Controllers
{
    //[Route("api/controller")]
    [Route("api/VillaAPI")]
    [ApiController]
    public class VillaAPIController : ControllerBase
    {
        
        //private readonly ApplicationDbContext _db;

         public VillaAPIController()//(ApplicationDbContext db)
        {
        }
        //{
         //   _db = db;   
         //}
 
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<VillaDTO>> GetVillas()
        {
            //_logger.LogInformation("Gettting all villas");
            //_logger.Log("Gettting all villas", "");
            return Ok(VillaStore.villaList);
            //return Ok(_db.Villas.ToList();
        }

        [HttpGet("{id:int}", Name = "GetVilla")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        //[ProducesResponseType(200)] //if you remove ActionResult [ProducesResponseType(200, Type =typeof(VillaDTO))]
        //[ProducesResponseType(404)]
        //[ProducesResponseType(400)] 
        public ActionResult<VillaDTO> GetVilla(int id)
        {
            if (id == 0)
            {
                //_logger.LogError("Get Villa with Id" + id);            
                //_logger.Log("Get Villa with Id" + id, "error");
                return BadRequest();

            }
            var villa = (VillaStore.villaList.FirstOrDefault(u => u.Id == id));
            //var villa = _db.Villas.FirstOrDefault(u => u.Id == id));

            if (villa == null)
            {
                return NotFound();
            }

            return Ok(villa);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<VillaDTO> CreateVilla([FromBody] VillaDTO villaDTO)
        {
            //if(!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}
            if (VillaStore.villaList.FirstOrDefault(u => u.Name.ToLower() == villaDTO.Name.ToLower()) != null)
            //if (_db.Villas.FirstOrDefault(u => u.Name.ToLower() == villaDTO.Name.ToLower()) != null)
            {
                ModelState.AddModelError("CustomError", "Villa already Exists!");
                return BadRequest(ModelState);
            }

            if (villaDTO == null)
            {
                return BadRequest(villaDTO);
            }
            if (villaDTO.Id > 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            //Villa model = new ()
            //{
            //    Amenity = VillaDTO.Amenity,
            //    Details = villaDTO.Details,
            //    Id = villaDTO.Id,
            //    ImageUrl = villaDTO.ImageUrl,
            //    Name = villaDTO.Name,
            //    Occupancy = villaDTO.Occupancy,
            //    Rate = villaDTO.Rate,
            //    Sqft = villaDTO.Sqft
            //};
            villaDTO.Id = VillaStore.villaList.OrderByDescending(u => u.Id).FirstOrDefault().Id + 1;//delete
            
            //db.Villas.Add(model);
            //_db.SaveChanges();
            VillaStore.villaList.Add(villaDTO);//delete



            return CreatedAtRoute("GetVilla", new { id = villaDTO.Id }, villaDTO);
        }


        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpDelete("{id:int}", Name = "DeleteVilla")]

        public IActionResult DeleteVilla(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var villa = VillaStore.villaList.FirstOrDefault(u => u.Id == id);
            //var villa = db.Villas.FirstOrDefault(u => u.Id == id);
            if (villa == null)
            {
                return NotFound();
            }
            VillaStore.villaList.Remove(villa);
            //db.Villas.Remove(villa);
            //_db.SaveChanges();
            return NoContent();
        }

        [HttpPut("{id:int}", Name = "UpdateVilla")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public IActionResult UpdateVilla(int id, [FromBody] VillaDTO villaDTO)
        {
            if (villaDTO == null || id != villaDTO.Id)
            {
                return BadRequest();
            }
            var villa = VillaStore.villaList.FirstOrDefault(u => u.Id == id);//no delete, comment
            villa.Name = villaDTO.Name;//
            villa.Sqft = villaDTO.Sqft;//
            villa.Occupancy = villaDTO.Occupancy;//

            //Villa model = new ()
            //{
            //    Amenity = VillaDTO.Amenity,
            //    Details = villaDTO.Details,
            //    Id = villaDTO.Id,
            //    ImageUrl = villaDTO.ImageUrl,
            //    Name = villaDTO.Name,
            //    Occupancy = villaDTO.Occupancy,
            //    Rate = villaDTO.Rate,
            //    Sqft = villaDTO.Sqft
            //};
            //_db.Villas.Update(model);
            //_db.SaveChanges();
            return NoContent();
        }

        [HttpPatch("{id:int}", Name = "UpdatePartialVilla")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public IActionResult UpdatePartialVilla(int id, JsonPatchDocument<VillaDTO> patchDTO)
        {
            if (patchDTO == null || id == 0)
            {
                return BadRequest();
            }
            var villa = VillaStore.villaList.FirstOrDefault(u => u.Id == id);
            //var villa = _db.Villas.FirstOrDefault(u => u.Id == id);
            //VillaDTO villaDTO = new()
            //{
            //    Amenity = Villa.Amenity,
            //    Details = villa.Details,
            //    Id = villaDTO.Id,
            //    ImageUrl = villa.ImageUrl,
            //    Name = villaDTO.Name,
            //    Occupancy = villa.Occupancy,
            //    Rate = villa.Rate,
            //    Sqft = villa.Sqft
            //};
            //_db.Villas.Update(model);
            //_db.SaveChanges();

            if (villa==null)
            {
                return BadRequest();    
            }
            patchDTO.ApplyTo(villa, ModelState);
            //patchDTO.ApplyTo(villaDTO, ModelState);
            //Villa model = new Villa()
            //{
            //    Amenity = VillaDTO.Amenity,
            //    Details = villaDTO.Details,
            //    Id = villaDTO.Id,
            //    ImageUrl = villaDTO.ImageUrl,
            //    Name = villaDTO.Name,
            //    Occupancy = villaDTO.Occupancy,
            //    Rate = villaDTO.Rate,
            //    Sqft = villaDTO.Sqft
            //};
            //_db.Villas.Update(model);
            //_db.SaveChanges();



            if (!ModelState.IsValid)
            { 
                return BadRequest();    
            }
            return NoContent();
        }
    }
}
