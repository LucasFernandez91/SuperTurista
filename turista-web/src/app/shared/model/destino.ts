export class Destino {
    constructor(
     public ciudad: string, 
     public provincia: string, 
     public pais: string
    ) {}
}

export class DestinoCategoria {
    constructor(
        public id: number,
        public nombre: string,
    ) { }
}

export class DestinoCategoriaResponse { 
        constructor(
            public id: number,
            public nombre: string,
            public destinos: Destino[],
        ) { }
    
}

export class DestinoResponse {
    constructor(
        public id: number,
        public ciudad: string,
        public provincia: string,
        public pais: string,
        public categoria: DestinoCategoria,
    ){}
}

export class DestinoSearchResponse {
    constructor(
        public count: number,
        public result: DestinoResponse[],
    ){}
}

export class DestinoRequest {
    

    constructor(
        public ciudad: string,
        public provincia: string,
        public pais: string,
        public categoria: DestinoCategoria,
    ) { }
}
