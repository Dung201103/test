# Dùng SDK để build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

COPY . ./
RUN dotnet restore SV21T1020589CLIENT.sln
RUN dotnet publish SV21T1020589CLIENT.Web/SV21T1020589CLIENT.Web.csproj -c Release -o out

# Dùng ASP.NET runtime để chạy
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/out .

ENTRYPOINT ["dotnet", "SV21T1020589CLIENT.Web.dll"]
