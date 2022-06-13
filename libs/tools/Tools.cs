//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using TN = ToolNames;
    using static core;

    public readonly struct Tools
    {
        [MethodImpl(Inline), Op]
        public static ToolCmdLine cmdline(ToolId tool, params string[] src)
            => new ToolCmdLine(tool, CmdScript.cmdline(src));

        [MethodImpl(Inline), Op]
        public static ToolCmdLine cmdline(ToolId tool, CmdModifier modifier, params string[] src)
            => new ToolCmdLine(tool, modifier, CmdScript.cmdline(src));

        [MethodImpl(Inline), Op]
        public static ToolScript script(ToolId tool, ScriptId script, CmdVars vars)
            => new ToolScript(tool,script,vars);

        public static Tool tool(ToolId id)
            => id;

        [Op, Closures(UInt64k)]
        public static ToolCmd command<T>(in T spec)
            where T : struct
        {
            var t = typeof(T);
            var fields = Clr.fields(t);
            var count = fields.Length;
            var reflected = alloc<ClrFieldValue>(count);
            ClrFields.values(spec, fields, reflected);
            var buffer = alloc<ToolCmdArg>(count);
            var target = span(buffer);
            var source = @readonly(reflected);
            for(var i=0u; i<count; i++)
            {
                ref readonly var fv = ref skip(source,i);
                seek(target,i) = new ToolCmdArg(fv.Field.Name, fv.Value?.ToString() ?? EmptyString);
            }
            return new ToolCmd(CmdId.from(t), buffer);
        }

        [MethodImpl(Inline), Op]
        public static ToolHelp help(ToolId tool, string doc, string description, CmdOptionSpec[] options)
            => new ToolHelp(tool, doc, description, options);

        [Parser]
        public static Outcome parse(string src, out Tool dst)
        {
            ToolId id = text.trim(src);
            dst = id;
            return true;
        }

        public static readonly Llc llc = Llc.Instance;

        public static readonly LlvmMc llvm_mc = LlvmMc.Instance;

        public static readonly LlvmConfig llvm_config = LlvmConfig.Instance;

        public static readonly Clang clang = Clang.Instance;

        public static readonly LlvmObjDump llvm_objdump = LlvmObjDump.Instance;

        public static readonly LlvmTableGen llvm_tblgen = LlvmTableGen.Instance;

        public static readonly LlvmReadObj llvm_readobj = LlvmReadObj.Instance;

        public static readonly LlvmDis llvm_dis = LlvmDis.Instance;

        public static readonly LlvmAs llvm_as = LlvmAs.Instance;

        public static readonly LlvmLld llvm_lld = LlvmLld.Instance;

        public static readonly ZTool ztool = ZTool.Instance;

        public static readonly Xed xed = Xed.Instance;

        public static readonly BdDisasm bddisasm = BdDisasm.Instance;

        public static readonly Msvs msvs = Msvs.Instance;

        public sealed class ZTool : Tool<ZTool>
        {
            public ZTool()
                : base("ZTool")
            {

            }

            public string Format()
                => Name.Format();

            public override string ToString()
                => Format();
        }

        public sealed class Llc : Tool<Llc>
        {
            public Llc()
                : base(TN.llc)
            {

            }

            public string Format()
                => Name.Format();

            public override string ToString()
                => Format();
        }

        public sealed class LlvmMc : Tool<LlvmMc>
        {
            public LlvmMc()
                : base(TN.llvm_mc)
            {

            }

            public string Format()
                => Name.Format();

            public override string ToString()
                => Format();
        }

        public sealed class Clang : Tool<Clang>
        {
            public Clang()
                : base(TN.clang)
            {

            }

            public string Format()
                => Name.Format();

            public override string ToString()
                => Format();
        }

        public sealed class LlvmObjDump : Tool<LlvmObjDump>
        {
            public LlvmObjDump()
                : base(TN.llvm_objdump)
            {

            }

            public string Format()
                => Name.Format();

            public override string ToString()
                => Format();
        }

        public sealed class LlvmConfig : Tool<LlvmConfig>
        {
            public LlvmConfig()
                : base(TN.llvm_config)
            {

            }

            public string Format()
                => Name.Format();

            public override string ToString()
                => Format();
        }

        public sealed class LlvmReadObj : Tool<LlvmReadObj>
        {
            public LlvmReadObj()
                : base(TN.llvm_readobj)
            {

            }

            public string Format()
                => Name.Format();

            public override string ToString()
                => Format();
        }

        public sealed class LlvmAs : Tool<LlvmAs>
        {
            public LlvmAs()
                : base(TN.llvm_as)
            {

            }

            public string Format()
                => Name.Format();

            public override string ToString()
                => Format();
        }

        public sealed class LlvmTableGen : Tool<LlvmTableGen>
        {
            public LlvmTableGen()
                : base(TN.llvm_tblgen)
            {

            }

            public string Format()
                => Name.Format();

            public override string ToString()
                => Format();
        }

        public sealed class LlvmDis : Tool<LlvmDis>
        {
            public LlvmDis()
                : base(TN.llvm_dis)
            {

            }

            public string Format()
                => Name.Format();

            public override string ToString()
                => Format();
        }

        public sealed class LlvmLld : Tool<LlvmLld>
        {
            public LlvmLld()
                : base(TN.llvm_lld)
            {

            }

            public string Format()
                => Name.Format();

            public override string ToString()
                => Format();
        }

        public sealed class LlvmNm : Tool<LlvmNm>
        {
            public LlvmNm()
                : base(TN.llvm_nm)
            {

            }

            public string Format()
                => Name.Format();

            public override string ToString()
                => Format();
        }

        public sealed class Xed : Tool<Xed>
        {
            public Xed()
                : base(TN.xed)
            {

            }

            public string Format()
                => Name.Format();

            public override string ToString()
                => Format();
        }

        public sealed class BdDisasm : Tool<BdDisasm>
        {
            public BdDisasm()
                : base(TN.bddisasm)
            {

            }

            public string Format()
                => Name.Format();

            public override string ToString()
                => Format();
        }

        public sealed class Msvs : Tool<Msvs>
        {
            public Msvs()
                : base(TN.msvs)
            {

            }

            public string Format()
                => Name.Format();

            public override string ToString()
                => Format();
        }
    }
}