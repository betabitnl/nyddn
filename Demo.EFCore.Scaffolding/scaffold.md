# Scaffold

# Install tools nuget packages

Install-Package Microsoft.EntityFrameworkCore.Tools

Install-Package Microsoft.EntityFrameworkCore.SqlServer.Design

# Scaffold existing db

Be sure to set lib as startup project
doesn't seem to work in standard lib
generated in fullframework lib and moved it over

Scaffold-DbContext "Server=tcp:**SERVERNAME**.database.windows.net,1433;Initial Catalog=**DBNAME**;Persist Security Info=False;User ID=USR;Password=PWD;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models
