namespace BibliotecaApp.Frontend.Services
{
    public interface IEditorialService
    {
        Task<HttpResponseMessage> CreateEditorialAsync<T>(string url, T model);
        Task<T> GetAllEditorialsAsync<T>(string url);
        Task<T> GetEditorialByIdAsync<T>(string url,int id);
    }
}
