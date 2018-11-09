using AutoMapper;
using GraphNetTest.Data;
using GraphNetTest.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphNetTest.BusinessServices
{
    public class PatientServices
    {
        private PatientRepository _patientRepository;

        public PatientServices() : this(null)
        {
        }
        public PatientServices(PatientRepository patientRepository)
        {
            this._patientRepository = new PatientRepository();
        }

        public List<Patient> GetPatients()
        {
         var patients = this._patientRepository.GetAll().ToList();
         var list = new List<Patient>();
          if(patients?.Count()>0){

            foreach (var c in patients)
            {
                list.Add(new Patient
                {
                    PatientId = c.PatientId,
                    FirstName = c.FirstName,
                    LastName = c.LastName,
                    DateOfBirth = c.DateOfBirth,
                    Gender = c.Gender,
                    Phone = new TelephoneNumber { HomePhone = c.HomePhone, WorkPhone = c.WorkPhone, CellPhone = c.CellPhone }
                });
            }
         }
            return list;
            //var config = new MapperConfiguration(cfg =>
            //{
            //    cfg.CreateMap<List<PatientData>, List<Patient>>();
            //});

            //IMapper iMapper = config.CreateMapper();

            //var destination = iMapper.Map<List<PatientData>, List<Patient>>(patients);
            //return destination.ToList();
            //return null;
        }

        public Patient GetPatient(string id)
        {
          
            var c = this._patientRepository.GetSingle(id);
            if(c!=null){
             var p = new Patient()
             {
                PatientId = c.PatientId,
                FirstName = c.FirstName,
                LastName = c.LastName,
                DateOfBirth = c.DateOfBirth,
                Gender = c.Gender,
                Phone = new TelephoneNumber { HomePhone = c.HomePhone, WorkPhone = c.WorkPhone, CellPhone = c.CellPhone }
             };
          }
            return p;

        }

        public int AddPatient(Patient p)
        {
            try
            {
            var patient = new PatientData()
            {
                PatientId = p.PatientId,
                FirstName = p.FirstName,
                LastName = p.LastName,
                DateOfBirth = p.DateOfBirth,
                Gender = p.Gender,
                HomePhone = p.Phone?.HomePhone,
                WorkPhone = p.Phone?.WorkPhone,
                CellPhone = p.Phone?.CellPhone
            };

                this._patientRepository.Add(patient);
                this._patientRepository.Save();
            }
            catch (Exception) when (_patientRepository.GetSingle(p.PatientId) != null)
            {
                return -1;
            }
            catch (Exception)
            {
                throw;
            }
            return 1;
        }

        public void UpdatePatient(Patient p)
        {
        try
            {
            var patient = new PatientData()
            {
                PatientId = p.PatientId,
                FirstName = p.FirstName,
                LastName = p.LastName,
                DateOfBirth = p.DateOfBirth,
                Gender = p.Gender,
                HomePhone = p.Phone?.HomePhone,
                WorkPhone = p.Phone?.WorkPhone,
                CellPhone = p.Phone?.CellPhone
            };
            this._patientRepository.Edit(patient);
            this._patientRepository.Save();
         }
         catch (Exception)
            {
                throw;
            }
        }

        public void DeletePatient(Patient p)
        {
            var patient = new PatientData()
            {
                PatientId = p.PatientId,
                FirstName = p.FirstName,
                LastName = p.LastName,
                DateOfBirth = p.DateOfBirth,
                Gender = p.Gender,
                HomePhone = p.Phone?.HomePhone,
                WorkPhone = p.Phone?.WorkPhone,
                CellPhone = p.Phone?.CellPhone
            };
            this._patientRepository.Delete(patient);
            this._patientRepository.Save();
        }
    }
}
