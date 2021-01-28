using Microsoft.AspNetCore.Html;
using Microsoft.Diagnostics.Runtime;
using Microsoft.DotNet.Interactive.Formatting;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Shirhatti.DiagnosticsExtensions.ClrMdExtensions
{
    public static class DataTargetFormatter
    {
        public static void Format(DataTarget dataTarget, TextWriter writer)
        {
            var headers = new List<IHtmlContent>();
            var columnNames = new string[] { "index", "Version", "FileSize", "TimeStamp", "Dac File", "Local Dac location" };
            headers.AddRange(columnNames.Select(c => (IHtmlContent)PocketViewTags.th(c)));

            var rows = new List<List<IHtmlContent>>();
            for (var i = 0; i < dataTarget.ClrVersions.Length; i++)
            {
                var version = dataTarget.ClrVersions[i];
                var cells = new List<IHtmlContent>();
                cells.Add(PocketViewTags.td(i));
                cells.Add(PocketViewTags.td(version.Version.ToString()));
                var dacInfo = version.DacInfo;
                cells.Add(PocketViewTags.td(dacInfo.IndexFileSize));
                cells.Add(PocketViewTags.td(dacInfo.IndexTimeStamp));
                cells.Add(PocketViewTags.td(dacInfo.PlatformSpecificFileName));

                string dacLocation = version.DacInfo.LocalDacPath;
                if (!string.IsNullOrEmpty(dacLocation))
                    cells.Add(PocketViewTags.td(dacLocation));

                rows.Add(cells);
            }

            var t = PocketViewTags.table(
                PocketViewTags.thead(
                    headers),
                PocketViewTags.tbody(
                    rows.Select(
                        r => PocketViewTags.tr(r))));

            writer.Write(t);
        }
    }
}
