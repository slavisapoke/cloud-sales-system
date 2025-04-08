FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src/service
#common should be replaced by nuget common packages
COPY ["Microservices/Common/Poke.CloudSalesSystem.Common/Poke.CloudSalesSystem.Common/Poke.CloudSalesSystem.Common.csproj", "../Common/Poke.CloudSalesSystem.Common/Poke.CloudSalesSystem.Common/"]
COPY ["Microservices/Common/Poke.CloudSalesSystem.Contracts.Events/Poke.CloudSalesSystem.Contracts.Events/Poke.CloudSalesSystem.Contracts.Events.csproj", "../Common/Poke.CloudSalesSystem.Contracts.Events/Poke.CloudSalesSystem.Contracts.Events/"]
#end common
COPY ["Microservices/Poke.CloudSalesSystem.Licences/Poke.CloudSalesSystem.Licences.API/Poke.CloudSalesSystem.Licences.API.csproj", "Poke.CloudSalesSystem.Licences.API/"]
RUN dotnet restore "Poke.CloudSalesSystem.Licences.API/Poke.CloudSalesSystem.Licences.API.csproj"
COPY ./Microservices/Common/ ../Common
COPY ./Microservices/Poke.CloudSalesSystem.Licences/ .
WORKDIR /src/service
RUN dotnet build "Poke.CloudSalesSystem.Licences.API/Poke.CloudSalesSystem.Licences.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Poke.CloudSalesSystem.Licences.API/Poke.CloudSalesSystem.Licences.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Poke.CloudSalesSystem.Licences.API.dll"]