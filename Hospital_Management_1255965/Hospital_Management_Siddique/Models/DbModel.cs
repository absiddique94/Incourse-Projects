using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital_Management_Siddique.Models
{
    public enum Gender { Male = 1, Female, Other }
    public enum Department { Cardiologists = 1, Dermatologists, Gastroenterologists, Ophthalmologists, Neurologists, Oncologists }
    public class Hospital
    {
        public Hospital()
        {
            this.Doctor = new HashSet<Doctor>();
            this.Service = new List<Service>();
            this.Patients = new List<Patient>();
        }
        [Display(Name = "Hospital Id")]
        public int HospitalId { get; set; }
        [Required, StringLength(60), Display(Name = "Hospital Name")]
        public string HospitalName { get; set; }
        [Required, Display(Name = "Working Since"), Column(TypeName = "date"),
            DataType(DataType.Date), DisplayFormat(DataFormatString = "{0;yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Established { get; set; }
        [StringLength(200), Display(Name = "Present Address")]
        public string Address { get; set; }
        [Required, DataType(DataType.EmailAddress), StringLength(40), Display(Name = "Email")]
        public string Emailaddress { get; set; }
        [Required, DataType(DataType.Url), Display(Name = "Website")]
        public string Web { get; set; }
        public virtual ICollection<Service> Service { get; set; }
        public virtual ICollection<Doctor> Doctor { get; set; }
        public virtual ICollection<Patient> Patients { get; set; }
    }
    public class Service
    {
        [Display(Name = "Hospital Id")]
        public int ServiceId { get; set; }
        [Required, StringLength(50), Display(Name = "Our Service")]
        public string ServiceName { get; set; }
        [Required, Display(Name = "Service Type")]
        public bool Contactual { get; set; }
        [Required, Display(Name = "Service Fee"), DisplayFormat(DataFormatString = "{0:00.00}", ApplyFormatInEditMode = true)]
        public decimal Expence { get; set; }
        [Required, ForeignKey("Hospital")]
        public int HospitalId { get; set; }
        public virtual Hospital Hospital { get; set; }
    }
    public class Doctor
    {       
        [Display(Name = "Doctor Id")]
        public int DoctorId { get; set; }
        [Required, StringLength(60), Display(Name = "Doctor Name")]
        public string DoctorName { get; set; }
        [Required, StringLength(200)]
        public string Picture { get; set; }
        [Required, EnumDataType(typeof(Department)), Display(Name = "Department")]
        public Department Department { get; set; }
        [Required]
        public bool IsAvailable { get; set; }
        [Required, ForeignKey("Hospital")]
        public int HospitalId { get; set; }
        public virtual Hospital Hospital { get; set; }
    }
    public class Patient
    {
        [Display(Name = "Patient Id")]
        public int PatientId { get; set; }
        [Required, StringLength(50), Display(Name = "Patient Name")]
        public string PatientName { get; set; }
        [Required, Display(Name = "Date of Birth"), Column(TypeName = "date"),
            DataType(DataType.Date), DisplayFormat(DataFormatString = "{0;yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DOB { get; set; }
        [Required, Display(Name = "Current Age")]
        public string Age { get; set; }
        [Required, Display(Name = "Service Fee")]
        public Gender Gender { get; set; }
        [Required, ForeignKey("Hospital")]
        public int HospitalId { get; set; }
        public virtual Hospital Hospital { get; set; }
    }
    public class HospitalDbContext : DbContext
    {
        public HospitalDbContext(DbContextOptions<HospitalDbContext> options) : base(options) { }
        public DbSet<Hospital> Hospitals { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Patient> Patients { get; set; }
    }
}
