export class TipoReserva {
    id: number;
    nombre: string;
    descripcion: string;
}

export class TipoReservaResponse {
    data: TipoReserva[];
    total: number;
}
