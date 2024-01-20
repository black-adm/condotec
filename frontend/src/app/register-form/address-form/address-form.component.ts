import { Component, OnInit } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import { RegisterFormComponent } from '../register-form.component';

interface AddressProps {
  postalCode: string
  streetAddress: string
  complement: string
  city: string
  uf: string
}

const url = 'https://viacep.com.br/ws'

@Component({
  selector: 'app-address-form',
  templateUrl: './address-form.component.html',
})
export class AddressFormComponent implements OnInit {
  form!: FormGroup

  constructor(
    private registerForm: RegisterFormComponent,
    private http: HttpClient
  ) { }

  ngOnInit() {
    this.form = this.registerForm.getAddress()
  }

  searchPostalCode(event: any) {
    const postalCode = (event.target as HTMLInputElement)?.value.replace("-", "");

    this.http.get<AddressProps>(`${url}/${postalCode}/json`)
      .subscribe(
        (data: any) => {
          const result: AddressProps = {
            postalCode: data.cep || '',
            streetAddress: `${data.logradouro || ''} - ${data.bairro || ''}`,
            complement: data.complemento || '',
            city: data.localidade || '',
            uf: data.uf || '',
          };

          this.form.controls['streetAddress'].setValue(result.streetAddress);
          this.form.controls['complement'].setValue(result.complement);
          this.form.controls['city'].setValue(result.city);
          this.form.controls['uf'].setValue(result.uf);
        }
      )
  }
}
