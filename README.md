<div id="top"></div>

# Hogwarts Houses

<!-- TABLE OF CONTENTS -->
<details>
  <summary>Table of Contents</summary>
  <ol>
    <li>
      <a href="#about-the-project">About The Project</a>
      <ul>
        <li><a href="#main-features">Main Features</a></li>
        <li><a href="#built-with">Built With</a></li>
        <li><a href="#visuals">Visuals</a></li>
      </ul>
    </li>
    <li><a href="#installation">Installation</a></li>
    <li><a href="#usage">Usage</a></li>
  </ol>
</details>



<!-- ABOUT THE PROJECT -->
## About The Project

![home-page.png][home-page]

Hogwarts Houses is a website where we can see all the rooms from the houses in the Wizarding World of Harry Potter. We can administer rooms by adding or deleting rooms from the evidence, modify the room capacity and see the accommodated Hogwarts students in any rooms.

<p align="right">(<a href="#top">back to top</a>)</p>


### Main Features

- Add rooms
- Delete rooms
- Modify room capacity
- Check room details
- See details about students accommodated in the rooms
- Sort rooms by availability and pet types in the rooms
- Mix ingredients and discover new recipes for potions (no visual representation yet, only available by requests, using for example Postman)

<p align="right">(<a href="#top">back to top</a>)</p>

### Built With

Back End:
* [ASP .NET Core][asp-net-core]
* [Entity Framework Core][ef-core]
* [C#][c#]

Front End:
* [HTML][html]
* [CSS][css]
* [React.js][react]

Database Management:
* [Microsoft SQL Server][msql-server]
* [Microsoft SQL Server Management Studio][ssms]

IDE:
* [Microsoft Visual Studio][visual-studio]
* [Visual Studio Code][visual-studio-code]

<p align="right">(<a href="#top">back to top</a>)</p>



### Visuals

Empty Cart:

![new-room-page.png][new-room-page]

Register Page:

![room-details.png][room-details]

<p align="right">(<a href="#top">back to top</a>)</p>



## Installation
- Run "npm install" in CMD from the Client directory
- Create a database named "Hogwarts"
- Update the database using the Package Manager Console

<p align="right">(<a href="#top">back to top</a>)</p>



<!-- USAGE EXAMPLES -->
## Usage

Run the React client server in parallel with the ASP .NET Web API app.
The React client will display the app to the localhost:3000 address, and any other requests to the API server will be done through an API platform, like [Postman][postman].

<p align="right">(<a href="#top">back to top</a>)</p>


<!-- MARKDOWN LINKS & IMAGES -->
[asp-net-core]: https://dotnet.microsoft.com/en-us/learn/aspnet/what-is-aspnet-core
[ef-core]: https://docs.microsoft.com/en-us/ef/core/
[c#]: https://docs.microsoft.com/en-us/dotnet/csharp/
[html]: https://html.com/
[css]: https://www.w3.org/Style/CSS/Overview.en.html
[react]: https://reactjs.org/
[msql-server]: https://www.microsoft.com/en-us/sql-server/sql-server-2019
[ssms]: https://docs.microsoft.com/en-us/sql/ssms/download-sql-server-management-studio-ssms?view=sql-server-ver15
[visual-studio]: https://visualstudio.microsoft.com/
[visual-studio-code]: https://code.visualstudio.com/
[postman]: https://www.postman.com/


[home-page]: wwwroot/img/captures/home-page.png
[new-room-page]: wwwroot/img/captures/new-room-page.png
[room-details]: wwwroot/img/captures/room-details.png
