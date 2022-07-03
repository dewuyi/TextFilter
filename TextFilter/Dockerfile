FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["TextFilter/TextFilter.csproj", "TextFilter/"]
RUN dotnet restore "TextFilter/TextFilter.csproj"
COPY . .
WORKDIR "/src/TextFilter"
RUN dotnet build "TextFilter.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TextFilter.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TextFilter.dll"]
