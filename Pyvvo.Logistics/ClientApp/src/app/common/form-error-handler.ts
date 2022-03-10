import { FormGroup } from "@angular/forms";

export class FormErrorHandler {
  private formGroup: FormGroup;

  constructor(_fg: FormGroup) {
    this.formGroup = _fg;
  }

  hasError(controlName: string, errorName) {
    return this.formGroup.controls[controlName].hasError(errorName);
  }
}
