cd ../ice_tools
slice2cpp ../ice_interface/iMesLink.ice --add-header "stdafx.h" --output-dir ../common
slice2cs ../ice_interface/iMesLink.ice  --output-dir ../common

slice2cpp ../ice_interface/iFoupMove.ice --add-header "stdafx.h" --output-dir ../common
slice2cs ../ice_interface/iFoupMove.ice  --output-dir ../common

slice2cpp ../ice_interface/iGuiHub.ice --add-header "stdafx.h" --output-dir ../common
slice2cs ../ice_interface/iGuiHub.ice  --output-dir ../common

pause