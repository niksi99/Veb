import { Polica  } from "./Polica.js";

export class VideoKlub {

    constructor (id, naziv) {
        this.id = id;
        this.naziv = naziv;

        this.police = [];
        this.kontejner = null;
    }

    nacrtajVK() {
        this.kontejner = document.createElement("div");
        this.kontejner.className = "videoKlub";
        document.body.appendChild(this.kontejner);
        
        let imeLbl = document.createElement("label");
        imeLbl.className = "imeLebela";
        imeLbl.innerHTML = this.naziv;
        this.kontejner.appendChild(imeLbl);

        let prikazAplikacije = document.createElement("div");
        prikazAplikacije.className = "aplikacija";
        this.kontejner.appendChild(prikazAplikacije);

        let menuDiv = document.createElement("div");
        menuDiv.className = "menuDiv";
        prikazAplikacije.appendChild(menuDiv);

        let divZaPolice = document.createElement("div");
        divZaPolice.className = "prikazPolica";
        prikazAplikacije.appendChild(divZaPolice);

        this.nacrtajMenuDIV(menuDiv);
        this.nacrtajPolice(divZaPolice);
    }

    nacrtajMenuDIV(host) {
        let nizOznaka = [];
        let nizIDs = [];

        fetch("https://localhost:7254/VideoKlub/PreuzmiOznakePolica/+"+this.id, {
        method: "GET"
    }).then(res => {
        res.json().then(data => {
            data.forEach(element => {
               nizOznaka.push(element.oznaka);
               nizIDs.push(element.id); 
            });

            nizOznaka.forEach((ozn, index) => {
                let red = document.createElement("div");
                let rdBtn = document.createElement("input");
                rdBtn.type = "radio";
                rdBtn.name = this.naziv;
                rdBtn.value = nizIDs[index];
                red.appendChild(rdBtn);

                let lbl=document.createElement("label");
                lbl.innerHTML=ozn;
                red.appendChild(lbl);
                host.appendChild(red);
            });

            let red = document.createElement("div");
            let lbl = document.createElement("label");
            lbl.innerHTML = "broj DVD-eva";
            red.appendChild(lbl);
            host.appendChild(red);

            let tbx=document.createElement("input");
            tbx.type="text";
            host.appendChild(tbx);

            let btn=document.createElement("button");
            btn.innerHTML="Dodaj na policu";
            btn.onclick=(ev)=>this.dodajDiskove();
            host.appendChild(btn);
        });
    })
    }

    nacrtajPolice(host) {
        let divZaPolice = document.createElement("div");
        divZaPolice.className = "prikazPolica";
        this.police.forEach(pol => {
            pol.nacrtajPolicu(divZaPolice);
        });

        host.appendChild(divZaPolice);
    }

    dodajDiskove() {
        let dodaj = this.kontejner.querySelector("input[type=radio]:checked");

        if(dodaj == null) {
            alert("Nisi pritiso radio button");
            return;
        }

        let Id = dodaj.value;

        let text = this.kontejner.querySelector("input[type=text]").value;
        let broj = parseInt(text);

        if(isNaN(broj)) {
            alert("Mora uneses br");
            return;
        }
    }
}