FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["EcoManage.Api/EcoManage.Api.csproj", "EcoManage.Api/"]
COPY ["EcoManage.Domain/EcoManage.Domain.csproj", "EcoManage.Domain/"]
COPY ["EcoManage.Persistence/EcoManage.Persistence.csproj", "EcoManage.Persistence/"]
RUN dotnet restore "EcoManage.Api/EcoManage.Api.csproj"
COPY . .
WORKDIR "/src/EcoManage.Api"
RUN dotnet build "EcoManage.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "EcoManage.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "EcoManage.Api.dll"]
