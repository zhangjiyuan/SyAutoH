cd ../ice_tools
slice2cpp ../ice_interface/MesLink.ice --add-header "stdafx.h" --output-dir ../common
slice2cs ../ice_interface/MesLink.ice  --output-dir ../common

pause