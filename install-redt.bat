@echo off

@rem TODO - use drive env in script below
 
set prog=redt
set bindir=d:\opt\bin
set msbuild=F:\opt\VisualStudio\2022\Preview\MSBuild\Current\Bin\MSBuild.exe
set reldeb=Debug

cd %prog% 
 
@echo ---- Clean Release %prog% 
lldu -sum obj bin 
rmdir /s obj  2> nul
rmdir /s bin  2> nul
@rem %msbuild% %prog%.sln  -t:Clean

@echo.
@echo ---- Build %reldeb% %prog% 
%msbuild% %prog%.sln -p:Configuration="%reldeb%";Platform=x64 -verbosity:minimal  -detailedSummary:True

@echo.
@echo ---- Build done 
if not exist "bin\x64\%reldeb%\%prog%.exe" (
   echo Failed to build bin\x64\%reldeb%\%prog%.exe
   goto _end
)
 
@echo ---- Copy Release to c:\opt\bin2
copy  bin\x64\%reldeb%\%prog%.exe %bindir%\%prog%.exe
dir   bin\x64\%reldeb%\%prog%.exe %bindir%\%prog%.exe

@rem play happy tone
rundll32.exe cmdext.dll,MessageBeepStub
rundll32 user32.dll,MessageBeep
 
:_end
cd ..
 