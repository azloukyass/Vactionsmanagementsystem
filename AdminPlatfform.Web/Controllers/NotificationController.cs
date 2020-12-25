using AdminPlatfform.Web.IService;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdminPlatfform.Web.Controllers
{
    public class NotificationController : Controller
    {
        // GET: Notification

        INotiService _notService = null;
        List<Notification> notifications = new List<Notification>(); 

        public NotificationController(INotiService notiService)
        {
            _notService = notiService;
        }
        public IActionResult AllNotifications()
        {
            return (IActionResult)View();
        }
        public JsonResult GetNotification(bool bIsGetOnlyUnread=false)
        {
            int nToUserId = 3;
            notifications = new List<Notification>();
            notifications = _notService.GetNotifications(nToUserId,bIsGetOnlyUnread);
            return Json(notifications); 

        }

    }
}