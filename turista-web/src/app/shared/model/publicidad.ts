export class Publicidad {
    id: number;
    imagen: string;
    descripcion: string;
    fechaInicio: Date;
    fechaFin: Date;
    activa: boolean;
}

export class PublicidadResponse {
    publicidades: Publicidad[];
    total: number;
}
