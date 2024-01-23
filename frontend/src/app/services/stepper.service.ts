import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class StepperService {
  private currentStepSubject: BehaviorSubject<number> = new BehaviorSubject<number>(1)
  public currentStep$: Observable<number> = this.currentStepSubject.asObservable()

  private stepDetails: { title: string; description: string }[] = [
    { title: 'Passo 1', description: 'Vamos criar suas credenciais de acesso ?' },
    { title: 'Passo 2', description: 'Agora, preencha seus dados pessoais.' },
    { title: 'Passo 3', description: 'Para finalizar, informe o seu endereço pessoal.' },
  ];

  getStepDetails(step: number): { title: string; description: string } {
    return this.stepDetails[step - 1];
  }

  getCurrentStep(): number {
    return this.currentStepSubject.value;
  }

  setCurrentStep(step: number): void {
    this.currentStepSubject.next(step);
  }
}
