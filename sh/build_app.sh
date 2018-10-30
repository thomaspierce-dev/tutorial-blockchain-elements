#!/bin/bash
dotnet restore
dotnet build
dotnet publish  ~/dev/reference/tutorial-blockchain-elements/src/Infrastructure.WebApi/Infrastructure.WebApi.csproj -o ~/dev/reference/tutorial-blockchain-elements/publish