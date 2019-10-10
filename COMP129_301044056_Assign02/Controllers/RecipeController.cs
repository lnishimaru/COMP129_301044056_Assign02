using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using COMP229_301044056_Assign02.Models;
using COMP229_301044056_Assign02.Models.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace COMP229_301044056_Assign02.Controllers
{
    public class RecipeController : Controller
    {
        private IRecipeRepository repository;
        public int PageSize = 4;
        public RecipeController(IRecipeRepository repo)
        {
            repository = repo;
            System.Diagnostics.Debug.WriteLine("First step");
        }
        public ViewResult List(int recipePage = 1)
                => View(new RecipesListViewModel
                {
                    Recipes = repository.Recipes
                        .OrderBy(p => p.ID)
                        .Skip((recipePage - 1) * PageSize)
                        .Take(PageSize),
                    PagingInfo = new PagingInfo
                    {
                        CurrentPage = recipePage,
                        ItemsPerPage = PageSize,
                        TotalItems = repository.Recipes.Count()
                    }
                });

        public ViewResult DataPage()
        {
            return View();
        }
        public ViewResult DisplayPage()
        {
            return View();
        }
        public ViewResult InsertPage(Recipe recipe)
        {
            recipe.ID = 1001;
            recipe.Category = "Test";
            recipe.Ingredients = "Heavy cream, Unflavored gelatin, Milk , White Sugar, Vanilla extract";
            System.Diagnostics.Debug.WriteLine("Second Step");
            return View(recipe);
        }
        public ViewResult UserPage()
        {
            return View();
        }
        public RedirectToActionResult AddRecipe(Recipe recipe)
        {
            System.Diagnostics.Debug.WriteLine("1.Saving  recipe?");
            repository.AddItem(recipe);
            System.Diagnostics.Debug.WriteLine(recipe.ID);
            System.Diagnostics.Debug.WriteLine(recipe.Name);
            System.Diagnostics.Debug.WriteLine(recipe.Cuisine);
            return RedirectToAction("", repository);
        }
    }
}
