import { Comentario } from './comentario';
export class Alojamiento {
    constructor(
        public id: number,
        public nombre: string,
        public tipo: TipoAlojamiento,
        public descripcion: string,
        public imagen: string,
        public ubicacion: string,
        public precioPorNoche: number,
        public valoracion: number,
        public comentarios: Comentario[]
      ) {}   
    
}

export enum TipoAlojamiento {
    HOTEL = 'Hotel',
    HOSTAL = 'Hostal',
    APARTAMENTO = 'Apartamento',
    CASA = 'Casa',
    VILLA = 'Villa'
}
