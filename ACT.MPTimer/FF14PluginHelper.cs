namespace ACT.MPTimer
{
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Reflection;

    using Advanced_Combat_Tracker;

    public static partial class FF14PluginHelper
    {
        private static object lockObject = new object();
        private static object plugin;
        private static object pluginMemory;
        private static dynamic pluginConfig;
        private static dynamic pluginScancombat;

        public static void Initialize()
        {
            lock (lockObject)
            {
                if (!ActGlobals.oFormActMain.Visible)
                {
                    return;
                }

                if (plugin == null)
                {
                    foreach (var item in ActGlobals.oFormActMain.ActPlugins)
                    {
                        if (item.pluginFile.Name.ToUpper() == "FFXIV_ACT_Plugin.dll".ToUpper() &&
                            item.lblPluginStatus.Text.ToUpper() == "FFXIV Plugin Started.".ToUpper())
                        {
                            plugin = item.pluginObj;
                            break;
                        }
                    }
                }

                if (plugin != null)
                {
                    FieldInfo fi;

                    if (pluginMemory == null)
                    {
                        fi = plugin.GetType().GetField("_Memory", BindingFlags.GetField | BindingFlags.NonPublic | BindingFlags.Instance);
                        pluginMemory = fi.GetValue(plugin);
                    }

                    if (pluginMemory == null)
                    {
                        return;
                    }

                    if (pluginConfig == null)
                    {
                        fi = pluginMemory.GetType().GetField("_config", BindingFlags.GetField | BindingFlags.NonPublic | BindingFlags.Instance);
                        pluginConfig = fi.GetValue(pluginMemory);
                    }

                    if (pluginConfig == null)
                    {
                        return;
                    }

                    if (pluginScancombat == null)
                    {
                        fi = pluginConfig.GetType().GetField("ScanCombatants", BindingFlags.GetField | BindingFlags.NonPublic | BindingFlags.Instance);
                        pluginScancombat = fi.GetValue(pluginConfig);
                    }
                }
            }
        }

        public static bool ExistsFFXIVProcess
        {
            get
            {
                var ps = Process.GetProcessesByName("ffxiv");
                return ps != null ? ps.Length > 0 : false;
            }
        }

        public static Process GetFFXIVProcess
        {
            get
            {
                try
                {
                    Initialize();

                    if (pluginConfig == null)
                    {
                        return null;
                    }

                    var process = pluginConfig.Process;

                    return (Process)process;
                }
                catch
                {
                    return null;
                }
            }
        }

        public static Combatant GetCombatantPlayer()
        {
            var result = default(Combatant);

            Initialize();

#if DEBUG
            result = new Combatant();
            result.Job = 25;
            result.CurrentMP = 1000;
            result.MaxMP = 5400;
            return result;
#else
            if (plugin == null)
            {
                return result;
            }

            if (!ExistsFFXIVProcess)
            {
                return result;
            }

            if (pluginScancombat == null)
            {
                return result;
            }

            dynamic list = pluginScancombat.GetCombatantList();
            if (list.Count > 0)
            {
                var item = list[0];
                var combatant = new Combatant();

                combatant.ID = (uint)item.ID;
                combatant.Job = (int)item.Job;
                combatant.CurrentMP = (int)item.CurrentMP;
                combatant.MaxMP = (int)item.MaxMP;

                result = combatant;
            }

            return result;
#endif
        }

        public static List<Combatant> GetCombatantList()
        {
            Initialize();

            var result = new List<Combatant>();

            if (plugin == null)
            {
                return result;
            }

            if (!ExistsFFXIVProcess)
            {
                return result;
            }

            if (pluginScancombat == null)
            {
                return result;
            }

            dynamic list = pluginScancombat.GetCombatantList();
            foreach (dynamic item in list.ToArray())
            {
                if (item == null)
                {
                    continue;
                }

                var combatant = new Combatant();

                combatant.ID = (uint)item.ID;
                combatant.Job = (int)item.Job;
                combatant.CurrentMP = (int)item.CurrentMP;
                combatant.MaxMP = (int)item.MaxMP;
/*
                combatant.OwnerID = (uint)item.OwnerID;
                combatant.Name = (string)item.Name;
                combatant.type = (byte)item.type;
                combatant.Level = (int)item.Level;
                combatant.CurrentHP = (int)item.CurrentHP;
                combatant.MaxHP = (int)item.MaxHP;
                combatant.CurrentTP = (int)item.CurrentTP;
*/

                result.Add(combatant);
            }

            return result;
        }

        public static Player GetPlayerData()
        {
            Initialize();

            var result = new Player();

            if (plugin == null)
            {
                return result;
            }

            if (!ExistsFFXIVProcess)
            {
                return result;
            }

            if (pluginScancombat == null)
            {
                return result;
            }

            dynamic playerData = pluginScancombat.GetPlayerData();
            if (playerData != null)
            {
                result.JobID = playerData.JobID;
                result.Pie = playerData.Pie;
/*
                result.Str = playerData.Str;
                result.Dex = playerData.Dex;
                result.Vit = playerData.Vit;
                result.Intel = playerData.Intel;
                result.Mnd = playerData.Mnd;
                result.Attack = playerData.Attack;
                result.Accuracy = playerData.Accuracy;
                result.Crit = playerData.Crit;
                result.AttackMagicPotency = playerData.AttackMagicPotency;
                result.HealMagicPotency = playerData.HealMagicPotency;
                result.Det = playerData.Det;
                result.SkillSpeed = playerData.SkillSpeed;
                result.SpellSpeed = playerData.SpellSpeed;
                result.WeaponDmg = playerData.WeaponDmg;
*/
            }

            return result;
        }

        public static List<uint> GetCurrentPartyList(
            out int partyCount)
        {
            Initialize();

            var partyList = new List<uint>();
            partyCount = 0;

            if (plugin == null)
            {
                return partyList;
            }

            if (!ExistsFFXIVProcess)
            {
                return partyList;
            }

            if (pluginScancombat == null)
            {
                return partyList;
            }

            partyList = pluginScancombat.GetCurrentPartyList(
                out partyCount) as List<uint>;

            return partyList;
        }
    }

    public class Combatant
    {
        public Combatant()
        {
            this.Name = string.Empty;
        }

        public uint ID;
        public uint OwnerID;
        public int Order;
        public byte type;
        public int Job;
        public int Level;
        public string Name;
        public int CurrentHP;
        public int MaxHP;
        public int CurrentMP;
        public int MaxMP;
        public int CurrentTP;
    }

    public class Player
    {
        public int JobID;
        public int Str;
        public int Dex;
        public int Vit;
        public int Intel;
        public int Mnd;
        public int Pie;
        public int Attack;
        public int Accuracy;
        public int Crit;
        public int AttackMagicPotency;
        public int HealMagicPotency;
        public int Det;
        public int SkillSpeed;
        public int SpellSpeed;
        public int WeaponDmg;
    }
}
