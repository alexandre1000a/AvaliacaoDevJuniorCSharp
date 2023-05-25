using PetShopWebApp.Models;

namespace PetShopWebApp.Repositories.Interfaces
{
    public interface IAnimal
    {
        List<AnimalModel> GetAll();
        AnimalModel GetOne(int id);
        AnimalModel Create(AnimalModel animal);
        AnimalModel Update(AnimalModel animal, int id);
        bool Delete(int id);
    }
}
