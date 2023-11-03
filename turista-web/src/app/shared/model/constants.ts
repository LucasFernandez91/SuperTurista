export abstract class LocalStorageKeys {
  static readonly Token: string = "token";
  static readonly Menu: string = "menu";
  static readonly Usuario: string = "usuario";
  static readonly HomeVerBalance: string = "HomeVerBalance";
}

export abstract class SignalRConstants {
  static readonly RetriesArray: [2000, 10000, 30000, 60000];
}

export abstract class GridPageSettings {
  static readonly PageSizeList: number[] = [5, 10, 15];
  static readonly PageCount: number = 10;
}

export abstract class EstadoConstants {
  static readonly ESTADO_USUARIO_NUEVO: number = 1;
  static readonly ESTADO_USUARIO_PENDIENTE: number = 2;
  static readonly ESTADO_USUARIO_APROBADO: number = 3;
  static readonly ESTADO_USUARIO_RECHAZADO: number = 4;

  static readonly ESTADO_MOVIMIENTO_PENDIENTE: number = 5;
  static readonly ESTADO_MOVIMIENTO_RECHAZADO: number = 6;
  static readonly ESTADO_MOVIMIENTO_APROBADO: number = 7;
  static readonly ESTADO_MOVIMIENTO_ERROR: number = 8;
  static readonly ESTADO_MOVIMIENTO_ACREDITADO: number = 9;

  static readonly ESTADO_INCIDENCIA_PEND_REV: number = 10;
  static readonly ESTADO_INCIDENCIA_EN_REVISION: number = 11;
  static readonly ESTADO_INCIDENCIA_CERRADA: number = 12;
}

export class MedioPagoConstants {
  static readonly Efectivo: number = 1;
  static readonly TransferenciaBancaria: number = 2;
  static readonly TransferenciaCrypto: number = 5;
  static readonly Tc: number = 3;
  static readonly Td: number = 4;
}

export class TipoMovimientoConstants {
  static readonly Ingreso: number = 1;
  static readonly Egreso: number = 2;
}

export class TipoMonedaConstants {
  static readonly Wallet: number = 1;
  static readonly Bancarizada: number = 2;
}

export abstract class MensajeUsuarioOpcionEnvioConstants {
  static readonly ROL: number = 1;
  static readonly USUARIO: number = 2;
  static readonly TODOS: number = 3;
}

export abstract class VisualizarCuentasConstants {
  static readonly VER_TODOS: number = 1;
  static readonly VER_SOLO_BUNCH: number = 2;
  static readonly VER_NO_BUNCH: number = 3;
}

export abstract class MenuFuncionCodes {
  static readonly HOME: string = "HOME";
  static readonly ADMIN: string = "ADMIN";
  static readonly PROC: string = "PROC";
  static readonly USER_LIST: string = "USER_LIST";
  static readonly USER_EDIT: string = "USER_EDIT";
  static readonly ROL_LIST: string = "ROL_LIST";
  static readonly ROL_EDIT: string = "ROL_EDIT";
  static readonly ESTADO_LIST: string = "ESTADO_LIST";
  static readonly ESTADO_EDIT: string = "ESTADO_EDIT";
  static readonly MENU_LIST: string = "MENU_LIST";
  static readonly MENU_EDIT: string = "MENU_EDIT";
  static readonly PARAM_SISTEMA_LIST: string = "PARAM_SISTEMA_LIST";
  static readonly PARAM_SISTEMA_EDIT: string = "PARAM_SISTEMA_EDIT";
  static readonly MENSAJE_USUARIO_LIST: string = "MENSAJE_USUARIO_LIST";
  static readonly MENSAJE_USUARIO_EDIT: string = "MENSAJE_USUARIO_EDIT";
  static readonly MENSAJE_USUARIO_TIPO_LIST: string = "MENSAJE_USUARIO_TIPO_LIST";
  static readonly MENSAJE_USUARIO_TIPO_EDIT: string = "MENSAJE_USUARIO_TIPO_EDIT";
  static readonly MENSAJE_USUARIO_OPC_ENVIO_LIST: string = "MENSAJE_USUARIO_OPC_ENVIO_LIST";
  static readonly MENSAJE_USUARIO_OPC_ENVIO_EDIT: string = "MENSAJE_USUARIO_OPC_ENVIO_EDIT";
  static readonly INCIDENCIA_USUARIO_LIST: string = "INCIDENCIA_USUARIO_LIST";
  static readonly INCIDENCIA_USUARIO_EDIT: string = "INCIDENCIA_USUARIO_EDIT";
  static readonly MAIL_CONFIGURACION_LIST: string = "MAIL_CONFIGURACION_LIST";
  static readonly MAIL_CONFIGURACION_EDIT: string = "MAIL_CONFIGURACION_EDIT";
  static readonly ROL_TIPO_LIST: string = "ROL_TIPO_LIST";
  static readonly ROL_TIPO_EDIT: string = "ROL_TIPO_EDIT";
  static readonly FAQ_LIST: string = "FAQ_LIST";
  static readonly FAQ_EDIT: string = "FAQ_EDIT";
  static readonly INGRESO_FONDOS: string = "INGRESO_FONDOS";
  static readonly EGRESO_FONDOS: string = "EGRESO_FONDOS";
  static readonly MIS_CUENTAS_BANCARIAS_LIST: string = "MIS_CUENTAS_BANCARIAS_LIST";
  static readonly MIS_MOVIMIENTOS_LIST: string = "MIS_MOVIMIENTOS_LIST";
  static readonly PLANUSUARIO_LIST: string = "PLANUSUARIO_LIST"
  static readonly PLANUSUARIO_EDIT: string = "PLANUSUARIO_EDIT"
}