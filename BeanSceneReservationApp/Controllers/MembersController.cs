using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BeanSceneReservationApp.Models;
using Microsoft.AspNetCore.Identity;
using System.Reflection.Metadata;


namespace BeanSceneReservationApp.Controllers
{
    public class MembersController : Controller
    {
        private readonly BeanSeanReservationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IUserStore<ApplicationUser> _userStore;
        private readonly IUserEmailStore<ApplicationUser> _emailStore;

        public MembersController(BeanSeanReservationDbContext context, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, IUserStore<ApplicationUser> userStore)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
            _userStore = userStore;
            _emailStore = GetEmailStore();
        }

        private IUserEmailStore<ApplicationUser> GetEmailStore()
        {
            if (!_userManager.SupportsUserEmail)
            {
                throw new NotSupportedException("The default UI requires a user store with email support.");
            }
            return (IUserEmailStore<ApplicationUser>)_userStore;
        }

        public async Task<IActionResult> Index()
        {
            // Get the user IDs of users in the "Member" role
         //   var memberUserIds = (await _userManager.GetUsersInRoleAsync("Member")).Select(u => u.Id).ToList();
           // var
            // Get all members from the database
            var allMembers = await _context.Members.ToListAsync();
           // allMembers.
            // Filter members based on user IDs
            //var members = allMembers.Where(m => memberUserIds.Contains(m.UserId)).ToList();

            return View(allMembers);
        }

        // GET: Members/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var member = await _context.Members.FirstOrDefaultAsync(m => m.MemberId == id);
            if (member == null)
            {
                return NotFound();
            }

            return View(member);
        }

        // GET: Members/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Members/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MemberId,FirstName,LastName,Email,PhoneNumber,Role,Password,RegistrationDate")] Member member)
        {
           
                if (!await _roleManager.RoleExistsAsync(member.Role))
                {
                    await _roleManager.CreateAsync(new IdentityRole(member.Role));
                }

                // Find the user by Id
               var user = await _userManager.FindByEmailAsync(member.Email);

                // Check if the user exists
                if (user == null)
                {
                    // If the user doesn't exist, create a new ApplicationUser object
                    user = new ApplicationUser
                    {
                        UserName = member.Email,
                        Email = member.Email,
                        FirstName = member.FirstName,
                        LastName = member.LastName,
                        PhoneNumber = member.PhoneNumber, 
                        RegistrationDate = DateTime.Now,
                    };

                // Create the user
                var createUserResult = await _userManager.CreateAsync(user, member.Password);

                    // Check if the user creation was successful
                    if (!createUserResult.Succeeded)
                    {
                        foreach (var error in createUserResult.Errors)
                        {
                            ModelState.AddModelError(string.Empty, error.Description);
                        }
                        return View(member); // Return the view with errors
                    }
                await _userManager.AddToRoleAsync(user, member.Role);
           

                // Add the user to the "Member" role
               

                // Assign the user Id to the member's UserId property
                member.UserId = user.Id;

                // Add the member to the context and save changes

                _context.Add(member);
                await _context.SaveChangesAsync();

                // Redirect to the Index action of the controller
                return RedirectToAction(nameof(Index));
            }

            // If ModelState is not valid, return the view with validation errors
            TempData["Error"] = "User already exist";
            return View(member);
        }


        // GET: Members/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }


            var member = await _context.Members.FindAsync(id);
            var x = member.Password;
            if (member == null)
            {
                return NotFound();
            }
            return View(member);
        }

        /*[HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MemberId,FirstName,LastName,Email,Phone,Password,RegistrationDate,Role")] Member member)
        {
            if (id != member.MemberId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    // Find the user by Id
                    var user = await _userManager.FindByIdAsync(member.UserId);
                    if (user != null)
                    {
                        user.FirstName = member.FirstName;
                        user.LastName = member.LastName;
                        user.Email = member.Email;
                        user.UserName = member.Email;
                        user.PhoneNumber = member.Phone.ToString();

                        // Update the user's role
                        await _userManager.RemoveFromRoleAsync(user, "Member"); 
                        await _userManager.AddToRoleAsync(user, member.Role); 

                        var updateResult = await _userManager.UpdateAsync(user);
                        if (!updateResult.Succeeded)
                        {
                            foreach (var error in updateResult.Errors)
                            {
                                ModelState.AddModelError(string.Empty, error.Description);
                            }
                            return View(member);
                        }

                        if (!string.IsNullOrEmpty(member.Password))
                        {
                            var token = await _userManager.GeneratePasswordResetTokenAsync(user);
                            var passwordResult = await _userManager.ResetPasswordAsync(user, token, member.Password);
                            if (!passwordResult.Succeeded)
                            {
                                foreach (var error in passwordResult.Errors)
                                {
                                    ModelState.AddModelError(string.Empty, error.Description);
                                }
                                return View(member);
                            }
                        }
                    }

                    // Update the member in the database
                    _context.Update(member);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MemberExists(member.MemberId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(member);
        }*/

        /*[HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MemberId,FirstName,LastName,Email,Phone,Password,RegistrationDate,Role")] Member member)
        {
            *//*if (id != member.MemberId)
            {
                return NotFound();
            }*/

        /*if (ModelState.IsValid)*/
        /* {*//*

             try
             {

                 var user = await _userManager.FindByEmailAsync(member.Email);
                 if (user != null)
                 {
                     user.FirstName = member.FirstName;
                     user.LastName = member.LastName;
                     user.Email = member.Email;
                     //user.UserName = member.Email;
                     user.PhoneNumber = member.Phone.ToString();



                     // Update the user's role
                     var currentRole = await _userManager.GetRolesAsync(user);
                     await _userManager.RemoveFromRolesAsync(user, currentRole); 
                     await _userManager.AddToRoleAsync(user, member.Role); 

                     var updateResult = await _userManager.UpdateAsync(user); 
                 member.UserId = user.Id;
                 if (!updateResult.Succeeded)
                     {

                         foreach (var error in updateResult.Errors)
                         {
                             ModelState.AddModelError(string.Empty, error.Description);
                         }
                         return View(member);
                     }

                     if (!string.IsNullOrEmpty(member.Password))
                     {
                         var token = await _userManager.GeneratePasswordResetTokenAsync(user);
                         var passwordResult = await _userManager.ResetPasswordAsync(user, token, member.Password);
                         if (!passwordResult.Succeeded)
                         {
                             foreach (var error in passwordResult.Errors)
                             {
                                 ModelState.AddModelError(string.Empty, error.Description);
                             }
                             return View(member);
                         }
                     }
                 }

             // Update the member in the database

                 _context.Update(member);
                 await _context.SaveChangesAsync();

                 return RedirectToAction(nameof(Index));
             }
             catch (DbUpdateConcurrencyException)
             {
                 if (!MemberExists(member.MemberId))
                 {
                     return NotFound();
                 }
                 else
                 {
                     throw;
                 }
             }
        *//* }*//*
         return View(member);
     }


*/

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MemberId,FirstName,LastName,Email,PhoneNumber,Password,RegistrationDate,Role,UserId")] Member member)
        {
            //if (id != member.MemberId)
            //{
            //    return NotFound();
            //}

            //if (ModelState.IsValid)
            //{
                try
                {
                    var user = await _userManager.FindByEmailAsync(member.Email);
                    if (user != null)
                    {
                        user.FirstName = member.FirstName;
                        user.LastName = member.LastName;
                        user.Email = member.Email;
                        user.UserName = member.Email;
                        user.PhoneNumber = member.PhoneNumber.ToString();

                        // Update the user's role
                        var currentRole = await _userManager.GetRolesAsync(user);
                        await _userManager.RemoveFromRolesAsync(user, currentRole); // Remove all current roles
                        await _userManager.AddToRoleAsync(user, member.Role); // Add the new role

                        var updateResult = await _userManager.UpdateAsync(user);
                        if (!updateResult.Succeeded)
                        {
                            foreach (var error in updateResult.Errors)
                            {
                                ModelState.AddModelError(string.Empty, error.Description);
                            }
                            return View(member);
                        }

                        if (!string.IsNullOrEmpty(member.Password))
                        {
                            var token = await _userManager.GeneratePasswordResetTokenAsync(user);
                            var passwordResult = await _userManager.ResetPasswordAsync(user, token, member.Password);
                            if (!passwordResult.Succeeded)
                            {
                                foreach (var error in passwordResult.Errors)
                                {
                                    ModelState.AddModelError(string.Empty, error.Description);
                                }
                                return View(member);
                            }
                        }
                    }

                // Update the member in the database
                var user1 = await _userManager.FindByEmailAsync(member.Email);
                member.UserId = user1.Id;
                _context.Update(member);
                    await _context.SaveChangesAsync();

                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MemberExists(member.MemberId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
           // }
            return View(member);
        }



        // GET: Members/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var member = await _context.Members.FirstOrDefaultAsync(m => m.MemberId == id);
            if (member == null)
            {
                return NotFound();
            }

            return View(member);
        }

        // POST: Members/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var member = await _context.Members.FindAsync(id);
            if (member != null)
            {
                _context.Members.Remove(member);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MemberExists(int id)
        {
            return _context.Members.Any(e => e.MemberId == id);
        }
    }
}
