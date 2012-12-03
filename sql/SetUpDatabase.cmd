@ECHO OFF
@REM  ----------------------------------------------------------------------------
@REM  SetupDataBase.cmd file
@REM
@REM  This cmd file calls the SQL script to create the database and tables 
@REM  required for the reference implementation. The script creates the database
@REM  in the local AMHS instance. The tables are created in the database named
@REM  MCS. If the database does not yet exist, the SQL script
@REM  will create it. If the MCS database already exists, the
@REM  script will delete it, and then create it.
@REM  
@REM  ----------------------------------------------------------------------------

echo.
echo ================================================================
echo   SetupDatabase
echo      Creates the database required for the MCS reference
echo      implementation. The tables are created in the database
echo      named MCS in the local AMHS instance. 
echo      The script creates the database if it does not exist. If
echo      the database exists, the script will delete it, and then
echo      recreate it. 
echo.
echo      You can modify this command file to create the database
echo      on a different instance of SQL (for example, to use SQL 
echo      Server 2005). If you do this, you must also update the
echo      DBConnection connection string in the
echo      Web.config file of the reference implementation 
echo      MCSServices Web site. 
echo.
echo ================================================================
echo.

if "%1"=="/?" goto HELP

PAUSE 

SETLOCAL
if not Exist MCS.sql goto HELPSCRIPT

@REM  ------------------------------------------------
@REM  Shorten the command prompt for making the output
@REM  easier to read.
@REM  ------------------------------------------------
set savedPrompt=%prompt%
set prompt=*$g

SET serverName="(local)\AMHS"

@ECHO ----------------------------------------
@ECHO SetupDatabase.cmd Started
@ECHO ----------------------------------------
@ECHO.

set cmd=OSQL -S %serverName% -E -n -i MCS.sql 

echo.
@echo %cmd%
@%cmd%

echo.
pause

@REM  ----------------------------------------
@REM  Restore the command prompt and exit
@REM  ----------------------------------------
@goto :exit

@REM  -------------------------------------------
@REM  Handle errors
@REM
@REM  Use the following after any call to exit
@REM  and return an error code when errors occur
@REM
@REM  if errorlevel 1 goto :error	
@REM  -------------------------------------------
:error
@ECHO An error occured in SetupDatabase.cmd - %errorLevel%

@exit errorLevel

:HELPSCRIPT
echo.
echo Error: Unable to locate the required SQL script DatabaseScript.sql
echo.
goto exit

:HELP
echo.
echo Usage: SetupDatabase.cmd 
echo.

@REM  ----------------------------------------
@REM  The exit label
@REM  ----------------------------------------
:exit

set prompt=%savedPrompt%
set savedPrompt=

echo on

