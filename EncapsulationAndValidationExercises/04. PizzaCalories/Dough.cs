using System;

class Dough
{
    private string flourType;
    private string bakingTechnique;
    private double weight;

    public Dough(string flourType, string bakingTechnique, double weight)
    {
        this.FlourType = flourType;
        this.BakingTechnique = bakingTechnique;
        this.Weight = weight;
    }

    public string FlourType
    {
        get
        {
            return this.flourType;
        }
        private set
        {
            if (value != "white" && value != "wholegrain")
            {
                throw new ArgumentException("Invalid type of dough.");
            }

            this.flourType = value;
        }
    }

    public string BakingTechnique
    {
        get
        {
            return this.bakingTechnique;
        }
        private set
        {
            if (value != "crispy" && value != "chewy" && value != "homemade")
            {
                throw new ArgumentException("Invalid type of dough.");
            }

            this.bakingTechnique = value;
        }
    }

    public double Weight
    {
        get
        {
            return this.weight;
        }
        private set
        {
            if (value < 1 || value > 200)
            {
                throw new ArgumentException("Dough weight should be in the range [1..200].");
            }

            this.weight = value;
        }
    }

    public double Calories()
    {
        var result = 0d;

        if (this.flourType == "white")
        {
            if (this.bakingTechnique == "crispy")
            {
                result = (2 * this.weight) * 1.5 * 0.9;
            }
            else if (this.bakingTechnique == "chewy")
            {
                result = (2 * this.weight) * 1.5 * 1.1;
            }
            else
            {
                result = (2 * this.weight) * 1.5 * 1;
            }
        }
        else
        {
            if (this.bakingTechnique == "crispy")
            {
                result = (2 * this.weight) * 1 * 0.9;
            }
            else if (this.bakingTechnique == "chewy")
            {
                result = (2 * this.weight) * 1 * 1.1;
            }
            else
            {
                result = (2 * this.weight) * 1.0 * 1;
            }
        }

        return result;
    }
}
