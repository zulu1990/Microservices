FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80


# This stage is used to build the service project
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Services/Test/Test.Api/Test.Api.csproj", "/Services/Test/Test.Api/"]
COPY ["Services/Test/Test.Api.Entities/Test.Api.Entities.csproj", "/Services/Test/Test.Api.Entities/"]
RUN dotnet restore "/Services/Test/Test.Api/Test.Api.csproj"
COPY . .
WORKDIR "/src/Services/Test/Test.Api"
RUN dotnet build "Test.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Test.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Test.Api.dll"]