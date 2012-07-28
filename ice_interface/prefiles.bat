cd ../compile_tools
slice2cpp ../ice/LogInterface.ice --add-header "stdafx.h" --output-dir ../Logger/common/Win32
slice2cppe ../ice/LogInterface.ice --add-header "stdafx.h" --output-dir ../Logger/common/CE
slice2cs ../ice/LogInterface.ice  --output-dir ../Logger/LogWinClientCS

pause