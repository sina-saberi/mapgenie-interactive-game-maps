# Stage 1: Build Next.js frontend
FROM node:18-alpine AS frontend-build
WORKDIR /app/game-maps-client
COPY game-maps-client/package*.json ./
RUN npm install
COPY game-maps-client/ .
RUN npm run build

# Stage 2: Build .NET backend
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS backend-build
WORKDIR /app
COPY game-maps/ ./game-maps
WORKDIR /app/game-maps
RUN dotnet restore
RUN dotnet publish -c Release -o /app/publish

# Stage 3: Final container (with both .NET and Node.js installed)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app

# Install Node.js to run the Next.js frontend
RUN apt-get update && \
    apt-get install -y curl && \
    curl -fsSL https://deb.nodesource.com/setup_18.x | bash - && \
    apt-get install -y nodejs && \
    rm -rf /var/lib/apt/lists/*

# Copy the backend files
COPY --from=backend-build /app/publish ./backend

# Copy the frontend build files and the package.json file
COPY --from=frontend-build /app/game-maps-client /app/frontend

# Expose the ports for frontend and backend
EXPOSE 7195   
# Backend (Kestrel .NET)
EXPOSE 3000   
# Frontend (Next.js)

# Entry point for both backend and frontend
CMD dotnet backend/game-maps.dll & npm run start --prefix /app/frontend