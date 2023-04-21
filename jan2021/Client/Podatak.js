export class Podatak {

    constructor(Id, prosecnaDnevnaTemperatura, kolicinaPadavina, brojSuncanihDana) {
        this.Id = Id;
        this.prosecnaDnevnaTemperatura = prosecnaDnevnaTemperatura;
        this.kolicinaPadavina = kolicinaPadavina;
        this.brojSuncanihDana = brojSuncanihDana;
        this.mesec = null;
        this.kontejner = null;
        this.Grad = null;
    }

    crtajPodatak(opcija) {

        switch(opcija) {
            case "Temperatura":
                this.Grad.podaci.forEach(element => {
                     
                });
        }
    }
}