export class GenericResponse<T> {
    constructor (
        public readonly Success: boolean,
        public readonly Message: string,
        public readonly Result: T
    ) {}
}

export class GenericSearchResponse<T> {
    constructor (
        public readonly count: number,
        public readonly result: T[]
    ) {}
}

export class GenericPieDashboardResponse {
    constructor (
        public readonly TotalItemsGrupos: number,
        public readonly Grupos: GenericPieDashboardItemResponse[]
    ) {}
}

export class GenericPieDashboardItemResponse {
    constructor (
        public readonly CantidadGrupo: number,
        public readonly NombreGrupo: string
    ) {}
}