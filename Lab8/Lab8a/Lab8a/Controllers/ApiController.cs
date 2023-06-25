using Lab8a.Model;
using Lab8a.Repository;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using ControllerBase = Microsoft.AspNetCore.Mvc.ControllerBase;

namespace Lab8a.Controllers
{
    [ApiController]
    [Route("api/phones")]
    public class ApiController : ControllerBase
    { 
        private readonly ILogger<ApiController> _logger;
        private readonly GenericRepository<Phone> _phoneRepository;

        public ApiController(ILogger<ApiController> logger, GenericRepository< Phone> genericRepository)
        {
            _logger = logger;
            _phoneRepository = genericRepository;
        }

        [HttpGet]
        public IEnumerable<Phone> GetAll()
        {
            return _phoneRepository.GetAll();
        }

        [HttpGet("{id}")]
        public ActionResult<Phone> Get(int id)
        {
            var phone = _phoneRepository.GetById(id);
            if (phone == null)
            {
                return NotFound();
            }
            return phone;
        }

        [HttpPost]
        public ActionResult<Phone> Post(Phone phone)
        {
            _phoneRepository.Add(phone);
            _phoneRepository.SaveChanges();
            return phone;
        }

        [HttpPut]
        public ActionResult<Phone> Update(int id, Phone phone)
        {
            try { 
                _phoneRepository.Update(phone);
                return phone;
            }
            catch (Exception ex)
            {
                Response.StatusCode = 404;
                StringValues stringValues = new StringValues(ex.Message);
                Response.Headers.Add(new KeyValuePair<string, StringValues>("ErrorMessage", stringValues));
                return NotFound();
            }
        }

        [HttpDelete("{id:int}")]
        public ActionResult<Phone> Remove(int id)
        {
            Phone phone = _phoneRepository.GetById(id);
            try
            {
                _phoneRepository.Remove(phone);
                _phoneRepository.SaveChanges();
                return phone;
            }
            catch (Exception ex)
            {
                Response.StatusCode = 404;
                StringValues stringValues = new StringValues(ex.Message);
                Response.Headers.Add(new KeyValuePair<string, StringValues>("ErrorMessage", stringValues));
                return NotFound();
            }
        }
    }
}
