FROM microsoft/dotnet:2.1-aspnetcore-runtime
WORKDIR /app
COPY ./publish .
ENTRYPOINT ["dotnet", "Infrastructure.WebApi.dll"]