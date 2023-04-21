import { VideoKlub } from "./VideoKlub.js";
import { Polica } from "./Polica.js"

let VideoKlubovi = [];

function preuzmiVideoKlubove() {
    fetch("https://localhost:7254/VideoKlub/PrikaziSveVK", {
        method: "GET"
    }).then(response => {
        response.json().then(data =>{
            data.forEach(dodajVK => {
                let noviVideoKlub = new VideoKlub(dodajVK.id, dodajVK.naziv);
                console.log(noviVideoKlub);
                VideoKlubovi.push(noviVideoKlub);
                noviVideoKlub.police.forEach(dodajPolicu => {
                    let novaPolica = new Polica(dodajPolicu.id, dodajPolicu.oznaka, dodajPolicu.maxBrDVDs, dodajPolicu.trenutnoDVDs);
                    console.log(novaPolica);
                    noviVideoKlub.police.push(novaPolica);
                }) 
                console.log(VideoKlubovi);
            });
            VideoKlubovi.forEach(vk => {
                vk.nacrtajVK();
            });
        });
    });
}

// function preuzmiKlubov1(){

//     fetch("https://localhost:7254/VideoKlub/PrikaziSveVK", {
//         method:"GET"
//     }).then(data=> {
//         data.json().then(info=>{
//             info.forEach(vk=>{
//                 let vidk=new VideoKlub(vk.id, vk.naziv);
//                 vk.police.forEach(p=>{
//                     let pol=new Polica(p.id, p.oznaka, p.maxDiskova, p.trenutnoDiskova);
//                     vidk.Police.push(pol);
//                 });
//                 Klubovi.push(vidk);
//             });
//             Klubovi.forEach(k=>{
//                 k.iscrtajKlub();
//             });
//         });
//     });
// }

preuzmiVideoKlubove();