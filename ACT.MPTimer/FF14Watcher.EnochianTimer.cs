namespace ACT.MPTimer
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Threading;
    using System.Threading.Tasks;

    using ACT.MPTimer.Properties;
    using Advanced_Combat_Tracker;

    /// <summary>
    /// FF14を監視する エノキアンタイマ
    /// </summary>
    public partial class FF14Watcher
    {
        /// <summary>
        /// エノキアンの効果期間
        /// </summary>
        public const double EnochianDuration = 30.0d;

        /// <summary>
        /// エノキアンの延長時の効果期間の劣化量
        /// </summary>
        public const double EnochianDegradationSecondsExtending = 5.0d;

        /// <summary>
        /// エノキアン効果中か？
        /// </summary>
        private bool inEnochian;

        /// <summary>
        /// アンブラルアイス中か？
        /// </summary>
        private bool inUmbralIce;

        /// <summary>
        /// エノキアンの更新回数
        /// </summary>
        private long updateEnchianCount;

        /// <summary>
        /// ログキュー
        /// </summary>
        private Queue<string> logQueue = new Queue<string>();

        /// <summary>
        /// エノキアンタイマータスク
        /// </summary>
        private Task enochianTimerTask;

        /// <summary>
        /// エノキアンタイマー停止フラグ
        /// </summary>
        private bool enochianTimerStop;

        /// <summary>
        /// プレイヤーの名前
        /// </summary>
        private string playerName;

        /// <summary>
        /// エノキアンタイマーを開始する
        /// </summary>
        private void StartEnochianTimer()
        {
            ActGlobals.oFormActMain.OnLogLineRead += this.OnLoglineRead;
            this.playerName = string.Empty;
            this.logQueue.Clear();
            this.enochianTimerStop = false;
            this.enochianTimerTask = new Task(this.AnalyseLogLinesToEnochian);
            this.enochianTimerTask.Start();
        }

        /// <summary>
        /// エノキアンタイマーを終了する
        /// </summary>
        private void EndEnochianTimer()
        {
            ActGlobals.oFormActMain.OnLogLineRead -= this.OnLoglineRead;

            if (this.enochianTimerTask != null)
            {
                this.enochianTimerStop = true;
                this.enochianTimerTask.Wait();
                this.enochianTimerTask.Dispose();
                this.enochianTimerTask = null;
            }
        }

        /// <summary>
        ///  Logline Read
        /// </summary>
        /// <param name="isImport">インポートログか？</param>
        /// <param name="logInfo">発生したログ情報</param>
        private void OnLoglineRead(
            bool isImport,
            LogLineEventArgs logInfo)
        {
            if (isImport)
            {
                return;
            }

            lock (this.logQueue)
            {
                this.logQueue.Enqueue(logInfo.logLine);
            }
        }

        /// <summary>
        /// エノキアンタイマー向けにログを分析する
        /// </summary>
        private void AnalyseLogLinesToEnochian()
        {
            while (true)
            {
                if (this.enochianTimerStop)
                {
                    break;
                }

                var log = string.Empty;

                while (true)
                {
                    lock (this.logQueue)
                    {
                        if (this.logQueue.Count > 0)
                        {
                            log = this.logQueue.Dequeue();
                        }
                        else
                        {
                            break;
                        }
                    }

                    this.AnalyzeLogLineToEnochian(log);
                    Thread.Sleep(1);
                }

                Thread.Sleep(Settings.Default.ParameterRefreshRate / 2);
            }
        }

        /// <summary>
        /// エノキアンタイマー向けにログを分析する
        /// </summary>
        /// <param name="log">ログ</param>
        private void AnalyzeLogLineToEnochian(
            string log)
        {
            if (string.IsNullOrWhiteSpace(log))
            {
                return;
            }

            if (string.IsNullOrWhiteSpace(this.playerName) ||
                log.Contains("Welcome to"))
            {
                // プレイヤ情報を取得する
                var player = FF14PluginHelper.GetCombatantPlayer();
                if (player != null)
                {
                    this.playerName = player.Name;
                }
            }

            // 各種マッチング用の文字列を生成する
            var machingTextToEnochianOn = this.playerName + "の「エノキアン」";
            var machingTextToEnochianOff = this.playerName + "の「エノキアン」が切れた。";
            var machingTextToUmbralIce1On = this.playerName + "に「アンブラルブリザード」の効果。";
            var machingTextToUmbralIce2On = this.playerName + "に「アンブラルブリザードII」の効果。";
            var machingTextToUmbralIce3On = this.playerName + "に「アンブラルブリザードIII」の効果。";
            var machingTextToUmbralIce1Off = this.playerName + "の「アンブラルブリザード」が切れた。";
            var machingTextToUmbralIce2Off = this.playerName + "の「アンブラルブリザードII」が切れた。";
            var machingTextToUmbralIce3Off = this.playerName + "の「アンブラルブリザードIII」が切れた。";
            var machingTextToBlizzard4 = this.playerName + "の「ブリザジャ」";

            if (!log.Contains(this.playerName))
            {
                return;
            }

            // エノキアンON？
            if (log.EndsWith(machingTextToEnochianOn))
            {
                this.inEnochian = true;
                this.updateEnchianCount = 0;
                this.UpdateEnochian();

                Trace.WriteLine("Enochian On.");
                return;
            }

            // エノキアンOFF？
            if (log.Contains(machingTextToEnochianOff))
            {
                this.inEnochian = false;
                this.updateEnchianCount = 0;

                Trace.WriteLine("Enochian Off.");
                return;
            }

            // アンブラルアイスON？
            if (log.Contains(machingTextToUmbralIce1On) ||
                log.Contains(machingTextToUmbralIce2On) ||
                log.Contains(machingTextToUmbralIce3On))
            {
                this.inUmbralIce = true;

                Trace.WriteLine("Umbral Ice On.");
                return;
            }

            // アンブラルアイスOFF？
            if (log.Contains(machingTextToUmbralIce1Off) ||
                log.Contains(machingTextToUmbralIce2Off) ||
                log.Contains(machingTextToUmbralIce3Off))
            {
                this.inUmbralIce = false;

                Trace.WriteLine("Umbral Ice Off.");
                return;
            }

            // ブリザジャ？
            if (log.EndsWith(machingTextToBlizzard4))
            {
                if (this.inEnochian &&
                    this.inUmbralIce)
                {
                    this.updateEnchianCount++;
                    this.UpdateEnochian();
                }
            }
        }

        /// <summary>
        /// エノキアンの効果時間を更新する
        /// </summary>
        private void UpdateEnochian()
        {
            var vm = EnochianTimerWindow.Default.ViewModel;

            vm.StartDateTime = DateTime.Now;

            var duration = EnochianDuration - (EnochianDegradationSecondsExtending * this.updateEnchianCount);
            vm.EndScheduledDateTime = vm.StartDateTime.AddSeconds(duration);

            Trace.WriteLine("Enochian Update, +" + duration.ToString() + "s.");
        }
    }
}
