//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Xml;
    using System.IO;
    using System.Linq;

    using static core;
    using static Markdown;

    public sealed class ApiComments : AppService<ApiComments>
    {
        AppDb AppDb => Service(Wf.AppDb);

        static Dictionary<string,string> TypeNameReplacements;

        static ApiComments()
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
            core.iter(TypeNameReplacements,x => name = name.Replace(x.Key,x.Value));
            return name;
        }

        public void EmitMarkdownDocs(string[] _types)
        {
            var typenames = _types.ToHashSet();
            var markers = typenames.Map(n => (n,string.Format(".{0}.",n))).ToDictionary();
            var ds = Calc();
            ref readonly var src = ref ds.Comments;
            var paths = src.Keys.Array();
            for(var i=0; i<paths.Length; i++)
            {
                ref readonly var path = ref skip(paths,i);
                if(path.Contains("z0.lib.xml"))
                {
                    var comments = src[path];
                    var selected =
                        from c in comments
                        from m in markers
                            let key = c.Key
                            let value = c.Value
                        where key.Contains(m.Value)
                            where value.Kind == ApiCommentTarget.Method
                        select (Type:m.Key, Method:key, value);

                    var types = (from groups in selected.Map(x => (x.Type, x.Method, Comment:x.value)).GroupBy(x => x.Type)
                                let type = groups.Key
                                select (type, groups.Index())).ToDictionary();


                    foreach(var typename in types.Keys)
                    {
                        var rows = types[typename];
                        var k=0u;
                        var parts = alloc<ISection>(rows.Length + 1);
                        var doc = Markdown.doc(parts);
                        for(var j=0; j<rows.Length; j++, k++)
                        {
                            (var _, var method, var comment) = rows[j];
                            var ms = MethodCommentSig.from(comment);
                            doc[k] = Markdown.section(k, header(3, ms.Format()), comment.Summary);
                        }
                        var dst = AppDb.Api() + FS.folder("markdown") + FS.file(string.Format("z0.lib.{0}", typename), FS.Md);
                        FileEmit(doc.Format(), k, dst);
                    }

                    break;
                }
            }
        }

        public Dictionary<FS.FilePath, Dictionary<string,string>> Collect()
        {
            var dir = ProjectDb.Subdir("api/comments");
            dir.Clear();
            var src = Pull();
            var dst = new Dictionary<FS.FilePath, Dictionary<string,ApiComment>>();
            foreach(var part in src.Keys)
            {
                var id = part.FileName.WithoutExtension.Name;
                var path = ProjectDb.TablePath<ApiComment>("api/comments", id);
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

        public static ApiComment comment2(ApiCommentTarget target, string name, string value)
        {
            var content = text.trim(text.unfence(value, RenderFence.define("<summary>", "</summary>")));
            core.iter(Replacements,kvp => content = text.replace(content, kvp.Key, kvp.Value));

            content = core.map(content.Lines(), x=> x.Content).Concat(Chars.Eol);
            return new ApiComment(target, name, content);
        }

        static bool parse(string key, string value, out ApiComment dst)
        {
            var components = key.SplitClean(Chars.Colon);
            var result = components.Length == 2 && components[0].Length == 1;
            if(result)
                dst = comment2(kind(components[0][0]), components[1], value);
            else
                dst = new ApiComment(0, EmptyString, EmptyString);

            return result;
        }

        public ApiCommentDataset Calc()
        {
            var xmlData = new Dictionary<FS.FilePath, Dictionary<string,string>>();
            var archive = core.controller().RuntimeArchive();
            var xmlFiles = archive.XmlFiles;
            foreach(var xmlfile in xmlFiles)
            {
                var elements = ParseXmlData(xmlfile.ReadText());
                if(elements.Count != 0)
                    xmlData[xmlfile] = elements;

            }

            var comments = new Dictionary<FS.FilePath, Dictionary<string,ApiComment>>();
            var csvRows = core.dict<FS.FilePath,List<string>>();
            foreach(var part in xmlData.Keys)
            {
                var id = part.FileName.WithoutExtension.Name;
                var path = ProjectDb.TablePath<ApiComment>("api/comments", id);
                var docs = new Dictionary<string, ApiComment>();
                comments[part] = docs;
                csvRows[path] = new();

                var kvp = xmlData[part];
                foreach(var key in kvp.Keys)
                {
                    var result = parse(key, kvp[key], out ApiComment comment);
                    docs[key] = comment;
                    if(result)
                        csvRows[path].Add(format(comment));
                }
            }

            return new(xmlData, comments, csvRows);
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
                var parsed = ParseXmlData(data);
                if(parsed.Count != 0)
                {
                    dst[xmlfile] = parsed;
                    var id = string.Format("{0}.{1}", "api.comments", xmlfile.FileName.WithoutExtension.Name);
                    var path = ProjectDb.FilePath("api/comments", id, FS.Xml);
                    var emitting = EmittingFile(path);
                    using var writer = path.Utf8Writer();
                    writer.WriteLine(data);
                    EmittedFile(emitting, parsed.Count);
                }

            }
            return dst;
        }

        static Dictionary<string,string> ParseXmlData(string src)
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

        [MethodImpl(Inline)]
        static KeyValuePair<K,V> kvp<K,V>(K key, V value)
            => new KeyValuePair<K, V>(key,value);

        static Dictionary<string,string> Replacements = new (new KeyValuePair<string,string>[]{
            kvp("&gt;",">")
            }
        );

        static ApiComment comment(ApiCommentTarget target, string name, string summary)
        {
            var content = summary;
            core.iter(Replacements,kvp => content = text.replace(content, kvp.Key,kvp.Value));
            return new ApiComment(target,name, content);
        }

        static ParseResult<ApiComment> parse(string key, string value)
        {
            var components = key.SplitClean(Chars.Colon);
            if(components.Length == 2 && components[0].Length == 1)
            {
                var summary = text.replace(
                              text.unfence(value, RenderFence.define("<summary>", "</summary>"))
                                 .RemoveAny((char)AsciControlSym.CR, (char)AsciControlSym.LF).Trim(), Chars.Pipe, Chars.Caret);

                return ParseResult.win(key, comment(kind(components[0][0]), components[1], summary));
            }
            else
                return ParseResult.fail<ApiComment>(key);
        }
    }
}