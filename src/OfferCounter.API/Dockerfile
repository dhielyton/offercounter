#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/OfferCounter.API/OfferCounter.API.csproj", "src/OfferCounter.API/"]
COPY ["src/OfferCounter.Domain/OfferCounter.Domain.csproj", "src/OfferCounter.Domain/"]
COPY ["src/OfferCounter.Infrastructure/OfferCounter.Infrastructure.csproj", "src/OfferCounter.Infrastructure/"]
RUN dotnet restore "src/OfferCounter.API/OfferCounter.API.csproj"
COPY . .
WORKDIR "/src/src/OfferCounter.API"
RUN dotnet build "OfferCounter.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "OfferCounter.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "OfferCounter.API.dll"]