/**
 * Created by Remikya Hellal on 2017-05-11.
 */
import {Injectable} from '@angular/core';

declare let toastr: any

@Injectable()
export class ToastrService {

  constructor() {}

  success(message: string, title?: string) {
    toastr.success(message, title);
  }
  error(message: string, title?: string) {
    toastr.error(message, title);
  }
}
