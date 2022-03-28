//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedRules;
    using static XedModels;
    using static XedPatterns;
    using static core;

    partial class XedCmdProvider
    {
        Index<string> Load(FS.FileUri src)
        {
            try
            {
                var lines = src.Path.ReadLines(true).Select(text.trim);
                return lines.Map(x => x.Remove("Kind     |").Remove("EncDec   |").Remove("Dec      |").Remove("Enc      |"));
            }
            catch(Exception)
            {
                Error(string.Format("Error loading '{0}'", src.Path));
                throw;
            }
        }
        [CmdOp("xed/check/rules")]
        Outcome CheckRules(CmdArgs args)
        {
            var patterns = Xed.Rules.CalcInstPatterns();
            var rules = Xed.Rules.CalcTableSet();

            ref readonly var rows = ref rules.SigRows;
            var count = rows.Count;
            var enc = dict<string,RuleSigRow>();
            var dec = dict<string,RuleSigRow>();
            var encdec = dict<string,RuleSigRow>();
            for(var i=0; i<count; i++)
            {
                ref readonly var row = ref rows[i];
                if(!row.TableDef.Path.Exists)
                    return (false, FS.missing(row.TableDef.Path));

                var sig = row.Sig;
                if(sig.IsEncRule)
                {
                    if(!enc.TryAdd(sig.Name,row))
                        return (false, "Duplicate");
                }
                else if(sig.IsDecRule)
                {
                    if(!dec.TryAdd(sig.Name,row))
                        return (false, "Duplicate");
                }
                else if(sig.IsEncDecRule)
                {
                    if(!encdec.TryAdd(sig.Name,row))
                        return (false, "Duplicate");
                }
                else
                {
                    return (false, "Unknown sig type");
                }
            }

            Require.equal(count, (uint)(enc.Count + dec.Count + encdec.Count));

            Status(string.Format("Validating {0} rules", count));

            var decnames = dec.Values.Map(x => x.TableDef.Path.FileName).ToHashSet();
            var encdecnames = encdec.Values.Map(x => x.TableDef.Path.FileName).ToHashSet();
            var encnames = enc.Values.Map(x => x.TableDef.Path.FileName).ToHashSet();
            foreach(var x in encnames)
            {
                if(!decnames.Contains(x) && !encnames.Contains(x))
                    Warn(string.Format("Unique to EncDec ruleset:{0}",x));
            }

            foreach(var x in decnames)
            {
                if(encnames.Contains(x))
                    Warn(string.Format("Rule exists in both Enc and Dec rulesets:{0}", x));
            }

            foreach(var x in encnames)
            {
                if(decnames.Contains(x))
                    Warn(string.Format("Rule exists in both Enc and Dec rulesets:{0}", x));
            }


            var _encdec = default(RuleSigRow);
            var _dec = default(RuleSigRow);
            var _enc =  default(RuleSigRow);
            var e = Index<string>.Empty;
            var d = Index<string>.Empty;
            var ed = Index<string>.Empty;
            var result = false;
            for(var i=0; i<count; i++)
            {
                ref readonly var row = ref rows[i];
                switch(row.TableKind)
                {
                    case RuleTableKind.Enc:
                        e = Load(row.TableDef);
                        if(encdec.TryGetValue(row.TableName, out _dec))
                        {
                            d = Load(_dec.TableDef);
                            result = Match(e,d);
                            if(!result)
                            {
                                Warn(string.Format("Enc-Dec Mismatch:{0}", row.TableName));
                                Write(row.TableDef, FlairKind.Running);
                                Write(_dec.TableDef, FlairKind.Ran);
                            }
                        }
                        if(encdec.TryGetValue(row.TableName, out _encdec))
                        {
                            ed = Load(_encdec.TableDef);
                            result = Match(e,ed);
                            if(!result)
                            {
                                Warn(string.Format("Enc-EncDec Mismatch:{0}", row.TableName));
                                Write(row.TableDef, FlairKind.Running);
                                Write(_encdec.TableDef, FlairKind.Ran);
                            }
                        }
                    break;
                    case RuleTableKind.Dec:
                        d = Load(row.TableDef);
                        if(encdec.TryGetValue(row.TableName, out _encdec))
                        {
                            ed = Load(_encdec.TableDef);
                            result = Match(d,ed);
                            if(!result)
                            {
                                Warn(string.Format("Dec-EncDec Mismatch:{0}", row.TableName));
                                Write(row.TableDef, FlairKind.Running);
                                Write(_encdec.TableDef, FlairKind.Ran);
                            }
                        }
                        if(encdec.TryGetValue(row.TableName, out _enc))
                        {
                            e = Load(_enc.TableDef);
                            result = Match(d,e);
                            if(!result)
                            {
                                Warn(string.Format("Dec-Enc Mismatch:{0}", row.TableName));
                                Write(row.TableDef, FlairKind.Running);
                                Write(_enc.TableDef, FlairKind.Ran);
                            }
                        }
                    break;
                    case RuleTableKind.EncDec:
                        ed = Load(row.TableDef);
                        if(encdec.TryGetValue(row.TableName, out _dec))
                        {
                            d = Load(_dec.TableDef);
                            result = Match(ed,d);
                            if(!result)
                            {
                                Warn(string.Format("EncDec-Dec Mismatch:{0}", row.TableName));
                                Write(row.TableDef, FlairKind.Running);
                                Write(_dec.TableDef, FlairKind.Ran);

                            }
                        }
                        if(encdec.TryGetValue(row.TableName, out _enc))
                        {
                            e = Load(_enc.TableDef);
                            result = Match(ed,e);
                            if(!result)
                            {
                                Warn(string.Format("EncDec-Enc Mismatch:{0}", row.TableName));
                                Write(row.TableDef, FlairKind.Running);
                                Write(_enc.TableDef, FlairKind.Ran);

                            }
                        }
                    break;
                }
            }


            //iter(rules.SigRows, row => Write(string.Format("{0,-6} | {1,-46} | {2}", row.TableKind, row.TableName, row.TableDef)));
            return true;
        }

        bool Match(Index<string> a, Index<string> b)
        {
            var result = true;
            var count = a.Count;
            result = (count == b.Count);
            if(result)
            {
                for(var i=0; i<count; i++)
                {
                    ref readonly var x = ref a[i];
                    ref readonly var y = ref b[i];
                    result = x == y;
                    if(!result)
                        break;
                }
            }

            return result;
        }
    }
}