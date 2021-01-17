using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hospital_Management_Siddique.Models;
using Microsoft.EntityFrameworkCore;

namespace Hospital_Management_Siddique.DAL
{
    public class PatientRepo : IPatientRepo
    {
        HospitalDbContext db;
        public PatientRepo(HospitalDbContext db) { this.db = db; }

        public bool Delete(int id)
        {
            db.Entry(new Patient { PatientId = id }).State = EntityState.Deleted;
            return db.SaveChanges() > 0;
        }

        public Patient GetPatientbyId(int id)
        {
            return db.Patients.FirstOrDefault(x => x.PatientId == id);
        }

        public List<Patient> GetPatients()
        {
            return db.Patients.ToList();
        }

        public bool Insert(Patient p)
        {
            db.Patients.Add(p);
            return db.SaveChanges() > 0;
        }

        public bool Update(Patient p)
        {
            db.Entry(p).State = EntityState.Modified;
            return db.SaveChanges() > 0;
        }
    }
}
