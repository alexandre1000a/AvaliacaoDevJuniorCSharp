using PetShopWebApp.Enums;

namespace PetShopWebApp.Models
{
    public class AnimalModel
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public int Idade { get; set; }
        public TipoAnimal Tipo { get; set; }
        public string? Raca { get; set; }
        public int? UsuarioId { get; set; }
        public virtual UsuarioModel? Usuario { get; set; }
    }
}
