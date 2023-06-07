FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /app

COPY src/BookBaazar.Domain/BookBaazar.Domain.csproj ./src/BookBaazar.Domain/
COPY src/BookBaazar.Application/BookBaazar.Application.csproj ./src/BookBaazar.Application/
COPY src/BookBaazar.Infrastructure/BookBaazar.Infrastructure.csproj ./src/BookBaazar.Infrastructure/
COPY src/BookBaazar.Api/BookBaazar.Api.csproj ./src/BookBaazar.Api/
RUN dotnet restore ./src/BookBaazar.Api/BookBaazar.Api.csproj

COPY . ./
RUN dotnet publish ./src/BookBaazar.Api -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS runtime
WORKDIR /app
EXPOSE 5432
COPY --from=build /app/out .
ENTRYPOINT ["dotnet", "BookBaazar.Api.dll"]
