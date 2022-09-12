import { Red } from "./red.js"
import { Proizvod } from "./proizvod.js";
import { Skladiste } from "./skladiste.js"
import { SProizvod } from "./sproizvod.js";

export class Supermarket
{
    constructor(id, grad, ime)
    {
        this.redovi = [];
        this.skladista = [];
        this.id=id;
        this.grad=grad;
        this.ime=ime;
        this.container = null;
        this.rContainer = null; 
        this.sContainer = null; 
    }

}