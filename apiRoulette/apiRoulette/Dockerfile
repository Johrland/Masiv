FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ["apiRoulette/apiRoulette.csproj", "apiRoulette/"]
RUN dotnet restore "apiRoulette/apiRoulette.csproj"
COPY . .
WORKDIR "/src/apiRoulette"
RUN dotnet build "apiRoulette.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "apiRoulette.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "apiRoulette.dll"]