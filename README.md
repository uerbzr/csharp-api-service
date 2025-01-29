# C# API Layers

A simple example of how you might setup a C# API with multiple layers.  

## Description

The project is a very simple calculator queueing API with the following endpoints:

| VERB  | PATH      | DESCRIPTION   |
| ------| -------   | -------       |
| GET   | /         | Get all calculations
| GET   | /queued   | Get all queued calculations (the result property is null)|
| GET   | /queue/a/b| Queue a calculation passing in 2 numbers in the path a/b|
| GET   | /calculate| Calculate anything in the queue with a null result |


## Setup (workshop.wwwapi Project)

- ```appsettings.Example.json```needs to be replaced with an ```appsettings.json``` & ```appsettings.Development.json``` with relevant credentials
- Run the following commands in the **Package Manager Console**:
  - ```Add-Migration InitialCreate```
  - ```Update-Database```
	
	