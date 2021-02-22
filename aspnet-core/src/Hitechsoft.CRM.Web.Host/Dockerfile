#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["src/Hitechsoft.CRM.Web.Host/Hitechsoft.CRM.Web.Host.csproj", "src/Hitechsoft.CRM.Web.Host/"]
COPY ["src/Hitechsoft.CRM.Web.Core/Hitechsoft.CRM.Web.Core.csproj", "src/Hitechsoft.CRM.Web.Core/"]
COPY ["src/Hitechsoft.CRM.Application/Hitechsoft.CRM.Application.csproj", "src/Hitechsoft.CRM.Application/"]
COPY ["src/Hitechsoft.CRM.Application.Shared/Hitechsoft.CRM.Application.Shared.csproj", "src/Hitechsoft.CRM.Application.Shared/"]
COPY ["src/Hitechsoft.CRM.Core.Shared/Hitechsoft.CRM.Core.Shared.csproj", "src/Hitechsoft.CRM.Core.Shared/"]
COPY ["src/Hitechsoft.CRM.Core/Hitechsoft.CRM.Core.csproj", "src/Hitechsoft.CRM.Core/"]
COPY ["src/Hitechsoft.CRM.EntityFrameworkCore/Hitechsoft.CRM.EntityFrameworkCore.csproj", "src/Hitechsoft.CRM.EntityFrameworkCore/"]
COPY ["src/Hitechsoft.CRM.GraphQL/Hitechsoft.CRM.GraphQL.csproj", "src/Hitechsoft.CRM.GraphQL/"]
RUN dotnet restore "src/Hitechsoft.CRM.Web.Host/Hitechsoft.CRM.Web.Host.csproj"
COPY . .
WORKDIR "/src/src/Hitechsoft.CRM.Web.Host"
RUN dotnet build "Hitechsoft.CRM.Web.Host.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Hitechsoft.CRM.Web.Host.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Hitechsoft.CRM.Web.Host.dll"]
