using UCDArch.Web.Controller;
using UCDArch.Web.Attributes;

namespace UcdArchTemplates.Web.Controllers
{
    [Version(MajorVersion = 3)]
    //[ServiceMessage("UcdArchTemplates.Web", ViewDataKey = "ServiceMessages", MessageServiceAppSettingsKey = "MessageService")]
    public abstract class ApplicationController : SuperController
    {
    }
}