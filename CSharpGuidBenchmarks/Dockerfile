﻿FROM mcr.microsoft.com/dotnet/runtime:9.0 AS base
USER $APP_UID
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["CSharpGuidBenchmarks/CSharpGuidBenchmarks.csproj", "CSharpGuidBenchmarks/"]
RUN dotnet restore "CSharpGuidBenchmarks/CSharpGuidBenchmarks.csproj"
COPY . .
WORKDIR "/src/CSharpGuidBenchmarks"
RUN dotnet build "CSharpGuidBenchmarks.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "CSharpGuidBenchmarks.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CSharpGuidBenchmarks.dll"]
