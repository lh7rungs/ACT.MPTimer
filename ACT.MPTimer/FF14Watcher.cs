namespace ACT.MPTimer
{
    using System;
    using System.Timers;

    using ACT.MPTimer.Properties;
    using Advanced_Combat_Tracker;

    /// <summary>
    /// FF14を監視する
    /// </summary>
    public partial class FF14Watcher
    {
        /// <summary>
        /// ロックオブジェクト
        /// </summary>
        private static object lockObject = new object();

        /// <summary>
        /// シングルトンインスタンス
        /// </summary>
        private static FF14Watcher instance;

        /// <summary>
        /// 監視タイマー
        /// </summary>
        private Timer watchTimer;

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
            lock (lockObject)
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
                        AutoReset = false,
                        Enabled = false
                    };

                    instance.watchTimer.Elapsed += instance.watchTimer_Elapsed;

                    // 監視を開始する
                    instance.watchTimer.Start();

                    // ログの読み取りをセットする
                    ActGlobals.oFormActMain.OnLogLineRead += instance.oFormActMain_OnLogLineRead;
                }
            }
        }

        /// <summary>
        /// 後片付けをする
        /// </summary>
        public static void Deinitialize()
        {
            lock (lockObject)
            {
                if (instance != null)
                {
                    ActGlobals.oFormActMain.OnLogLineRead -= instance.oFormActMain_OnLogLineRead;

                    if (instance.watchTimer != null)
                    {
                        instance.watchTimer.Stop();
                        instance.watchTimer.Dispose();
                        instance.watchTimer = null;
                    }

                    instance = null;
                }
            }
        }

        /// <summary>
        /// 監視タイマー Elapsed
        /// </summary>
        /// <param name="sender">イベント発声元</param>
        /// <param name="e">イベント引数</param>
        private void watchTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            var timer = sender as Timer;

            lock (lockObject)
            {
                // タイマーを止める
                timer.Stop();

                try
                {
                    this.WatchCore();
                }
                catch (Exception ex)
                {
                    ActGlobals.oFormActMain.WriteExceptionLog(
                        ex,
                        "ACT.MPTimer FF14の監視スレッドで例外が発生しました");
                }

                // タイマーを再開する
                timer.Start();
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
            var ff14 = FF14PluginHelper.GetFFXIVProcess;
            if (ff14 == null)
            {
                return;
            }

            // MP回復スパンを開始する
            this.WacthMPRecovery();
        }
    }
}
