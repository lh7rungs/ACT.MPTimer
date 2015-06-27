namespace ACT.MPTimer
{
    using System;
    using System.Diagnostics;

    using Advanced_Combat_Tracker;

    /// <summary>
    /// FF14を監視する エノキアンタイマ
    /// </summary>
    public partial class FF14Watcher
    {
        /// <summary>
        /// エノキアンの効果期間
        /// </summary>
        private const double EnochianDuration = 30.0d;

        /// <summary>
        /// エノキアンの延長時の効果期間の劣化量
        /// </summary>
        private const double EnochianDegradationSecondsExtending = 5.0d;

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

            // プレイヤ情報を取得する
            var player = FF14PluginHelper.GetCombatantPlayer();
            if (player == null)
            {
                return;
            }

            // 各種マッチング用の文字列を生成する
            var machingTextToEnochianOn = player.Name + "に「エノキアン」の効果。";
            var machingTextToEnochianOff = player.Name + "の「エノキアン」が切れた。";
            var machingTextToUmbralIce1On = player.Name + "に「アンブラルブリザード」の効果。";
            var machingTextToUmbralIce2On = player.Name + "に「アンブラルブリザードII」の効果。";
            var machingTextToUmbralIce3On = player.Name + "に「アンブラルブリザードIII」の効果。";
            var machingTextToUmbralIce1Off = player.Name + "の「アンブラルブリザード」が切れた。";
            var machingTextToUmbralIce2Off = player.Name + "の「アンブラルブリザードII」が切れた。";
            var machingTextToUmbralIce3Off = player.Name + "の「アンブラルブリザードIII」が切れた。";
            var machingTextToBlizzard4 = player.Name + "の「ブリザジャ」";

            var log = logInfo.logLine;

            if (!log.Contains(player.Name))
            {
                return;
            }

            // エノキアンON？
            if (log.Contains(machingTextToEnochianOn))
            {
                // 既にエノキアン中でなければエノキアンの更新回数をクリアする
                if (!this.inEnochian)
                {
                    this.updateEnchianCount = 0;
                    this.UpdateEnochian();
                }

                this.inEnochian = true;

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
