//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Xml;
    using System.IO;
    using System.Linq;
    using static ApiGranules;

    using static core;

    using CT = ApiCommentTarget;

    public sealed partial class ApiComments : WfSvc<ApiComments>
    {
        public CommentDataset Calc()
        {
            var targets = AppDb.ApiTargets(comments);
            var dllPaths = list<FS.FilePath>();
            var xmlData = new Dictionary<FS.FilePath, Dictionary<string,string>>();
            var archive = core.controller().RuntimeArchive();
            var dllFiles = archive.DllFiles;
            var xmlFiles = archive.XmlFiles;
            foreach(var xmlfile in xmlFiles)
            {
                var elements = ParseXmlData(xmlfile.ReadText());
                if(elements.Count != 0)
                {
                    xmlData[xmlfile] = elements;
                    var dllfile = dllFiles.Where(f => f.FileName == xmlfile.FileName.ChangeExtension(FS.Dll)).FirstOrDefault();
                    if(dllfile.IsNonEmpty)
                        dllPaths.Add(dllfile);

                }
            }

            var lookup = new Dictionary<FS.FilePath, Dictionary<string,ApiComment>>();
            var csvRowFormat = dict<FS.FilePath,List<string>>();
            var csvRows = dict<FS.FilePath,List<ApiComment>>();
            var formatter = Tables.formatter<ApiComment>();
            foreach(var part in xmlData.Keys)
            {
                var file = FS.file(string.Format("{0}.{1}", "api.comments", part.FileName.WithoutExtension.Name), FS.Csv);
                var path = targets.Path(file);
                var docs = dict<string,ApiComment>();
                lookup[part] = docs;
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
                }
            }

            return new(xmlData, lookup, csvRows, dllFiles);
        }

        public void EmitMarkdownDocs(CommentDataset ds, string[] _types)
        {
            // var markers = _types.Map(n => (n, string.Format(".{0}.",n))).ToDictionary();
            // ref readonly var src = ref ds.TargetCommentLookup;
            // var paths = src.Keys.ToArray();
            // for(var i=0; i<paths.Length; i++)
            // {
            //     ref readonly var path = ref skip(paths,i);
            //     var assemblyComments = src[path];
            //     var selected =
            //         from c in assemblyComments
            //         from m in markers
            //         let key = c.Key
            //         let value = c.Value
            //         where key.Contains(m.Value)
            //         where value.Target == ApiCommentTarget.Method
            //         select (Type:m.Key, Method:key, value);

            //     var types = (from groups in selected.Map(x => (x.Type, x.Method, Comment:x.value)).GroupBy(x => x.Type)
            //                 let type = groups.Key
            //                 select (type, groups.Index())).ToDictionary();


            //     foreach(var typename in types.Keys)
            //     {
            //         var rows = types[typename];
            //         var k=0u;
            //         var parts = alloc<ISection>(rows.Length + 1);
            //         var doc = Markdown.doc(parts);
            //         for(var j=0; j<rows.Length; j++, k++)
            //         {
            //             (var _, var method, var comment) = rows[j];
            //             var ms = MethodCommentSig.from(comment);
            //             doc[k] = Markdown.section(k, header(3, ms.Format()), comment.Summary);
            //         }
            //         var dst = AppDb.ApiTargets().Targets("markdown").Path(string.Format("z0.lib.{0}", typename), FileKind.Md);
            //         FileEmit(doc.Format(), k, dst);
            //     }
            // }
        }

        public static FS.FileName CsvFile(PartId part)
            => FS.file(string.Format("api.comments.z0", part.Format()), FS.Csv);

        public static FS.FileName XmlFile(PartId part)
            => FS.file(string.Format("api.comments.z0", part.Format()), FS.Xml);

        public static FS.FilePath CsvPath(FS.FolderPath dir, PartId part)
            => dir + CsvFile(part);

        public static FS.FilePath XmlPath(FS.FolderPath dir, PartId part)
            => dir + XmlFile(part);

        public void Collect(IApiPack dst)
        {
            var targets = dst.Comments();
            targets.Clear();
            var src = Pull(dst);
            var lookup = new Dictionary<FS.FilePath, Dictionary<string,ApiComment>>();
            var formatter = Tables.formatter<ApiComment>();
            foreach(var part in src.Keys)
            {
                var id = part.FileName.WithoutExtension.Name;
                var file = FS.file(string.Format("{0}.{1}", "api.comments", part.FileName.WithoutExtension.Name), FS.Csv);
                var path = targets.Path(file);
                var flow = EmittingTable<ApiComment>(path);
                var docs = new Dictionary<string, ApiComment>();
                lookup[part] = docs;
                using var writer = path.Writer();
                writer.AppendLine(formatter.FormatHeader());
                var kvp = src[part];
                foreach(var key in kvp.Keys)
                {
                    var value = kvp[key];
                    var comment = ParseComent(key, value).Value;
                    docs[comment.TargetName] = comment;
                    writer.WriteLine(formatter.Format(comment));
                }
                EmittedTable(flow, kvp.Count);
            }
        }

        static bool parse(string key, string value, out ApiComment dst)
        {
            var parts = key.SplitClean(Chars.Colon);
            var result = parts.Length >= 2 && parts[0].Length == 1;
            for(var i=0; i<parts.Length; i++)
            {
                ref readonly var part = ref skip(parts,i);
                if(nonempty(part))
                {
                    ref readonly var c = ref first(part);
                    switch(target(c))
                    {
                        case CT.Type:
                        break;
                        case CT.Method:
                        break;
                        case CT.Field:
                        break;
                        case CT.Property:
                        break;
                        case CT.Operand:
                        break;
                        case CT.Param:
                        break;
                        default:
                            break;
                    }
                }
            }

            if(result)

                result = parse(target(parts[0][0]), parts[1], value, out dst);
            else
                dst = ApiComment.Empty;
            return result;
        }

        static bool parse(ApiCommentTarget target, string name, string data, out ApiComment comment)
        {
            var result = false;
            comment = ApiComment.Empty;
            if(Summary.parse(data, out var summary))
            {
                comment = new ApiComment(target, name, summary.Format());
                result = true;
            }
            return result;
        }

        static ApiCommentTarget target(char src)
            => src switch {
                'T' => ApiCommentTarget.Type,
                'M' => ApiCommentTarget.Method,
                'P' => ApiCommentTarget.Property,
                'F' => ApiCommentTarget.Field,
                _ => ApiCommentTarget.None,
            };

        ConstLookup<FS.FilePath, Dictionary<string,string>> Pull(IApiPack dst)
        {
            var archive = core.controller().RuntimeArchive();
            var paths = archive.XmlFiles;
            var lookup = cdict<FS.FilePath, Dictionary<string,string>>();
            var t = default(ApiComment);
            iter(paths, path => {
                var data = ParseXmlFile(path, dst, out var packpath);
                if(data.Count != 0)
                {
                    lookup.TryAdd(path,data);
                }
                }, true);
            // foreach(var xmlfile in paths)
            // {
            //     var data = xmlfile.ReadText();
            //     var parsed = ParseXmlData(data);
            //     if(parsed.Count != 0)
            //     {
            //         lookup[xmlfile] = parsed;
            //         FileEmit(data, parsed.Count, dst.Docs().Path(FS.file(string.Format("{0}.{1}", "api.comments", xmlfile.FileName.WithoutExtension.Name), FS.Xml)));
            //     }

            // }
            return lookup;
        }

        Dictionary<string,string> ParseXmlFile(FS.FilePath src, IApiPack dst, out FS.FilePath target)
        {
            var data = src.ReadText();
            var parsed = ParseXmlData(data);
            target = FS.FilePath.Empty;
            if(parsed.Count != 0)
            {
                target = dst.Docs(comments).Path(FS.file(string.Format("{0}.{1}", "api.comments", src.FileName.WithoutExtension.Name), FS.Xml));
                src.CopyTo(target);
                //FileEmit(data, parsed.Count, dst.Docs().Path(FS.file(string.Format("{0}.{1}", "api.comments", src.FileName.WithoutExtension.Name), FS.Xml)));
            }
            return parsed;
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

        static bool parse2(string key, string value, out ApiComment dst)
        {
            var components = key.SplitClean(Chars.Colon);
            var result = false;
            dst = ApiComment.Empty;
            if(components.Length == 2 && components[0].Length == 1)
            {
                var summary = text.replace(
                              Fenced.unfence(value, Fenced.define("<summary>", "</summary>"))
                                 .RemoveAny((char)AsciControlSym.CR, (char)AsciControlSym.LF).Trim(), Chars.Pipe, Chars.Caret);
                result = parse(target(components[0][0]), components[1], summary, out dst);
            }
            return result;
        }

        static ParseResult<ApiComment> ParseComent(string key, string value)
        {
            var components = key.SplitClean(Chars.Colon);
            if(components.Length == 2 && components[0].Length == 1)
            {
                var summary = text.replace(
                              Fenced.unfence(value, Fenced.define("<summary>", "</summary>"))
                                 .RemoveAny((char)AsciControlSym.CR, (char)AsciControlSym.LF).Trim(), Chars.Pipe, Chars.Caret);

                return ParseResult.win(key, comment(target(components[0][0]), components[1], summary));
            }
            else
                return ParseResult.fail<ApiComment>(key);
        }
    }
}