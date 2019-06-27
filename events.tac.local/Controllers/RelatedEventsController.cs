using events.tac.local.Models;
using Sitecore.Data.Fields;
using Sitecore.Links;
using Sitecore.Mvc.Presentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace events.tac.local.Controllers
{
    public class RelatedEventsController : Controller
    {
        // GET: RelatedEvents
        public ActionResult Index()
        {
            var item = RenderingContext.Current.Rendering.Item;
            if (item == null) return new EmptyResult();

            MultilistField relatedEvents = item.Fields["{43B3B1EB-375A-408B-BFEA-2E2E2B5E4688}"];
            if (relatedEvents == null) return new EmptyResult();

            var events = relatedEvents.GetItems()
                .Select(i => new NavigationItem()
                {
                    Title = i.DisplayName,
                    URL = LinkManager.GetItemUrl(i)

                });
            return View(events);
        }
    }
}