import { SProizvod } from "./sproizvod.js"

export class Skladiste
{
    constructor(velicina, id, broj)
    {
        this.sproizvodi = [];
        this.velicina = velicina;
        this.id = id;
        this.broj = broj;
        this.container = null; 
        this.sprContainer = null;    
    }

    
}