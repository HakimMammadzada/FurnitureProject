using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FurnitureProject.Infarstructure.Extensions
{
    public static class ControllerExtensions
    {
        public static RedirectToActionResult RedirectToSameAction(this ControllerBase controller)
        {
           string actionName = controller.ControllerContext.ActionDescriptor.ActionName;
           return controller.RedirectToAction(actionName);
        }
    }
}
