//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static ApiGranules;

    [LiteralProvider(files)]
    public readonly struct FileKindNames
    {
        const string Dot = ".";

        /// <summary>
        /// Defines the 'alg' literal
        /// </summary>
        public const string alg = nameof(alg);

        /// <summary>
        /// Defines the 'asm' literal
        /// </summary>
        public const string asm = nameof(asm);

        /// <summary>
        /// Defines the 'syn.asm' literal
        /// </summary>
        public const string synasm = syn + Dot + asm;

        /// <summary>
        /// Defines the 'syn.asm.log' literal
        /// </summary>
        public const string synasmlog = syn + Dot + asm + Dot + log;

        /// <summary>
        /// Defines the 'bat' literal
        /// </summary>
        public const string bat = nameof(bat);

        /// <summary>
        /// Defines the 'bits' literal
        /// </summary>
        public const string bits = nameof(bits);

        /// <summary>
        /// Defines the 'bc' literal
        /// </summary>
        public const string bc = nameof(bc);

        /// <summary>
        /// Defines the 'bin' literal
        /// </summary>
        public const string bin = nameof(bin);

        /// <summary>
        /// Defines the 'c' literal
        /// </summary>
        public const string c = nameof(c);

        /// <summary>
        /// Defines the 'cil' literal
        /// </summary>
        public const string cil = nameof(cil);

        /// <summary>
        /// Defines the 'cfg' literal
        /// </summary>
        public const string cfg = nameof(cfg);

        /// <summary>
        /// Defines the 'csv' literal
        /// </summary>
        public const string csv = nameof(csv);

        /// <summary>
        /// Defines the 'cs' literal
        /// </summary>
        public const string cs = nameof(cs);

        /// <summary>
        /// Defines the 'csproj' literal
        /// </summary>
        public const string csproj = nameof(csproj);

        /// <summary>
        /// Defines the 'cmd' literal
        /// </summary>
        public const string cmd = nameof(cmd);

        /// <summary>
        /// Defines the 'coff' literal
        /// </summary>
        public const string coff = nameof(coff);

        /// <summary>
        /// Defines the 'config' literal
        /// </summary>
        public const string config = nameof(config);

        /// <summary>
        /// Defines the 'coff.headers.txt' literal
        /// </summary>
        public const string coffheaders = coff + Dot + headers + Dot + txt;

        /// <summary>
        /// Defines the 'cpp' literal
        /// </summary>
        public const string cpp = nameof(cpp);

        /// <summary>
        /// Defines the 'dat' literal
        /// </summary>
        public const string dat = nameof(dat);

        /// <summary>
        /// Defines the 'def' literal
        /// </summary>
        public const string def = nameof(def);

        /// <summary>
        /// Defines the 'dll' literal
        /// </summary>
        public const string dll = nameof(dll);

        /// <summary>
        /// Defines the 'deps' literal
        /// </summary>
        public const string deps = nameof(deps);

        /// <summary>
        /// Defines the 'dmp' literal
        /// </summary>
        public const string dmp = nameof(dmp);

        /// <summary>
        /// Defines the 'dot' literal
        /// </summary>
        public const string dot = nameof(dot);

        /// <summary>
        /// Defines the 'exe' literal
        /// </summary>
        public const string exe = nameof(exe);

        /// <summary>
        /// Defines the 'errors' literal
        /// </summary>
        public const string error = nameof(error);

        /// <summary>
        /// Defines the 'headers' literal
        /// </summary>
        public const string headers = nameof(headers);

        /// <summary>
        /// Defines the 'h' literal
        /// </summary>
        public const string h = nameof(h);

        /// <summary>
        /// Defines the 'help' literal
        /// </summary>
        public const string help = nameof(help);

        /// <summary>
        /// Defines the 'hex' literal
        /// </summary>
        public const string hex = nameof(hex);

        /// <summary>
        /// Defines the 'hex.dat' literal
        /// </summary>
        public const string hexdat = hex + Dot + dat;

        /// <summary>
        /// Defines the 'i' literal
        /// </summary>
        public const string i = nameof(i);

        /// <summary>
        /// Defines the 'ii' literal
        /// </summary>
        public const string ii = nameof(ii);

        /// <summary>
        /// Defines the 'idx' literal
        /// </summary>
        public const string idx = nameof(idx);

        /// <summary>
        /// Defines the 'il' literal
        /// </summary>
        public const string il = nameof(il);

        /// <summary>
        /// Defines the 'list' literal
        /// </summary>
        public const string list = nameof(list);

        /// <summary>
        /// Defines the 'log' literal
        /// </summary>
        public const string log = nameof(log);

        /// <summary>
        /// Defines the 'lib' literal
        /// </summary>
        public const string lib = nameof(lib);

        /// <summary>
        /// Defines the 'mc' literal
        /// </summary>
        public const string mc = nameof(mc);

        /// <summary>
        /// Defines the 'mc.asm' literal
        /// </summary>
        public const string mcasm = mc + Dot + asm;

        /// <summary>
        /// Defines the 'syn' literal
        /// </summary>
        public const string syn = nameof(syn);

        /// <summary>
        /// Defines the 'encoding' literal
        /// </summary>
        public const string enc = nameof(enc);

        /// <summary>
        /// Defines the 'encoding.asm' literal
        /// </summary>
        public const string encasm = enc + Dot + asm;

        /// <summary>
        /// Defines the 'mlir' literal
        /// </summary>
        public const string mlir = nameof(mlir);

        /// <summary>
        /// Defines the 'mir' literal
        /// </summary>
        public const string mir = nameof(mir);

        /// <summary>
        /// Defines the 'll' literal
        /// </summary>
        public const string ll = nameof(ll);

        /// <summary>
        /// Defines the 'll.asm' literal
        /// </summary>
        public const string llasm = ll + Dot + asm;

        /// <summary>
        /// Defines the 'll.bc' literal
        /// </summary>
        public const string llbc = ll + Dot + bc;

        /// <summary>
        /// Defines the 'md' literal
        /// </summary>
        public const string md = nameof(md);

        /// <summary>
        /// Defines the 'pdb' literal
        /// </summary>
        public const string pdb = nameof(pdb);

        /// <summary>
        /// Defines the 'o' literal
        /// </summary>
        public const string o = nameof(o);

        /// <summary>
        /// Defines the 'obi' literal
        /// </summary>
        public const string obi = nameof(obi);

        /// <summary>
        /// Defines the 'obj' literal
        /// </summary>
        public const string obj = nameof(obj);

        /// <summary>
        /// Defines the 'ops' literal
        /// </summary>
        public const string ops = nameof(ops);

        /// <summary>
        /// Defines the 'ops.asm' literal
        /// </summary>
        public const string opsasm = ops + Dot + asm;

        /// <summary>
        /// Defines the 'obj.asm' literal
        /// </summary>
        public const string objasm = obj + Dot + asm;

        /// <summary>
        /// Defines the 'obj.yaml' literal
        /// </summary>
        public const string objyaml = obj + Dot + yaml;

        /// <summary>
        /// Defines the 'obj.hex' literal
        /// </summary>
        public const string objhex = obj + Dot + hex;

        /// <summary>
        /// Defines the 'status' literal
        /// </summary>
        public const string status = nameof(status);

        /// <summary>
        /// Defines the 'sln' literal
        /// </summary>
        public const string sln = nameof(sln);

        /// <summary>
        /// Defines the 'sorted' literal
        /// </summary>
        public const string sorted = nameof(sorted);

        /// <summary>
        /// Defines the 'ps1' literal
        /// </summary>
        public const string ps1 = nameof(ps1);

        /// <summary>
        /// Defines the 's' literal
        /// </summary>
        public const string s = nameof(s);

        /// <summary>
        /// Defines the 'sh' literal
        /// </summary>
        public const string sh = nameof(sh);

        /// <summary>
        /// Defines the 'statemetnts' literal
        /// </summary>
        public const string statements = nameof(statements);

        /// <summary>
        /// Defines the 'settings' literal
        /// </summary>
        public const string settings = nameof(settings);

        /// <summary>
        /// Defines the 'sym' literal
        /// </summary>
        public const string sym = nameof(sym);

        /// <summary>
        /// Defines the 'sql' literal
        /// </summary>
        public const string sql = nameof(sql);

        /// <summary>
        /// Defines the 'targets' literal
        /// </summary>
        public const string targets = nameof(targets);

        /// <summary>
        /// Defines the 'txt' literal
        /// </summary>
        public const string txt = nameof(txt);

        /// <summary>
        /// Defines the 'xml' literal
        /// </summary>
        public const string xml = nameof(xml);

        /// <summary>
        /// Defines the 'zip' literal
        /// </summary>
        public const string zip = nameof(zip);

        /// il.csv
        /// </summary>
        public const string ildata = il + Dot + csv;

        /// <summary>
        /// Defines the 'x.csv' literal
        /// </summary>
        public const string xcsv = CharText.x + Dot + csv;

        /// <summary>
        /// Defines the 'p.csv' literal
        /// </summary>
        public const string pcsv = CharText.p + Dot + csv;

        /// <summary>
        /// Defines the 'tok' literal
        /// </summary>
        public const string tok = nameof(tok);

        /// <summary>
        /// Defines the 'yaml' literal
        /// </summary>
        public const string yaml = nameof(yaml);

        /// <summary>
        /// Defines the 'yaml.tok' literal
        /// </summary>
        public const string yamltok = yaml + Dot + tok;

        /// <summary>
        /// Defines the 'bv' literal
        /// </summary>
        public const string bv = nameof(bv);

        /// <summary>
        /// Defines the 'inc' literal
        /// </summary>
        public const string inc = nameof(inc);

        /// <summary>
        /// Defines the 'td' literal
        /// </summary>
        public const string td = nameof(td);

        /// <summary>
        /// Defines the 'xpack' literal
        /// </summary>
        public const string xpack = nameof(xpack);

        /// <summary>
        /// Defines the 'xarray' literal
        /// </summary>
        public const string xarray = nameof(xarray);

        /// <summary>
        /// Defines the 'json' literal
        /// </summary>
        public const string json = nameof(json);

        /// <summary>
        /// Defines the 'deps.json' literal
        /// </summary>
        public const string djson = deps + Dot + json;

        /// <summary>
        /// Defines the 'config.json' literal
        /// </summary>
        public const string cjson = config + Dot + json;

        /// <summary>
        /// Defines the 'settings.json' literal
        /// </summary>
        public const string sjson = settings + Dot + json;

        public const string xed = nameof(xed);

        public const string disasm = nameof(disasm);

        public const string xeddisasm = xed + Dot + disasm;

        /// <summary>
        /// Defines the 'xed.disasm.txt' literal
        /// </summary>
        public const string xeddisasm_raw = xeddisasm + Dot + txt;

        public const string xeddisasm_summary = xeddisasm + Dot + "summary" + Dot + csv;

        public const string xeddisasm_semantic = xeddisasm + Dot + "semantic" + Dot + txt;

        public const string xeddisasm_detail = xeddisasm + Dot + "detail";
    }
}