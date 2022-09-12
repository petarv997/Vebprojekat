import { Supermarket } from "./supermarket.js"
import { Proizvod } from "./proizvod.js"
import { Red } from "./red.js"

export class Lanac
{
    constructor(listaMarketa, listaRedova, listaSkladista)
    {
        this.listaMarketa=listaMarketa;
        this.listaRedova=listaRedova;
        this.listaSkladista=listaSkladista;
        this.kontejner=null;
        this.listk=[];
    }

    crtaj(host)
    {
        if(!host)
        throw new Error("Host nije definisan");

        const naslov = document.createElement("div");
        naslov.className = "naslov";
        naslov.innerHTML = "Supermarket";
        host.appendChild(naslov);

        this.kontejner = document.createElement("div");
        this.kontejner.className = "MainKontejner";
        host.appendChild(this.kontejner);

        let kontejnerForma=document.createElement("div");
        kontejnerForma.className="Forma";
        this.kontejner.appendChild(kontejnerForma);


        let zaTabele=document.createElement("div");
        zaTabele.className="zaTabele";
        this.kontejner.appendChild(zaTabele);



        let kTabela=document.createElement("div");
        kTabela.className="KTForma";
        zaTabele.appendChild(kTabela);

        /*let kontejnerTabela=document.createElement("div");
        kontejnerTabela.className="TForma";
        kTabela.appendChild(kontejnerTabela);*/



        let rTabela=document.createElement("div");
        rTabela.className="KRForma";
        zaTabele.appendChild(rTabela);

        let kontejnerRed=document.createElement("div");
        kontejnerRed.className="RForma";
        rTabela.appendChild(kontejnerRed);



        let kontejnerProizvod=document.createElement("div");
        kontejnerProizvod.className="PForma";
        zaTabele.appendChild(kontejnerProizvod);



        this.crtajFormu(kontejnerForma);
        /*this.crtajTabelu(kontejnerTabela);*/
        this.crtajRedove(kontejnerRed);
        this.crtajProizvode(kontejnerProizvod);
    }
    
    crtajRed(host){
        let red=document.createElement("div");
        red.className="red";
        host.appendChild(red);
        return red;
    }

    crtajFormu(host){
        let red=this.crtajRed(host);
        let l=document.createElement("label");
        l.className="marketi";
        l.innerHTML="Marketi";
        red.appendChild(l);

        
        let sE=document.createElement("select");
        sE.className="sE";
        red.appendChild(sE);

        let op;
        this.listaMarketa.forEach(sm=>{
            op=document.createElement("option");
            op.innerHTML=sm.ime;
            op.value=sm.id;
            sE.appendChild(op);
        });

        let btnRed=document.createElement("button");
        btnRed.innerHTML="Nadji Red";
        btnRed.onclick=(ev)=>this.SortRow();
        red.appendChild(btnRed);

        red=this.crtajRed(host);
        red.className="ovajred";
        let l2=document.createElement("label");
        l2.className="reds";
        l2.innerHTML="Redovi";
        red.appendChild(l2);

        let rsE=document.createElement("select");
        rsE.className="rsE";
        red.appendChild(rsE);


        let rop;
        this.listaRedova.forEach(rsm=>{
            rop=document.createElement("option");
            rop.innerHTML=rsm.id;
            rop.value=rsm.kategorija;
            rsE.appendChild(rop);
        });

        


        
        red=this.crtajRed(host);
        red.className="onajred";


        let btnIzlistaj=document.createElement("button");
        btnIzlistaj.className="Izlistaj";
        btnIzlistaj.innerHTML="Izlistaj Proizvode";
        btnIzlistaj.onclick=(ev)=>this.Razvrstaj();
        red.appendChild(btnIzlistaj);


        red=this.crtajRed(host);

        let sdiv=document.createElement("div");
        red.appendChild(sdiv);

        let sskl=document.createElement("label");
        sskl.innerHTML="Skladista";
        sskl.className="Skladista";
        sdiv.appendChild(sskl);

        let ssE=document.createElement("select");
        sdiv.appendChild(ssE);

        let sop;
        this.listaSkladista.forEach(ssm=>{
            sop=document.createElement("option");
            sop.innerHTML=ssm.broj;
            sop.value=ssm.id;
            ssE.appendChild(sop);
        });
        red=this.crtajRed(host);

        let btnFind=document.createElement("button");
        btnFind.className="find";
        btnFind.innerHTML="Pronadji";
        btnFind.onclick=(ev)=>this.Find();
        red.appendChild(btnFind);

        let btnMove=document.createElement("button");
        btnMove.innerHTML="Premesti";
        btnMove.onclick=(ev)=>this.Move();
        red.appendChild(btnMove);
    }

    Razvrstaj()
    {
        let prEl = this.kontejner.querySelector("select");
        var tID = prEl.options[prEl.selectedIndex].value;
        console.log(tID);

        this.Izlistaj();
    }
    Izlistaj()
    {
        fetch("https://localhost:5001/Supermarket/PreuzmiProizvode/")
        .then(s=>{
            console.log(s);
            if(s.ok){
                s.json().then(arrayData=>{
                    this.tableBody.innerHTML="";  
                    arrayData.forEach(data=>{
                        console.log(data);
                        let pr=new Proizvod(data.id, data.naziv, data.cena, data.kolicina);
                        pr.GetProizvod(this.tableBody);
                    })
                })
            }
        })
    }
    
    SortRow()
    {
        let opEl = this.kontejner.querySelector("select");
        var smID = opEl.options[opEl.selectedIndex].value;
        console.log(smID);

        this.findRow(smID);
    }

    findRow(smID)
    {
        fetch("https://localhost:5001/Supermarket/PreuzmiOdrRedove/" + smID,
        )
        .then(s=>{
            console.log(s);
            if(s.ok){
                s.json().then(arrayData=>{
                    this.RtableBody.innerHTML="";
                    arrayData.forEach(data=>{
                        console.log(data);
                        let rr=new Red(data.id, data.broj, data.kategorija);
                        rr.GetRow(this.RtableBody);
                    })
                })
            }
        })
    }

    /*crtajTabelu(host){

        let contDisplay=document.createElement("div");
        contDisplay.className="Display";
        host.appendChild(contDisplay);

        var table=document.createElement("table");
        table.className="table";
        contDisplay.appendChild(table);

        var tableHead=document.createElement("thead");
        table.appendChild(tableHead);

        var tr=document.createElement("tr");
        tableHead.appendChild(tr);

        var tableBody=document.createElement("tbody");
        tableBody.className="TableData";
        table.appendChild(tableBody);

        let th;
        var zag=['Ime','Grad'];
        zag.forEach(el=>{
            th=document.createElement("th")
            th.innerHTML=el;
            tr.appendChild(th);
        })
    } */

    crtajRedove(host){

        let contDisplay=document.createElement("div");
        contDisplay.className="Display";
        host.appendChild(contDisplay);

        var table=document.createElement("table");
        table.className="table";
        contDisplay.appendChild(table);

        var tableHead=document.createElement("thead");
        table.appendChild(tableHead);

        var tr=document.createElement("tr");
        tableHead.appendChild(tr);

        this.RtableBody=document.createElement("tbody");
        this.RtableBody.className="TableData";
        table.appendChild(this.RtableBody);

        let th;
        var zag=['Broj','Kategorija'];
        zag.forEach(el=>{
            th=document.createElement("th")
            th.innerHTML=el;
            tr.appendChild(th);
        })
    }

    crtajProizvode(host){

        let contDisplay=document.createElement("div");
        contDisplay.className="Display";
        host.appendChild(contDisplay);

        var table=document.createElement("table");
        table.className="table";
        contDisplay.appendChild(table);

        var tableHead=document.createElement("thead");
        table.appendChild(tableHead);

        var tr=document.createElement("tr");
        tableHead.appendChild(tr);

        this.tableBody=document.createElement("tbody");
        this.tableBody.className="TableData";
        table.appendChild(this.tableBody);

        let th;
        var zag=['Naziv','Cena','Kolicina','Akcija'];
        zag.forEach(el=>{
            th=document.createElement("th")
            th.innerHTML=el;
            tr.appendChild(th);
        })
    }
}