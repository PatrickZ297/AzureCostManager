# AzureCostManager
![Language](https://img.shields.io/badge/Language-C%23-blue)
![Platform](https://img.shields.io/badge/Platform-Azure-blue)
![Status](https://img.shields.io/badge/Status-In%20Development-yellow)

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
│   ├── User.cs
│   ├── Admin.cs
│   └── Customer.cs
├── Services/
│   ├── CostCalculator.cs
│   ├── FileService.cs
│   └── UserManagementService.cs
└── Data/
    ├── users.csv
    └── calculations.csv
```

## Class Diagram
![Class Diagram](docs/class-diagram.png)

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
| Claude (Anthropic) | Trouble shooting with github and vs community 

## Development Log

### Day 1
- Repository set up
- Project structure created
- README created

### Day 2
- Class diagram created in Draw.io
- Project classes created (User, Admin, Customer)

### Day 3 
- User.cs, Admin.cs, Customer.cs implemented
- Resource.cs and Calculation.cs created
- Troubleshooting delete .vs from github and commit in VS Community vs. powershell

### Day 4
- Resource.cs and Calculation.cs implemented
- Program.cs implemented
- Extended calculation features added (Full, Custom, Edit)
- FileService.cs implemented
- CSV persistence in progress - debugging ongoing