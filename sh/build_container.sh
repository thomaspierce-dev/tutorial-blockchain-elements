#!/bin/bash

# Kill and remove the docker container
docker rm -f elements_api

# Run the docker image with all of the necessary overrides
docker run  -itd -p 5001:80 \
-e ASPNETCORE_ENVIRONMENT \
--name elements_api walterpinson/tutorial-blockchain-elements