using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Project_Work.Models
{
    public class EquipmentType
    {
        public EquipmentType() { this.Equipments = new HashSet<Equipment>(); }
        public int EquipmentTypeId { get; set; }
        [Required, StringLength(40)]
        public string TypeName { get; set; }
        //
        public virtual ICollection<Equipment> Equipments { get; set; }
    }
    public class Equipment
    {
        public Equipment() { this.Parts = new HashSet<Part>(); }
        public int EquipmentId { get; set; }
        [Required, StringLength(30)]
        public string Model { get; set; }
        [Required, DataType(DataType.Date), Column(TypeName ="date"), Display(Name ="Purchase Date"),
            DisplayFormat(DataFormatString ="{0:yyyy-MM-dd}", ApplyFormatInEditMode =true)]
        public DateTime PurchaseDate { get; set; }
        [Required, ForeignKey("EquipmentType")]
        public int EquipTypeId { get; set; }
        //
        public virtual EquipmentType EquipmentType { get; set; }
        public virtual ICollection<Part> Parts { get; set; }
    }
    public class Part
    {
        public int PartId { get; set; }
        [Required, StringLength(30)]
        public string PartName { get; set; }
        public int Stock { get; set; }
        [Required, ForeignKey("Equipment")]
        public int EquipmentId { get; set; }
        //
        public virtual Equipment Equipment { get; set; }
    }
    public class EquipmentDbContext:DbContext
    {
        public EquipmentDbContext()
        {
            Database.SetInitializer(new EqDbInitializer());
        }
        public DbSet<EquipmentType> EquipmentTypes { get; set; }
        public DbSet<Equipment> Equipments { get; set; }

        public DbSet<Part> Parts { get; set; }
    }
    public class EqDbInitializer : DropCreateDatabaseIfModelChanges<EquipmentDbContext>
    {
        protected override void Seed(EquipmentDbContext db)
        {
            string[] typeNames = { "Lifter", "Excavator", "Loader" };
            var i = 1;
            foreach(string s in typeNames)
            {
                var t = new EquipmentType { TypeName = s };
                Equipment eq1 = new Equipment { Model = ( s.Substring(0, 2) + "-" +(i++) ), PurchaseDate = DateTime.Now.AddDays((-1)*i*100), EquipmentType = t };
                Equipment eq2 = new Equipment { Model = (s.Substring(0, 2) + "-" + (i++)), PurchaseDate = DateTime.Now.AddDays((-1)*i * 100), EquipmentType = t };
                t.Equipments.Add(eq1);
                t.Equipments.Add(eq2);
                db.EquipmentTypes.Add(t);
            }
            db.SaveChanges();
        }
    }
}