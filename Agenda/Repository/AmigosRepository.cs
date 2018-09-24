using Agenda.Models;
using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace Agenda.Repository
{
	public class AmigosRepository : IAmigosRepository
	{
		private readonly IConfiguration _config;

		public AmigosRepository(IConfiguration config)
		{
			_config = config;
		}

		internal IDbConnection Connection
		{
			get
			{
				return new SqlConnection(_config.GetConnectionString("MyConnectionString"));
			}
		}

		public Amigo CreateAmigo(Amigo amigo)
		{
			using (IDbConnection cnx = Connection)
			{
				string sql = @"DECLARE @InsertedRows AS TABLE (Id uniqueidentifier);

							INSERT INTO Amigos (Nombre,Apellido,Telefono,Ciudad,Departamento)
							OUTPUT Inserted.AmigoId INTO @InsertedRows
							VALUES (@Nombre,@Apellido,@Telefono,@Ciudad,@Departamento)

							SELECT a.AmigoId,a.Nombre,a.Apellido,a.Telefono,m.nombre as NombreCiudad,d.nombre as NombreDepartamento 
							FROM Amigos a, Municipios m, Departamentos d 
							WHERE a.Ciudad = m.MunicipioId and a.Departamento = d.DepartamentoId 
							and a.AmigoId in (SELECT Id FROM @InsertedRows)";

				cnx.Open();
				var parameters = new
				{
					amigo.Nombre,
					amigo.Apellido,
					amigo.Telefono,
					amigo.Ciudad,
					amigo.Departamento
				};
				return cnx.Query<Amigo>(sql, parameters).FirstOrDefault();
			}
		}

		public Amigo FindAmigoById(Guid amigoId)
		{
			using (IDbConnection cnx = Connection)
			{
				var sql = @"SELECT a.AmigoId,a.Nombre,a.Apellido,a.Telefono,m.nombre as NombreCiudad,d.nombre as NombreDepartamento 
					FROM Amigos a, Municipios m, Departamentos d 
					WHERE a.Ciudad = m.MunicipioId and a.Departamento = d.DepartamentoId
					AND a.AmigoId = @amigoId";
				cnx.Open();
				return cnx.Query<Amigo>(sql, new { amigoId }).FirstOrDefault();
			}
		}

		public IEnumerable<Amigo> GetAmigos()
		{
			var sql = @"SELECT a.AmigoId,a.Nombre,a.Apellido,a.Telefono,m.nombre as NombreCiudad,d.nombre as NombreDepartamento 
						FROM Amigos a, Municipios m, Departamentos d 
						WHERE a.Ciudad = m.MunicipioId and a.Departamento = d.DepartamentoId";
			using (IDbConnection cnx = Connection)
			{
				cnx.Open();
				return cnx.Query<Amigo>(sql);
			}
		}

		public Amigo UpdateAmigo(Amigo amigo)
		{
			string sql = @"UPDATE Amigos SET Nombre = @Nombre, Apellido = @Apellido, Telefono = @Telefono,
							Ciudad = @Ciudad, Departamento = @Departamento
							WHERE AmigoId = @amigoId
							
							SELECT a.AmigoId,a.Nombre,a.Apellido,a.Telefono,m.nombre as NombreCiudad,d.nombre as NombreDepartamento 
							FROM Amigos a, Municipios m, Departamentos d 
							WHERE a.Ciudad = m.MunicipioId and a.Departamento = d.DepartamentoId 
							and a.AmigoId = @amigoId";

			using (IDbConnection cnx = Connection)
			{
				cnx.Open();
				var parameters = new
				{
					amigo.AmigoId,
					amigo.Nombre,
					amigo.Apellido,
					amigo.Telefono,
					amigo.Ciudad,
					amigo.Departamento
				};
				return cnx.Query<Amigo>(sql, parameters).FirstOrDefault();
			}
		}

		public void DeleteAmigo(Guid amigoId)
		{
			var sql = @"DELETE FROM Amigos
						WHERE AmigoId = @amigoId";
			using (IDbConnection cnx = Connection)
			{
				cnx.Open();
				var affectedRows = cnx.Execute(sql, new { amigoId });
			}
		}

	}
}
