let buttonElement: HTMLButtonElement = <HTMLButtonElement>document.getElementById("BeregnAfgift");


// funktionen for beregning af almindelig personbils bilafgift
function BilAfgift(pris : number){
   // Et output element defineres for at kunne sende exceptions i forbindelse med fejl og forkert brug af metoden

    let outputElement: HTMLOutputElement = <HTMLOutputElement>document.getElementById("output");

    // Et if-statement bestående af et tjek om hvorvidt værdiene er valide, og hvis ikke de er, sender en exception til brugeren.

    if (pris <= 0)
    {
        outputElement.innerHTML = "Tallet skal være positivt, og må ikke være under eller lig nul";
    }

    // Herefter laver vi vores beregninger ud fra hvilket prisniveau bilen er i. Dette gøres ved at bruge if-statements afhængig af prisen.
    // Derudover definere vi en variable vi kan gemme den resulterende bilafgift i.
    let bilAfgift : number;
    if (pris <= 200000)
    {
        bilAfgift = pris * 0.85
    }
    else if (pris > 200000)
    {
        bilAfgift = (pris*1.50) - 130000;
    }
    // Dernæst returner vi resultat
    return bilAfgift;
}
// funktionen for beregning af elbils bilafgift
function ElBilAfgift(pris : number){
    // Et output element defineres for at kunne sende exceptions i forbindelse med fejl og forkert brug af metoden
    let outputElement: HTMLOutputElement = <HTMLOutputElement>document.getElementById("output");

    // Et if-statement bestående af et tjek om hvorvidt værdiene er valide, og hvis ikke de er, sender en exception til brugeren.

    if (pris <= 0)
    {
        outputElement.innerHTML = "Tallet skal være positivt, og må ikke være under eller lig nul";
    }

    // Herefter laver vi vores beregninger ud fra hvilket prisniveau bilen er i. Dette gøres ved at bruge if-statements afhængig af prisen.
    // Derudover definere vi en variable vi kan gemme den resulterende bilafgift i.
    let bilAfgift : number;

    if (pris <= 200000)
    {
        bilAfgift = pris * 0.85;
    }
    else if (pris > 200000)
    {
        bilAfgift = (pris * 1.50) - 130000
    }

    // En variabel defineres til at beregne og returnere afgiften for elbiler
    let elBilAfgift : number = bilAfgift * 0.20;
    return elBilAfgift

}

// Der sættes en event listener op, som kalder de metoder der passer med de typer som den eventet bliver triggered med.
buttonElement.addEventListener("click", () => {
    // Der defineres et input og et output-element. Output bruges til at vise resultat, og input bruges til at få fat i prisen på bilen
    let inputElement: HTMLInputElement = <HTMLInputElement>document.getElementById("BilensPris");
    let outputElement: HTMLOutputElement = <HTMLOutputElement>document.getElementById("output");
    // Plusset bruges til at gøre inputElement.Value til typen number, istedet for string.
    let inputPris : number = +inputElement.value;

    // Biltypen findes ved at definere en variabel der henter typen fra elementet i HTML'en

    let bilType = (<HTMLSelectElement>document.getElementById('bilType')).value;
    // Der defineres en variabel til at håndtere outputtet af resultatet af vores metodekald

    let bilAfgiftResultat : number;

    // If-statements til at kalde den rigtige metode afhængig af inputet på eventlistener
    if (bilType == "Personbil")
    {
        bilAfgiftResultat = BilAfgift(inputPris);
    }
    else if (bilType == "Elbil")
    {
        bilAfgiftResultat = ElBilAfgift(inputPris);
    }
    else 
    {
        bilAfgiftResultat = 0;
    }

    // Til sidst ændres outputtets tekst til resultatet for at vise brugeren dette

    outputElement.innerHTML = bilAfgiftResultat.toString();

    
});