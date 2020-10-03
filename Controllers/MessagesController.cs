using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace TwitterClone.Controllers
{
	[Route("api/messages")]
	[ApiController]
	public class MessagesController : ControllerBase
	{

		private readonly IDbService _dbService;

		public MessagesController(IDbService dbService)
		{
			_dbService = dbService;
		}

		// GET: api/<MessagesController>
		[HttpGet]
		public IActionResult GetAllMessages()
		{
			Console.WriteLine("GET REQUEST");
			return Ok(_dbService.GetMessages());
		}

		//// GET api/<MessagesController>/5
		[HttpGet("{id}")]
		public IActionResult GetMessageById(int id)
		{
			Console.WriteLine("GET REQUEST FOR: " + id);
			return Ok(_dbService.GetMessageById(id));
		}

		//// POST api/<MessagesController>
		//[HttpPost]
		//public void Post([FromBody] string value)
		//{
		//}

		// PUT api/<MessagesController>/5
		[HttpPut]
		public IActionResult AddMessage([FromBody] MessageDTO message)
		{
			Console.WriteLine("PUT REQUEST");
			Console.WriteLine("MSG: " + message.username + " said " + message.messageText);
			return Ok(_dbService.AddMessage(message));

		}

		//// DELETE api/<MessagesController>/5
		[HttpDelete("{id}")]
		public IActionResult Delete(int id)
		{
			Console.WriteLine("DELETE REQUEST FOR ID: " + id);
			_dbService.DeleteMessage(id);
			return Ok();
		}
	}
}
