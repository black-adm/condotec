import { Component, OnInit } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import { RegisterFormComponent } from '../register-form.component';

interface AddressProps {
  postalCode: string
  street: string
  number: string
  district: string
  complement?: string
  city: string
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
            street: data.logradouro || '',
            number: '',
            district: data.bairro || '',
            complement: data.complemento || '',
            city: `${data.localidade || ''} - ${data.uf || ''}`,
          };

          this.form.controls['street'].setValue(result.street);
          this.form.controls['number'].setValue(result.number);
          this.form.controls['district'].setValue(result.district);
          this.form.controls['complement'].setValue(result.complement);
          this.form.controls['city'].setValue(result.city);
        }
      )
  }
}
