//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Reflection;
    using System.Collections.Generic;

    using static core;

    public class ProjectFlows : AppService<ProjectFlows>
    {
        public ProjectFlows()
        {
            var symbols = Symbols.index<FileKind>();
            var kinds = symbols.Kinds;
            FileKindMatch = symbols.View.Map(s => ("." + s.Expr.Format().ToLower(), s.Kind)).ToSortedDictionary(TextLengthComparer.create(true));
        }

        SortedDictionary<string,FileKind> FileKindMatch;

        public Index<IFileFlowType> FlowTypes()
        {
            return Data(nameof(FlowTypes), Load);

            Index<IFileFlowType> Load()
            {
                var src = ApiRuntimeCatalog.Components.Storage;
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
        }

        public FileKind Match(FS.FilePath src)
        {
            var name = src.FileName.Format().ToLower();
            var kind = FileKind.None;
            foreach(var expr in FileKindMatch)
            {
                if(name.EndsWith(expr.Key))
                {
                    kind = expr.Value;
                    break;
                }
            }
            return kind;
        }

        public Pairings<FS.FilePath,FileKind> Match(ReadOnlySpan<FS.FilePath> src)
        {
            var count = src.Length;
            var dst = alloc<Paired<FS.FilePath,FileKind>>(count);
            for(var i=0; i<count; i++)
            {
                ref readonly var path = ref skip(src,i);
                seek(dst,i) = (path, Match(path));
                // seek(dst,i) = (path,FileKind.None);
                // var name = path.FileName.Format().ToLower();
                // foreach(var expr in FileKindMatch)
                // {
                //     if(name.EndsWith(expr.Key))
                //     {
                //         seek(dst,i) = (path,expr.Value);
                //         break;
                //     }
                // }
            }
            return dst;
        }
    }
}