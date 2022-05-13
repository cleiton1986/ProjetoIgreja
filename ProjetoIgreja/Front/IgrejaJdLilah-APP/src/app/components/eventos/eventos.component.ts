
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-eventos',
  templateUrl: './eventos.component.html',
  styleUrls: ['./eventos.component.scss']
  //Provider que permite toda a aplicação visualizar a classe EventoService
  //passou a ser usado dento de module
  //  providers: [EventoService]

})
export class EventosComponent implements OnInit {

  ngOnInit(): void {

  }

}
