namespace BlockBoys.Tutorial.Blockchain.Infrastructure.WebApi.Controllers.v1
{
    using System;
    using BlockBoys.Tutorial.Blockchain.Core.Application.Messages;
    using BlockBoys.Tutorial.Blockchain.Core.Application.Services;
    using CompanyName.Notebook.NoteTaking.Infrastructure.WebApi.Validators;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;

    [Route("api/v1/[controller]")]
    public class HashController : Controller
    {
        private ILogger _logger;
        private readonly ICryptographer _cryptographer;

        public HashController(
            ICryptographer cryptographer,
            ILogger<HashController> logger) {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _cryptographer = cryptographer ?? throw new ArgumentNullException(nameof(cryptographer));
        }

        /// <summary>
        /// Generate a hash for the given message.
        /// </summary>
        /// <param name="hashReqeust">Hash generation request.</param>
        /// <response code="200">Hash generated.</response>
        // POST api/v1/notes

        [HttpPost, Route("")]
        [ValidateModel]
        [ProducesResponseType(typeof(string), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 400)]
        public IActionResult Post([FromBody]HashRequest hashRequest)
        {
            var hashResponse = _cryptographer.GenerateHash(hashRequest);
            return Ok(hashResponse);
        }
    }
}