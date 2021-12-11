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

    public sealed class ApiComments : AppService<ApiComments>
    {
        public Dictionary<FS.FilePath, Dictionary<string,string>> Collect()
        {
            var dir = ProjectDb.Subdir("api/comments");
            dir.Clear();
            var src = Pull();
            var dst = new Dictionary<FS.FilePath, Dictionary<string,ApiComment>>();
            foreach(var part in src.Keys)
            {
                var id = part.FileName.WithoutExtension.Name;
                var path = ProjectDb.TablePath<ApiComment>("api", "comments", id, FS.Csv);
                var flow = EmittingTable<ApiComment>(path);
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
                EmittedTable(flow, kvp.Count);
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

        Dictionary<FS.FilePath, Dictionary<string,string>> Pull()
        {
            var archive = core.controller().RuntimeArchive();
            var paths = archive.XmlFiles;
            var dst = new Dictionary<FS.FilePath, Dictionary<string,string>>();
            var t = default(ApiComment);
            foreach(var xmlfile in paths)
            {
                var loading = Running(string.Format("Loading {0}", xmlfile));
                var data = xmlfile.ReadText();
                Ran(loading);
                var parsed = parse(data);
                if(parsed.Count != 0)
                {
                    dst[xmlfile] = parsed;
                    var id = string.Format("{0}.{1}", "api.comments", xmlfile.FileName.WithoutExtension.Name);
                    var path = ProjectDb.FilePath("api", "comments", id, FS.Xml);
                    var emitting = EmittingFile(path);
                    using var writer = path.Utf8Writer();
                    writer.WriteLine(data);
                    EmittedFile(emitting, parsed.Count);
                }

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
                var summary = text.replace(text.unfence(value, fence).RemoveAny((char)AsciControlSym.CR, (char)AsciControlSym.LF).Trim(), Chars.Pipe, Chars.Caret);
                return ParseResult.win(key, new ApiComment(k, name, summary));
            }
            else
                return ParseResult.fail<ApiComment>(key);
        }
    }
}