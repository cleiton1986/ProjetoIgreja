import { Endereco } from "./Endereco";
import { Evento } from "./Evento";
import { RedeSocial } from "./RedeSocial";


export interface Palestrante {
  id:  number;
  nome: string;
  miniCurriculo: number;
  imagemUrl: string;
  telefone: string;
  email: string;
  denominacao: string;
  dataCadastro: Date;
  fazParteMesmaDenominacao: boolean;
  enderecoId?: number;
  endereco: Endereco[];
  redeSociais: RedeSocial[];
  palestranteEvento: Evento[];
}

