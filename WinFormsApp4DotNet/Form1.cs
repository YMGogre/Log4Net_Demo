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
            /// <see cref="FormattedMessageBuilder.Formatted(string)"/> �������ڴ�����ʽ������Ϣ���÷����᷵��һ��ʵ���� 
            /// <see cref="PostSharp.Patterns.Diagnostics.Custom.Messages.IMessage"/> �ӿڵĶ��󣬰�������Ҫ��¼����־��Ϣ��
            /// ���� <see cref="LogSource.Info.Write{T}(in T, in WriteMessageOptions)"/> ����ʱ��PostSharp [Logging] �Ὣ�����Ϣ��¼����־�С�
            LogSource.Get().Info.Write(FormattedMessageBuilder.Formatted("�����˲��԰�ť"));
            /// ������������Ҫ�Զ�����־�����Ϣ�ĳ��ϱȽ����á�����Ȼ������Ҫȥ�޸�Դ���룬��Υ���� AOP �ĳ��ԡ�
            /// �������Ҫ�ڲ��޸�Դ���������¼�¼�Զ������־����ô������һ���Զ������������һ���ȽϺõĽ��������
            /// ����̳� PostSharp �� <see cref="PostSharp.Aspects.OnMethodBoundaryAspect"/>��Ȼ����д
            /// <see cref="PostSharp.Aspects.OnMethodBoundaryAspect.OnEntry(PostSharp.Aspects.MethodExecutionArgs)"/> �ȷ���
        }

        internal void OnExceptionButtonClick()
        {
            throw new Exception("���°�ť���׳���һ���쳣");
        }

        internal void OnCatchedExceptionButtonClick()
        {
            try
            {
                throw new Exception("���°�ť���׳�һ���ᱻ������쳣");
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