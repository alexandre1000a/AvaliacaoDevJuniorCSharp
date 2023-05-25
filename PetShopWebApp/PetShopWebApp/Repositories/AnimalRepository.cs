using Newtonsoft.Json;
using PetShopWebApp.Models;
using PetShopWebApp.Repositories.Interfaces;
using System.Text;

namespace PetShopWebApp.Repositories
{
    public class AnimalRepository : IAnimal
    {
        private readonly string urlApi = "https://localhost:7107/api/";

        public List<AnimalModel> GetAll()
        {
            var animais = new List<AnimalModel>();
            try
            {
                using (var client = new HttpClient())
                {
                    var response = client.GetAsync(urlApi + "Animal");
                    response.Wait();
                    if (response.Result.IsSuccessStatusCode)
                    {
                        var retorno = response.Result.Content.ReadAsStringAsync();
                        animais = JsonConvert.DeserializeObject<AnimalModel[]>(retorno.Result).ToList();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }

            return animais;
        }

        public AnimalModel GetOne(int id)
        {
            var animalBuscado = new AnimalModel();
            try
            {
                using (var client = new HttpClient())
                {
                    var response = client.GetAsync(urlApi + "Animal/" + id);
                    response.Wait();
                    if (response.Result.IsSuccessStatusCode)
                    {
                        var retorno = response.Result.Content.ReadAsStringAsync();
                        animalBuscado = JsonConvert.DeserializeObject<AnimalModel>(retorno.Result);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }

            return animalBuscado;

        }
        public AnimalModel Create(AnimalModel animal)
        {
            var animalCriado = new AnimalModel();

            try
            {
                using (var client = new HttpClient())
                {
                    string jsonObject = JsonConvert.SerializeObject(animal);
                    var content = new StringContent(jsonObject, Encoding.UTF8, "application/json");
                    var response = client.PostAsync(urlApi + "Animal", content);
                    response.Wait();
                    if (response.Result.IsSuccessStatusCode)
                    {
                        var retorno = response.Result.Content.ReadAsStringAsync();
                        animalCriado = JsonConvert.DeserializeObject<AnimalModel>(retorno.Result);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }

            return animalCriado;
        }
        public AnimalModel Update(AnimalModel animal, int id)
        {
            var animalAtualizado = new AnimalModel();

            try
            {
                using (var client = new HttpClient())
                {
                    string jsonObject = JsonConvert.SerializeObject(animal);
                    var content = new StringContent(jsonObject, Encoding.UTF8, "application/json");
                    var response = client.PutAsync(urlApi + "Animal/" + id, content);
                    response.Wait();
                    if (response.Result.IsSuccessStatusCode)
                    {
                        var retorno = response.Result.Content.ReadAsStringAsync();
                        animalAtualizado = JsonConvert.DeserializeObject<AnimalModel>(retorno.Result);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }

            return animalAtualizado;
        }
        public bool Delete(int id)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    var response = client.DeleteAsync(urlApi + "Animal/" + id);
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
