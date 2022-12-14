# AGL
A temporary repo for AGL challenge

# Prerequisites on Windows
- .Net Core 2.1.2 SDK (Download from https://www.microsoft.com/net/download/windows)
- Node 8.6.0 
- npm 5.3.0

# GITHUB
  Open command prompt and clone the AGL repo at any drive/folder of your choice
  
  git clone https://github.com/PrashantDhavale/AGL.git

# Folder structure 

  The clone will create a new folder AGL -> (Root folder)

    PeopleWithPets.DataAccess
    PeopleWithPets.Domain
    PeopleWithPets.WebAPI
    PeopleWithPets.WebUI
    Tests
    PeopleWithPets.sln
    README.md

# Build and Test

    Open the .sln in Visual Studio 2017
    Compile it. The tests should execute automatically. If not then please use the Test runner.
    
# Setting up

    1) Set the PeopleWithPets.WebAPI as the Startup project
    2) IMPORTANT: Open launch properties and set the App URL to http://localhost:5000/
    
    NOTE: On the local settings the WebAPI should execute on port 5000.
          If you choose any other port, then you need to open up the 
          PeopleWithPets.WebUI\src\environments\environment.*.ts files and 
          set the peopleWithPetsAPI value to use the port of your choice
    
# Executing the application

  Execution is 2 parts
  
  (a) WebAPI
  
       a.1) Execute the application (F5) and in the browser browse http://localhost:5000/api/PeopleWithPets
       
       a.2) Check if the API is running. It should return the response as JSON.
       
  (b) WebUI
  
       b.1) Command prompt -> browse to PeopleWithPets.WebUI
  
       b.2) npm install (required only once & this will take some time for downloading packages)
       
       b.3) ng build -prod
       
       b.4) ng serve -open
            This will pop up a new browser and display the default page with a Information button.
       
       b.5) Click the Blue information button
       
       
