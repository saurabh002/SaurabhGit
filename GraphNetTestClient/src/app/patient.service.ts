import { Injectable } from '@angular/core';
import { RequestOptions } from '@angular/http';
import { HttpClient,HttpHeaders } from '@angular/common/http';
import {Patient} from "./patient.model";

@Injectable()

export class PatientService {
  constructor(private http: HttpClient) { }
  baseUrl: string = 'http://localhost:20026/api/patient';

  getPatients() {
    return this.http.get<Patient[]>(this.baseUrl+'/getall');
  }

  getPatientById(id: number) {
     return this.http.get<Patient>(this.baseUrl + '/get/' + id);
  }

  addPatient(patient: Patient) {
    //const headers = new Headers({ 'Content-Type': 'text/xml' });
  //   this.http.request({
  //     url: this.baseUrl+"/add",
  //     method: "POST",
  //     headers: { "Content-Type": "text/xml" },
  //     body: patient
  //     //data: JSON.stringify({ "": patient })

  // })
    //const options = new RequestOptions({ headers: headers });
   // return this.http.post(this.apiUrl, { 'XML': patient }, options)
   const headers = new HttpHeaders().set('Content-Type', 'text/xml');
    return this.http.post(this.baseUrl+"/add" , JSON.stringify({patient }) ,{ headers: headers});
  }

   updatePatient(patient: Patient) {
     return this.http.put(this.baseUrl + '/update', patient);
  }

  // deletePatient(id: number) {
  //   return this.http.delete(this.baseUrl + '/' + id);
  // }
}