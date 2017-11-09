using System;

class Box
{
    private double length;
    private double width;
    private double height;   

    public double Length
    {
        get
        {
            return this.length;
        }
        set
        {
            if (value <= 0)
            {
                throw new ArgumentException("Length cannot be zero or negative.");
            }

            this.length = value;
        }
    }

    public double Width
    {
        get
        {
            return this.width;
        }
        set
        {
            if (value <= 0)
            {
                throw new ArgumentException("Width cannot be zero or negative.");
            }

            this.width = value;
        }
    }

    public double Height
    {
        get
        {
            return this.height;
        }
        set
        {
            if (value <= 0)
            {
                throw new ArgumentException("Height cannot be zero or negative.");
            }

            this.height = value;
        }
    }

    public double Volume()
    {
        var result = width * length * height;

        return result;
    }

    public double LateralSurfaceArea()
    {
        var result = 2 * (length * height) + 2 * (width * height);

        return result;
    }

    public double SurfaceArea()
    {
        var result = 2 * (length * width) + 2 * (length * height) + 2 * (width * height);

        return result;
    }
}

