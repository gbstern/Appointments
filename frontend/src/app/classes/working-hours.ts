export class WorkingHours {
    constructor(
        public id : number,
        public doctorId : string,
        public day : number,
        public startTime : string,
        public endTime : string
    ){}
}
