//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class WsArchives
    {
        readonly Settings Data;

        internal WsArchives(Settings src)
        {
            Data = src;
        }

        public Setting Path(string name)
        {
            var dst = Setting.Empty;
            var result = Data.Lookup(name, out dst);
            if(result)
                return dst;
            else
                return Setting.Empty;
        }

        public string Format()
            => Data.Format();
        // {
        //     var dst = text.emitter();
        //     var formatter = Tables.formatter<WsArchive>();
        //     dst.AppendLine(formatter.FormatHeader());
        //     for(var i=0; i<Data.Count; i++)
        //     {
        //         ref readonly var src = ref Data[i];
        //         var archive = new WsArchive(src.ProjectId, src.Root);
        //         dst.AppendLine(formatter.Format(archive));
        //     }

        //     return dst.Emit();
        // }

        public override string ToString()
            => Format();
    }
}