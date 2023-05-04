#!/bin/bash

cd /Users/zolotoy/Documents/Delta/Delta/bin/Release/net7.0/publish || exit
zip -r delta.zip ./
scp delta.zip roman@95.163.236.186:~
rm delta.zip  