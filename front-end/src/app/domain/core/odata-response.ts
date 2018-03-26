export class OdataResponse {
    constructor(
        public items: any,
        public nextPageLink: any,
        public count: number
    ) { }
}
