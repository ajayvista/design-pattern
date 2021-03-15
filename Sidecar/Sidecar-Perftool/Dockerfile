FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["Sidecar.csproj", "./"]
RUN dotnet restore "./Sidecar.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "Sidecar.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Sidecar.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENV ASPNETCORE_URLS http://*:5000
ENTRYPOINT ["dotnet", "Sidecar.dll"]
