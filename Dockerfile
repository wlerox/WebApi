#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["UserInfo.API/UserInfo.API.csproj", "UserInfo.API/"]
COPY ["UserInfo.Business/UserInfo.Business.csproj", "UserInfo.Business/"]
COPY ["UserInfo.DataAccess/UserInfo.DataAccess.csproj", "UserInfo.DataAccess/"]
COPY ["UserInfo.Entities/UserInfo.Entities.csproj", "UserInfo.Entities/"]
RUN dotnet restore "UserInfo.API/UserInfo.API.csproj"
COPY . .
WORKDIR "/src/UserInfo.API"
RUN dotnet build "UserInfo.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "UserInfo.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "UserInfo.API.dll"]