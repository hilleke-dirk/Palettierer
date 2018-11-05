﻿Module zmcaux
    '   /********************************** ZMC系列控制器  ************************************************
    '**--------------文件信息--------------------------------------------------------------------------------
    '**文件名: zmcaux.h
    '**创建人: 郑孝洋
    '**时间: 20130621
    '**描述: ZMCDLL 辅助函数

    '**------------修订历史记录----------------------------------------------------------------------------
    '** 修改人: 吴勇
    '** 版  本: V1.5
    '** 日　期: 20150915
    '** 描　述: 
    '**
    '**------------------------------------------------------------------------------------------------------
    '********************************************************************************************************/




    '//ZAUX支持的最大轴数宏
    '#define MAX_AXIS_AUX   32  
    '#define MAX_CARD_AUX   16

    Const MAX_AXIS_AUX = 32
    Const MAX_CARD_AUX = 16





    '/*********************************************************
    '数据类型定义
    '**********************************************************/

    'typedef unsigned __int64   uint64;  
    'typedef __int64   int64;  


    '//#define BYTE           INT8U
    '//#define WORD           INT16U
    '//#define DWORD          INT32U
    'typedef unsigned char  BYTE;
    'typedef unsigned short  WORD;
    '//typedef unsigned int  DWORD;
    '//#define __stdcall 
    'typedef unsigned char  uint8;                   /* defined for unsigned 8-bits integer variable     无符号8位整型变量  */
    'typedef signed   char  int8;                    /* defined for signed 8-bits integer variable        有符号8位整型变量  */
    'typedef unsigned short uint16;                  /* defined for unsigned 16-bits integer variable     无符号16位整型变量 */
    'typedef signed   short int16;                   /* defined for signed 16-bits integer variable         有符号16位整型变量 */
    'typedef unsigned int   uint32;                  /* defined for unsigned 32-bits integer variable     无符号32位整型变量 */
    'typedef signed   int   int32;                   /* defined for signed 32-bits integer variable         有符号32位整型变量 */
    'typedef float          fp32;                    /* single precision floating point variable (32bits) 单精度浮点数（32位长度） */
    'typedef double         fp64;                    /* double precision floating point variable (64bits) 双精度浮点数（64位长度） */
    'typedef unsigned int   uint;                  /* defined for unsigned 32-bits integer variable     无符号32位整型变量 */



    '/************************************************/
    '//错误码 
    '/************************************************/
    '#define ERR_OK  0
    '#define ERROR_OK 0
    '#define ERR_SUCCESS  0

    '#define ERR_AUX_OFFSET       30000

    '#define ERR_NOACK               ERR_AUX_OFFSET      //无应答
    '#define ERR_ACKERROR            (ERR_AUX_OFFSET+1)  //应答错误
    '#define ERR_AUX_PARAERR         (ERR_AUX_OFFSET+2)  //参数错误
    '#define ERR_AUX_NOTSUPPORT      (ERR_AUX_OFFSET+3)  //参数错误

    Const ERR_OK = 0
    Const ERROR_OK = 0
    Const ERR_SUCCESS = 0

    Const ERR_AUX_OFFSET = 30000

    Const ERR_NOACE = ERR_AUX_OFFSET           '无应答
    Const ERR_ACKERROR = (ERR_AUX_OFFSET + 1)   '应答错误
    Const ERR_AUX_PARAERR = (ERR_AUX_OFFSET + 2)  '参数错误
    Const ERR_AUX_NOTSUPPORT = (ERR_AUX_OFFSET + 3)  '参数错误

    '#If 0 Then
    '  //错误输出部分
    '#End If


    '#define  ZAUX_DEBUG //不需要输出时注释掉这行
    '#define  ZAUX_DEBUG_FILE "d:\\zauxout.txt"


    '#ifdef  ZAUX_DEBUG

    '#define ZAUX_TRACE(cText,a)     ZAux_TraceOut("%s,L:%u,"cText"\r\n",__FILE__,(unsigned int)__LINE__,a)
    '#define ZAUX_WARN(cText,a)      ZAux_TraceOut("%s,L:%u,"cText"\r\n",__FILE__,(unsigned int)__LINE__,a)
    '#define ZAUX_ERROR(cText,a)     ZAux_TraceOut("Error:%s,L:%u,"cText"\r\n",__FILE__,(unsigned int)__LINE__,a)
    '#define ZAUX_ERROR2(cText,a,b)     ZAux_TraceOut("Error:%s,L:%u,"cText"\r\n",__FILE__,(unsigned int)__LINE__,a,b)

    '#else

    '#define  ZAUX_TRACE(cText,a)
    '#define  ZAUX_WARN(cText,a)
    '#define  ZAUX_ERROR(cText,a)
    '#define  ZAUX_ERROR2(cText,a,b)

    '#End If

    'void  ZAux_TraceOut(const char * cText, ...);



    '/*********************************************************
    '函数声明
    '**********************************************************/


    '/*************************************************************
    'Description:    //封装 Excute 函数, 以便接收错误
    'Input:          //卡链接handle
    'Output:         //
    'Return:         //错误码
    '*************************************************************/
    'int32 __stdcall ZAux_Execute(ZMC_HANDLE handle, const char* pszCommand, char* psResponse, uint32 uiResponseLength);
    Declare Function ZAux_Execute Lib "zauxdll.dll" (ByVal handle As Integer, ByVal pszCommand As String, ByVal psResponse As String, ByVal uiResponseLength As Integer) As Integer

    '/*************************************************************
    'Description:    //封装 Excute 函数, 以便接收错误
    'Input:          //卡链接handle
    'Output:         //
    'Return:         //错误码
    '*************************************************************/
    'int32 __stdcall ZAux_DirectCommand(ZMC_HANDLE handle, const char* pszCommand, char* psResponse, uint32 uiResponseLength);
    Declare Function ZAux_DirectCommand Lib "zauxdll.dll" (ByVal handle As Integer, ByVal pszCommand As String, ByVal psResponse As String, ByVal uiResponseLength As Integer) As Integer

    '/*************************************************************
    'Description:    //命令跟踪设置.
    'Input:          //卡链接handle
    'Output:         //
    'Return:         //错误码
    '*************************************************************/
    'int32 __stdcall ZAux_SetTraceFile(int bifTofile, const char *pFilePathName);
    Declare Function ZAux_SetTraceFile Lib "zauxdll.dll" (ByVal bifTofile As Integer, ByVal pFilePathName As String) As Integer

    '/*************************************************************
    'Description:    //快速检索控制器
    'Input:          //控制器IP地址
    'Input:          //响应时间
    'Output:         //
    'Return:         //错误码, ERR_OK表示有搜索到.
    '*************************************************************/
    'int32 __stdcall ZAux_SearchEth(const char *ipaddress,  uint32 uims);
    Declare Function ZAux_SearchEth Lib "zauxdll.dll" (ByVal ipaddress As String, ByVal uims As Integer) As Integer

#If 0 Then
    //IO指令
    // 可以使用 ZMC_GetIn ZMC_GetOutput 等 
#End If
    '/*************************************************************
    'Description:    //读取输入信号
    'Input:          //卡链接handle  
    'Output:         //
    'Return:         //错误码
    '*************************************************************/
    'int32 __stdcall ZAux_Direct_GetIn(ZMC_HANDLE handle, int ionum , uint32 *piValue);
    Declare Function ZAux_Direct_GetIn Lib "zauxdll.dll" (ByVal handle As Integer, ByVal ionum As Integer, ByRef piValue As Integer) As Integer

    '/*************************************************************
    'Description:    //打开输出信号
    'Input:          //卡链接handle  
    'Output:         //
    'Return:         //错误码
    '*************************************************************/
    'int32 __stdcall ZAux_Direct_SetOp(ZMC_HANDLE handle, int ionum, uint32 iValue);
    Declare Function ZAux_Direct_SetOp Lib "zauxdll.dll" (ByVal handle As Integer, ByVal ionum As Integer, ByVal iValue As Integer) As Integer

    '/*************************************************************
    'Description:    //读取输出口状态
    'Input:          //卡链接handle  
    'Output:         //
    'Return:         //错误码
    '*************************************************************/
    'int32 __stdcall ZAux_Direct_GetOp(ZMC_HANDLE handle, int ionum, uint32 *piValue);
    Declare Function ZAux_Direct_GetOp Lib "zauxdll.dll" (ByVal handle As Integer, ByVal ionum As Integer, ByRef piValue As Integer) As Integer

    '/*************************************************************
    'Description:    //读取模拟量输入信号
    'Input:          //卡链接handle  
    'Output:         //
    'Return:         //错误码
    '*************************************************************/
    'int32 __stdcall ZAux_Direct_GetAD(ZMC_HANDLE handle, int ionum , float *pfValue);
    Declare Function ZAux_Direct_GetAD Lib "zauxdll.dll" (ByVal handle As Integer, ByVal ionum As Integer, ByRef pfValue As Single) As Integer

    '/*************************************************************
    'Description:    //打开模拟量输出信号
    'Input:          //卡链接handle  
    'Output:         //
    'Return:         //错误码
    '*************************************************************/
    'int32 __stdcall ZAux_Direct_SetDA(ZMC_HANDLE handle, int ionum, float fValue);
    Declare Function ZAux_Direct_SetDA Lib "zauxdll.dll" (ByVal handle As Integer, ByVal ionum As Integer, ByVal fValue As Single) As Integer

    '/*************************************************************
    'Description:    //读取模拟输出口状态
    'Input:          //卡链接handle  
    'Output:         //
    'Return:         //错误码
    '*************************************************************/
    'int32 __stdcall ZAux_Direct_GetDA(ZMC_HANDLE handle, int ionum, float *pfValue);
    Declare Function ZAux_Direct_GetDA Lib "zauxdll.dll" (ByVal handle As Integer, ByVal ionum As Integer, ByRef pfValue As Single) As Integer

    '/*************************************************************
    'Description:    //设置输入口反转
    'Input:          //卡链接handle  
    'Output:         //
    'Return:         //错误码
    '*************************************************************/
    'int32 __stdcall ZAux_Direct_SetInvertIn(ZMC_HANDLE handle, int ionum, int bifInvert);
    Declare Function ZAux_Direct_SetInvertIn Lib "zauxdll.dll" (ByVal handle As Integer, ByVal ionum As Integer, ByVal bifInvert As Long) As Integer

    '/*************************************************************
    'Description:    //读取输入口反转状态
    'Input:          //卡链接handle  
    'Output:         //
    'Return:         //错误码
    '*************************************************************/
    'int32 __stdcall ZAux_Direct_GetInvertIn(ZMC_HANDLE handle, int ionum, int *piValue);
    Declare Function ZAux_Direct_GetInvertIn Lib "zauxdll.dll" (ByVal handle As Integer, ByVal ionum As Integer, ByRef piValue As Integer) As Integer

    '/*************************************************************
    'Description:    //设置pwm频率
    'Input:          //卡链接handle  
    'Output:         //
    'Return:         //错误码
    '*************************************************************/
    'int32 __stdcall ZAux_Direct_SetPwmFreq(ZMC_HANDLE handle, int ionum, float fValue);
    Declare Function ZAux_Direct_SetPwmFreq Lib "zauxdll.dll" (ByVal handle As Integer, ByVal ionum As Integer, ByVal fValue As Single) As Integer

    '/*************************************************************
    'Description:    //读取pwm频率
    'Input:          //卡链接handle  
    'Output:         //
    'Return:         //错误码
    '*************************************************************/
    'int32 __stdcall ZAux_Direct_GetPwmFreq(ZMC_HANDLE handle, int ionum, float *pfValue);
    Declare Function ZAux_Direct_GetPwmFreq Lib "zauxdll.dll" (ByVal handle As Integer, ByVal ionum As Integer, ByRef pfValue As Single) As Integer

    '/*************************************************************
    'Description:    //设置pwm占空比
    'Input:          //卡链接handle  
    'Output:         //
    'Return:         //错误码
    '*************************************************************/
    'int32 __stdcall ZAux_Direct_SetPwmDuty(ZMC_HANDLE handle, int ionum, float fValue);
    Declare Function ZAux_Direct_SetPwmDuty Lib "zauxdll.dll" (ByVal handle As Integer, ByVal ionum As Integer, ByVal fValue As Single) As Integer

    '/*************************************************************
    'Description:    //读取pwm占空比
    'Input:          //卡链接handle  
    'Output:         //
    'Return:         //错误码
    '*************************************************************/
    'int32 __stdcall ZAux_Direct_GetPwmDuty(ZMC_HANDLE handle, int ionum, float *pfValue);
    Declare Function ZAux_Direct_GetPwmDuty Lib "zauxdll.dll" (ByVal handle As Integer, ByVal ionum As Integer, ByRef pfValue As Single) As Integer

    '#If 0 Then
    '    //通过modbus快速读取特殊寄存器
    '#End If

    '/*************************************************************
    'Description:    //参数 快速读取多个输入
    'Input:          //卡链接handle  
    'Output:         //按位存储
    'Return:         //错误码
    '*************************************************************/
    'int32 __stdcall ZAux_GetModbusIn(ZMC_HANDLE handle, int ionumfirst, int ionumend, uint8 *pValueList);
    Declare Function ZAux_GetModbusIn Lib "zauxdll.dll" (ByVal handle As Integer, ByVal ionumfirst As Integer, ByVal ionumend As Integer, ByRef pValueList As Byte) As Integer

    '/*************************************************************
    'Description:    //参数 快速读取多个当前的输出状态
    'Input:          //卡链接handle  
    'Output:         //按位存储
    'Return:         //错误码
    '*************************************************************/
    'int32 __stdcall ZAux_GetModbusOut(ZMC_HANDLE handle, int ionumfirst, int ionumend, uint8 *pValueList);
    Declare Function ZAux_GetModbusOut Lib "zauxdll.dll" (ByVal handle As Integer, ByVal ionumfirst As Integer, ByVal ionumend As Integer, ByRef pValueList As Byte) As Integer

    '/*************************************************************
    'Description:    //参数 快速读取多个当前的DPOS
    'Input:          //卡链接handle  
    'Output:         //按存储
    'Return:         //错误码
    '*************************************************************/
    'int32 __stdcall ZAux_GetModbusDpos(ZMC_HANDLE handle, int imaxaxises, float *pValueList);
    Declare Function ZAux_GetModbusDpos Lib "zauxdll.dll" (ByVal handle As Integer, ByVal imaxaxises As Integer, ByRef pValueList As Single) As Integer

    '/*************************************************************
    'Description:    //参数 快速读取多个当前的MPOS
    'Input:          //卡链接handle  
    'Output:         //按存储
    'Return:         //错误码
    '*************************************************************/
    'int32 __stdcall ZAux_GetModbusMpos(ZMC_HANDLE handle, int imaxaxises, float *pValueList);
    Declare Function ZAux_GetModbusMpos Lib "zauxdll.dll" (ByVal handle As Integer, ByVal imaxaxises As Integer, ByRef pValueList As Single) As Integer

    '/*************************************************************
    'Description:    //参数 快速读取多个当前的速度
    'Input:          //卡链接handle  
    'Output:         //按存储
    'Return:         //错误码
    '*************************************************************/
    'int32 __stdcall ZAux_GetModbusCurSpeed(ZMC_HANDLE handle, int imaxaxises, float *pValueList);
    Declare Function ZAux_GetModbusCurSpeed Lib "zauxdll.dll" (ByVal handle As Integer, ByVal imaxaxises As Integer, ByRef pValueList As Single) As Integer


    '#If 0 Then
    '    //采用ZMC_DirectCommand 来快速获取一些状态, ZMC_DirectCommand的执行比ZMC_Execute要快'
    '// 只有参数，变量，数组元素等能使用ZMC_DirectCommand
    '// 20130901以后的版本，一些运动函数也可以调用ZMC_DirectCommand，当运动条件不满足的时候，会立刻返回失败。
    '// ZMC_DirectCommand调用运动函数时，参数必须是具体的数值，不能是变量表达式。
    '#End If

    '/*************************************************************
    'Description:    //通用的参数修改函数 sParam: 填写参数名称
    'Input:          //卡链接handle 
    'Output:         //
    'Return:         //错误码
    '*************************************************************/
    'int32 __stdcall ZAux_Direct_SetParam(ZMC_HANDLE handle,const char *sParam,int iaxis, float fset);
    Declare Function ZAux_Direct_SetParam Lib "zauxdll.dll" (ByVal handle As Integer, ByRef sParam As String, ByVal iaxis As Integer, ByVal fset As Single) As Integer

    '/*************************************************************
    'Description:    //参数 通用的参数读取函数, sParam:填写参数名称
    'Input:          //卡链接handle  
    'Output:         //
    'Return:         //错误码
    '*************************************************************/
    'int32 __stdcall ZAux_Direct_GetParam(ZMC_HANDLE handle,const char *sParam, int iaxis, float *pfValue);
    Declare Function ZAux_Direct_GetParam Lib "zauxdll.dll" (ByVal handle As Integer, ByRef sParam As String, ByVal iaxis As Integer, ByRef pfValue As Single) As Integer

    '/*************************************************************
    'Description:    //设置加速度
    'Input:          //卡链接handle  
    'Output:         //
    'Return:         //错误码
    '*************************************************************/
    'int32 __stdcall ZAux_Direct_SetAccel(ZMC_HANDLE handle, int iaxis, float fValue);
    Declare Function ZAux_Direct_SetAccel Lib "zauxdll.dll" (ByVal handle As Integer, ByVal iaxis As Integer, ByVal fValue As Single) As Integer

    '/*************************************************************
    'Description:    //读取加速度
    'Input:          //卡链接handle  
    'Output:         //
    'Return:         //错误码
    '*************************************************************/
    'int32 __stdcall ZAux_Direct_GetAccel(ZMC_HANDLE handle, int iaxis, float *pfValue);
    Declare Function ZAux_Direct_GetAccel Lib "zauxdll.dll" (ByVal handle As Integer, ByVal iaxis As Integer, ByRef pfValue As Single) As Integer

    '/*************************************************************
    'Description:    //读取叠加轴
    'Input:          //卡链接handle  
    'Output:         //
    'Return:         //错误码
    '*************************************************************/
    'int32 __stdcall ZAux_Direct_GetAddax(ZMC_HANDLE handle, int iaxis, int *piValue);
    Declare Function ZAux_Direct_GetAddax Lib "zauxdll.dll" (ByVal handle As Integer, ByVal iaxis As Integer, ByRef piValue As Integer) As Integer

    '/*************************************************************
    'Description:    //设置轴告警信号
    'Input:          //卡链接handle  
    'Output:         //
    'Return:         //错误码
    '*************************************************************/
    'int32 __stdcall ZAux_Direct_SetAlmIn(ZMC_HANDLE handle, int iaxis, int iValue);
    Declare Function ZAux_Direct_SetAlmIn Lib "zauxdll.dll" (ByVal handle As Integer, ByVal iaxis As Integer, ByVal iValue As Integer) As Integer

    '/*************************************************************
    'Description:    //读取告警信号
    'Input:          //卡链接handle  
    'Output:         //
    'Return:         //错误码
    '*************************************************************/
    'int32 __stdcall ZAux_Direct_GetAlmIn(ZMC_HANDLE handle, int iaxis, int *piValue);
    Declare Function ZAux_Direct_GetAlmIn Lib "zauxdll.dll" (ByVal handle As Integer, ByVal iaxis As Integer, ByRef piValue As Integer) As Integer

    '/*************************************************************
    'Description:    //设置轴类型
    'Input:          //卡链接handle  
    'Output:         //
    'Return:         //错误码
    '*************************************************************/
    'int32 __stdcall ZAux_Direct_SetAtype(ZMC_HANDLE handle, int iaxis, int iValue);
    Declare Function ZAux_Direct_SetAtype Lib "zauxdll.dll" (ByVal handle As Integer, ByVal iaxis As Integer, ByVal iValue As Integer) As Integer

    '/*************************************************************
    'Description:    //读取轴类型
    'Input:          //卡链接handle  
    'Output:         //
    'Return:         //错误码
    '*************************************************************/
    'int32 __stdcall ZAux_Direct_GetAtype(ZMC_HANDLE handle, int iaxis, int *piValue);
    Declare Function ZAux_Direct_GetAtype Lib "zauxdll.dll" (ByVal handle As Integer, ByVal iaxis As Integer, ByRef piValue As Integer) As Integer

    '/*************************************************************
    'Description:    //读取轴状态
    'Input:          //卡链接handle  
    'Output:         //
    'Return:         //错误码
    '*************************************************************/
    'int32 __stdcall ZAux_Direct_GetAxisStatus(ZMC_HANDLE handle, int iaxis, int *piValue);
    Declare Function ZAux_Direct_GetAxisStatus Lib "zauxdll.dll" (ByVal handle As Integer, ByVal iaxis As Integer, ByRef piValue As Integer) As Integer

    '/*************************************************************
    'Description:    //设置轴地址
    'Input:          //卡链接handle  
    'Output:         //
    'Return:         //错误码
    '*************************************************************/
    'int32 __stdcall ZAux_Direct_SetAxisAddress(ZMC_HANDLE handle, int iaxis, int iValue);
    Declare Function ZAux_Direct_SetAxisAddress Lib "zauxdll.dll" (ByVal handle As Integer, ByVal iaxis As Integer, ByRef piValue As Integer) As Integer

    '/*************************************************************
    'Description:    //读取轴地址
    'Input:          //卡链接handle  
    'Output:         //
    'Return:         //错误码
    '*************************************************************/
    'int32 __stdcall ZAux_Direct_GetAxisAddress(ZMC_HANDLE handle, int iaxis, int *piValue);
    Declare Function ZAux_Direct_GetAxisAddress Lib "zauxdll.dll" (ByVal handle As Integer, ByVal iaxis As Integer, ByRef piValue As Integer) As Integer

    '/*************************************************************
    'Description:    //设置轴使能
    'Input:          //卡链接handle  
    'Output:         //
    'Return:         //错误码
    '*************************************************************/
    'int32 __stdcall ZAux_Direct_SetAxisEnable(ZMC_HANDLE handle, int iaxis, int iValue);
    Declare Function ZAux_Direct_SetAxisEnable Lib "zauxdll.dll" (ByVal handle As Integer, ByVal iaxis As Integer, ByVal iValue As Integer) As Integer

    '/*************************************************************
    'Description:    //读取轴使能状态
    'Input:          //卡链接handle  
    'Output:         //
    'Return:         //错误码
    '*************************************************************/
    'int32 __stdcall ZAux_Direct_GetAxisEnable(ZMC_HANDLE handle, int iaxis, int *piValue);
    Declare Function ZAux_Direct_GetAxisEnable Lib "zauxdll.dll" (ByVal handle As Integer, ByVal iaxis As Integer, ByRef piValue As Integer) As Integer

    '/*************************************************************
    'Description:    //设置链接速率
    'Input:          //卡链接handle  
    'Output:         //
    'Return:         //错误码
    '*************************************************************/
    'int32 __stdcall ZAux_Direct_SetClutchRate(ZMC_HANDLE handle, int iaxis, float fValue);
    Declare Function ZAux_Direct_SetClutchRate Lib "zauxdll.dll" (ByVal handle As Integer, ByVal iaxis As Integer, ByVal fValue As Single) As Integer

    '/*************************************************************
    'Description:    //读取链接速率
    'Input:          //卡链接handle  
    'Output:         //
    'Return:         //错误码
    '*************************************************************/
    'int32 __stdcall ZAux_Direct_GetClutchRate(ZMC_HANDLE handle, int iaxis, float *pfValue);
    Declare Function ZAux_Direct_GetClutchRate Lib "zauxdll.dll" (ByVal handle As Integer, ByVal iaxis As Integer, ByRef pfValue As Single) As Integer

    '/*************************************************************
    'Description:    //设置锁存触发的结束坐标范围点
    'Input:          //卡链接handle  
    'Output:         //
    'Return:         //错误码
    '*************************************************************/
    'int32 __stdcall ZAux_Direct_SetCloseWin(ZMC_HANDLE handle, int iaxis, float fValue);
    Declare Function ZAux_Direct_SetCloseWin Lib "zauxdll.dll" (ByVal handle As Integer, ByVal iaxis As Integer, ByVal fValue As Single) As Integer

    '/*************************************************************
    'Description:    //读取锁存触发的结束坐标范围点
    'Input:          //卡链接handle  
    'Output:         //
    'Return:         //错误码
    '*************************************************************/
    'int32 __stdcall ZAux_Direct_GetCloseWin(ZMC_HANDLE handle, int iaxis, float *pfValue);
    Declare Function ZAux_Direct_GetCloseWin Lib "zauxdll.dll" (ByVal handle As Integer, ByVal iaxis As Integer, ByRef fValue As Single) As Integer

    '/*************************************************************
    'Description:    //设置拐角减速
    'Input:          //卡链接handle  
    'Output:         //
    'Return:         //错误码
    '*************************************************************/
    'int32 __stdcall ZAux_Direct_SetCornerMode(ZMC_HANDLE handle, int iaxis, int iValue);
    Declare Function ZAux_Direct_SetCornerMode Lib "zauxdll.dll" (ByVal handle As Integer, ByVal iaxis As Integer, ByVal iValue As Integer) As Integer

    '/*************************************************************
    'Description:    //读取拐角减速
    'Input:          //卡链接handle  
    'Output:         //
    'Return:         //错误码
    '*************************************************************/
    'int32 __stdcall ZAux_Direct_GetCornerMode(ZMC_HANDLE handle, int iaxis, int *piValue);
    Declare Function ZAux_Direct_GetCornerMode Lib "zauxdll.dll" (ByVal handle As Integer, ByVal iaxis As Integer, ByRef piValue As Integer) As Integer

    '/*************************************************************
    'Description:    //设置回零爬行速度
    'Input:          //卡链接handle  
    'Output:         //
    'Return:         //错误码
    '*************************************************************/
    'int32 __stdcall ZAux_Direct_SetCreep(ZMC_HANDLE handle, int iaxis, float fValue);
    Declare Function ZAux_Direct_SetCreep Lib "zauxdll.dll" (ByVal handle As Integer, ByVal iaxis As Integer, ByVal fValue As Single) As Integer

    '/*************************************************************
    'Description:    //读取回零爬行速度
    'Input:          //卡链接handle  
    'Output:         //
    'Return:         //错误码
    '*************************************************************/
    'int32 __stdcall ZAux_Direct_GetCreep(ZMC_HANDLE handle, int iaxis, float *pfValue);
    Declare Function ZAux_Direct_GetCreep Lib "zauxdll.dll" (ByVal handle As Integer, ByVal iaxis As Integer, ByRef fValue As Single) As Integer

    '/*************************************************************
    'Description:    //设置原点信号
    'Input:          //卡链接handle  
    'Output:         //
    'Return:         //错误码
    '*************************************************************/
    'int32 __stdcall ZAux_Direct_SetDatumIn(ZMC_HANDLE handle, int iaxis, int iValue);
    Declare Function ZAux_Direct_SetDatumIn Lib "zauxdll.dll" (ByVal handle As Integer, ByVal iaxis As Integer, ByVal iValue As Integer) As Integer

    '/*************************************************************
    'Description:    //读取原点信号
    'Input:          //卡链接handle  
    'Output:         //
    'Return:         //错误码
    '*************************************************************/
    'int32 __stdcall ZAux_Direct_GetDatumIn(ZMC_HANDLE handle, int iaxis, int *piValue);
    Declare Function ZAux_Direct_GetDatumIn Lib "zauxdll.dll" (ByVal handle As Integer, ByVal iaxis As Integer, ByRef piValue As Integer) As Integer

    '/*************************************************************
    'Description:    //设置减速度
    'Input:          //卡链接handle  
    'Output:         //
    'Return:         //错误码
    '*************************************************************/
    'int32 __stdcall ZAux_Direct_SetDecel(ZMC_HANDLE handle, int iaxis, float fValue);
    Declare Function ZAux_Direct_SetDecel Lib "zauxdll.dll" (ByVal handle As Integer, ByVal iaxis As Integer, ByVal fValue As Single) As Integer

    '/*************************************************************
    'Description:    //读取减速度
    'Input:          //卡链接handle  
    'Output:         //
    'Return:         //错误码
    '*************************************************************/
    'int32 __stdcall ZAux_Direct_GetDecel(ZMC_HANDLE handle, int iaxis, float *pfValue);
    Declare Function ZAux_Direct_GetDecel Lib "zauxdll.dll" (ByVal handle As Integer, ByVal iaxis As Integer, ByRef pfValue As Single) As Integer

    '/*************************************************************
    'Description:    //设置拐角减速角度，开始减速角度，单位为弧度
    'Input:          //卡链接handle  
    'Output:         //
    'Return:         //错误码
    '*************************************************************/
    'int32 __stdcall ZAux_Direct_SetDecelAngle(ZMC_HANDLE handle, int iaxis, float fValue);
    Declare Function ZAux_Direct_SetDecelAngle Lib "zauxdll.dll" (ByVal handle As Integer, ByVal iaxis As Integer, ByVal fValue As Single) As Integer

    '/*************************************************************'
    'Description:    //读取拐角开始减速角度
    'Input:          //卡链接handle  
    'Output:         //
    'Return:         //错误码
    '*************************************************************/
    'int32 __stdcall ZAux_Direct_GetDecelAngle(ZMC_HANDLE handle, int iaxis, float *pfValue);
    Declare Function ZAux_Direct_GetDecelAngle Lib "zauxdll.dll" (ByVal handle As Integer, ByVal iaxis As Integer, ByRef pfValue As Single) As Integer

    '/*************************************************************
    'Description:    //设置轴位置
    'Input:          //卡链接handle   
    'Output:         //
    'Return:         //错误码
    '*************************************************************/
    'int32 __stdcall ZAux_Direct_SetDpos(ZMC_HANDLE handle, int iaxis, float fValue);
    Declare Function ZAux_Direct_SetDpos Lib "zauxdll.dll" (ByVal handle As Integer, ByVal iaxis As Integer, ByVal fValue As Single) As Integer

    '/*************************************************************
    'Description:    //读取轴位置
    'Input:          //卡链接handle  
    'Output:         //
    'Return:         //错误码
    '*************************************************************/
    'int32 __stdcall ZAux_Direct_GetDpos(ZMC_HANDLE handle, int iaxis, float *pfValue);
    Declare Function ZAux_Direct_GetDpos Lib "zauxdll.dll" (ByVal handle As Integer, ByVal iaxis As Integer, ByRef pfValue As Single) As Integer

    '/*************************************************************
    'Description:    //读取内部编码器值
    'Input:          //卡链接handle  
    'Output:         //
    'Return:         //错误码
    '*************************************************************/
    'int32 __stdcall ZAux_Direct_GetEncoder(ZMC_HANDLE handle, int iaxis, float *pfValue);
    Declare Function ZAux_Direct_GetEncoder Lib "zauxdll.dll" (ByVal handle As Integer, ByVal iaxis As Integer, ByRef pfValue As Single) As Integer

    '/*************************************************************
    'Description:    //读取当前运动的最终位置
    'Input:          //卡链接handle  
    'Output:         //
    'Return:         //错误码
    '*************************************************************/
    'int32 __stdcall ZAux_Direct_GetEndMove(ZMC_HANDLE handle, int iaxis, float *pfValue);
    Declare Function ZAux_Direct_GetEndMove Lib "zauxdll.dll" (ByVal handle As Integer, ByVal iaxis As Integer, ByRef pfValue As Single) As Integer

    '/*************************************************************
    'Description:    //读取当前和缓冲中运动的最终位置，可以用于相对绝对转换
    'Input:          //卡链接handle  
    'Output:         //
    'Return:         //错误码
    '*************************************************************/
    'int32 __stdcall ZAux_Direct_GetEndMoveBuffer(ZMC_HANDLE handle, int iaxis, float *pfValue);
    Declare Function ZAux_Direct_GetEndMoveBuffer Lib "zauxdll.dll" (ByVal handle As Integer, ByVal iaxis As Integer, ByRef pfValue As Single) As Integer

    '/*************************************************************
    'Description:    //设置SP运动的结束速度
    'Input:          //卡链接handle  
    'Output:         //
    'Return:         //错误码
    '*************************************************************/
    'int32 __stdcall ZAux_Direct_SetEndMoveSpeed(ZMC_HANDLE handle, int iaxis, float fValue);
    Declare Function ZAux_Direct_SetEndMoveSpeed Lib "zauxdll.dll" (ByVal handle As Integer, ByVal iaxis As Integer, ByVal fValue As Single) As Integer

    '/*************************************************************
    'Description:    //读取SP运动的结束速度
    'Input:          //卡链接handle  
    'Output:         //
    'Return:         //错误码
    '*************************************************************/
    'int32 __stdcall ZAux_Direct_GetEndMoveSpeed(ZMC_HANDLE handle, int iaxis, float *pfValue);
    Declare Function ZAux_Direct_GetEndMoveSpeed Lib "zauxdll.dll" (ByVal handle As Integer, ByVal iaxis As Integer, ByRef pfValue As Single) As Integer

    '/*************************************************************
    'Description:    //设置错误标记，和AXISSTATUS做与运算来决定哪些错误需要关闭WDOG。
    'Input:          //卡链接handle  
    'Output:         //
    'Return:         //错误码
    '*************************************************************/
    'int32 __stdcall ZAux_Direct_SetErrormask(ZMC_HANDLE handle, int iaxis, int iValue);
    Declare Function ZAux_Direct_SetErrormask Lib "zauxdll.dll" (ByVal handle As Integer, ByVal iaxis As Integer, ByVal pfValue As Integer) As Integer

    '/*************************************************************
    'Description:    //读取错误标记，和AXISSTATUS做与运算来决定哪些错误需要关闭WDOG。
    'Input:          //卡链接handle  
    'Output:         //
    'Return:         //错误码
    '*************************************************************/
    'int32 __stdcall ZAux_Direct_GetErrormask(ZMC_HANDLE handle, int iaxis, int *piValue);
    Declare Function ZAux_Direct_GetErrormask Lib "zauxdll.dll" (ByVal handle As Integer, ByVal iaxis As Integer, ByRef piValue As Integer) As Integer

    '/*************************************************************
    'Description:    //设置快速JOG输入
    'Input:          //卡链接handle  
    'Output:         //
    'Return:         //错误码
    '*************************************************************/
    'int32 __stdcall ZAux_Direct_SetFastJog(ZMC_HANDLE handle, int iaxis, int iValue);
    Declare Function ZAux_Direct_SetFastJog Lib "zauxdll.dll" (ByVal handle As Integer, ByVal iaxis As Integer, ByVal iValue As Integer) As Integer

    '/*************************************************************
    'Description:    //读取快速JOG输入
    'Input:          //卡链接handle  
    'Output:         //
    'Return:         //错误码
    '*************************************************************/
    'int32 __stdcall ZAux_Direct_GetFastJog(ZMC_HANDLE handle, int iaxis, int *piValue);
    Declare Function ZAux_Direct_GetFastJog Lib "zauxdll.dll" (ByVal handle As Integer, ByVal iaxis As Integer, ByRef piValue As Integer) As Integer

    '/*************************************************************
    'Description:    //设置快速减速度
    'Input:          //卡链接handle  
    'Output:         //
    'Return:         //错误码
    '*************************************************************/
    'int32 __stdcall ZAux_Direct_SetFastDec(ZMC_HANDLE handle, int iaxis, float fValue);
    Declare Function ZAux_Direct_SetFastDec Lib "zauxdll.dll" (ByVal handle As Integer, ByVal iaxis As Integer, ByVal fValue As Single) As Integer

    '/*************************************************************
    'Description:    //读取快速减速度
    'Input:          //卡链接handle  
    'Output:         //
    'Return:         //错误码
    '*************************************************************/
    'int32 __stdcall ZAux_Direct_GetFastDec(ZMC_HANDLE handle, int iaxis, float *pfValue);
    Declare Function ZAux_Direct_GetFastDec Lib "zauxdll.dll" (ByVal handle As Integer, ByVal iaxis As Integer, ByRef pfValue As Single) As Integer

    '/*************************************************************
    'Description:    //读取随动误差
    'Input:          //卡链接handle  
    'Output:         //
    'Return:         //错误码
    '*************************************************************/
    'int32 __stdcall ZAux_Direct_GetFe(ZMC_HANDLE handle, int iaxis, float *pfValue);
    Declare Function ZAux_Direct_GetFe Lib "zauxdll.dll" (ByVal handle As Integer, ByVal iaxis As Integer, ByRef pfValue As Single) As Integer

    '/*************************************************************
    'Description:    //设置最大允许的随动误差值
    'Input:          //卡链接handle  
    'Output:         //
    'Return:         //错误码
    '*************************************************************/
    'int32 __stdcall ZAux_Direct_SetFeLimit(ZMC_HANDLE handle, int iaxis, float fValue);
    Declare Function ZAux_Direct_SetFeLimit Lib "zauxdll.dll" (ByVal handle As Integer, ByVal iaxis As Integer, ByVal fValue As Single) As Integer

    '/*************************************************************
    'Description:    //读取最大允许的随动误差值
    'Input:          //卡链接handle  
    'Output:         //
    'Return:         //错误码
    '*************************************************************/
    'int32 __stdcall ZAux_Direct_GetFeLimit(ZMC_HANDLE handle, int iaxis, float *pfValue);
    Declare Function ZAux_Direct_GetFeLimit Lib "zauxdll.dll" (ByVal handle As Integer, ByVal iaxis As Integer, ByRef pfValue As Single) As Integer

    '/*************************************************************
    'Description:    //设置报警时随动误差值
    'Input:          //卡链接handle  
    'Output:         //
    'Return:         //错误码
    '*************************************************************/
    'int32 __stdcall ZAux_Direct_SetFRange(ZMC_HANDLE handle, int iaxis, float fValue);
    Declare Function ZAux_Direct_SetFRange Lib "zauxdll.dll" (ByVal handle As Integer, ByVal iaxis As Integer, ByVal fValue As Single) As Integer

    '/*************************************************************
    'Description:    //读取报警时的随动误差值
    'Input:          //卡链接handle  
    'Output:         //
    'Return:         //错误码
    '*************************************************************/
    'int32 __stdcall ZAux_Direct_GetFeRange(ZMC_HANDLE handle, int iaxis, float *pfValue);
    Declare Function ZAux_Direct_GetFeRange Lib "zauxdll.dll" (ByVal handle As Integer, ByVal iaxis As Integer, ByRef pfValue As Single) As Integer

    '/*************************************************************
    'Description:    //设置保持输入
    'Input:          //卡链接handle  
    'Output:         //
    'Return:         //错误码
    '*************************************************************/
    'int32 __stdcall ZAux_Direct_SetFholdIn(ZMC_HANDLE handle, int iaxis, int iValue);
    Declare Function ZAux_Direct_SetFholdIn Lib "zauxdll.dll" (ByVal handle As Integer, ByVal iaxis As Integer, ByVal iValue As Integer) As Integer

    '/*************************************************************
    'Description:    //读取保持输入
    'Input:          //卡链接handle  
    'Output:         //
    'Return:         //错误码
    '*************************************************************/
    'int32 __stdcall ZAux_Direct_GetFholdIn(ZMC_HANDLE handle, int iaxis, int *piValue);
    Declare Function ZAux_Direct_GetFholdIn Lib "zauxdll.dll" (ByVal handle As Integer, ByVal iaxis As Integer, ByRef piValue As Integer) As Integer

    '/*************************************************************
    'Description:    //设置轴保持速度
    'Input:          //卡链接handle  
    'Output:         //
    'Return:         //错误码
    '*************************************************************/
    'int32 __stdcall ZAux_Direct_SetFhspeed(ZMC_HANDLE handle, int iaxis, float fValue);
    Declare Function ZAux_Direct_SetFhspeed Lib "zauxdll.dll" (ByVal handle As Integer, ByVal iaxis As Integer, ByVal fValue As Single) As Integer

    '/*************************************************************
    'Description:    //读取轴保持速度
    'Input:          //卡链接handle  
    'Output:         //
    'Return:         //错误码
    '*************************************************************/
    'int32 __stdcall ZAux_Direct_GetFhspeed(ZMC_HANDLE handle, int iaxis, float *pfValue);
    Declare Function ZAux_Direct_GetFhspeed Lib "zauxdll.dll" (ByVal handle As Integer, ByVal iaxis As Integer, ByRef pfValue As Single) As Integer

    '/*************************************************************
    'Description:    //设置SP运动的运行速度
    'Input:          //卡链接handle  
    'Output:         //
    'Return:         //错误码
    '*************************************************************/
    'int32 __stdcall ZAux_Direct_SetForceSpeed(ZMC_HANDLE handle, int iaxis, float fValue);
    Declare Function ZAux_Direct_SetForceSpeed Lib "zauxdll.dll" (ByVal handle As Integer, ByVal iaxis As Integer, ByVal fValue As Single) As Integer

    '/*************************************************************
    'Description:    //读取SP运动的运行速度
    'Input:          //卡链接handle  
    'Output:         //
    'Return:         //错误码
    '*************************************************************/
    'int32 __stdcall ZAux_Direct_GetForceSpeed(ZMC_HANDLE handle, int iaxis, float *pfValue);
    Declare Function ZAux_Direct_GetForceSpeed Lib "zauxdll.dll" (ByVal handle As Integer, ByVal iaxis As Integer, ByRef pfValue As Single) As Integer

    '/*************************************************************
    'Description:    //设置正向软限位
    'Input:          //卡链接handle  
    'Output:         //
    'Return:         //错误码
    '*************************************************************/
    'int32 __stdcall ZAux_Direct_SetFsLimit(ZMC_HANDLE handle, int iaxis, float fValue);
    Declare Function ZAux_Direct_SetFsLimit Lib "zauxdll.dll" (ByVal handle As Integer, ByVal iaxis As Integer, ByVal fValue As Single) As Integer

    '/*************************************************************
    'Description:    //读取正向软限位
    'Input:          //卡链接handle  
    'Output:         //
    'Return:         //错误码
    '*************************************************************/
    'int32 __stdcall ZAux_Direct_GetFsLimit(ZMC_HANDLE handle, int iaxis, float *pfValue);
    Declare Function ZAux_Direct_GetFsLimit Lib "zauxdll.dll" (ByVal handle As Integer, ByVal iaxis As Integer, ByRef pfValue As Single) As Integer

    '/*************************************************************
    'Description:    //设置小圆限速最小半径
    'Input:          //卡链接handle  
    'Output:         //
    'Return:         //错误码
    '*************************************************************/
    'int32 __stdcall ZAux_Direct_SetFullSpRadius(ZMC_HANDLE handle, int iaxis, float fValue);
    Declare Function ZAux_Direct_SetFullSpRadius Lib "zauxdll.dll" (ByVal handle As Integer, ByVal iaxis As Integer, ByVal fValue As Single) As Integer

    '/*************************************************************
    'Description:    //读取小圆限速最小半径
    'Input:          //卡链接handle  
    'Output:         //
    'Return:         //错误码
    '*************************************************************/
    'int32 __stdcall ZAux_Direct_GetFullSpRadius(ZMC_HANDLE handle, int iaxis, float *pfValue);
    Declare Function ZAux_Direct_GetFullSpRadius Lib "zauxdll.dll" (ByVal handle As Integer, ByVal iaxis As Integer, ByRef pfValue As Single) As Integer

    '/*************************************************************
    'Description:    //设置正向硬限位输入
    'Input:          //卡链接handle  
    'Output:         //
    'Return:         //错误码
    '*************************************************************/
    'int32 __stdcall ZAux_Direct_SetFwdIn(ZMC_HANDLE handle, int iaxis, int iValue);
    Declare Function ZAux_Direct_SetFwdIn Lib "zauxdll.dll" (ByVal handle As Integer, ByVal iaxis As Integer, ByVal iValue As Integer) As Integer

    '/*************************************************************
    'Description:    //读取正向硬限位输入
    'Input:          //卡链接handle  
    'Output:         //
    'Return:         //错误码
    '*************************************************************/
    'int32 __stdcall ZAux_Direct_GetFwdIn(ZMC_HANDLE handle, int iaxis, int *piValue);
    Declare Function ZAux_Direct_GetFwdIn Lib "zauxdll.dll" (ByVal handle As Integer, ByVal iaxis As Integer, ByRef piValue As Integer) As Integer

    '/*************************************************************
    'Description:    //设置正向JOG输入
    'Input:          //卡链接handle  
    'Output:         //
    'Return:         //错误码
    '*************************************************************/
    'int32 __stdcall ZAux_Direct_SetFwdJog(ZMC_HANDLE handle, int iaxis, int iValue);
    Declare Function ZAux_Direct_SetFwdJog Lib "zauxdll.dll" (ByVal handle As Integer, ByVal iaxis As Integer, ByVal iValue As Integer) As Integer

    '/*************************************************************
    'Description:    //读取正向JOG输入
    'Input:          //卡链接handle  
    'Output:         //
    'Return:         //错误码
    '*************************************************************/
    'int32 __stdcall ZAux_Direct_GetFwdJog(ZMC_HANDLE handle, int iaxis, int *piValue);
    Declare Function ZAux_Direct_GetFwdJog Lib "zauxdll.dll" (ByVal handle As Integer, ByVal iaxis As Integer, ByRef piValue As Integer) As Integer

    '/*************************************************************
    'Description:    //读取轴是否运动结束
    'Input:          //卡链接handle  
    'Output:         //
    'Return:         //错误码
    '*************************************************************/
    'int32 __stdcall ZAux_Direct_GetIfIdle(ZMC_HANDLE handle, int iaxis, int *piValue);
    Declare Function ZAux_Direct_GetIfIdle Lib "zauxdll.dll" (ByVal handle As Integer, ByVal iaxis As Integer, ByRef piValue As Integer) As Integer

    '/*************************************************************
    'Description:    //设置脉冲输出模式
    'Input:          //卡链接handle  
    'Output:         //
    'Return:         //错误码
    '*************************************************************/
    'int32 __stdcall ZAux_Direct_SetInvertStep(ZMC_HANDLE handle, int iaxis, int iValue);
    Declare Function ZAux_Direct_SetInvertStep Lib "zauxdll.dll" (ByVal handle As Integer, ByVal iaxis As Integer, ByVal iValue As Integer) As Integer

    '/*************************************************************
    'Description:    //读取脉冲输出模式
    'Input:          //卡链接handle  
    'Output:         //
    'Return:         //错误码
    '*************************************************************/
    'int32 __stdcall ZAux_Direct_GetInvertStep(ZMC_HANDLE handle, int iaxis, int *piValue);
    Declare Function ZAux_Direct_GetInvertStep Lib "zauxdll.dll" (ByVal handle As Integer, ByVal iaxis As Integer, ByRef piValue As Integer) As Integer

    '/*************************************************************
    'Description:    //设置插补时轴是否参与速度计算，缺省参与（1）。此参数只对直线和螺旋的第三个轴起作用
    'Input:          //卡链接handle  
    'Output:         //
    'Return:         //错误码
    '*************************************************************/
    'int32 __stdcall ZAux_Direct_SetInterpFactor(ZMC_HANDLE handle, int iaxis, int iValue);
    Declare Function ZAux_Direct_SetInterpFactor Lib "zauxdll.dll" (ByVal handle As Integer, ByVal iaxis As Integer, ByVal iValue As Integer) As Integer

    '/*************************************************************
    'Description:    //读取插补时轴是否参与速度计算，缺省参与（1）。此参数只对直线和螺旋的第三个轴起作用
    'Input:          //卡链接handle  
    'Output:         //
    'Return:         //错误码
    '*************************************************************/
    'int32 __stdcall ZAux_Direct_GetInterpFactor(ZMC_HANDLE handle, int iaxis, int *piValue);
    Declare Function ZAux_Direct_GetInterpFactor Lib "zauxdll.dll" (ByVal handle As Integer, ByVal iaxis As Integer, ByRef piValue As Integer) As Integer

    '/*************************************************************
    'Description:    //设置JOG时速度
    'Input:          //卡链接handle  
    'Output:         //
    'Return:         //错误码
    '*************************************************************/
    'int32 __stdcall ZAux_Direct_SetJogSpeed(ZMC_HANDLE handle, int iaxis, float fValue);
    Declare Function ZAux_Direct_SetJogSpeed Lib "zauxdll.dll" (ByVal handle As Integer, ByVal iaxis As Integer, ByVal fValue As Single) As Integer

    '/*************************************************************
    'Description:    //读取JOG时速度
    'Input:          //卡链接handle  
    'Output:         //
    'Return:         //错误码
    '*************************************************************/
    'int32 __stdcall ZAux_Direct_GetJogSpeed(ZMC_HANDLE handle, int iaxis, float *pfValue);
    Declare Function ZAux_Direct_GetJogSpeed Lib "zauxdll.dll" (ByVal handle As Integer, ByVal iaxis As Integer, ByRef pfValue As Single) As Integer

    '/*************************************************************
    'Description:    //读取当前链接运动的参考轴号
    'Input:          //卡链接handle  
    'Output:         //
    'Return:         //错误码
    '*************************************************************/
    'int32 __stdcall ZAux_Direct_GetLinkax(ZMC_HANDLE handle, int iaxis, int *piValue);
    Declare Function ZAux_Direct_GetLinkax Lib "zauxdll.dll" (ByVal handle As Integer, ByVal iaxis As Integer, ByRef piValue As Integer) As Integer

    '/*************************************************************
    'Description:    //读取当前除了当前运动是否还有缓冲
    'Input:          //卡链接handle  
    'Output:         //
    'Return:         //错误码
    '*************************************************************/
    'int32 __stdcall ZAux_Direct_GetLoaded(ZMC_HANDLE handle, int iaxis, int *piValue);
    Declare Function ZAux_Direct_GetLoaded Lib "zauxdll.dll" (ByVal handle As Integer, ByVal iaxis As Integer, ByRef piValue As Integer) As Integer

    '/*************************************************************
    'Description:    //设置轴起始速度
    'Input:          //卡链接handle  
    'Output:         //
    'Return:         //错误码
    '*************************************************************/
    'int32 __stdcall ZAux_Direct_SetLspeed(ZMC_HANDLE handle, int iaxis, float fValue);
    Declare Function ZAux_Direct_SetLspeed Lib "zauxdll.dll" (ByVal handle As Integer, ByVal iaxis As Integer, ByVal fValue As Single) As Integer

    '/*************************************************************
    'Description:    //读取轴起始速度
    'Input:          //卡链接handle  
    'Output:         //
    'Return:         //错误码
    '*************************************************************/
    'int32 __stdcall ZAux_Direct_GetLspeed(ZMC_HANDLE handle, int iaxis, float *pfValue);
    Declare Function ZAux_Direct_GetLspeed Lib "zauxdll.dll" (ByVal handle As Integer, ByVal iaxis As Integer, ByRef pfValue As Single) As Integer

    '/*************************************************************
    'Description:    //设置回零反找等待时间
    'Input:          //卡链接handle  
    'Output:         //
    'Return:         //错误码
    '*************************************************************/
    'int32 __stdcall ZAux_Direct_SetHomeWait(ZMC_HANDLE handle, int iaxis, float fValue);
    Declare Function ZAux_Direct_SetHomeWait Lib "zauxdll.dll" (ByVal handle As Integer, ByVal iaxis As Integer, ByVal fValue As Single) As Integer

    '/*************************************************************
    'Description:    //读取回零反找等待时间
    'Input:          //卡链接handle  
    'Output:         //
    'Return:         //错误码
    '*************************************************************/
    'int32 __stdcall ZAux_Direct_GetHomeWait(ZMC_HANDLE handle, int iaxis, float *pfValue);
    Declare Function ZAux_Direct_GetHomeWait Lib "zauxdll.dll" (ByVal handle As Integer, ByVal iaxis As Integer, ByRef pfValue As Single) As Integer


    '/*************************************************************
    'Description:    //读取编码器锁存示教返回状态
    'Input:          //卡链接handle  
    'Output:         //
    'Return:         //错误码
    '*************************************************************/
    'int32 __stdcall ZAux_Direct_GetMark(ZMC_HANDLE handle, int iaxis, int *piValue);
    Declare Function ZAux_Direct_GetMark Lib "zauxdll.dll" (ByVal handle As Integer, ByVal iaxis As Integer, ByRef piValue As Integer) As Integer

    '/*************************************************************
    'Description:    //读取编码器锁存示教返回状态
    'Input:          //卡链接handle  
    'Output:         //
    'Return:         //错误码
    '*************************************************************/
    'int32 __stdcall ZAux_Direct_GetMarkB(ZMC_HANDLE handle, int iaxis, int *piValue);
    Declare Function ZAux_Direct_GetMarkB Lib "zauxdll.dll" (ByVal handle As Integer, ByVal iaxis As Integer, ByRef piValue As Integer) As Integer

    '/*************************************************************
    'Description:    //设置脉冲输出最高频率
    'Input:          //卡链接handle  
    'Output:         //'
    'Return:         //错误码
    '*************************************************************/
    'int32 __stdcall ZAux_Direct_SetMaxSpeed(ZMC_HANDLE handle, int iaxis, int iValue);
    Declare Function ZAux_Direct_SetMaxSpeed Lib "zauxdll.dll" (ByVal handle As Integer, ByVal iaxis As Integer, ByVal iValue As Integer) As Integer

    '/*************************************************************
    'Description:    //读取脉冲输出最高频率
    'Input:          //卡链接handle  
    'Output:         //
    'Return:         //错误码
    '*************************************************************/
    'int32 __stdcall ZAux_Direct_GetMaxSpeed(ZMC_HANDLE handle, int iaxis, int *piValue);
    Declare Function ZAux_Direct_GetMaxSpeed Lib "zauxdll.dll" (ByVal handle As Integer, ByVal iaxis As Integer, ByRef piValue As Integer) As Integer

    '/*************************************************************
    'Description:    //设置连续插补
    'Input:          //卡链接handle  
    'Output:         //
    'Return:         //错误码
    '*************************************************************/
    'int32 __stdcall ZAux_Direct_SetMerge(ZMC_HANDLE handle, int iaxis, int iValue);
    Declare Function ZAux_Direct_SetMerge Lib "zauxdll.dll" (ByVal handle As Integer, ByVal iaxis As Integer, ByVal iValue As Integer) As Integer

    '/*************************************************************
    'Description:    //读取连续插补状态
    'Input:          //卡链接handle  
    'Output:         //
    'Return:         //错误码
    '*************************************************************/
    'int32 __stdcall ZAux_Direct_GetMerge(ZMC_HANDLE handle, int iaxis, int *piValue);
    Declare Function ZAux_Direct_GetMerge Lib "zauxdll.dll" (ByVal handle As Integer, ByVal iaxis As Integer, ByRef piValue As Integer) As Integer

    '/*************************************************************
    ''Description:    //读取当前被缓冲起来的运动个数
    'Input:          //卡链接handle  
    'Output:         //
    'Return:         //错误码
    '*************************************************************/
    'int32 __stdcall ZAux_Direct_GetMovesBuffered(ZMC_HANDLE handle, int iaxis, int *piValue);
    Declare Function ZAux_Direct_GetMovesBuffered Lib "zauxdll.dll" (ByVal handle As Integer, ByVal iaxis As Integer, ByRef piValue As Integer) As Integer

    '/*************************************************************
    'Description:    //读取当前正在运动指令的MOVE_MARK标号
    'Input:          //卡链接handle  
    'Output:         //
    'Return:         //错误码
    '*************************************************************/
    'int32 __stdcall ZAux_Direct_GetMoveCurmark(ZMC_HANDLE handle, int iaxis, int *piValue);
    Declare Function ZAux_Direct_GetMoveCurmark Lib "zauxdll.dll" (ByVal handle As Integer, ByVal iaxis As Integer, ByRef piValue As Integer) As Integer

    '/*************************************************************
    'Description:    //设置运动指令的MOVE_MARK标号
    'Input:          //卡链接handle  
    'Output:         //
    'Return:         //错误码
    '*************************************************************/
    'int32 __stdcall ZAux_Direct_SetMovemark(ZMC_HANDLE handle, int iaxis, int iValue);
    Declare Function ZAux_Direct_SetMovemark Lib "zauxdll.dll" (ByVal handle As Integer, ByVal iaxis As Integer, ByVal iValue As Integer) As Integer

    '/*************************************************************
    'Description:    //设置反馈位置
    'Input:          //卡链接handle  
    'Output:         //
    'Return:         //错误码
    '*************************************************************/
    'int32 __stdcall ZAux_Direct_SetMpos(ZMC_HANDLE handle, int iaxis, float fValue);
    Declare Function ZAux_Direct_SetMpos Lib "zauxdll.dll" (ByVal handle As Integer, ByVal iaxis As Integer, ByVal fValue As Single) As Integer

    '/*************************************************************
    'Description:    //读取反馈位置
    'Input:          //卡链接handle  
    'Output:         //
    'Return:         //错误码
    '*************************************************************/
    'int32 __stdcall ZAux_Direct_GetMpos(ZMC_HANDLE handle, int iaxis, float *pfValue);
    Declare Function ZAux_Direct_GetMpos Lib "zauxdll.dll" (ByVal handle As Integer, ByVal iaxis As Integer, ByRef pfValue As Single) As Integer

    '/*************************************************************
    'Description:    //读取反馈速度
    'Input:          //卡链接handle  
    'Output:         //
    'Return:         //错误码
    '*************************************************************/
    'int32 __stdcall ZAux_Direct_GetMspeed(ZMC_HANDLE handle, int iaxis, float *pfValue);
    Declare Function ZAux_Direct_GetMspeed Lib "zauxdll.dll" (ByVal handle As Integer, ByVal iaxis As Integer, ByRef pfValue As Single) As Integer

    '/*************************************************************
    'Description:    //读取当前正在运动指令类型
    'Input:          //卡链接handle  
    'Output:         //
    'Return:         //错误码
    '*************************************************************/
    'int32 __stdcall ZAux_Direct_GetMtype(ZMC_HANDLE handle, int iaxis, int *piValue);
    Declare Function ZAux_Direct_GetMtype Lib "zauxdll.dll" (ByVal handle As Integer, ByVal iaxis As Integer, ByRef piValue As Integer) As Integer

    '/*************************************************************
    'Description:    //设置修改偏移位置
    'Input:          //卡链接handle  
    'Output:         //
    'Return:         //错误码
    '*************************************************************/
    'int32 __stdcall ZAux_Direct_SetOffpos(ZMC_HANDLE handle, int iaxis, float fValue);
    Declare Function ZAux_Direct_SetOffpos Lib "zauxdll.dll" (ByVal handle As Integer, ByVal iaxis As Integer, ByVal fValue As Single) As Integer

    '/*************************************************************
    'Description:    //读取修改偏移位置
    'Input:          //卡链接handle  
    'Output:         //
    'Return:         //错误码
    '*************************************************************/
    'int32 __stdcall ZAux_Direct_GetOffpos(ZMC_HANDLE handle, int iaxis, float *pfValue);
    Declare Function ZAux_Direct_GetOffpos Lib "zauxdll.dll" (ByVal handle As Integer, ByVal iaxis As Integer, ByRef pfValue As Single) As Integer

    '/*************************************************************
    'Description:    //设置锁存触发的结束坐标范围点。
    'Input:          //卡链接handle  
    'Output:         //
    'Return:         //错误码
    '*************************************************************/
    'int32 __stdcall ZAux_Direct_SetOpenWin(ZMC_HANDLE handle, int iaxis, float fValue);
    Declare Function ZAux_Direct_SetOpenWin Lib "zauxdll.dll" (ByVal handle As Integer, ByVal iaxis As Integer, ByVal fValue As Single) As Integer

    '/*************************************************************
    'Description:    //读取锁存触发的结束坐标范围点。
    'Input:          //卡链接handle  
    'Output:         //
    'Return:         //错误码
    '*************************************************************/
    'int32 __stdcall ZAux_Direct_GetOpenWin(ZMC_HANDLE handle, int iaxis, float *pfValue);
    Declare Function ZAux_Direct_GetOpenWin Lib "zauxdll.dll" (ByVal handle As Integer, ByVal iaxis As Integer, ByRef pfValue As Single) As Integer

    '/*************************************************************
    'Description:    //读取返回锁存的测量反馈位置(MPOS)
    'Input:          //卡链接handle  
    'Output:         //
    'Return:         //错误码
    '*************************************************************/
    'int32 __stdcall ZAux_Direct_GetRegPos(ZMC_HANDLE handle, int iaxis, float *pfValue);
    Declare Function ZAux_Direct_GetRegPos Lib "zauxdll.dll" (ByVal handle As Integer, ByVal iaxis As Integer, ByRef pfValue As Single) As Integer

    '/*************************************************************
    'Description:    //读取返回锁存的测量反馈位置(MPOS)
    'Input:          //卡链接handle  
    'Output:         //
    'Return:         //错误码
    '*************************************************************/
    'int32 __stdcall ZAux_Direct_GetRegPosB(ZMC_HANDLE handle, int iaxis, float *pfValue);
    Declare Function ZAux_Direct_GetRegPosB Lib "zauxdll.dll" (ByVal handle As Integer, ByVal iaxis As Integer, ByRef pfValue As Single) As Integer

    '/*************************************************************
    'Description:    //读取返回轴当前运动还未完成的距离
    'Input:          //卡链接handle  
    'Output:         //
    'Return:         //错误码
    '*************************************************************/
    'int32 __stdcall ZAux_Direct_GetRemain(ZMC_HANDLE handle, int iaxis, float *pfValue);
    Declare Function ZAux_Direct_GetRemain Lib "zauxdll.dll" (ByVal handle As Integer, ByVal iaxis As Integer, ByRef pfValue As Single) As Integer

    '/*************************************************************
    'Description:    //参数  轴剩余的缓冲, 按直线段来计算
    '				  REMAIN_BUFFER为唯一一个可以加AXIS并用ZAux_DirectCommand获取的.
    'Input:          //卡链接handle  
    'Output:         //
    ''Return:         //错误码
    '*************************************************************/
    'int32 __stdcall ZAux_Direct_GetRemain_LineBuffer(ZMC_HANDLE handle, int iaxis,int * piValue);
    Declare Function ZAux_Direct_GetRemain_LineBuffer Lib "zauxdll.dll" (ByVal handle As Integer, ByVal iaxis As Integer, ByRef piValue As Integer) As Integer

    '/*************************************************************
    'Description:    //参数  轴剩余的缓冲, 按最复杂的空间圆弧来计算
    '				  REMAIN_BUFFER为唯一一个可以加AXIS并用ZAux_DirectCommand获取的.
    'Input:          //卡链接handle  
    'Output:         //
    'Return:         //错误码
    '*************************************************************/
    'int32 __stdcall ZAux_Direct_GetRemain_Buffer(ZMC_HANDLE handle, int iaxis, int *piValue);
    Declare Function ZAux_Direct_GetRemain_Buffer Lib "zauxdll.dll" (ByVal handle As Integer, ByVal iaxis As Integer, ByRef piValue As Integer) As Integer

    '/*************************************************************
    'Description:    //设置根据REP_OPTION设置来自动循环轴DPOS和MPOS坐标。
    'Input:          //卡链接handle  
    'Output:         //
    'Return:         //错误码
    '*************************************************************/
    'int32 __stdcall ZAux_Direct_SetRepDist(ZMC_HANDLE handle, int iaxis, float fValue);
    Declare Function ZAux_Direct_SetRepDist Lib "zauxdll.dll" (ByVal handle As Integer, ByVal iaxis As Integer, ByVal fValue As Single) As Integer

    '/*************************************************************
    'Description:    //读取根据REP_OPTION设置来自动循环轴DPOS和MPOS坐标。
    'Input:          //卡链接handle  
    'Output:         //
    'Return:         //错误码
    '*************************************************************/
    'int32 __stdcall ZAux_Direct_GetOpenRepDist(ZMC_HANDLE handle, int iaxis, float *pfValue);
    Declare Function ZAux_Direct_GetOpenRepDist Lib "zauxdll.dll" (ByVal handle As Integer, ByVal iaxis As Integer, ByRef pfValue As Single) As Integer

    '/*************************************************************
    'Description:    //设置坐标重复设置
    'Input:          //卡链接handle  
    'Output:         //
    'Return:         //错误码
    '*************************************************************/
    'int32 __stdcall ZAux_Direct_SetRepOption(ZMC_HANDLE handle, int iaxis, int iValue);
    Declare Function ZAux_Direct_SetRepOption Lib "zauxdll.dll" (ByVal handle As Integer, ByVal iaxis As Integer, ByVal iValue As Integer) As Integer

    '/*************************************************************
    'Description:    //读取坐标重复设置
    'Input:          //卡链接handle  
    'Output:         //
    'Return:         //错误码
    '*************************************************************/
    'int32 __stdcall ZAux_Direct_GetRepOption(ZMC_HANDLE handle, int iaxis, int *piValue);
    Declare Function ZAux_Direct_GetRepOption Lib "zauxdll.dll" (ByVal handle As Integer, ByVal iaxis As Integer, ByRef piValue As Integer) As Integer

    '/*************************************************************
    'Description:    //设置负向硬件限位开关对应的输入点编号，-1无效。
    'Input:          //卡链接handle  
    'Output:         //
    'Return:         //错误码
    '*************************************************************/
    'int32 __stdcall ZAux_Direct_SetRevIn(ZMC_HANDLE handle, int iaxis, int iValue);
    Declare Function ZAux_Direct_SetRevIn Lib "zauxdll.dll" (ByVal handle As Integer, ByVal iaxis As Integer, ByVal iValue As Integer) As Integer

    '/*************************************************************
    'Description:    //读取负向硬件限位开关对应的输入点编号，-1无效。
    'Input:          //卡链接handle  
    'Output:         //
    'Return:         //错误码
    '*************************************************************/
    'int32 __stdcall ZAux_Direct_GetRevIn(ZMC_HANDLE handle, int iaxis, int *piValue);
    Declare Function ZAux_Direct_GetRevIn Lib "zauxdll.dll" (ByVal handle As Integer, ByVal iaxis As Integer, ByRef piValue As Integer) As Integer

    '/*************************************************************
    'Description:    //设置负向JOG输入对应的输入点编号，-1无效。
    'Input:          //卡链接handle  
    'Output:         //
    'Return:         //错误码
    '*************************************************************/
    'int32 __stdcall ZAux_Direct_SetRevJog(ZMC_HANDLE handle, int iaxis, int iValue);
    Declare Function ZAux_Direct_SetRevJog Lib "zauxdll.dll" (ByVal handle As Integer, ByVal iaxis As Integer, ByVal iValue As Integer) As Integer

    '/*************************************************************
    'Description:    //读取负向JOG输入对应的输入点编号，-1无效。
    'Input:          //卡链接handle  
    'Output:         //
    'Return:         //错误码
    '*************************************************************/
    'int32 __stdcall ZAux_Direct_GetRevJog(ZMC_HANDLE handle, int iaxis, int *piValue);
    Declare Function ZAux_Direct_GetRevJog Lib "zauxdll.dll" (ByVal handle As Integer, ByVal iaxis As Integer, ByRef piValue As Integer) As Integer

    '/*************************************************************
    'Description:    //设置负向软限位位置。
    'Input:          //卡链接handle  
    'Output:         //
    'Return:         //错误码
    '*************************************************************/
    'int32 __stdcall ZAux_Direct_SetRsLimit(ZMC_HANDLE handle, int iaxis, float fValue);
    Declare Function ZAux_Direct_SetRsLimit Lib "zauxdll.dll" (ByVal handle As Integer, ByVal iaxis As Integer, ByVal fValue As Single) As Integer

    '/*************************************************************
    'Description:    //读取负向软限位位置。
    'Input:          //卡链接handle  
    'Output:         //
    'Return:         //错误码
    '*************************************************************/
    'int32 __stdcall ZAux_Direct_GetRsLimit(ZMC_HANDLE handle, int iaxis, float *pfValue);
    Declare Function ZAux_Direct_GetRsLimit Lib "zauxdll.dll" (ByVal handle As Integer, ByVal iaxis As Integer, ByRef pfValue As Single) As Integer

    '/*************************************************************
    'Description:    //设置轴速度，单位为units/s，当多轴运动时，作为插补运动的速度
    'Input:          //卡链接handle  
    'Output:         //'
    'Return:         //错误码
    '*************************************************************/
    'int32 __stdcall ZAux_Direct_SetSpeed(ZMC_HANDLE handle, int iaxis, float fValue);
    Declare Function ZAux_Direct_SetSpeed Lib "zauxdll.dll" (ByVal handle As Integer, ByVal iaxis As Integer, ByVal fValue As Single) As Integer

    '/*************************************************************
    'Description:    //读取轴速度，单位为units/s，当多轴运动时，作为插补运动的速度
    'Input:          //卡链接handle  
    'Output:         //
    'Return:         //错误码
    '*************************************************************/
    'int32 __stdcall ZAux_Direct_GetSpeed(ZMC_HANDLE handle, int iaxis, float *pfValue);
    Declare Function ZAux_Direct_GetSpeed Lib "zauxdll.dll" (ByVal handle As Integer, ByVal iaxis As Integer, ByRef pfValue As Single) As Integer

    '/*************************************************************
    'Description:    //设置 S曲线设置。
    'Input:          //卡链接handle  
    'Output:         //
    'Return:         //错误码
    '*************************************************************/
    'int32 __stdcall ZAux_Direct_SetSramp(ZMC_HANDLE handle, int iaxis, float fValue);
    Declare Function ZAux_Direct_SetSramp Lib "zauxdll.dll" (ByVal handle As Integer, ByVal iaxis As Integer, ByVal fValue As Single) As Integer

    '/*************************************************************
    'Description:    //读取 S曲线设置。
    'Input:          //卡链接handle  
    'Output:         //
    'Return:         //错误码
    '*************************************************************/
    'int32 __stdcall ZAux_Direct_GetSramp(ZMC_HANDLE handle, int iaxis, float *pfValue);
    Declare Function ZAux_Direct_GetSramp Lib "zauxdll.dll" (ByVal handle As Integer, ByVal iaxis As Integer, ByRef pfValue As Single) As Integer

    '/*************************************************************
    'Description:    //设置 自定义速度的SP运动的起始速度
    'Input:          //卡链接handle  
    'Output:         //
    'Return:         //错误码
    '*************************************************************/
    'int32 __stdcall ZAux_Direct_SetStartMoveSpeed(ZMC_HANDLE handle, int iaxis, float fValue);
    Declare Function ZAux_Direct_SetStartMoveSpeed Lib "zauxdll.dll" (ByVal handle As Integer, ByVal iaxis As Integer, ByVal fValue As Single) As Integer

    '/*************************************************************
    'Description:    //读取自定义速度的SP运动的起始速度
    'Input:          //卡链接handle  
    'Output:         //
    'Return:         //错误码
    '*************************************************************/
    'int32 __stdcall ZAux_Direct_GetStartMoveSpeed(ZMC_HANDLE handle, int iaxis, float *pfValue);
    Declare Function ZAux_Direct_GetStartMoveSpeed Lib "zauxdll.dll" (ByVal handle As Integer, ByVal iaxis As Integer, ByRef pfValue As Single) As Integer

    '/*************************************************************
    'Description:    //设置 减速到最低的最小拐角
    'Input:          //卡链接handle  '
    'Output:         //
    'Return:         //错误码
    '*************************************************************/
    'int32 __stdcall ZAux_Direct_SetStopAngle(ZMC_HANDLE handle, int iaxis, float fValue);
    Declare Function ZAux_Direct_SetStopAngle Lib "zauxdll.dll" (ByVal handle As Integer, ByVal iaxis As Integer, ByVal fValue As Single) As Integer

    '/*************************************************************
    'Description:    //读取减速到最低的最小拐角
    'Input:          //卡链接handle  
    'Output:         //
    'Return:         //错误码
    '*************************************************************/
    'int32 __stdcall ZAux_Direct_GetStopAngle(ZMC_HANDLE handle, int iaxis, float *pfValue);
    Declare Function ZAux_Direct_GetStopAngle Lib "zauxdll.dll" (ByVal handle As Integer, ByVal iaxis As Integer, ByRef pfValue As Single) As Integer

    '/*************************************************************
    'Description:    //设置 脉冲当量
    'Input:          //卡链接handle  
    'Output:         //
    'Return:         //错误码
    '*************************************************************/
    'int32 __stdcall ZAux_Direct_SetUnits(ZMC_HANDLE handle, int iaxis, float fValue);
    Declare Function ZAux_Direct_SetUnits Lib "zauxdll.dll" (ByVal handle As Integer, ByVal iaxis As Integer, ByVal fValue As Single) As Integer

    '/*************************************************************
    'Description:    //读取脉冲当量
    'Input:          //卡链接handle  
    'Output:         //
    'Return:         //错误码
    '*************************************************************/
    'int32 __stdcall ZAux_Direct_GetUnits(ZMC_HANDLE handle, int iaxis, float *pfValue);
    Declare Function ZAux_Direct_GetUnits Lib "zauxdll.dll" (ByVal handle As Integer, ByVal iaxis As Integer, ByRef pfValue As Single) As Integer

    '/*************************************************************
    'Description:    //读取返回轴当前当前运动和缓冲运动还未完成的距离
    'Input:          //卡链接handle  
    'Output:         //
    'Return:         //错误码
    '*************************************************************/
    'int32 __stdcall ZAux_Direct_GetVectorBuffered(ZMC_HANDLE handle, int iaxis, float *pfValue);
    Declare Function ZAux_Direct_GetVectorBuffered Lib "zauxdll.dll" (ByVal handle As Integer, ByVal iaxis As Integer, ByRef pfValue As Single) As Integer

    '/*************************************************************
    'Description:    //参数
    'Input:          //卡链接handle  
    'Output:         //
    'Return:         //错误码
    '*************************************************************/
    'int32 __stdcall ZAux_Direct_GetVpSpeed(ZMC_HANDLE handle, int iaxis, float *pfValue);
    Declare Function ZAux_Direct_GetVpSpeed Lib "zauxdll.dll" (ByVal handle As Integer, ByVal iaxis As Integer, ByRef pfValue As Single) As Integer



    '/*************************************************************
    'Description:    //全局变量读取, 也可以是参数等等
    'Input:          //卡链接handle  
    'Output:         //
    'Return:         //错误码
    '*************************************************************/
    'int32 __stdcall ZAux_Direct_GetVariablef(ZMC_HANDLE handle, const char *pname, float *pfValue);
    Declare Function ZAux_Direct_GetVariablef Lib "zauxdll.dll" (ByVal handle As Integer, ByVal pname As String, ByRef pfValue As Single) As Integer

    '/*************************************************************
    'Description:    //全局变量读取, 也可以是参数等等
    'Input:          //卡链接handle  
    'Output:         //
    'Return:         //错误码
    '*************************************************************/
    ''int32 __stdcall ZAux_Direct_GetVariableInt(ZMC_HANDLE handle, const char *pname, int *piValue);
    Declare Function ZAux_Direct_GetVariableInt Lib "zauxdll.dll" (ByVal handle As Integer, ByVal pname As String, ByRef piValue As Integer) As Integer

    '///////////////////////  只有下面的运动函数支持直接调用，并不是所有的指令都支持
    '///////////////////////  必须 20130901 以后的控制器版本支持

    '/*************************************************************
    'Description:    //BASE指令调用
    '
    '仅仅修改在线命令的BASE列表，不对控制器的运行任务的BASE进行修改.
    '修改后，后续的所有MOVE等指令都是以这个BASE为基础
    ''
    'Input:          //卡链接handle
    'Output:         //
    'Return:         //错误码
    '*************************************************************/
    'int32 __stdcall ZAux_Direct_Base(ZMC_HANDLE handle, int imaxaxises, int *piAxislist);
    Declare Function ZAux_Direct_Base Lib "zauxdll.dll" (ByVal handle As Integer, ByVal imaxaxises As Integer, ByRef piAxislist As Integer) As Integer

    '/*************************************************************
    'Description:    //定义DPOS'
    'Input:          //卡链接handle
    'Output:         //
    'Return:         //错误码
    '*************************************************************/
    'int32 __stdcall ZAux_Direct_Defpos(ZMC_HANDLE handle, int imaxaxises, float *pfDposlist);
    Declare Function ZAux_Direct_Defpos Lib "zauxdll.dll" (ByVal handle As Integer, ByVal imaxaxises As Integer, ByRef pfDposlist As Single) As Integer

    '/*************************************************************'
    'Description:    //相对插补 直接调用运动函数 20130901 以后的控制器版本支持
    'Input:          //卡链接handle
    'Output:         //
    'Return:         //错误码
    '*************************************************************/
    'int32 __stdcall ZAux_Direct_Move(ZMC_HANDLE handle, int imaxaxises, float *pfDisancelist);
    Declare Function ZAux_Direct_Move Lib "zauxdll.dll" (ByVal handle As Integer, ByVal imaxaxises As Integer, ByRef pfDposlist As Single) As Integer

    '/*************************************************************
    'Description:    //相对插补 直接调用运动函数 20130901 以后的控制器版本支持
    'Input:          //卡链接handle
    'Output:         //
    'Return:         //错误码
    '*************************************************************/
    'int32 __stdcall ZAux_Direct_MoveSp(ZMC_HANDLE handle, int imaxaxises, float *pfDisancelist);
    Declare Function ZAux_Direct_MoveSp Lib "zauxdll.dll" (ByVal handle As Integer, ByVal imaxaxises As Integer, ByRef pfDposlist As Single) As Integer


    '/*************************************************************
    'Description:    //插补 直接调用运动函数 20130901 以后的控制器版本支持
    'Input:          //卡链接handle
    'Output:         //
    'Return:         //错误码
    '*************************************************************/
    'int32 __stdcall ZAux_Direct_MoveAbs(ZMC_HANDLE handle, int imaxaxises, float *pfDisancelist);
    Declare Function ZAux_Direct_MoveAbs Lib "zauxdll.dll" (ByVal handle As Integer, ByVal imaxaxises As Integer, ByRef pfDposlist As Single) As Integer

    '/*************************************************************
    'Description:    //插补 BASE后立刻调用运动函数.
    'Input:          //卡链接handle'
    'Output:         //
    'Return:         //错误码
    '*************************************************************/
    'int32 __stdcall ZAux_Direct_BaseAndMoveAbs(ZMC_HANDLE handle, int imaxaxises, int *piAxislist, float *pfDisancelist);
    Declare Function ZAux_Direct_BaseAndMoveAbs Lib "zauxdll.dll" (ByVal handle As Integer, ByVal imaxaxises As Integer, ByRef piAxislist As Integer, ByRef pfDposlist As Single) As Integer

    '/*************************************************************
    'Description:    //插补 直接调用运动函数 20130901 以后的控制器版本支持
    'Input:          //卡链接handle
    'Output:         //
    ''Return:         //错误码
    '*************************************************************/
    'int32 __stdcall ZAux_Direct_MoveAbsSp(ZMC_HANDLE handle, int imaxaxises, float *pfDisancelist);
    Declare Function ZAux_Direct_MoveAbsSp Lib "zauxdll.dll" (ByVal handle As Integer, ByVal imaxaxises As Integer, ByRef pfDposlist As Single) As Integer


    '/*************************************************************
    'Description:    //插补 直接调用运动函数 20130901 以后的控制器版本支持
    'Input:          //卡链接handle
    'Output:         //
    'Return:         //错误码
    '*************************************************************/
    'int32 __stdcall ZAux_Direct_MoveModify(ZMC_HANDLE handle, int imaxaxises, float *pfDisancelist);
    Declare Function ZAux_Direct_MoveModify Lib "zauxdll.dll" (ByVal handle As Integer, ByVal imaxaxises As Integer, ByRef pfDposlist As Single) As Integer


    '/*************************************************************
    'Description:    //插补 直接调用运动函数 20130901 以后的控制器版本支持
    'Input:          //卡链接handle
    '
    'end1              第一个轴运动坐标
    'end2              第二个轴运动坐标
    'centre1    第一个轴运动圆心，相对与起始点。
    'centre2    第二个轴运动圆心，相对与起始点。
    'direction  0-逆时针，1-顺时针
    '
    'Output:         //
    'Return:         //错误码
    ''*************************************************************/
    'int32 __stdcall ZAux_Direct_MoveCirc(ZMC_HANDLE handle, float fend1, float fend2, float fcenter1, float fcenter2, int idirection);
    Declare Function ZAux_Direct_MoveCirc Lib "zauxdll.dll" (ByVal handle As Integer, ByVal fend1 As Single, ByVal fend2 As Single, ByVal fcenter1 As Single, ByVal fcenter2 As Single, ByVal idirection As Integer) As Integer

    '/*************************************************************
    'Description:    //插补 直接调用运动函数 20130901 以后的控制器版本支持
    'Input:          //卡链接handle
    '
    'end1              第一个轴运动坐标
    'end2              第二个轴运动坐标
    'centre1    第一个轴运动圆心，相对与起始点。
    'centre2    第二个轴运动圆心，相对与起始点。
    'direction  0-逆时针，1-顺时针
    '
    'Output:         //
    'Return:         //错误码
    '*************************************************************/
    'int32 __stdcall ZAux_Direct_MoveCircSp(ZMC_HANDLE handle, float fend1, float fend2, float fcenter1, float fcenter2, int idirection);
    Declare Function ZAux_Direct_MoveCircSp Lib "zauxdll.dll" (ByVal handle As Integer, ByVal fend1 As Single, ByVal fend2 As Single, ByVal fcenter1 As Single, ByVal fcenter2 As Single, ByVal idirection As Integer) As Integer

    '/*************************************************************
    'Description:    //插补 直接调用运动函数 20130901 以后的控制器版本支持
    'Input:          //卡链接handle
    '
    'end1              第一个轴运动坐标，绝对位置
    'end2              第二个轴运动坐标，绝对位置
    'centre1    第一个轴运动圆心，绝对位置
    'centre2    第二个轴运动圆心，绝对位置
    'direction  0-逆时针，1-顺时针
    '
    'Output:         //
    'Return:         //错误码
    '*************************************************************/
    'int32 __stdcall ZAux_Direct_MoveCircAbs(ZMC_HANDLE handle, float fend1, float fend2, float fcenter1, float fcenter2, int idirection);
    Declare Function ZAux_Direct_MoveCircAbs Lib "zauxdll.dll" (ByVal handle As Integer, ByVal fend1 As Single, ByVal fend2 As Single, ByVal fcenter1 As Single, ByVal fcenter2 As Single, ByVal idirection As Integer) As Integer

    '/*************************************************************
    'Description:    //插补 直接调用运动函数 20130901 以后的控制器版本支持
    'Input:          //卡链接handle
    '
    'end1              第一个轴运动坐标，绝对位置
    'end2              第二个轴运动坐标，绝对位置
    'centre1    第一个轴运动圆心，绝对位置
    'centre2    第二个轴运动圆心，绝对位置
    'direction  0-逆时针，1-顺时针
    '
    'Output:         //
    'Return:         //错误码
    '*************************************************************/
    'int32 __stdcall ZAux_Direct_MoveCircAbsSp(ZMC_HANDLE handle, float fend1, float fend2, float fcenter1, float fcenter2, int idirection);
    Declare Function ZAux_Direct_MoveCircAbsSp Lib "zauxdll.dll" (ByVal handle As Integer, ByVal fend1 As Single, ByVal fend2 As Single, ByVal fcenter1 As Single, ByVal fcenter2 As Single, ByVal idirection As Integer) As Integer



    '/*************************************************************
    'Description:    //插补 直接调用运动函数 20130901 以后的控制器版本支持
    'Input:          //卡链接handle
    '
    'mid1       第一个轴中间点，相对起始点距离
    'mid2       第二个轴中间点，相对起始点距离
    'end1              第一个轴结束点，相对起始点距离
    'end2              第二个轴结束点，相对起始点距离
    ''
    'Output:         //
    'Return:         //错误码
    '*************************************************************/
    'int32 __stdcall ZAux_Direct_MoveCirc2(ZMC_HANDLE handle, float fmid1, float fmid2, float fend1, float fend2);
    Declare Function ZAux_Direct_MoveCirc2 Lib "zauxdll.dll" (ByVal handle As Integer, ByVal fmid1 As Single, ByVal fmid2 As Single, ByVal fend1 As Single, ByVal fend2 As Single) As Integer


    '/*************************************************************
    'Description:    //插补 直接调用运动函数 20130901 以后的控制器版本支持
    'Input:          //卡链接handle
    '
    'mid1       第一个轴中间点，绝对位置
    'mid2       第二个轴中间点，绝对位置
    'end1              第一个轴结束点，绝对位置
    'end2              第二个轴结束点，绝对位置
    '
    'Output:         //
    ''Return:         //错误码
    '*************************************************************/
    'int32 __stdcall ZAux_Direct_MoveCirc2Abs(ZMC_HANDLE handle, float fmid1, float fmid2, float fend1, float fend2);
    Declare Function ZAux_Direct_MoveCirc2Abs Lib "zauxdll.dll" (ByVal handle As Integer, ByVal fmid1 As Single, ByVal fmid2 As Single, ByVal fend1 As Single, ByVal fend2 As Single) As Integer

    '/*************************************************************
    'Description:    //插补 直接调用运动函数 20130901 以后的控制器版本支持
    'Input:          //卡链接handle
    '
    'mid1       第一个轴中间点，相对起始点距离
    'mid2       第二个轴中间点，相对起始点距离
    'end1              第一个轴结束点，相对起始点距离
    'end2              第二个轴结束点，相对起始点距离
    '
    'Output:         //
    'Return:         //错误码
    '*************************************************************/
    'int32 __stdcall ZAux_Direct_MoveCirc2Sp(ZMC_HANDLE handle, float fmid1, float fmid2, float fend1, float fend2);
    Declare Function ZAux_Direct_MoveCirc2Sp Lib "zauxdll.dll" (ByVal handle As Integer, ByVal fmid1 As Single, ByVal fmid2 As Single, ByVal fend1 As Single, ByVal fend2 As Single) As Integer


    '/*************************************************************
    'Description:    //插补 直接调用运动函数 20130901 以后的控制器版本支持'
    'Input:          //卡链接handle'
    '
    'mid1       第一个轴中间点，绝对位置
    'mid2       第二个轴中间点，绝对位置
    'end1              第一个轴结束点，绝对位置
    'end2              第二个轴结束点，绝对位置
    '
    'Output:         //
    'Return:         //错误码
    '*'************************************************************/
    'int32 __stdcall ZAux_Direct_MoveCirc2AbsSp(ZMC_HANDLE handle, float fmid1, float fmid2, float fend1, float fend2);
    Declare Function ZAux_Direct_MoveCirc2AbsSp Lib "zauxdll.dll" (ByVal handle As Integer, ByVal fmid1 As Single, ByVal fmid2 As Single, ByVal fend1 As Single, ByVal fend2 As Single) As Integer



    '/*************************************************************
    'Description:    //插补
    'Input:          //卡链接handle
    '
    'end1              第一个轴运动坐标
    '
    'end2              第二个轴运动坐标
    '
    'centre1    第一个轴运动圆心，相对与起始点
    '
    ''centre2    第二个轴运动圆心，相对与起始点
    '
    'direction  0-逆时针，1-顺时针
    '
    'distance3第三个轴运动距离。
    '
    'mode      第三轴的速度计算:
    '0(缺省)
    ' 第三轴参与速度计算。
    '1
    ' 第三轴不参与速度计算。
    '
    '
    'Output:         //
    'Return:         //错误码
    '*************************************************************/
    'int32 __stdcall ZAux_Direct_MHelical(ZMC_HANDLE handle, float fend1, float fend2, float fcenter1, float fcenter2, int idirection, float fDistance3, int imode);
    Declare Function ZAux_Direct_MHelical Lib "zauxdll.dll" (ByVal handle As Integer, ByVal fend1 As Single, ByVal fend2 As Single, ByVal fcenter1 As Single, ByVal fcenter2 As Single, ByVal idirection As Integer, ByVal fDistance3 As Single, ByVal imode As Integer) As Integer

    '/*************************************************************
    'Description:    //插补
    'Input:          //卡链接handle
    '
    'end1              第一个轴运动坐标
    '
    'end2              第二个轴运动坐标
    '
    'centre1    第一个轴运动圆心，相对与起始点
    '
    'centre2    第二个轴运动圆心，相对与起始点
    ''
    'direction  0-逆时针，1-顺时针
    '
    'distance3第三个轴运动距离。
    '
    'mode      第三轴的速度计算:
    '0(缺省)
    '' 第三轴参与速度计算。
    '1
    '第三轴不参与速度计算。
    '
    '
    'Output:         //
    'Return:         //错误码
    '*************************************************************/
    'int32 __stdcall ZAux_Direct_MHelicalAbs(ZMC_HANDLE handle, float fend1, float fend2, float fcenter1, float fcenter2, int idirection, float fDistance3, int imode);
    Declare Function ZAux_Direct_MHelicalAbs Lib "zauxdll.dll" (ByVal handle As Integer, ByVal fend1 As Single, ByVal fend2 As Single, ByVal fcenter1 As Single, ByVal fcenter2 As Single, ByVal idirection As Integer, ByVal fDistance3 As Single, ByVal imode As Integer) As Integer

    '/*************************************************************
    'Description:    //插补
    'Input:          //卡链接handle
    '
    'end1              第一个轴运动坐标
    '
    'end2              第二个轴运动坐标
    '
    'centre1    第一个轴运动圆心，相对与起始点
    '
    'centre2    第二个轴运动圆心，相对与起始点
    '
    'direction  0-逆时针，1-顺时针
    ''
    'distance3第三个轴运动距离。
    '
    'mode      第三轴的速度计算:
    '0(缺省)
    ' 第三轴参与速度计算。
    '1
    ' 第三轴不参与速度计算。
    '
    '
    'Output:         //
    'Return:         //错误码
    '*************************************************************/
    'int32 __stdcall ZAux_Direct_MHelicalSp(ZMC_HANDLE handle, float fend1, float fend2, float fcenter1, float fcenter2, int idirection, float fDistance3, int imode);
    Declare Function ZAux_Direct_MHelicalSp Lib "zauxdll.dll" (ByVal handle As Integer, ByVal fend1 As Single, ByVal fend2 As Single, ByVal fcenter1 As Single, ByVal fcenter2 As Single, ByVal idirection As Integer, ByVal fDistance3 As Single, ByVal imode As Integer) As Integer

    '/*************************************************************
    'Description:    //插补
    'Input:          //卡链接handle
    '
    'end1              第一个轴运动坐标
    '
    'end2              第二个轴运动坐标
    '
    'centre1    第一个轴运动圆心，相对与起始点
    '
    'centre2    第二个轴运动圆心，相对与起始点
    '
    'direction  0-逆时针，1-顺时针
    '
    'distance3第三个轴运动距离。
    '
    'mode      第三轴的速度计算:
    '0(缺省)
    ' 第三轴参与速度计算。
    '1
    ' 第三轴不参与速度计算。
    '
    '
    'Output:         //
    'Return:         //错误码
    '*************************************************************/
    'int32 __stdcall ZAux_Direct_MHelicalAbsSp(ZMC_HANDLE handle, float fend1, float fend2, float fcenter1, float fcenter2, int idirection, float fDistance3, int imode);
    Declare Function ZAux_Direct_MHelicalAbsSp Lib "zauxdll.dll" (ByVal handle As Integer, ByVal fend1 As Single, ByVal fend2 As Single, ByVal fcenter1 As Single, ByVal fcenter2 As Single, ByVal idirection As Integer, ByVal fDistance3 As Single, ByVal imode As Integer) As Integer


    '/*************************************************************
    'Description:    //插补
    'Input:          //卡链接handle
    '
    ''mid1       第一个轴中间点
    '
    'mid2       第二个轴中间点
    '
    'end1              第一个轴结束点
    '
    'end2              第二个轴结束点
    '
    'distance3第三个轴运动距离
    '
    'mode      第三轴的速度计算:
    ''
    'Output:         //
    'Return:         //错误码
    '*************************************************************/
    'int32 __stdcall ZAux_Direct_MHelical2(ZMC_HANDLE handle, float fmid1, float fmid2, float fend1, float fend2, float fDistance3, int imode);
    Declare Function ZAux_Direct_MHelical2 Lib "zauxdll.dll" (ByVal handle As Integer, ByVal fmid1 As Single, ByVal fmid2 As Single, ByVal fend1 As Single, ByVal fend2 As Single, ByVal idirection As Integer, ByVal fDistance3 As Single, ByVal imode As Integer) As Integer

    '/*************************************************************
    'Description:    //插补
    'Input:          //卡链接handle
    '
    'mid1       第一个轴中间点
    '
    'mid2       第二个轴中间点
    '
    'end1              第一个轴结束点
    '
    ''end2              第二个轴结束点
    '
    'distance3   第三个轴运动结束点
    '
    'mode      第三轴的速度计算:
    '
    'Output:         //
    'Return:         //错误码
    '*************************************************************/
    'int32 __stdcall ZAux_Direct_MHelical2Abs(ZMC_HANDLE handle, float fmid1, float fmid2, float fend1, float fend2, float fDistance3, int imode);
    Declare Function ZAux_Direct_MHelical2Abs Lib "zauxdll.dll" (ByVal handle As Integer, ByVal fmid1 As Single, ByVal fmid2 As Single, ByVal fend1 As Single, ByVal fend2 As Single, ByVal idirection As Integer, ByVal fDistance3 As Single, ByVal imode As Integer) As Integer

    '/*************************************************************
    'Description:    //插补
    'Input:          //卡链接handle
    '
    'mid1       第一个轴中间点
    '
    'mid2       第二个轴中间点
    '
    'end1              第一个轴结束点
    '
    'end2              第二个轴结束点
    '
    'distance3第三个轴运动距离
    '
    ''mode      第三轴的速度计算:
    '
    'Output:         //
    'Return:         //错误码
    '*************************************************************/
    'int32 __stdcall ZAux_Direct_MHelical2Sp(ZMC_HANDLE handle, float fmid1, float fmid2, float fend1, float fend2, float fDistance3, int imode);
    Declare Function ZAux_Direct_MHelical2Sp Lib "zauxdll.dll" (ByVal handle As Integer, ByVal fmid1 As Single, ByVal fmid2 As Single, ByVal fend1 As Single, ByVal fend2 As Single, ByVal idirection As Integer, ByVal fDistance3 As Single, ByVal imode As Integer) As Integer

    '/*************************************************************
    'Description:    //插补
    'Input:          //卡链接handle
    '
    'mid1       第一个轴中间点
    '
    'mid2       第二个轴中间点
    '
    'end1              第一个轴结束点
    '
    ''end2              第二个轴结束点
    '
    'distance3   第三个轴运动结束点

    'mode      第三轴的速度计算:

    'Output:         //
    'Return:         //错误码
    '*************************************************************/
    'int32 __stdcall ZAux_Direct_MHelical2AbsSp(ZMC_HANDLE handle, float fmid1, float fmid2, float fend1, float fend2, float fDistance3, int imode);
    Declare Function ZAux_Direct_MHelical2AbsSp Lib "zauxdll.dll" (ByVal handle As Integer, ByVal fmid1 As Single, ByVal fmid2 As Single, ByVal fend1 As Single, ByVal fend2 As Single, ByVal idirection As Integer, ByVal fDistance3 As Single, ByVal imode As Integer) As Integer



    '/*************************************************************
    'Description:    //插补
    'Input:          //卡链接handle
    '
    'Output:         //
    'Return:         //错误码'
    '*************************************************************/
    'int32 __stdcall ZAux_Direct_MEclipse(ZMC_HANDLE handle, float fend1, float fend2, float fcenter1, float fcenter2, int idirection, float fADis, float fBDis);
    Declare Function ZAux_Direct_MEclipse Lib "zauxdll.dll" (ByVal handle As Integer, ByVal fend1 As Single, ByVal fend2 As Single, ByVal fcenter1 As Single, ByVal fcenter2 As Single, ByVal idirection As Integer, ByVal fADis As Single, ByVal fBDis As Single) As Integer
    '
    '/*************************************************************
    'Description:    //插补
    'Input:          //卡链接handle
    '
    'Output:         //
    'Return:         //错误码
    '*************************************************************/
    'int32 __stdcall ZAux_Direct_MEclipseAbs(ZMC_HANDLE handle, float fend1, float fend2, float fcenter1, float fcenter2, int idirection, float fADis, float fBDis);
    Declare Function ZAux_Direct_MEclipseAbs Lib "zauxdll.dll" (ByVal handle As Integer, ByVal fend1 As Single, ByVal fend2 As Single, ByVal fcenter1 As Single, ByVal fcenter2 As Single, ByVal idirection As Integer, ByVal fADis As Single, ByVal fBDis As Single) As Integer

    '/*************************************************************
    'Description:    //插补
    'Input:          //卡链接handle
    '
    'Output:         //
    'Return:         //错误码
    '*************************************************************/
    'int32 __stdcall ZAux_Direct_MEclipseSp(ZMC_HANDLE handle, float fend1, float fend2, float fcenter1, float fcenter2, int idirection, float fADis, float fBDis);
    Declare Function ZAux_Direct_MEclipseSp Lib "zauxdll.dll" (ByVal handle As Integer, ByVal fend1 As Single, ByVal fend2 As Single, ByVal fcenter1 As Single, ByVal fcenter2 As Single, ByVal idirection As Integer, ByVal fADis As Single, ByVal fBDis As Single) As Integer

    '/*************************************************************
    'Description:    //插补
    'Input:          //卡链接handle
    '
    'Output:         //
    'Return:         //错误码
    '*************************************************************/
    'int32 __stdcall ZAux_Direct_MEclipseAbsSp(ZMC_HANDLE handle, float fend1, float fend2, float fcenter1, float fcenter2, int idirection, float fADis, float fBDis);
    Declare Function ZAux_Direct_MEclipseAbsSp Lib "zauxdll.dll" (ByVal handle As Integer, ByVal fend1 As Single, ByVal fend2 As Single, ByVal fcenter1 As Single, ByVal fcenter2 As Single, ByVal idirection As Integer, ByVal fADis As Single, ByVal fBDis As Single) As Integer


    '/*************************************************************
    'Description:    //插补 椭圆 + 螺旋
    'Input:          //卡链接handle
    '
    'Output:         //
    'Return:         //错误码
    '*************************************************************/
    'int32 __stdcall ZAux_Direct_MEclipseHelical(ZMC_HANDLE handle, float fend1, float fend2, float fcenter1, float fcenter2, int idirection, float fADis, float fBDis, float fDistance3);
    Declare Function ZAux_Direct_MEclipseHelical Lib "zauxdll.dll" (ByVal handle As Integer, ByVal fend1 As Single, ByVal fend2 As Single, ByVal fcenter1 As Single, ByVal fcenter2 As Single, ByVal idirection As Integer, ByVal fADis As Single, ByVal fBDis As Single, ByVal fDistance3 As Single) As Integer

    '/*************************************************************
    'Description:    //插补  椭圆 + 螺旋
    'Input:          //卡链接handle
    '
    'Output:         //
    'Return:         //错误码
    '*************************************************************/
    'int32 __stdcall ZAux_Direct_MEclipseHelicalAbs(ZMC_HANDLE handle, float fend1, float fend2, float fcenter1, float fcenter2, int idirection, float fADis, float fBDis,float fDistance3);
    Declare Function ZAux_Direct_MEclipseHelicalAbs Lib "zauxdll.dll" (ByVal handle As Integer, ByVal fend1 As Single, ByVal fend2 As Single, ByVal fcenter1 As Single, ByVal fcenter2 As Single, ByVal idirection As Integer, ByVal fADis As Single, ByVal fBDis As Single, ByVal fDistance3 As Single) As Integer

    '/*************************************************************
    'Description:    //插补 椭圆 + 螺旋
    'Input:          //卡链接handle
    '
    'Output:         //
    'Return:         //错误码
    '*************************************************************/
    'int32 __stdcall ZAux_Direct_MEclipseHelicalSp(ZMC_HANDLE handle, float fend1, float fend2, float fcenter1, float fcenter2, int idirection, float fADis, float fBDis, float fDistance3);
    Declare Function ZAux_Direct_MEclipseHelicalSp Lib "zauxdll.dll" (ByVal handle As Integer, ByVal fend1 As Single, ByVal fend2 As Single, ByVal fcenter1 As Single, ByVal fcenter2 As Single, ByVal idirection As Integer, ByVal fADis As Single, ByVal fBDis As Single, ByVal fDistance3 As Single) As Integer

    '/*************************************************************
    'Description:    //插补  椭圆 + 螺旋
    'Input:          //卡链接handle
    '
    'Output:         //
    'Return:         //错误码
    '*************************************************************/
    'int32 __stdcall ZAux_Direct_MEclipseHelicalAbsSp(ZMC_HANDLE handle, float fend1, float fend2, float fcenter1, float fcenter2, int idirection, float fADis, float fBDis,float fDistance3);
    Declare Function ZAux_Direct_MEclipseHelicalAbsSp Lib "zauxdll.dll" (ByVal handle As Integer, ByVal fend1 As Single, ByVal fend2 As Single, ByVal fcenter1 As Single, ByVal fcenter2 As Single, ByVal idirection As Integer, ByVal fADis As Single, ByVal fBDis As Single, ByVal fDistance3 As Single) As Integer


    '/*************************************************************
    'Description:    //插补  空间圆弧
    'Input:          //卡链接handle
    'end1              第1个轴运动距离参数1
    '
    'end2              第2个轴运动距离参数1
    '
    'end3              第3个轴运动距离参数1
    '
    'centre1    第1个轴运动距离参数2
    '
    '    'centre2    第2个轴运动距离参数2

    'centre3    第3个轴运动距离参数2
    '
    'mode      指定前面参数的意义
    '0 当前点，中间点，终点三点定圆弧，距离参数1为终点距离，距离参数2为中间点距离。
    '1 走最小的圆弧，距离参数1为终点距离，距离参数2为圆心的距离。
    '2 当前点，中间点，终点三点定圆，距离参数1为终点距离，距离参数2为中间点距离。
    '3 先走最小的圆弧，再继续走完整圆，距离参数1为终点距离，距离参数2为圆心的距离。


    'Output:         //
    'Return:         //错误码
    '*************************************************************/
    'int32 __stdcall ZAux_Direct_MSpherical(ZMC_HANDLE handle, float fend1, float fend2, float fend3, float fcenter1, float fcenter2, float fcenter3, int imode);
    Declare Function ZAux_Direct_MSpherical Lib "zauxdll.dll" (ByVal handle As Integer, ByVal fend1 As Single, ByVal fend2 As Single, ByVal fend3 As Single, ByVal fcenter1 As Single, ByVal fcenter2 As Single, ByVal fcenter3 As Single, ByVal imode As Integer) As Integer

    '/*************************************************************
    'Description:    //插补  空间圆弧
    'Input:          //卡链接handle
    'end1              第1个轴运动距离参数1
    '
    'end2              第2个轴运动距离参数1
    '
    'end3              第3个轴运动距离参数1
    '
    'centre1    第1个轴运动距离参数2
    '
    'centre2    第2个轴运动距离参数2
    '
    'centre3    第3个轴运动距离参数2
    '
    'mode      指定前面参数的意义
    '0 当前点，中间点，终点三点定圆弧，距离参数1为终点距离，距离参数2为中间点距离。
    '1 走最小的圆弧，距离参数1为终点距离，距离参数2为圆心的距离。
    '2 当前点，中间点，终点三点定圆，距离参数1为终点距离，距离参数2为中间点距离。
    '3 先走最小的圆弧，再继续走完整圆，距离参数1为终点距离，距离参数2为圆心的距离。
    '

    'Output:         //
    'Return:         //错误码
    '*************************************************************/
    'int32 __stdcall ZAux_Direct_MSphericalSp(ZMC_HANDLE handle, float fend1, float fend2, float fend3, float fcenter1, float fcenter2, float fcenter3, int imode);
    Declare Function ZAux_Direct_MSphericalSp Lib "zauxdll.dll" (ByVal handle As Integer, ByVal fend1 As Single, ByVal fend2 As Single, ByVal fend3 As Single, ByVal fcenter1 As Single, ByVal fcenter2 As Single, ByVal fcenter3 As Single, ByVal imode As Integer) As Integer


    '/*************************************************************
    'Description:    //渐开线圆弧插补运动，相对移动方式，当起始半径0直接扩散时从0角度开始
    'Input:          //卡链接handle
    '
    '              centre1: 第1轴圆心的相对距离
    '
    '              centre2: 第2轴圆心的相对距离
    '
    '              circles:  要旋转的圈数，可以为小数圈，负数表示顺时针.
    '
    '              pitch:   每圈的扩散距离，可以为负。
    '
    'distance3        第3轴螺旋的功能，指定第3轴的相对距离，此轴不参与速度计算。

    'distance4        第4轴螺旋的功能，指定第4轴的相对距离，此轴不参与速度计算。
    'Output:         //
    'Return:         //错误码
    '*************************************************************/
    'int32 __stdcall ZAux_Direct_MoveSpiral(ZMC_HANDLE handle, float centre1, float centre2, float circles, float pitch, float distance3, float distance4);
    Declare Function ZAux_Direct_MoveSpiral Lib "zauxdll.dll" (ByVal handle As Integer, ByVal centre1 As Single, ByVal centre2 As Single, ByVal circles As Single, ByVal pitch As Single, ByVal distance3 As Single, ByVal distance4 As Single) As Integer

    '/*************************************************************
    'Description:    //渐开线圆弧插补运动，相对移动方式，当起始半径0直接扩散时从0角度开始
    'Input:          //卡链接handle
    ''
    '         centre1: 第1轴圆心的相对距离

    '          centre2: 第2轴圆心的相对距离
    '
    '         circles:  要旋转的圈数，可以为小数圈，负数表示顺时针.
    '
    '          pitch:   每圈的扩散距离，可以为负。
    '
    'distance3        第3轴螺旋的功能，指定第3轴的相对距离，此轴不参与速度计算。
    '
    'distance4        第4轴螺旋的功能，指定第4轴的相对距离，此轴不参与速度计算。
    '
    'Output:         //
    'Return:         //错误码
    '*************************************************************/
    ''int32 __stdcall ZAux_Direct_MoveSpiralSp(ZMC_HANDLE handle, float centre1, float centre2, float circles, float pitch, float distance3, float distance4);
    Declare Function ZAux_Direct_MoveSpiralSp Lib "zauxdll.dll" (ByVal handle As Integer, ByVal centre1 As Single, ByVal centre2 As Single, ByVal circles As Single, ByVal pitch As Single, ByVal distance3 As Single, ByVal distance4 As Single) As Integer

    '/*************************************************************
    'Description:    //空间直线运动，根据下一个直线运动的绝对坐标在拐角自动插入圆弧，加入圆弧后会使得运动的终点与直线的终点不一致，拐角过大时不会插入圆弧，当距离不够时会自动减小半径
    'Input:          //卡链接handle
    'end1              第1个轴运动绝对坐标'
    'end2              第2个轴运动绝对坐标'
    'end3              第3个轴运动绝对坐标''
    'next1      第1个轴下一个直线运动绝对坐标'
    'next2      第2个轴下一个直线运动绝对坐'标
    'next3      第3个轴下一个直线运动绝对坐标'
    'radius      插入圆弧的半径，当过大的时候自动缩小。
    '
    'Output:         //
    'Return:         //错误码
    '*************************************************************/
    'int32 __stdcall ZAux_Direct_MoveSmooth(ZMC_HANDLE handle, float end1, float end2, float end3, float next1, float next2, float next3, float radius);
    Declare Function ZAux_Direct_MoveSmooth Lib "zauxdll.dll" (ByVal handle As Integer, ByVal end1 As Single, ByVal end2 As Single, ByVal end3 As Single, ByVal next1 As Single, ByVal next2 As Single, ByVal next3 As Single, ByVal radius As Single) As Integer

    '/*************************************************************
    'Description:    //空间直线运动，根据下一个直线运动的绝对坐标在拐角自动插入圆弧，加入圆弧后会使得运动的终点与直线的终点不一致，拐角过大时不会插入圆弧，当距离不够时会自动减小半径
    'Input:          //卡链接handle
    'end1              第1个轴运动绝对坐标
    'end2              第2个轴运动绝对坐标
    'end3              第3个轴运动绝对坐标
    'next1      第1个轴下一个直线运动绝对坐标
    'next2      第2个轴下一个直线运动绝对坐标
    'next3      第3个轴下一个直线运动绝对坐标
    'radius      插入圆弧的半径，当过大的时候自动缩小。
    '
    'Output:         //
    'Return:         //错误码
    '*************************************************************/
    'int32 __stdcall ZAux_Direct_MoveSmoothSp(ZMC_HANDLE handle, float end1, float end2, float end3, float next1, float next2, float next3, float radius);
    Declare Function ZAux_Direct_MoveSmoothSp Lib "zauxdll.dll" (ByVal handle As Integer, ByVal end1 As Single, ByVal end2 As Single, ByVal end3 As Single, ByVal next1 As Single, ByVal next2 As Single, ByVal next3 As Single, ByVal radius As Single) As Integer



    '/*************************************************************
    'Description:    //运动暂停
    'Input:          //卡链接handle  
    '
    '0（缺省） 暂停当前运动。 
    '1 在当前运动完成后正准备执行下一条运动指令时暂停。 
    '2 在当前运动完成后正准备执行下一条运动指令时，并且两条指令的MARK标识不一样时暂停。这个模式可以用于一个动作由多个指令来实现时，可以在一整个动作完成后暂停。 
    ''
    'Output:         //
    'Return:         //错误码
    '*************************************************************/
    'int32 __stdcall ZAux_Direct_MovePause(ZMC_HANDLE handle, int imode);
    Declare Function ZAux_Direct_MovePause Lib "zauxdll.dll" (ByVal handle As Integer, ByVal imode As Integer) As Integer

    '/*************************************************************
    'Description:    //运动暂停
    'Input:          //卡链接handle  
    '
    '0（缺省） 暂停当前运动。 
    '1 在当前运动完成后正准备执行下一条运动指令时暂停。 
    '2 在当前运动完成后正准备执行下一条运动指令时，并且两条指令的MARK标识不一样时暂停。这个模式可以用于一个动作由多个指令来实现时，可以在一整个动作完成后暂停。 
    ''
    'Output:         //
    'Return:         //错误码
    '*************************************************************/
    'int32 __stdcall ZAux_Direct_MoveResume(ZMC_HANDLE handle);
    Declare Function ZAux_Direct_MoveResume Lib "zauxdll.dll" (ByVal handle As Integer) As Integer

    '/*************************************************************
    'Description:    //在当前的运动末尾位置增加速度限制，用于强制拐角减速
    'Input:          //卡链接handle  
    '
    'Output:         //
    'Return:         //错误码
    '*************************************************************/
    ''int32 __stdcall ZAux_Direct_MoveLimit(ZMC_HANDLE handle, float limitspeed);
    Declare Function ZAux_Direct_MoveLimit Lib "zauxdll.dll" (ByVal handle As Integer, ByVal limitspeed As Single) As Integer

    '/*************************************************************
    'Description:    //在运动缓冲中加入输出指令
    'Input:          //卡链接handle  
    '
    'Output:         //
    'Return:         //错误码
    '*************************************************************/
    'int32 __stdcall ZAux_Direct_MoveOp(ZMC_HANDLE handle, int ioutnum, int ivalue);
    Declare Function ZAux_Direct_MoveOp Lib "zauxdll.dll" (ByVal handle As Integer, ByVal ioutnum As Integer, ByVal ivalue As Integer) As Integer

    '/*************************************************************
    'Description:    //在运动缓冲中加入输出指令
    'Input:          //卡链接handle  
    '
    'Output:         //
    'Return:         //错误码
    ''*************************************************************/
    'int32 __stdcall ZAux_Direct_MoveOpMulti(ZMC_HANDLE handle, int ioutnumfirst, int ioutnumend, int ivalue);
    Declare Function ZAux_Direct_MoveOpMulti Lib "zauxdll.dll" (ByVal handle As Integer, ByVal ioutnumfirst As Integer, ByVal ioutnumend As Integer, ByVal ivalue As Integer) As Integer

    '/*************************************************************
    'Description:    //在运动缓冲中加入输出指令
    'Input:          //卡链接handle  
    '
    'Output:         //
    'Return:         //错误码
    '*************************************************************/
    'int32 __stdcall ZAux_Direct_MoveOp2(ZMC_HANDLE handle, int ioutnum, int ivalue, int iofftimems);
    Declare Function ZAux_Direct_MoveOp2 Lib "zauxdll.dll" (ByVal handle As Integer, ByVal ioutnum As Integer, ByVal ivalue As Integer, ByVal iofftimems As Integer) As Integer

    '/*************************************************************
    'Description:    //在运动缓冲中加入AOUT输出指令
    'Input:          //卡链接handle  
    '
    'Output:         //
    'Return:         //错误码
    '*************************************************************/
    'int32 __stdcall ZAux_Direct_MoveAout(ZMC_HANDLE handle, int ioutnum, float fvalue);
    Declare Function ZAux_Direct_MoveAout Lib "zauxdll.dll" (ByVal handle As Integer, ByVal ioutnum As Integer, ByVal fvalue As Single) As Integer

    '/*************************************************************
    'Description:    //在运动缓冲中加入延时指令
    'Input:          //卡链接handle  
    '
    'Output:         //
    ''Return:         //错误码
    '*************************************************************/
    'int32 __stdcall ZAux_Direct_MoveDelay(ZMC_HANDLE handle, int itimems);
    Declare Function ZAux_Direct_MoveDelay Lib "zauxdll.dll" (ByVal handle As Integer, ByVal ioutnum As Integer, ByVal itimems As Integer) As Integer

    '/*************************************************************
    'Description:    //插补 旋转的插补运动
    'Input:          //卡链接handle
    'Output:         //
    'Return:         //错误码
    '*************************************************************/
    'int32 __stdcall ZAux_Direct_MoveTurnabs(ZMC_HANDLE handle, int tablenum ,int imaxaxises, float *pfDisancelist);
    Declare Function ZAux_Direct_MoveTurnabs Lib "zauxdll.dll" (ByVal handle As Integer, ByVal tablenum As Integer, ByVal imaxaxises As Integer, ByRef pfDisancelist As Single) As Integer

    '/*************************************************************
    'Description:    //插补 直接调用运动函数 20130901 以后的控制器版本支持
    'Input:          //卡链接handle
    '				tablenum       存储旋转参数的table编号
    ''refpos1    第一个轴参考点，绝对位置
    ''refpos2    第二个轴参考点，绝对位置
    'mode      1-参考点是当前点前面，2-参考点是结束点后面，3-参考点在中间，采用三点定圆的方式。
    'end1              第一个轴结束点，绝对位置
    'end2              第二个轴结束点，绝对位置
    'imaxaxises        螺旋轴个数
    'pfDisancelist	螺旋轴距离列表
    'Output:         //
    'Return:         //错误码
    ''*************************************************************/
    'int32 __stdcall ZAux_Direct_McircTurnabs(ZMC_HANDLE handle, int tablenum ,float refpos1,float refpos2,int mode,float end1,float end2,int imaxaxises, float *pfDisancelist);
    Declare Function ZAux_Direct_McircTurnabs Lib "zauxdll.dll" (ByVal handle As Integer, ByVal tablenum As Integer, ByVal refpos1 As Single, ByVal refpos2 As Single, ByVal mode As Integer, ByVal end1 As Single, ByVal end2 As Single, ByVal imaxaxises As Integer, ByRef pfDisancelist As Single) As Integer

    '/*************************************************************
    ''Description:    //电子凸轮
    'Input:          //卡链接handle  
    '
    'Output:         //
    'Return:         //错误码
    '*************************************************************/
    'int32 __stdcall ZAux_Direct_Cam(ZMC_HANDLE handle, int istartpoint, int iendpoint, float ftablemulti, float fDistance);
    Declare Function ZAux_Direct_Cam Lib "zauxdll.dll" (ByVal handle As Integer, ByVal istartpoint As Integer, ByVal iendpoint As Integer, ByVal ftablemulti As Single, ByVal fDistance As Single) As Integer

    '/*************************************************************
    'Description:    //电子凸轮
    'Input:          //卡链接handle  
    '
    'Output:         //
    ''Return:         //错误码
    '*************************************************************/
    'int32 __stdcall ZAux_Direct_Cambox(ZMC_HANDLE handle, int istartpoint, int iendpoint, float ftablemulti, float fDistance, int ilinkaxis, int ioption, float flinkstartpos);
    Declare Function ZAux_Direct_Cambox Lib "zauxdll.dll" (ByVal handle As Integer, ByVal istartpoint As Integer, ByVal iendpoint As Integer, ByVal ftablemulti As Single, ByVal fDistance As Single, ByVal ilinkaxis As Integer, ByVal ioption As Integer, ByVal flinkstartpos As Single) As Integer


    '/*************************************************************
    'Description:    //连接 特殊凸轮
    'Input:          //卡链接handle  
    'Output:         //
    'Return:         //错误码
    '*************************************************************/
    'int32 __stdcall ZAux_Direct_Movelink(ZMC_HANDLE handle, float fDistance, float fLinkDis, float fLinkAcc, float fLinkDec,int iLinkaxis, int ioption, float flinkstartpos);
    Declare Function ZAux_Direct_Movelink Lib "zauxdll.dll" (ByVal handle As Integer, ByVal fDistance As Single, ByVal fLinkDis As Single, ByVal fLinkAcc As Single, ByVal fLinkDec As Single, ByVal iLinkaxis As Integer, ByVal ioption As Integer, ByVal flinkstartpos As Single) As Integer

    '/*************************************************************
    'Description:    //连接 同步运动指令
    'Input:          //卡链接handle  
    'Output:         //
    'Return:         //错误码
    ''*************************************************************/
    'int32 __stdcall ZAux_Direct_Connect(ZMC_HANDLE handle, float ratio, int link_axis);
    Declare Function ZAux_Direct_Connect Lib "zauxdll.dll" (ByVal handle As Integer, ByVal ratio As Single, ByVal link_axis As Integer) As Integer

    '/*************************************************************
    'Description:    //连接 同步运动指令
    'Input:          //卡链接handle  
    'Output:         //
    'Return:         //错误码
    '*************************************************************/
    'int32 __stdcall ZAux_Direct_Connpath(ZMC_HANDLE handle, float ratio, int link_axis);
    Declare Function ZAux_Direct_Connpath Lib "zauxdll.dll" (ByVal handle As Integer, ByVal ratio As Single, ByVal link_axis As Integer) As Integer


    '/*************************************************************
    'Description:    //位置锁存指令
    'Input:          //卡链接handle  
    'Output:         //
    'Return:         //错误码
    '*************************************************************/
    'int32 __stdcall ZAux_Direct_Regist(ZMC_HANDLE handle, int imode);
    Declare Function ZAux_Direct_Regist Lib "zauxdll.dll" (ByVal handle As Integer, ByVal imode As Integer) As Integer

    '/*************************************************************
    'Description:    //编码器输入齿轮比，缺省(1,1)
    'Input:          //卡链接handle  
    'Output:         //
    'Return:         //错误码
    '*************************************************************/
    'int32 __stdcall ZAux_Direct_EncoderRatio(ZMC_HANDLE handle,int mpos_count,int input_count);
    Declare Function ZAux_Direct_EncoderRatio Lib "zauxdll.dll" (ByVal handle As Integer, ByVal mpos_count As Integer, ByVal input_count As Integer) As Integer

    '/*************************************************************
    ''Description:    //设置步进输出齿轮比，缺省(1,1)
    'Input:          //卡链接handle  
    'Output:         //
    ''Return:         //错误码
    '*************************************************************/
    'int32 __stdcall ZAux_Direct_StepRatio(ZMC_HANDLE handle,int mpos_count,int input_count);
    Declare Function ZAux_Direct_StepRatio Lib "zauxdll.dll" (ByVal handle As Integer, ByVal mpos_count As Integer, ByVal input_count As Integer) As Integer

    '/*************************************************************
    'Description:    //所有轴立即停止
    'Input:          //卡链接handle  
    'Output:         //
    'Return:         //错误码
    '*************************************************************/
    'int32 __stdcall ZAux_Direct_Rapidstop(ZMC_HANDLE handle, int imode);
    Declare Function ZAux_Direct_Rapidstop Lib "zauxdll.dll" (ByVal handle As Integer, ByVal imode As Integer) As Integer

    '/*************************************************************
    'Description:    //多个轴运动停止
    'Input:          //卡链接handle  轴号， 距离
    'Output:         //
    'Return:         //错误码
    '*************************************************************/
    'int32 __stdcall ZAux_Direct_CancelAxisList(ZMC_HANDLE handle, int imaxaxises, int *piAxislist, int imode);
    Declare Function ZAux_Direct_CancelAxisList Lib "zauxdll.dll" (ByVal handle As Integer, ByVal imaxaxises As Integer, ByRef piAxislist As Integer, ByVal imode As Integer) As Integer

    '/*************************************************************
    ''Description:    //CONNFRAME机械手指令
    '
    'Input:          //卡链接handle
    '					frame机械手类型
    '					tablenum  相关参数TABLE起点
    '					imaxaxises 关联虚拟轴个数
    '					piAxislist 虚拟轴列表
    'Output:         //
    'Return:         //错误码
    '*************************************************************/
    'int32 __stdcall ZAux_Direct_Connframe(ZMC_HANDLE handle, int frame, int tablenum , int imaxaxises , int *piAxislist);
    Declare Function ZAux_Direct_Connframe Lib "zauxdll.dll" (ByVal handle As Integer, ByVal frame As Integer, ByVal tablenum As Integer, ByVal imaxaxises As Integer, ByRef piAxislist As Integer) As Integer

    '/*************************************************************
    'Description:    //CONNREFRAME机械手指令
    '
    'Input:          //卡链接handle
    '					frame机械手类型
    '					tablenum  相关参数TABLE起点
    '					imaxaxises 关联关节轴个数
    '					piAxislist 关节轴列表
    'Output:         //
    ''Return:         //错误码
    '*************************************************************/
    'int32 __stdcall ZAux_Direct_Connreframe(ZMC_HANDLE handle, int frame, int tablenum , int imaxaxises , int *piAxislist);
    Declare Function ZAux_Direct_Connreframe Lib "zauxdll.dll" (ByVal handle As Integer, ByVal frame As Integer, ByVal tablenum As Integer, ByVal imaxaxises As Integer, ByRef piAxislist As Integer) As Integer


    '#If 0 Then
    '    //单轴函数
    '#End If

    '/*************************************************************
    'Description:    //叠加
    'Input:          //卡链接handle  
    'Output:         //
    'Return:         //错误码
    '*************************************************************/
    'int32 __stdcall ZAux_Direct_Singl_Addax(ZMC_HANDLE handle, int iaxis, int iaddaxis);
    Declare Function ZAux_Direct_Singl_Addax Lib "zauxdll.dll" (ByVal handle As Integer, ByVal iaxis As Integer, ByVal iaddaxis As Integer) As Integer

    '/*************************************************************
    'Description:    //单轴运动停止
    'Input:          //卡链接handle  轴号， 模式
    'Output:         //
    'Return:         //错误码
    ''*************************************************************/
    'int32 __stdcall ZAux_Direct_Singl_Cancel(ZMC_HANDLE handle, int iaxis, int imode);
    Declare Function ZAux_Direct_Singl_Cancel Lib "zauxdll.dll" (ByVal handle As Integer, ByVal iaxis As Integer, ByVal imode As Integer) As Integer

    '/*************************************************************
    'Description:    //连续运动
    ''Input:          //卡链接handle  轴号， 方向
    'Output:         //
    'Return:         //错误码
    '*************************************************************/
    'int32 __stdcall ZAux_Direct_Singl_Vmove(ZMC_HANDLE handle, int iaxis, int idir);
    Declare Function ZAux_Direct_Singl_Vmove Lib "zauxdll.dll" (ByVal handle As Integer, ByVal iaxis As Integer, ByVal idir As Integer) As Integer

    '/*************************************************************
    'Description:    //回零
    'Input:          //卡链接handle  
    'Output:         //
    'Return:         //错误码
    '*************************************************************/
    'int32 __stdcall ZAux_Direct_Singl_Datum(ZMC_HANDLE handle, int iaxis, int imode);
    Declare Function ZAux_Direct_Singl_Datum Lib "zauxdll.dll" (ByVal handle As Integer, ByVal iaxis As Integer, ByVal imode As Integer) As Integer

    '/*************************************************************
    'Description:    //单轴运动
    'Input:          //卡链接handle  轴号， 距离
    'Output:         //
    'Return:         //错误码
    '*************************************************************/
    'int32 __stdcall ZAux_Direct_Singl_Move(ZMC_HANDLE handle, int iaxis, float fdistance);
    Declare Function ZAux_Direct_Singl_Move Lib "zauxdll.dll" (ByVal handle As Integer, ByVal iaxis As Integer, ByVal fdistance As Single) As Integer

    '/*************************************************************
    'Description:    //单轴运动
    'Input:          //卡链接handle  轴号， 距离
    'Output:         //
    'Return:         //错误码
    '*************************************************************/
    'int32 __stdcall ZAux_Direct_Singl_MoveAbs(ZMC_HANDLE handle, int iaxis, float fdistance);
    Declare Function ZAux_Direct_Singl_MoveAbs Lib "zauxdll.dll" (ByVal handle As Integer, ByVal iaxis As Integer, ByVal fdistance As Single) As Integer



    '#If 0 Then
    '    //辅助函数
    '#End If

    '/*********************内存操作
    ''
    '/*********************内存操作
    '/*************************************************************
    'Description:    //写VR, 
    'Input:          //卡链接handle  轴号， 距离
    'Output:         //
    'Return:         //错误码
    '*************************************************************/
    'int32 __stdcall ZAux_Direct_SetVr(ZMC_HANDLE handle,int vrstartnum, int numes, float *pfValue);
    Declare Function ZAux_Direct_SetVr Lib "zauxdll.dll" (ByVal handle As Integer, ByVal vrstartnum As Integer, ByVal numes As Integer, ByVal pfValue As Single) As Integer

    '/*************************************************************
    'Description:    //VR读取, 可以一次读取多个
    'Input:          //卡链接handle  
    'Output:         //pfValue  多个时必须分配空间.
    'Return:         //错误码
    '*************************************************************/
    'int32 __stdcall ZAux_Direct_GetVrf(ZMC_HANDLE handle, int vrstartnum, int numes, float *pfValue);
    Declare Function ZAux_Direct_GetVrf Lib "zauxdll.dll" (ByVal handle As Integer, ByVal vrstartnum As Integer, ByVal numes As Integer, ByVal pfValue As Single) As Integer

    '/*************************************************************
    'Description:    //VRINT读取， 必须150401以上版本才支持VRINT的DIRECTCOMMAND读取
    'Input:          //卡链接handle  
    'Output:         //
    'Return:         //错误码
    '*************************************************************/
    'int32 __stdcall ZAux_Direct_GetVrInt(ZMC_HANDLE handle, int vrstartnum, int numes, int *piValue);
    Declare Function ZAux_Direct_GetVrInt Lib "zauxdll.dll" (ByVal handle As Integer, ByVal vrstartnum As Integer, ByVal numes As Integer, ByVal piValue As Integer) As Integer

    '/*************************************************************
    'Description:    //写table 
    'Input:          //卡链接handle  轴号， 距离
    'Output:         //
    'Return:         //错误码
    '*************************************************************/
    'int32 __stdcall ZAux_Direct_SetTable(ZMC_HANDLE handle,int tabstart, int numes, float *pfValue);
    Declare Function ZAux_Direct_SetTable Lib "zauxdll.dll" (ByVal handle As Integer, ByVal tabstart As Integer, ByVal numes As Integer, ByVal pfValue As Single) As Integer

    '/*************************************************************
    'Description:    //table读取, 可以一次读取多个
    'Input:          //卡链接handle  
    'Output:         //pfValue  多个时必须分配空间
    'Return:         //错误码
    '*************************************************************/
    'int32 __stdcall ZAux_Direct_Gettable(ZMC_HANDLE handle, int tabstart, int numes, float *pfValue);
    Declare Function ZAux_Direct_Gettable Lib "zauxdll.dll" (ByVal handle As Integer, ByVal tabstart As Integer, ByVal numes As Integer, ByVal pfValue As Single) As Integer

    '/*************************************************************
    'Description:    //字符串转为float
    'Input:          //卡链接handle  
    'Output:         //
    'Return:         //错误码
    '*************************************************************/
    'int32 __stdcall ZAux_TransStringtoFloat(const char* pstringin, int inumes,  float* pfvlaue);
    Declare Function ZAux_TransStringtoFloat Lib "zauxdll.dll" (ByVal pstringin As String, ByVal inumes As Integer, ByRef pfvlaue As Single) As Integer

    '/*************************************************************
    'Description:    //字符串转为int
    'Input:          //卡链接handle  
    'Output:         //
    'Return:         //错误码
    '*************************************************************/
    'int32 __stdcall ZAux_TransStringtoInt(const char* pstringin, int inumes,  int* pivlaue);
    Declare Function ZAux_TransStringtoInt Lib "zauxdll.dll" (ByVal pstringin As String, ByVal inumes As Integer, ByRef pfvlaue As Integer) As Integer

    '/*************************************************************
    'Description:    //把float格式的变量列表存储到文件， 与控制器的U盘文件格式一致.
    'Input:          //
    'Output:         //
    'Return:         //错误码
    '*************************************************************/
    'int32 __stdcall ZAux_WriteUFile(const char *sFilename, float *pVarlist, int inum);
    Declare Function ZAux_WriteUFile Lib "zauxdll.dll" (ByVal sFilename As String, ByRef pVarlist As Single, ByVal inum As Integer) As Integer

    '/*************************************************************
    'Description:    //读取float格式的变量列表， 与控制器的U盘文件格式一致.
    'Input:          //
    'Output:         //
    'Return:         //错误码
    '*************************************************************/
    'int32 __stdcall ZAux_ReadUFile(const char *sFilename, float *pVarlist, int* pinum);
    Declare Function ZAux_ReadUFile Lib "zauxdll.dll" (ByVal sFilename As String, ByRef pVarlist As Single, ByRef pinum As Integer) As Integer

    '//
    '#endif



    '=================================================================================
    '                               ‘新添加’
    '=================================================================================
    '*************************************************************
    'Description:    //与控制器建立链接
    'Input:          //IP地址，字符串的方式输入
    'Output:         //卡链接handle
    'Return:         //错误码
    '*************************************************************/
    'int32  __stdcall ZAux_OpenEth(char *ipaddr, ZMC_HANDLE * phandle);
    Declare Function ZAux_OpenEth Lib "zauxdll.dll" (ByVal ipaddr As String, ByRef phandle As Integer) As Integer

    '/*************************************************************
    'Description:    //modbus寄存器操作
    'Input:          //卡链接handle 寄存器地址
    'Output:         //
    'Return:         //错误码
    '*************************************************************/
    'int32 __stdcall ZAux_Modbus_Set0x(ZMC_HANDLE handle, uint16 start, uint16 inum, uint8* pdata);
    Declare Function ZAux_Modbus_Set0x Lib "zauxdll.dll" (ByVal handle As Integer, ByVal start As Integer, ByVal inum As Integer, ByVal pdata As Integer) As Integer

    '/*************************************************************
    'Description:    //modbus寄存器操作
    'Input:          //卡链接handle 寄存器地址
    'Output:         //
    'Return:         //错误码
    '*************************************************************/
    'int32 __stdcall ZAux_Modbus_Get0x(ZMC_HANDLE handle, uint16 start, uint16 inum, uint8* pdata);
    Declare Function ZAux_Modbus_Get0x Lib "zauxdll.dll" (ByVal handle As Integer, ByVal start As Integer, ByVal inum As Integer, ByVal pdata As Integer) As Integer

    '/*************************************************************
    'Description:    //modbus_ieee
    'Input:          //
    'Output:         //
    'Return:         //错误码
    '*************************************************************/
    'int32 __stdcall ZAux_Modbus_Get4x_Float(ZMC_HANDLE handle, uint16 start, uint16 inum, float* pfdata);
    Declare Function ZAux_Modbus_Get4x_Float Lib "zauxdll.dll" (ByVal handle As Integer, ByVal start As Integer, ByVal inum As Integer, ByVal pfdata As Single) As Integer

    '/*************************************************************
    'Description:    //modbus_ieee
    'Input:          //
    'Output:         //
    'Return:         //错误码
    '*************************************************************/
    'int32 __stdcall ZAux_Modbus_Set4x_Float(ZMC_HANDLE handle, uint16 start, uint16 inum, float* pfdata);
    Declare Function ZAux_Modbus_Set4x_Float Lib "zauxdll.dll" (ByVal handle As Integer, ByVal start As Integer, ByVal inum As Integer, ByVal pfdata As Single) As Integer

    '/*************************************************************
    'Description:    //modbus_long
    'Input:          //
    'Output:         //
    'Return:         //错误码
    '*************************************************************/
    'int32 __stdcall ZAux_Modbus_Get4x_Long(ZMC_HANDLE handle, uint16 start, uint16 inum, int32* pidata);
    Declare Function ZAux_Modbus_Get4x_Long Lib "zauxdll.dll" (ByVal handle As Integer, ByVal start As Integer, ByVal inum As Integer, ByVal pfdata As Single) As Integer
    '/*************************************************************
    'Description:    //modbus_long
    'Input:          //
    'Output:         //
    'Return:         //错误码
    '*************************************************************/
    'int32 __stdcall ZAux_Modbus_Set4x_Long(ZMC_HANDLE handle, uint16 start, uint16 inum, int32* pidata);
    Declare Function ZAux_Modbus_Set4x_Long Lib "zauxdll.dll" (ByVal handle As Integer, ByVal start As Integer, ByVal inum As Integer, ByVal pfdata As Single) As Integer
    '    /*************************************************************
    'Description:    //写用户flash块, float数据
    'Input:          //卡链接handle
    '					uiflashid 	flash块号
    '					uinumes		变量个数
    'Output:         //
    'Return:         //错误码
    '*************************************************************/
    'int32 __stdcall ZAux_FlashWritef(ZMC_HANDLE handle, uint16 uiflashid, uint32 uinumes, float *pfvlue);
    Declare Function ZAux_FlashWritef Lib "zauxdll.dll" (ByVal handle As Integer, ByVal uiflashid As Integer, ByVal uinumes As Integer, ByVal pfvlue As Single) As Integer
    '/*************************************************************
    'Description:    //读取用户flash块, float数据
    'Input:          //卡链接handle
    '					uiflashid 	flash块号
    '					uibuffnum	缓冲变量个数
    'Output:         //
    '					puinumesread 读取到的变量个数
    'Return:         //错误码
    '*************************************************************/
    'int32 __stdcall ZAux_FlashReadf(ZMC_HANDLE handle, uint16 uiflashid, uint32 uibuffnum, float *pfvlue, uint32* puinumesread);
    Declare Function ZAux_FlashReadf Lib "zauxdll.dll" (ByVal handle As Integer, ByVal uiflashid As Integer, ByVal uibuffnum As Single, ByVal pfvlue As Single) As Integer




    Declare Function ZAux_Modbus_Set4x Lib "zauxdll.dll" (ByVal handle As Integer, ByVal start As Integer, ByVal inum As Integer, ByVal pdata As Single) As Integer
    Declare Function ZAux_Modbus_Get4x Lib "zauxdll.dll" (ByVal handle As Integer, ByVal start As Integer, ByVal inum As Integer, ByVal pdata As Single) As Integer


End Module
