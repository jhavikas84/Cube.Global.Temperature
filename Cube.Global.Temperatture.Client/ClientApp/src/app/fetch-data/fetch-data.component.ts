import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { TempertureService, TemperatureData} from './temperature-service';
import { FormGroup, FormControl, Validators } from '@angular/forms';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html'
})
export class FetchDataComponent {
  public temperature: TemperatureData;
  form: FormGroup;

  constructor(private tempertureService: TempertureService) {

  }

  ngOnInit() {
    this.form = new FormGroup({
      temperature: new FormControl(null, { updateOn: 'blur', validators: [Validators.required] }),
      temperatureType: new FormControl(null, { updateOn: 'blur', validators: [Validators.required] }),
    });

    
  }

  onSubmit() {
    const temperature = this.form.value.temperature;
    const temperatureType = this.form.value.temperatureType;
    this.tempertureService.getConvertedTemperature(temperatureType, temperature)
      .subscribe(resData => {
        console.log('Results: ', resData);
      this.temperature = resData;
    },
      error => {
        console.log('error when trying to get the converted temperature', error);
      },
      () => {
        console.log('complete');
      });
  }
}
