using System;
using Microsoft.AspNetCore.Mvc;
using PeopleWithPets.Domain.Service;
using PeopleWithPets.Domain.Repository;
using Microsoft.Extensions.Logging;

namespace PeopleWithPets.WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class PeopleWithPetsController : Controller
    {
        private readonly PeopleWithPetsRepository _repository;
        private readonly ILogger<PeopleWithPetsController> _logger;

        /// <summary>
        /// Constructor with dependency 
        /// This is inverting the dependency so that the StartUp class manages the instantiation(IOC).
        /// </summary>
        /// <param name="repository">The repository</param>
        /// <param name="logger">An ILogger to log to configured sink</param>
        public PeopleWithPetsController(PeopleWithPetsRepository repository, ILogger<PeopleWithPetsController> logger)
        {
            if (repository == null)
            {
                throw new ArgumentNullException(nameof(repository));
            }
            if (logger == null)
            {
                throw new ArgumentNullException(nameof(logger));
            }

            _repository = repository;
            _logger = logger;
        }

        /// <summary>
        /// Get all the cats ordered alphabetically by their name and grouped by its owners gender.
        /// </summary>
        /// <response code="200">Successful operation</response>
        /// <response code="500">Internal server error</response>
        [HttpGet]
        public ActionResult GetCatsGroupedByOwnersGender()
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _logger.LogInformation("Calling GetCatsGroupedByOwnersGender method");
                    var peopleWithPetsService = new PeopleWithPetsService(_repository);
                    return Ok(peopleWithPetsService.GetCatsGroupedByOwnersGender());
                }
                return BadRequest(new { Reason = "Error Occurred" });
            }
            catch (Exception)
            {
                _logger.LogError("Failed while executing GetCatsGroupedByOwnersGender");
                return BadRequest(new { Reason = "Error Occurred" });
            }
        }
    }
}