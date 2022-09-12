export class Proizvod
{
    constructor(ID, naziv, cena, kolicina)
    {
        this.ID = ID;
        this.naziv = naziv;   
        this.cena = cena;
        this.kolicina = kolicina;
        this.container = null;
        this.rreedd = null;       
    }

    GetProizvod(host){
        var tr=document.createElement("tr");
        host.appendChild(tr);

        var el=document.createElement("td");
        el.innerHTML=this.naziv;
        tr.appendChild(el);

        var el=document.createElement("td");
        el.innerHTML=this.cena;
        tr.appendChild(el);

        this.kolicinael=document.createElement("td");
        this.kolicinael.innerHTML=this.kolicina;
        tr.appendChild(this.kolicinael);

        var el=document.createElement("td");
        tr.appendChild(el);

        var but=document.createElement("button");
        but.innerHTML="Kupi";
        el.appendChild(but);
        but.onclick=(ev)=>{
            this.Kupi();
        }

        var but2=document.createElement("button");
        but2.innerHTML="Dodaj";
        el.appendChild(but2);
        but2.onclick=(ev)=>{
            this.Add();
        }
    }
    Kupi()
    {
        fetch("https://localhost:5001/Supermarket/KupiProizvod/" + this.ID,
        {
            method:"POST"
        }
        )
        .then(s=>{
            console.log(s);
            if(s.ok){
                this.kolicina--;
                this.kolicinael.innerHTML=this.kolicina;
            }
        })
    }
    Add()
    {
        fetch("https://localhost:5001/Supermarket/DodajProizvod/" + this.ID,
        {
            method:"POST"
        }
        )
        .then(s=>{
            console.log(s);
            if(s.ok){
                this.kolicina++;
                this.kolicinael.innerHTML=this.kolicina;
            }
        })
    }
}