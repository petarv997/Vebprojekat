import { Proizvod } from "./proizvod.js"

export class Red
{
    constructor(id, kategorija, broj)
    {
        this.proizvodi = [];
        this.id = id;
        this.kategorija = kategorija;
        this.broj = broj;
        this.container = null; 
        this.prContainer = null;    
    }

    GetRow(host){
        var tr=document.createElement("tr");
        host.appendChild(tr);

        var el=document.createElement("td");
        el.innerHTML=this.kategorija;
        tr.appendChild(el);

        var el=document.createElement("td");
        el.innerHTML=this.broj;
        tr.appendChild(el);
    }
}