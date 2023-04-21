import { Grad } from "./Grad.js";
import { Podatak } from "./Podatak.js";

let nizGradova = [];

function prikaziGradove() {
    nizGradova.forEach(p => {
        p.crtajGrad();
    })
}

function ucitajGradovi() {
    fetch("https://localhost:7257/Grad/PreuzmiGrad", {
            method: "GET"
        }).then(res => {
            res.json().then(data => {
                data.forEach(g => {
                    var noviGrad = new Grad(g.id, g.naziv, g.x, g.y);
                    noviGrad.podaci.forEach(p => {
                        var noviPodatak = new Podatak(p.Id, p.prosecnaDnevnaTemperatura, p.kolicinaPadavina, p.brojSuncanihDana, p.mesec);
                        noviPodatak.Grad = noviGrad;
                        noviGrad.podaci.push(noviPodatak);
                        console.log(noviPodatak);
                    });
                    nizGradova.push(noviGrad);
                    console.log(nizGradova);
                });
                prikaziGradove();
            });
        });
}

ucitajGradovi();



