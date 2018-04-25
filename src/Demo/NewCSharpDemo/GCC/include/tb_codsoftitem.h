//By KeelKit.Generators.CGenerator   CreateDate:2009-05-16 21:04:11
#ifndef _tb_codsoftitem_H_
#define _tb_codsoftitem_H_
struct MSG_TB_CODSOFTITEM
{
      char CodFileMd5[32];
      char FullName[50];
      char SoftName[50];
      char Version[50];
      char Size[10];
      char Created[23];
      char Score_Good[10];
      char Score_Bad[10];
      char Money[10];
      char UploadDateTime[23];
      char PhoneTypes[50];
      char PhoneOS[50];
};//endstructtb_codsoftitem
#define  LENGHT_MSG_TB_CODSOFTITEM 368
void InitMsgtb_codsoftitem(void);
struct MSG_TB_CODSOFTITEM *GetMsgtb_codsoftitem(void);
void Set32MsgCodFileMd5(char*  InputCodFileMd5);
void Set50MsgFullName(char*  InputFullName);
void Set50MsgSoftName(char*  InputSoftName);
void Set50MsgVersion(char*  InputVersion);
void Settb_codsoftitemMsgSize(int InputSize);
void Settb_codsoftitemMsgCreated(char* InputCreated);
void Settb_codsoftitemMsgScore_Good(int InputScore_Good);
void Settb_codsoftitemMsgScore_Bad(int InputScore_Bad);
void Settb_codsoftitemMsgMoney(int InputMoney);
void Settb_codsoftitemMsgUploadDateTime(char* InputUploadDateTime);
void Set50MsgPhoneTypes(char*  InputPhoneTypes);
void Set50MsgPhoneOS(char*  InputPhoneOS);
#endif //define t_tablename

