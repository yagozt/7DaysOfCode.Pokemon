#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/7DaysOfCode.Pokemon.API/7DaysOfCode.Pokemon.API.csproj", "7DaysOfCode.Pokemon.API/"]
RUN dotnet restore "7DaysOfCode.Pokemon.API/7DaysOfCode.Pokemon.API.csproj"
COPY . .
WORKDIR "/src/7DaysOfCode.Pokemon.API"
RUN dotnet build "7DaysOfCode.Pokemon.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "7DaysOfCode.Pokemon.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "7DaysOfCode.Pokemon.API.dll"]