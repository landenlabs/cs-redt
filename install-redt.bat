@echo off

@rem TODO - use drive env in script below
 
set prog=redt
set bindir=d:\opt\bin

set devenv="C:\PROGRA~1\Microsoft Visual Studio\2022\Community\Common7\IDE\devenv.com"
set devenv=F:\opt\VisualStudio\2022\Preview\Common7\IDE\devenv.exe 
set msbuild=F:\opt\VisualStudio\2022\Preview\MSBuild\Current\Bin\MSBuild.exe

echo cd %prog%-ms
 
dir


@rem @echo Clean Build 
@rem %devenv% %prog%.sln /Clean "Debug|x64" /Projectconfig "Debug|x64"
@rem %devenv% %prog%.sln /Clean "Release|x64" /Projectconfig "Release|x64"
 
@echo ---- Clean Release %prog% 
lldu -sum %prog%\obj\x64\* 2> nul 
rmdir /s %prog%\obj  2> nul
@rem %msbuild% %prog%.sln  -t:Clean

@echo.
@echo ---- Build Release %prog% 
@rem %devenv% %prog%.sln /Project %prog% /Build "Release|x64"  /Projectconfig "Release|x64"
%msbuild% %prog%.sln -p:Configuration="Release";Platform=x64 -verbosity:minimal  -detailedSummary:True

@echo.
@echo ---- Build done 
if not exist "%prog%\obj\x64\Release\%prog%.exe" (
   echo Failed to build llfile.exe 
   goto _end
)
dir %prog%\obj\x64\Release\%prog%.exe
@echo ---- Copy Release to c:\opt\bin2
copy  %prog%\obj\x64\Release\%prog%.exe %bindir%\%prog%.exe
dir   %prog%\obj\x64\Release\%prog%.exe %bindir%\%prog%.exe

@rem play happy tone
rundll32.exe cmdext.dll,MessageBeepStub
rundll32 user32.dll,MessageBeep
 
:_end
cd ..
 