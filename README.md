VIDEO PREZENTARE: https://www.youtube.com/watch?v=AnSc3vbo_iU

Programe necesare pentru rulare program:
* Microsoft Visual Studio 2022 Communitiy
* Microsoft SQL Server Management Studio

Import baza de date:
1. Se dechide Microsoft SQL Server Management Studio
2. La server name se scrie (LocalDB)\MSSQLLocalDB
3. Click dreapta folderul Databases si alegem Import Data-tier Application
4. Next -> Browse... -> Cautam si alegem fisierul "Baza de date.bacpac" -> Open -> Next -> Next -> Finish -> Close

Import solutie aplicatie:
1. Dublu click pe Moga_Stefan_Proiect.sln
2. Se instaleaa o masina virtuala pentru aplicatia android din Tools -> Android -> Android Device Manager (api 30)
3. Pentru a porni tot sistemul informatic se da click dreapta pe solutie click pe Configure Startup Projects
4. Se alege Multiple startup projects
5. Se alege start pentru Moga_Stefan_Proiect.Android, RestaurantSiteComenzi si WebService2.
6. Pentru a face conexiunea dintre aplicatia web si cea mobila trebuie instalat Conveyor by Keyoti
7. Click Extensions din bara de sus si apoi Manage Extensions
8. Se cauta si instaleaza Conveyor by Keyoti for VS 2022+
9. Se ruleaza solutia si se da click Access Over Internet in fereastra Conveyor
10. Se copiaza cuvantul generat din linkul https://xxxxxxxxx.conveyor.cloud/swagger 
11. In fisierul RestService.cs din Moga_Stefan_Proiect/Services la linia 14 se inlocuieste cuvantul mogaapi din cod cu cuvantul copiat
12. Se ruleaza din nou proiectul.

Observatie: S-ar putea ca pagina cu harta Google Maps sa nu se incarce fiind nevoia unei noi chei API. Mai multe detalii:
https://learn.microsoft.com/en-us/xamarin/android/platform/maps-and-location/maps/obtaining-a-google-maps-api-key?tabs=windows
