using ApiFlock.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiFlock.Service
{
    public interface IProvinciaService
    {
        Task<List<ProvinciaResponseDto>> GetLocation(string nombre);
    } 
}
