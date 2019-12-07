﻿using FoodDataCentral.Controllers;
using FoodDataCentral.Models;
using System.Threading.Tasks;

namespace FoodDataCentral
{
    public class FoodDataCentralAPI
    {
        private readonly IRequester requester;
        private readonly FoodController foodController;

        public FoodDataCentralAPI(string apiKey) : this(apiKey, new WebRequester()) { }

        public FoodDataCentralAPI(string apiKey, IRequester requester)
        {
            this.requester = requester;
            foodController = new FoodController(requester, apiKey);
        }

        public async Task<Food> GetFoodById(int id)
        {
            return await foodController.GetFoodById(id);
        }
    }
}