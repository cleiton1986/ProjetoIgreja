import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Evento } from '../models/Evento';

@Injectable(

  //Provide que permit toda a aplicação visualizar essa classe
  //passou a ser usado dento de module
 // { providedIn: 'root'}
  )
export class EventoService {
  baseURL = 'https://localhost:5001/api/eventos';

/*
  A estrutura service vai servir os outros componentes
  como fosse a camada de "App"
  Encapsulando a chamada a API

  //Através da injeção de dependencia no construtor e no app.componet
  //Componte HttpCliente, é possivel chamar o controller Eventos da
  //camanda API

*/

  constructor(private http: HttpClient) { }

  //Pelo o Observable é possivel fazer a tipagen do metodo
  public getEvento(): Observable<Evento[]>{
    return this.http.get<Evento[]>(this.baseURL);
  }

  public getEventoByTema(tema: string): Observable<Evento[]>{
    return this.http.get<Evento[]>(`${this.baseURL}/tema/${tema}`)
  }

  public getEventoById(id: number): Observable<Evento>{
    return this.http.get<Evento>(`${this.baseURL}/${id}`)
  }

  public getEventoByImagens(): Observable<any[]>{
    return this.http.get<any[]>(`${this.baseURL}`)
  }
}
