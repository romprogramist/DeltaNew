#!/bin/bash

cd C:/Users/roman/RiderProjects/DeltaNew/Delta/bin/Release/net7.0/publish || exit
zip -r delta.zip ./
scp delta.zip roman@95.163.236.186:~
rm delta.zip  

