#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:8.0 AS base
USER app
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Test.Consumer/Test.Consumer.csproj", "Test.Consumer/"]
COPY ["Test.Consumer.Application/Test.Consumer.Application.csproj", "Test.Consumer.Application/"]
COPY ["Test.Domain/Test.Domain.csproj", "Test.Domain/"]
COPY ["Test.Consumer.Infrastructure/Test.Consumer.Infrastructure.csproj", "Test.Consumer.Infrastructure/"]
RUN dotnet restore "./Test.Consumer/Test.Consumer.csproj"
COPY . .
WORKDIR "/src/Test.Consumer"
RUN dotnet build "./Test.Consumer.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Test.Consumer.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Test.Consumer.dll"]