export class DialogTextoLibreRequest {
  constructor(
    public readonly Title: string,
    public readonly Message: string,
    public readonly ButtonTextAccept: string,
    public readonly ButtonTextCancel: string
  ) {}
}


export class DialogTextoLibreResponse {
  constructor(
    public readonly Result: string,
    public readonly Cancelled: boolean
  ) {}
}

export class DialogConfirmRequest {
  constructor(
    public readonly Title: string,
    public readonly Message: string,
    public readonly ButtonTextAccept: string,
    public readonly ButtonTextCancel: string,
    public readonly Message2?: string,
  ) {}
}
export class DialogConfirmRequest2 {
  constructor(
    public readonly Title: string,
    public readonly Message: string,
    public readonly Message2: string,
    public readonly ButtonTextAccept: string,
    public readonly ButtonTextCancel?: string

   
  ) {}
}


export class DialogConfirmResponse {
  constructor(
    public readonly Accepted: boolean
  ) {}
}

