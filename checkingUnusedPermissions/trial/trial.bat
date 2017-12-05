IF not "%~1" equ "" (
java -jar PermissionChecker.jar .\%1
GOTO :terminate
)
echo please enter name of apk and the destination to output!
:terminate
pause