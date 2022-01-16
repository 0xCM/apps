//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Reflection;
    using static core;

    public class FileTypes
    {
        public static FS.FileExt ext(FileKind src)
            => FS.ext(format(src));

        public static string name(FileKind src)
            => Symbols.index<FileKind>()[src].Name.ToLower();

        [Op]
        internal static string format(FileKind src)
            => Symbols.index<FileKind>()[src].Expr.Format();

        internal static string format(IFileFlowType flow)
            => string.Format("{0}:*.{1} -> *.{2}", flow.Actor, flow.SourceExt, flow.TargetExt);

        public static FileFlowType flow(Identifier actor, FileKind src, FileKind dst)
            => new FileFlowType(actor,src,dst);

        public static Index<IFileFlowType> flows(Assembly[] src)
        {
            var types = src.Types().Tagged<FileFlowTypeAttribute>().Concrete();
            var count = types.Length;
            var dst = alloc<IFileFlowType>(count);
            for(var i=0; i<count; i++)
            {
                ref readonly var type = ref skip(types,i);
                seek(dst,i) = (IFileFlowType)Activator.CreateInstance(type);
            }
            return dst;
        }

        public static Pairings<FS.FilePath,FileKind> match(ReadOnlySpan<FS.FilePath> src)
        {
            var count = src.Length;
            var symbols = Symbols.index<FileKind>();
            var kinds = symbols.Kinds;
            var kindExpr = symbols.View.Map(s => ("." + s.Expr.Format().ToLower(), s.Kind)).ToSortedDictionary(TextLengthComparer.create(true));
            var dst = alloc<Paired<FS.FilePath,FileKind>>(count);
            for(var i=0; i<count; i++)
            {
                ref readonly var path = ref skip(src,i);
                seek(dst,i) = (path,FileKind.None);
                var name = path.FileName.Format().ToLower();
                foreach(var expr in kindExpr)
                {
                    if(name.EndsWith(expr.Key))
                    {
                        seek(dst,i) = (path,expr.Value);
                        break;
                    }
                }
            }
            return dst;
        }
    }

    partial class XTend
    {
        public static FS.FileExt Ext(this FileKind src)
            => FileTypes.ext(src);

        public static string Name(this FileKind src)
            => FileTypes.name(src);
    }
}