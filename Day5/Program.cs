using Day5;

var ingredientInfo = IngredientInfoReader.Read("Input.txt");
Console.WriteLine(ingredientInfo.CountFreshIngredients());

var nonOverlapping = ingredientInfo.IdRanges.GetNonOverlapping();
Console.Write(nonOverlapping.Count());