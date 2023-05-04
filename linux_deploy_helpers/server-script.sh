#!/bin/bash

# rename all <your_project_name> entries and put this file on server
  
sudo service delta stop
sudo unzip -o delta.zip -d /var/www/delta # your project folder on server
sudo rm delta.zip
sudo service delta start