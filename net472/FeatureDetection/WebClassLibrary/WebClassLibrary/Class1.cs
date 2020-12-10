using System.Security.Permissions;
using System.Web;

namespace WebClassLibrary
{
    public class Class1
    {
        int x = 5;
        AspNetHostingPermission permission = new AspNetHostingPermission(PermissionState.None);
    }
}
