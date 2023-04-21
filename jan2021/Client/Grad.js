export class Grad {

    constructor(Id, Naziv, x, y) {
        this.Id = Id;
        this.X = x;
        this.Y = y;
        this.Naziv = Naziv;
        this.kontejner = null;
        this.podaci = [];
    }

    crtajGrad() {
        this.kontejner = document.createElement("div");
        this.kontejner.className = "prikazGrada";
        document.body.appendChild(this.kontejner);

        let naslovKontejner = document.createElement("div");
        naslovKontejner.className = "naslovKont";

        
        naslovKontejner.innerHTML = "Grad: " + this.Naziv +"(";
        if(this.X > 0) 
            naslovKontejner.innerHTML += this.X + "°E, ";
        else
            naslovKontejner.innerHTML += Math.abs(this.X) + "°W ";
        
        if(this.Y > 0) 
            naslovKontejner.innerHTML += this.Y + "°N, ";
        else
            naslovKontejner.innerHTML += Math.abs(this.Y) + "°S ";
        
        naslovKontejner.innerHTML += "godina 2020.";

        this.kontejner.appendChild(naslovKontejner);
        
        let divZaPodatke = document.createElement("div");
        divZaPodatke.className = "divZaPodatke";
        this.kontejner.appendChild(divZaPodatke);

        let nizPodataka = ["Temperatura", "Padavine", "Suncani Dani"];

        let rdBtn, labelRdBtn;
        nizPodataka.forEach((p, index) => {
            rdBtn = document.createElement("input");
            rdBtn.type = "radio";
            rdBtn.name = this.Naziv;
            rdBtn.value = p;
            if(p === "Temperatura")
                rdBtn.checked = true;
            divZaPodatke.appendChild(rdBtn);

            labelRdBtn = document.createElement("label");
            labelRdBtn.innerHTML = p;
            divZaPodatke.appendChild(labelRdBtn);
        });

        
        let divPrikazi = document.createElement("div");
        divPrikazi.className = "PrikaziButton";
        this.kontejner.appendChild(divPrikazi);

        let dugmePrikazi = document.createElement("input");
        dugmePrikazi.type = "button";
        dugmePrikazi.innerHTML = "Prikazi";

        let prikazPodataka = document.createElement("div");
        prikazPodataka.className = "PrikaziDIV";
        this.kontejner.appendChild(prikazPodataka);

        //dugmePrikazi.onclick = (event) => this.iscrtajPodatke(prikazPodataka);

    }

    // iscrtajPodatke(host) {
    //     let podaci = document.createElement("div");
    //     stavka.className = "stavka";
    //     host.appendChild(podaci);

    //     let samaStavka = document.createElement("div"); 
    // }
}