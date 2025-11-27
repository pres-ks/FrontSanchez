FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY . .
RUN dotnet publish -c Release -o /app/publish

FROM nginx:alpine AS final
WORKDIR /usr/share/nginx/html

# Copiar SOLO los archivos estáticos de wwwroot
COPY --from=build /app/publish/wwwroot .

# Configuración de Nginx para SPA
COPY nginx.conf /etc/nginx/nginx.conf

EXPOSE 8080
CMD ["nginx", "-g", "daemon off;"]
