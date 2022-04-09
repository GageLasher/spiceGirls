using spiceGirls.Models;
using spiceGirls.Repositories;

namespace spiceGirls.Services
{
    public class StepsService
    {
        private readonly StepsRepository _stepsRepo;
        private readonly RecipesRepository _recipesRepo;

        public StepsService(StepsRepository stepsRepo, RecipesRepository recipesRepo)
        {
            _stepsRepo = stepsRepo;
            _recipesRepo = recipesRepo;
        }

        internal Step Create(Step stepData)
        {
            return _stepsRepo.Create(stepData);
        }

        internal Step Update(Step stepUpdate, Account userInfo)
        {
            Recipe recipe = _recipesRepo.GetById(stepUpdate.RecipeId);
            stepUpdate.RecipeId = recipe.Id;
            if (recipe.CreatorId != userInfo.Id)
            {
                throw new System.Exception("This isn't your ingredient");
            }
            Step original = _stepsRepo.GetById(stepUpdate.Id);
            original.Body = stepUpdate.Body ?? original.Body;
            original.StepOrder = stepUpdate.StepOrder;
            if (original != null)
            {

                _stepsRepo.Update(original);
            }
            return original;
        }
    }
}