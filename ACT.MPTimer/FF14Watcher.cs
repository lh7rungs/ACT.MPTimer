namespace ACT.MPTimer
{
    using System;
    using System.Diagnostics;
    using System.Timers;

    using ACT.MPTimer.Properties;
    using Advanced_Combat_Tracker;

    /// <summary>
    /// FF14を監視する
    /// </summary>
    public partial class FF14Watcher
    {
        private static double FFXIVProcessCheckInterval = 10.0d;

        /// <summary>
        /// シングルトンインスタンス
        /// </summary>
        private static FF14Watcher instance;

        /// <summary>
        /// 監視タイマー
        /// </summary>
        private Timer watchTimer;

        /// <summary>
        /// 処理中か？
        /// </summary>
        private bool isWorking;

        /// <summary>
        /// FFXIVプロセスの所在を最後にチェックした日時
        /// </summary>
        private DateTime lastCheckDateTime;

        /// <summary>
        /// シングルトンインスタンス
        /// </summary>
        public static FF14Watcher Default
        {
            get
            {
                FF14Watcher.Initialize();
                return instance;
            }
        }

        /// <summary>
        /// 初期化する
        /// </summary>
        public static void Initialize()
        {
            if (instance == null)
            {
                instance = new FF14Watcher()
                {
                    PreviousMP = -1
                };

                instance.watchTimer = new Timer()
                {
                    Interval = Settings.Default.ParameterRefreshRate,
                    Enabled = false
                };

                instance.watchTimer.Elapsed += instance.watchTimer_Elapsed;

                // エノキアンタイマーを開始する
                instance.StartEnochianTimer();

                // 監視を開始する
                instance.watchTimer.Start();
            }
        }

        /// <summary>
        /// 後片付けをする
        /// </summary>
        public static void Deinitialize()
        {
            if (instance != null)
            {
                // エノキアンタイマーを終了する
                instance.EndEnochianTimer();

                if (instance.watchTimer != null)
                {
                    instance.watchTimer.Stop();
                    instance.watchTimer.Dispose();
                    instance.watchTimer = null;
                }

                instance = null;
            }
        }

        /// <summary>
        /// 監視タイマー Elapsed
        /// </summary>
        /// <param name="sender">イベント発声元</param>
        /// <param name="e">イベント引数</param>
        private void watchTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (this.isWorking)
            {
                return;
            }

#if DEBUG
//          var sw = Stopwatch.StartNew();
#endif

            try
            {
                this.isWorking = true;

                this.WatchCore();
            }
            catch (Exception ex)
            {
                Trace.WriteLine(
                    "ACT.MPTimer FF14の監視スレッドで例外が発生しました" + Environment.NewLine +
                    ex.ToString());
            }
            finally
            {
#if DEBUG
//              sw.Stop();
//              Trace.WriteLine(string.Format("Timer elapsed. {0:N0} ticks", sw.Elapsed.Ticks));
#endif

                this.isWorking = false;
                this.watchTimer.Start();
            }
        }

        /// <summary>
        /// 監視の中核
        /// </summary>
        private void WatchCore()
        {
            // ACTが表示されていなければ何もしない
            if (!ActGlobals.oFormActMain.Visible)
            {
                return;
            }

            // FF14Processがなければ何もしない
            if ((DateTime.Now - this.lastCheckDateTime).TotalSeconds >= FFXIVProcessCheckInterval)
            {
                if (FF14PluginHelper.GetFFXIVProcess == null)
                {
#if !DEBUG
                    return;
#endif
                }

                this.lastCheckDateTime = DateTime.Now;
            }

            // MP回復スパンを開始する
            this.WacthMPRecovery();
        }
    }
}
