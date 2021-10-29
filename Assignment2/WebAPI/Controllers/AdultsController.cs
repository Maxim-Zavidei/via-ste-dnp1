using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Data;
using WebAPI.Models;

namespace WebAPI.Controllers {
    [Route("[controller]")]
    public class AdultsController : ControllerBase {
        
        private IData dataService;

        public AdultsController(IData dataService) {
            this.dataService = dataService;
        }

        [HttpGet]
        public async Task<ActionResult<IList<Adult>>> GetAdultsAsync([FromQuery] int? adultId, [FromQuery] string name, [FromQuery] int? age, [FromQuery] string sex) {
            try {
                IList<Adult> adults = await dataService.GetAdultsAsync(adultId, name, age, sex);
                return Ok(adults);
            }
            catch (Exception e) {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<ActionResult> DeleteTodo([FromRoute] int id) {
            try {
                await dataService.DeleteAdultAsync(id);
                return Ok();
            }
            catch (Exception e) {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<Adult>> AddTodo([FromBody] Adult adult) {
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }

            try {
                Adult added = await dataService.AddAdultAsync(adult);
                return Created($"/{added.Id}", added); // return newly added adult, to get the auto generated id
            }
            catch (Exception e) {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }

        [HttpPatch]
        [Route("{id:int}")]
        public async Task<ActionResult<Adult>> UpdateTodo([FromBody] Adult adult) {
            try {
                Adult updatedAdult = await dataService.UpdateAdultAsync(adult);
                if (adult == null) throw new Exception();
                return Ok(updatedAdult);
            }
            catch (Exception e) {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
    }
}