using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Agenda.Models;
using Agenda.Repository;

namespace Agenda.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AmigosController : ControllerBase
	{
		private readonly IAmigosRepository _amigosRepository;

		public AmigosController(IAmigosRepository amigosRepository)
		{
			_amigosRepository = amigosRepository;
		}

		// GET api/values
		[HttpGet]
		public ActionResult<IEnumerable<Amigo>> Get()
		{

			var amigos = _amigosRepository.GetAmigos();
			return amigos.ToList();
		}

		// GET api/values/5
		[HttpGet("{amigoId}")]
		public ActionResult<Amigo> Get(Guid amigoId)
		{
			var newamigo = _amigosRepository.FindAmigoById(amigoId);
			return newamigo;
		}

		// POST api/values
		[HttpPost]
		public ActionResult<Amigo> Post(Amigo amigo)
		{
			var newamigo = _amigosRepository.CreateAmigo(amigo);
			return newamigo;
		}

		// PUT api/values/5
		[HttpPut("{amigoId}")]
		public Amigo Put(Guid amigoId, [FromBody] Amigo amigo)
		{
			amigo.AmigoId = amigoId;
			var newamigo = _amigosRepository.UpdateAmigo(amigo);
			return newamigo;
		}

		// DELETE api/values/5
		[HttpDelete("{amigoId}")]
		public void Delete(Guid amigoId)
		{
			_amigosRepository.DeleteAmigo(amigoId);
		}
	}
}