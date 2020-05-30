# 🚵 SQLite Simple Auth & Roles Server 🎟
Lightweight, fast Authentication server. A sub-server design to be served locally (or secretly), then pinged through any of your server-side / serverless services!

> Welcome to VSADS testing authentication server  
> ---
> This server is competing against MariSol Finance distributed 
> self-auth verification server "Acountabless Wirematching".  
> Here we are using a small, centeralized SQLite database inside 
> Microsoft's dotnet core asp.net core entity framework. 
> Entity Framework helps us interact with out database in C# (it 
> does the SQL for us).

## Running... 
Download this repo, then run with `dotnet run` (you will need dotnet runtime or sdk). 
This project is a dotnet `netcoreapp3.1`.

## How simple?
1. `http://{server}/Auth/New` Send an email y password (Password is hashed with a randomly generated salt).
2. `http://{server}/Auth/Test` Now send the same http body request here. If the password is correct it will return true!

## Use case...
+ You have many small server-less services that need to check for authentication!
+ You don't want to build auth + db + roles into your application.
