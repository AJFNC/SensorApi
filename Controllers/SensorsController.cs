using SensorApi.Models;
using SensorApi.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace SensorApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class SensorController : ControllerBase
    {
        private readonly SensorService _sensorService;
        public SensorController(SensorService sensorService)
        {
            _sensorService = sensorService;
        }

        [HttpGet]
        public ActionResult<List<Sensor>> Get() => _sensorService.Get();

        [HttpGet("{id:length(24)}", Name = "GetSensor")]
        public ActionResult<Sensor> Get(long id)
        {
            var sensor = _sensorService.Get(id);

            if (sensor == null)
            {
                return NotFound();
            }
            return sensor;
        }

        [HttpPost]
        public ActionResult<Sensor> Create(Sensor sensor)
        {
            _sensorService.Create(sensor);
            return CreatedAtRoute("GetSensor", new { id = sensor.Id.ToString()}, sensor);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(long id, Sensor sensorIn)
        {
            var sensor = _sensorService.Get(id);

            if (sensor == null)
            {
                return NotFound();
            }
            _sensorService.Update(id, sensorIn);
            return NoContent();
        }

        [HttpDelete("{id:length(24)")]
        public IActionResult Delete(long id)
        {
            var sensor = _sensorService.Get(id);
            if (sensor == null)
            {
                return NotFound();
            }
            _sensorService.Remove(sensor.Id);
            return NoContent();
        }


    }
}