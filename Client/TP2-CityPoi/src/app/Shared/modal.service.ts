/**
 * Created by Remikya Hellal on 2017-05-09.
 */
import {Injectable, ViewContainerRef} from '@angular/core';
import {Modal} from 'angular2-modal/plugins/bootstrap';
import {Overlay} from 'angular2-modal';

@Injectable()
export class ModalService {

  modalResult: string;

  constructor(private overlay: Overlay, private modal: Modal) {
  }

  setOverlayToViewContainer(viewContainerRef: ViewContainerRef) {
    this.overlay.defaultViewContainer = viewContainerRef;
  }

  confirm(message: string, title: string): Promise<any> {

    let modalView = this.modal.confirm()
      .size('sm')
      .isBlocking(true)
      .showClose(true)
      .keyboard(27)
      .title(title)
      .body(message)
      .okBtn('Oui')
      .cancelBtn('Non')
      .open();

    return modalView.then((resultPromise) => resultPromise.result);
  }
}
