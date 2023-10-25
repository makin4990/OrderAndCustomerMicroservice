#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app


FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["src/Services/Ordering/Ordering.MassTransitConsumer/Ordering.MassTransitConsumer.csproj", "src/Services/Ordering/Ordering.MassTransitConsumer/"]
COPY ["src/Services/Ordering/Ordering.Application/Ordering.Application.csproj", "src/Services/Ordering/Ordering.Application/"]
COPY ["src/Services/Ordering/CoreFramework/CoreFramework.Application/CoreFramework.Application.csproj", "src/Services/Ordering/CoreFramework/CoreFramework.Application/"]
COPY ["src/Services/Ordering/CoreFramework/CoreFramework.CrossCuttingConsern/CoreFramework.CrossCuttingConsern/CoreFramework.CrossCuttingConsern.csproj", "src/Services/Ordering/CoreFramework/CoreFramework.CrossCuttingConsern/CoreFramework.CrossCuttingConsern/"]
COPY ["src/Services/Ordering/CoreFramework/CoreFramework.Mailing/CoreFramework.Mailing.csproj", "src/Services/Ordering/CoreFramework/CoreFramework.Mailing/"]
COPY ["src/Services/Ordering/CoreFramework/CoreFramework.Persistence/CoreFramework.Persistence.csproj", "src/Services/Ordering/CoreFramework/CoreFramework.Persistence/"]
COPY ["src/Services/Ordering/Ordering.Domain/Ordering.Domain.csproj", "src/Services/Ordering/Ordering.Domain/"]
COPY ["src/Services/Ordering/Ordering.Infrastructure/Ordering.Infrastructure.csproj", "src/Services/Ordering/Ordering.Infrastructure/"]
COPY ["src/Services/Ordering/Ordering.MassTransitShared/Ordering.MassTransitShared.csproj", "src/Services/Ordering/Ordering.MassTransitShared/"]
COPY ["src/Services/Ordering/Ordering.Persistence/Ordering.Persistence.csproj", "src/Services/Ordering/Ordering.Persistence/"]
RUN dotnet restore "src/Services/Ordering/Ordering.MassTransitConsumer/Ordering.MassTransitConsumer.csproj"
COPY . .
WORKDIR "/src/src/Services/Ordering/Ordering.MassTransitConsumer"
RUN dotnet build "Ordering.MassTransitConsumer.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Ordering.MassTransitConsumer.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Ordering.MassTransitConsumer.dll"]