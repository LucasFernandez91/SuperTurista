export class Alojamiento {
    id: number;
    nombre: string;
    direccion: string;
    descripcion: string;
    precio: number;
    capacidad: number;
    imagen: string;
    tipo: TipoAlojamiento;
}

export enum TipoAlojamiento {
    HOTEL = 'Hotel',
    HOSTAL = 'Hostal',
    APARTAMENTO = 'Apartamento',
    CASA = 'Casa',
    VILLA = 'Villa'
}
