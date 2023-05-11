using Microsoft.AspNetCore.Mvc;
using person_crud.DataAccess;
using person_crud.DataAccess.Interfaces;
using persona_crud.Models;
using persona_crud.Models.Interfaces;

namespace persona_crud.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IPersonDA _personDA;

        public PersonController()
        {
            _personDA = new PersonDA();
        }

        [Route("{id}")]
        [HttpGet]
        public IActionResult Get(int id) {
            IResponseDTO response = new ResponseDTO()
            {
                Value = _personDA.Get(id),
                Ok = true
            };
            return Ok(response);
        }

        [Route("getall")]
        [HttpGet]
        public IActionResult GetAll()
        {
            IResponseDTO response = new ResponseDTO()
            {
                Value = _personDA.GetAll(),
                Ok = true
            };
            return Ok(response);
        }

        [HttpPost]
        public IActionResult Save(RequestDTO request) {
            IResponseDTO response = new ResponseDTO();

            try {
                _personDA.Save(Convert.ToString(request.Value));
                response.Value = "Successfully added";
                response.Ok = true;
                return Ok(response);
            }
            catch (Exception ex) {
                response.Value = "Error adding";
                response.Ok = false;
                return BadRequest(response);
            }
        }


        [Route("{id}")]
        [HttpPut]
        public IActionResult Update(int id, RequestDTO request) {
            IResponseDTO response = new ResponseDTO();

            try
            {
                _personDA.Update(Convert.ToString(request.Value), id);
                response.Value = "Successfully updated";
                response.Ok = true;
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.Value = "Error adding";
                response.Ok = false;
                return BadRequest(response);
            }
        }

        [Route("delete/{id}")]
        [HttpPut]
        public IActionResult Delete(int id)
        {
            IResponseDTO response = new ResponseDTO();

            try
            {
                _personDA.Delete(id);
                response.Value = "Successfully deleted";
                response.Ok = true;
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.Value = "Error adding";
                response.Ok = false;
                return BadRequest(response);
            }
        }
    }
}
