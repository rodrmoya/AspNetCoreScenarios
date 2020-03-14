#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ContainerServices.Web/ContainerServices.Web.csproj ContainerServices.Web/
COPY ContainerServices.Shared/ContainerServices.Shared.csproj ContainerServices.Shared/
RUN dotnet restore "ContainerServices.Web/ContainerServices.Web.csproj"
COPY . .
WORKDIR "/src/ContainerServices.Web"
RUN dotnet build "ContainerServices.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ContainerServices.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ContainerServices.Web.dll"]
