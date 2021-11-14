//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using static LlvmNames;
    using static core;

    using records;

    partial class LlvmCmd
    {
        [CmdOp(Queries.fields)]
        Outcome Fields(CmdArgs args)
        {
            var result = Outcome.Success;
            if(args.Length == 2)
            {
                DataParser.parse(arg(args,0).Value, out uint offset);
                DataParser.parse(arg(args,1).Value, out uint length);
                var fields = Db.Fields(offset,length);
                iter(fields, f => Write(f.Format()));
            }
            else if(args.Length == 0)
            {
                var entities = list<Entity>();
                Db.QueryFields(provider => {
                    //Write(provider.EntityName);
                    entities.Add(Entity.load(provider));
                });
                var index = entities.Map(x => (x.EntityName.Text,x)).ToDictionary();
                var x86inst = Db.SelectList("X86Inst");
                var counter = 0u;
                foreach(var inst in x86inst)
                {
                    if(index.TryGetValue(inst.Value.Text, out var i))
                    {
                        Write(string.Format("{0:D5} {1:D5} {2}", counter++, inst.Id, i.EntityName));

                    }
                }
            }
            return result;
        }
    }
}