FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src/service
#common should be replaced by nuget foundation libs
COPY ["Microservices/Common/Poke.CloudSalesSystem.Common/Poke.CloudSalesSystem.Common/Poke.CloudSalesSystem.Common.csproj", "../Common/Poke.CloudSalesSystem.Common/Poke.CloudSalesSystem.Common/"]
COPY ["Microservices/Common/Poke.CloudSalesSystem.Contracts.Events/Poke.CloudSalesSystem.Contracts.Events/Poke.CloudSalesSystem.Contracts.Events.csproj", "../Common/Poke.CloudSalesSystem.Contracts.Events/Poke.CloudSalesSystem.Contracts.Events/"]
#end common
COPY ["Microservices/Poke.CloudSalesSystem.Customers/Poke.CloudSalesSystem.Customers.API/Poke.CloudSalesSystem.Customers.API.csproj", "Poke.CloudSalesSystem.Customers.API/"]
RUN dotnet restore "Poke.CloudSalesSystem.Customers.API/Poke.CloudSalesSystem.Customers.API.csproj"
COPY ./Microservices/Common/ ../Common
COPY ./Microservices/Poke.CloudSalesSystem.Customers/ .
WORKDIR /src/service
RUN dotnet build "Poke.CloudSalesSystem.Customers.API/Poke.CloudSalesSystem.Customers.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Poke.CloudSalesSystem.Customers.API/Poke.CloudSalesSystem.Customers.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Poke.CloudSalesSystem.Customers.API.dll"]