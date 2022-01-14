using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DAL_Data_Access_Layer_.Model;
using Service_Layer.Repositories;

namespace Online_Voting.Controllers
{
    public class AdminsController : Controller
    {
        private readonly IAdmin _AdminRepo;
        private readonly IUser _UserRepo;
        private readonly ICandidate _candidateRepo;

        public AdminsController(IAdmin repo, IUser user, ICandidate candidateRepo)
        {
            _AdminRepo = repo;
            _UserRepo = user;
            _candidateRepo = candidateRepo;
        }

        [HttpGet]
        public IActionResult AdminOptions()
        {
            return View();
        }

        // GET: Admins
        [HttpGet]
        public IActionResult Index()
        {
            return View(_AdminRepo.GetAll());
        }

        //GET: Users
        [HttpGet]
        public IActionResult UserIndex()
        {
            return View(_UserRepo.GetAll());
        }

        //GET: Candidates
        [HttpGet]
        public IActionResult CandidateIndex()
        {
            return View(_candidateRepo.GetAll());
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

        private bool AdminExists(int id)
        {
            return _AdminRepo.Any(id);
        }
    }
}
