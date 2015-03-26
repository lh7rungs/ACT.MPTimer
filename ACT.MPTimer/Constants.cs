namespace ACT.MPTimer
{
    public static class Constants
    {
        /// <summary>
        /// MP回復周期
        /// 
        /// ET 1分毎
        /// ET 24h = LT 70m
        /// ET 1m  = LT 70 / 24 → 2.91666... 
        /// </summary>
        public const double MPRecoverySpan = 70.0d / 24.0d;

        /// <summary>
        /// MP回復割合
        /// </summary>
        public static class MPRecoveryRate
        {
            /// <summary>
            /// 通常(非戦闘時)
            /// </summary>
            public const double Normal = 0.06d;

            /// <summary>
            /// 戦闘中
            /// </summary>
            public const double InCombat = 0.02d;

            /// <summary>
            /// アンブラルブリザード1による増量
            /// </summary>
            public const double UmbralIce1 = 0.30d;

            /// <summary>
            /// アンブラルブリザード2による増量
            /// </summary>
            public const double UmbralIce2 = 0.45d;

            /// <summary>
            /// アンブラルブリザード3による増量
            /// </summary>
            public const double UmbralIce3 = 0.60d;
        }
    }
}
