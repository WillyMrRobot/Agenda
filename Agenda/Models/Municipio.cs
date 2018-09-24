using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Agenda.Models
{
	public class Municipio
	{
		public int MunicipioId { get; set; }
		public string MunicipioNombre { get; set; }
		public int DepartamentoId { get; set; }
	}
}
