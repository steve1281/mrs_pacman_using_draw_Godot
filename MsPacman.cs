using Godot;
using Godot.NativeInterop;
using System;

public partial class MsPacman : Node2D
{
    public double MouthAngle = 20.0f;
    public double Time = 0f;


    public override void _Draw()
    {

        //GD.Print("MsPacman::Draw Called.");
        DrawArc(Vector2.Zero, 100, (float)Mathf.DegToRad(MouthAngle), (float)Mathf.DegToRad(360 - MouthAngle), 60, Colors.Yellow, 200); // body
        
        // eye
        DrawSetTransform(new Vector2(0,0), (float)Mathf.DegToRad(360 - MouthAngle));
        DrawCircle(new Vector2(60, -70), 30, Colors.Black); // eye

        // hair bow
        Vector2[] points = {
            new(0,0),
            new(120, -60),
            new(120, 60)
        };
        // note the use of transforms
        DrawSetTransform(new Vector2(-140, -240), Mathf.DegToRad(-35));
        DrawColoredPolygon(points, Colors.DeepPink);
        DrawSetTransform(new Vector2(-140, -240), Mathf.DegToRad(180 - 35));
        DrawColoredPolygon(points, Colors.DeepPink);
    }

    public override void _Process(double delta)
    {
        MouthAngle = 20 * (Mathf.Sin(Time * double.Tau) + 1) * .5;
        Time += delta;
        QueueRedraw();
    }


}
