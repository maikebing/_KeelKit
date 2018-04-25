//By KeelKit.Generators.CGenerator   CreateDate:2009-05-16 21:04:11
#ifndef _tb_codfiles_H_
#define _tb_codfiles_H_
struct MSG_TB_CODFILES
{
      char filemd5[32];
      char filepath[20];
};//endstructtb_codfiles
#define  LENGHT_MSG_TB_CODFILES 52
void InitMsgtb_codfiles(void);
struct MSG_TB_CODFILES *GetMsgtb_codfiles(void);
void Set32Msgfilemd5(char*  Inputfilemd5);
void Set20Msgfilepath(char*  Inputfilepath);
#endif //define t_tablename

