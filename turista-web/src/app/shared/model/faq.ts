export class Faq {    
    constructor(
        public pregunta: string,
        public respuesta: string,
        public categoria: string
    ) {}
}

export class FaqCategoria {    
    constructor(
        public id: number,
        public nombre: string,
    ){}   
}

export class FaqRequest {
    constructor(
        public pregunta: string,
        public respuesta: string,
        public categoria: string
    ) {}
}

export class FaqResponse {
    constructor(
        public id: number,
        public pregunta: string,
        public respuesta: string,
        public categoria: string
    ) {}
}
