Module Zmotion




    ''''''''''''''''''''''''''''''''''  zmotion technology  ''''''''''''''''''''''''
    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    ''
    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''


    '/*********************************************************
    '数据类型定义
    '**********************************************************/
    '
    'typedef unsigned __int64   uint64;
    'typedef __int64   int64;
    '
    '
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
    '
    '// 连接类型,
    'enum ZMC_CONNECTION_TYPE
    '{
    '    ZMC_CONNECTION_COM = 1,
    '    ZMC_CONNECTION_ETH = 2,
    '    ZMC_CONNECTION_USB = 3,
    '    ZMC_CONNECTION_PCI = 4,
    '};
    Const ZMC_CONNECTION_COM = 1                                   'COM
    Const ZMC_CONNECTION_ETH = 2                                   'LAN
    Const ZMC_CONNECTION_USB = 3                                   'USB
    Const ZMC_CONNECTION_PCI = 4                                   'PCI

    '//缺省的等待时间
    '#define ZMC_DEFAULT_TIMEOUT   5000
    Const ZMC_DEFAULT_TIMEOUT = 5000
    '
    '//串口延时需要更加长一些
    '#define ZMC_DEFAULT_TIMEOUT_COM   5000
    Const ZMC_DEFAULT_TIMEOUT_COM = 5000
    '
    '
    '//通道句柄定义
    'typedef  void* ZMC_HANDLE;
    '
    '
    '/************************************************/
    '//错误码 详细的错误码常见说明书或 zerror.h
    '/************************************************/
    '#define ERR_OK  0
    '#define ERROR_OK 0
    '#define ERR_SUCCESS  0
    '
    '
    '
    '/*********************************************************
    '系统状态定义
    '**********************************************************/
    'enum ZBASIC_TASKSTATE
    '{
    '    TASK_STATE_RUNING = 1,
    '    TASK_STATE_PAUSE = 3,
    '    TASK_STATE_STOP = 0,
    '
    '    /************  下面是trio特殊状态, 暂时不支持  ************/
    '    //步进
    '    TASK_STATE_STEP = 2,
    '    TASK_STATE_PAUSING = 4,
    '    TASK_STATE_STOPING = 5,
    '
    '    TASK_STATE_ERROR = 100,//查询的时候如果ID错返回这个值, 脚本初始化发现语法错误也返回这个错误
    '};
    '
    '//新增加
    '#define  SYS_STATE_CANNOT_CONNECT   50 //链接不上
    Const SYS_STATE_CANNOT_CONNECT = 50
    'system status start

    Const TASK_STATE_RUNING = 1
    Const TASK_STATE_PAUSE = 3
    Const TASK_STATE_STOP = 0

    Const TASK_STATE_STEP = 2
    Const TASK_STATE_PAUSING = 4
    Const TASK_STATE_STOPING = 5

    Const TASK_STATE_ERROR = 100 '//查询的时候如果ID错返回这个值, 脚本初始化发现语法错误也返回这个错误

    '
    '
    '/*********************************************************
    '函数声明
    '**********************************************************/
    '
    '/*************************************************************
    'Description:    //与控制器建立链接
    'Input:          //无
    'Output:         //卡链接handle
    'Return:         //错误码
    '*************************************************************/
    'int32 __stdcall ZMC_Open(ZMC_CONNECTION_TYPE type, char *pconnectstring ,ZMC_HANDLE * phandle);
    Declare Function ZMC_Open Lib "zmotion.dll" (ByVal type As Integer, ByVal pconnectstring As String, ByRef phandle As Integer) As Integer
    '
    '/*************************************************************
    'Description:    //与控制器建立链接, 可以指定连接的等待时间
    'Input:          //无
    'Output:         //卡链接handle
    'Return:         //错误码
    '*************************************************************/
    'int32 __stdcall ZMC_FastOpen(ZMC_CONNECTION_TYPE type, char *pconnectstring, uint32 uims ,ZMC_HANDLE * phandle);
    Declare Function ZMC_FastOpen Lib "zmotion.dll" (ByVal type As Integer, ByVal pconnectstring As String, ByVal uims As Integer, ByRef phandle As Integer) As Integer
    '
    '/*************************************************************
    'Description:    //与控制器建立链接， 串口方式.
    'Input:          //无
    'Output:         //卡链接handle
    'Return:         //错误码
    '*************************************************************/
    'int32 __stdcall ZMC_OpenCom(uint32 comid, ZMC_HANDLE * phandle);
    Declare Function ZMC_OpenCom Lib "zmotion.dll" (ByVal comid As Integer, ByRef phandle As Integer) As Integer

    '
    '/*************************************************************
    'Description:    //可以修改缺省的波特率等设置
    '
    'uint32 dwByteSize = 8, uint32 dwParity = NOPARITY, uint32 dwStopBits = ONESTOPBIT
    '
    'Input:          //
    'Output:         //
    'Return:         //错误码
    '*************************************************************/
    'int32 __stdcall ZMC_SetComDefaultBaud(uint32 dwBaudRate, uint32 dwByteSize, uint32 dwParity, uint32 dwStopBits);
    Declare Function ZMC_SetComDefaultBaud Lib "zmotion.dll" (ByVal dwBaudRate As Integer, ByVal dwByteSize As Integer, ByVal dwParity As Integer, ByVal dwStopBits As Integer) As Integer

    '/*************************************************************
    'Description:    //快速控制器建立链接
    'Input:          //无
    'Output:         //卡链接handle
    'Return:         //错误码
    '*************************************************************/
    'int32 __stdcall ZMC_PeakCom(uint32 comid, uint32 uims,ZMC_HANDLE * phandle);
    Declare Function ZMC_PeakCom Lib "zmotion.dll" (ByVal comid As Integer, ByVal uims As Integer, ByRef phandle As Integer) As Integer


    '
    '/*************************************************************
    'Description:    //与控制器建立链接
    'Input:          //IP地址，字符串的方式输入
    'Output:         //卡链接handle
    'Return:         //错误码
    '*************************************************************/
    'int32 __stdcall ZMC_OpenEth(char *ipaddr, ZMC_HANDLE * phandle);
    Declare Function ZMC_OpenEth Lib "zmotion.dll" (ByVal ipaddr As String, ByRef phandle As Integer) As Integer
    '
    '/*************************************************************
    'Description:    //与控制器建立链接
    'Input:          //IP地址，32位数的IP地址输入, 注意字节顺序
    'Output:         //卡链接handle
    'Return:         //错误码
    '*************************************************************/
    'int32 __stdcall ZMC_OpenEth2(struct in_addr straddr, ZMC_HANDLE * phandle);
    Declare Function ZMC_OpenEth2 Lib "zmotion.dll" (ByRef straddr As Integer, ByRef phandle As Integer) As Integer

    '
    '/*************************************************************
    'Description:    //与控制器建立链接
    'Input:          //PCI卡编号
    'Output:         //卡链接handle
    'Return:         //错误码
    '*************************************************************/
    'int32 __stdcall ZMC_OpenPci(uint32 cardnum, ZMC_HANDLE * phandle);
    Declare Function ZMC_OpenPci Lib "zmotion.dll" (ByVal cardnum As Integer, ByRef phandle As Integer) As Integer

    '
    '/*************************************************************
    'Description:    //读取PCI的控制卡个数
    'Input:          //
    'Output:         //
    'Return:         //卡数
    '*************************************************************/
    'uint32 __stdcall ZMC_GetMaxPciCards();
    Declare Function ZMC_GetMaxPciCards Lib "zmotion.dll" () As Integer

    '
    '/*************************************************************
    'Description:    //与控制器建立链接, 自动查找COM号
    'Input:          //COM号范围
    'Output:         //卡链接handle
    'Return:         //错误码
    '*************************************************************/
    'int32 __stdcall ZMC_SearchAndOpenCom(uint32 uimincomidfind, uint32 uimaxcomidfind,uint* pcomid, uint32 uims, ZMC_HANDLE * phandle);
    Declare Function ZMC_SearchAndOpenCom Lib "zmotion.dll" (ByVal uimincomidfind As Integer, ByVal uimaxcomidfind As Integer, ByRef pcomid As Integer, ByVal uims As Integer, ByRef phandle As Integer) As Integer

    '/*************************************************************
    'Description:    //与控制器建立链接, 自动搜索网络. 暂时不支持
    'Input:          //最长等待时间
    'Output:         //卡链接handle 连接的IP地址
    'Return:         //错误码
    '*************************************************************/
    'int32 __stdcall ZMC_SearchAndOpenEth(char *ipaddr, uint32 uims, ZMC_HANDLE * phandle);
    Declare Function ZMC_SearchAndOpenEth Lib "zmotion.dll" (ByVal ipaddr As String, ByVal uims As Integer, ByRef phandle As Integer) As Integer
    '
    '/*************************************************************
    'Description:    //与控制器建立链接, 自动搜索网络.
    'Input:          //最长等待时间
    'Output:         //控制器IP地址, 地址间用空格区分。
    'Return:         //错误码
    '*************************************************************/
    'int32 __stdcall ZMC_SearchEth(char *ipaddrlist,  uint32 addrbufflength, uint32 uims);
    Declare Function ZMC_SearchEth Lib "zmotion.dll" (ByVal ipaddrlist As String, ByVal addrbufflength As Integer, ByVal uims As Integer) As Integer

    '
    '
    '/*************************************************************
    'Description:    //关闭控制器链接
    'Input:          //卡链接handle
    'Output:         //
    'Return:         //错误码
    '*************************************************************/
    'int32 __stdcall ZMC_Close(ZMC_HANDLE  handle);
    Declare Function ZMC_Close Lib "zmotion.dll" (ByVal handle As Integer) As Integer

    '
    '/*************************************************************
    'Description:    //命令的延时等待时间
    'Input:          //卡链接handle 毫秒时间
    'Output:         //
    'Return:         //错误码
    '*************************************************************/
    'int32 __stdcall ZMC_SetTimeOut(ZMC_HANDLE  handle, uint32 timems);
    Declare Function ZMC_SetTimeOut Lib "zmotion.dll" (ByVal handle As Integer, ByVal timems As Integer) As Integer

    '
    '/*************************************************************
    'Description:    //命令的延时等待时间
    'Input:          //卡链接handle
    'Output:         //毫秒时间
    'Return:         //错误码
    '*************************************************************/
    'int32 __stdcall ZMC_GetTimeOut(ZMC_HANDLE  handle, uint32* ptimems);
    Declare Function ZMC_GetTimeOut Lib "zmotion.dll" (ByVal handle As Integer, ByRef timems As Integer) As Integer

    '
    '/*************************************************************

    'Description:    //读取长时间命令的进度
    'Input:          //卡链接handle
    'Output:         //
    'Return:         //进度， 浮点，
    '*************************************************************/
    'float  __stdcall ZMC_GetProgress(ZMC_HANDLE  handle);
    Declare Function ZMC_GetProgress Lib "zmotion.dll" (ByVal handle As Integer) As Single

    '
    '/*************************************************************
    'Description:    //读取连接的类型
    'Input:          //卡链接handle
    'Output:         //
    'Return:         //ZMC_CONNECTION_TYPE
    '*************************************************************/
    'uint8  __stdcall ZMC_GetConnectType(ZMC_HANDLE  handle);
    Declare Function ZMC_GetConnectType Lib "zmotion.dll" (ByVal handle As Integer) As Byte

    '
    '/*************************************************************
    'Description:    //读取连接的名称
    'Input:          //卡链接handle
    'Output:         //
    'Return:         //string
    '*************************************************************/
    'const char*  __stdcall ZMC_GetConnectString(ZMC_HANDLE  handle);
    Declare Function ZMC_GetConnectString Lib "zmotion.dll" (ByVal handle As Integer) As String

    '#if 0
    '#endif
    '/***************************************************
    '       ZBASIC命令，文件相关函数列表
    '***************************************************/


    '/*************************************************************
    'Description:    ////读取系统状态
    'Input:          //卡链接handle
    'Output:         //状态 ZBASIC_TASKSTATE
    'Return:         //错误码
    '*************************************************************/
    'int32 __stdcall ZMC_GetState(ZMC_HANDLE handle,uint8 *pstate);
    Declare Function ZMC_GetState Lib "zmotion.dll" (ByVal handle As Integer, ByRef pState As Byte) As Integer

    '
    '/*************************************************************
    'Description:    //读取暂停导致的任务号
    'Input:          //卡链接handle
    'Output:         //任务号
    'Return:         //错误码
    '*************************************************************/
    'int32 __stdcall ZMC_GetStopPauseTaskid(ZMC_HANDLE handle,uint8 *ptaskid);
    Declare Function ZMC_GetStopPauseTaskid Lib "zmotion.dll" (ByVal handle As Integer, ByRef pState As Byte) As Integer
    '
    '
    '/*************************************************************
    'Description:    ////读取链接控制器的总虚拟轴数
    'Input:          //卡链接handle
    'Output:         //
    'Return:         //轴数，出错0
    '*************************************************************/
    'uint8 __stdcall ZMC_GetAxises(ZMC_HANDLE handle);
    Declare Function ZMC_GetAxises Lib "zmotion.dll" (ByVal handle As Integer) As Byte

    '
    '/*************************************************************
    'Description:    //通用的命令执行接口,此命令不读取控制器的应答.  当控制器没有缓冲时自动阻赛
    'Input:          //卡链接handle     pszCommand命令串,  uimswait 最长等待ms时间
    'Output:         //
    'Return:         //错误码
    '*************************************************************/
    'int32 __stdcall ZMC_ExecuteNoAck(ZMC_HANDLE handle, const char* pszCommand, uint32 uimswait);
    Declare Function ZMC_ExecuteNoAck Lib "zmotion.dll" (ByVal handle As Integer, ByRef pszCommand As String, ByVal uimswait As Integer) As Integer

    '
    '/*************************************************************
    'Description:    //通用的命令执行接口  当控制器没有缓冲时自动阻赛
    'Input:          //卡链接handle  pszCommand命令串,    uimswait 最长等待ms时间
    'Output:         //psResponse 接收控制器的执行结果输出
    'Return:         //错误码
    '*************************************************************/
    'int32 __stdcall ZMC_Execute(ZMC_HANDLE handle, const char* pszCommand, uint32 uimswait, char* psResponse, uint32 uiResponseLength);
    Declare Function ZMC_Execute Lib "zmotion.dll" (ByVal handle As Integer, ByVal pszCommand As String, ByVal uimswait As Integer, ByVal psResponse As String, ByVal uiResponseLength As Integer) As Integer

    '
    '/*************************************************************
    'Description:    //等待前面的命令执行结束，控制器执行的应答被丢掉. 当没有缓冲时自动阻赛
    'Input:          //卡链接handle  uimswait 最长等待ms时间
    'Output:         //
    'Return:         //错误码
    '*************************************************************/
    'int32 __stdcall ZMC_ExecuteWaitDown(ZMC_HANDLE handle, uint32 uimaxms);
    Declare Function ZMC_ExecuteWaitDown Lib "zmotion.dll" (ByVal handle As Integer, ByVal uimswait As Integer) As Integer
    '
    '/*************************************************************
    'Description:    //读取在线命令的应答， 对没有接收应答的命令有用.
    '                               此函数不阻赛
    'Input:          //卡链接handle  uimax 缓冲长度
    'Output:         //pbuff 返回读取结果，  puiread 读取的长度，  pbifExcuteDown 是否已经执行结束
    'Return:         //错误码
    '*************************************************************/
    'int32 __stdcall ZMC_ExecuteGetReceive(ZMC_HANDLE handle, char * pbuff, uint32 uimax, uint32 *puiread, uint8 *pbifExcuteDown);
    Declare Function ZMC_ExecuteGetReceive Lib "zmotion.dll" (ByVal handle As Integer, ByVal pbuff As Integer, ByVal uimax As Integer, ByRef puiread As Integer, ByRef pbifExcuteDown As Byte) As Integer
    '
    '
    '/*************************************************************
    'Description:    //读取在线命令的当前剩余缓冲
    'Input:          //卡链接handle
    'Output:         //
    'Return:         //剩余空间 出错 - 0
    '*************************************************************/
    'uint32 __stdcall ZMC_ExecuteGetRemainBuffSpace(ZMC_HANDLE handle);
    Declare Function ZMC_ExecuteGetRemainBuffSpace Lib "zmotion.dll" (ByVal handle As Integer) As Integer
    '
    '
    '
    '/*************************************************************
    'Description:    //直接命令接口，用于调试, 只支持少数命令 暂时不支持
    'Input:          //卡链接handle
    'Output:         //
    'Return:         //错误码
    '*************************************************************/
    'int32 __stdcall ZMC_DirectCommand(ZMC_HANDLE handle, const char* pszCommand, char* psResponse, uint32 uiResponseLength);
    Declare Function ZMC_DirectCommand Lib "zmotion.dll" (ByVal handle As Integer, ByVal pszCommoand As String, ByVal psResponse As String, ByVal uiResponseLength As Integer) As Integer
    '
    '
    '/*************************************************************
    'Description:    //打下载包ZAR,
    'Input:          //卡链接handle
    '                pZpjfilename 项目文件名 带路径
    '                pZarfilename ZAR文件名
    '                pPass 软件密码, 绑定APP_PASS  没有密码时pPass = NULL
    '                uid 绑定控制器唯一ID， 0-不绑定
    'Output:         //
    'Return:         //错误码
    '*************************************************************/
    'int32 __stdcall ZMC_MakeZar(const char* pZpjfilename, const char* pZarfilename, const char *pPass, uint32 uid);
    Declare Function ZMC_MakeZar Lib "zmotion.dll" (ByVal pzpjfilename As String, ByVal pZarfilename As String, ByVal pPass As String, ByVal uid As Integer) As Integer
    '
    '
    '/*************************************************************
    'Description:    //打下载包ZAR, 输入二进制的zpj文件
    'Input:          //卡链接handle
    '                pzpj 文件缓冲
    '                pBasDir bas程序文件路径
    '                pZarfilename ZAR文件名
    '                pPass 软件密码, 绑定APP_PASS  没有密码时pPass = NULL

    'Output:         //
    'Return:         //错误码
    '*************************************************************/
    'int32 __stdcall ZMC_MakeZar2(void *pzpj,const char *pBasDir, const char* pZarfilename, const char *pPass, uint32 uid);
    Declare Function ZMC_MakeZar2 Lib "zmotion.dll" (ByRef pzpj As Integer, ByVal pBasDir As String, ByVal pZarfilename As String, ByVal pPass As String, ByVal uid As Integer) As Integer
    '
    '
    '/*************************************************************
    'Description:    //下载包文件
    'Input:          //卡链接handle
    '                pfilename  zar文件名
    '                pfilenameinControl  BASIC系统只有一个包文件，可以不指定.
    'Output:         //
    'Return:         //错误码
    '*************************************************************/
    'int32 __stdcall ZMC_DownZar(ZMC_HANDLE handle, const char* pfilename, const char* pfilenameinControl);
    Declare Function ZMC_DownZar Lib "zmotion.dll" (ByVal handle As Integer, ByVal pfilename As String, ByVal pfilenameinControl As String) As Integer
    '
    '
    '/*************************************************************
    'Description:    //下载包文件
    'Input:          //卡链接handle
    '                pbuffer     zar文件在内存中的地址
    '                buffsize    zar文件长度
    '                pfilenameinControl 控制器上文件的名字 , BASIC系统只有一个包文件，可以不指定.
    'Output:         //
    'Return:         //错误码
    '*************************************************************/
    'int32 __stdcall ZMC_DownMemZar(ZMC_HANDLE handle, const char* pbuffer, uint32 buffsize, const char* pfilenameinControl);
    Declare Function ZMC_DownMemZar Lib "zmotion.dll" (ByVal handle As Integer, ByVal pbuffer As String, ByVal buffsize As Integer, ByVal pfilenameinControl As String) As Integer
    '
    '
    '
    '/*************************************************************
    'Description:    //运行包
    'Input:          //卡链接handle
    '                pfilenameinControl 文件名， 当为NULL的时候运行缺省文件 , BASIC系统只有一个包文件，可以不指定.
    'Output:         //
    'Return:         //错误码
    '*************************************************************/
    'int32 __stdcall ZMC_RunZarFile(ZMC_HANDLE handle, const char* pfilenameinControl);
    Declare Function ZMC_RunZarFile Lib "zmotion.dll" (ByVal handle As Integer, ByVal pfilenameinControl As String) As Integer
    '
    '
    '/*************************************************************
    'Description:    //暂停继续运行
    'Input:          //卡链接handle
    'Output:         //
    'Return:         //错误码
    '*************************************************************/
    'int32 __stdcall ZMC_Resume(ZMC_HANDLE handle);
    Declare Function ZMC_Resume Lib "zmotion.dll" (ByVal handle As Integer) As Integer
    '
    '
    '/*************************************************************
    'Description:    //下载到ram中运行
    'Input:          //卡链接handle
    '                pfilename zar文件名, 带路径
    'Output:         //
    'Return:         //错误码
    '*************************************************************/
    'int32 __stdcall ZMC_DownZarToRamAndRun(ZMC_HANDLE handle, const char* pfilename);
    Declare Function ZMC_DownZarToRamAndRun Lib "zmotion.dll" (ByVal handle As Integer, ByVal pfilename As String) As Integer
    '
    '
    '/*************************************************************
    'Description:    //下载包到ram中运行
    'Input:          //卡链接handle
    '                pbuffer     zar文件在内存中的地址
    '                buffsize    zar文件长度
    'Output:         //
    'Return:         //错误码
    '*************************************************************/
    'int32 __stdcall ZMC_DownMemZarToRamAndRun(ZMC_HANDLE handle, const char* pbuffer, uint32 buffsize);
    Declare Function ZMC_DownMemZarToRamAndRun Lib "zmotion.dll" (ByVal handle As Integer, ByVal pbuffer As String, ByVal buffsize As Integer) As Integer
    '
    '
    '/*************************************************************
    'Description:    //打下载包ZAR， 并下载到RAM运行
    'Input:          //卡链接handle 文件名
    '                pZpjfilename 项目文件名 带路径
    '                pPass 软件密码, 绑定APP_PASS  没有密码时pPass = NULL
    '                uid 绑定控制器唯一ID， 0-不绑定
    'Output:         //
    'Return:         //错误码
    '*************************************************************/
    'int32 __stdcall ZMC_MakeZarAndRamRun(const char* pZpjfilename,const  char *pPass, uint32 uid);
    Declare Function ZMC_MakeZarAndRamRun Lib "zmotion.dll" (ByVal pzpjfilename As String, ByVal pPass As String, ByVal uid As Integer) As Integer
    '
    '
    '/*************************************************************
    'Description:    //打下载包ZAR， 并下载到RAM运行
    'Input:          //卡链接handle 文件名
    '                pzpj 文件缓冲
    '                pBasDir bas程序文件路径
    '                pPass 软件密码, 绑定APP_PASS  没有密码时pPass = NULL
    '                uid 绑定控制器唯一ID， 0-不绑定
    'Output:         //
    'Return:         //错误码
    '*************************************************************/
    'int32 __stdcall ZMC_MakeZarAndRamRun2(ZMC_HANDLE handle, void *pzpj,const char *pBasDir,const  char *pPass, uint32 uid);
    Declare Function ZMC_MakeZarAndRamRun2 Lib "zmotion.dll" (ByVal handle As Integer, ByRef pzpj As Integer, ByVal pBasDir As String, ByVal pPass As String, ByVal uid As Integer) As Integer
    '
    '/*************************************************************
    'Description:    //打下载包ZAR, 并下载到控制器ROM
    'Input:          //卡链接handle 文件名
    '                pZpjfilename 项目文件名 带路径
    '                pPass 软件密码, 绑定APP_PASS  没有密码时pPass = NULL
    '                uid 绑定控制器唯一ID， 0-不绑定
    'Output:         //
    'Return:         //错误码
    '*************************************************************/
    'int32 __stdcall ZMC_MakeZarAndDown(const char* pZpjfilename,const  char *pPass, uint32 uid);
    Declare Function ZMC_MakeZarAndDown Lib "zmotion.dll" (ByVal pzpjfilename As String, ByVal pPass As String, ByVal uid As Integer) As Integer
    '
    '
    '/*************************************************************
    'Description:    //打下载包ZAR, 并下载到控制器ROM
    'Input:          //卡链接handle 文件名
    '                pzpj 文件缓冲
    '                pBasDir bas程序文件路径
    '                pPass 软件密码, 绑定APP_PASS  没有密码时pPass = NULL
    '                uid 绑定控制器唯一ID， 0-不绑定
    'Output:         //
    'Return:         //错误码
    '*************************************************************/
    'int32 __stdcall ZMC_MakeZarAndDown2(ZMC_HANDLE handle, void *pzpj,const char *pBasDir,const  char *pPass, uint32 uid);
    Declare Function ZMC_MakeZarAndDown2 Lib "zmotion.dll" (ByVal handle As Integer, ByRef pzpj As Integer, ByVal pBasDir As String, ByVal pPass As String, ByVal uid As Integer) As Integer
    '
    '
    '/*************************************************************
    'Description:    //制作单文件的二进制ZPJ文件
    'Input:          //pBasfilename basic文件名，带路径
    'Output:         //pzpj     项目文件缓冲
    '                  pBasDir  BAS文件路径输出
    'Return:         //错误码
    '*************************************************************/
    'int32 __stdcall ZMC_MakeOneFileZpj(void *pZpjBuff,  char *pBasDir, const char* pBasfilename);
    Declare Function ZMC_MakeOneFileZpj Lib "zmotion.dll" (ByRef pZpjBuff As Integer, ByVal pBasDir As String, ByVal pBasfilename As String) As String
    '
    '
    '/*************************************************************
    'Description:    //ZPJ文件重新生成, 用于和上传的ZPJ比较是否修改.
    'Input:          //pZpjfilename 二进制zpj文件名，带路径
    'Output:         //
    '                pbuffer 缓冲，缓冲长度不能小于文件长度
    'Return:         //错误码
    '*************************************************************/
    'int32 __stdcall ZMC_MakeRealZpj(const char* pZpjfilename, char* pbuffer, uint32 buffsize);
    Declare Function ZMC_MakeRealZpj Lib "zmotion.dll" (ByVal pzpjfilename As String, ByVal pbuffer As String, ByVal buffsize As Integer) As Integer
    '
    '
    '/*************************************************************
    'Description:    //ZPJ文件重新生成, 用于和上传的ZPJ比较是否修改.
    '                  全部在buff里面
    'Input:          //pBasDir basic文件的路径
    '                pzpj 缓冲，二进制zpj文件， 同时作为输出
    'Output:         //
    'Return:         //错误码
    '*************************************************************/
    'int32 __stdcall ZMC_MakeRealZpjMem(const char* pBasDir, void *pzpj);
    Declare Function ZMC_MakeRealZpjMem Lib "zmotion" (ByVal pBasDir As String, ByRef pzpj As Integer) As Integer
    '
    '
    '/*************************************************************
    'Description:    //制作ZLIB文件
    'Input:          //pfilenameBas  basic 文件
    '                pfilenameZlb    zlb 文件
    'Output:         //
    'Return:         //错误码
    '*************************************************************/
    'int32 __stdcall ZMC_MakeZlib(const char* pfilenameBas, const char* pfilenameZlb);
    Declare Function ZMC_MakeZlib Lib "zmotion.dll" (ByVal pfilenameBas As String, ByVal pfilenameZlb As String) As Integer
    '
    '
    '/*************************************************************
    'Description:    //获取ZLIB文件的全局描述，包括变量，SUB等
    'Input:          //pfilenameZlb  lib文件名，带路径
    'Output:         //pbuffer 返回全局描述
    'Return:         //错误码
    '*************************************************************/
    'int32 __stdcall ZMC_GetZlibGlobalDefine(const char* pfilenameZlb, char* pbuffer, uint32 buffsize);
    Declare Function ZMC_GetZlibGlobalDefine Lib "zmotion.dll" (ByVal pfilenameZlb As String, ByVal pbuffer As String, ByVal buffsize As Integer) As Integer
    '
    '
    '/*************************************************************
    'Description:    //上传zpj，用于PC和控制器文件比较
    'Input:          //卡链接handle
    '                pbuffer 接收zpj文件的缓冲 buffsize 缓冲最大长度
    'Output:         //puifilesize 读取的zpj文件长度
    'Return:         //错误码
    '*************************************************************/
    'int32 __stdcall ZMC_UpCurZpjToMem(ZMC_HANDLE handle, char* pbuffer, uint32 buffsize, uint32* puifilesize);
    Declare Function ZMC_UpCurZpjToMem Lib "zmotion.dll" (ByVal handle As Integer, ByRef pbuffer As String, ByVal buffsize As Integer, ByRef puidilesize As Integer) As Integer
    '
    '
    '/*************************************************************
    'Description:    //暂停
    'Input:          //卡链接handle
    'Output:         //
    'Return:         //错误码
    '*************************************************************/
    'int32 __stdcall ZMC_Pause(ZMC_HANDLE handle);
    Declare Function ZMC_Pause Lib "zmotion.dll" (ByVal handle As Integer) As Integer
    '
    '
    '/*************************************************************
    'Description:    //停止
    'Input:          //卡链接handle
    'Output:         //
    'Return:         //错误码
    '*************************************************************/
    'int32 __stdcall ZMC_Stop(ZMC_HANDLE handle);
    Declare Function ZMC_Stop Lib "zmotion.dll" (ByVal handle As Integer) As Integer
    '
    '
    '
    '/*********************************************************
    '    3次文件功能暂时不支持.
    '**********************************************************/
    '
    '/*************************************************************
    'Description:    //检查文件是否存在
    'Input:          //卡链接handle 控制器上文件名，不带扩展
    'Output:         //
    'Return:         //错误码
    '*************************************************************/
    'int32 __stdcall ZMC_Check3File(ZMC_HANDLE handle, const char* pfilenameinControl, uint8 *pbIfExist, uint32 *pFileSize);
    Declare Function ZMC_Check3File Lib "zmotion.dll" (ByVal handle As Integer, ByVal pfilenameinControl As String, ByRef pbIfExist As Byte, ByRef pFileSize As Integer) As Integer
    '
    '
    '/*************************************************************
    'Description:    //查找控制器上的文件， 文件名为空表示文件不不存在
    'Input:          //卡链接handle 控制器上文件名，不带扩展
    'Output:         // 是否存在 文件大小
    'Return:         //错误码
    '*************************************************************/
    'int32 __stdcall ZMC_FindFirst3File(ZMC_HANDLE handle, char* pfilenameinControl, uint32 *pFileSize);
    Declare Function ZMC_FindFirsr3File Lib "zmotion.dll" (ByVal handle As Integer, ByVal pfilenameinControl As String, ByRef pFileSize As Integer) As Integer
    '
    '
    '/*************************************************************
    'Description:    //查找控制器上的文件， 文件名为空表示文件不不存在
    'Input:          //卡链接handle 控制器上文件名，不带扩展
    'Output:         // 是否存在 文件大小
    'Return:         //错误码
    '*************************************************************/
    'int32 __stdcall ZMC_FindNext3File(ZMC_HANDLE handle, char* pfilenameinControl, uint32 *pFileSize);
    Declare Function ZMC_FindNext3File Lib "zmotion.dll" (ByVal handle As Integer, ByVal pfilenameinControl As String, ByRef pFileSize As Integer) As Integer
    '
    '
    '/*************************************************************
    'Description:    //查找控制器上的当前文件
    'Input:          //卡链接handle 控制器上文件名，不带扩展
    'Output:         // 是否存在 文件大小(暂时不支持)
    'Return:         //错误码
    '*************************************************************/
    'int32 __stdcall ZMC_GetCur3File(ZMC_HANDLE handle, char* pfilenameinControl, uint32 *pFileSize);
    Declare Function ZMC_GetCur3File Lib "zmotion.dll" (ByVal handle As Integer, ByVal pfilenameinControl As String, ByRef pFileSize As Integer) As Integer
    '
    '
    '/*************************************************************
    'Description:    //删除控制器上的文件
    'Input:          //卡链接handle 控制器上文件名，不带扩展
    'Output:         //
    'Return:         //错误码
    '*************************************************************/
    'int32 __stdcall ZMC_Delete3File(ZMC_HANDLE handle, const char* pfilenameinControl);
    Declare Function ZMC_Delete3File Lib "zmotion.dll" (ByVal handle As Integer, ByVal pfilenameinControl As String) As Integer
    '
    '
    '/*************************************************************
    'Description:    //删除控制器上的文件
    'Input:          //卡链接handle
    'Output:         //
    'Return:         //错误码
    '*************************************************************/
    'int32 __stdcall ZMC_RemoveAll3Files(ZMC_HANDLE handle);
    Declare Function ZMC_RemoveAll3Files Lib "zmotion.dll" (ByVal handle As Integer) As Integer
    '
    '
    '/*************************************************************
    'Description:    //写用户flash块, float数据
    'Input:          //卡链接handle
    '                                       uiflashid       flash块号
    '                                       uinumes         变量个数
    'Output:         //
    'Return:         //错误码
    '*************************************************************/
    'int32 __stdcall ZMC_FlashWritef(ZMC_HANDLE handle, uint16 uiflashid, uint32 uinumes, float *pfvlue);
    Declare Function ZMC_FlashWritef Lib "zmotion.dll" (ByVal handle As Integer, ByVal uiflashid As Integer, ByVal uinumes As Integer, ByRef pfvlue As Single) As Integer
    '
    '
    '/*************************************************************
    'Description:    //读取用户flash块, float数据
    'Input:          //卡链接handle
    '                                       uiflashid       flash块号
    '                                       uibuffnum       缓冲变量个数
    'Output:         //
    '                                       puinumesread 读取到的变量个数
    'Return:         //错误码
    '*************************************************************/
    'int32 __stdcall ZMC_FlashReadf(ZMC_HANDLE handle, uint16 uiflashid, uint32 uibuffnum, float *pfvlue, uint32* puinumesread);
    Declare Function ZMC_FlashReadf Lib "zmotion.dll" (ByVal handle As Integer, ByVal uiflashid As Integer, ByVal uibuffnum As Integer, ByRef pfvlue As Single, ByRef puinumesread As Integer) As Integer
    '
    '
    '/*************************************************************
    'Description:    //读取当前控制器的IP地址,
    'Input:          //卡链接handle
    'Output:         //sIpAddr  返回IP地址，  注意:当设置dhcp以后，设置的IP与实际的不一致。
    'Return:         //错误码
    '*************************************************************/
    'int32 __stdcall ZMC_GetCurIpAddr(ZMC_HANDLE handle, char* sIpAddr);
    Declare Function ZMC_GetCurIpAddr Lib "zmotion.dll" (ByVal handle As Integer, ByVal sIpAddr As String) As Integer
    '
    '
    '/*************************************************************
    'Description:    //读取字符串在当前控制器上的类型
    'Input:          //卡链接handle
    'Output:         //type  类型，string_types
    '                  TYPE2 当类型为数组时，代表数组的长度
    '                  pvalue 变量直接返回值
    'Return:         //错误码
    '*************************************************************/
    'int32 __stdcall ZMC_GetStringType(ZMC_HANDLE handle, const char *sname, uint16 filenum, uint16* type, uint32* type2, double *pvalue);
    Declare Function ZMC_GetStringType Lib "zmotion.dll" (ByVal handle As Integer, ByVal sname As String, ByVal filenum As Integer, ByRef type As Integer, ByRef type2 As Integer, ByRef pvalue As Double) As Integer
    '
    'enum string_types
    '{
    '    STRING_USERSUB = 1,
    '    STRING_VARIABLE = 2,
    '    STRING_ARRAY = 3,
    '    STRING_PARA = 4,
    '
    '    STRING_CMD = 5,
    '    STRING_KEYWORD = 6, // AS 等关键词
    '
    '    STRING_LOCAL = 7, //局部定义
    '
    '    STRING_MODULE = 8, //局部定义
    '
    '    STRING_UNKOWN = 10,
    '};

    Const STRING_USERSUB = 1
    Const STRING_VARIABLE = 2
    Const STRING_ARRAY = 3
    Const STRING_PARA = 4

    Const STRING_CMD = 5
    Const STRING_KEYWORD = 6   'AS 等关键词

    Const STRING_LOCAL = 7   '局部定义

    Const STRING_MODULE = 8   '局部定义

    Const STRING_UNKOWN = 10
    '
    '
    '/*************************************************************
    'Description:    //IO接口 轴使能, 部分控制器不带轴使能的输出
    'Input:          //卡链接handle
    'Output:         //状态
    'Return:         //错误码
    '*************************************************************/
    'int32 __stdcall ZMC_SetAxisEnable(ZMC_HANDLE handle, uint8 iaxis, uint8 bifenable);
    Declare Function ZMC_SetAxisEnable Lib "zmotion.dll" (ByVal handle As Integer, ByVal iaxis As Byte, ByVal bifenable As Byte) As Integer
    '
    '
    '/*************************************************************
    'Description:    //IO接口 设置输出
    'Input:          //卡链接handle 1- IO开
    'Output:         //状态
    'Return:         //错误码
    '*************************************************************/
    'int32 __stdcall ZMC_SetOutput(ZMC_HANDLE handle, uint16 inum, uint8 iostate);
    Declare Function ZMC_SetOutput Lib "zmotion.dll" (ByVal handle As Integer, ByVal inum As Integer, ByVal iostate As Byte) As Integer
    '
    '
    '/*************************************************************
    'Description:    //IO接口 读取输入
    'Input:          //卡链接handle
    'Output:         //状态
    'Return:         //错误码
    '*************************************************************/
    'int32 __stdcall ZMC_GetIn(ZMC_HANDLE handle, uint16 inum, uint8* pistate);
    Declare Function ZMC_GetIn Lib "zmotion.dll" (ByVal handle As Integer, ByVal inum As Integer, ByRef pistate As Byte) As Integer
    '
    '
    '/*************************************************************
    'Description:    //IO接口 读取输出
    'Input:          //卡链接handle
    'Output:         //状态
    'Return:         //错误码
    '*************************************************************/
    'int32 __stdcall ZMC_GetOutput(ZMC_HANDLE handle, uint16 inum, uint8* pistate);
    Declare Function ZMC_GetOutput Lib "zmotion.dll" (ByVal handle As Integer, ByVal inum As Integer, ByRef pistate As Byte) As Integer
    '
    '
    'typedef struct
    '{
    '    uint8 m_HomeState; //
    '    uint8 m_AlarmState;
    '    uint8 m_SDState;
    '    uint8 m_INPState;
    '    uint8 m_ElDecState;
    '    uint8 m_ElPlusState;
    '    uint8 m_HandWheelAState;
    '    uint8 m_HandWheelBState;
    '    uint8 m_EncodeAState; //
    '    uint8 m_EncodeBState; //
    '    uint8 m_EMGState; //每个轴都一样
    '    uint8 m_ClearState; //
    '    uint8 m_EnableOut;
    '
    '    //增加软限位信号
    '    uint8 m_SoftElDecState; //0- 有效
    '    uint8 m_SoftElPlusState;
    '    uint8 m_LatchAState; //锁存信号
    '    uint8 m_LatchBState; //锁存信号
    '}struct_AxisStates;
    '
    Structure struct_AxisStates
        Dim m_HomeState As Byte         ' //
        Dim m_AlarmState As Byte
        Dim m_SDState As Byte
        Dim m_INPState As Byte
        Dim m_ElDecState As Byte
        Dim m_ElPlusState As Byte
        Dim m_HandWheelAState As Byte
        Dim m_HandWheelBState As Byte
        Dim m_EncodeAState As Byte                 '//
        Dim m_EncodeBState As Byte                 '//
        Dim m_EMGState As Byte                         '//每个轴都一样
        Dim m_ClearState As Byte                 '//
        Dim m_EnableOut As Byte

        '    //增加软限位信号
        Dim m_SoftElDecState As Byte                 '//0- 有效
        Dim m_SoftElPlusState As Byte
        Dim m_LatchAState As Byte                          '//锁存信号
        Dim m_LatchBState As Byte                          '//锁存信号
    End Structure
    '
    '
    '/*************************************************************
    'Description:    //IO接口 读取轴状态
    'Input:          //卡链接handle
    'Output:         //状态 struct_AxisStates
    'Return:         //错误码
    '*************************************************************/
    'int32 __stdcall ZMC_GetAxisStates(ZMC_HANDLE handle, uint8 iaxis, struct_AxisStates* pstrstates);
    Declare Function ZMC_GetAxisStates Lib "zmotion.dll" (ByVal handle As Integer, ByVal iaxis As Byte, ByRef pstrstates As Integer) As Integer
    '
    '/*************************************************************
    'Description:    //IO接口 读取AD
    'Input:          //卡链接handle
    'Output:         //状态
    'Return:         //错误码
    '*************************************************************/
    'int32 __stdcall ZMC_GetAIn(ZMC_HANDLE handle, uint16 inum, float* pfstate);
    Declare Function ZMC_GetAIn Lib "zmotion.dll" (ByVal handle As Integer, ByVal inum As Integer, ByRef pfstate As Single) As Integer
    '
    '
    '/*************************************************************
    'Description:    //IO接口 读取DA
    'Input:          //卡链接handle
    'Output:         //状态
    'Return:         //错误码
    '*************************************************************/
    'int32 __stdcall ZMC_GetDaOut(ZMC_HANDLE handle, uint16 inum, float* pfstate);
    Declare Function ZMC_GetDaOut Lib "zmotion.dll" (ByVal handle As Integer, ByVal inum As Integer, ByRef pfstate As Single) As Integer
    '
    '
    '/*************************************************************
    'Description:    //IO接口 设置DA
    'Input:          //卡链接handle
    'Output:         //状态
    'Return:         //错误码
    '*************************************************************/
    'int32 __stdcall ZMC_SetDaOut(ZMC_HANDLE handle, uint16 inum, float fstate);
    Declare Function ZMC_SetDaOut Lib "zmotion.dll" (ByVal handle As Integer, ByVal inum As Integer, ByVal fstate As Single) As Integer
    '
    '
    '/*************************************************************
    'Description:    //IO接口 设置输出
    'Input:          //卡链接handle
    'Output:         //状态
    'Return:         //错误码
    '*************************************************************/
    'int32 __stdcall ZMC_SetOutAll(ZMC_HANDLE handle, uint16 inumfirst,uint16 inumend, uint32 istate);
    Declare Function ZMC_SetOutAll Lib "zmotion.dll" (ByVal handle As Integer, ByVal inumfitst As Integer, ByVal inumend As Integer, ByVal istate As Integer) As Integer
    '
    '
    '/*************************************************************
    'Description:    //IO接口 读取输入口
    'Input:          //卡链接handle
    'Output:         //状态
    'Return:         //错误码
    '*************************************************************/
    'int32 __stdcall ZMC_GetInAll(ZMC_HANDLE handle, uint16 inumfirst,uint16 inumend, uint32* pistate);
    Declare Function ZMC_GetInAll Lib "zmotion.dll" (ByVal handle As Integer, ByVal inumfirst As Integer, ByVal inumend As Integer, ByRef pistate As Integer) As Integer
    '
    '
    '/*************************************************************
    'Description:    //IO接口 读取输出口
    'Input:          //卡链接handle
    'Output:         //状态
    'Return:         //错误码
    '*************************************************************/
    'int32 __stdcall ZMC_GetOutAll(ZMC_HANDLE handle, uint16 inumfirst,uint16 inumend, uint32* pistate);
    Declare Function ZMC_GetOutAll Lib "zmotion.dll" (ByVal handle As Integer, ByVal inumfirst As Integer, ByVal inumend As Integer, ByRef pistate As Integer) As Integer
    '
    '
    '
    '
    '
    '/*************************************************************
    'Description:    //modbus寄存器操作
    'Input:          //卡链接handle 寄存器地址
    'Output:         //
    'Return:         //错误码
    '*************************************************************/
    'uint32 __stdcall ZMC_Modbus_Set0x(ZMC_HANDLE handle, uint16 start, uint16 inum, uint8* pdata);
    'uint32 __stdcall ZMC_Modbus_Get0x(ZMC_HANDLE handle, uint16 start, uint16 inum, uint8* pdata);
    'uint32 __stdcall ZMC_Modbus_Set4x(ZMC_HANDLE handle, uint16 start, uint16 inum, uint16* pdata);
    'uint32 __stdcall ZMC_Modbus_Get4x(ZMC_HANDLE handle, uint16 start, uint16 inum, uint16* pdata);

    Declare Function ZMC_Modbus_Set0x Lib "zmotion.dll" (ByVal handle As Integer, ByVal start As Integer, ByVal inum As Integer, ByRef pdata As Byte) As Integer
    Declare Function ZMC_Modbus_Get0x Lib "zmotion.dll" (ByVal handle As Integer, ByVal start As Integer, ByVal inum As Integer, ByRef pdata As Byte) As Integer
    Declare Function ZMC_Modbus_Set4x Lib "zmotion.dll" (ByVal handle As Integer, ByVal start As Integer, ByVal inum As Integer, ByRef pdata As Integer) As Integer
    Declare Function ZMC_Modbus_Get4x Lib "zmotion.dll" (ByVal handle As Integer, ByVal start As Integer, ByVal inum As Integer, ByRef pdata As Integer) As Integer

    '
    '/*************************************************************
    'Description:    //把错误码转成描述字符串
    'Input:          //应答的消息
    'Output:         //
    'Return:         //错误码
    '*************************************************************/
    'const char* ZMC_GetErrcodeDescription(int32 ierrcode);
    Declare Function ZMC_GetErrcodeDescription Lib "zmotion.dll" (ByVal ierrcode As Integer) As String

    '
    '/*************************************************************
    'Description:    //检查程序语法
    '
    '暂时不提供
    '
    'Input:          //错误字符串缓存，至少1024字节
    'Output:         //
    'Return:         //错误码
    '*************************************************************/
    'int32 __stdcall ZMC_CheckProgramSyntax(const char *pzpjfilename, char *sError);
    Declare Function ZMC_CheckProgramSyntax Lib "zmotion.dll" (ByVal pzpjfilename As String, ByVal sError As String) As Integer
    '
    '
    '//轴特征位
    'enum AXIS_FEATURE_BIT
    '{
    '    AXIS_FEATURE_STEPPER = 0, //  步进  脉冲方向
    '    AXIS_FEATURE_STEPPER_DOUBLE = 1, //  步进 双脉冲
    '    AXIS_FEATURE_STEPPER_AB = 2, //  步进 A, B相
    '
    '    AXIS_FEATURE_ENCODER = 4, // 支持配置为编码器, 正交,
    '    AXIS_FEATURE_ENCODER_PULDIR = 5, // 脉冲方向方式的编码器
    '    AXIS_FEATURE_ENCODER_DOUBLE = 6, // 双脉冲编码器
    '
    '    AXIS_FEATURE_ENCODER_SSI = 7, //
    '    AXIS_FEATURE_ENCODER_TAMA = 8, //
    '    AXIS_FEATURE_ENCODER_ENDAT = 9, //
    '
    '
    '    AXIS_FEATURE_WITH_EZ = 10, // 有EZ输入，可以和步进一起使用
    '    AXIS_FEATURE_SERVODAC = 11, // dac 伺服
    '    AXIS_FEATURE_STEPCODER = 12, // 特殊的类型 步进和编码器一起使用
    '
    '    AXIS_FEATURE_CANOPEN = 13, //  后面的暂时不支持
    '    //AXIS_FEATURE_ZCAN = 14, // 支持配置为ZCAN, 这个可以和其他的类型一起合并
    '
    '
    '};
    '
    Const AXIS_FEATURE_STEPPER = 0                            '//  步进  脉冲方向
    Const AXIS_FEATURE_STEPPER_DOUBLE = 1             ' //  步进 双脉冲
    Const AXIS_FEATURE_STEPPER_AB = 2                 ' //  步进 A, B相

    Const AXIS_FEATURE_ENCODER = 4                ' // 支持配置为编码器, 正交,
    Const AXIS_FEATURE_ENCODER_PULDIR = 5         '// 脉冲方向方式的编码器
    Const AXIS_FEATURE_ENCODER_DOUBLE = 6         ' // 双脉冲编码器

    Const AXIS_FEATURE_ENCODER_SSI = 7
    Const AXIS_FEATURE_ENCODER_TAMA = 8
    Const AXIS_FEATURE_ENCODER_ENDAT = 9

    Const AXIS_FEATURE_WITH_EZ = 10               ' // 有EZ输入，可以和步进一起使用
    Const AXIS_FEATURE_SERVODAC = 11              ' // dac 伺服
    Const AXIS_FEATURE_STEPCODER = 12             ' // 特殊的类型 步进和编码器一起使用

    Const AXIS_FEATURE_CANOPEN = 13               ' //  后面的暂时不支持
    Const AXIS_FEATURE_ZCAN = 14                              ' // 支持配置为ZCAN, 这个可以和其他的类型一起合并


    '/*************************************************************
    'Description:    //读取控制器轴规格
    'Input:          //卡链接handle
    '                  iaxis     轴号
    'Output:         //pfeatures 规格
    'Return:         //错误码
    '*************************************************************/
    'int32 __stdcall ZMC_GetAxisFeatures(ZMC_HANDLE handle, uint8 iaxis, uint32 *pfeatures);
    Declare Function ZMC_GetAxisFeatures Lib "zmotion.dll" (ByVal handle As Integer, ByVal iaxis As Byte, ByRef pfeatures As Integer) As Integer
    '
    '
    'typedef  struct
    '{
    '    //主要规格
    '    uint8   m_bIfSupportBasic; //
    '    uint8   m_bIfSupportPLC; // 是否支持PLC程序
    '    uint8   m_bIfSupportRamRun; // 下载到RAM运行
    '    uint8   m_bIfLocked; // 是否LOCK
    '
    '    //轴数规格
    '    uint16  m_MaxVirtuAxises;
    '    uint8   m_MaxAxises;
    '    uint8   m_MaxBreakes;  // 最多断点数
    '    //IO规格
    '    uint8   m_MaxInController;
    '    uint8   m_MaxOutController;
    '    uint8   m_MaxAdController;
    '    uint8   m_MaxDaController;
    '
    '    //存储规格
    '    uint32  m_MaxProgramSpaceinKB;  // 总程序空间
    '    uint32  m_MaxNandSpaceinKB;
    '    uint32  m_MaxNandSpaceRemaininKB; //剩余的空间
    '
    '    //modbus寄存器规格
    '    uint16  m_MaxModbusBits;
    '    uint16  m_MaxModbusRegs;
    '
    '    //下面为BASIC规格
    '    uint16  m_MaxFiles;     //系统支持程序文件数
    '    uint8   m_Max3Files;
    '    //uint8   m_bIfSupport3File; // 3次文件.
    '    uint8   m_bReserve;
    '
    '       //trio兼容
    '    uint32  m_MaxTable;
    '    uint32  m_MaxVr;
    '
    '    uint16  m_MaxTaskes;    //系统任务数
    '    uint16  m_MaxTimeres;   //最大TIMES数
    '
    '    uint16  m_MaxVarNum; //    变量数
    '    uint16  m_MaxArrayNum; //
    '
    '    uint32  m_MaxArraySpace; //
    '
    '    uint16  m_MaxSubes; //
    '    uint16  m_MaxStackes; //
    '
    '    uint16  m_MaxExpressionLayeres; //  表达式复杂程度
    '    uint16  m_MaxLabelChares;  //名称字符数
    '
    '
    '
    '
    '
    '}struct_SysMaxSpecification;
    '
    '
    Structure struct_SysMaxSpecification

        '    //主要规格
        Dim m_bIfSupportBasic As Byte         ' //
        Dim m_bIfSupportPLC As Byte         ' // 是否支持PLC程序
        Dim m_bIfSupportRamRun As Byte         ' // 下载到RAM运行
        Dim m_bIfLocked As Byte         ' // 是否LOCK
        '
        '    //轴数规格
        Dim m_MaxVirtuAxises As Byte
        Dim m_MaxAxises As Byte
        Dim m_MaxBreakes As Byte         '  // 最多断点数
        '    //IO规格
        Dim m_MaxInController As Byte
        Dim m_MaxOutController As Byte
        Dim m_MaxAdController As Byte
        Dim m_MaxDaController As Byte
        '
        '    //存储规格
        Dim m_MaxProgramSpaceinKB As Integer '  // 总程序空间
        Dim m_MaxNandSpaceinKB As Integer
        Dim m_MaxNandSpaceRemaininKB As Integer ' //剩余的空间
        '
        '    //modbus寄存器规格
        Dim m_MaxModbusBits As Integer
        Dim m_MaxModbusRegs As Integer
        '
        '    //下面为BASIC规格
        Dim m_MaxFiles As Integer      '     //系统支持程序文件数
        Dim m_Max3Files As Byte
        Dim m_bIfSupport3File As Byte ' // 3次文件.
        Dim m_bReserve As Byte
        '
        '       //trio兼容
        Dim m_MaxTable As Integer
        Dim m_MaxVr As Integer
        '
        Dim m_MaxTaskes As Integer '    //系统任务数
        Dim m_MaxTimeres As Integer '   //最大TIMES数
        '
        Dim m_MaxVarNum As Integer      ' //    变量数
        Dim m_MaxArrayNum As Integer      ' //
        '
        Dim m_MaxArraySpace As Integer ' //
        '
        Dim m_MaxSubes As Integer      ' //
        Dim m_MaxStackes As Integer      ' //
        '
        Dim m_MaxExpressionLayeres As Integer      ' //  表达式复杂程度
        Dim m_MaxLabelChares As Integer      '  //名称字符数
        '
    End Structure
    '

    '
    '/*************************************************************
    'Description:    //读取控制器规格
    'Input:          //卡链接handle
    'Output:         //
    'Return:         //错误码
    '*************************************************************/
    'int32 __stdcall ZMC_GetSysSpecification(ZMC_HANDLE handle, struct_SysMaxSpecification *pspeci);
    Declare Function ZMC_GetSysSpecification Lib "zmotion.dll" (ByVal handle As Integer, ByRef pspeci As Integer) As Integer
    '
    '
    '/*************************************************************
    'Description:    //读取脚本输出的信息
    'Input:          //卡链接handle
    'Output:         //
    'Return:         //错误码
    '*************************************************************/
    'int32 __stdcall ZMC_ReadMessage(ZMC_HANDLE handle, char * pbuff, uint32 uimax, uint32 *puiread);
    '
    Declare Function ZMC_ReadMessage Lib "zmotion.dll" (ByVal handle As Integer, ByVal pbuff As String, ByVal uimax As Integer, ByRef puiread As Integer) As Integer
    '
    '/*************************************************************
    'Description:    //单步执行
    'Input:          //
    '// 单步定义
    'enum ZBASIC_STEPMODE
    '{
    '    STEP_MODE_NONE = 0,
    '    STEP_MODE_IN = 1,  // 跳到里面
    '    STEP_MODE_NEXT = 2,  // 跳到 下一个
    '    STEP_MODE_OUT = 3,  // 跳到 上层
    '    STEP_MODE_SPECIALLINE = 4,  // 跳到 指定行
    '};
    '                               ifilenum:指定行的时候使用
    'Output:         //
    'Return:         //错误码
    '*************************************************************/
    'int32 __stdcall ZMC_StepRun(ZMC_HANDLE handle, uint16 taskid, uint8 Stepmode, uint8 bifBreakAll, uint8 ifilenum, uint32 iLineNum);
    Declare Function ZMC_StepRun Lib "zmotion.dll" (ByVal handle As Integer, ByVal taskid As Integer, ByVal Stepmode As Byte, ByVal bifBreakAll As Byte, ByVal ifilenum As Byte, ByVal ilinenum As Integer) As Integer
    '
    '
    'enum ZBASIC_STEPMODE
    '{
    '    STEP_MODE_NONE = 0,
    '    STEP_MODE_IN = 1,  // 跳到里面
    '    STEP_MODE_NEXT = 2,  // 跳到 下一个
    '    STEP_MODE_OUT = 3,  // 跳到 上层
    '    STEP_MODE_SPECIALLINE = 4,  // 跳到 指定行
    '};
    Const STEP_MODE_NONE = 0
    Const STEP_MODE_IN = 1                   '// 跳到里面
    Const STEP_MODE_NEXT = 2                 ' // 跳到 下一个
    Const STEP_MODE_OUT = 3                  ' // 跳到 上层
    Const STEP_MODE_SPECIALLINE = 4                  '// 跳到 指定行
    '
    'typedef struct
    '{
    '
    '    //硬件ID
    '    uint32 m_hardid;
    '
    '    uint16 m_cardid; // 对编号一致
    '
    '    //
    '    uint8 m_imaxin;
    '    uint8 m_imaxout;
    '    uint8 m_imaxad;
    '    uint8 m_imaxda;
    '
    '    //轴数，非0表示带轴
    '    uint8 m_iAxises;
    '
    '}struct_ChildCardInfo;
    '
    '
    Structure struct_ChildCardInfo
        '    //硬件ID
        Dim m_hardid As Integer
        '
        Dim m_cardid As Integer      '//编号一致
        '
        '    //
        Dim m_imaxin As Byte
        Dim m_imaxout As Byte
        Dim m_imaxad As Byte
        Dim m_imaxda As Byte
        '
        '    //轴数，非0表示带轴
        Dim m_iAxises As Byte

    End Structure
    '
    '/*************************************************************
    'Description:    //取消当前正在执行的命令
    'Input:          //卡链接handle
    'Output:         //
    'Return:         //错误码
    '*************************************************************/
    'int32 __stdcall ZMC_CancelOnline(ZMC_HANDLE handle);
    Declare Function ZMC_CancelOnline Lib "zmotion.dll" (ByVal handle As Integer) As Integer
    '
    '/*************************************************************
    'Description:    //断点, LIB文件里面不能增加断点.
    'Input:          //卡链接handle 行号 从0 开始编号
    'Output:         //
    'Return:         //错误码
    '*************************************************************/
    'int32 __stdcall ZMC_BreakAdd(ZMC_HANDLE handle, const char* filenamenoext, uint32 ilinenum, uint8 bifPauseAll);
    Declare Function ZMC_BreakAdd Lib "zmotion.dll" (ByVal handle As Integer, ByVal filenamenoext As String, ByVal ilinenum As Integer, ByVal bifPauseAll As Byte) As Integer
    '
    '
    '/*************************************************************
    'Description:    //断点, LIB文件里面不能增加断点.
    'Input:          //卡链接handle 行号 从0 开始编号
    'Output:         //
    'Return:         //错误码
    '*************************************************************/
    'int32 __stdcall ZMC_BreakDel(ZMC_HANDLE handle, const char* filenamenoext, uint32 ilinenum);
    Declare Function ZMC_BreakDel Lib "zmotion.dll" (ByVal handle As Integer, ByVal filenamenoext As String, ByVal ilinenum As Integer) As Integer
    '
    '
    '/*************************************************************
    'Description:    //断点清除
    'Input:          //卡链接handle
    'Output:         //
    'Return:         //错误码
    '*************************************************************/
    'int32 __stdcall ZMC_BreakClear(ZMC_HANDLE handle);
    Declare Function ZMC_BreakClear Lib "zmotion.dll" (ByVal handle As Integer) As Integer



End Module
