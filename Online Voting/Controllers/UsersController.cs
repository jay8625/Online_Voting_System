using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DAL_Data_Access_Layer_.Model;
using Service_Layer.Repositories;
using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;

namespace Online_Voting.Controllers
{
    [Authorize]
    public class UsersController : Controller
    {
        private readonly IUser _UserRepo;
        private readonly ICandidate _CandidateRepo;
        public UsersController(IUser repo, ICandidate candidateRepo)
        {
            _UserRepo = repo;
            _CandidateRepo = candidateRepo;
        }

        // GET: Users
        [HttpGet]
        public IActionResult Index()
        {
            return View(_UserRepo.GetAll());
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
            ViewBag.Gender = new List<string> { "Male", "Female", "Other" };
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
            var candidate=_CandidateRepo.GetByID(id);
            _UserRepo.ChoiceCandidate(id);
            return View(candidate);
        }

        private bool UserExists(int id)
        {
            return _UserRepo.Any(id);
        }
    }
}
