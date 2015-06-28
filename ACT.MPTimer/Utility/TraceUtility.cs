namespace ACT.MPTimer.Utility
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using System.Windows.Forms;

    public static class TraceUtility
    {
        private static CustomTraceListener listener;

        public static void Initialize()
        {
            if (listener == null)
            {
                listener = new CustomTraceListener(Assembly.GetExecutingAssembly());

                Trace.Listeners.Remove("Default");
                Trace.Listeners.Add(listener);
            }
        }

        public static RichTextBox LogTextBox
        {
            get { return listener.LogTextBox; }
            set { listener.LogTextBox = value; }
        }
    }

    public class CustomTraceListener : TraceListener
    {
        private DefaultTraceListener defaultListener = new DefaultTraceListener();

        public RichTextBox LogTextBox { get; set; }

        private string logFile;

        private List<string> logBuffer = new List<string>();

        public CustomTraceListener(
            Assembly assembly)
        {
            this.Name = assembly.GetName().Name;

            this.logFile = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                @"anoyetta\ACT\" + this.Name + ".log");

            var dir = Path.GetDirectoryName(this.logFile);
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }
        }

        public override void Write(string message)
        {
            try
            {
                var frames = new StackTrace().GetFrames();

                // 同じAssemblyのメソッドから呼ばれているか？
                var any = frames.Any(x =>
                    x.GetMethod().DeclaringType != MethodBase.GetCurrentMethod().DeclaringType &&
                    x.GetMethod().ReflectedType.FullName.Contains(this.Name));

                if (!any)
                {
                    return;
                }

                var log =
                    DateTime.Now.ToString("[yyyy/MM/dd HH:mm:ss.fff]") + " " +
                    message;

                this.defaultListener.Write(log);

                if (this.LogTextBox != null)
                {
                    this.LogTextBox.AppendText(log);
                }

                // ログファイルに出力する
                lock (this.logBuffer)
                {
                    this.logBuffer.Add(log);

                    if (this.logBuffer.Count >= 64)
                    {
                        foreach (var text in this.logBuffer)
                        {
                            File.AppendAllText(this.logFile, text);
                        }

                        this.logBuffer.Clear();
                    }
                }
            }
            catch
            {
            }
        }

        public override void WriteLine(string message)
        {
            this.Write(message + Environment.NewLine);
        }
    }
}
