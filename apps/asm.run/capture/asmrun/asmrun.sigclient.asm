; ----------------------------------------------------------------------------------------------------------------------------------------------------------------
; int run1(in CodeBuffers src)::located://asmrun/sigclient?run1#run1_(CodeBuffers~in)
; public static ReadOnlySpan<byte> run1_ᐤCodeBuffersᕀinᐤ => new byte[191]{0xe9,0xf3,0x8d,0x34,0x04,0x5f,0x03,0x02,0xe9,0xab,0x8e,0x34,0x04,0x5f,0x06,0x01,0xe8,0x53,0xec,0xb4,0x5f,0x5e,0x09,0x00,0xc8,0x39,0x96,0xa2,0xfa,0x7f,0x00,0x00,0xe8,0x43,0xec,0xb4,0x5f,0x5e,0x00,0x01,0xe8,0x3b,0xec,0xb4,0x5f,0x5e,0x04,0x00,0xc0,0x3a,0x96,0xa2,0xfa,0x7f,0x00,0x00,0xe8,0x2b,0xec,0xb4,0x5f,0x5e,0x00,0x00,0xf0,0x3b,0x96,0xa2,0xfa,0x7f,0x00,0x00,0xe8,0x1b,0xec,0xb4,0x5f,0x5e,0x00,0x0c,0xe8,0x13,0xec,0xb4,0x5f,0x5e,0x02,0x0b,0xe8,0x0b,0xec,0xb4,0x5f,0x5e,0x04,0x0a,0xe8,0x03,0xec,0xb4,0x5f,0x5e,0x06,0x09,0xe8,0xfb,0xeb,0xb4,0x5f,0x5e,0x08,0x08,0xe8,0xf3,0xeb,0xb4,0x5f,0x5e,0x0a,0x07,0xe8,0xeb,0xeb,0xb4,0x5f,0x5e,0x0c,0x06,0xe8,0xe3,0xeb,0xb4,0x5f,0x5e,0x0e,0x05,0xe8,0xdb,0xeb,0xb4,0x5f,0x5e,0x10,0x04,0xe8,0xd3,0xeb,0xb4,0x5f,0x5e,0x12,0x03,0xe8,0xcb,0xeb,0xb4,0x5f,0x5e,0x14,0x02,0xe8,0xc3,0xeb,0xb4,0x5f,0x5e,0x16,0x01,0xe8,0xbb,0xeb,0xb4,0x5f,0x5e,0x18,0x00,0x10,0x3d,0x96,0xa2,0xfa,0x7f,0x00,0x00,0xe9,0xfb,0x4b,0x00,0x00,0x5f,0x00};
; BaseAddress = 7ffaa270abd8h
; TermCode = CTC_Zx7
0000h jmp near ptr 4348df8h                         ; JMP rel32                        | E9 cd                            | 5   | e9 f3 8d 34 04
0005h pop rdi                                       ; POP r64                          | 58 +ro                           | 1   | 5f
0006h add eax,[rdx]                                 ; ADD r32, r/m32                   | 03 /r                            | 2   | 03 02
0008h jmp near ptr 4348eb8h                         ; JMP rel32                        | E9 cd                            | 5   | e9 ab 8e 34 04
000dh pop rdi                                       ; POP r64                          | 58 +ro                           | 1   | 5f
000eh (bad)                                         ; <invalid>                        | <invalid>                        | 2   | 06 01
0010h call 7ffb02259840h                            ; CALL rel32                       | E8 cd                            | 5   | e8 53 ec b4 5f
0015h pop rsi                                       ; POP r64                          | 58 +ro                           | 1   | 5e
0016h or [rax],eax                                  ; OR r/m32, r32                    | 09 /r                            | 2   | 09 00
0018h enter 9639h,0a2h                              ; ENTER imm16, imm8                | C8 iw ib                         | 4   | c8 39 96 a2
001ch cli                                           ; CLI                              | FA                               | 1   | fa
001dh jg short 001fh                                ; JG rel8                          | 7F cb                            | 2   | 7f 00
001fh add al,ch                                     ; ADD r/m8, r8                     | 00 /r                            | 2   | 00 e8
0021h in al,dx                                      ; IN AL, DX                        | EC                               | 2   | 43 ec
0023h mov ah,5fh                                    ; MOV r8, imm8                     | B0 +rb ib                        | 2   | b4 5f
0025h pop rsi                                       ; POP r64                          | 58 +ro                           | 1   | 5e
0026h add [rcx],al                                  ; ADD r/m8, r8                     | 00 /r                            | 2   | 00 01
0028h call 7ffb02259840h                            ; CALL rel32                       | E8 cd                            | 5   | e8 3b ec b4 5f
002dh pop rsi                                       ; POP r64                          | 58 +ro                           | 1   | 5e
002eh add al,0                                      ; ADD AL, imm8                     | 04 ib                            | 2   | 04 00
0030h sar byte ptr [rdx],96h                        ; SAR r/m8, imm8                   | C0 /7 ib                         | 3   | c0 3a 96
0033h mov [0b4ec2be800007ffah],al                   ; MOV moffs8, AL                   | A2 mo                            | 9   | a2 fa 7f 00 00 e8 2b ec b4
003ch pop rdi                                       ; POP r64                          | 58 +ro                           | 1   | 5f
003dh pop rsi                                       ; POP r64                          | 58 +ro                           | 1   | 5e
003eh add [rax],al                                  ; ADD r/m8, r8                     | 00 /r                            | 2   | 00 00
0040h (bad)                                         ; <invalid>                        | <invalid>                        | 7   | f0 3b 96 a2 fa 7f 00
0047h add al,ch                                     ; ADD r/m8, r8                     | 00 /r                            | 2   | 00 e8
0049h sbb ebp,esp                                   ; SBB r32, r/m32                   | 1B /r                            | 2   | 1b ec
004bh mov ah,5fh                                    ; MOV r8, imm8                     | B0 +rb ib                        | 2   | b4 5f
004dh pop rsi                                       ; POP r64                          | 58 +ro                           | 1   | 5e
004eh add [rax+rbp*8],cl                            ; ADD r/m8, r8                     | 00 /r                            | 3   | 00 0c e8
0051h adc ebp,esp                                   ; ADC r32, r/m32                   | 13 /r                            | 2   | 13 ec
0053h mov ah,5fh                                    ; MOV r8, imm8                     | B0 +rb ib                        | 2   | b4 5f
0055h pop rsi                                       ; POP r64                          | 58 +ro                           | 1   | 5e
0056h add cl,[rbx]                                  ; ADD r8, r/m8                     | 02 /r                            | 2   | 02 0b
0058h call 7ffb02259840h                            ; CALL rel32                       | E8 cd                            | 5   | e8 0b ec b4 5f
005dh pop rsi                                       ; POP r64                          | 58 +ro                           | 1   | 5e
005eh add al,0ah                                    ; ADD AL, imm8                     | 04 ib                            | 2   | 04 0a
0060h call 7ffb02259840h                            ; CALL rel32                       | E8 cd                            | 5   | e8 03 ec b4 5f
0065h pop rsi                                       ; POP r64                          | 58 +ro                           | 1   | 5e
0066h (bad)                                         ; <invalid>                        | <invalid>                        | 2   | 06 09
0068h call 7ffb02259840h                            ; CALL rel32                       | E8 cd                            | 5   | e8 fb eb b4 5f
006dh pop rsi                                       ; POP r64                          | 58 +ro                           | 1   | 5e
006eh or [rax],cl                                   ; OR r/m8, r8                      | 08 /r                            | 2   | 08 08
0070h call 7ffb02259840h                            ; CALL rel32                       | E8 cd                            | 5   | e8 f3 eb b4 5f
0075h pop rsi                                       ; POP r64                          | 58 +ro                           | 1   | 5e
0076h or al,[rdi]                                   ; OR r8, r/m8                      | 0A /r                            | 2   | 0a 07
0078h call 7ffb02259840h                            ; CALL rel32                       | E8 cd                            | 5   | e8 eb eb b4 5f
007dh pop rsi                                       ; POP r64                          | 58 +ro                           | 1   | 5e
007eh or al,6                                       ; OR AL, imm8                      | 0C ib                            | 2   | 0c 06
0080h call 7ffb02259840h                            ; CALL rel32                       | E8 cd                            | 5   | e8 e3 eb b4 5f
0085h pop rsi                                       ; POP r64                          | 58 +ro                           | 1   | 5e
0086h (bad)                                         ; <invalid>                        | <invalid>                        | 2   | 0e 05
0088h call 7ffb02259840h                            ; CALL rel32                       | E8 cd                            | 5   | e8 db eb b4 5f
008dh pop rsi                                       ; POP r64                          | 58 +ro                           | 1   | 5e
008eh adc [rax+rbp*8],al                            ; ADC r/m8, r8                     | 10 /r                            | 3   | 10 04 e8
0091h shr ebx,cl                                    ; SHR r/m32, CL                    | D3 /5                            | 2   | d3 eb
0093h mov ah,5fh                                    ; MOV r8, imm8                     | B0 +rb ib                        | 2   | b4 5f
0095h pop rsi                                       ; POP r64                          | 58 +ro                           | 1   | 5e
0096h adc al,[rbx]                                  ; ADC r8, r/m8                     | 12 /r                            | 2   | 12 03
0098h call 7ffb02259840h                            ; CALL rel32                       | E8 cd                            | 5   | e8 cb eb b4 5f
009dh pop rsi                                       ; POP r64                          | 58 +ro                           | 1   | 5e
009eh adc al,2                                      ; ADC AL, imm8                     | 14 ib                            | 2   | 14 02
00a0h call 7ffb02259840h                            ; CALL rel32                       | E8 cd                            | 5   | e8 c3 eb b4 5f
00a5h pop rsi                                       ; POP r64                          | 58 +ro                           | 1   | 5e
00a6h (bad)                                         ; <invalid>                        | <invalid>                        | 2   | 16 01
00a8h call 7ffb02259840h                            ; CALL rel32                       | E8 cd                            | 5   | e8 bb eb b4 5f
00adh pop rsi                                       ; POP r64                          | 58 +ro                           | 1   | 5e
00aeh sbb [rax],al                                  ; SBB r/m8, r8                     | 18 /r                            | 2   | 18 00
00b0h adc [rip+7ffaa296h],bh                        ; ADC r/m8, r8                     | 10 /r                            | 6   | 10 3d 96 a2 fa 7f
00b6h add [rax],al                                  ; ADD r/m8, r8                     | 00 /r                            | 2   | 00 00
00b8h jmp near ptr 4cb8h                            ; JMP rel32                        | E9 cd                            | 5   | e9 fb 4b 00 00
00bdh pop rdi                                       ; POP r64                          | 58 +ro                           | 1   | 5f
00beh (bad)                                         ; <invalid>                        | <invalid>                        | 1   | 00
; ----------------------------------------------------------------------------------------------------------------------------------------------------------------
; int run2(in CodeBuffers src)::located://asmrun/sigclient?run2#run2_(CodeBuffers~in)
; public static ReadOnlySpan<byte> run2_ᐤCodeBuffersᕀinᐤ => new byte[183]{0xe9,0xab,0x8e,0x34,0x04,0x5f,0x06,0x01,0xe8,0x53,0xec,0xb4,0x5f,0x5e,0x09,0x00,0xc8,0x39,0x96,0xa2,0xfa,0x7f,0x00,0x00,0xe8,0x43,0xec,0xb4,0x5f,0x5e,0x00,0x01,0xe8,0x3b,0xec,0xb4,0x5f,0x5e,0x04,0x00,0xc0,0x3a,0x96,0xa2,0xfa,0x7f,0x00,0x00,0xe8,0x2b,0xec,0xb4,0x5f,0x5e,0x00,0x00,0xf0,0x3b,0x96,0xa2,0xfa,0x7f,0x00,0x00,0xe8,0x1b,0xec,0xb4,0x5f,0x5e,0x00,0x0c,0xe8,0x13,0xec,0xb4,0x5f,0x5e,0x02,0x0b,0xe8,0x0b,0xec,0xb4,0x5f,0x5e,0x04,0x0a,0xe8,0x03,0xec,0xb4,0x5f,0x5e,0x06,0x09,0xe8,0xfb,0xeb,0xb4,0x5f,0x5e,0x08,0x08,0xe8,0xf3,0xeb,0xb4,0x5f,0x5e,0x0a,0x07,0xe8,0xeb,0xeb,0xb4,0x5f,0x5e,0x0c,0x06,0xe8,0xe3,0xeb,0xb4,0x5f,0x5e,0x0e,0x05,0xe8,0xdb,0xeb,0xb4,0x5f,0x5e,0x10,0x04,0xe8,0xd3,0xeb,0xb4,0x5f,0x5e,0x12,0x03,0xe8,0xcb,0xeb,0xb4,0x5f,0x5e,0x14,0x02,0xe8,0xc3,0xeb,0xb4,0x5f,0x5e,0x16,0x01,0xe8,0xbb,0xeb,0xb4,0x5f,0x5e,0x18,0x00,0x10,0x3d,0x96,0xa2,0xfa,0x7f,0x00,0x00,0xe9,0xfb,0x4b,0x00,0x00,0x5f,0x00};
; BaseAddress = 7ffaa270abe0h
; TermCode = CTC_Zx7
0000h jmp near ptr 4348eb0h                         ; JMP rel32                        | E9 cd                            | 5   | e9 ab 8e 34 04
0005h pop rdi                                       ; POP r64                          | 58 +ro                           | 1   | 5f
0006h (bad)                                         ; <invalid>                        | <invalid>                        | 2   | 06 01
0008h call 7ffb02259840h                            ; CALL rel32                       | E8 cd                            | 5   | e8 53 ec b4 5f
000dh pop rsi                                       ; POP r64                          | 58 +ro                           | 1   | 5e
000eh or [rax],eax                                  ; OR r/m32, r32                    | 09 /r                            | 2   | 09 00
0010h enter 9639h,0a2h                              ; ENTER imm16, imm8                | C8 iw ib                         | 4   | c8 39 96 a2
0014h cli                                           ; CLI                              | FA                               | 1   | fa
0015h jg short 0017h                                ; JG rel8                          | 7F cb                            | 2   | 7f 00
0017h add al,ch                                     ; ADD r/m8, r8                     | 00 /r                            | 2   | 00 e8
0019h in al,dx                                      ; IN AL, DX                        | EC                               | 2   | 43 ec
001bh mov ah,5fh                                    ; MOV r8, imm8                     | B0 +rb ib                        | 2   | b4 5f
001dh pop rsi                                       ; POP r64                          | 58 +ro                           | 1   | 5e
001eh add [rcx],al                                  ; ADD r/m8, r8                     | 00 /r                            | 2   | 00 01
0020h call 7ffb02259840h                            ; CALL rel32                       | E8 cd                            | 5   | e8 3b ec b4 5f
0025h pop rsi                                       ; POP r64                          | 58 +ro                           | 1   | 5e
0026h add al,0                                      ; ADD AL, imm8                     | 04 ib                            | 2   | 04 00
0028h sar byte ptr [rdx],96h                        ; SAR r/m8, imm8                   | C0 /7 ib                         | 3   | c0 3a 96
002bh mov [0b4ec2be800007ffah],al                   ; MOV moffs8, AL                   | A2 mo                            | 9   | a2 fa 7f 00 00 e8 2b ec b4
0034h pop rdi                                       ; POP r64                          | 58 +ro                           | 1   | 5f
0035h pop rsi                                       ; POP r64                          | 58 +ro                           | 1   | 5e
0036h add [rax],al                                  ; ADD r/m8, r8                     | 00 /r                            | 2   | 00 00
0038h (bad)                                         ; <invalid>                        | <invalid>                        | 7   | f0 3b 96 a2 fa 7f 00
003fh add al,ch                                     ; ADD r/m8, r8                     | 00 /r                            | 2   | 00 e8
0041h sbb ebp,esp                                   ; SBB r32, r/m32                   | 1B /r                            | 2   | 1b ec
0043h mov ah,5fh                                    ; MOV r8, imm8                     | B0 +rb ib                        | 2   | b4 5f
0045h pop rsi                                       ; POP r64                          | 58 +ro                           | 1   | 5e
0046h add [rax+rbp*8],cl                            ; ADD r/m8, r8                     | 00 /r                            | 3   | 00 0c e8
0049h adc ebp,esp                                   ; ADC r32, r/m32                   | 13 /r                            | 2   | 13 ec
004bh mov ah,5fh                                    ; MOV r8, imm8                     | B0 +rb ib                        | 2   | b4 5f
004dh pop rsi                                       ; POP r64                          | 58 +ro                           | 1   | 5e
004eh add cl,[rbx]                                  ; ADD r8, r/m8                     | 02 /r                            | 2   | 02 0b
0050h call 7ffb02259840h                            ; CALL rel32                       | E8 cd                            | 5   | e8 0b ec b4 5f
0055h pop rsi                                       ; POP r64                          | 58 +ro                           | 1   | 5e
0056h add al,0ah                                    ; ADD AL, imm8                     | 04 ib                            | 2   | 04 0a
0058h call 7ffb02259840h                            ; CALL rel32                       | E8 cd                            | 5   | e8 03 ec b4 5f
005dh pop rsi                                       ; POP r64                          | 58 +ro                           | 1   | 5e
005eh (bad)                                         ; <invalid>                        | <invalid>                        | 2   | 06 09
0060h call 7ffb02259840h                            ; CALL rel32                       | E8 cd                            | 5   | e8 fb eb b4 5f
0065h pop rsi                                       ; POP r64                          | 58 +ro                           | 1   | 5e
0066h or [rax],cl                                   ; OR r/m8, r8                      | 08 /r                            | 2   | 08 08
0068h call 7ffb02259840h                            ; CALL rel32                       | E8 cd                            | 5   | e8 f3 eb b4 5f
006dh pop rsi                                       ; POP r64                          | 58 +ro                           | 1   | 5e
006eh or al,[rdi]                                   ; OR r8, r/m8                      | 0A /r                            | 2   | 0a 07
0070h call 7ffb02259840h                            ; CALL rel32                       | E8 cd                            | 5   | e8 eb eb b4 5f
0075h pop rsi                                       ; POP r64                          | 58 +ro                           | 1   | 5e
0076h or al,6                                       ; OR AL, imm8                      | 0C ib                            | 2   | 0c 06
0078h call 7ffb02259840h                            ; CALL rel32                       | E8 cd                            | 5   | e8 e3 eb b4 5f
007dh pop rsi                                       ; POP r64                          | 58 +ro                           | 1   | 5e
007eh (bad)                                         ; <invalid>                        | <invalid>                        | 2   | 0e 05
0080h call 7ffb02259840h                            ; CALL rel32                       | E8 cd                            | 5   | e8 db eb b4 5f
0085h pop rsi                                       ; POP r64                          | 58 +ro                           | 1   | 5e
0086h adc [rax+rbp*8],al                            ; ADC r/m8, r8                     | 10 /r                            | 3   | 10 04 e8
0089h shr ebx,cl                                    ; SHR r/m32, CL                    | D3 /5                            | 2   | d3 eb
008bh mov ah,5fh                                    ; MOV r8, imm8                     | B0 +rb ib                        | 2   | b4 5f
008dh pop rsi                                       ; POP r64                          | 58 +ro                           | 1   | 5e
008eh adc al,[rbx]                                  ; ADC r8, r/m8                     | 12 /r                            | 2   | 12 03
0090h call 7ffb02259840h                            ; CALL rel32                       | E8 cd                            | 5   | e8 cb eb b4 5f
0095h pop rsi                                       ; POP r64                          | 58 +ro                           | 1   | 5e
0096h adc al,2                                      ; ADC AL, imm8                     | 14 ib                            | 2   | 14 02
0098h call 7ffb02259840h                            ; CALL rel32                       | E8 cd                            | 5   | e8 c3 eb b4 5f
009dh pop rsi                                       ; POP r64                          | 58 +ro                           | 1   | 5e
009eh (bad)                                         ; <invalid>                        | <invalid>                        | 2   | 16 01
00a0h call 7ffb02259840h                            ; CALL rel32                       | E8 cd                            | 5   | e8 bb eb b4 5f
00a5h pop rsi                                       ; POP r64                          | 58 +ro                           | 1   | 5e
00a6h sbb [rax],al                                  ; SBB r/m8, r8                     | 18 /r                            | 2   | 18 00
00a8h adc [rip+7ffaa296h],bh                        ; ADC r/m8, r8                     | 10 /r                            | 6   | 10 3d 96 a2 fa 7f
00aeh add [rax],al                                  ; ADD r/m8, r8                     | 00 /r                            | 2   | 00 00
00b0h jmp near ptr 4cb0h                            ; JMP rel32                        | E9 cd                            | 5   | e9 fb 4b 00 00
00b5h pop rdi                                       ; POP r64                          | 58 +ro                           | 1   | 5f
00b6h (bad)                                         ; <invalid>                        | <invalid>                        | 1   | 00
