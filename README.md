# idle-game

This is my first journey into the magical lands of making a dotnet web api.
The api is used by this [react frontend](https://github.com/Vehx/idle-game-frontend/tree/dev-full-api) and is a small idle game with farms and barns.


## Setup

* To setup the database go into Data/DataContext.cs and change this line <br>
   optionsBuilder.UseMySQL("server=localhost;database=library;user=user;password=password");
   
* Run dotnet ef database update

* Send a POST request to /player with a name to make your player <br>
  {<br>
     name:"player"<br>
  }<br>
This can be done using postman or something similar

## Usage

* Start it using dotnet watch run in terminal

* Send GET requests to /player/:playerid to get current info such as money etc

* Send PUT request with player id and building id to /player to buy said building
