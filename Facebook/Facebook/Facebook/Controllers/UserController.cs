using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Facebook.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        
        public ActionResult GetProfileView()
        {
            return View("Profile");
        }

        public ActionResult GetPostView()
        {
            return View("PostList");
        }

        public ActionResult GetFriendRequestsView()
        {
            return View("FriendRequests");
        }

        public ActionResult GetFriendsView()
        {
            return View("Friends");
        }

        public ActionResult GetEditView()
        {
            return View("Edit");
        }

        public ActionResult GetUserDetailsView()
        {
            return View("UserDetails");
        }

    }
}