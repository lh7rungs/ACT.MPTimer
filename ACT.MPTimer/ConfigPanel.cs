namespace ACT.MPTimer
{
    using System;
    using System.Windows.Forms;

    using ACT.MPTimer.Properties;

    /// <summary>
    /// 設定Panel
    /// </summary>
    public partial class ConfigPanel : UserControl
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public ConfigPanel()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// MPTimer Window
        /// </summary>
        public MPTimerWindow MPTimerWindow { get; set; }

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
                Settings.Default.OverlayTop = (int)this.MPTimerWindow.Top;
                Settings.Default.OverlayLeft = (int)this.MPTimerWindow.Left;
                this.SaveSettings();

                this.MPTimerWindow.Close();
                this.MPTimerWindow = new MPTimerWindow();
                if (Settings.Default.ClickThrough)
                {
                    this.MPTimerWindow.ToTransparentWindow();
                }

                this.MPTimerWindow.Show();
            };

            this.ShokikaButton.Click += (s1, e1) =>
            {
                Settings.Default.Reset();
                Settings.Default.Save();

                this.MPTimerWindow.Top = Settings.Default.OverlayTop;
                this.MPTimerWindow.Left = Settings.Default.OverlayLeft;

                this.LoadSettings();

                this.MPTimerWindow.Close();
                this.MPTimerWindow = new MPTimerWindow();
                if (Settings.Default.ClickThrough)
                {
                    this.MPTimerWindow.ToTransparentWindow();
                }

                this.MPTimerWindow.Show();
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

            this.OverlayRefreshRateNumericUpDown.Value = Settings.Default.OverlayRefreshRate;
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

            Settings.Default.OverlayRefreshRate = (int)this.OverlayRefreshRateNumericUpDown.Value;
            Settings.Default.ParameterRefreshRate = (int)this.MPRefreshRateNumericUpDown.Value;

            Settings.Default.Save();
        }
    }
}
