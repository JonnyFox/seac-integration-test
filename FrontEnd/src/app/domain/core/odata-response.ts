export class OdataResponse {
  constructor(
    public items: any,
    public nextPageLink: any, // string?
    public count: number
  ) { }
}
