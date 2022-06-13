FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["BI.Database/BI.Database.csproj", "BI.Database/"]
RUN dotnet restore "BI.Database/BI.Database.csproj"
COPY . .
WORKDIR "/src/BI.Database"
RUN dotnet build "BI.Database.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BI.Database.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BI.Database.dll"]
