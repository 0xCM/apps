; ----------------------------------------------------------------------------------------------------------------------------------------------------------------
; IntPtr func_32i_32i_32i(void* f)::located://asmrun/sigs?func_32i_32i_32i#func_32i_32i_32i_(void~ptr)
; public static ReadOnlySpan<byte> func_32i_32i_32i_ᐤvoidᕀptrᐤ => new byte[223]{0xe9,0xd3,0x0a,0x2f,0x04,0x5f,0x00,0x01,0xe9,0xcb,0x1d,0x2f,0x04,0x5f,0x03,0x00,0x00,0x39,0x96,0xa2,0xfa,0x7f,0x00,0x00,0xe8,0x6b,0xec,0xb4,0x5f,0x5e,0x00,0x03,0xe8,0x63,0xec,0xb4,0x5f,0x5e,0x03,0x02,0xe8,0x5b,0xec,0xb4,0x5f,0x5e,0x06,0x01,0xe8,0x53,0xec,0xb4,0x5f,0x5e,0x09,0x00,0xc8,0x39,0x96,0xa2,0xfa,0x7f,0x00,0x00,0xe8,0x43,0xec,0xb4,0x5f,0x5e,0x00,0x01,0xe8,0x3b,0xec,0xb4,0x5f,0x5e,0x04,0x00,0xc0,0x3a,0x96,0xa2,0xfa,0x7f,0x00,0x00,0xe8,0x2b,0xec,0xb4,0x5f,0x5e,0x00,0x00,0xf0,0x3b,0x96,0xa2,0xfa,0x7f,0x00,0x00,0xe8,0x1b,0xec,0xb4,0x5f,0x5e,0x00,0x0c,0xe8,0x13,0xec,0xb4,0x5f,0x5e,0x02,0x0b,0xe8,0x0b,0xec,0xb4,0x5f,0x5e,0x04,0x0a,0xe8,0x03,0xec,0xb4,0x5f,0x5e,0x06,0x09,0xe8,0xfb,0xeb,0xb4,0x5f,0x5e,0x08,0x08,0xe8,0xf3,0xeb,0xb4,0x5f,0x5e,0x0a,0x07,0xe8,0xeb,0xeb,0xb4,0x5f,0x5e,0x0c,0x06,0xe8,0xe3,0xeb,0xb4,0x5f,0x5e,0x0e,0x05,0xe8,0xdb,0xeb,0xb4,0x5f,0x5e,0x10,0x04,0xe8,0xd3,0xeb,0xb4,0x5f,0x5e,0x12,0x03,0xe8,0xcb,0xeb,0xb4,0x5f,0x5e,0x14,0x02,0xe8,0xc3,0xeb,0xb4,0x5f,0x5e,0x16,0x01,0xe8,0xbb,0xeb,0xb4,0x5f,0x5e,0x18,0x00,0x10,0x3d,0x96,0xa2,0xfa,0x7f,0x00,0x00,0xe9,0xfb,0x4b,0x00,0x00,0x5f,0x00};
; BaseAddress = 7ffaa270abb8h
; TermCode = CTC_Zx7
0000h jmp near ptr 42f0ad8h                         ; JMP rel32                        | E9 cd                            | 5   | e9 d3 0a 2f 04
0005h pop rdi                                       ; POP r64                          | 58 +ro                           | 1   | 5f
0006h add [rcx],al                                  ; ADD r/m8, r8                     | 00 /r                            | 2   | 00 01
0008h jmp near ptr 42f1dd8h                         ; JMP rel32                        | E9 cd                            | 5   | e9 cb 1d 2f 04
000dh pop rdi                                       ; POP r64                          | 58 +ro                           | 1   | 5f
000eh add eax,[rax]                                 ; ADD r32, r/m32                   | 03 /r                            | 2   | 03 00
0010h add [rcx],bh                                  ; ADD r/m8, r8                     | 00 /r                            | 2   | 00 39
0012h xchg esi,eax                                  ; XCHG r32, EAX                    | 90 +rd                           | 1   | 96
0013h mov [0b4ec6be800007ffah],al                   ; MOV moffs8, AL                   | A2 mo                            | 9   | a2 fa 7f 00 00 e8 6b ec b4
001ch pop rdi                                       ; POP r64                          | 58 +ro                           | 1   | 5f
001dh pop rsi                                       ; POP r64                          | 58 +ro                           | 1   | 5e
001eh add [rbx],al                                  ; ADD r/m8, r8                     | 00 /r                            | 2   | 00 03
0020h call 7ffb02259840h                            ; CALL rel32                       | E8 cd                            | 5   | e8 63 ec b4 5f
0025h pop rsi                                       ; POP r64                          | 58 +ro                           | 1   | 5e
0026h add eax,[rdx]                                 ; ADD r32, r/m32                   | 03 /r                            | 2   | 03 02
0028h call 7ffb02259840h                            ; CALL rel32                       | E8 cd                            | 5   | e8 5b ec b4 5f
002dh pop rsi                                       ; POP r64                          | 58 +ro                           | 1   | 5e
002eh (bad)                                         ; <invalid>                        | <invalid>                        | 2   | 06 01
0030h call 7ffb02259840h                            ; CALL rel32                       | E8 cd                            | 5   | e8 53 ec b4 5f
0035h pop rsi                                       ; POP r64                          | 58 +ro                           | 1   | 5e
0036h or [rax],eax                                  ; OR r/m32, r32                    | 09 /r                            | 2   | 09 00
0038h enter 9639h,0a2h                              ; ENTER imm16, imm8                | C8 iw ib                         | 4   | c8 39 96 a2
003ch cli                                           ; CLI                              | FA                               | 1   | fa
003dh jg short 003fh                                ; JG rel8                          | 7F cb                            | 2   | 7f 00
003fh add al,ch                                     ; ADD r/m8, r8                     | 00 /r                            | 2   | 00 e8
0041h in al,dx                                      ; IN AL, DX                        | EC                               | 2   | 43 ec
0043h mov ah,5fh                                    ; MOV r8, imm8                     | B0 +rb ib                        | 2   | b4 5f
0045h pop rsi                                       ; POP r64                          | 58 +ro                           | 1   | 5e
0046h add [rcx],al                                  ; ADD r/m8, r8                     | 00 /r                            | 2   | 00 01
0048h call 7ffb02259840h                            ; CALL rel32                       | E8 cd                            | 5   | e8 3b ec b4 5f
004dh pop rsi                                       ; POP r64                          | 58 +ro                           | 1   | 5e
004eh add al,0                                      ; ADD AL, imm8                     | 04 ib                            | 2   | 04 00
0050h sar byte ptr [rdx],96h                        ; SAR r/m8, imm8                   | C0 /7 ib                         | 3   | c0 3a 96
0053h mov [0b4ec2be800007ffah],al                   ; MOV moffs8, AL                   | A2 mo                            | 9   | a2 fa 7f 00 00 e8 2b ec b4
005ch pop rdi                                       ; POP r64                          | 58 +ro                           | 1   | 5f
005dh pop rsi                                       ; POP r64                          | 58 +ro                           | 1   | 5e
005eh add [rax],al                                  ; ADD r/m8, r8                     | 00 /r                            | 2   | 00 00
0060h (bad)                                         ; <invalid>                        | <invalid>                        | 7   | f0 3b 96 a2 fa 7f 00
0067h add al,ch                                     ; ADD r/m8, r8                     | 00 /r                            | 2   | 00 e8
0069h sbb ebp,esp                                   ; SBB r32, r/m32                   | 1B /r                            | 2   | 1b ec
006bh mov ah,5fh                                    ; MOV r8, imm8                     | B0 +rb ib                        | 2   | b4 5f
006dh pop rsi                                       ; POP r64                          | 58 +ro                           | 1   | 5e
006eh add [rax+rbp*8],cl                            ; ADD r/m8, r8                     | 00 /r                            | 3   | 00 0c e8
0071h adc ebp,esp                                   ; ADC r32, r/m32                   | 13 /r                            | 2   | 13 ec
0073h mov ah,5fh                                    ; MOV r8, imm8                     | B0 +rb ib                        | 2   | b4 5f
0075h pop rsi                                       ; POP r64                          | 58 +ro                           | 1   | 5e
0076h add cl,[rbx]                                  ; ADD r8, r/m8                     | 02 /r                            | 2   | 02 0b
0078h call 7ffb02259840h                            ; CALL rel32                       | E8 cd                            | 5   | e8 0b ec b4 5f
007dh pop rsi                                       ; POP r64                          | 58 +ro                           | 1   | 5e
007eh add al,0ah                                    ; ADD AL, imm8                     | 04 ib                            | 2   | 04 0a
0080h call 7ffb02259840h                            ; CALL rel32                       | E8 cd                            | 5   | e8 03 ec b4 5f
0085h pop rsi                                       ; POP r64                          | 58 +ro                           | 1   | 5e
0086h (bad)                                         ; <invalid>                        | <invalid>                        | 2   | 06 09
0088h call 7ffb02259840h                            ; CALL rel32                       | E8 cd                            | 5   | e8 fb eb b4 5f
008dh pop rsi                                       ; POP r64                          | 58 +ro                           | 1   | 5e
008eh or [rax],cl                                   ; OR r/m8, r8                      | 08 /r                            | 2   | 08 08
0090h call 7ffb02259840h                            ; CALL rel32                       | E8 cd                            | 5   | e8 f3 eb b4 5f
0095h pop rsi                                       ; POP r64                          | 58 +ro                           | 1   | 5e
0096h or al,[rdi]                                   ; OR r8, r/m8                      | 0A /r                            | 2   | 0a 07
0098h call 7ffb02259840h                            ; CALL rel32                       | E8 cd                            | 5   | e8 eb eb b4 5f
009dh pop rsi                                       ; POP r64                          | 58 +ro                           | 1   | 5e
009eh or al,6                                       ; OR AL, imm8                      | 0C ib                            | 2   | 0c 06
00a0h call 7ffb02259840h                            ; CALL rel32                       | E8 cd                            | 5   | e8 e3 eb b4 5f
00a5h pop rsi                                       ; POP r64                          | 58 +ro                           | 1   | 5e
00a6h (bad)                                         ; <invalid>                        | <invalid>                        | 2   | 0e 05
00a8h call 7ffb02259840h                            ; CALL rel32                       | E8 cd                            | 5   | e8 db eb b4 5f
00adh pop rsi                                       ; POP r64                          | 58 +ro                           | 1   | 5e
00aeh adc [rax+rbp*8],al                            ; ADC r/m8, r8                     | 10 /r                            | 3   | 10 04 e8
00b1h shr ebx,cl                                    ; SHR r/m32, CL                    | D3 /5                            | 2   | d3 eb
00b3h mov ah,5fh                                    ; MOV r8, imm8                     | B0 +rb ib                        | 2   | b4 5f
00b5h pop rsi                                       ; POP r64                          | 58 +ro                           | 1   | 5e
00b6h adc al,[rbx]                                  ; ADC r8, r/m8                     | 12 /r                            | 2   | 12 03
00b8h call 7ffb02259840h                            ; CALL rel32                       | E8 cd                            | 5   | e8 cb eb b4 5f
00bdh pop rsi                                       ; POP r64                          | 58 +ro                           | 1   | 5e
00beh adc al,2                                      ; ADC AL, imm8                     | 14 ib                            | 2   | 14 02
00c0h call 7ffb02259840h                            ; CALL rel32                       | E8 cd                            | 5   | e8 c3 eb b4 5f
00c5h pop rsi                                       ; POP r64                          | 58 +ro                           | 1   | 5e
00c6h (bad)                                         ; <invalid>                        | <invalid>                        | 2   | 16 01
00c8h call 7ffb02259840h                            ; CALL rel32                       | E8 cd                            | 5   | e8 bb eb b4 5f
00cdh pop rsi                                       ; POP r64                          | 58 +ro                           | 1   | 5e
00ceh sbb [rax],al                                  ; SBB r/m8, r8                     | 18 /r                            | 2   | 18 00
00d0h adc [rip+7ffaa296h],bh                        ; ADC r/m8, r8                     | 10 /r                            | 6   | 10 3d 96 a2 fa 7f
00d6h add [rax],al                                  ; ADD r/m8, r8                     | 00 /r                            | 2   | 00 00
00d8h jmp near ptr 4cd8h                            ; JMP rel32                        | E9 cd                            | 5   | e9 fb 4b 00 00
00ddh pop rdi                                       ; POP r64                          | 58 +ro                           | 1   | 5f
00deh (bad)                                         ; <invalid>                        | <invalid>                        | 1   | 00
; ----------------------------------------------------------------------------------------------------------------------------------------------------------------
; int invoke(IntPtr f, int a, int b)::located://asmrun/sigs?invoke#invoke_(IntPtr,32i,32i)
; public static ReadOnlySpan<byte> invoke_ᐤIntPtrㆍ32iㆍ32iᐤ => new byte[215]{0xe9,0xcb,0x1d,0x2f,0x04,0x5f,0x03,0x00,0x00,0x39,0x96,0xa2,0xfa,0x7f,0x00,0x00,0xe8,0x6b,0xec,0xb4,0x5f,0x5e,0x00,0x03,0xe8,0x63,0xec,0xb4,0x5f,0x5e,0x03,0x02,0xe8,0x5b,0xec,0xb4,0x5f,0x5e,0x06,0x01,0xe8,0x53,0xec,0xb4,0x5f,0x5e,0x09,0x00,0xc8,0x39,0x96,0xa2,0xfa,0x7f,0x00,0x00,0xe8,0x43,0xec,0xb4,0x5f,0x5e,0x00,0x01,0xe8,0x3b,0xec,0xb4,0x5f,0x5e,0x04,0x00,0xc0,0x3a,0x96,0xa2,0xfa,0x7f,0x00,0x00,0xe8,0x2b,0xec,0xb4,0x5f,0x5e,0x00,0x00,0xf0,0x3b,0x96,0xa2,0xfa,0x7f,0x00,0x00,0xe8,0x1b,0xec,0xb4,0x5f,0x5e,0x00,0x0c,0xe8,0x13,0xec,0xb4,0x5f,0x5e,0x02,0x0b,0xe8,0x0b,0xec,0xb4,0x5f,0x5e,0x04,0x0a,0xe8,0x03,0xec,0xb4,0x5f,0x5e,0x06,0x09,0xe8,0xfb,0xeb,0xb4,0x5f,0x5e,0x08,0x08,0xe8,0xf3,0xeb,0xb4,0x5f,0x5e,0x0a,0x07,0xe8,0xeb,0xeb,0xb4,0x5f,0x5e,0x0c,0x06,0xe8,0xe3,0xeb,0xb4,0x5f,0x5e,0x0e,0x05,0xe8,0xdb,0xeb,0xb4,0x5f,0x5e,0x10,0x04,0xe8,0xd3,0xeb,0xb4,0x5f,0x5e,0x12,0x03,0xe8,0xcb,0xeb,0xb4,0x5f,0x5e,0x14,0x02,0xe8,0xc3,0xeb,0xb4,0x5f,0x5e,0x16,0x01,0xe8,0xbb,0xeb,0xb4,0x5f,0x5e,0x18,0x00,0x10,0x3d,0x96,0xa2,0xfa,0x7f,0x00,0x00,0xe9,0xfb,0x4b,0x00,0x00,0x5f,0x00};
; BaseAddress = 7ffaa270abc0h
; TermCode = CTC_Zx7
0000h jmp near ptr 42f1dd0h                         ; JMP rel32                        | E9 cd                            | 5   | e9 cb 1d 2f 04
0005h pop rdi                                       ; POP r64                          | 58 +ro                           | 1   | 5f
0006h add eax,[rax]                                 ; ADD r32, r/m32                   | 03 /r                            | 2   | 03 00
0008h add [rcx],bh                                  ; ADD r/m8, r8                     | 00 /r                            | 2   | 00 39
000ah xchg esi,eax                                  ; XCHG r32, EAX                    | 90 +rd                           | 1   | 96
000bh mov [0b4ec6be800007ffah],al                   ; MOV moffs8, AL                   | A2 mo                            | 9   | a2 fa 7f 00 00 e8 6b ec b4
0014h pop rdi                                       ; POP r64                          | 58 +ro                           | 1   | 5f
0015h pop rsi                                       ; POP r64                          | 58 +ro                           | 1   | 5e
0016h add [rbx],al                                  ; ADD r/m8, r8                     | 00 /r                            | 2   | 00 03
0018h call 7ffb02259840h                            ; CALL rel32                       | E8 cd                            | 5   | e8 63 ec b4 5f
001dh pop rsi                                       ; POP r64                          | 58 +ro                           | 1   | 5e
001eh add eax,[rdx]                                 ; ADD r32, r/m32                   | 03 /r                            | 2   | 03 02
0020h call 7ffb02259840h                            ; CALL rel32                       | E8 cd                            | 5   | e8 5b ec b4 5f
0025h pop rsi                                       ; POP r64                          | 58 +ro                           | 1   | 5e
0026h (bad)                                         ; <invalid>                        | <invalid>                        | 2   | 06 01
0028h call 7ffb02259840h                            ; CALL rel32                       | E8 cd                            | 5   | e8 53 ec b4 5f
002dh pop rsi                                       ; POP r64                          | 58 +ro                           | 1   | 5e
002eh or [rax],eax                                  ; OR r/m32, r32                    | 09 /r                            | 2   | 09 00
0030h enter 9639h,0a2h                              ; ENTER imm16, imm8                | C8 iw ib                         | 4   | c8 39 96 a2
0034h cli                                           ; CLI                              | FA                               | 1   | fa
0035h jg short 0037h                                ; JG rel8                          | 7F cb                            | 2   | 7f 00
0037h add al,ch                                     ; ADD r/m8, r8                     | 00 /r                            | 2   | 00 e8
0039h in al,dx                                      ; IN AL, DX                        | EC                               | 2   | 43 ec
003bh mov ah,5fh                                    ; MOV r8, imm8                     | B0 +rb ib                        | 2   | b4 5f
003dh pop rsi                                       ; POP r64                          | 58 +ro                           | 1   | 5e
003eh add [rcx],al                                  ; ADD r/m8, r8                     | 00 /r                            | 2   | 00 01
0040h call 7ffb02259840h                            ; CALL rel32                       | E8 cd                            | 5   | e8 3b ec b4 5f
0045h pop rsi                                       ; POP r64                          | 58 +ro                           | 1   | 5e
0046h add al,0                                      ; ADD AL, imm8                     | 04 ib                            | 2   | 04 00
0048h sar byte ptr [rdx],96h                        ; SAR r/m8, imm8                   | C0 /7 ib                         | 3   | c0 3a 96
004bh mov [0b4ec2be800007ffah],al                   ; MOV moffs8, AL                   | A2 mo                            | 9   | a2 fa 7f 00 00 e8 2b ec b4
0054h pop rdi                                       ; POP r64                          | 58 +ro                           | 1   | 5f
0055h pop rsi                                       ; POP r64                          | 58 +ro                           | 1   | 5e
0056h add [rax],al                                  ; ADD r/m8, r8                     | 00 /r                            | 2   | 00 00
0058h (bad)                                         ; <invalid>                        | <invalid>                        | 7   | f0 3b 96 a2 fa 7f 00
005fh add al,ch                                     ; ADD r/m8, r8                     | 00 /r                            | 2   | 00 e8
0061h sbb ebp,esp                                   ; SBB r32, r/m32                   | 1B /r                            | 2   | 1b ec
0063h mov ah,5fh                                    ; MOV r8, imm8                     | B0 +rb ib                        | 2   | b4 5f
0065h pop rsi                                       ; POP r64                          | 58 +ro                           | 1   | 5e
0066h add [rax+rbp*8],cl                            ; ADD r/m8, r8                     | 00 /r                            | 3   | 00 0c e8
0069h adc ebp,esp                                   ; ADC r32, r/m32                   | 13 /r                            | 2   | 13 ec
006bh mov ah,5fh                                    ; MOV r8, imm8                     | B0 +rb ib                        | 2   | b4 5f
006dh pop rsi                                       ; POP r64                          | 58 +ro                           | 1   | 5e
006eh add cl,[rbx]                                  ; ADD r8, r/m8                     | 02 /r                            | 2   | 02 0b
0070h call 7ffb02259840h                            ; CALL rel32                       | E8 cd                            | 5   | e8 0b ec b4 5f
0075h pop rsi                                       ; POP r64                          | 58 +ro                           | 1   | 5e
0076h add al,0ah                                    ; ADD AL, imm8                     | 04 ib                            | 2   | 04 0a
0078h call 7ffb02259840h                            ; CALL rel32                       | E8 cd                            | 5   | e8 03 ec b4 5f
007dh pop rsi                                       ; POP r64                          | 58 +ro                           | 1   | 5e
007eh (bad)                                         ; <invalid>                        | <invalid>                        | 2   | 06 09
0080h call 7ffb02259840h                            ; CALL rel32                       | E8 cd                            | 5   | e8 fb eb b4 5f
0085h pop rsi                                       ; POP r64                          | 58 +ro                           | 1   | 5e
0086h or [rax],cl                                   ; OR r/m8, r8                      | 08 /r                            | 2   | 08 08
0088h call 7ffb02259840h                            ; CALL rel32                       | E8 cd                            | 5   | e8 f3 eb b4 5f
008dh pop rsi                                       ; POP r64                          | 58 +ro                           | 1   | 5e
008eh or al,[rdi]                                   ; OR r8, r/m8                      | 0A /r                            | 2   | 0a 07
0090h call 7ffb02259840h                            ; CALL rel32                       | E8 cd                            | 5   | e8 eb eb b4 5f
0095h pop rsi                                       ; POP r64                          | 58 +ro                           | 1   | 5e
0096h or al,6                                       ; OR AL, imm8                      | 0C ib                            | 2   | 0c 06
0098h call 7ffb02259840h                            ; CALL rel32                       | E8 cd                            | 5   | e8 e3 eb b4 5f
009dh pop rsi                                       ; POP r64                          | 58 +ro                           | 1   | 5e
009eh (bad)                                         ; <invalid>                        | <invalid>                        | 2   | 0e 05
00a0h call 7ffb02259840h                            ; CALL rel32                       | E8 cd                            | 5   | e8 db eb b4 5f
00a5h pop rsi                                       ; POP r64                          | 58 +ro                           | 1   | 5e
00a6h adc [rax+rbp*8],al                            ; ADC r/m8, r8                     | 10 /r                            | 3   | 10 04 e8
00a9h shr ebx,cl                                    ; SHR r/m32, CL                    | D3 /5                            | 2   | d3 eb
00abh mov ah,5fh                                    ; MOV r8, imm8                     | B0 +rb ib                        | 2   | b4 5f
00adh pop rsi                                       ; POP r64                          | 58 +ro                           | 1   | 5e
00aeh adc al,[rbx]                                  ; ADC r8, r/m8                     | 12 /r                            | 2   | 12 03
00b0h call 7ffb02259840h                            ; CALL rel32                       | E8 cd                            | 5   | e8 cb eb b4 5f
00b5h pop rsi                                       ; POP r64                          | 58 +ro                           | 1   | 5e
00b6h adc al,2                                      ; ADC AL, imm8                     | 14 ib                            | 2   | 14 02
00b8h call 7ffb02259840h                            ; CALL rel32                       | E8 cd                            | 5   | e8 c3 eb b4 5f
00bdh pop rsi                                       ; POP r64                          | 58 +ro                           | 1   | 5e
00beh (bad)                                         ; <invalid>                        | <invalid>                        | 2   | 16 01
00c0h call 7ffb02259840h                            ; CALL rel32                       | E8 cd                            | 5   | e8 bb eb b4 5f
00c5h pop rsi                                       ; POP r64                          | 58 +ro                           | 1   | 5e
00c6h sbb [rax],al                                  ; SBB r/m8, r8                     | 18 /r                            | 2   | 18 00
00c8h adc [rip+7ffaa296h],bh                        ; ADC r/m8, r8                     | 10 /r                            | 6   | 10 3d 96 a2 fa 7f
00ceh add [rax],al                                  ; ADD r/m8, r8                     | 00 /r                            | 2   | 00 00
00d0h jmp near ptr 4cd0h                            ; JMP rel32                        | E9 cd                            | 5   | e9 fb 4b 00 00
00d5h pop rdi                                       ; POP r64                          | 58 +ro                           | 1   | 5f
00d6h (bad)                                         ; <invalid>                        | <invalid>                        | 1   | 00
