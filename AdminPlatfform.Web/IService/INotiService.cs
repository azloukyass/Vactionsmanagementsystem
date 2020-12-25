using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminPlatfform.Web.IService
{
    public interface INotiService
    {
        List<Notification> GetNotifications(int noToUserId, bool bIsGetOnlyUnread);
      
    }
}
