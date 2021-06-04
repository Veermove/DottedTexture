using System;
using System.Drawing;
// Adding reference to assembly:
// Dotnet add package System.Drawing.Common

class TextureGen
{
    const int xSize = 1000;
    const int ySize = 1000;

    public void Draw()
    {
        var bitmap = new Bitmap(xSize, ySize);
    }
}
