namespace ACT.MPTimer
{
    using System;
    using System.Diagnostics;
    using System.Windows.Forms;

    using ACT.MPTimer.Properties;
    using ACT.MPTimer.Utility;

    /// <summary>
    /// 設定Panel
    /// </summary>
    public partial class ConfigPanel : UserControl
    {
        private static ConfigPanel instance;

        public static ConfigPanel Default
        {
            get { return instance ?? (instance = new ConfigPanel()); }
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public ConfigPanel()
        {
            this.InitializeComponent();
            this.Dock = DockStyle.Fill;

            TraceUtility.LogTextBox = this.LogRichTextBox;
        }

        /// <summary>
        /// Load
        /// </summary>
        /// <param name="sender">イベント発生元</param>
        /// <param name="e">イベント引数</param>
        private void ConfigPanel_Load(object sender, EventArgs e)
        {
            this.TargetJobComboBox.DataSource = Job.GetJobList();
            this.TargetJobComboBox.ValueMember = "JobId";
            this.TargetJobComboBox.DisplayMember = "JobName";

            this.LoadSettings();

            this.TekiyoButton.Click += (s1, e1) =>
            {
                try
                {
                    FF14Watcher.Deinitialize();

                    Settings.Default.OverlayTop = (int)MPTimerWindow.Default.Top;
                    Settings.Default.OverlayLeft = (int)MPTimerWindow.Default.Left;

                    this.SaveSettings();

                    MPTimerWindow.Reload();
                    MPTimerWindow.Default.Show();

                    Trace.WriteLine("Change settings.");
                }
                finally
                {
                    FF14Watcher.Initialize();
                }
            };

            this.ShokikaButton.Click += (s1, e1) =>
            {
                try
                {
                    FF14Watcher.Deinitialize();

                    Settings.Default.Reset();
                    Settings.Default.Save();

                    MPTimerWindow.Default.Top = Settings.Default.OverlayTop;
                    MPTimerWindow.Default.Left = Settings.Default.OverlayLeft;

                    this.LoadSettings();

                    MPTimerWindow.Reload();
                    MPTimerWindow.Default.Show();

                    Trace.WriteLine("Reset settings.");
                }
                finally
                {
                    FF14Watcher.Initialize();
                }
            };
        }

        /// <summary>
        /// 設定をLoadする
        /// </summary>
        private void LoadSettings()
        {
            this.VisualSetting.BarColor = Settings.Default.ProgressBarColor;
            this.VisualSetting.BarOutlineColor = Settings.Default.ProgressBarOutlineColor;
            this.VisualSetting.TextFont = Settings.Default.Font;
            this.VisualSetting.FontColor = Settings.Default.FontColor;
            this.VisualSetting.FontOutlineColor = Settings.Default.FontOutlineColor;
            this.VisualSetting.BarSize = Settings.Default.ProgressBarSize;
            this.VisualSetting.RefreshSampleImage();

            this.TokaRitsuNumericUpDown.Value = Settings.Default.OverlayOpacity;

            this.CountInCombatCheckBox.Checked = Settings.Default.CountInCombat;
            this.CountInCombatNumericUpDown.Value = Settings.Default.CountInCombatSpan;
            this.TargetJobComboBox.SelectedValue = Settings.Default.TargetJobId;
            this.ClickThroughCheckBox.Checked = Settings.Default.ClickThrough;

            this.MPRefreshRateNumericUpDown.Value = Settings.Default.ParameterRefreshRate;
        }

        /// <summary>
        /// 設定をSaveする
        /// </summary>
        private void SaveSettings()
        {
            Settings.Default.ProgressBarColor = this.VisualSetting.BarColor;
            Settings.Default.ProgressBarOutlineColor = this.VisualSetting.BarOutlineColor;
            Settings.Default.Font = this.VisualSetting.TextFont;
            Settings.Default.FontColor = this.VisualSetting.FontColor;
            Settings.Default.FontOutlineColor = this.VisualSetting.FontOutlineColor;
            Settings.Default.ProgressBarSize = this.VisualSetting.BarSize;

            Settings.Default.OverlayOpacity = (int)this.TokaRitsuNumericUpDown.Value;

            Settings.Default.CountInCombat = this.CountInCombatCheckBox.Checked;
            Settings.Default.CountInCombatSpan = (int)this.CountInCombatNumericUpDown.Value;
            Settings.Default.TargetJobId = (int)this.TargetJobComboBox.SelectedValue;
            Settings.Default.ClickThrough = this.ClickThroughCheckBox.Checked;

            Settings.Default.ParameterRefreshRate = (int)this.MPRefreshRateNumericUpDown.Value;

            Settings.Default.Save();
        }
    }
}
