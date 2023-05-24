using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PetShopWebApp.Models;
using PetShopWebApp.Repositories.Interfaces;

namespace PetShopWebApp.Controllers
{
    public class AnimalController : Controller
    {

        private readonly IAnimal _animalRepository;

        public AnimalController(IAnimal animalRepository)
        {
            _animalRepository = animalRepository;
        }
        // GET: AnimalController
        public ActionResult Index()
        {
            return View(_animalRepository.GetAll());
        }

        // GET: AnimalController/Details/5
        public ActionResult Detalhes(int id)
        {
            return View(_animalRepository.GetOne(id));
        }

        // GET: AnimalController/Create
        public ActionResult Criar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CriarAnimal(AnimalModel animal)
        {
            var animalCriado = _animalRepository.Create(animal);
            return Json(new { data = animalCriado, erro = false });
        }


        // GET: AnimalController/Edit/5
        public ActionResult Editar(int id)
        {
            return View(_animalRepository.GetOne(id));
        }

        [HttpPut]
        public IActionResult EditarAnimal(AnimalModel animal, int id)
        {
            var animalAtualizado = _animalRepository.Update(animal, id);
            return Json(new { animalAtualizado });

        }

        // GET: AnimalController/Delete/5
        public ActionResult Deletar(int id)
        {
            return View(_animalRepository.GetOne(id));
        }
        [HttpDelete]
        public IActionResult DeletarAnimal(int id)
        {
            var deletado = _animalRepository.Delete(id);
            return Json(new { deletado });
        }

    }
}
