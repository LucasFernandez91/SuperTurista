export class TipoServicio {
    id: number;
    nombre: string;
    descripcion: string;
}

export class TipoServicioDetalle extends TipoServicio {
    precio: number;
    duracion: number;
}
