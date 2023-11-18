export class LoginRequest {
    constructor(
        public UserName: string,
        public Clave: string,
    ) { }
}

export class RegisterRequest {
    constructor(
        public Nombre: string,
        public Apellido: string,
        public Telefono: string,
        public Login: string,
        public Email: string,
        public Password: string,
        public ConfirmPassword: string,
    ) { }
}