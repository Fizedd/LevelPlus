// Copyright (c) Bitwiser.
// Licensed under the Apache License, Version 2.0.

using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace LevelPlus.Common.Players.Stats;

/// The base stat that all stats (or extentions of the player for stats) should inherit from
public abstract class BaseStat : ILoadable
{
  /// The localized name of this stat 
  public LocalizedText Name => Language.GetText(NameKey);
  /// The localized list of bonuses this stat provides
  public LocalizedText Description => Language.GetText(DescriptionKey).WithFormatArgs(DescriptionArgs);

  /// The name key for localization of this stat
  protected virtual string NameKey => "Stats." + Id + ".Name";
  /// The list of bonuses key for the localization of what this stat provides
  protected virtual string DescriptionKey => "Stats." + Id + ".Bonuses";
  /// Set to false to not display this stat in the spend screen <br/>
  /// (See LevelStat.cs for example of why this is useful)
  public virtual bool Displayable => true;
  /// Set to false to not have this subracted from point total in StatPlayer.cs <br/>
  /// and to be not be spendable in the spend screen <br/>
  /// (See LevelStat.cs for example of why this is useful)
  public virtual bool Spendable => true;
  /// The file path of the icon for this stat
  public virtual string IconPath => "LevelPlus/Assets/Textures/UI/Icons/" + Id;
  /// The amount of points invested in this stat
  public virtual int Value { get; protected internal set; }

  /// The arugments that go toward the localized description
  protected abstract object[] DescriptionArgs { get; }
  /// The internal handle of the stat
  public abstract string Id { get; }

  /// Should this mod be loaded? Used to check for dependencies
  public abstract bool IsLoadingEnabled(Mod mod);
  
  /// Load the stat. It would be useful to register to StatPlayer here
  public virtual void Load(Mod mod)
  {
  }
  
  /// Unload the stat
  public virtual void Unload()
  {
  }
  
  /// Save data to the StatPlayer
  public virtual void SaveData(TagCompound tag)
  {
  }
  
  /// Load data from the StatPlayer
  public virtual void LoadData(TagCompound tag)
  {
  }

  /// Called on PostUpdateMiscEffects
  public virtual void ModifyPlayer(ref Player player)
  {
  }

  /// Called on GetFishingLevel
  public virtual void ModifyFishingLevel(Item fishingRod, Item bait, ref float fishingLevel)
  {
  }

  /// Called on PostUpdateRunSpeeds
  public virtual void ModifyRunSpeeds(ref Player player)
  {
  }

  /// Called on UpdateLifeRegen
  public virtual void ModifyLifeRegen(ref Player player)
  {
  }
  
  /// Called on OnConsumeMana
  public virtual void ModifyOnConsumeMana(ref Player player, Item item, int manaConsumed)
  {
  }
  
  /// Whether or not the player can consume ammo
  public virtual bool CanConsumeAmmo(Item weapon, Item ammo)
  {
    return true;
  }
}