//By KeelKit.Generators.CGenerator   CreateDate:2009-05-16 21:04:11
#include "include/tb_user.h"
struct MSG_TB_USER Msgtb_user;
void InitMsgtb_user(void)
{
memset((char *)&Msgtb_user,'0',sizeof(struct MSG_TB_USER));
}
struct MSG_TB_USER *GetMsgtb_user(void)
{
return (struct MSG_TB_USER  *)&Msgtb_user;
}
//用户名
void Settb_userMsgusername(char* Inputusername)
{
	strncpy(Msgtb_user.username,Inputusername,sizeof(Msgtb_user.username));
}
//密码
void Settb_userMsgpassword(char* Inputpassword)
{
	strncpy(Msgtb_user.password,Inputpassword,sizeof(Msgtb_user.password));
}
//手机类型
void Settb_userMsgphonetype(char* Inputphonetype)
{
	strncpy(Msgtb_user.phonetype,Inputphonetype,sizeof(Msgtb_user.phonetype));
}
//电邮
void Settb_userMsgemail(char* Inputemail)
{
	strncpy(Msgtb_user.email,Inputemail,sizeof(Msgtb_user.email));
}

//end_tb_user
