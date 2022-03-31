using ApiFlock.Configuration;
using ApiFlock.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ApiFlock.Service
{
    public class ProvinciaService : IProvinciaService
    {
        private readonly EndPointApiPublicaSetting _endPointSetting;
        private readonly ILogger<ProvinciaService> _logger;

        public ProvinciaService(ConfigurationContext configurationContext, ILogger<ProvinciaService> logger)
        {
            _endPointSetting = configurationContext.EndPointApiPublicaSetting.Value;
            _logger = logger;
        }

        public async Task<List<ProvinciaResponseDto>> GetLocation(string nombre)
        {
            var client = new HttpClient();
            ApiProvinciaResponseDto apiProvinciaResponse;

            string url = _endPointSetting.url + "?nombre=" + nombre;

            try
            {
                HttpResponseMessage response = await client.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    string result = await response.Content.ReadAsStringAsync();
                    apiProvinciaResponse = JsonConvert.DeserializeObject<ApiProvinciaResponseDto>(result);

                    var provinciaResponse = new List<ProvinciaResponseDto>();

                    foreach (var provincia in apiProvinciaResponse.Provincias)
                    {
                        provinciaResponse.Add(new ProvinciaResponseDto()
                        {
                            Nombre = provincia.Nombre,
                            Latitud = provincia.Centroide.Lat.ToString(),
                            Longitud = provincia.Centroide.Lon.ToString()
                        });
                    }

                    return provinciaResponse;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ocurrió un error al consultar la api");
                throw new Exception(ex.Message);
            }

        }
    }
}
