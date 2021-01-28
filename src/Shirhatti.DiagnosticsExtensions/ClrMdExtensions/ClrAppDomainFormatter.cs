using Microsoft.AspNetCore.Html;
using Microsoft.Diagnostics.Runtime;
using Microsoft.DotNet.Interactive.Formatting;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shirhatti.DiagnosticsExtensions.ClrMdExtensions
{
    public static class ClrAppDomainFormatter
    {
        public static void Format(ClrAppDomain appDomain, TextWriter writer)
        {
            var rows = new List<List<IHtmlContent>>();
            PopulateRows(ref rows, appDomain);
            writer.Write(CreateTable(rows));
        }
        public static void Format(ImmutableArray<ClrAppDomain> appDomains, TextWriter writer)
        {
            var rows = new List<List<IHtmlContent>>();
            foreach (var appDomain in appDomains)
            {
                PopulateRows(ref rows, appDomain);
            }
            writer.Write(CreateTable(rows));
        }

        private static dynamic CreateTable(List<List<IHtmlContent>> rows)
        {
            var headers = new List<IHtmlContent>();
            var columnNames = new string[] { "ID", "Name", "Address" };
            headers.AddRange(columnNames.Select(c => (IHtmlContent)PocketViewTags.th(c)));
            var table = PocketViewTags.table(
                PocketViewTags.thead(
                    headers),
                PocketViewTags.tbody(
                    rows.Select(
                        r => PocketViewTags.tr(r))));
            return table;
        }

        private static void PopulateRows(ref List<List<IHtmlContent>> rows, ClrAppDomain appDomain)
        {
            var cells = new List<IHtmlContent>
                    {
                        PocketViewTags.td(appDomain.Id),
                        PocketViewTags.td(appDomain.Name),
                        PocketViewTags.td(appDomain.Address)
                    };

            rows.Add(cells);
        }
    }
}
