// dllmain.h : Declaration of module class.

class CCPPProjectModule : public ATL::CAtlDllModuleT< CCPPProjectModule >
{
public :
	DECLARE_LIBID(LIBID_CPPProjectLib)
	DECLARE_REGISTRY_APPID_RESOURCEID(IDR_CPPPROJECT, "{7dc85997-024f-4db9-985e-55f80b4f6643}")
};

extern class CCPPProjectModule _AtlModule;
