FROM microsoft/aspnetcore:2.0 AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/aspnetcore-build:2.0 AS build
WORKDIR /src
COPY BoynerCase.sln ./
COPY BoynerCase.Api.Product/BoynerCase.Api.Product.csproj BoynerCase.Api.Product/
COPY Boyner.DTO/Boyner.DTO.csproj Boyner.DTO/
RUN dotnet restore -nowarn:msb3202,nu1503
COPY . .
WORKDIR /src/BoynerCase.Api.Product
RUN dotnet build -c Release -o /app

FROM build AS publish
RUN dotnet publish -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "BoynerCase.Api.Product.dll"]
