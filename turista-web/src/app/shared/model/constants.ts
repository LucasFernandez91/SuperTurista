export abstract class LocalStorageKeys {
    static readonly Token: string = "token";
    static readonly Menu: string = "menu";
    static readonly Usuario: string = "usuario";
    static readonly TenantId: string = "tenantId";
    static readonly NamesToReplace: string = "namesToReplace";
  }  
  export abstract class SignalRConstants {
    static readonly RetriesArray: [2000, 10000, 30000, 60000];
  }
  
  export abstract class GridPageSettings {
    static readonly PageSizeList: number[] = [5, 10, 15];
    static readonly PageCount: number = 10;
  }