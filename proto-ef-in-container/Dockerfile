#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM microsoft/dotnet:2.1-aspnetcore-runtime-nanoserver-1803 AS base
WORKDIR /app
EXPOSE 52822
EXPOSE 44347

FROM microsoft/dotnet:2.1-sdk-nanoserver-1803 AS build
WORKDIR /src
COPY ["proto-ef-in-container/proto-ef-in-container.csproj", "proto-ef-in-container/"]
RUN dotnet restore "proto-ef-in-container/proto-ef-in-container.csproj"
COPY . .
WORKDIR "/src/proto-ef-in-container"
RUN dotnet build "proto-ef-in-container.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "proto-ef-in-container.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "proto-ef-in-container.dll"]