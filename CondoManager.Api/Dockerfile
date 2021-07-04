#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["CondoManager.Api/CondoManager.Api.csproj", "CondoManager.Api/"]
COPY ["CondoManager.Application/CondoManager.Application.csproj", "CondoManager.Application/"]
COPY ["CondoManager.CQS/CondoManager.CQS.csproj", "CondoManager.CQS/"]
COPY ["CondoManager.Domain/CondoManager.Domain.csproj", "CondoManager.Domain/"]
COPY ["CondoManager.Infra.Persistence/CondoManager.Infra.Persistence.csproj", "CondoManager.Infra.Persistence/"]
RUN dotnet restore "CondoManager.Api/CondoManager.Api.csproj"
COPY . .
WORKDIR "/src/CondoManager.Api"
RUN dotnet build "CondoManager.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CondoManager.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CondoManager.Api.dll"]
