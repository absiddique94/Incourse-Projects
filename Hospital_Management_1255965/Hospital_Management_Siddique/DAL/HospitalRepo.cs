using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hospital_Management_Siddique.Models;
using Microsoft.EntityFrameworkCore;

namespace Hospital_Management_Siddique.DAL
{
    public class HospitalRepo : IHospitalRepo
    {
        HospitalDbContext db;
        public HospitalRepo(HospitalDbContext db) { this.db = db; }
        public bool Delete(int id)
        {
            Hospital h = new Hospital { HospitalId = id };
            db.Entry(h).State = EntityState.Deleted;
            return db.SaveChanges() > 0;
        }

        public Hospital GetHospitalbyId(int id)
        {
            return db.Hospitals.FirstOrDefault(x => x.HospitalId == id);
        }

        public List<Hospital> GetHospitals()
        {
            return db.Hospitals.ToList();
        }

        public bool Insert(Hospital h)
        {
            db.Hospitals.Add(h);
            return db.SaveChanges() > 0;
        }

        public bool Update(Hospital h)
        {
            db.Entry(h).State = EntityState.Modified;
            return db.SaveChanges()>0;
        }
    }
}
