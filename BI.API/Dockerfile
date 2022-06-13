FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["BI.API/BI.API.csproj", "BI.API/"]
RUN dotnet restore "BI.API/BI.API.csproj"
COPY . .
WORKDIR "/src/BI.API"
RUN dotnet build "BI.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BI.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BI.API.dll"]
