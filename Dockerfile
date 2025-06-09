# Giai đoạn build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy toàn bộ source vào container
COPY . .

# Restore dependencies & publish
RUN dotnet restore SV21T1020589CLIENT.sln
RUN dotnet publish SV21T1020589CLIENT.Web/SV21T1020589CLIENT.Web.csproj -c Release -o /app/publish

# Giai đoạn runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app

# Copy output đã publish từ giai đoạn build
COPY --from=build /app/publish .

# Chạy app
ENTRYPOINT ["dotnet", "SV21T1020589CLIENT.Web.dll"]
