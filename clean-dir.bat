@echo off

@rem TODO - use drive env in script below
 
set prog=redt

set msbuild=G:\opt\VisualStudio\18\Community\MSBuild\Current\Bin\MSBuild.exe

cd %prog% 
 
@echo ---- Clean Release %prog% 
%msbuild% %prog%.sln /t:Clean
%msbuild% %prog%.csproj /t:Clean
lldu -sum obj bin 
rmdir /s obj  2> nul
rmdir /s bin  2> nul
@rem %msbuild% %prog%.sln  -t:Clean

cd ..