export class Persona {
    constructor(
        public readonly Id: number,
        public readonly Nombre: string,
        public readonly Apellido: string,
        public readonly NroDocumento: string,
        public readonly TipoDocumentoNombre: string,
        public readonly TipoDocumentoId: number | null,
        public FechaNacimiento: Date | null,
        public readonly Cuit: number,
        public readonly MailContacto: string,
        public MovilContacto: string,
        public  Activo: boolean,
        public FotoDniFrenteUrl: string,
        public FotoDniDorsoUrl: string,
        public FotoSelfieUrl: string
    ) { }
}

export class SavePersonaDto {
    constructor(
        public readonly Id: number,
        public readonly Nombre: string,
        public readonly Apellido: string,
        public readonly TipoDocumentoId: number,
        public readonly NroDocumento: string,
        public readonly Cuit: string,
        public readonly FechaNacimiento: Date,
        public readonly Activo: boolean,
        public readonly FotoDniFrenteBase64: string,
        public readonly FotoDniFrenteExtension: string,
        public readonly FotoDniDorsoBase64: string,
        public readonly FotoDniDorsoExtension: string,
        public readonly FotoSelfieBase64: string,
        public readonly FotoSelfieExtension: string
    ) { }
}

export class SearchPersonaRequestDto {
    constructor(
        public readonly PageSize: number | null,
        public readonly PageNumber: number | null,
        public readonly OrderAscending: boolean | null,
        public readonly OrderFieldName: string,
        public readonly Nombre: string,
        public readonly Apellido: string,
        public readonly TipoDocumentoId: number | null,
        public readonly NroDocumento: string,
        public readonly Cuit: number,
        public readonly MailContacto: string,
        public readonly MovilContacto: string,
        public readonly VerSoloActivos: boolean,
        public readonly VerSoloConUsuarios: boolean
    ) { }
}

export class SearchPersonaResponseDto {
    constructor(
        public readonly count: number,
        public readonly result: Persona[]
    ) { }
}

export class DialogPersonaSearchComponentRequestDto {
    constructor(
        public readonly AllowMultipleSelection: boolean,
        public readonly MaxItemSelection: number
    ) { }
}

export class DialogPersonaSearchComponentResponseDto {
    constructor(
        public readonly Cancelled: boolean,
        public readonly Items: Persona[]
    ) { }
}

export class SavePersonVerificationImageRequestDto {
    constructor(
        public readonly PersonaId: number,
        public readonly TipoFoto: string,
        public readonly FotoBase64: string,
        public readonly FotoExtension: string
    ) { }
}