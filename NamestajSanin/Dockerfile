FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

COPY . .
RUN ls -la /app

RUN dotnet restore
RUN dotnet build NamestajSanin.csproj -c Release -o out --no-restore
RUN dotnet publish NamestajSanin.csproj -c Release -o out --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app

# Kopiraa build output + logo u runtime image
COPY --from=build /app/out . 
COPY LiberationSans-Regular.ttf ./LiberationSans-Regular.ttf
COPY logo.jpg ./logo.jpg

EXPOSE 80
ENV ASPNETCORE_URLS=http://+:80

ENTRYPOINT ["dotnet", "NamestajSanin.dll"]
