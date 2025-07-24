import { Appointment } from "./appointment";
import { WorkingHours } from "./working-hours";

export enum Gender {
  Male = 0,
  Female = 1
}

export class Doctor {
    constructor(
        public id : string,
        public licenseNum : string,
        public specialtyId : number,
        public name : string,
        public gender : Gender | string,
        public languages : string,
        public phone : string,
        public email : string,
        public workingHours : WorkingHours[],
        public appointmentDoration : string,
        public appointments : Appointment[],
        public genderText?: string
    ){}
}
