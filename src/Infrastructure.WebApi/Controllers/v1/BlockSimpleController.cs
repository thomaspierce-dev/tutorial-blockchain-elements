namespace BlockBoys.Tutorial.Blockchain.Infrastructure.WebApi.Controllers.v1
{
    using System;
    using BlockBoys.Tutorial.Blockchain.Core.Application.Messages;
    using BlockBoys.Tutorial.Blockchain.Core.Application.Services;
    using CompanyName.Notebook.NoteTaking.Infrastructure.WebApi.Validators;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;

    [Route("api/v1/[controller]")]
    public class BlockSimpleController : Controller
    {
        private ILogger _logger;
        private readonly IBlockStacker _blockStacker;

        public BlockSimpleController(
            IBlockStacker blockStacker,
            ILogger<BlockSimpleController> logger) {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _blockStacker = blockStacker ?? throw new ArgumentNullException(nameof(blockStacker));
        }

        /// <summary>
        /// Create a hashed simpleBlock.
        /// </summary>
        /// <param name="simpleBlockRequest">Hash generation request.</param>
        /// <response code="200">SimpleBlock created and hashed.</response>
        // POST api/v1/simpleblock

        [HttpPost, Route("")]
        [ValidateModel]
        [ProducesResponseType(typeof(BlockSimpleResponse), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 400)]
        public IActionResult Post([FromBody]BlockSimpleRequest simpleBlockRequest)
        {
            var simpleBlockResponse = _blockStacker.CreateSimpleBlock(simpleBlockRequest);
            return Ok(simpleBlockResponse);
        }

        /// <summary>
        /// Create a hashed simpleBlock.
        /// </summary>
        /// <param name="simpleBlockRequest">Hash generation request.</param>
        /// <response code="200">SimpleBlock created and hashed.</response>
        // POST api/v1/simpleblock

        [HttpPost, Route("mine")]
        [ValidateModel]
        [ProducesResponseType(typeof(BlockSimpleResponse), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 400)]
        public IActionResult MineBlockSimple([FromBody]BlockSimpleRequest simpleBlockRequest)
        {
            var simpleBlockResponse = _blockStacker.MineSimpleBlock(simpleBlockRequest);
            return Ok(simpleBlockResponse);
        }
    }
}