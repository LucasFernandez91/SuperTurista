export class Usuario {
    id: number;
    nombre: string;
    correo: string;
    contrasena: string;
    fechaNacimiento: Date;
    direccion: Direccion;
}

export class Direccion {
    calle: string;
    numero: number;
    ciudad: string;
    pais: string;
}
