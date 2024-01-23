import { Component, OnInit, inject } from '@angular/core';
import { StepperService } from 'src/app/services/stepper.service';

@Component({
  selector: 'app-stepper',
  templateUrl: './stepper.component.html',
})
export class StepperComponent implements OnInit {
  currentStep: number = 1
  stepDetails: { title: string; description: string; } = { title: '', description: '' };

  private stepperService = inject(StepperService)

  ngOnInit() {
    this.stepperService.currentStep$.subscribe((step) => {
      this.currentStep = step;
      this.stepDetails = this.stepperService.getStepDetails(step);
    });
  }
}
