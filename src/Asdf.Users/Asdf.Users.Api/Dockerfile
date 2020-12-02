#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-nanoserver-1903 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-nanoserver-1903 AS build
WORKDIR /src
COPY ["src/Asdf.Users/Asdf.Users.Api/Asdf.Users.Api.csproj", "src/Asdf.Users/Asdf.Users.Api/"]
COPY ["src/Asdf.Users/Asdf.Users.Services/Asdf.Users.Services.csproj", "src/Asdf.Users/Asdf.Users.Services/"]
COPY ["src/Asdf.Users/Asdf.Users.Models/Asdf.Users.Models.csproj", "src/Asdf.Users/Asdf.Users.Models/"]
COPY ["src/Asdf.Users/Asdf.Users.Agregates/Asdf.Users.Agregates.csproj", "src/Asdf.Users/Asdf.Users.Agregates/"]
RUN dotnet restore "src/Asdf.Users/Asdf.Users.Api/Asdf.Users.Api.csproj"
COPY . .
WORKDIR "/src/src/Asdf.Users/Asdf.Users.Api"
RUN dotnet build "Asdf.Users.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Asdf.Users.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Asdf.Users.Api.dll"]