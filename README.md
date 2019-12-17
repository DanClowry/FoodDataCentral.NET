# FoodDataCentral.NET
A .NET Standard library for interacting with the US Department of Agriculture's FoodData Central API


## Installation
You can use FoodDataCentral.NET in your package by installing the NuGet package.

```
Install-Package FoodDataCentral
```

Note you will need a data.gov API key. You can obtain a key [here](https://api.data.gov/signup/).


## Usage

```c#
using FoodDataCentral;
using FoodDataCentral.Models;

...

// Create the API client
var api = new FoodDataCentralAPI("YOUR_API_KEY");

// Search for foods with the query "big mac"
SearchResult searchResults = await api.Search("big mac");

// Get details of a food
Food food = await api.GetFoodById(170720);
// Get protein of selected food
float proteinGrams = food.FoodNutrients[NutrientType.Protein].Amount;
```


## Licence
[MIT](LICENSE)
