import { Persona } from "./persona";
import { Rol } from "./rol";

export class Usuario {
    constructor(
        public readonly Id: number,
        public PersonaId: number,
        public readonly Persona: Persona,
        public readonly Movil: string,
        public readonly Login: string,
        public readonly Clave: string,
        public readonly Pin: string,
        public readonly Mail: string,
        public readonly FotoPerfilUrl: string,
        public readonly FechaUltimoInicioSesion: Date | null,
        public readonly UsuarioEstadoId: number,
        public readonly IntentosFallidosClave: number,
        public readonly MotivoBloqueo: string,
        public readonly AceptaCondiciones: boolean,
        public readonly DebeCambiarClave: boolean,
        public Bloqueado: boolean,
        public Activo: boolean,
        public readonly Roles: Rol[],        
       
    ) { }
}

export class Direccion {
    calle: string;
    numero: number;
    ciudad: string;
    pais: string;
}
