# Build image
FROM mcr.microsoft.com/dotnet/sdk:latest AS build
WORKDIR /app

# Copy project files only
COPY *.sln ./
COPY /BaseConn.Api/*.csproj ./BaseConn.Api/
COPY /BaseConn.Application/*.csproj ./BaseConn.Application/
COPY /BaseConn.Infrastructure/*.csproj ./BaseConn.Infrastructure/
COPY /BaseConn.Domain/*.csproj ./BaseConn.Domain/

# Restore with only project files (cached layer)
RUN dotnet restore

# Now copy everything
COPY . .

# Publish
RUN dotnet publish BaseConn.Api/BaseConn.Api.csproj -c Release -o /out

# Runtime image
FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS runtime
WORKDIR /app
COPY --from=build /out .

EXPOSE 8080

ENTRYPOINT ["dotnet", "BaseConn.Api.dll"]