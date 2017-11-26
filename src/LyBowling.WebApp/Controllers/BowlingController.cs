using LyBowling.Lib;
using LyBowling.WebApp.Models.ModelView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace LyBowling.WebApp.Controllers
{
    public class BowlingController : Controller
    {
        Game game;
        GameVM vm;
        Throw current;
        Random rm = new Random();
        // GET: Bowling
        public ActionResult Index()
        {
            return View(vm);
        }

        [HttpPost]
        public ActionResult Throw()
        {
            int x = rm.Next(0, 20);
            if (x > current.Before)
                x = current.Before;
            current = current.Play(x);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult ReSet(int? frameCount)
        {
            if (frameCount.HasValue && frameCount.Value > 0)
                current = game.ReSet(frameCount.Value);
            else
                current = game.ReSet();
            return RedirectToAction("Index");
        }
        protected override RedirectToRouteResult RedirectToAction(string actionName, string controllerName, RouteValueDictionary routeValues)
        {
            this.Session["Throw"] = current;
            return base.RedirectToAction(actionName, controllerName, routeValues);
        }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            game = this.Session["Game"] as Game;
            current = this.Session["Throw"] as Throw;
            if (game == null)
                game = new Game(10);
            vm = new GameVM();
            vm.Frames = game.GetFrames();
            vm.Current = current;
            vm.FrameCount = game.FrameCount;
            base.OnActionExecuting(filterContext);
        }
        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            this.Session["Game"] = game;
            this.Session["Throw"] = current;
            base.OnActionExecuted(filterContext);
        }
    }
}