1. create the solution file: `dotnet new sln -n "name of the sln"`
2. create the console application: `dotnet new console -n "name"`
3. create the class library: `dotnet new classlibrary -n "name"`
4. add csproj files to sln: `dotnet sln <name of sln> add **/**.csproj`
5. make sure that console project references the class library: `dotnet add <console app/name.csproj> reference <library class/libname.csproj>`

now we can start working with the project solution.
