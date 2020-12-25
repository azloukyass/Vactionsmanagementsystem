using AdminPlatfform.Web.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdminPlatfform.Web.Service
{
    public class NotiService : INotiService
    {
        List<Notification> _notifications = new List<Notification>(); 
        public List<Notification> GetNotifications(int noToUserId, bool bIsGetOnlyUnread)
        {
            _notifications = new List<Notification>(); 
            using(JahreUrlaubDBEntities db = new JahreUrlaubDBEntities())
            {
                var noti = db.Database.SqlQuery<Notification>("SELCET * FROM VIEW_Notification WHERE ToUserId=" + noToUserId).ToList();
                if(noti!=null && noti.Count()>0)
                {
                    _notifications = noti;
                }
                return _notifications; 
            }
        }
    }
}