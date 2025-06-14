using Godot;
using System;

public partial class Main : Node
{
    [Export] public double Speed { get; private set; } = 100; // px/second
    [Export] public Sprite2D MsPacmanPixilated { get; private set; }

    public override void _Ready()
    {
        MsPacmanPixilated.Draw += HandleDraw;  // you can handle the Draw signal
    }

    private void HandleDraw()
    {
        // draw a non-pixelated circle.
        MsPacmanPixilated.DrawCircle(new(-10, 0), 5, Colors.Red);
    }


    public override void _Process(double delta)
    {
        if (Input.IsActionPressed("ui_left"))
        {
            MsPacmanPixilated.Position = new(MsPacmanPixilated.Position.X - (float)(delta * Speed), MsPacmanPixilated.Position.Y);
            MsPacmanPixilated.FlipH = true;

        }
        else if (Input.IsActionPressed("ui_right"))
        {
            MsPacmanPixilated.Position = new(MsPacmanPixilated.Position.X + (float)(delta * Speed), MsPacmanPixilated.Position.Y);
            MsPacmanPixilated.FlipH = false;

        }
    }

}
