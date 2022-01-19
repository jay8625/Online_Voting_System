using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DAL_Data_Access_Layer_.Model;
using Service_Layer.Repositories;
using Microsoft.AspNetCore.Authorization;

namespace Online_Voting.Controllers
{
    //Authorize validation 
    //[Authorize(Roles = "Admin")]
    public class AdminsController : Controller
    {
        //declaring Repositories to perform actions
        private readonly IAdmin _AdminRepo;
        private readonly ICandidate _CandidateRepo;
        public AdminsController(IAdmin repo, ICandidate candidateRepo)
        {
            _AdminRepo = repo;
            _CandidateRepo = candidateRepo;
        }

        //partial view of AdminOptions
        [HttpGet]
        [AllowAnonymous]
        public PartialViewResult AdminOptions()
        {
            return PartialView();
        }

        //get voting results
        [HttpGet]
        public IActionResult VotingResult()
        {
            return View(_CandidateRepo.SortByVote());
        }

        // GET: Admins
        [HttpGet]
        public IActionResult Index()
        {
            return View(_AdminRepo.GetAll());
        }

        // GET: Admins/Details/5
        [HttpGet]
        public IActionResult Details(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var admin = _AdminRepo.GetByID(id);
            if (admin == null)
            {
                return NotFound();
            }

            return View(admin);
        }

        // GET: Admins/Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admins/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,FirstName,LastName,Age,Email,Gender,PhoneNumber")] Admin admin)
        {
            if (ModelState.IsValid)
            {
                _AdminRepo.Add(admin);
                return RedirectToAction(nameof(Index));
            }
            return View(admin);
        }

        // GET: Admins/Edit/5
        [HttpGet]
        public IActionResult Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var admin = _AdminRepo.GetByID(id);
            if (admin == null)
            {
                return NotFound();
            }
            return View(admin);
        }

        // POST: Admins/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,FirstName,LastName,Age,Email,Gender,PhoneNumber")] Admin admin)
        {
            if (id != admin.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _AdminRepo.Update(admin);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AdminExists(admin.Id))
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
            return View(admin);
        }

        // GET: Admins/Delete/5
        [HttpGet]
        public IActionResult Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var admin = _AdminRepo.GetByID(id);
            if (admin == null)
            {
                return NotFound();
            }

            return View(admin);
        }

        // POST: Admins/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var admin = _AdminRepo.GetByID(id);
            _AdminRepo.Remove(id);
            return RedirectToAction(nameof(Index));
        }

        //any condition of admin
        private bool AdminExists(int id)
        {
            return _AdminRepo.Any(id);
        }
    }
}
