//By KeelKit.Generators.CGenerator   CreateDate:2009-05-16 21:04:11
#include "include/tb_codfiles.h"
struct MSG_TB_CODFILES Msgtb_codfiles;
void InitMsgtb_codfiles(void)
{
memset((char *)&Msgtb_codfiles,'0',sizeof(struct MSG_TB_CODFILES));
}
struct MSG_TB_CODFILES *GetMsgtb_codfiles(void)
{
return (struct MSG_TB_CODFILES  *)&Msgtb_codfiles;
}
void Settb_codfilesMsgfilemd5(char* Inputfilemd5)
{
	strncpy(Msgtb_codfiles.filemd5,Inputfilemd5,sizeof(Msgtb_codfiles.filemd5));
}
void Settb_codfilesMsgfilepath(char* Inputfilepath)
{
	strncpy(Msgtb_codfiles.filepath,Inputfilepath,sizeof(Msgtb_codfiles.filepath));
}

//end_tb_codfiles
