// Importer Axios
import Axios, {AxiosResponse,AxiosError} from "../../node_modules/axios/index"
// Definer alle variabler til elementer og URI
let buttonElement: HTMLButtonElement = <HTMLButtonElement>(document.getElementById("Getallcoins"));
buttonElement.addEventListener("click", PerformGetAllRequest);

let IdbuttonElement: HTMLButtonElement = <HTMLButtonElement>(document.getElementById("Getcoinbyid"));
IdbuttonElement.addEventListener("click", PerformGetById);

let buttonElementAdd: HTMLButtonElement = <HTMLButtonElement>(document.getElementById("AddBtn"));
buttonElementAdd.addEventListener("click", PerformPostRequest);

let buttomElementTable: HTMLButtonElement  = <HTMLButtonElement>document.getElementById("Tableknap")
buttomElementTable.addEventListener("click",PerformGetRequestAndPutToTable);

let uri: string = "http://localhost:49330/api/coin/";
// Indsæt interface hvis nødvendigt som gjort nedenfor
interface ICoin {
  id: number;
  genstand: string;
  bud: number;
  navn: string;
}

// Laver et get all request, som henter al data i REST-servicen
function PerformGetAllRequest(): void {
  // Definer variable til brug i metoden
  let outputElement = document.getElementById("output");
  outputElement.innerHTML = "";
  // Get kaldet bliver lavet med Axios
  Axios.get<ICoin[]>(uri)
    .then((response: AxiosResponse<ICoin[]>) => {
      let data: ICoin[] = response.data;
      outputElement.innerHTML = JSON.stringify(data);
    })
    .catch((error: AxiosError) => {
      console.log(error);
      outputElement.innerHTML = error.message;
    });
}
// Laver et Get all call på samme måde som PerformGetAllRequest(), men sætter dog dataene ind i et table istedet. 
function PerformGetRequestAndPutToTable(): void {

  // Definer variable til brug i metoden
  let tablebody: HTMLTableElement = <HTMLTableElement>(
    document.getElementById("tbody")
  );
  tablebody.innerHTML = "";
  
  let outputElement = document.getElementById("output");
  outputElement.innerHTML = "";
  // Get called bliver lavet, og dernæst sætter man dataene ind i cellerne i data.forEach loopet. Det er ikke nødvendigt at lave en index og index++ da du indsætter en row for hver coin i data
  Axios.get<ICoin[]>(uri)
    .then((response: AxiosResponse<ICoin[]>) => {
      let data: ICoin[] = response.data;    
      data.forEach(coin => {
        let row = tablebody.insertRow();
        row.insertCell(0).innerHTML = coin.id+"";
        row.insertCell(-1).innerHTML = coin.navn;
        row.insertCell(-1).innerHTML = coin.bud+"";
        row.insertCell(-1).innerHTML = coin.genstand;       
      });
    })
    .catch((error: AxiosError) => {
      console.log(error);
      outputElement.innerHTML = error.message;
    });
}
// Laver en variabel som bruges som id. Sætter dette id sammen med URL'en ved brug af .concat(id). Dette resultere i at URL'en bliver localhost:port/api/controller/id - hvor id delen bliver tilføjet ved concat
function PerformGetById(): void {
  // Definer variable til brug i metoden
  let outputElement = document.getElementById("output");
  outputElement.innerHTML = "";
  let inputelement: HTMLInputElement = <HTMLInputElement>(
    document.getElementById("Coinid")
  );
  let CoinId: string = inputelement.value;
 // laver Axios get kaldet med id i URL
  Axios.get<ICoin>(uri.concat(CoinId))
    .then((response: AxiosResponse<ICoin>) => {
      let data: ICoin = response.data;

      outputElement.innerHTML = JSON.stringify(data);
    })
    .catch((error: AxiosError) => {
      console.log(error);
      outputElement.innerHTML = error.message;
    });
}

function PerformPostRequest(): void {
  // Definer variable til brug i metoden
  let addIdElement: HTMLInputElement = <HTMLInputElement>(
    document.getElementById("CoinAddId")
  );
  let addGenstandElement: HTMLInputElement = <HTMLInputElement>(
    document.getElementById("CoinAddGenstand")
  );
  let addBudElement: HTMLInputElement = <HTMLInputElement>(
    document.getElementById("CoinAddBud")
  );
  let addNavnElement: HTMLInputElement = <HTMLInputElement>(
    document.getElementById("CoinAddNavn")
  );
  // Definer variable til brug i Post requesten
  let Coinid: number = Number(addIdElement.value);
  let CoinGenstand: string = addGenstandElement.value;
  let CoinBud: number = Number(addBudElement.value);
  let CoinNavn: string = addNavnElement.value;
  // Axios post kaldet med variablerne.
  Axios.post<ICoin>(uri, {
    id: Coinid,
    Genstand: CoinGenstand,
    Bud: CoinBud,
    Navn: CoinNavn
  })
    .then((response: AxiosResponse) => {
      console.log("response" + response.status + " " + response.statusText);
    })
    .catch((error: AxiosError) => {
      console.log(error);
    });
}