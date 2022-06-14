import {Client} from "./client";

class InvestManagerClient extends Client{
    constructor() {
        super("https://localhost:5001");
    }
}

export const client = new InvestManagerClient();