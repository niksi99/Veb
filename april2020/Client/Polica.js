export class Polica {

    constructor(id, oznaka, maxBrDVDs, trenutnoDVDs) {
        this.id = id;
        this.oznaka = oznaka;
        this.maxBrDVDs = maxBrDVDs;
        this.trenutnoDVDs = trenutnoDVDs;
        this.kontejner = null;
    }

    nacrtajPolicu(host) {

        this.kontejner = document.createElement("div");
        this.kontejner.className = "novaPolica";

        let oznaka = document.createElement("div");
        oznaka.className = "oznaka";
        oznaka.innerHTML = this.oznaka;
        this.kontejner.appendChild(oznaka);

        let policaDIV = document.createElement("div");
        policaDIV.className = "policaDIV";
        this.kontejner.appendChild(policaDIV);

        for(let i=0;i<this.trenutnoDVDs;i++) {

            let DVD = document.createElement("div");
            DVD.className = "DVD";
            policaDIV.appendChild(DVD);
        }
        
        let brojDVDs = document.createElement("div");
        brojDVDs.className = "brojDVDs";
        brojDVDs.innerHTML = this.trenutnoDVDs + "/" + this.maxBrDVDs;
        this.kontejner.appendChild(brojDVDs);

        host.appendChild(this.kontejner);

    }
}