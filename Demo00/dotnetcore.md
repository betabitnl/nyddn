# dotnet.exe

Cross-platform toolchain for developing .NET applications. Foundation upon which higher-level tools, such as 
Integrated Development Environments (IDEs), editors and build orchestrators can rest.

During development of ASP.NET Core, a big change in the project file format was announced (and 
implemented): project.json in stead of .csproj. This change has been reverted, although the new .csproj 
format is a lot more readable.

## DEMO
dotnet.exe<br/>
dotnet new console<br/>
dotnet restore<br/>
dotnet build --output bin build<br/>
*using --output /bin places dll in c:\bin !!! Works fine without the (back)slash*<br/>
dotnet bin/project.dll

Also possible: run csproj

## PROJECT.JSON (and .xproj)
- AutoComplete for references
- Ease of reading
- Overall simpler structure
- No MSBuild support

## .CSPROJ
- No more GUIDs in the file!
- Include (files) by default
- Package references now in the project file
- Right-click-edit (while it is loaded!)

## 'Choosing' your project file
- Visual Studio 2015 -> project.json​
- Visual Studio 2017​ -> .csproj