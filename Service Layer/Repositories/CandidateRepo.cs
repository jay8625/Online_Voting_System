﻿using DAL_Data_Access_Layer_.Data;
using DAL_Data_Access_Layer_.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Service_Layer.Repositories
{
    public class CandidateRepo : ICandidate
    {
        private readonly CommonDbContext _context;

        public CandidateRepo(CommonDbContext context)
        {
            _context = context;
        }

        public void Add(Candidate candidate)
        {
            _context.Candidates.Add(candidate);
        }

        public bool Any(int Id)
        {
            if (_context.Candidates.Any(e => e.CandidateId == Id))
            {
                return true;
            }
            return false;
        }

        public IEnumerable<Candidate> GetAll()
        {
            return _context.Candidates.ToList();
        }

        public Candidate GetByID(int Id)
        {
            return _context.Candidates.Where(x => x.CandidateId == Id).FirstOrDefault();
        }

        public void Remove(int Id)
        {
            Candidate Remove = _context.Candidates.Find(Id);
            _context.Candidates.Remove(Remove);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public void Update(Candidate candidate)
        {
            _context.Entry(candidate).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }
    }
}