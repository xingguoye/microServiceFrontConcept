#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Test.Queries.Api/Test.Queries.Api.csproj", "Test.Queries.Api/"]
COPY ["Test.Queries.Application/Test.Queries.Application.csproj", "Test.Queries.Application/"]
COPY ["Test.Domain/Test.Domain.csproj", "Test.Domain/"]
COPY ["Test.Queries.Infrastructure/Test.Queries.Infrastructure.csproj", "Test.Queries.Infrastructure/"]
RUN dotnet restore "./Test.Queries.Api/Test.Queries.Api.csproj"
COPY . .
WORKDIR "/src/Test.Queries.Api"
RUN dotnet build "./Test.Queries.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Test.Queries.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Test.Queries.Api.dll"]