import { Directive, HostListener, Input } from '@angular/core';
import { NgControl } from '@angular/forms';

@Directive({
  selector: '[appMask]',
  standalone: true
})
export class AppMaskDirective {
  @Input('appMask') mask: string = '';

  constructor(private control: NgControl) {}

  @HostListener('input', ['$event'])
  onInputChange(event: any): void {
    let value = event.target.value.replace(/\D/g, '');
    const maskChars = this.mask.split('');
    let newValue = '';

    let valueIndex = 0;
    maskChars.forEach((char) => {
      if (char === '0' && value[valueIndex] !== undefined) {
        newValue += value[valueIndex];
        valueIndex++;
      } else if (char !== '0') {
        newValue += char;
      }
    });

    this.control.control?.setValue(newValue);
  }
}
