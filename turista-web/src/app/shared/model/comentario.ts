export class Comentario {
    constructor(
      public id: number,
      public nombreUsuario: string,
      public texto: string,
      public fecha: Date,
      public valoracion: number
    ) {}
  }