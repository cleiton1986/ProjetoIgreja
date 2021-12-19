export interface Contato {
   id: number;
   nome: string;
   email: string;
   telefone: string;
   denominacao: string;
   dataCadastro: Date;
   fazParteMesmaDenominacao: boolean;
   enderecoId: number;
   endereco: string;

}
