using System;
using System.Numerics;
using Dalamud.Interface.Internal;
using Dalamud.Interface.Windowing;
using ImGuiNET;

namespace LeagueCombatSystem.Windows;

public class MainWindow : Window, IDisposable
{
    private IDalamudTextureWrap GoatImage;
    private Plugin Plugin;

    public MainWindow(Plugin plugin, IDalamudTextureWrap goatImage) : base(
        "LCS Home Screen", ImGuiWindowFlags.NoScrollbar | ImGuiWindowFlags.NoScrollWithMouse)
    {
        this.SizeConstraints = new WindowSizeConstraints
        {
            MinimumSize = new Vector2(375, 330),
            MaximumSize = new Vector2(float.MaxValue, float.MaxValue)
        };

        this.GoatImage = goatImage;
        this.Plugin = plugin;
    }

    public void Dispose()
    {
        this.GoatImage.Dispose();
    }

    public override void Draw()
    {
        //ImGui.Text($"The random config bool is {this.Plugin.Configuration.SomePropertyToBeSavedAndWithADefault}");

        if (ImGui.Button("Show Settings"))
        {
            this.Plugin.DrawConfigUI();
        }
        //if (ImGui.Button("Talent Tree"))
        //{
        //    this.Plugin.DrawTalentTreeUI();
        //}

        ImGui.Spacing();

        //ImGui.Text("Have a goat:");
        //ImGui.Indent(55);
        //ImGui.Image(this.GoatImage.ImGuiHandle, new Vector2(this.GoatImage.Width, this.GoatImage.Height));
        //ImGui.Unindent(55);

        // Top Row: Image/Health - Armor - Weapons - Utility Links (Compedium, Character Select, Edit Tree, Defense Calc, Reset
        ImGui.BeginGroup();
        ImGui.Image(this.GoatImage.ImGuiHandle, new Vector2(this.GoatImage.Width, this.GoatImage.Height));
        ImGui.Text("A health bar");
        ImGui.EndGroup();
        ImGui.SameLine();
        ImGui.BeginGroup();
        var MidButtonSize = new Vector2(120, 50);
        if (ImGui.Button("Armor", MidButtonSize))
        { 
        
        }
        if (ImGui.Button("Main Weapon", MidButtonSize))
        {

        }
        if (ImGui.Button("Offhand", MidButtonSize))
        {

        }
        ImGui.EndGroup();
        ImGui.SameLine();
        ImGui.BeginGroup();
        var ButtonSize = new Vector2(120, 30);
        if (ImGui.Button("A drop down box", ButtonSize)) { }
        if (ImGui.Button("Talent Tree", ButtonSize))
        {
            this.Plugin.DrawTalentTreeUI();
        }
        if (ImGui.Button("Compedium", ButtonSize)) { }
        if (ImGui.Button("Defense Calc", ButtonSize)) { }
        if (ImGui.Button("Reset", ButtonSize)) { }
        ImGui.EndGroup();
    }
}
