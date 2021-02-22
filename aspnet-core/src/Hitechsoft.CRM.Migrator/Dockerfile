#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["src/Hitechsoft.CRM.Migrator/Hitechsoft.CRM.Migrator.csproj", "src/Hitechsoft.CRM.Migrator/"]
COPY ["src/Hitechsoft.CRM.EntityFrameworkCore/Hitechsoft.CRM.EntityFrameworkCore.csproj", "src/Hitechsoft.CRM.EntityFrameworkCore/"]
COPY ["src/Hitechsoft.CRM.Core/Hitechsoft.CRM.Core.csproj", "src/Hitechsoft.CRM.Core/"]
COPY ["src/Hitechsoft.CRM.Core.Shared/Hitechsoft.CRM.Core.Shared.csproj", "src/Hitechsoft.CRM.Core.Shared/"]
RUN dotnet restore "src/Hitechsoft.CRM.Migrator/Hitechsoft.CRM.Migrator.csproj"
COPY . .
WORKDIR "/src/src/Hitechsoft.CRM.Migrator"
RUN dotnet build "Hitechsoft.CRM.Migrator.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Hitechsoft.CRM.Migrator.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Hitechsoft.CRM.Migrator.dll"]
