#!/bin/bash

# rename all <your_project_name> entries
# change the user_name and ip_address

# use this script for copy publish folder files to server
# then run "server-script.sh" on server

cd /Users/SYSTEM_USER_NAME/Documents/your_project_name/your_project_name/bin/Release/net6.0/publish || exit # use your publish folder path
zip -r your_project_name.zip ./
scp your_project_name.zip user_name@255.255.255.255:~ # change the user_name and ip_address
rm your_project_name.zip