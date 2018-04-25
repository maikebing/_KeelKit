//By KeelKit.Generators.CGenerator   CreateDate:2009-05-16 21:04:11
#include "include/tb_codsoftitem.h"
struct MSG_TB_CODSOFTITEM Msgtb_codsoftitem;
void InitMsgtb_codsoftitem(void)
{
memset((char *)&Msgtb_codsoftitem,'0',sizeof(struct MSG_TB_CODSOFTITEM));
}
struct MSG_TB_CODSOFTITEM *GetMsgtb_codsoftitem(void)
{
return (struct MSG_TB_CODSOFTITEM  *)&Msgtb_codsoftitem;
}
void Settb_codsoftitemMsgCodFileMd5(char* InputCodFileMd5)
{
	strncpy(Msgtb_codsoftitem.CodFileMd5,InputCodFileMd5,sizeof(Msgtb_codsoftitem.CodFileMd5));
}
void Settb_codsoftitemMsgFullName(char* InputFullName)
{
	strncpy(Msgtb_codsoftitem.FullName,InputFullName,sizeof(Msgtb_codsoftitem.FullName));
}
void Settb_codsoftitemMsgSoftName(char* InputSoftName)
{
	strncpy(Msgtb_codsoftitem.SoftName,InputSoftName,sizeof(Msgtb_codsoftitem.SoftName));
}
void Settb_codsoftitemMsgVersion(char* InputVersion)
{
	strncpy(Msgtb_codsoftitem.Version,InputVersion,sizeof(Msgtb_codsoftitem.Version));
}
void Settb_codsoftitemMsgSize(int InputSize)
{
	sprintf(Msgtb_codsoftitem.Size,"%010d",InputSize);
}
void Settb_codsoftitemMsgCreated(char* InputCreated)
{
	strncpy(Msgtb_codsoftitem.Created,InputCreated,sizeof(Msgtb_codsoftitem.Created));
}
void Settb_codsoftitemMsgScore_Good(int InputScore_Good)
{
	sprintf(Msgtb_codsoftitem.Score_Good,"%010d",InputScore_Good);
}
void Settb_codsoftitemMsgScore_Bad(int InputScore_Bad)
{
	sprintf(Msgtb_codsoftitem.Score_Bad,"%010d",InputScore_Bad);
}
void Settb_codsoftitemMsgMoney(int InputMoney)
{
	sprintf(Msgtb_codsoftitem.Money,"%010d",InputMoney);
}
void Settb_codsoftitemMsgUploadDateTime(char* InputUploadDateTime)
{
	strncpy(Msgtb_codsoftitem.UploadDateTime,InputUploadDateTime,sizeof(Msgtb_codsoftitem.UploadDateTime));
}
void Settb_codsoftitemMsgPhoneTypes(char* InputPhoneTypes)
{
	strncpy(Msgtb_codsoftitem.PhoneTypes,InputPhoneTypes,sizeof(Msgtb_codsoftitem.PhoneTypes));
}
void Settb_codsoftitemMsgPhoneOS(char* InputPhoneOS)
{
	strncpy(Msgtb_codsoftitem.PhoneOS,InputPhoneOS,sizeof(Msgtb_codsoftitem.PhoneOS));
}

//end_tb_codsoftitem
