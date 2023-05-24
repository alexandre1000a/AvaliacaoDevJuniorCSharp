using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PetShopWebApp.Models;
using PetShopWebApp.Repositories.Interfaces;

namespace PetShopWebApp.Controllers
{
    public class UsuarioController : Controller
    {

        private readonly IUsuario _usuarioRepository;

        public UsuarioController(IUsuario usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }
        [HttpGet]
        public IActionResult PegarUsuario(int id)
        {
            var usuario = _usuarioRepository.GetOne(id);
            return Json(new { data = usuario, erro = false });
        }

        [HttpPost]
        public IActionResult CriarUsuario(UsuarioModel usuario)
        {
            var usuarioCriado = _usuarioRepository.Create(usuario);
            return Json(new { data = usuarioCriado, erro = false });
        }


        [HttpPut]
        public IActionResult EditarUsuario(UsuarioModel usuario, int id)
        {
            var usuarioAtualizado = _usuarioRepository.Update(usuario, id);
            return Json(new { data = usuarioAtualizado });

        }

        [HttpDelete]
        public IActionResult DeletarUsuario(int id)
        {
            var deletado = _usuarioRepository.Delete(id);
            return Json(new { deletado });
        }
    }
}
