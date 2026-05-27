# AzureCostManager
![Language](https://img.shields.io/badge/Language-C%23-blue)
![Platform](https://img.shields.io/badge/Platform-Azure-blue)
![Status](https://img.shields.io/badge/Status-Finished-yellow)

## Description
A C# console application that helps companies manage 
and monitor their monthly Azure cloud costs.

## Features
- Role-based login system (Admin & Customer)
- Cost calculation for Azure resources
- CSV data persistence
- User management (Admin only)
- Historical calculations overview

## Project Structure 
```
AzureCostManager/
├── Classes/
│   ├── Admin.cs
│   ├── Calculation.cs
│   ├── Customer.cs
│   ├── Resource.cs
│   └── User.cs
├── Data/
│   ├── calculations.csv
│   └── users.csv
├── docs/
│   └── class-diagram.png
├── Services/
│   └── FileService.cs
└── Program.cs
```

## Class Diagram
![Class Diagram](docs/class-diagram.png)

## Screenshots
### Login
![Login](docs/screenshot-login.png)

### Admin Menu
![Admin Menu](docs/screenshot-admin-menu.png)
![User Management](docs/screenshot-admin-menu-user-management.png)

### Customer Menu
![Customer Menu](docs/screenshot-customer-menu.png)
![Calculation](docs/screenshot-customer-menu-calculation.png)

### Calculation
![Calculation](docs/screenshot-calculation-example.png)
![Calculation](docs/screenshot-calculation-example-summary.png)

## How to Run
1. Clone the repository
2. Open AzureCostManager.sln in Visual Studio
3. Press F5 to run

## Technologies
- C# / .NET
- Visual Studio Community 2022
- GitHub

## AI Tools Used
| Tool | Purpose |
|------|---------|
| Claude (Anthropic) | Designelements for Project Structure (└──, ├──, │  )
| Claude (Anthropic) | Trouble shooting with github and vs community 
| Claude (Anthropic) | Trouble shooting for CSV persistence

## Development Log

### Day 1
This was the first day of our project. We had to develop a console app in C#, the topic of our project was our decision. My first step was to think about a project idea and design a roadmap for my project. Therefore, I did some brainstorming and designed my first structure.   
I decided on a AzureCostManager for multiple reasons. First, it's a good practice for my goal to work with cloud, and second, I was able to test CSV. The decision why I chose CSV for my first test was relatively easy.
Since this was my first time implementing any kind of data storage in a project, I wanted to keep it simple and focus on understanding the core concept. CSV files are easy to read, require no external tools and were perfectly sufficient for this project. 
In a real-world scenario, however, I would opt for a proper database solution like Azure SQL Database or CosmosDB, which offer better security, faster query performance, support for simultaneous access and protection against unauthorized data manipulation.
After receiving approval from the lecturer, the GitHub repository was set up and connected to Visual Studio Community. 
The basic project structure was created with the folders Classes, Services, Data and docs. A first README was written with a project description, features and the project structure. The first commit was pushed to GitHub.


### Day 2
The second day was all about planning and visualization. Before jumping into the code, I wanted to have a clear picture of how my classes would work together. 
So I started by creating a class diagram in Draw.io to map out the inheritance structure between User, Admin and Customer. Having that visual really helped me understand the relationships before writing a single line of code. 
Alongside that, I created the three main class files User.cs, Admin.cs and Customer.cs as empty placeholders in the Classes folder. I also extended the README with the class diagram and added a How to Run section to make the project more accessible for others.


### Day 3 
On day 3 I implemented main classes User.cs, Admin.cs and Customer.cs. I designed User.cs as the base class with private fields, a constructor and the Login() and ShowProfile() methods. 
Admin.cs and Customer.cs were then built as derived classes using inheritance from User. On top of that, Resource.cs and Calculation.cs were created and implemented to lay the foundation for the cost calculation logic.
Day three also came with some unexpected technical challenges. During the setup I noticed that my .vs folder had been accidentally pushed to the GitHub repository. 
Since this folder contains personal Visual Studio settings that should never be shared publicly, I had to remove it from the repository. This taught me a lot about how .gitignore works and why it is so important to configure it correctly from the start. 
I also took this opportunity to get more familiar with different ways of committing – directly through Visual Studio, via PowerShell and through the GitHub web interface for things like editing the README.


### Day 4
Day four was where the project really started to come to life. I implemented Program.cs with the main menu, the login system and role-based navigation between Admin and Customer. After some testing I realized that the customer didn't really have options to add or change new calculations.
So I gave the customer three different options: a Full Calculation covering all resources at once, a Custom Calculation for selecting individual resources and an Edit function for existing calculations. 
I also created FileService.cs in the Services folder to handle saving and loading data via CSV. To simplify the process I decided to focus on users.csv to implement the feature and to test it. The users.csv file was set up in the Data folder as a template.
Finished this day with an unfinished CSV. The CSV persistence was not working as expected – data was being saved but not in the right directory.


### Day 5 
Day five was honestly a frustrating but important day. I started the day with debugging my users.csv file. After a lot of debugging I identified the issue: the file path was pointing to an old project version. 
I resolved this by switching from AppDomain.CurrentDomain.BaseDirectory to Directory.GetCurrentDirectory() and cleaning up the old project folder. After finishing users.csv I implemented calculations.csv and checked for similar mistakes.
I also added a duplicate username check in the CreateUser() method to prevent conflicts between accounts. 
Once everything was connected properly, the save and load functionality finally worked as intended.


### Day 6
The last day was all about finishing touches and presentation preparation. I was not fully satisfied with the original class diagram so I recreated it using Mermaid which gave it a much cleaner and more professional look. 
I took all the screenshots, cropped them to remove personal information and added them to the docs folder. The README got its final update with the new diagram, screenshots and a completed development log. 
I reworked my development log and added more information for a better understanding of the process. 
I also changed the status badge from In Development to Finished. After one last review I pushed the final commit to GitHub and considered the project complete.




