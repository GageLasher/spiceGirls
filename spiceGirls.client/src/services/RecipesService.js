import { AppState } from "../AppState";
import { logger } from "../utils/Logger";
import { api } from "./AxiosService";

class RecipesService {

    async getAll() {
        const res = await api.get('api/recipes')
        AppState.recipes = res.data
    }
    async create(body) {
        const res = await api.post('api/recipes', body)
        logger.log(res.data)
        AppState.recipes = [...AppState.recipes, res.data]
    }


}



export const recipesService = new RecipesService();