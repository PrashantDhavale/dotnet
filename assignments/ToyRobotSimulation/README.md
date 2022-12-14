# ToyRobotSimulation
Toy Robot Simulation - Telstra Purple Assignment 

# Prerequisites
- .Net Core 3.1 (Download from https://dotnet.microsoft.com/download/dotnet/3.1)

# Source Code 
  Open command prompt / terminal and clone this repo at any drive/folder of your choice using git command cli. (Download git from https://git-scm.com/downloads)
```
  git clone https://github.com/PrashantDhavale/ToyRobotSimulation.git
```
# Folder structure 

  The clone command will create a new folder ToyRobotSimulation -> (Root folder)
```
    ToyRobotSimulation.Client
    ToyRobotSimulation.Service
    ToyRobotSimulation.Tests
    README.md
```
#	Build the code
  Use the same command prompt and issue the following command in the root folder
```
  dotnet build .\ToyRobotSimulation.sln
```
# Execute the xUnit tests
  Once the build is successful use the following command to run the xUnit tests
```
  dotnet test
```
# Execute the application
  Execute the application using the following command
```
  dotnet run -p ./ToyRobotSimulation.Client
```
