import { Prodavnica } from "./Prodavnica.js";


    // let p1 = new Prodavnica(1, "Ja");
    // p1.nacrtajProdavnicu();

    // let hr = document.createElement("hr");
    // document.body.appendChild(hr);

    // let p2 = new Prodavnica(2, "Ti");
    // p2.nacrtajProdavnicu();

     let nizProdavnica = [];

    function iscrtajProdavnice() {
        nizProdavnica.forEach(pr => {
            pr.nacrtajProdavnicu();
        });
    }

    fetch("https://localhost:7291/Prodavnica/PrikaziProdavnice", {
        method: "GET",
    }).then(res => {
        res.json().then(data => {
            data.forEach(p => {
                var novaProdavnica = new Prodavnica(p.id, p.naziv);
                nizProdavnica.push(novaProdavnica);
                console.log(novaProdavnica);
            });
            iscrtajProdavnice();
        });
    });


