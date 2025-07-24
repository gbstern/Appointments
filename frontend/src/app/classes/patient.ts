import { Appointment } from "./appointment";

export enum Gender {
  Male = 0,
  Female = 1
}

export class Patient {
  constructor(public id: string,
    public firstName: string,
    public lastName: string,
    public birthDate: Date | string,
    public gender: Gender,
    public address: string,
    public phone: string,
    public email: string,
    public password: string,
    public appointments: Appointment[]
  ) { }
}
