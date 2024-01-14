#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
RUN apt-get update && apt-get install -y curl
USER app
WORKDIR /app
EXPOSE 8083

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/Condotec.Identity.API/Condotec.Identity.API.csproj", "Condotec.Identity.API/"]
COPY ["src/Condotec.Identity.IoC/Condotec.Identity.IoC.csproj", "Condotec.Identity.IoC/"]
COPY ["src/Condotec.Identity.Application/Condotec.Identity.Application.csproj", "Condotec.Identity.Application/"]
COPY ["src/Condotec.Identity.Data/Condotec.Identity.Data.csproj", "Condotec.Identity.Data/"]

RUN dotnet restore "./Condotec.Identity.API/./Condotec.Identity.API.csproj"
COPY . .

RUN dotnet build "src/Condotec.Identity.API/Condotec.Identity.API.csproj" -c Release -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release

RUN dotnet publish "src/Condotec.Identity.API/Condotec.Identity.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Condotec.Identity.API.dll"]