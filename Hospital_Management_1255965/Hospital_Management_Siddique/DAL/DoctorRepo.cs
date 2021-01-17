using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hospital_Management_Siddique.Models;
using Microsoft.EntityFrameworkCore;

namespace Hospital_Management_Siddique.DAL
{
    
    public class DoctorRepo : IDoctorRepo
    {
        HospitalDbContext db;
        public DoctorRepo(HospitalDbContext db) { this.db = db; }
        public bool Delete(int id)
        {
            db.Entry(new Doctor { DoctorId = id }).State = EntityState.Deleted;
            return db.SaveChanges() > 0;
        }

        public Doctor GetDoctorbyId(int id)
        {
            return db.Doctors.FirstOrDefault(x => x.DoctorId == id);
        }

        public List<Doctor> GetDoctors()
        {
            return db.Doctors.ToList();
        }

        public bool Insert(Doctor d)
        {
            db.Doctors.Add(d);
            return db.SaveChanges() > 0;
        }

        public bool Update(Doctor d)
        {
            db.Entry(d).State = EntityState.Modified;
            return db.SaveChanges() > 0;
        }
    }
}
