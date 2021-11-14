//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Collections.Generic;
    using System.Xml;
    using System.IO;

    public sealed class ApiComments : AppService<ApiComments>, IApiComments
    {
        public Dictionary<FS.FilePath, Dictionary<string,string>> Collect()
            => collect(Wf);

        public static Dictionary<FS.FilePath, Dictionary<string,string>> collect(IWfRuntime wf)
        {
            var src = pull(wf);
            var dst = new Dictionary<FS.FilePath, Dictionary<string,ApiComment>>();
            foreach(var part in src.Keys)
            {
                var id = part.FileName.WithoutExtension.Name;
                var path = wf.Db().Table<ApiComment>(id, FS.Csv);
                var flow = wf.EmittingTable<ApiComment>(path);

                var docs = new Dictionary<string, ApiComment>();
                dst[part] = docs;
                using var writer = path.Writer();

                var kvp = src[part];
                foreach(var key in kvp.Keys)
                {
                    var member = parse(key, kvp[key]).OnSuccess(d => docs[d.Identifer] = d);
                    if(member.Succeeded)
                        writer.WriteLine(format(member.Value));
                }
                wf.EmittedTable(flow, kvp.Count);
            }
            return src;
        }

        const string Sep = "| ";

        public static ApiCommentTarget kind(char src)
            => src switch {
                'T' => ApiCommentTarget.Type,
                'M' => ApiCommentTarget.Method,
                'P' => ApiCommentTarget.Property,
                'F' => ApiCommentTarget.Field,
                _ => ApiCommentTarget.None,
            };

        public static string format(ApiComment src)
            => text.concat(src.Kind.ToString().PadRight(12), Sep, src.Identifer.PadRight(70), Sep, src.Summary);

        static Dictionary<FS.FilePath, Dictionary<string,string>> pull(IWfRuntime wf)
        {
            var archive = core.controller().RuntimeArchive();
            var paths = archive.XmlFiles;
            var dst = new Dictionary<FS.FilePath, Dictionary<string,string>>();
            var t = default(ApiComment);
            foreach(var xmlfile in paths)
            {
                var flow = wf.Running(xmlfile);
                var data = xmlfile.ReadText();
                var parsed = parse(data);
                if(parsed.Count != 0)
                    dst[xmlfile] = parsed;

                wf.Ran(flow, parsed.Count);
            }
            return dst;
        }

        static Dictionary<string,string> parse(string src)
        {
            var index = new Dictionary<string, string>();
            using var xmlReader = XmlReader.Create(new StringReader(src));
            while (xmlReader.Read())
            {
                if (xmlReader.NodeType == XmlNodeType.Element && xmlReader.Name == "member")
                {
                    string raw_name = xmlReader["name"];
                    index[raw_name] = xmlReader.ReadInnerXml();
                }
            }
            return index;
        }

        static ParseResult<ApiComment> parse(string key, string value)
        {
            var components = key.SplitClean(Chars.Colon);
            if(components.Length == 2 && components[0].Length == 1)
            {
                var k = kind(components[0][0]);
                var name = components[1];
                var fence = RuleModels.fence("<summary>", "</summary>");
                var summary = text.unfence(value, fence).RemoveAny((char)AsciControlSym.CR, (char)AsciControlSym.LF).Trim();
                return ParseResult.win(key, new ApiComment(k, name, summary));
            }
            else
                return ParseResult.fail<ApiComment>(key);
        }
    }
}