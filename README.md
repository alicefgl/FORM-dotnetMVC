# FORM-dotnetMVC

Sito realizzato con ASP.NET

CONSEGNA:
Creare un Form che accetti:
- Nome
- Cognome
- email
- Data di nascita
- Sesso (con un Radio Button)
- Ruolo ( con menù a tendina)

Visualizzare i dati all'invio della form tramite botton Submit

PROCEDIMENTO:
Per creare la pagina "Prenota" ho creato una nuova View contenuta all'interno della View preesistente "Home", per poi creare un nuovo metodo Controller all'interno di "HomeController.cs" (anche esso già esistente) che mostrasse a video la View appena aggiunta.
A questo punto per visualizzare effettivamente la pagina Prenota è necessario specificare la View desiderata all'interno dell'URL della pagina (ad esempio .../Home/Prenota).
Per evitare l'ultimo passaggio descritto ho creato una nuova "li" all'interno di _Layout.cshtml (Views -> Shared) in questo modo:
```
<li class="nav-item">
  <a class="nav-link text-dark" asp-area="" asp-controller="Home" asp-action="Prenota">Prenota</a>
</li>
```
All'interno di questa li specifico che la View Prenota deve essere richiamata tramite una chiamata alla Action contenuta nel Controller Home.

I dati relativi alla pagina Prenota sono contenuti all'interno di una classe Prenotazione, aggiunta come nuovo Model (cartella Models).
All'interno della classe vi sono le property relative agli attributi, che saranno i dati che vengono inseriti dall'utente.
```
public class Prenotazione
{
    public string? Nome { get; set; } required
    public string? Cognome { get; set; } required

    public string? Email { get; set; } required
    public DateTime DataDiNascita { get; set; } required
    public Sesso _Sesso { get; set; } required
    public Ruolo _Ruolo { get; set; }

    public enum Sesso{
        Maschio,
        Femmina,
        Non_specificato,
    }
        public enum Ruolo{
        Docente,
        Studente,
        Genitore,
    }
}
```
Ho creato in seguito la pagina Conferma, all'interno della quale vengono stampati a video i dati inseriti nel form "Prenota".
Per collegare queste due pagine si specifica nel form "Prenota" la procedura di HTTP POST verso la pagina Conferma, in questo modo:
```   
    <form class="m-2" method="post" asp-action="Conferma">
```
Il form Conferma si basa sul modello di una lista di classe Prenotazione, e stampa gli attributi della classe per ogni elemento presente nella lista.
```
@model List<Prenotazione>;
@{
    ViewData["Title"] = "Conferma";
}

<div class="text-center">
    <h1 class="display-4">Conferma</h1>
    Il numero di elementi nella lista è @Model.Count </br>
        @{
            foreach(var item in @Model){
                <p> Nome: @item.Nome <br> Cognome @item.Cognome <br> Email: @item.Email <br> Data di nascita: @item.DataDiNascita <br> Sesso: @item._Sesso <br> Ruolo: @item._Ruolo</p>
            }
        }
</div>
```
