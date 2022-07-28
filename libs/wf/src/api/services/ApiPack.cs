//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Spans;
    using static Arrays;

    public class ApiPack : IApiPack
    {
        // public static ReadOnlySeq<IApiPack> discover()
        // {
        //     var src = AppDb.Service.Capture().Root.SubDirs(false);
        //     var dst = Lists.list<IApiPack>();
        //     var counter = 0u;
        //     for(var i=0; i<src.Count; i++)
        //     {
        //         ref readonly var source = ref src[i];
        //         if(ApiPack.parse(source, out ApiPack pack))
        //         {
        //             dst.Add(pack);
        //             counter++;
        //         }
        //     }

        //     return slice(@readonly(dst.Seal()),0,counter).ToArray();
        // }

        // public static IApiPack create()
        //     => new ApiPack(AppDb.Service.Capture().Targets(AppDb.Ts.Format()).Root, AppDb.Ts);

        // public static IApiPack create(Timestamp ts)
        //     => new ApiPack(AppDb.Service.Capture().Targets(ts.Format()).Root, ts);

        // public static bool timestamp(FS.FolderPath src, out Timestamp dst)
        // {
        //     dst = default;
        //     var fmt = src.Format(PathSeparator.FS);
        //     var idx = fmt.LastIndexOf(Chars.FSlash);
        //     if(idx == NotFound)
        //         return false;
        //     return Time.parse(fmt.RightOfIndex(idx), out dst);
        // }

        // public static bool parse(FS.FolderPath src, out ApiPack dst)
        // {
        //     dst = default;
        //     var fmt = src.Format(PathSeparator.FS);
        //     var idx = fmt.LastIndexOf(Chars.FSlash);
        //     if(idx == NotFound)
        //         return false;
        //     var result =Time.parse(fmt.RightOfIndex(idx), out var ts);
        //     if(result)
        //         dst = new ApiPack(src,ts);
        //     else
        //         dst = new ApiPack(FS.FolderPath.Empty, Timestamp.Zero);
        //     return result;
        // }

        public FS.FolderPath Root {get;}

        public Timestamp Timestamp {get;}

        public ApiPack(FS.FolderPath root, Timestamp ts)
        {
            Root = root;
            Timestamp = ts;
        }

        public string Format()
            => string.Format("{0}: {1}", Timestamp, Root);

        public override string ToString()
            => Format();
    }
}