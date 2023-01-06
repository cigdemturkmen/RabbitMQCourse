# RabbitMQCourse

#### This is a .NET CORE 7 Console App

## Installation
 - Clone the project
 - Open with visual studio 
 - Download the RabbitMQ.client from package manager (*Manage NuGet Packages*) for each assembly(both producer and consumer)
 - Replace the connection url with yours.
 - Run the app

This console app sends a message to the RabbitMQ queue and the message is consumed by the subscriber. 

In workQueue branch, multiple messages are sent at once to multiple subscribers. Messages are deleted only after RabbitMQ acknowledges that the messages are received successfully. In order to run multiple subscriber at once:
- open multiple powershells
- locate to the project file using cd C:\myPath command
- run the project using dotnet run command in each subscriber(powershell)


## RabbitMQ Installation
in progress...