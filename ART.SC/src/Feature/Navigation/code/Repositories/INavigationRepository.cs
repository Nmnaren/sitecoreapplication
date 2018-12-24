using ART.SC.Feature.Navigation.Models;
using Sitecore.Data.Items;

namespace ART.SC.Feature.Navigation.Repositories
{
    public interface INavigationRepository
    {
        Item GetNavigationRoot(Item contextItem);
        NavigationItems GetPrimaryMenu();
    }
}
