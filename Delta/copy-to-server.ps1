cd C:/Users/roman/RiderProjects/DeltaNew/Delta/bin/Release/net7.0/publish
Compress-Archive -Path ./* -DestinationPath ./delta.zip
scp delta.zip roman@95.163.236.186:~
rm delta.zip