export class Vehiculo {
    marca: string;
    modelo: string;
    anio: number;
    precio: number;
    descripcion: string;
    imagen: string;

    constructor(marca: string, modelo: string, anio: number, precio: number, descripcion: string, imagen: string) {
        this.marca = marca;
        this.modelo = modelo;
        this.anio = anio;
        this.precio = precio;
        this.descripcion = descripcion;
        this.imagen = imagen;
    }
}

export class Moto extends Vehiculo {
    cilindrada: number;

    constructor(marca: string, modelo: string, anio: number, precio: number, descripcion: string, imagen: string, cilindrada: number) {
        super(marca, modelo, anio, precio, descripcion, imagen);
        this.cilindrada = cilindrada;
    }
}

export class Auto extends Vehiculo {
    puertas: number;

    constructor(marca: string, modelo: string, anio: number, precio: number, descripcion: string, imagen: string, puertas: number) {
        super(marca, modelo, anio, precio, descripcion, imagen);
        this.puertas = puertas;
    }
}
