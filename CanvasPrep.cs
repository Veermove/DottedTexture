using System;
using System.Drawing;
// Adding reference to assembly:
// Dotnet add package System.Drawing.Common

class TextureGen
{


    Color[,] imageInfo;
    Bitmap bitmap;

    public void Draw()
    {
        bitmap = new Bitmap(main.xSize, main.ySize);
        ColorCalc temp = new ColorCalc();
        imageInfo = temp.GenerateTexture();
        ColorBitmap(imageInfo);
        bitmap.Save("Texture.png");
    }

    public void ColorBitmap(Color[,] info)
    {
        for (int x = 0; x < main.xSize; x++)
        {
            for (int y = 0; y < main.ySize; y++)
            {
                bitmap.SetPixel(x, y, info[x,y]);
            }
        }
    }
}
