class Box
{
    private double length;
    private double width;
    private double height;

    public Box(double length, double width, double height)
    {
        this.length = length;
        this.width = width;
        this.height = height;
    }

    public double Length
    {
        get
        {
            return this.length;
        }
        set
        {
            this.Length = value;
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
            this.Width = value;
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
            this.Width = value;
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
