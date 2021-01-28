using Microsoft.AspNetCore.Html;
using Microsoft.Diagnostics.Runtime;
using Microsoft.DotNet.Interactive;
using Microsoft.DotNet.Interactive.Formatting;
using Shirhatti.DiagnosticsExtensions.ClrMdExtensions;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Shirhatti.DiagnosticsExtensions
{
    public class DiagnosticsExtensions : IKernelExtension
    {
        public Task OnLoadAsync(Kernel kernel)
        {
            //Formatter.Register<DataTarget>(DataTargetFormatter.Format, "text/html");
            //Formatter.Register<ClrAppDomain>(ClrAppDomainFormatter.Format, "text/html");
            //Formatter.Register<ImmutableArray<ClrAppDomain>>(ClrAppDomainFormatter.Format, "text/html");

            return Task.CompletedTask;
        }
    }
}
