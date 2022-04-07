using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using spiceGirls.Models;

namespace spiceGirls.Repositories
{
    public class RecipesRepository
    {
        private readonly IDbConnection _db;

        public RecipesRepository(IDbConnection db)
        {
            _db = db;
        }

        internal Recipe GetById(int id)
        {
            string sql = @"
            SELECT 
                r.*,
                a.* 
            FROM recipes r
            JOIN accounts a ON g.creatorId = a.id
            WHERE r.id = @id;
            ";
            return _db.Query<Recipe, Account, Recipe>(sql, (recipe, account) =>
            {
                // NOTE this is the populate creator
                recipe.Creator = account;
                return recipe;
            }, new { id }).FirstOrDefault();
        }

        internal string Remove(int id)
        {
            throw new NotImplementedException();
        }

        internal List<Recipe> GetAll()
        {
            string sql = @"
            SELECT
            r.*,
            a.*
            FROM recipes r
            JOIN accounts a WHERE a.id = r.creatorId;
            ";
            return _db.Query<Recipe, Account, Recipe>(sql, (recipe, account) =>
            {

                recipe.Creator = account;
                return recipe;
            }).ToList();
        }

        internal Recipe Create(Recipe recipeData)
        {
            string sql = @"
            INSERT INTO recipes
            (title, subTitle, category, creatorId, picture)
            VALUES
            (@Title, @SubTitle, @Category, @CreatorId, @Picture);
            SELECT LAST_INSERT_ID();
            ";
            int id = _db.ExecuteScalar<int>(sql, recipeData);
            recipeData.Id = id;
            return recipeData;
        }
    }
}