# Créer un dossier racine
mkdir TwinSim && cd TwinSim

# Créer la solution .NET
dotnet new sln --name TwinSim

# Créer le projet principal (bibliothèque de services)
dotnet new classlib --name TwinSim.Domain
dotnet new classlib --name TwinSim.Services

# Créer l'API REST minimale
dotnet new webapi --no-https --name TwinSim.API

# Créer le projet de tests
dotnet new xunit --name TwinSim.Tests

dotnet sln add TwinSim.Domain/TwinSim.Domain.csproj
dotnet sln add TwinSim.Services/TwinSim.Services.csproj
dotnet sln add TwinSim.API/TwinSim.API.csproj
dotnet sln add TwinSim.Tests/TwinSim.Tests.csproj

# L'API a besoin du service et du domain
dotnet add TwinSim.API/TwinSim.API.csproj reference TwinSim.Services/TwinSim.Services.csproj
dotnet add TwinSim.API/TwinSim.API.csproj reference TwinSim.Domain/TwinSim.Domain.csproj

# Le service a besoin du domain
dotnet add TwinSim.Services/TwinSim.Services.csproj reference TwinSim.Domain/TwinSim.Domain.csproj

# Les tests ont besoin du service et du domain
dotnet add TwinSim.Tests/TwinSim.Tests.csproj reference TwinSim.Services/TwinSim.Services.csproj
dotnet add TwinSim.Tests/TwinSim.Tests.csproj reference TwinSim.Domain/TwinSim.Domain.csproj
