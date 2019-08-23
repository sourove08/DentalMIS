using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DENTALMIS.Web.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace DENTALMIS.Web.Controllers
{
    [Authorize(Roles = "Admin")]
    public class RoleController : BaseController
    {
         readonly ApplicationDbContext _context;


        public RoleController()
        {
            _context=new ApplicationDbContext();
        }
        /// <summary>
        /// Get All Roles
        /// </summary>
        /// <returns></returns>
        public ActionResult Index(RoleViewModel model)
        {

            model.IdentityRoles = _context.Roles.ToList();
            return View(model);
        }
        /// <summary>
        /// Create a New Role
        /// </summary>
        /// <param name="role"></param>
        /// <returns></returns>
        [HttpPost]

        public ActionResult Save(IdentityRole role)
        {
            if (String.IsNullOrEmpty(role.Id))
            {
                role.Id = Guid.NewGuid().ToString();
                _context.Roles.Add(role);
            }
            else
            {
                IdentityRole roleObj = _context.Roles.Find(role.Id);

                roleObj.Name = role.Name;
                _context.Entry(roleObj).State=EntityState.Modified;
            }

            _context.SaveChanges();

            return Reload();
        }

        public ActionResult Edit(RoleViewModel model)
        {
            if (!String.IsNullOrEmpty(model.Id))
            {
                IdentityRole role = _context.Roles.Find(model.Id);
                model.Id = role.Id;
                model.Name = role.Name;
            }
            return View(model);
        }
	}
}