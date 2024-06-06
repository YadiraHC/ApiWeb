using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Dapper;
using System.Data;
using WedApi.Context;
using WedApi.Services.IServices;
using System.Security.Cryptography.X509Certificates;

namespace WebApi.Service.Services
{
    public class AutorServices : IAutorServices
    {
        private readonly AplicationDbContext _context;

        public AutorServices(AplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Response<List<Autor>>> GetAutores()
        {
            try
            {
                List<Autor> response = new List<Autor>();
                var result = await _context.Database.GetDbConnection().QueryAsync<Autor>("spGetAutores", new { }, commandType: CommandType.StoredProcedure);
                response = result.ToList();

                return new Response<List<Autor>>(response);
            }
            catch (Exception ex)
            {
                //return new Response<List<Autor>>();
                throw new Exception("Error ListaAutor" + ex.Message);
            }
        }

        public async Task<Response<Autor>> Crear(Autor i)//Pegvar en interface sin asy
        {
            try
            {
                Autor autor = new Autor();
                var response = await _context.Database.GetDbConnection().QueryAsync<Autor>("spCrearAutor", new {i.Nombre, i.Nacionalidad}, commandType: CommandType.StoredProcedure);
                foreach (var item in response)
                {
                    autor.Nombre = item.Nombre;
                    autor.Nacionalidad = item.Nacionalidad;
                }
                return new Response<Autor>(autor);
            }
            catch(Exception ex) 
            {
                throw new Exception("Error CrearAutor: " + ex.Message);
            }
        }
    }
}