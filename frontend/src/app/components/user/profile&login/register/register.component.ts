import { ChangeDetectionStrategy, Component, signal } from '@angular/core';
import { FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { InputTextModule } from 'primeng/inputtext';
import { FloatLabelModule } from 'primeng/floatlabel';
import { DatePickerModule } from 'primeng/datepicker';
import { RadioButtonModule } from 'primeng/radiobutton';
import { InputMaskModule } from 'primeng/inputmask';
import { PasswordModule } from 'primeng/password';
import { ButtonModule } from 'primeng/button';
import { PatientService } from '../../../../services/patient.service';
import { Gender, Patient } from '../../../../classes/patient';



@Component({
  selector: 'app-register',
  imports: [ReactiveFormsModule, InputTextModule, FloatLabelModule, DatePickerModule,
    RadioButtonModule, InputMaskModule, PasswordModule, ButtonModule],
  changeDetection: ChangeDetectionStrategy.OnPush,
  templateUrl: './register.component.html',
  styleUrl: './register.component.scss',
})
export class RegisterComponent {

  constructor(public patientService: PatientService) { }

  ngOnInit(): void {
    this.registrationForm.valueChanges.subscribe((value) => {
    });
  }


  registrationForm: FormGroup = new FormGroup({
    personalInformation: new FormGroup({
      idNumber: new FormControl('', Validators.required),
      firstName: new FormControl('', Validators.required),
      lastName: new FormControl('', Validators.required),
      birthDate: new FormControl('', Validators.required),
      gender: new FormControl('', Validators.required)
    }),
    contactInformation: new FormGroup({
      address: new FormControl('', Validators.required),
      phone: new FormControl('', [Validators.required, Validators.pattern(/^\d{10}$/)]),
      email: new FormControl('', [Validators.required, Validators.email]),
      password: new FormControl('', Validators.required),
      passwordValidate: new FormControl('', Validators.required)
    })
  })

  register() {
    console.log("פרטי משתמש", this.registrationForm.value);
    const date = this.registrationForm.get('personalInformation.birthDate')?.value;
    const formattedDate = new Date(date).toISOString();
    const genderValue = this.registrationForm.get('personalInformation.gender')?.value === 'Male' ? Gender.Male : Gender.Female;

    const patient: Patient = new Patient(
      this.registrationForm.get('personalInformation.idNumber')?.value,
      this.registrationForm.get('personalInformation.firstName')?.value,
      this.registrationForm.get('personalInformation.lastName')?.value,
      formattedDate,
      genderValue,
      this.registrationForm.get('contactInformation.address')?.value,
      this.registrationForm.get('contactInformation.phone')?.value,
      this.registrationForm.get('contactInformation.email')?.value,
      this.registrationForm.get('contactInformation.password')?.value,
      []
    );
    console.log("patient: ", patient);

    this.patientService.addPatient(patient).subscribe(data => {
      console.log(data);
    })
  }

  hide = signal(true);
  clickEvent(event: MouseEvent) {
    this.hide.set(!this.hide());
    event.stopPropagation();
  }

  private readonly _currentYear = new Date().getFullYear();
  readonly minDate = new Date(this._currentYear - 120, 0, 1);
  readonly maxDate = new Date(new Date().setDate(new Date().getDate() - 1));

}