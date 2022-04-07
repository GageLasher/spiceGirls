using System;
using System.Collections.Generic;
using spiceGirls.Models;
using spiceGirls.Repositories;

namespace spiceGirls.Services
{
    public class RecipesService
    {
        private readonly RecipesRepository _recipeRepo;

        public RecipesService(RecipesRepository recipeRepo)
        {
            _recipeRepo = recipeRepo;
        }

        internal List<Recipe> GetAll()
        {
            return _recipeRepo.GetAll();

        }

        internal Recipe Create(Recipe recipeData)
        {
            return _recipeRepo.Create(recipeData);

        }
        internal string Remove(int id, Account user)
        {
            Recipe recipe = _recipeRepo.GetById(id);
            if (recipe.CreatorId != user.Id)
            {
                throw new Exception("you can't do that nice try.");
            }
            return _recipeRepo.Remove(id);
        }


    }
}