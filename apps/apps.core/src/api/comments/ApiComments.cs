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

        public ApiCommentDataset Calc()
        {
            var targets = AppDb.ApiTargets("comments");
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
            var csvRowFormat = dict<FS.FilePath,List<string>>();
            var csvRows = dict<FS.FilePath,List<ApiComment>>();
            var formatter = Tables.formatter<ApiComment>();
            foreach(var part in xmlData.Keys)
            {
                var file = FS.file(string.Format("{0}.{1}", "api.comments", part.FileName.WithoutExtension.Name), FS.Csv);
                var path = targets.Path(file);
                var docs = new Dictionary<string, ApiComment>();
                comments[part] = docs;
                csvRowFormat[path] = new();
                csvRows[path] = new();

                var kvp = xmlData[part];
                foreach(var key in kvp.Keys)
                {
                    var result = parse(key, kvp[key], out ApiComment comment);
                    if(result)
                    {
                        docs[key] = comment;
                        csvRows[path].Add(comment);
                        csvRowFormat[path].Add(formatter.Format(comment));
                    }
                    // var result = parse(key, kvp[key], out ApiComment comment);
                    // docs[key] = comment;
                    // if(result)
                    //     csvRows[path].Add(formatter.Format(comment));
                }
            }

            return new(xmlData, comments, csvRows);
        }

        public ApiCommentDataset EmitMarkdownDocs(ApiCommentDataset ds, string[] _types)
        {
            var markers = _types.Map(n => (n, string.Format(".{0}.",n))).ToDictionary();
            ref readonly var src = ref ds.TargetCommentLookup;
            var paths = src.Keys.ToArray();
            for(var i=0; i<paths.Length; i++)
            {
                ref readonly var path = ref skip(paths,i);
                var assemblyComments = src[path];
                var selected =
                    from c in assemblyComments
                    from m in markers
                    let key = c.Key
                    let value = c.Value
                    where key.Contains(m.Value)
                    where value.Target == ApiCommentTarget.Method
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
                        doc[k] = Markdown.section(k, header(3, ms.Format()), comment.Description);
                    }
                    var dst = AppDb.ApiTargets().Targets("markdown").Path(string.Format("z0.lib.{0}", typename), FileKind.Md);
                    FileEmit(doc.Format(), k, dst);
                }
            }

            return ds;
        }

        public void EmitMarkdownDocs(string[] _types)
        {
            var typenames = _types.ToHashSet();
            var markers = typenames.Map(n => (n,string.Format(".{0}.",n))).ToDictionary();
            var ds = Calc();
            ref readonly var src = ref ds.TargetCommentLookup;
            var paths = src.Keys.ToArray();
            for(var i=0; i<paths.Length; i++)
            {
                ref readonly var path = ref skip(paths,i);
                if(path.Contains("z0.lib.xml"))
                {
                    var assemblyComments = src[path];
                    var selected =
                        from c in assemblyComments
                        from m in markers
                            let key = c.Key
                            let value = c.Value
                        where key.Contains(m.Value)
                        where value.Target == ApiCommentTarget.Method
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
                            doc[k] = Markdown.section(k, header(3, ms.Format()), comment.Description);
                        }
                        var dst = AppDb.ApiTargets().Targets("markdown").Path(string.Format("z0.lib.{0}", typename), FileKind.Md);
                        FileEmit(doc.Format(), k, dst);
                    }

                    break;
                }
            }
        }

        public Dictionary<FS.FilePath, Dictionary<string,string>> Collect()
        {
            var targets = AppDb.ApiTargets("comments");
            targets.Clear();
            var src = Pull();
            var dst = new Dictionary<FS.FilePath, Dictionary<string,ApiComment>>();
            var formatter = Tables.formatter<ApiComment>();
            foreach(var part in src.Keys)
            {
                var id = part.FileName.WithoutExtension.Name;
                var file = FS.file(string.Format("{0}.{1}", "api.comments", part.FileName.WithoutExtension.Name), FS.Csv);
                var path = targets.Path(file);
                var flow = EmittingTable<ApiComment>(path);
                var docs = new Dictionary<string, ApiComment>();
                dst[part] = docs;
                using var writer = path.Writer();
                writer.AppendLine(formatter.FormatHeader());
                var kvp = src[part];
                foreach(var key in kvp.Keys)
                {
                    var value = kvp[key];
                    var result = ParseComent(key, value);
                    if(result.Succeeded)
                    {
                        var comment = result.Value;
                        docs[comment.TargetName] = comment;
                        writer.WriteLine(formatter.Format(comment));
                    }
                    else
                        Warn(AppMsg.ParseFailure.Format(key, value));
                }
                EmittedTable(flow, kvp.Count);
            }
            return src;
        }

        static bool parse(string key, string value, out ApiComment dst)
        {
            var components = key.SplitClean(Chars.Colon);
            var result = components.Length == 2 && components[0].Length == 1;
            if(result)
            {
                dst = parse(target(components[0][0]), components[1], value);
            }
            else
                dst = new ApiComment(0, EmptyString, EmptyString);

            return result;
        }

        static ApiComment parse(ApiCommentTarget target, string name, string value)
        {
            var content = text.trim(text.unfence(value, RenderFence.define("<summary>", "</summary>")));
            core.iter(Replacements, kvp => content = text.replace(content, kvp.Key, kvp.Value));
            content = core.map(content.Lines(), x=> x.Content).Concat(Chars.Eol);
            return new ApiComment(target, name, content);
        }

        static ApiCommentTarget target(char src)
            => src switch {
                'T' => ApiCommentTarget.Type,
                'M' => ApiCommentTarget.Method,
                'P' => ApiCommentTarget.Property,
                'F' => ApiCommentTarget.Field,
                _ => ApiCommentTarget.None,
            };

        Dictionary<FS.FilePath, Dictionary<string,string>> Pull()
        {
            var archive = core.controller().RuntimeArchive();
            var targets = AppDb.ApiTargets("comments");
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
                    var file = FS.file(string.Format("{0}.{1}", "api.comments", xmlfile.FileName.WithoutExtension.Name), FS.Xml);
                    FileEmit(data, parsed.Count, targets.Path(file));
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
            => new KeyValuePair<K,V>(key,value);

        static Dictionary<string,string> Replacements = new (new KeyValuePair<string,string>[]{
                    kvp("&gt;",">"),
                }
            );

        static ApiComment comment(ApiCommentTarget target, string name, string summary)
        {
            var content = summary;
            core.iter(Replacements,kvp => content = text.replace(content, kvp.Key,kvp.Value));
            return new ApiComment(target,name, content);
        }

        static ParseResult<ApiComment> ParseComent(string key, string value)
        {
            var components = key.SplitClean(Chars.Colon);
            if(components.Length == 2 && components[0].Length == 1)
            {
                var summary = text.replace(
                              text.unfence(value, RenderFence.define("<summary>", "</summary>"))
                                 .RemoveAny((char)AsciControlSym.CR, (char)AsciControlSym.LF).Trim(), Chars.Pipe, Chars.Caret);

                return ParseResult.win(key, comment(target(components[0][0]), components[1], summary));
            }
            else
                return ParseResult.fail<ApiComment>(key);
        }
    }
}