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



