FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 7037

ENV ASPNETCORE_URLS=http://+:7037

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["sgvd-activity-db.csproj", "./"]
RUN dotnet restore "sgvd-activity-db.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "sgvd-activity-db.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "sgvd-activity-db.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
COPY ./db /db
ENTRYPOINT ["dotnet", "sgvd-activity-db.dll"]
