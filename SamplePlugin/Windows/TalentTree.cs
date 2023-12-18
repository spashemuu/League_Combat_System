using System;
using System.Numerics;
using Dalamud.Interface.Windowing;
using ImGuiNET;

namespace SamplePlugin.Windows;

public class TalentTree : Window, IDisposable
{
    private Configuration Configuration;
    //private Plugin Plugin;
    public TalentTree(Plugin plugin) : base(
        "LCS Talent Tree",
        ImGuiWindowFlags.NoScrollbar |
        ImGuiWindowFlags.NoScrollWithMouse)
    {
        //this.Size = new Vector2(600, 300);
        //this.SizeCondition = ImGuiCond.Always;

        this.Configuration = plugin.Configuration;
    }

    public void Dispose() { }

    public override void Draw()
    {
        // can't ref a property, so use a local copy
        // stats
        var smashingValue = this.Configuration.Smashing;
        // talent tree
        var fleetFootedValue = this.Configuration.FleetFootedValue;
        var evasionValue = this.Configuration.EvasionValue;
        var fitnessValue = this.Configuration.FitnessValue;
        var untouchableValue = this.Configuration.UntouchableValue;
        var reactionTimeValue = this.Configuration.ReactionTimeValue;
        var strengthTrainingValue = this.Configuration.StrengthTrainingValue;
        var enduringValue = this.Configuration.EnduringValue;
        var fortitudeValue = this.Configuration.FortitudeValue;
        var rangedCombatTrainingValue = this.Configuration.RangedCombatTrainingValue;
        var meleeCombatTrainingValue = this.Configuration.MeleeCombatTrainingValue;
        var armoredWarfareValue = this.Configuration.ArmoredWarfareValue;
        // This nukes the tree to clear everything to zero
        if (ImGui.Button("Clear Tree"))
        {
            this.Configuration.Smashing = 0;
            this.Configuration.FleetFootedValue = false;
            this.Configuration.EvasionValue = false;
            this.Configuration.UntouchableValue = false;
            this.Configuration.ReactionTimeValue = false;
            this.Configuration.FitnessValue = false;
            this.Configuration.StrengthTrainingValue = false;
            this.Configuration.EnduringValue = false;
            this.Configuration.FortitudeValue = false;
            this.Configuration.MeleeCombatTrainingValue = false;
            this.Configuration.RangedCombatTrainingValue = false;
            this.Configuration.ArmoredWarfareValue = false;
            this.Configuration.Save();
        }
        if (ImGui.Checkbox("Fleet Footed", ref fleetFootedValue))
        {
            this.Configuration.FleetFootedValue = fleetFootedValue;
            this.Configuration.Save();
        }
        if (fleetFootedValue == true)
        {
            ImGui.SameLine();
            if (ImGui.Checkbox("Evasion", ref evasionValue))
            {
                this.Configuration.EvasionValue = evasionValue;
                this.Configuration.Save();

            }
        }
        else if (fleetFootedValue == false)
        {
            this.Configuration.EvasionValue = false;
            this.Configuration.UntouchableValue = false;
            this.Configuration.ReactionTimeValue = false;
            this.Configuration.Save();
        }
        if (evasionValue == true)
        {
            ImGui.SameLine();
            ImGui.BeginGroup();
            if (ImGui.Checkbox("Untouchable", ref untouchableValue))
            {
                this.Configuration.UntouchableValue = untouchableValue;
                this.Configuration.Save();
            }
            if (ImGui.Checkbox("Reaction Time", ref reactionTimeValue))
            {
                this.Configuration.ReactionTimeValue = reactionTimeValue;
                this.Configuration.Save();
            }
            ImGui.EndGroup();
        }
        else if (evasionValue == false) 
        {
            this.Configuration.UntouchableValue = false;
            this.Configuration.ReactionTimeValue = false;
            this.Configuration.Save();
        }
        ImGui.Spacing();
        // This if statement is here to handle interaction with a button
        if (ImGui.Checkbox("Fitness", ref fitnessValue))
        {
            this.Configuration.FitnessValue = fitnessValue;
            this.Configuration.Save();
        }     
        if (fitnessValue == true)            
        {
            ImGui.SameLine();
            ImGui.BeginGroup();
            if (ImGui.Checkbox("Strength Training", ref strengthTrainingValue))
            {
                this.Configuration.StrengthTrainingValue = strengthTrainingValue;
                this.Configuration.Save();
            }
            if (strengthTrainingValue == true)
            {
                ImGui.SameLine();
                ImGui.BeginGroup();
                if (ImGui.Checkbox("Enduring", ref enduringValue))
                {
                    this.Configuration.EnduringValue = enduringValue;
                    this.Configuration.Save();
                }
                if (ImGui.Checkbox("Fortitude", ref fortitudeValue))
                {
                    this.Configuration.FortitudeValue = fortitudeValue;
                    this.Configuration.Save();
                }
                ImGui.EndGroup();
            }
            else if (strengthTrainingValue == false)
            {
                this.Configuration.EnduringValue = false;
                this.Configuration.FortitudeValue = false;
            }
            if (ImGui.Checkbox("Melee Combat Training", ref meleeCombatTrainingValue))
            {
                this.Configuration.MeleeCombatTrainingValue = meleeCombatTrainingValue;
                this.Configuration.Save();
            }
            if (ImGui.Checkbox("Ranged Combat Training", ref rangedCombatTrainingValue))
            {
                this.Configuration.RangedCombatTrainingValue = rangedCombatTrainingValue;
                this.Configuration.Save();
            }
            if (ImGui.Checkbox("Armored Warfare", ref armoredWarfareValue))
            {
                this.Configuration.ArmoredWarfareValue = armoredWarfareValue;
                this.Configuration.Save();
            }
            ImGui.EndGroup();
            //ImGui.SameLine();            
        }
        else if (fitnessValue == false)
        {
            this.Configuration.StrengthTrainingValue = false;
            this.Configuration.MeleeCombatTrainingValue = false;
            this.Configuration.RangedCombatTrainingValue = false;
            this.Configuration.ArmoredWarfareValue = false;
            this.Configuration.EnduringValue = false;
            this.Configuration.FortitudeValue = false;
            //cause dalamud seems to preserve info somewhere? I need this in case the checkbox was on to make sure it doesn't subtract from 0
            //if (smashingValue-200 < 0)
            //    this.Configuration.Smashing = smashingValue;
            //else
            //    this.Configuration.Smashing = smashingValue-200;
        }

        //This causes the game to die - fix this
        //ImGui.BeginTable("Output Stats", 3);
        //{
        //    ImGui.TableNextRow();
        //    ImGui.TableSetColumnIndex(0);
        //    ImGui.Text($"Fitness is {this.Configuration.FitnessValue}");
        //    ImGui.TableSetColumnIndex(1);
        //    ImGui.Text($"The Smashing Value is {this.Configuration.Smashing}");
        //}
        //ImGui.EndTable();

    }
}
