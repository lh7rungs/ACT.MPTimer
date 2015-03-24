namespace ACT.MPTimer
{
    using System;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Media;
    using System.Windows.Threading;

    using ACT.MPTimer.Properties;
    using ACT.MPTimer.Utility;
    using Advanced_Combat_Tracker;

    /// <summary>
    /// MPTimer Window
    /// </summary>
    public partial class MPTimerWindow : Window
    {
        /// <summary>
        /// ロックオブジェクト
        /// </summary>
        private static object lockObject = new object();

        /// <summary>
        /// MP監視タイマ
        /// </summary>
        private DispatcherTimer MPWatchTimer;

        /// <summary>
        /// 停止中か？
        /// </summary>
        private bool IsStopping;

        /// <summary>フォントのBrush</summary>
        private SolidColorBrush FontBrush { get; set; }

        /// <summary>フォントのアウトラインBrush</summary>
        private SolidColorBrush FontOutlineBrush { get; set; }

        /// <summary>バーのBrush</summary>
        private SolidColorBrush BarBrush { get; set; }

        /// <summary>バーの背景のBrush</summary>
        private SolidColorBrush BarBackBrush { get; set; }

        /// <summary>バーのアウトラインのBrush</summary>
        private SolidColorBrush BarOutlineBrush { get; set; }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public MPTimerWindow()
        {
            this.InitializeComponent();

            this.ShowInTaskbar = false;
            this.Topmost = true;

            this.Loaded += MPTimerWindow_Loaded;
        }

        /// <summary>
        /// Window Loaded
        /// </summary>
        /// <param name="sender">イベント発生元</param>
        /// <param name="e">イベント引数</param>
        private void MPTimerWindow_Loaded(object sender, RoutedEventArgs e)
        {
            this.Left = Settings.Default.OverlayLeft;
            this.Top = Settings.Default.OverlayTop;

#if !DEBUG
            // リリースではロード時は一先ず消しておく
            this.Opacity = 0;
#endif

            // Brushを生成する
            this.FontBrush = new SolidColorBrush(Settings.Default.FontColor.ToWPF());
            this.FontOutlineBrush = new SolidColorBrush(Settings.Default.FontOutlineColor.ToWPF());
            this.BarBrush = new SolidColorBrush(Settings.Default.ProgressBarColor.ToWPF());
            this.BarBackBrush = new SolidColorBrush(Settings.Default.ProgressBarColor.ToWPF().ChangeBrightness(0.4d));
            this.BarOutlineBrush = new SolidColorBrush(Settings.Default.ProgressBarOutlineColor.ToWPF());

            this.FontBrush.Freeze();
            this.FontOutlineBrush.Freeze();
            this.BarBrush.Freeze();
            this.BarBackBrush.Freeze();
            this.BarOutlineBrush.Freeze();

            // マウスの移動を定義する
            this.MouseLeftButtonDown += (s1, e1) =>
            {
                lock (lockObject)
                {
                    this.DragMove();
                }
            };

            // 停止動作を定義する
            this.MouseDoubleClick += (s1, e1) =>
            {
                lock (lockObject)
                {
                    this.IsStopping = !this.IsStopping;
                    this.MPWatchCore();
                }
            };

            // MP監視タイマを開始する
            this.MPWatchTimer = new DispatcherTimer()
            {
                Interval = new TimeSpan(0, 0, 0, 0, Settings.Default.OverlayRefreshRate),
            };

            this.MPWatchTimer.Tick += this.MPWatchTimer_Tick;
            this.MPWatchTimer.Start();
        }

        /// <summary>
        /// MP監視タイマ Tick
        /// </summary>
        /// <param name="sender">イベント発生元</param>
        /// <param name="e">イベント引数</param>
        private void MPWatchTimer_Tick(object sender, EventArgs e)
        {
            lock (lockObject)
            {
                this.MPWatchCore();
            }
        }

        /// <summary>
        /// MP監視タイマの中核
        /// </summary>
        private void MPWatchCore()
        {
            try
            {
                this.MPWatchTimer.Stop();

                // ACTが表示されていなければ何もしない
                if (!ActGlobals.oFormActMain.Visible)
                {
                    this.MPWatchTimer.Interval = new TimeSpan(0, 0, 0, 1, 0);
                    this.Opacity = 0;
                    return;
                }

#if !DEBUG
                // FF14Processがなければ何もしない
                var ff14 = FF14PluginHelper.GetFFXIVProcess;
                if (ff14 == null)
                {
                    this.MPWatchTimer.Interval = new TimeSpan(0, 0, 0, 1, 0);
                    this.Opacity = 0;
                    return;
                }

                // プレイヤーがいない？
                if (!FF14Watcher.Default.ExistPlayer)
                {
                    this.MPWatchTimer.Interval = new TimeSpan(0, 0, 0, 1, 0);
                    this.Opacity = 0;
                    return;
                }
#endif

                // リキャストタイマーを描画する
                this.DrawRecastTimer();

                // 監視間隔を短くする
                this.MPWatchTimer.Interval = new TimeSpan(0, 0, 0, 0, Settings.Default.OverlayRefreshRate);
            }
            catch (Exception ex)
            {
                ActGlobals.oFormActMain.WriteExceptionLog(
                    ex,
                    "ACT.MPTimer グラフの描画で例外が発生しました。");

                this.Opacity = 0;
            }
            finally
            {
                this.MPWatchTimer.Start();
            }
        }

        /// <summary>
        /// リキャストタイマを描画する
        /// </summary>
        private void DrawRecastTimer()
        {
            // 残り秒数を取得する
            var recastTime = string.Empty;
            if (FF14Watcher.Default.TimeOfRecovery > 0)
            {
                recastTime = ((decimal)FF14Watcher.Default.TimeOfRecovery / 1000m).ToString("0.0");
            }

#if DEBUG
            if (string.IsNullOrWhiteSpace(recastTime))
            {
                recastTime = "3.0";
            }
#endif

            // 進捗率を取得する
            var rateOfMPRecovery = FF14Watcher.Default.RateOfRecovery;

            // 戦闘中のみ？
            if (Settings.Default.CountInCombat)
            {
                if (!FF14Watcher.Default.InCombat)
                {
                    this.Opacity = 0;
                    return;
                }
            }

            // 停止中？
            if (this.IsStopping)
            {
                recastTime = "Ready";
                rateOfMPRecovery = 1m;
            }

            // 透過率を設定する
            this.Opacity = (100d - Settings.Default.OverlayOpacity) / 100d;

            this.Topmost = false;
            this.Topmost = true;

            Dispatcher.BeginInvoke(new Action(() =>
            {
                // 秒数を描画する
                if (this.RecastTimeTextBlock.Text != recastTime)
                {
                    this.RecastTimeTextBlock.FontFamily = Settings.Default.Font.ToFontFamilyWPF();
                    this.RecastTimeTextBlock.FontSize = Settings.Default.Font.ToFontSizeWPF();
                    this.RecastTimeTextBlock.FontStyle = Settings.Default.Font.ToFontStyleWPF();
                    this.RecastTimeTextBlock.FontWeight = Settings.Default.Font.ToFontWeightWPF();
                    this.RecastTimeTextBlock.Fill = this.FontBrush;
                    this.RecastTimeTextBlock.Stroke = this.FontOutlineBrush;
                    this.RecastTimeTextBlock.StrokeThickness = (this.RecastTimeTextBlock.FontSize / 100.0d) * 3.0d;
                    this.RecastTimeTextBlock.Text = recastTime;
                }

                // プログレスバーを描画する
                var foreRect = this.BarRectangle;
                foreRect.Stroke = this.BarBrush;
                foreRect.Fill = this.BarBrush;
                foreRect.Width = (double)(Settings.Default.ProgressBarSize.Width * rateOfMPRecovery);
                foreRect.Height = Settings.Default.ProgressBarSize.Height;
                foreRect.RadiusX = 4.0d;
                foreRect.RadiusY = 4.0d;
                Canvas.SetLeft(foreRect, 0);
                Canvas.SetTop(foreRect, 0);

                var backRect = this.BarBackRectangle;
                backRect.Stroke = this.BarBackBrush;
                backRect.Fill = this.BarBackBrush;
                backRect.Width = Settings.Default.ProgressBarSize.Width;
                backRect.Height = Settings.Default.ProgressBarSize.Height;
                backRect.RadiusX = 4.0d;
                backRect.RadiusY = 4.0d;
                Canvas.SetLeft(backRect, 0);
                Canvas.SetTop(backRect, 0);

                var outlineRect = this.BarOutlineRectangle;
                outlineRect.Stroke = this.BarOutlineBrush;
                outlineRect.Fill = Brushes.Transparent;
                outlineRect.Width = Settings.Default.ProgressBarSize.Width;
                outlineRect.Height = Settings.Default.ProgressBarSize.Height;
                outlineRect.RadiusX = 4.0d;
                outlineRect.RadiusY = 4.0d;
                Canvas.SetLeft(outlineRect, 0);
                Canvas.SetTop(outlineRect, 0);

                this.BarRectangleEffect.Color = this.BarBrush.Color;

                // プログレスバーキャンパスのレイアウトを調整する
                this.ProgressBarCanvas.Width = Settings.Default.ProgressBarSize.Width;
                this.ProgressBarCanvas.Height = Settings.Default.ProgressBarSize.Height;
            }));
        }
    }
}
