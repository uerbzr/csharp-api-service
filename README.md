# C# API Layers

A simple example of how to create a C# API with multiple layers.  Layers have been broken down into various projects in this extreme example!

## Description

The project is a very simple calculator queueing API with the following endpoints:

| VERB  | PATH      | DESCRIPTION   |
| ------| -------   | -------       |
| GET   | /         | Get all calculations
| GET   | /queued   | Get all queued calculations (the result property is null)|
| GET   | /queue/a/b| Queue a calculation passing in 2 numbers in the path a/b|
| GET   | /calculate| Calculate anything with a null Result |


## Setup (workshop.wwwapi Project)

- ```appsettings.Example.json```needs to be replaced with an ```appsettings.json``` & ```appsettings.Development.json``` with relevant credentials
- Run the following commands in the **Package Manager Console**:
  - ```Add-Migration InitialCreate```
  - ```Update-Database```
	
	