﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DAL_Data_Access_Layer_.Data;
using DAL_Data_Access_Layer_.Model;
using Service_Layer.Repositories;

namespace Online_Voting.Controllers
{
    public class AdminsController : Controller
    {
        private readonly IAdmin _Repo;

        public AdminsController(IAdmin repo)
        {
            _Repo = repo;
        }

        // GET: Admins
        public IActionResult Index()
        {
            return View(_Repo.GetAll());
        }

        // GET: Admins/Details/5
        public IActionResult Details(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var admin = _Repo.GetByID(id);
            if (admin == null)
            {
                return NotFound();
            }

            return View(admin);
        }

        // GET: Admins/Create
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
                _Repo.Add(admin);
                _Repo.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(admin);
        }

        // GET: Admins/Edit/5
        public IActionResult Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var admin = _Repo.GetByID(id);
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
                    _Repo.Update(admin);
                    _Repo.SaveChanges();
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
        public IActionResult Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var admin = _Repo.GetByID(id);
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
            var admin = _Repo.GetByID(id);
            _Repo.Remove(id);
            _Repo.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        private bool AdminExists(int id)
        {
            return _Repo.Any(id);
        }
    }
}