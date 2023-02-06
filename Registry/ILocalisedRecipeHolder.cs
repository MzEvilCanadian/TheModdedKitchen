using KitchenData;
using System.Collections.Generic;

namespace ModdedKitchen.Registry
{
    public interface ILocalisedRecipeHolder
    {
        IDictionary<Locale, string> LocalisedRecipe { get; }

    }
}
