//-----------------------------------------------------------------------------
// Copyright   :  (c) Microsoft Corporation. All rights reserved.
// License     :  MIT
// Origin      : https://github.com/microsoft/CsWin32/src/ScrapeDocs/Program.cs
//-----------------------------------------------------------------------------
namespace Z0.Tools
{
    using System;
    using System.Text.RegularExpressions;

    partial struct MsDocs
    {
        internal readonly struct SearchPatterns
        {
            public static readonly Regex FileNamePattern = new Regex(@"^\w\w-\w+-([\w\-]+)$", RegexOptions.Compiled);

            public static readonly Regex ParameterHeaderPattern = new Regex(@"^### -param (\w+)", RegexOptions.Compiled);

            public static readonly Regex FieldHeaderPattern = new Regex(@"^### -field (?:\w+\.)*(\w+)", RegexOptions.Compiled);

            public static readonly Regex ReturnHeaderPattern = new Regex(@"^## -returns", RegexOptions.Compiled);

            public static readonly Regex RemarksHeaderPattern = new Regex(@"^## -remarks", RegexOptions.Compiled);

            public static readonly Regex InlineCodeTag = new Regex(@"\<code\>(.*)\</code\>", RegexOptions.Compiled);

            public static readonly Regex EnumNameCell = new Regex(@"\<td[^\>]*\>\<a id=""([^""]+)""", RegexOptions.Compiled);

            public static readonly Regex EnumOrdinalValue = new Regex(@"\<dt\>([\dxa-f]+)\<\/dt\>", RegexOptions.Compiled | RegexOptions.IgnoreCase);
        }
    }
}