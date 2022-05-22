//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class ApiComments
    {
        partial class CommentDataset
        {
            public static FS.FileName CsvFile(PartId part)
                => FS.file(string.Format("api.comments.z0", part.Format()), FS.Csv);

            public static FS.FileName XmlFile(PartId part)
                => FS.file(string.Format("api.comments.z0", part.Format()), FS.Xml);

            public static FS.FilePath CsvPath(FS.FolderPath dir, PartId part)
                => dir + CsvFile(part);

            public static FS.FilePath XmlPath(FS.FolderPath dir, PartId part)
                => dir + XmlFile(part);

            static Dictionary<string,string> TypeNameReplacements;

            static CommentDataset()
            {
                TypeNameReplacements = new();
                TypeNameReplacements.Add("System.Byte","uint8");
                TypeNameReplacements.Add("System.SByte","int8");
                TypeNameReplacements.Add("System.UInt16","uint16");
                TypeNameReplacements.Add("System.Int16","int16");
                TypeNameReplacements.Add("System.UInt32","uint32");
                TypeNameReplacements.Add("System.Int32","int32");
                TypeNameReplacements.Add("System.UInt64","uint64");
                TypeNameReplacements.Add("System.Int64","int64");
                TypeNameReplacements.Add("System.Float","float32");
                TypeNameReplacements.Add("System.Double","float64");
                TypeNameReplacements.Add("System.String","string");
            }

            public static string TypeDisplayName(string src)
            {
                var name = src.Remove("System.Runtime.Intrinsics.").Replace(Chars.LBrace, Chars.Lt).Replace(Chars.RBrace, Chars.Gt).Remove("@");
                core.iter(TypeNameReplacements, x => name = name.Replace(x.Key,x.Value));
                return name;
            }

        }
    }
}