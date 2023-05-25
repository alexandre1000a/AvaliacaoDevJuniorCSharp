using PetShopWebApp.Models;

namespace PetShopWebApp.Repositories.Interfaces
{
    public interface IUsuario
    {
        UsuarioModel GetOne(int id);
        UsuarioModel Create(UsuarioModel usuario);
        UsuarioModel Update(UsuarioModel usuario, int id);
        bool Delete(int id);
    }
}
