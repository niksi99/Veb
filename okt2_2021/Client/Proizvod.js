export class Proizvod {

    constructor(Id, Ime, Tip, Kolicina, Cena) {
        this.Id = Id;
        this.Ime = Ime;
        this.Tip = Tip;
        this.Kolicina = Kolicina;
        this.Cena = Cena;

        this.kontejner = null;
        this.roditelj = null;
    
    }

    nacrtajProizvod(host) {
        this.kontejner = document.createElement("tr");

        let niz = [
            this.Ime, this.Cena, this.Kolicina
        ];
        let el;
        niz.forEach(n => {
            el = document.createElement("td");
            el.innerHTML = n;
            this.kontejner.appendChild(el);
        });

        el = document.createElement("td");
        let izmeniBtn = document.createElement("button");
        izmeniBtn.innerHTML = "izmeni";
        izmeniBtn.onclick = (event) => this.prikazZaZamenu();
        el.appendChild(izmeniBtn);
        this.kontejner.appendChild(el);

        el = document.createElement("td");
        let korpaBtn = document.createElement("button");
        korpaBtn.innerHTML = "korpa";
        korpaBtn.onclick = (event) => this.prikazZaZamenu();
        el.appendChild(korpaBtn);
        this.kontejner.appendChild(el);

        host.appendChild(this.kontejner);
        
    }
}

