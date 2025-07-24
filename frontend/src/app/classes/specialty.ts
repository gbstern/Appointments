import { Doctor } from "./doctor";

export class Specialty {
    constructor(
        public id : number,
        public specialty : string,
        public doctors : Doctor[]
    ){}
}
