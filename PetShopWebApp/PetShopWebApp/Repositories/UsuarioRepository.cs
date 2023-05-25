using Newtonsoft.Json;
using PetShopWebApp.Models;
using PetShopWebApp.Repositories.Interfaces;
using System.Text;

namespace PetShopWebApp.Repositories
{
    public class UsuarioRepository : IUsuario
    {


        private readonly string urlApi = "https://localhost:7107/api/";

        public UsuarioModel GetOne(int id)
        {
            var usuarioBuscado = new UsuarioModel();
            try
            {
                using (var client = new HttpClient())
                {
                    var response = client.GetAsync(urlApi + "Usuario/" + id);
                    response.Wait();
                    if (response.Result.IsSuccessStatusCode)
                    {
                        var retorno = response.Result.Content.ReadAsStringAsync();
                        usuarioBuscado = JsonConvert.DeserializeObject<UsuarioModel>(retorno.Result);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }

            return usuarioBuscado;

        }

        public UsuarioModel Create(UsuarioModel usuario)
        {
            var usuarioCriado = new UsuarioModel();

            try
            {
                using (var client = new HttpClient())
                {
                    string jsonObject = JsonConvert.SerializeObject(usuario);
                    var content = new StringContent(jsonObject, Encoding.UTF8, "application/json");
                    var response = client.PostAsync(urlApi + "Usuario", content);
                    response.Wait();
                    if (response.Result.IsSuccessStatusCode)
                    {
                        var retorno = response.Result.Content.ReadAsStringAsync();
                        usuarioCriado = JsonConvert.DeserializeObject<UsuarioModel>(retorno.Result);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }

            return usuarioCriado;
        }


        public UsuarioModel Update(UsuarioModel usuario, int id)
        {
            var usuarioAtualizado = new UsuarioModel();

            try
            {
                using (var client = new HttpClient())
                {
                    string jsonObject = JsonConvert.SerializeObject(usuario);
                    var content = new StringContent(jsonObject, Encoding.UTF8, "application/json");
                    var response = client.PutAsync(urlApi + "Usuario/" + id, content);
                    response.Wait();
                    if (response.Result.IsSuccessStatusCode)
                    {
                        var retorno = response.Result.Content.ReadAsStringAsync();
                        usuarioAtualizado = JsonConvert.DeserializeObject<UsuarioModel>(retorno.Result);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }

            return usuarioAtualizado;
        }
        public bool Delete(int id)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    var response = client.DeleteAsync(urlApi + "Usuario/" + id);
                    response.Wait();
                    if (response.Result.IsSuccessStatusCode)
                    {
                        var retorno = response.Result.Content.ReadAsStringAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }

            return true;
        }
    }
}
