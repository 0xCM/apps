//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedModels;
    using static XedModels.ModeKind;
    using static Asm.AsmPrefixCodes;
    using static Asm.AsmPrefixCodes.VectorWidthCode;
    using static XedModels.EASZ;
    using static XedModels.EOSZ;
    using static XedModels.SMode;
    using static XedModels.SegPrefixKind;
    using static XedModels.VexMapKind;
    using static XedModels.BCastKind;
    using static bit;

    using K = XedRules.FieldKind;
    using M = XedRules.RuleMacroKind;
    using P = XedModels.RepPrefix;
    using D = XedModels.SegDefaultKind;
    using V = XedModels.VexKind;
    using X = XedModels.XopMapKind;

    using static core;

    partial class XedRules
    {
        [ApiHost("xed.rules.macros")]
        public class RuleMacros
        {
            static Symbols<RuleMacroKind> KindSymbols;

            static Index<MacroSpec> Specs;

            static ConstLookup<RuleMacroKind,MacroSpec> Lookup;

            static ConstLookup<string,Index<FieldAssign>> Assignments;

            static HashSet<string> Names;

            static RuleMacros()
            {
                KindSymbols = Symbols.index<RuleMacroKind>();
                Specs = _specs();
                Lookup = Specs.Storage.Map(x => (x.Name, x)).ToDictionary();
                Names = map(KindSymbols.View.Where(x => x.Kind != 0),x => x.Expr.Text).ToHashSet();
                Assignments = assignments();

                static Index<MacroSpec> _specs()
                {
                    var src = typeof(RuleMacros).StaticMethods().Where(x => x.ReturnType == typeof(MacroSpec) && x.Parameters().Length == 0);
                    var count = src.Length;
                    var dst = alloc<MacroSpec>(count);
                    for(var i=0; i<count; i++)
                        seek(dst,i) = (MacroSpec)skip(src,i).Invoke(null, sys.empty<object>());
                    return dst.Sort();
                }

                static ConstLookup<string,Index<FieldAssign>> assignments()
                {
                    var dst = dict<string,Index<FieldAssign>>();
                    foreach(var spec in Specs)
                        dst[XedRender.format(spec.Name)] = spec.Assignments;
                    return dst;
                }
            }

            public static bool assignments(string name, out ReadOnlySpan<FieldAssign> dst)
            {
                if(Assignments.Find(name, out var x))
                {
                    dst = x.View;
                    return true;
                }
                else
                {
                    dst = default;
                    return false;
                }
            }

            public static string expand(string src)
            {
                var input = text.trim(text.split(text.despace(src), Chars.Space));
                var count = input.Length;
                var output = alloc<string>(count);
                var names = RuleMacros.names();
                var kinds = RuleMacros.kinds();
                for(var i=0; i<count; i++)
                {
                    ref readonly var part = ref skip(input,i);
                    if(names.Contains(part))
                    {
                        if(kinds.Lookup(part, out var sym))
                            seek(output,i) = Lookup[sym.Kind].Format();
                        else
                            seek(output,i) = part;
                    }
                    else
                        seek(output,i) = part;
                }
                return output.Delimit(Chars.Space).Format();
            }

            [MethodImpl(Inline), Op]
            public static Symbols<RuleMacroKind> kinds()
                => KindSymbols;

            [MethodImpl(Inline), Op]
            public static Index<MacroSpec> specs()
                => Specs;

            [MethodImpl(Inline), Op]
            public static ConstLookup<RuleMacroKind,MacroSpec> lookup()
                => Lookup;

            public static bool spec(string name, out MacroSpec dst)
            {
                if(KindSymbols.Lookup(name, out var sym))
                    return Lookup.Find(sym.Kind, out dst);
                dst = MacroSpec.Empty;
                return false;
            }

            [MethodImpl(Inline), Op]
            public static HashSet<string> names()
                => Names;

            [MethodImpl(Inline), Op]
            static MacroSpec mod0()
                => assign(M.mod0, K.MOD, 0);

            [MethodImpl(Inline), Op]
            static MacroSpec mod1()
                => assign(M.mod1, K.MOD, 1);

            [MethodImpl(Inline), Op]
            static MacroSpec mod2()
                => assign(M.mod2, K.MOD, 2);

            [MethodImpl(Inline), Op]
            static MacroSpec mod3()
                => assign(M.mod3, K.MOD, 2);

            [MethodImpl(Inline), Op]
            static MacroSpec not64()
                => assign(M.not64, K.MODE, Not64);

            [MethodImpl(Inline), Op]
            static MacroSpec mode64()
                => assign(M.mode64, K.MODE, Mode64);

            [MethodImpl(Inline), Op]
            static MacroSpec mode32()
                => assign(M.mode32, K.MODE, Mode32);

            [MethodImpl(Inline), Op]
            static MacroSpec mode16()
                => assign(M.mode16, K.MODE, Mode16);

            [MethodImpl(Inline), Op]
            static MacroSpec eanot16()
                => assign(M.eanot16, K.EASZ, EASZNot16);

            [MethodImpl(Inline), Op]
            static MacroSpec eamode16()
                => assign(M.eamode16, K.EASZ, EASZ16);

            [MethodImpl(Inline), Op]
            static MacroSpec eamode32()
                => assign(M.eamode32, K.EASZ, EASZ32);

            [MethodImpl(Inline), Op]
            static MacroSpec eamode64()
                => assign(M.eamode64, K.EASZ, EASZ64);

            [MethodImpl(Inline), Op]
            static MacroSpec smode16()
                => assign(M.smode16, K.SMODE, SMode16);

            [MethodImpl(Inline), Op]
            static MacroSpec smode32()
                => assign(M.smode32, K.SMODE, SMode32);

            [MethodImpl(Inline), Op]
            static MacroSpec smode64()
                => assign(M.smode64, K.SMODE, SMode64);

            [MethodImpl(Inline), Op]
            static MacroSpec eosz8()
                => assign(M.eosz8, K.EOSZ, EOSZ8);

            [MethodImpl(Inline), Op]
            static MacroSpec eosz16()
                => assign(M.eosz16, K.EOSZ, EOSZ16);

            [MethodImpl(Inline), Op]
            static MacroSpec eosz32()
                => assign(M.eosz32, K.EOSZ, EOSZ32);

            [MethodImpl(Inline), Op]
            static MacroSpec eosz64()
                => assign(M.eosz64, K.EOSZ, EOSZ64);

            [MethodImpl(Inline), Op]
            static MacroSpec not_eosz16()
                => assign(M.not_eosz16, K.EOSZ, EOSZNot16);

            [MethodImpl(Inline), Op]
            static MacroSpec eosznot64()
                => assign(M.eosznot64, K.EOSZ, EOSZNot64);

            [MethodImpl(Inline), Op]
            static MacroSpec nrmw()
                => assign(M.nrmw, K.DF64, Off);

            [MethodImpl(Inline), Op]
            static MacroSpec df64()
                => assign(M.df64, K.DF64, On);

            [MethodImpl(Inline), Op]
            public static MacroSpec rex_reqd()
                => assign(M.rex_reqd, K.REX, On);

            [MethodImpl(Inline), Op]
            static MacroSpec nothing()
                => RuleMacroKind.nothing;

            [MethodImpl(Inline), Op]
            static MacroSpec otherwise()
                => M.otherwise;

            [MethodImpl(Inline), Op]
            static MacroSpec no_rex()
                => assign(M.no_rex, K.REX, Off);

            [MethodImpl(Inline), Op]
            static MacroSpec reset_rex()
                =>  assign(M.reset_rex,
                    assign(K.REX, Off),
                    assign(K.REXW, Off),
                    assign(K.REXB, Off),
                    assign(K.REXR, Off),
                    assign(K.REXX, Off)
                    );

            [MethodImpl(Inline), Op]
            static MacroSpec rexb_prefix()
                => assign(M.rexb_prefix, K.REXB, On);

            [MethodImpl(Inline), Op]
            static MacroSpec norexb_prefix()
                => assign(M.norexb_prefix, K.REXB, Off);

            [MethodImpl(Inline), Op]
            static MacroSpec rexx_prefix()
                => assign(M.rexx_prefix, K.REXX, On);

            [MethodImpl(Inline), Op]
            static MacroSpec norexx_prefix()
                => assign(M.norexx_prefix, K.REXX, Off);

            [MethodImpl(Inline), Op]
            static MacroSpec rexr_prefix()
                => assign(M.rexr_prefix, K.REXR, On);

            [MethodImpl(Inline), Op]
            static MacroSpec norexr_prefix()
                => assign(M.norexr_prefix, K.REXR, Off);

            [MethodImpl(Inline), Op]
            static MacroSpec rexw_prefix()
                => assign(M.rexw_prefix, K.REXW, On);

            [MethodImpl(Inline), Op]
            static MacroSpec norexw_prefix()
                => assign(M.norexw_prefix, K.REXW, Off);

            [MethodImpl(Inline), Op]
            static MacroSpec W0()
                => assign(M.W0, K.REXW, Off);

            [MethodImpl(Inline), Op]
            static MacroSpec W1()
                => assign(M.W1, K.REXW, On);

            [MethodImpl(Inline), Op]
            static MacroSpec VL128()
                => assign(M.VL128, K.VL, V128);

            [MethodImpl(Inline), Op]
            static MacroSpec VL256()
                => assign(M.VL256, K.VL, V256);

            [MethodImpl(Inline), Op]
            static MacroSpec VL512()
                => assign(M.VL512, K.VL, V512);

            [MethodImpl(Inline), Op]
            static MacroSpec VV0()
                => assign(M.VV0, K.VEXVALID, VexClass.None);

            [MethodImpl(Inline), Op]
            static MacroSpec VV1()
                => assign(M.VV1, K.VEXVALID, VexClass.VV1);

            [MethodImpl(Inline), Op]
            static MacroSpec KVV()
                => assign(M.KVV, K.VEXVALID, VexClass.KVV);

            [MethodImpl(Inline), Op]
            static MacroSpec EVV()
                => assign(M.EVV, K.VEXVALID, VexClass.EVV);

            [MethodImpl(Inline), Op]
            static MacroSpec XOPV()
                => assign(M.XOPV, K.VEXVALID, VexClass.XOPV);

            [MethodImpl(Inline), Op]
            static MacroSpec VNP()
                => assign(M.VNP, K.VEX_PREFIX, V.VNP);

            [MethodImpl(Inline), Op]
            static MacroSpec V66()
                => assign(M.V66, K.VEX_PREFIX, V.V66);

            [MethodImpl(Inline), Op]
            static MacroSpec VF2()
                => assign(M.VF2, K.VEX_PREFIX, V.VF2);

            [MethodImpl(Inline), Op]
            static MacroSpec VF3()
                => assign(M.VF3, K.VEX_PREFIX, V.VF3);

            [MethodImpl(Inline), Op]
            static MacroSpec NOVSR()
                => assign(M.NOVSR, assign(K.VEXDEST3, 1), assign(K.VEXDEST210, 0b111));

            [MethodImpl(Inline), Op]
            static MacroSpec NOEVSR()
                => assign(M.NOEVSR, assign(K.VEXDEST3, 1), assign(K.VEXDEST210, 0b111), assign(K.VEXDEST4,0));

            [MethodImpl(Inline), Op]
            static MacroSpec NO_SPARSE_EVSR()
                => assign(M.NO_SPARSE_EVSR, assign(K.VEXDEST3, 1), assign(K.VEXDEST210, 0b111));

            [MethodImpl(Inline), Op]
            static MacroSpec EVEXRR_ONE()
                => assign(M.EVEXRR_ONE, K.REXRR, Off);

            [MethodImpl(Inline), Op]
            static MacroSpec VLBAD()
                => assign(M.VLBAD, K.VL, VectorWidthCode.INVALID);

            [MethodImpl(Inline), Op]
            static MacroSpec VMAP0()
                => assign(M.VMAP0, K.MAP, 0);

            [MethodImpl(Inline), Op]
            static MacroSpec V0F()
                => assign(M.V0F, K.MAP, VEX_MAP_0F);

            [MethodImpl(Inline), Op]
            static MacroSpec V0F38()
                => assign(M.V0F38, K.MAP, VEX_MAP_0F38);

            [MethodImpl(Inline), Op]
            static MacroSpec V0F3A()
                => assign(M.V0F3A, K.MAP, VEX_MAP_0F3A);

            [MethodImpl(Inline), Op]
            static MacroSpec XMAP8()
                => assign(M.XMAP8, K.MAP, X.XOP8);

            [MethodImpl(Inline), Op]
            static MacroSpec XMAP9()
                => assign(M.XMAP9, K.MAP, X.XOP9);

            [MethodImpl(Inline), Op]
            static MacroSpec XMAPA()
                => assign(M.XMAPA, K.MAP, X.XOPA);

            [MethodImpl(Inline), Op]
            static MacroSpec no67_prefix()
                => assign(M.no67_prefix, K.ASZ, Off);

            [MethodImpl(Inline), Op]
            static MacroSpec x67_prefix()
                => assign(M.x67_prefix, K.ASZ, On);

            [MethodImpl(Inline), Op]
            static MacroSpec x66_prefix()
                => assign(M.x66_prefix, K.OSZ, EOSZ16);

            [MethodImpl(Inline), Op]
            static MacroSpec no66_prefix()
                => assign(M.no66_prefix, K.OSZ, EOSZ8);

            [MethodImpl(Inline), Op]
            static MacroSpec f2_prefix()
                => assign(M.f2_prefix, K.REP, P.REPF2);

            [MethodImpl(Inline), Op]
            static MacroSpec f3_prefix()
                => assign(M.f3_prefix, K.REP, P.REPF3);

            [MethodImpl(Inline), Op]
            static MacroSpec repne()
                => assign(M.repne, K.REP, P.REPF2);

            [MethodImpl(Inline), Op]
            static MacroSpec repn()
                => assign(M.repe, K.REP, P.REPF3);

            [MethodImpl(Inline), Op]
            static MacroSpec norep()
                => assign(M.norep, K.REP, P.None);

            [MethodImpl(Inline), Op]
            static MacroSpec nof3_prefix()
                => assign(M.nof3_prefix, K.REP, P.NOF3);

            [MethodImpl(Inline), Op]
            static MacroSpec not_refining()
                => assign(M.not_refining, K.REP, P.None);

            [MethodImpl(Inline), Op]
            static MacroSpec refining_f2()
                => assign(M.refining_f2, K.REP, P.REPF2);

            [MethodImpl(Inline), Op]
            static MacroSpec refining_f3()
                => assign(M.refining_f3, K.REP, P.REPF3);

            [MethodImpl(Inline), Op]
            static MacroSpec not_refining_f3()
                => assign(M.not_refining_f3, K.REP, P.NOF3);

            [MethodImpl(Inline), Op]
            static MacroSpec no_refining_prefix()
                => assign(M.no_refining_prefix, assign(K.REP, P.None), assign(K.EOSZ, EOSZ16));

            [MethodImpl(Inline), Op]
            static MacroSpec osz_refining_prefix()
                => assign(M.osz_refining_prefix, assign(K.REP, P.None), assign(K.EOSZ, EOSZ8));

            [MethodImpl(Inline), Op]
            static MacroSpec f2_refining_prefix()
                => assign(M.f2_refining_prefix, K.REP, P.REPF2);

            [MethodImpl(Inline), Op]
            static MacroSpec f3_refining_prefix()
                => assign(M.f3_refining_prefix, K.REP, P.REPF3);

            [MethodImpl(Inline), Op]
            static MacroSpec lock_prefix()
                => assign(M.lock_prefix, K.LOCK, On);

            [MethodImpl(Inline), Op]
            static MacroSpec nolock_prefix()
                => assign(M.nolock_prefix, K.LOCK, Off);

            [MethodImpl(Inline), Op]
            static MacroSpec default_ds()
                => assign(M.default_ds, K.DEFAULT_SEG, D.DefaultDS);

            [MethodImpl(Inline), Op]
            static MacroSpec default_ss()
                => assign(M.default_ss, K.DEFAULT_SEG, D.DefaultSS);

            [MethodImpl(Inline), Op]
            static MacroSpec default_3s()
                => assign(M.default_es, K.DEFAULT_SEG, D.DefaultES);

            [MethodImpl(Inline), Op]
            static MacroSpec no_seg_prefix()
                => assign(M.no_seg_prefix, K.SEG_OVD, 0);

            [MethodImpl(Inline), Op]
            static MacroSpec cs_prefix()
                => assign(M.cs_prefix, K.SEG_OVD, CS);

            [MethodImpl(Inline), Op]
            static MacroSpec ds_prefix()
                => assign(M.ds_prefix, K.SEG_OVD, DS);

            [MethodImpl(Inline), Op]
            static MacroSpec es_prefix()
                => assign(M.es_prefix, K.SEG_OVD, ES);

            [MethodImpl(Inline), Op]
            static MacroSpec fs_prefix()
                => assign(M.fs_prefix, K.SEG_OVD, SegPrefixKind.FS);

            [MethodImpl(Inline), Op]
            static MacroSpec gs_prefix()
                => assign(M.gs_prefix, K.SEG_OVD, GS);

            [MethodImpl(Inline), Op]
            static MacroSpec ss_prefix()
                => assign(M.ss_prefix, K.SEG_OVD, SS);

            [MethodImpl(Inline), Op]
            static MacroSpec enc()
                => assign(M.enc, K.ENCODER_PREFERRED, 1);

            [MethodImpl(Inline), Op]
            static MacroSpec no_return()
                => assign(M.no_return, K.NO_RETURN, 1);

            [MethodImpl(Inline), Op]
            static MacroSpec error()
                => assign(M.error, K.ERROR, ErrorKind.GENERAL_ERROR);

            [MethodImpl(Inline), Op]
            static MacroSpec @true()
                => assign(M.@true, K.DUMMY, 0);

            [MethodImpl(Inline), Op]
            static MacroSpec EMX_BROADCAST_1TO2_8()
                => assign(M.EMX_BROADCAST_1TO2_8, K.BCAST, BCast_1TO2_8);

            [MethodImpl(Inline), Op]
            static MacroSpec EMX_BROADCAST_1TO4_8()
                => assign(M.EMX_BROADCAST_1TO4_8, K.BCAST, BCast_1TO4_8);

            [MethodImpl(Inline), Op]
            static MacroSpec EMX_BROADCAST_1TO8_8()
                => assign(M.EMX_BROADCAST_1TO8_8, K.BCAST, BCast_1TO8_8);

            [MethodImpl(Inline), Op]
            static MacroSpec EMX_BROADCAST_1TO16_8()
                => assign(M.EMX_BROADCAST_1TO16_8, K.BCAST, BCast_1TO16_8);

            [MethodImpl(Inline), Op]
            static MacroSpec EMX_BROADCAST_1TO32_8()
                => assign(M.EMX_BROADCAST_1TO32_8, K.BCAST, BCast_1TO32_8);

            [MethodImpl(Inline), Op]
            static MacroSpec EMX_BROADCAST_1TO64_8()
                => assign(M.EMX_BROADCAST_1TO64_8, K.BCAST, BCast_1TO64_8);

            [MethodImpl(Inline), Op]
            static MacroSpec EMX_BROADCAST_1TO2_16()
                => assign(M.EMX_BROADCAST_1TO2_16, K.BCAST, BCast_1TO2_16);

            [MethodImpl(Inline), Op]
            static MacroSpec EMX_BROADCAST_1TO4_16()
                => assign(M.EMX_BROADCAST_1TO4_16, K.BCAST, BCast_1TO4_16);

            [MethodImpl(Inline), Op]
            static MacroSpec EMX_BROADCAST_1TO8_16()
                => assign(M.EMX_BROADCAST_1TO8_16, K.BCAST, BCast_1TO8_16);

            [MethodImpl(Inline), Op]
            static MacroSpec EMX_BROADCAST_1TO16_16()
                => assign(M.EMX_BROADCAST_1TO16_16, K.BCAST, BCast_1TO16_16);

            [MethodImpl(Inline), Op]
            static MacroSpec EMX_BROADCAST_1TO32_16()
                => assign(M.EMX_BROADCAST_1TO32_16, K.BCAST, BCast_1TO32_16);

            [MethodImpl(Inline), Op]
            static MacroSpec EMX_BROADCAST_1TO2_32()
                => assign(M.EMX_BROADCAST_1TO2_32, K.BCAST, BCast_1TO2_32);

            [MethodImpl(Inline), Op]
            public static MacroSpec EMX_BROADCAST_1TO4_32()
                => assign(M.EMX_BROADCAST_1TO4_32, K.BCAST, BCast_1TO4_32);

            [MethodImpl(Inline), Op]
            public static MacroSpec EMX_BROADCAST_1TO8_32()
                => assign(M.EMX_BROADCAST_1TO8_32, K.BCAST, BCast_1TO8_32);

            [MethodImpl(Inline), Op]
            public static MacroSpec EMX_BROADCAST_1TO16_32()
                => assign(M.EMX_BROADCAST_1TO16_32, K.BCAST, BCast_1TO16_32);

            [MethodImpl(Inline), Op]
            public static MacroSpec EMX_BROADCAST_2TO4_32()
                => assign(M.EMX_BROADCAST_2TO4_32, K.BCAST, BCast_2TO4_32);

            [MethodImpl(Inline), Op]
            public static MacroSpec EMX_BROADCAST_2TO8_32()
                => assign(M.EMX_BROADCAST_2TO8_32, K.BCAST, BCast_2TO8_32);

            [MethodImpl(Inline), Op]
            public static MacroSpec EMX_BROADCAST_2TO16_32()
                => assign(M.EMX_BROADCAST_2TO16_32, K.BCAST, BCast_2TO16_32);

            [MethodImpl(Inline), Op]
            public static MacroSpec EMX_BROADCAST_4TO8_32()
                => assign(M.EMX_BROADCAST_4TO8_32, K.BCAST, BCast_4TO8_32);

            [MethodImpl(Inline), Op]
            public static MacroSpec EMX_BROADCAST_4TO16_32()
                => assign(M.EMX_BROADCAST_4TO16_32, K.BCAST, BCast_4TO16_32);

            [MethodImpl(Inline), Op]
            public static MacroSpec EMX_BROADCAST_8TO16_32()
                => assign(M.EMX_BROADCAST_8TO16_32, K.BCAST, BCast_8TO16_32);

            [MethodImpl(Inline), Op]
            public static MacroSpec EMX_BROADCAST_1TO2_64()
                => assign(M.EMX_BROADCAST_1TO2_64, K.BCAST, BCast_1TO2_64);

            [MethodImpl(Inline), Op]
            public static MacroSpec EMX_BROADCAST_1TO4_64()
                => assign(M.EMX_BROADCAST_1TO4_64, K.BCAST, BCast_1TO4_64);

            [MethodImpl(Inline), Op]
            public static MacroSpec EMX_BROADCAST_1TO8_64()
                => assign(M.EMX_BROADCAST_1TO8_64, K.BCAST, BCast_1TO8_64);

            [MethodImpl(Inline), Op]
            public static MacroSpec EMX_BROADCAST_2TO4_64()
                => assign(M.EMX_BROADCAST_2TO4_64, K.BCAST, BCast_2TO4_64);

            [MethodImpl(Inline), Op]
            public static MacroSpec EMX_BROADCAST_2TO8_64()
                => assign(M.EMX_BROADCAST_2TO8_64, K.BCAST, BCast_2TO8_64);

            [MethodImpl(Inline), Op]
            public static MacroSpec EMX_BROADCAST_4TO8_64()
                => assign(M.EMX_BROADCAST_4TO8_64, K.BCAST, BCast_4TO8_64);
        }
    }
}