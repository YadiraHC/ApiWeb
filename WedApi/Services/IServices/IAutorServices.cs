using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WedApi.Services.IServices
{
    public interface IAutorServices
    {
        public Task<Response<List<Autor>>> GetAutores();
        public Task<Response<Autor>> Crear(Autor i);//ahora en controllers
    }
}
