using ART.SC.Foundation.DependencyInjection;
using Sitecore.Data.Items;
using Sitecore.Mvc.Presentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ART.SC.Foundation.SitecoreExtensions.Extensions;
using Sitecore;
using ART.SC.Feature.Navigation.Models;

namespace ART.SC.Feature.Navigation.Repositories
{
    [Service(typeof(INavigationRepository), Lifetime = Lifetime.Transient)]
    public class NavigationRepository: INavigationRepository
    {
        public Item ContextItem => RenderingContext.Current?.ContextItem ?? Sitecore.Context.Item;

        public Item NavigationRoot { get; }
        public NavigationRepository()
        {
            this.NavigationRoot = this.GetNavigationRoot(this.ContextItem);
            if (this.NavigationRoot == null)
            {
                throw new InvalidOperationException($"Cannot determine navigation root from '{this.ContextItem.Paths.FullPath}'");
            }
        }

        public Item GetNavigationRoot(Item contextItem)
        {
            return contextItem.GetAncestorOrSelfOfTemplate(Templates.NavigationRoot.ID) ?? Context.Site.GetContextItem(Templates.NavigationRoot.ID);
        }
        public NavigationItems GetPrimaryMenu()
        {
            var navItems = this.GetChildNavigationItems(this.NavigationRoot, 0, 1);

            this.AddRootToPrimaryMenu(navItems);
            return navItems;
        }
        private void AddRootToPrimaryMenu(NavigationItems navItems)
        {
            if (!this.IncludeInNavigation(this.NavigationRoot))
            {
                return;
            }

            var navigationItem = this.CreateNavigationItem(this.NavigationRoot, 0, 0);
            //Root navigation item is only active when we are actually on the root item
            navigationItem.IsActive = this.ContextItem.ID == this.NavigationRoot.ID;
            navItems?.NavItems?.Insert(0, navigationItem);
        }

        private bool IncludeInNavigation(Item item, bool forceShowInMenu = false)
        {
            return item.HasContextLanguage() && item.IsDerived(Templates.Navigable.ID) && (forceShowInMenu || MainUtil.GetBool(item[Templates.Navigable.Fields.ShowInNavigation], false));
        }
        private NavigationItems GetChildNavigationItems(Item parentItem, int level, int maxLevel)
        {
            if (level > maxLevel || !parentItem.HasChildren)
            {
                return null;
            }
            var childItems = parentItem.Children.Where(item => this.IncludeInNavigation(item)).Select(i => this.CreateNavigationItem(i, level, maxLevel));
            return new NavigationItems
            {
                NavItems = childItems.ToList()
            };
        }
        private NavigationItem CreateNavigationItem(Item item, int level, int maxLevel = -1)
        {
            var targetItem = item.IsDerived(Templates.Link.ID) ? item.TargetItem(Templates.Link.Fields.Link) : item;
            return new NavigationItem
            {
                Item = item,
                Url = item.IsDerived(Templates.Link.ID) ? item.LinkFieldUrl(Templates.Link.Fields.Link) : item.Url(),
                Target = item.IsDerived(Templates.Link.ID) ? item.LinkFieldTarget(Templates.Link.Fields.Link) : "",
                IsActive = this.IsItemActive(targetItem ?? item),
                Children = this.GetChildNavigationItems(item, level + 1, maxLevel),
                ShowChildren = !item.IsDerived(Templates.Navigable.ID) || item.Fields[Templates.Navigable.Fields.ShowChildren].IsChecked()
            };
        }
        private bool IsItemActive(Item item)
        {
            return this.ContextItem.ID == item.ID || this.ContextItem.Axes.GetAncestors().Any(a => a.ID == item.ID);
        }
    }
}