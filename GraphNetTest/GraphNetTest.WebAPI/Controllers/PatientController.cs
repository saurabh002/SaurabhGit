using GraphNetTest.BusinessServices;
using GraphNetTest.Data;
using GraphNetTest.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace GraphNetTest.WebAPI.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*", exposedHeaders: "X-Custom-Header")]
    public class PatientController : ApiController
    {
        PatientServices _patientService;
        public PatientController(PatientServices patientServices)
        {
            _patientService = patientServices;
        }
        // GET api/<controller>
        public IEnumerable<Patient> GetAll()
        {
            return this._patientService.GetPatients();
        }

        public Patient Get(string id)
        {
            return this._patientService.GetPatient(id);
        }

        public IHttpActionResult Add(Patient p)
        {
            int response = this._patientService.AddPatient(p);
            if (response == -1)
                return Conflict();
            else
                return Ok("Data posted successfully");
        }

        public void Update(Patient p)
        {
            this._patientService.UpdatePatient(p);
        }

        public void Delete(Patient p)
        {
            this._patientService.DeletePatient(p);
        }
    }
}
