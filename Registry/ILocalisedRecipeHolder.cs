using KitchenData;
using System.Collections.Generic;

namespace GrilledCheese.Registry
{
    public interface ILocalisedRecipeHolder
    {
        IDictionary<Locale, string> LocalisedRecipe { get; }

    }
}
