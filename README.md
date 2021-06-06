# SocialBrothersAPI
 
Dit is mijn uitwerking van de SocialBrothers .NET/C# API case. 

## Instructies
- Stap 1: Open het project in Visual Studio  
- Stap 2: Zorg dat de instellingen bovenin het scherm op dezelfde instellingen staan als de onderstaande afbeelding </br>
![image](https://user-images.githubusercontent.com/63775330/120933963-bffcb500-c6fc-11eb-8c16-29b2dcf2cbe4.png)
- Stap 3: Druk op de IIS Express start knop. Je hebt nu de API opgestart
- Stap 4: Start Visual Studio nog een keer op
- Stap 5: Zorg dat de instellingen bovenin het scherm op dezelfde instellingen staan als de onderstaande afbeelding </br>
![image](https://user-images.githubusercontent.com/63775330/120934102-4618fb80-c6fd-11eb-9276-e20864941268.png)
- Stap 6: Druk op de IIS Express start knop. Je hebt nu de Web Application opgestart. Als het goed is kom je nu op hetzelfde scherm als de onderstaande afbeelding
![image](https://user-images.githubusercontent.com/63775330/120934175-8d9f8780-c6fd-11eb-99ca-047e09a00bec.png)
- Stap 7: In de navigatiebalk zie je "Addresses" en "Distance". Wanneer je op "Addresses" drukt, kom je op de index pagina van de adressen. Je kunt hier alle adressen filteren en sorteren. Ook kun je hier doorverwezen worden naar de CRUD pagina's van de adressen.
- Stap 8: Wanneer je op "Distance" drukt, kun je de afstand tussen twee adressen laten berekenen via een API

## Trots
Ik ben trots op de volgende punten:
- Het is gelukt om elke functionaliteit te implementeren
- De sorteerfunctie is erg dynamisch en blijft up to date wanneer er nieuwe attributen worden toegevoegd aan adressen

## Minder trots
Ik ben minder trots op de volgende punten:
- De filter methode is niet compleet dynamisch en is ook hoofdlettergevoelig
- Het berekenen van de afstand gebruikt veel methodes en code. Ik had geprobeerd om de google maps API te gebruiken, maar die vereist sinds 2018 creditcard gegevens en ik heb helaas geen creditcard. Ik heb daarom gebruik gemaakt van een andere API waar dit geen vereiste is.

## Uitleg functionaliteiten
![image](https://user-images.githubusercontent.com/63775330/120934615-5336ea00-c6ff-11eb-9aa6-3faffb291ddd.png)
Link: https://localhost:44369/Address?Filter=Br&Sort=
Uitleg: Hier zie je dat er gefilterd wordt op alle velden.  

![image](https://user-images.githubusercontent.com/63775330/120934676-93966800-c6ff-11eb-8edc-e0ef91c67e2f.png)
Link: https://localhost:44369/Address?Filter=&Sort=Street
Uitleg: Hier zie je dat er gesorteerd wordt op de straatnaam. Bij de invoer van Sort moet je dus een naam van een kolom invullen.

![image](https://user-images.githubusercontent.com/63775330/120934713-c3de0680-c6ff-11eb-9b9f-2adb53230242.png)
Uitleg: Hier zie je dat de afstand tussen de twee adressen wordt berekend.
