import { Component, OnInit } from '@angular/core';
import { AbstractControlOptions, FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ValidatorField } from '@app/helpers/ValidatorField';

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.scss']
})
export class RegistrationComponent implements OnInit {

  form!: FormGroup;

  constructor(public fb: FormBuilder) { }

  ngOnInit(): void {
    this.validation();
  }

  get f(): any{
    return this.form.controls;
  }

  private validation(): void{

    const formOptions: AbstractControlOptions ={
        validators: ValidatorField.MustMatch('senha','confirmarSenha')
    };

    this.form = this.fb.group({
        primeiroNome:['', Validators.required],
        ultimoNome:['', Validators.required],
        usuario:['', Validators.required],
        email:['',
           [Validators.required, Validators.email]
        ],
        senha:['',
          [Validators.required, Validators.minLength(3)]
        ],
        confirmarSenha:['', Validators.required],

   }, formOptions)

  }

}
