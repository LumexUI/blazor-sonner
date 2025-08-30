# -----------------------------
# Stage 1: build/publish
# -----------------------------
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build

WORKDIR /src

COPY . .
RUN dotnet publish ./docs/Blazor.Sonner.Docs -c Release -o app

# -----------------------------
# Stage 2: runtime
# -----------------------------
FROM mcr.microsoft.com/dotnet/aspnet:9.0
COPY --from=build /src/app .

EXPOSE 8080
ENTRYPOINT ["dotnet","Blazor.Sonner.Docs.dll"]
