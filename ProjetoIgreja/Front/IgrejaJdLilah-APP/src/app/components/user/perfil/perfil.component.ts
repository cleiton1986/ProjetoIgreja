import { Component, OnInit } from '@angular/core';
import { AbstractControlOptions, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ValidatorField } from '@app/helpers/ValidatorField';

@Component({
  selector: 'app-perfil',
  templateUrl: './perfil.component.html',
  styleUrls: ['./perfil.component.scss']
})
export class PerfilComponent implements OnInit {

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
        telefone:['',
          [Validators.required, Validators.pattern("^\\d{1,4}$")]
        ],
        titulo:['',
          [Validators.required]
        ],
        descricao:['',
          [Validators.maxLength(100)]
        ],
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
