using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DAL_Data_Access_Layer_.Model;
using Service_Layer.Repositories;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Linq;
using Online_Voting.Areas.Identity.Pages.Account;
using Online_Voting_DAL.Data;
using Online_Voting.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;

namespace Online_Voting.Controllers
{
    [Authorize]
    public class UsersController : Controller
    {
        private readonly IUser _UserRepo;
        private readonly ICandidate _CandidateRepo;
        private readonly SignInManager<Online_VotingUser> _signinManager;
        public UsersController(IUser repo, ICandidate candidateRepo, Online_VotingContext identityContext, UserManager<Online_VotingUser> userManager, SignInManager<Online_VotingUser> signinManager)
        {
            _UserRepo = repo;
            _CandidateRepo = candidateRepo;
            _signinManager = signinManager;
        }

        // GET: Users
        [HttpGet]
        public IActionResult Index(string search)
        {
            var data = _UserRepo.vwUsers().ToList();
            if (search != null)
            {
                string searchLower = search.ToLower();
                data = data.Where(x => x.FirstName.ToLower().Contains(searchLower) || x.LastName.ToLower().Contains(searchLower)).ToList();
                return View(data);
            }
            return View(data);
        }

        // GET: Users/Details/5
        [HttpGet]
        public IActionResult Details(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = _UserRepo.GetByID(id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // GET: Users/Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("UserId,FirstName,LastName,Age,Email,Gender,PhoneNumber,GetDateTime,AddressLine1,AddressLine2,City,State,Country,PostalPincode")] User user)
        {
            if (ModelState.IsValid)
            {
                _UserRepo.Add(user);
                TempData["userId"] = user.UserId;
                return RedirectToAction("ViewCandidate");
            }
            return View(user);
        }

        // GET: Users/Edit/5
        public IActionResult Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = _UserRepo.GetByID(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("UserId,FirstName,LastName,Age,Email,Gender,PhoneNumber,GetDateTime,AddressLine1,AddressLine2,City,State,Country,PostalPincode")] User user)
        {
            if (id != user.UserId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _UserRepo.Update(user);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserExists(user.UserId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(user);
        }

        // GET: Users/Delete/5
        [HttpGet]
        public IActionResult Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = _UserRepo.GetByID(id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var user = _UserRepo.GetByID(id);
            _UserRepo.Remove(id);
            return RedirectToAction(nameof(Index));
        }

        //ChoiceCandidate
        [HttpGet]
        [Route("ViewCandidate")]
        public IActionResult ViewCandidate()
        {
            return View(_CandidateRepo.GetAll());
        }

        [HttpGet]
        [Route("ChoiceCandidate")]
        public IActionResult ChoiceCandidate(int id)
        {
            string email = TempData["email"].ToString();
            int userId = Convert.ToInt32(TempData["userId"]);
            User user = _UserRepo.GetByID(userId);
            try
            {
                if (email == user.Email)
                {
                    user.ChoiceCandidateId = id;
                    _UserRepo.Update(user);
                    return View();
                }
                else
                    _UserRepo.Remove(userId);
                    return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {

                return RedirectToAction("Index", "Home");
            }
        }

        [HttpGet]
        [Route("SortFirstName")]
        public IActionResult SortFirstName()
        {
            return View("Index", _UserRepo.SortFirstName());
        }

        [HttpGet]
        [Route("SortLastName")]
        public IActionResult SortLastName()
        {
            return View("Index", _UserRepo.SortLastName());
        }

        [HttpGet]
        [Route("SortbyVote")]
        public IActionResult SortbyVote()
        {
            return View("Index", _UserRepo.SortVote());
        }

        private bool UserExists(int id)
        {
            return _UserRepo.Any(id);
        }
    }
}
