import { Supermarket } from "./supermarket.js"
import { Red } from "./red.js"
import { Proizvod } from "./proizvod.js";
import { Skladiste } from "./skladiste.js"
import { SProizvod } from "./sproizvod.js";
import { Lanac } from "./lanac.js";

var listaMarketa=[];

fetch("https://localhost:5001/Supermarket/Preuzmi")
.then(p=>{
    p.json().then(smarketi=>{
        smarketi.forEach(sm => {
            console.log(sm);
            var m = new Supermarket(sm.id, sm.grad, sm.ime);
            listaMarketa.push(m);
        });
        fetch("https://localhost:5001/Supermarket/PreuzmiRedove")
.then(p=>{
    p.json().then(redovi=>{
        redovi.forEach(row => {
            console.log(row);
            var r = new Red(row.kategorija, row.id, row.broj);
            listaRedova.push(r);
        });   
        fetch("https://localhost:5001/Supermarket/PreuzmiSkladista")
        .then(p=>{
            p.json().then(skladista=>{
                skladista.forEach(skl => {
                    console.log(skl);
                    var s = new Skladiste(skl.velicina, skl.id, skl.broj);
                    listaSkladista.push(s);
                });
                var l = new Lanac(listaMarketa,listaRedova,listaSkladista);
                l.crtaj(document.body);
    })
})      
    })
})
    })
})
console.log(listaMarketa);

var listaRedova=[];

console.log(listaRedova);


var listaSkladista=[];

console.log(listaSkladista);

