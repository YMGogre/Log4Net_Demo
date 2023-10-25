using PostSharp.Patterns.Diagnostics;

namespace WinFormsApp4DotNet
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        internal void OnButtonClick()
        {
            /// <see cref="FormattedMessageBuilder.Formatted(string)"/> 方法用于创建格式化的消息。该方法会返回一个实现了 
            /// <see cref="PostSharp.Patterns.Diagnostics.Custom.Messages.IMessage"/> 接口的对象，包含了想要记录的日志消息。
            /// 调用 <see cref="LogSource.Info.Write{T}(in T, in WriteMessageOptions)"/> 方法时，PostSharp [Logging] 会将这个消息记录到日志中。
            LogSource.Get().Info.Write(FormattedMessageBuilder.Formatted("按下了测试按钮"));
            /// 上面的语句在需要自定义日志输出消息的场合比较有用。但显然这又需要去修改源代码，这违背了 AOP 的初衷。
            /// 如果您需要在不修改源代码的情况下记录自定义的日志，那么，创建一个自定义切面可能是一个比较好的解决方案：
            /// 比如继承 PostSharp 的 <see cref="PostSharp.Aspects.OnMethodBoundaryAspect"/>，然后重写
            /// <see cref="PostSharp.Aspects.OnMethodBoundaryAspect.OnEntry(PostSharp.Aspects.MethodExecutionArgs)"/> 等方法
        }

        internal void OnExceptionButtonClick()
        {
            throw new Exception("按下按钮，抛出了一个异常");
        }

        internal void OnCatchedExceptionButtonClick()
        {
            try
            {
                throw new Exception("按下按钮，抛出一个会被捕获的异常");
            }
            catch { }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OnButtonClick();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OnExceptionButtonClick();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OnCatchedExceptionButtonClick();
        }
    }
}