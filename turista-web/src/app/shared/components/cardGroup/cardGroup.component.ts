import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-cardGroup',
  templateUrl: './cardGroup.component.html',
  styleUrls: ['./cardGroup.component.scss']
})
export class CardGroupComponent implements OnInit {
  cards:any[] = [{},{},{}]
  
  @Input() title: string = "Default Title";
  @Input() subTitle: string = "Default SubTitle";
  @Input() isSale: boolean = true;
  @Input() reservationType: number = 0;


  ngOnInit(){
  }
}
