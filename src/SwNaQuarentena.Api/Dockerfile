FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /src
COPY ["src/SwNaQuarentena.Api/SwNaQuarentena.Api.csproj", "src/SwNaQuarentena.Api/"]
RUN dotnet restore "src/SwNaQuarentena.Api/SwNaQuarentena.Api.csproj"
COPY . .
WORKDIR "/src/src/SwNaQuarentena.Api"
RUN dotnet build "SwNaQuarentena.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SwNaQuarentena.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SwNaQuarentena.Api.dll"]
