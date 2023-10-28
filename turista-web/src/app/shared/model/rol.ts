export class Rol {
    constructor(
      public readonly Id: number,
      public readonly Codigo: string,
      public readonly Nombre: string,
      public readonly Activo: boolean,
      public readonly EsDefaultParaAltas: boolean,
      public readonly RolTipoId: number,
      public readonly RolTipoNombre: string,
      public readonly TenantId: number,
      public readonly Funciones: RolMenuFuncion[],
      public readonly TiposMensaje: RolMensajeUsuarioTipo[],
      public readonly OpcionesEnvioMensaje: RolMensajeUsuarioOpcionEnvio[]
    ) {}
  }
  
  export class RolMenuFuncion {
    constructor( 
      public readonly RolId: number, 
      public readonly MenuFuncionId: number,
      public readonly Id: number
    ){}
  }
  
  export class RolMensajeUsuarioTipo {
    constructor( 
      public readonly RolId: number, 
      public readonly MensajeUsuarioTipoId: number,  
      public readonly Id: number
    ){}
  }
  
  export class RolMensajeUsuarioOpcionEnvio {
    constructor( 
      public readonly RolId: number, 
      public readonly MensajeUsuarioOpcionEnvioId: number,
      public readonly Id: number
    ){}
  }
  
  export class SearchRolRequest {
    constructor(
      public readonly PageSize: number | null,
      public readonly PageNumber: number | null,
      public readonly OrderAscending: boolean | null,
      public readonly OrderFieldName: string,
      public readonly Nombre: string,
      public readonly Codigo: string,
      public readonly TenantId: number,
      public readonly VerSoloActivos: boolean | null
    ) {}
  }
  
  export class SearchRolResponse {
    constructor(
      public readonly count: number,
      public readonly result: Rol[]
    ) {}
  }
  
  export class SaveRolDto { 
    constructor(
      public readonly Id: number,
      public readonly Codigo: string,
      public readonly Nombre: string,
      public readonly RolTipoId: number,
      public readonly EsDefaultParaAltas: boolean,
      public readonly Activo: boolean,
      public readonly Menues: number[],
      public readonly OpcionesEnvioMensaje: number[],
      public readonly TiposMensaje: number[]
    ) {}
  }