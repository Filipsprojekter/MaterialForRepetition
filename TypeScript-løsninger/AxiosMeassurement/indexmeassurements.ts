// Importer Axios
import Axios, {
  AxiosResponse,
  AxiosError
} from "../../node_modules/axios/index";
// Definere knapperne, husk at kalde de rigtige metoder på de rigtige knapper

let buttonElement: HTMLButtonElement = <HTMLButtonElement>(document.getElementById("Getall"));
buttonElement.addEventListener("click", getAllMeassuments);

let IdbuttonElement: HTMLButtonElement = <HTMLButtonElement>(document.getElementById("Getbyid"));
IdbuttonElement.addEventListener("click", GetMeassurementById);

let buttonElementAdd: HTMLButtonElement = <HTMLButtonElement>(document.getElementById("Deletebyid"));
buttonElementAdd.addEventListener("click", DeleteById);

let buttomElementTable: HTMLButtonElement  = <HTMLButtonElement>document.getElementById("Tableknap")
buttomElementTable.addEventListener("click",getAllMeassuments);
// Skiftes til urlen på den REST du har lavet
let url: string = "http://localhost:62703/api/meassurements/";

// Kan være nødvendigt at tilføje interface som vist nedenfor
interface IMeassurement {
  id: number;
  pressure: number;
  humidity: number;
  temperature: number;
  timeStamp: Date;
}
// Get all med table creation og indsættelse i dette table.
function getAllMeassuments(): void {
  // Definerer variabler og sætter output stederne til tomme for ikke at ende med dobbelt indhold i disse.
  let tablebody: HTMLTableElement = <HTMLTableElement>(
    document.getElementById("tbody")
  );
  tablebody.innerHTML = "";

  let outputElement: HTMLOutputElement = <HTMLOutputElement>(
    document.getElementById("output")
  );
  outputElement.innerHTML = "";
  // Laver Axios metode kaldet og sætter ind i table celler
  Axios.get<IMeassurement[]>(url)
    .then((response: AxiosResponse<IMeassurement[]>) => {
      let data: IMeassurement[] = response.data;     
      data.forEach(i => {
        let row = tablebody.insertRow();
        row.insertCell(0).innerHTML = i.id+"";
        row.insertCell(-1).innerHTML = i.pressure + "";
        row.insertCell(-1).innerHTML = i.humidity + "";
        row.insertCell(-1).innerHTML = i.temperature + "";
        row.insertCell(-1).innerHTML = i.timeStamp+"";       
      });
      
    })
    .catch((error: AxiosError) => {
      console.log(error);
    });
}
// Laver en variabel som bruges som id. Sætter dette id sammen med URL'en ved brug af .concat(id). Dette resultere i at URL'en bliver localhost:port/api/controller/id - hvor id delen bliver tilføjet ved concat
function GetMeassurementById(): void {
  // Definrer variabler der bruges i metoden
  let outputElement = document.getElementById("output");
  outputElement.innerHTML = "";
  let inputelement: HTMLInputElement = <HTMLInputElement>(
    document.getElementById("inputid")
  );
  let id: string = inputelement.value;
  // laver Axios get kaldet med id i URL
  Axios({
    method: "get",
    url: url.concat(id)
  })
    .then((response: AxiosResponse<IMeassurement>) => {
      let data: IMeassurement = response.data;
      outputElement.innerHTML = JSON.stringify(data);
    })
    .catch((error: AxiosError) => {
      console.log(error.message);
    });
}
// Fungerer på samme måde som GetMeassurementById(), dog bruges metoden delete i axios bare istedet. Derudover er der vidst en alternativ måde at sætte metodekaldet op på.
function DeleteById(): void {
  // Definerer variabler til brug i metoden
  let outputElement = document.getElementById("output");
  outputElement.innerHTML = "";
  let inputelement: HTMLInputElement = <HTMLInputElement>(
    document.getElementById("inputid")
  );
  let id: string = inputelement.value;
  // Laver Delete kaldet via Axios med id i URL
  Axios({
    method: "delete",
    url: url.concat(id)
  })
    .then((response: AxiosResponse) => {
      console.log("response " + response.status + " " + response.statusText);
    })
    .catch((error: AxiosError) => {
      console.log(error);
    });
}
