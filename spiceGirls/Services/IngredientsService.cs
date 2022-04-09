using System.Collections.Generic;
using spiceGirls.Models;
using spiceGirls.Repositories;

namespace spiceGirls.Services
{
    public class IngredientsService
    {
        private readonly IngredientsRepository _ingredientsRepo;
        private readonly RecipesRepository _recipesRepo;

        public IngredientsService(IngredientsRepository ingredientsRepo, RecipesRepository recipesRepo)
        {
            _ingredientsRepo = ingredientsRepo;
            _recipesRepo = recipesRepo;
        }

        internal Ingredient Create(Ingredient ingredientData, Account userInfo)
        {
            Recipe recipe = _recipesRepo.GetById(ingredientData.RecipeId);
            ingredientData.RecipeId = recipe.Id;
            if (recipe.CreatorId != userInfo.Id)
            {
                throw new System.Exception("You don't own this recipe");
            }
            return _ingredientsRepo.Create(ingredientData);
        }

        internal List<Ingredient> GetAll(int id)
        {
            return _ingredientsRepo.GetAll(id);
        }
    }
}