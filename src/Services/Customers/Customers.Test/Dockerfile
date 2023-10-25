#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["src/Services/Customers/Customers.Test/Customers.Test.csproj", "src/Services/Customers/Customers.Test/"]
COPY ["src/Services/Customers/Customers.WebApi/Customers.WebApi.csproj", "src/Services/Customers/Customers.WebApi/"]
RUN dotnet restore "src/Services/Customers/Customers.Test/Customers.Test.csproj"
COPY . .
WORKDIR "/src/src/Services/Customers/Customers.Test"
RUN dotnet build "Customers.Test.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Customers.Test.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Customers.Test.dll"]