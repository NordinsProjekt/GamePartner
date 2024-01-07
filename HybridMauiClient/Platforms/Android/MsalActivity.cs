using Android.App;
using Android.Content;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HybridMauiClient
{
    [Activity(Exported = true)]
    [IntentFilter(new[] {Intent.ActionView},
        Categories = new[] { Intent.CategoryBrowsable, Intent.CategoryDefault},
        DataHost = "auth",
        DataScheme = "msal81793abd-11bb-4f80-96b4-c8042d70fd7e")]
    public class MsalActivity : BrowserTabActivity
    {
    }
}
