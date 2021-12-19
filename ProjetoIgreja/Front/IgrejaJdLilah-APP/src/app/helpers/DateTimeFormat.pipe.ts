import { DatePipe } from '@angular/common';
import { Pipe, PipeTransform } from '@angular/core';
import { Constants } from '../util/constants';

@Pipe({
  name: 'DateTimeFormat'
})
export class DateTimeFormatPipe extends  DatePipe implements PipeTransform {

  override transform(value: any, args?: any): any {
    //Usa Piper de data
    return super.transform(value, Constants.DATE_TIME_FMT);
    //return super.transform(value, 'dd/MM/yyyy hh:mm');

  }
}
