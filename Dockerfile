
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app 


COPY AluguelMotos.csproj ./
RUN dotnet restore "AluguelMotos.csproj"

COPY . ./
RUN dotnet publish "AluguelMotos.csproj" -c Release -o /app/publish


FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/publish .

EXPOSE 5000

ENTRYPOINT ["dotnet", "AluguelMotos.dll"]
