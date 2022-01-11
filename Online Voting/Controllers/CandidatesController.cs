using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DAL_Data_Access_Layer_.Model;
using Service_Layer.Repositories;

namespace Online_Voting.Controllers
{
    public class CandidatesController : Controller
    {
        private readonly ICandidate _Repo;

        public CandidatesController(ICandidate Repo)
        {
            _Repo = Repo;
        }

        // GET: Candidates
        public IActionResult Index()
        {
            return View(_Repo.GetAll());
        }

        // GET: Candidates/Details/5
        public IActionResult Details(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var candidate = _Repo.GetByID(id);
            if (candidate == null)
            {
                return NotFound();
            }

            return View(candidate);
        }

        // GET: Candidates/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Candidates/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("CandidateId,LastName,Age,Gender,PhoneNumber,Votes")] Candidate candidate)
        {
            if (ModelState.IsValid)
            {
                _Repo.Add(candidate);
                _Repo.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(candidate);
        }

        // GET: Candidates/Edit/5
        public IActionResult Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var candidate = _Repo.GetByID(id);
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
        public IActionResult Edit(int id, [Bind("CandidateId,LastName,Age,Gender,PhoneNumber,Votes")] Candidate candidate)
        {
            if (id != candidate.CandidateId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _Repo.Update(candidate);
                    _Repo.SaveChanges();
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
        public async Task<IActionResult> Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var candidate = _Repo.GetByID(id);
            if (candidate == null)
            {
                return NotFound();
            }

            return View(candidate);
        }

        // POST: Candidates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var candidate = _Repo.GetByID(id);
            _Repo.Remove(id);
            _Repo.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        private bool CandidateExists(int id)
        {
            return _Repo.Any(id);
        }
    }
}
