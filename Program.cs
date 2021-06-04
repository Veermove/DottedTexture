using System;

class main
{
    public const int xSize = 1000;
    public const int ySize = 1000;

    public const int PointsAmount = 50;
    public static void Main(String[] args)
    {
        TextureGen temp = new TextureGen();
        temp.Draw();
        Console.WriteLine("Done!");
    }
}
