# -----------------------------
# Stage 1: build/publish
# -----------------------------
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build

RUN apt-get update && apt-get install -y curl \
    && curl -fsSL https://deb.nodesource.com/setup_22.x | bash - \
    && apt-get install -y nodejs \
    && apt-get clean && rm -rf /var/lib/apt/lists/*

WORKDIR /src

COPY . .
RUN dotnet publish ./docs/Blazor.Sonner.Docs -c Release -o app
RUN node ./scripts/export-static.mjs app/Blazor.Sonner.Docs.dll /static

# -----------------------------
# Stage 2: static site
# -----------------------------
FROM alpine:3
COPY --from=build /static /static
