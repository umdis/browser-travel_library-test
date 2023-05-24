using BrowserTravel.Library.Entities.Dto.Library;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Reflection.Metadata;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace WebApp.Services
{
    public class BookService : IBookService
    {
        private readonly HttpClient _httpClient;
        private const string ServiceEndpoint = "Books/";

        public BookService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<ICollection<BookResponseDto>> GetAll()
        {
            return await _httpClient.GetFromJsonAsync<ICollection<BookResponseDto>>(ServiceEndpoint);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public async Task<ICollection<BookResponseDto>> GetAll(string parameter)
        {
            if(string.IsNullOrEmpty(parameter))
                return await _httpClient.GetFromJsonAsync<ICollection<BookResponseDto>>(ServiceEndpoint);

            return await _httpClient.GetFromJsonAsync<ICollection<BookResponseDto>>($"{ServiceEndpoint}Filter?parameter={parameter}");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<BookResponseDto> Get(int id)
        {
            return await _httpClient.GetFromJsonAsync<BookResponseDto>($"{ServiceEndpoint}{id}");
        }
    }
}
