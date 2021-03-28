# entityframeworkcore-demo
EntityFrameworkCoreDemo
step-1 create .net core webapi project 
	dotnet new webapi -n efcoredemo
	dotnet dev-certs https --trust
	
step-2 install packages
	dotnet add package Microsoft.EntityFrameworkCore.SqlServer
	dotnet add package Microsoft.EntityFrameworkCore.Design
	dotnet add package Microsoft.EntityFrameworkCore.Tools 
	
	dotnet tool install --global dotnet-ef
	
step-3 	
	dotnet ef migrations add yourMigrationName
	dotnet ef database update
	
step-4 Add swagger
		dotnet add package NSwag.AspNetCore
		
step - 5 
		dotnet publish -c Release
