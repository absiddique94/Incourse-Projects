using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hospital_Management_Siddique.Models;
using Microsoft.EntityFrameworkCore;

namespace Hospital_Management_Siddique.DAL
{
    public class ServiceRepo : IServiceRepo
    {
        HospitalDbContext db;
        public ServiceRepo(HospitalDbContext db) { this.db = db; }
        public bool Delete(int id)
        {
            db.Entry(new Service { ServiceId=id}).State = EntityState.Deleted;
            if( db.SaveChanges() > 0) return true;
            else return false;
        }

        public Service GetServicebyId(int id)
        {
            return db.Services.FirstOrDefault(x => x.ServiceId == id);
        }

        public List<Service> GetServices()
        {
            return db.Services.ToList();
        }

        public bool Insert(Service s)
        {
            db.Services.Add(s);
            if (db.SaveChanges() > 0) return true;
            else return false;
        }

        public bool Update(Service s)
        {
            db.Entry(s).State = EntityState.Modified;
            if (db.SaveChanges() > 0) return true;
            else return false;
        }
    }
}