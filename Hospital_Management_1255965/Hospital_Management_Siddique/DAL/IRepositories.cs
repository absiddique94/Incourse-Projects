using Hospital_Management_Siddique.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital_Management_Siddique.DAL
{
    public interface IHospitalRepo
    {
        List<Hospital> GetHospitals();
        Hospital GetHospitalbyId(int id);
        bool Insert(Hospital h);
        bool Update(Hospital h);
        bool Delete(int id);
    }
    public interface IServiceRepo
    {
        List<Service> GetServices();
        Service GetServicebyId(int id);
        bool Insert(Service s);
        bool Update(Service s);
        bool Delete(int id);
    }
    public interface IDoctorRepo
    {
        List<Doctor> GetDoctors();
        Doctor GetDoctorbyId(int id);
        bool Insert(Doctor d);
        bool Update(Doctor d);
        bool Delete(int id);
    }
    public interface IPatientRepo
    {
        List<Patient> GetPatients();
        Patient GetPatientbyId(int id);
        bool Insert(Patient p);
        bool Update(Patient p);
        bool Delete(int id);
    }
}
