#!/bin/bash

rm -f ./bin/api.zip
dotnet publish --configuration Release --output ./bin/publish
cd ./bin/publish
zip -r -q ../api.zip .
