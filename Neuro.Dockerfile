FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
USER $APP_UID

WORKDIR /app
EXPOSE 8080


FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release

WORKDIR /src

COPY ["NeuroChecker.Backend.Service.Neuro/NeuroChecker.Backend.Service.Neuro.csproj", "NeuroChecker.Backend.Service.Neuro/"]
COPY ["NeuroChecker.Backend.Identity.Permission/NeuroChecker.Backend.Identity.Permission.csproj", "NeuroChecker.Backend.Identity.Permission/"]

RUN dotnet restore "NeuroChecker.Backend.Service.Neuro/NeuroChecker.Backend.Service.Neuro.csproj"
COPY . .

WORKDIR "/src/NeuroChecker.Backend.Service.Neuro"
RUN dotnet build "./NeuroChecker.Backend.Service.Neuro.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release

RUN dotnet publish "./NeuroChecker.Backend.Service.Neuro.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app

COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "NeuroChecker.Backend.Service.Neuro.dll"]
