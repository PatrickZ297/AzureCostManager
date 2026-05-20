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