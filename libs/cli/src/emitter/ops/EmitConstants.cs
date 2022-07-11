//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial class CliEmitter
    {
        public void EmitConstants(IApiPack dst)
            => iter(ApiMd.Components, c => EmitConstants(c, dst), true);

        public void EmitConstants(Assembly src, IApiPack dst)
        {
            var counter = 0u;
            var target = dst.Metadata("fields.const").PrefixedTable<ConstantFieldInfo>(src.GetSimpleName());
            var flow = Wf.EmittingTable<ConstantFieldInfo>(target);
            var formatter = Tables.formatter<ConstantFieldInfo>();
            using var writer = target.Writer();
            writer.WriteLine(formatter.FormatHeader());
            using var reader = PeTableReader.open(src.Path());
            var constants = reader.Constants(ref counter);
            var count = constants.Length;
            for(var i=0; i<count; i++)
                writer.WriteLine(formatter.Format(skip(constants,i)));
            EmittedTable(flow, counter);
        }
    }
}