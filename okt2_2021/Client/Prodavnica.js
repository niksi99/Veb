import { Proizvod } from "./Proizvod.js";

export class Prodavnica {

    constructor(Id, Naziv) {
        this.Id = Id;
        this.Naziv = Naziv;

        this.kontejner = null;
        this.proizvodi = [];
    }

    nacrtajProdavnicu() {
        this.kontejner = document.createElement("div");
        this.kontejner.className = "prodavnicaDIV";
        document.body.appendChild(this.kontejner);

        let menuDIV = document.createElement("div");
        menuDIV.className = "menuDIV";
        this.kontejner.appendChild(menuDIV);


        let izmeniDIV = document.createElement("div");
        izmeniDIV.className = "izmeniDIV";
        this.kontejner.appendChild(izmeniDIV);

        this.nacrtajPretragu(menuDIV);
        this.nacrtajIzmenu(izmeniDIV);
        //this.nacrtajTabelu(divZaTabelu);
    }
    
    nacrtajPretragu(host) {

        
        let pretragaDIV = document.createElement("div");
        pretragaDIV.className = "pretragaDIV";
        host.appendChild(pretragaDIV);
        
        let divZaTabelu = document.createElement("div");
        divZaTabelu.className = "divZaTabelu";
        host.appendChild(divZaTabelu);

        let tipDIV = document.createElement("div");
        tipDIV.className = "tipDIV";
        pretragaDIV.appendChild(tipDIV);

        let pretragaLbl = document.createElement("label");
        pretragaLbl.innerHTML = "Pretraga<br/>";
        tipDIV.appendChild(pretragaLbl);

        let tipLbl = document.createElement("label");
        tipLbl.innerHTML = "Tip ";
        tipDIV.appendChild(tipLbl);

        let selectTipovi = document.createElement("select");
        tipDIV.appendChild(selectTipovi);
        
        let nizTipova = [];

        fetch("https://localhost:7291/Prodavnica/PreuzmiTipove/"+this.Id, {
            method: "GET"
        }).then(res => {
            res.json().then(data => {
                data.forEach(n => {
                    nizTipova.push(n);
                    console.log(nizTipova);
                });
                nizTipova.forEach(m => {
                    let opcija = document.createElement("option");
                    opcija.innerHTML = m;
                    opcija.value = m;
                    selectTipovi.appendChild(opcija);
                })
            });
        });
        //CENE
        let ceneOdDoDIV = document.createElement("div");
        ceneOdDoDIV.className = "ceneOdDoDIV";
        pretragaDIV.appendChild(ceneOdDoDIV);
        
        let ceneOdLbl = document.createElement("label");
        ceneOdLbl.innerHTML = "Cene od: ";
        ceneOdDoDIV.appendChild(ceneOdLbl);

        let ceneOdInput = document.createElement("input");
        ceneOdInput.className = "ceneOdInput";
        ceneOdInput.type = "text";
        ceneOdDoDIV.appendChild(ceneOdInput);

        let ceneDoLbl = document.createElement("label");
        ceneDoLbl.innerHTML = "<br>Cene do: ";
        ceneOdDoDIV.appendChild(ceneDoLbl);

        let ceneDoInput = document.createElement("input");
        ceneDoInput.className = "ceneDoInput";
        ceneDoInput.type = "text";
        ceneOdDoDIV.appendChild(ceneDoInput);

        let tabela = document.createElement("table");
        tabela.className = "tabela";
        divZaTabelu.appendChild(tabela);

        let th = document.createElement("thead");
        let niz = ["Ime", "Cena", "Kolicina", " ", " "];
        niz.forEach(n => {
            let el = document.createElement("td");
            el.innerHTML = n;
            th.appendChild(el);
        });

        tabela.appendChild(th);

        let tBody = document.createElement("tbody");
        tabela.appendChild(tBody);

        let prikaziBtn = document.createElement("button");
        prikaziBtn.innerHTML = "Prikazi";
        prikaziBtn.onclick = (ev) => this.PrikaziPodatke(tBody);
        pretragaDIV.appendChild(prikaziBtn);

       
    }

    nacrtajIzmenu(host) {

        let izmenaLbl = document.createElement("label");
        izmenaLbl.innerHTML = "Izmena proizvoda";
        host.appendChild(izmenaLbl);

        let CenaKolicinaDIV = document.createElement("div");
        CenaKolicinaDIV.className = "CenaKolicinaDIV";
        host.appendChild(CenaKolicinaDIV);
        
        let ceneIzmenaLbl = document.createElement("label");
        ceneIzmenaLbl.innerHTML = "Cena ";
        CenaKolicinaDIV.appendChild(ceneIzmenaLbl);

        let ceneIzmenaInput = document.createElement("input");
        ceneIzmenaInput.type = "text";
        CenaKolicinaDIV.appendChild(ceneIzmenaInput);

        let kolicinaIzmenaLbl = document.createElement("label");
        kolicinaIzmenaLbl.innerHTML = "<br>Kolicina ";
        CenaKolicinaDIV.appendChild(kolicinaIzmenaLbl);

        let kolicIzmenaInput = document.createElement("input");
        kolicIzmenaInput.type = "text";
        CenaKolicinaDIV.appendChild(kolicIzmenaInput);

        let sacuvajBtn = document.createElement("button");
        sacuvajBtn.innerHTML = "Sacuvaj";
        //prikaziBtn.onclick = (event) => this.PrikaziIzmene();
        host.appendChild(sacuvajBtn);
    }

    // nacrtajTabelu(host) {
    //     let tabelaDIV = document.createElement("div");
    //     tabelaDIV.className = "tabelaDIV";
    //     host.appendChild(tabelaDIV);

    //     let tabela = document.createElement("table");
    //     tabela.className = "tabela";
    //     tabelaDIV.appendChild(tabela);

    //     let th = document.createElement("thead");
    //     let niz = ["Ime", "Cena", "Kolicna", " ", " "];
    //     niz.forEach(n => {
    //         let el = document.createElement("td");
    //         el.innerHTML = n;
    //         th.appendChild(el);
    //     });

    //     tabela.appendChild(th);

    //     let tBody = document.createElement("tbody");
    //     tabela.appendChild(tBody);
    // }

    PrikaziPodatke(host) {
        host.innerHTML = "";

        this.proizvodi = [];

        //let CenaOd = document.querySelector(".cenaOdInput").value;
       // let cenaDo = document.querySelector(".cenaDoInput").value;
        let tipSelect = document.querySelector("select").value;

        // if(CenaOd === "" && cenaDo === "") {
            fetch("https://localhost:7291/Prodavnica/PreuzmiSveZaProdavnicu/" + this.Id + "/" + tipSelect, {
                method: "GET"
            }).then(res => {
                res.json().then(data => {
                    data.forEach(pr => {
                        let noviProiz = new Proizvod(pr.id, pr.ime, pr.tip, pr.kolicina, pr.cena);
                        pr.roditelj = this;
                        this.proizvodi.push(noviProiz);
                    });
                    this.proizvodi.forEach(p => {
                        p.nacrtajProizvod(host);
                    });
                });
            });
        //}


    }

   

    
}