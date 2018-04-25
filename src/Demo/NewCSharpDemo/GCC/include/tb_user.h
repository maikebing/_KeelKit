//By KeelKit.Generators.CGenerator   CreateDate:2009-05-16 21:04:11
#ifndef _tb_user_H_
#define _tb_user_H_
struct MSG_TB_USER
{
      char username[50];//用户名
      char password[50];//密码
      char phonetype[50];//手机类型
      char email[50];//电邮
};//endstructtb_user
#define  LENGHT_MSG_TB_USER 200
void InitMsgtb_user(void);
struct MSG_TB_USER *GetMsgtb_user(void);
void Set50Msgusername(char*  Inputusername);//用户名
void Set50Msgpassword(char*  Inputpassword);//密码
void Set50Msgphonetype(char*  Inputphonetype);//手机类型
void Set50Msgemail(char*  Inputemail);//电邮
#endif //define t_tablename

