#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
RUN apt-get update && apt-get install -y curl
USER app
WORKDIR /app
EXPOSE 8084

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/CondoTec.Management.API/CondoTec.Management.API.csproj", "CondoTec.Management.API/"]
COPY ["src/CondoTec.Management.Application/CondoTec.Management.Application.csproj", "CondoTec.Management.Application/"]
COPY ["src/Condotec.Management.Domain/Condotec.Management.Domain.csproj", "Condotec.Management.Domain/"]
COPY ["src/Condotec.Management.Infrastructure/Condotec.Management.Infrastructure.csproj", "Condotec.Management.Infrastructure/"]
COPY ["src/CondoTec.Management.IoC/CondoTec.Management.IoC.csproj", "CondoTec.Management.IoC/"]

RUN dotnet restore "./CondoTec.Management.API/CondoTec.Management.API.csproj"
COPY . .

RUN dotnet build "src/CondoTec.Management.API/CondoTec.Management.API.csproj" -c Release -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release

RUN dotnet publish "src/CondoTec.Management.API/CondoTec.Management.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CondoTec.Management.API.dll"]