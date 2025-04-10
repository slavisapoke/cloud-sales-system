FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src/service
#common should be replaced by nuget foundation libs
COPY ["Microservices/Common/Poke.CloudSalesSystem.Common/Poke.CloudSalesSystem.Common/Poke.CloudSalesSystem.Common.csproj", "..Microservices/Common/Poke.CloudSalesSystem.Common/Poke.CloudSalesSystem.Common/"]
COPY ["Microservices/Common/Poke.CloudSalesSystem.Contracts.Events/Poke.CloudSalesSystem.Contracts.Events/Poke.CloudSalesSystem.Contracts.Events.csproj", "..Microservices/Common/Poke.CloudSalesSystem.Contracts.Events/Poke.CloudSalesSystem.Contracts.Events/"]
#end common
COPY ["Poke.CloudSalesSystem.Gateway/Poke.CloudSalesSystem.Gateway.API/Poke.CloudSalesSystem.Gateway.API.csproj", "Poke.CloudSalesSystem.Gateway.API/"]
RUN dotnet restore "Poke.CloudSalesSystem.Gateway.API/Poke.CloudSalesSystem.Gateway.API.csproj"
COPY ./Microservices/Common/ ../Microservices/Common
COPY /Poke.CloudSalesSystem.Gateway/ .
WORKDIR /src/service
RUN dotnet build "Poke.CloudSalesSystem.Gateway.API/Poke.CloudSalesSystem.Gateway.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Poke.CloudSalesSystem.Gateway.API/Poke.CloudSalesSystem.Gateway.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Poke.CloudSalesSystem.Gateway.API.dll"]