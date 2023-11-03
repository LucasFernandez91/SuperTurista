export class Usuario {
    id: number;
    nombre: string;
    correo: string;
    contrasena: string;
    fechaNacimiento: Date;
    direccion: Direccion;
    Login: string;
}

export class Direccion {
    calle: string;
    numero: number;
    ciudad: string;
    pais: string;
}

export class DialogPinRequestDto {
    constructor(
        public UsuarioId: number,
        public Pin: string
    ){}
}

export class DialogPinResponseDto {
    constructor(
        public EsValido: boolean,
        public Pin: string,
        public UsuarioCancelo: boolean
    ){}
}

export class ValidateRegistroLargoDto {
    constructor(
        public RegistroOk: boolean,
        public DatosCargados: boolean
    ){}
}
export class ChangePasswordDto {
    constructor(
        public UsuarioId: number,
        public ClaveActual: string,
        public ClaveNueva: string
    ){}
}
