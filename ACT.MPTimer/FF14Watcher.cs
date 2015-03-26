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

#if !DEBUG
            // FF14Processがなければ何もしない
            if (!FF14PluginHelper.ExistsFFXIVProcess)
            {
                return;
            }
#endif

            // MP回復スパンを開始する
            this.WacthMPRecovery();
        }
    }
}
