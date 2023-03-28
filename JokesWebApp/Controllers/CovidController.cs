using JokesWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
namespace JokesWebApp.Controllers
{
    public class CovidController : Controller
{
    public IActionResult ScreeningForm()
    {
        return View();
    }

    [HttpPost]
    public IActionResult ScreeningForm(ScreeningFormModel model)
    {
        if (ModelState.IsValid)
        {
            TempData["SuccessMessage"] = "Please screenshot and show this at the front-desk";
            return RedirectToAction("ScreeningFormSuccess");
        }

        return View(model);
    }

    public IActionResult ScreeningFormSuccess()
    {
        var successMessage = TempData["SuccessMessage"] as string;
        ViewBag.SuccessMessage = successMessage;
        return View();
    }
}


}