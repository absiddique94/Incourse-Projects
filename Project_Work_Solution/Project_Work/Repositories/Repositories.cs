using Project_Work.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Project_Work.Repositories
{
    public interface IEquipmentRepository
    {
        List<EquipmentType> GetAllRelated();
        Equipment GetEquipment(int id);
        List<Part> GetPartsOfEquipment(int id);
        List<EquipmentType> GetTypesForDropDown();
        void UpdateEquipment(Equipment eq);
        void InsertEquipmentWithPart(Equipment eq);
        //
        List<Equipment> GetEquipments();
        int EquipmentCount(int size);
        List<Part> GetEquipmentParts(int id);

        //Part
        List<Part> GetParts();
        Part GetPart(int id);
        void InsertPart(Part p);
        void UpdatePart(Part p);
        void DeletePart(int id);
    }
    public class EquipentRepository : IEquipmentRepository
    {
        EquipmentDbContext db = new EquipmentDbContext();

        public void DeletePart(int id)
        {
            Part p = new Part { PartId = id };
            db.Entry(p).State = EntityState.Deleted;
            db.SaveChanges();
        }

        public int EquipmentCount(int size)
        {
            return (int)Math.Ceiling((double)db.Equipments.Count() / size);
        }

        public Part GetPart(int id)
        {
            return db.Parts.FirstOrDefault(p => p.PartId == id);
        }

        public List<EquipmentType> GetAllRelated()
        {
            return db.EquipmentTypes
                .Include(t => t.Equipments.Select(eq => eq.Parts)).ToList();
        }

        public Equipment GetEquipment(int id)
        {
            return db.Equipments.FirstOrDefault(p => p.EquipmentId == id);
        }

        public List<Part> GetEquipmentParts(int id)
        {
            return db.Parts.Where(x => x.EquipmentId == id).ToList();
        }

        public List<Equipment> GetEquipments()
        {
            return db.Equipments.ToList();
        }

        public List<Part> GetParts()
        {
            return db.Parts.ToList();
        }

        public List<Part> GetPartsOfEquipment(int id)
        {
           return db.Parts.Where(x => x.EquipmentId == id).ToList();
        }

        public List<EquipmentType> GetTypesForDropDown()
        {
            return db.EquipmentTypes.ToList();
        }

        public void InsertEquipmentWithPart(Equipment eq)
        {
            db.Equipments.Add(eq);
            db.SaveChanges();
        }

        public void InsertPart(Part p)
        {
            db.Parts.Add(p);
            db.SaveChanges();
        }

        public void UpdateEquipment(Equipment eq)
        {
            db.Entry(eq).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void UpdatePart(Part p)
        {
            db.Entry(p).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}