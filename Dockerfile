FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["HousingManagementSystemApi/HousingManagementSystemApi.csproj", "HousingManagementSystemApi/"]
ARG PASSWORD
ARG USERNAME
RUN dotnet nuget add source --username $USERNAME --password $PASSWORD --store-password-in-clear-text --name github "https://nuget.pkg.github.com/City-of-Lincoln-Council/index.json"
RUN dotnet restore "HousingManagementSystemApi/HousingManagementSystemApi.csproj"
COPY . .
WORKDIR "/src/HousingManagementSystemApi"
RUN dotnet build "HousingManagementSystemApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "HousingManagementSystemApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "HousingManagementSystemApi.dll"]
