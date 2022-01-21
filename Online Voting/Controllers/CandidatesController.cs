using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DAL_Data_Access_Layer_.Model;
using Service_Layer.Repositories;

namespace Online_Voting.Controllers
{
    public class CandidatesController : Controller
    {
        //injecting Repositories to perform actions
        private readonly ICandidate _candidateRepo;
        private readonly IUser _userRepo;

        public CandidatesController(ICandidate candidateRepo, IUser userRepo)
        {
            _candidateRepo = candidateRepo;
            _userRepo = userRepo;
        }

        // GET: Candidates
        [HttpGet]
        public IActionResult Index()
        {
            return View(_candidateRepo.GetAll());
        }

        // GET: Candidates/Details/5
        [HttpGet]
        public IActionResult Details(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var candidate = _candidateRepo.GetByID(id);
            if (candidate == null)
            {
                return NotFound();
            }

            return View(candidate);
        }

        // GET: Candidates/Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Candidates/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CandidateId,FirstName,LastName,Age,Gender,PhoneNumber")] Candidate candidate)
        {
            if (ModelState.IsValid)
            {
                _candidateRepo.Add(candidate);
                return RedirectToAction(nameof(Index));
            }
            return View(candidate);
        }

        // GET: Candidates/Edit/5
        [HttpGet]
        public IActionResult Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var candidate = _candidateRepo.GetByID(id);
            if (candidate == null)
            {
                return NotFound();
            }
            return View(candidate);
        }

        // POST: Candidates/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("CandidateId,FirstName,LastName,Age,Gender,PhoneNumber")] Candidate candidate)
        {
            if (id != candidate.CandidateId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _candidateRepo.Update(candidate);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CandidateExists(candidate.CandidateId))
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
            return View(candidate);
        }

        // GET: Candidates/Delete/5
        [HttpGet]
        public IActionResult Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var candidate = _candidateRepo.GetByID(id);
            if (candidate == null)
            {
                return NotFound();
            }

            return View(candidate);
        }

        // POST: Candidates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _userRepo.CascadeRemove(id);
            _candidateRepo.Remove(id);
            return RedirectToAction(nameof(Index));
        }

        //any condition candidate
        private bool CandidateExists(int id)
        {
            return _candidateRepo.Any(id);
        }
    }
}
