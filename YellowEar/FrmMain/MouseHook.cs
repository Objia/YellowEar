using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Windows.Forms;

namespace YellowEar
{
    public class MouseHook
    {


        /**************************************************/
        //鼠标消息和鼠标事件的区别:
        //    鼠标消息包含按键标识和具体行为，如以下鼠标消息号
        //    鼠标事件则不包含按键标识，只有MouseDown,MouseUp,MouseMove,MouseWheel,Click,DoubleClick等具体行为
        /**************************************************/
        //鼠标消息号
        private const int WM_NCHITTEST = 0x0084;//鼠标击中测试，所有鼠标消息最先产生的消息
        private const int WM_MOUSEMOVE = 0x200; //移动鼠标时发生，同WM_MOUSEFIRST
        private const int WM_LBUTTONDOWN = 0x201; //按下鼠标左键
        private const int WM_LBUTTONUP = 0x202; //释放鼠标左键
        private const int WM_LBUTTONDBLCLK = 0x203;//双击鼠标左键
        private const int WM_RBUTTONDOWN = 0x204;//按下鼠标右键
        private const int WM_RBUTTONUP = 0x205;//释放鼠标右键
        private const int WM_RBUTTONDBLCLK = 0x206; //双击鼠标右键
        private const int WM_MBUTTONDOWN = 0x207; //按下鼠标中键
        private const int WM_MBUTTONUP = 0x208;//释放鼠标中键
        private const int WM_MBUTTONDBLCLK = 0x209;//双击鼠标中键
        private const int WM_MOUSEWHEEL = 0x020A;//鼠标滚轮滚动
        private const int WM_NCMOUSEMOVE = 0x00A0; //在非客户区移动鼠标时发生
        private const int WM_NCLBUTTONDOWN = 0x00A1; //在非客户区按下鼠标左键
        private const int WM_NCLBUTTONUP = 0x00A2; //在非客户区释放鼠标左键
        private const int WM_NCLBUTTONDBLCLK = 0x00A3;//在非客户区双击鼠标左键
        private const int WM_NCRBUTTONDOWN = 0x00A4;//在非客户区按下鼠标右键
        private const int WM_NCRBUTTONUP = 0x00A5;//在非客户区释放鼠标右键
        private const int WM_NCRBUTTONDBLCLK = 0x00A6; //在非客户区双击鼠标右键
        private const int WM_NCMBUTTONDOWN = 0x00A7; //在非客户区按下鼠标中键
        private const int WM_NCMBUTTONUP = 0x00A8;//在非客户区释放鼠标中键
        private const int WM_NCMBUTTONDBLCLK = 0x00A9;//在非客户区双击鼠标中键
        private const int WM_SYSCOMMAND = 0x0112;

        //WM_NCHITTEST消息的返回值
        private const int HTCAPTION = 2;//标题栏
        private const int HTLEFT = 10;    //左边界
        private const int HTRIGHT = 11;   //右边界
        private const int HTTOP = 12; //上边界
        private const int HTTOPLEFT = 13; //左上角
        private const int HTTOPRIGHT = 14;    //右上角
        private const int HTBOTTOM = 15;  //下边界
        private const int HTBOTTOMLEFT = 16;    //左下角
        private const int HTBOTTOMRIGHT = 17; //右下角

        //WM_SYSCOMMAND消息的wParam参数可选值
        private const int SC_MOVE = 0xF010;//窗口移动
        private const int SC_DRAGMOVE = 0xF012;//拖曳移动【在MSDN中并没有这个常量的定义，但确实有用，可以理解为SC_MOVE+HTCAPTION，实际上这个常量的值设置为SC_MOVE+任一上述WM_NCHITTEST消息的返回值均有效】

        public const int WH_MOUSE_LL = 14; // 鼠标钩子标识号HookID，线程鼠标钩子为7，全局鼠标钩子为14
        public const int WH_MOUSE = 7;

        //在非托管代码时，不能使用c#的对象，只能自己定义可序列化的结构类/class和struct关键字均可,使用StructLayout属性后，数据成员的顺序不能更改
        [StructLayout(LayoutKind.Sequential)]
        protected class POINT
        {
            public int x;
            public int y;
        }
        /// <summary>
        /// 鼠标钩子结构体
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        protected class MSLLHookStruct
        {
            public POINT pt;//鼠标坐标，相对于屏幕
            public int mouseData;//鼠标滚轮信息或X键信息
            public int flags;//事件注入标志
            public int time;//时间戳
            public int dwExtraInfo;//额外信息
        }

        [StructLayout(LayoutKind.Sequential)]
        protected class MouseHookStruct
        {
            public POINT pt;//鼠标坐标，相对于屏幕
            public int hwnd;
            public int wHitTestCode;//WM_NCHITTEST消息的返回值,表示击中区域
            public int dwExtraInfo;
        }

        /// <summary>
        /// 安装消息钩子
        /// </summary>
        /// <param name="idHook">钩子类型ID</param>
        /// <param name="lpfn">钩子处理函数的委托</param>
        /// <param name="hInstance">当前进程句柄</param>
        /// <param name="threadID">线程句柄</param>
        /// <returns>安装失败则返回0，成功返回钩子句柄</returns>
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern int SetWindowsHookEx(int idHook, HookProc lpfn, IntPtr hInstance, int threadID);

        /// <summary>
        /// 卸载消息钩子
        /// </summary>
        /// <param name="idHook">需要卸载的钩子句柄，此标识由SetWindowsHookEx函数生成</param>
        /// <returns>成功返回true，失败返回false</returns>
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern bool UnhookWindowsHookEx(int idHook);

        /// <summary>
        /// 将钩子信息传递到当前钩子链中的下一个钩子程序
        /// </summary>
        /// <param name="idHook">当前钩子句柄</param>
        /// <param name="nCode"></param>
        /// <param name="wParam"></param>
        /// <param name="lParam"></param>
        /// <returns></returns>
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern int CallNextHookEx(int idHook, int nCode, Int32 wParam, IntPtr lParam);

        /// <summary>
        /// 通过进程模块获取进程句柄
        /// </summary>
        /// <param name="name">进程模块名</param>
        /// <returns>进程句柄</returns>
        [DllImport("kernel32.dll")]
        public static extern IntPtr GetModuleHandle(string name);

        /// <summary>
        /// 取得当前线程编号（线程钩子需要用到）
        /// </summary>
        /// <returns></returns>
        [DllImport("kernel32.dll")]
        static extern int GetCurrentThreadId();

        [DllImport("user32.dll", EntryPoint = "PostMessage")]
        public static extern int PostMessage(IntPtr hwnd, int Msg, int wParam, int lParam);



        public delegate int HookProc(int nCode, Int32 wParam, IntPtr lParam);
        private HookProc HookProcdure;
        private static int HookHandle=0;
        public bool isStarted;
        frmMain hookForm;
        public MouseHook( frmMain form)
        {
            Application.ApplicationExit += new EventHandler(Stop_Before_AppExit);
            hookForm = form;
            HookProcdure = new HookProc(HookProcFunction);
        }
        private void Stop_Before_AppExit(object sender,EventArgs e)
        {
            if(isStarted)
            {
                Stop();
            }
        }

        public void Start()
        {
            if(!isStarted)
            {
                //全局钩子
                //HookHandle = SetWindowsHookEx(
                //    WH_MOUSE_LL,
                //    HookProcdure,
                //    GetModuleHandle(Process.GetCurrentProcess().MainModule.ModuleName),
                //    0);

                //线程钩子
                HookHandle = SetWindowsHookEx(
                    WH_MOUSE,
                    HookProcdure,
                    IntPtr.Zero,
                    GetCurrentThreadId());
                if (HookHandle!=0)
                {
                    isStarted = true;
                }
                else
                {
                    Stop();
                    throw new Exception("安装鼠标钩子失败");
                }
            }
        }
        public void Stop()
        {
            if(isStarted)
            {
                if(UnhookWindowsHookEx(HookHandle))
                {
                    isStarted=false;
                }
                else
                {
                    throw new Exception("卸载鼠标钩子失败");
                }
            }
        }

        private int HookProcFunction(int nCode,Int32 wParam,IntPtr lParam)//wParam是一个鼠标消息号（类似WM_RBUTTONDOWN），lParam参数包含了鼠标点击坐标和滚轮信息
        {
            if (nCode >= 0)
            {
                MouseHookStruct mouseHookStruct = (MouseHookStruct)Marshal.PtrToStructure(lParam, typeof(MouseHookStruct));
                Point clientPoint = hookForm.PointToClient(new Point(mouseHookStruct.pt.x, mouseHookStruct.pt.y));
                //检查鼠标是否在主窗体上
                Control control = Control.FromHandle(new IntPtr(mouseHookStruct.hwnd));
                while ( control!=null&&control.Parent!=null)
                {
                    control = control.Parent;
                }
                if(control!=null)
                {
                    if (control.Handle.ToInt32() == hookForm.Handle.ToInt32())
                    {
                        if (((5 - clientPoint.X) >= 0 && clientPoint.X >= 0) || ((hookForm.Width - clientPoint.X) <= 5 && hookForm.Width >= clientPoint.X) || ((5 - clientPoint.Y) >= 0 && clientPoint.Y >= 0) || ((hookForm.Height - clientPoint.Y) <= 5) && hookForm.Height >= clientPoint.Y)
                        {
                            //左上角
                            if (((5 - clientPoint.X) >= 0 && (5 - clientPoint.Y) >= 0))
                            {
                                hookForm.Cursor = Cursors.SizeNWSE;
                                switch (wParam)
                                {
                                    case WM_LBUTTONDOWN:
                                        PostMessage(hookForm.Handle, WM_NCLBUTTONDOWN, HTTOPLEFT, (mouseHookStruct.pt.y << 16 | mouseHookStruct.pt.x));
                                        return 1;
                                }
                            }
                            //右下角
                            else if (((hookForm.Width - clientPoint.X) <= 5 && (hookForm.Height - clientPoint.Y) <= 5))
                            {
                                hookForm.Cursor = Cursors.SizeNWSE;
                                switch (wParam)
                                {
                                    case WM_LBUTTONDOWN:
                                        PostMessage(hookForm.Handle, WM_NCLBUTTONDOWN, HTBOTTOMRIGHT, (mouseHookStruct.pt.y << 16 | mouseHookStruct.pt.x));
                                        return 1;
                                }
                            }
                            //左下角
                            else if ((5 - clientPoint.X) >= 0 && (hookForm.Height - clientPoint.Y) <= 5)
                            {
                                hookForm.Cursor = Cursors.SizeNESW;
                                switch (wParam)
                                {
                                    case WM_LBUTTONDOWN:
                                        PostMessage(hookForm.Handle, WM_NCLBUTTONDOWN, HTBOTTOMLEFT, (mouseHookStruct.pt.y << 16 | mouseHookStruct.pt.x));
                                        return 1;
                                }
                            }
                            //右上角
                            else if ((hookForm.Width - clientPoint.X) <= 5 && (5 - clientPoint.Y) >= 0)
                            {
                                hookForm.Cursor = Cursors.SizeNESW;
                                switch (wParam)
                                {
                                    case WM_LBUTTONDOWN:
                                        PostMessage(hookForm.Handle, WM_NCLBUTTONDOWN, HTTOPRIGHT, (mouseHookStruct.pt.y << 16 | mouseHookStruct.pt.x));
                                        return 1;
                                }
                            }
                            else if ((5 - clientPoint.X) >= 0 || (hookForm.Width - clientPoint.X) <= 5)//左/右边框
                            {
                                hookForm.Cursor = Cursors.SizeWE;
                                if ((5 - clientPoint.X) >= 0)//左边框
                                {
                                    switch (wParam)
                                    {
                                        case WM_LBUTTONDOWN:
                                            PostMessage(hookForm.Handle, WM_NCLBUTTONDOWN, HTLEFT, (mouseHookStruct.pt.y << 16 | mouseHookStruct.pt.x));
                                            return 1;
                                    }
                                }
                                else//右边框
                                {
                                    switch (wParam)
                                    {
                                        case WM_LBUTTONDOWN:
                                            PostMessage(hookForm.Handle, WM_NCLBUTTONDOWN, HTRIGHT, (mouseHookStruct.pt.y << 16 | mouseHookStruct.pt.x));
                                            return 1;
                                    }
                                }
                            }
                            else//上/下边框
                            {
                                hookForm.Cursor = Cursors.SizeNS;
                                if ((5 - clientPoint.Y) >= 0)//上边框
                                {
                                    switch (wParam)
                                    {
                                        case WM_LBUTTONDOWN:
                                            PostMessage(hookForm.Handle, WM_NCLBUTTONDOWN, HTTOP, (mouseHookStruct.pt.y << 16 | mouseHookStruct.pt.x));
                                            return 1;
                                    }
                                }
                                else//下边框
                                {
                                    switch (wParam)
                                    {
                                        case WM_LBUTTONDOWN:
                                            PostMessage(hookForm.Handle, WM_NCLBUTTONDOWN, HTBOTTOM, (mouseHookStruct.pt.y << 16 | mouseHookStruct.pt.x));
                                            return 1;
                                    }
                                }
                            }
                        }
                        //鼠标在标题栏除关闭和最小化按钮以外的位置
                        else if (0 <= clientPoint.X && clientPoint.X <= (hookForm.Width - 53) && 0 <= clientPoint.Y && clientPoint.Y <= 19)
                        {
                            hookForm.Cursor = Cursors.Arrow;
                            switch (wParam)
                            {
                                case WM_LBUTTONDOWN:
                                    PostMessage(hookForm.Handle, WM_NCLBUTTONDOWN, HTCAPTION, (mouseHookStruct.pt.y << 16 | mouseHookStruct.pt.x));
                                    hookForm.isPnlTopMouseDown = true;
                                    return 1;
                                case WM_LBUTTONUP:
                                    hookForm.isPnlTopMouseDown = false;
                                    break;
                            }
                        }
                        //鼠标在自定义窗体客户区内部
                        else
                        {
                            hookForm.Cursor = Cursors.Arrow;
                        }
                    }
                }
            }

            //如果返回1，则结束消息，这个消息到此为止，不再传递。
            //如果返回0或调用CallNextHookEx函数则消息出了这个钩子继续往下传递，也就是传给消息真正的接受者
            return CallNextHookEx(HookHandle, nCode, wParam, lParam);
        }

        /// <summary>
        /// 析构函数
        /// </summary>
        ~MouseHook()
        {
            Stop();
        }
    }
}
