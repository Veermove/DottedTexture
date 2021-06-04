using System;
using System.Drawing;

class ColorCalc
{
    Color[,] image;

    // distance from each pixel to neares point;
    double[,] dist;

    Point[] pointsArray;
    Color[] grayScalePalette;
    public Color[,] GenerateTexture()
    {
        image = new Color[main.xSize, main.ySize];
        genRandomPoints();
        generateDistancesForAll();
        generateGrayScale();
        for (int x = 0; x < main.xSize; x++)
        {
            for (int y = 0; y < main.ySize; y++)
            {
                image[x, y] = DistToColor(dist[x, y]);
            }
        }
        return image;
    }

    private void generateGrayScale()
    {
        grayScalePalette = new Color[6];
        grayScalePalette[0] = Color.FromArgb(238, 238, 238);
        grayScalePalette[1] = Color.FromArgb(204, 204, 204);
        grayScalePalette[2] = Color.FromArgb(153, 153, 153);
        grayScalePalette[3] = Color.FromArgb(102, 102, 102);
        grayScalePalette[4] = Color.FromArgb(51, 51, 51);
        grayScalePalette[5] = Color.FromArgb(0, 0, 0);
    }

    private Color DistToColor(double dist)
    {
        if (dist > 100.0)
        {
            return grayScalePalette[5];
        } else if (dist <= 100.0 && dist > 90.0)
        {
            return grayScalePalette[4];
        } else if (dist <= 90.0 && dist > 60.0)
        {
            return grayScalePalette[3];
        } else if (dist <= 60.0 && dist > 30.0)
        {
            return grayScalePalette[2];
        } else if (dist <= 30.0 && dist > 10.0)
        {
            return grayScalePalette[1];
        } else {
            return grayScalePalette[0];
        }
    }

    private void generateDistancesForAll()
    {
        dist = new double[main.xSize, main.ySize];
        for(int x = 0; x < main.xSize; x++)
        {
            for(int y = 0; y < main.ySize; y++)
            {
                dist[x, y] = calculateNearestDist(x, y);
            }
        }
    }

    private double calculateNearestDist(int x, int y)
    {
        double[] propDist = new double[main.PointsAmount];
        for (int i = 0; i < propDist.GetLength(0); i++)
        {
            propDist[i] = pointsArray[i].DistnaceTo(x, y);
        }
        double min = propDist[0];
        for (int i = 0; i < propDist.GetLength(0); i++)
        {
            if (min > propDist[i])
            {
                min = propDist[i];
            }
        }
        return min;
    }

    private void genRandomPoints()
    {
        var rand = new Random();
        pointsArray = new Point[main.PointsAmount];
        for (int i = 0; i < pointsArray.GetLength(0); i++)
        {
            pointsArray[i] = new Point(rand.Next(main.xSize), rand.Next(main.ySize));
        }
    }
}

class Point
{
    int x;
    int y;

    public Point(int x, int y)
    {
        this.x = x;
        this.y = y;
    }

    public double DistnaceTo(int givenX, int givenY)
    {
        double xDist = (double)Math.Abs(x - givenX);
        double yDist = (double)Math.Abs(y - givenY);
        return Math.Sqrt((xDist * xDist) + (yDist * yDist));
    }

    public int getX()
    {
        return x;
    }

    public int getY()
    {
        return y;
    }
}
