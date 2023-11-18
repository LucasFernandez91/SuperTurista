import { Component, Inject, Input } from '@angular/core';
import { DialogConfirmRequest2 } from '../../model/textoLibre';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';

@Component({
  selector: 'app-dialog-confirm',
  templateUrl: './dialog-confirm.component.html',
  styleUrls: ['./dialog-confirm.component.scss']
})
export class DialogConfirmComponent {
  title: string = "Default Title"
  message1: string = "";
  message2: string = "";
  constructor(
    public dialogRef: MatDialogRef<DialogConfirmRequest2>,
    @Inject(MAT_DIALOG_DATA) public data: DialogConfirmRequest2
  ){
    this.title = data.Title;
    this.message1 = data.Message;
    this.message2 = data.Message2;
  }
}
