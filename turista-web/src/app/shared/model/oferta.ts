export class Oferta {
    id: number;
    titulo: string;
    descripcion: string;
    precio: number;
    destaque: boolean;
    imagenes: Array<string>;
    anunciante: Anunciante;
    categoria: Categoria;
}

export class Anunciante {
    id: number;
    nome: string;
    email: string;
    telefone: string;
    imageUrl: string;
}

export class Categoria {
    id: number;
    descricao: string;
}
