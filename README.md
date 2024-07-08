# WebEnginnering24

Linux:
```bash
# We need some old dotnet-sdk
sudo apt-get update && sudo apt-get install -y dotnet-sdk-6.0
# get deps set in MyWebDbApp.csproj
dotnet restore 
# build the project
dotnet build
# initialize the database
dotnet ef database update
# run the web-server
dotnet run
```
