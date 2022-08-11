using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;


namespace FragmentGrinder
{
    public class FragmentGrinder : Mod
    {
        public override void Load()
        {
            base.Load();
        }

    }

    public class FragmentGrinderCondition : IItemDropRuleCondition
    {
        FragmentGrinderBiomeNebula modNebula = ModContent.GetInstance<FragmentGrinderBiomeNebula>();
        FragmentGrinderBiomeSolar modSolar = ModContent.GetInstance<FragmentGrinderBiomeSolar>();
        FragmentGrinderBiomeStardust modStardust = ModContent.GetInstance<FragmentGrinderBiomeStardust>();
        FragmentGrinderBiomeVortex modVortex = ModContent.GetInstance<FragmentGrinderBiomeVortex>();

        public bool CanDrop(DropAttemptInfo info)
        {
            if (!info.IsInSimulation)
            {
                return info.player.InModBiome(modNebula) || info.player.InModBiome(modSolar) || info.player.InModBiome(modStardust) || info.player.InModBiome(modVortex);
            }

            return false;

        }

        public bool CanShowItemDropInUI() => true;
        public string GetConditionDescription() => "Enemy spawned with placed monolith";
    }

    public class FragmentGrinderBiomeNebula : ModBiome
    {
        public override bool IsBiomeActive(Player player)
        {
            if (Main.SceneMetrics.ActiveMonolithType == 1 && NPC.downedTowerNebula)
            {
                return true;
            }
            return false;
        }

        public override void OnInBiome(Player player)
        {
            base.OnInBiome(player);
            player.ZoneTowerNebula = true;
        }
    }


    public class FragmentGrinderBiomeSolar : ModBiome
    {
        public override bool IsBiomeActive(Player player)
        {
            if (Main.SceneMetrics.ActiveMonolithType == 3 && NPC.downedTowerSolar)
            {
                return true;
            }
            return false;
        }

        public override void OnInBiome(Player player)
        {
            base.OnInBiome(player);
            player.ZoneTowerSolar = true;
        }

    }

    public class FragmentGrinderBiomeStardust : ModBiome
    {
        public override bool IsBiomeActive(Player player)
        {
            if (Main.SceneMetrics.ActiveMonolithType == 2 && NPC.downedTowerStardust)
            {
                return true;
            }
            return false;
        }

        public override void OnInBiome(Player player)
        {
            base.OnInBiome(player);
            player.ZoneTowerStardust = true;
        }

    }

    public class FragmentGrinderBiomeVortex : ModBiome
    {
        public override bool IsBiomeActive(Player player)
        {
            if (Main.SceneMetrics.ActiveMonolithType == 0 && NPC.downedTowerVortex)
            {
                return true;
            }
            return false;
        }

        public override void OnInBiome(Player player)
        {
            base.OnInBiome(player);
            player.ZoneTowerVortex = true;
        }

    }

    public class FragmentGrinderNPCs : GlobalNPC
    {

        //public override void ModifyGlobalLoot(GlobalLoot globalLoot)
        //{
        //    FragmentGrinderCondition modCondition = new();
        //    globalLoot.Add(ItemDropRule.ByCondition(modCondition, ItemID.FragmentNebula, 3));
        //    globalLoot.Add(ItemDropRule.ByCondition(modCondition, ItemID.FragmentSolar, 3));
        //    globalLoot.Add(ItemDropRule.ByCondition(modCondition, ItemID.FragmentStardust, 3));
        //    globalLoot.Add(ItemDropRule.ByCondition(modCondition, ItemID.FragmentVortex, 3));
        //}

        public override void ModifyNPCLoot(NPC npc, NPCLoot npcLoot)
        {
            FragmentGrinderCondition modCondition = new();
            if (npc.type == NPCID.NebulaBeast || npc.type == NPCID.NebulaBeast || npc.type == NPCID.NebulaBeast || npc.type == NPCID.NebulaBeast)
            {
                npcLoot.Add(ItemDropRule.ByCondition(modCondition, ItemID.FragmentNebula, 3));
            }
            if (npc.type == NPCID.SolarCorite || npc.type == NPCID.SolarCrawltipedeTail || npc.type == NPCID.SolarDrakomire || npc.type == NPCID.SolarDrakomireRider || npc.type == NPCID.SolarSolenian || npc.type == NPCID.SolarSroller || npc.type == NPCID.SolarSpearman)
            {
                npcLoot.Add(ItemDropRule.ByCondition(modCondition, ItemID.FragmentSolar, 3));
            }
            if (npc.type == NPCID.StardustWormHead || npc.type == NPCID.StardustJellyfishBig || npc.type == NPCID.StardustSpiderBig || npc.type == NPCID.StardustCellBig || npc.type == NPCID.StardustSoldier)
            {
                npcLoot.Add(ItemDropRule.ByCondition(modCondition, ItemID.FragmentStardust, 3));
            }
            if (npc.type == NPCID.VortexHornet || npc.type == NPCID.VortexHornetQueen || npc.type == NPCID.VortexLarva || npc.type == NPCID.VortexRifleman || npc.type == NPCID.VortexSoldier)
            {
                npcLoot.Add(ItemDropRule.ByCondition(modCondition, ItemID.FragmentVortex, 3));
            }
        }

    }


}