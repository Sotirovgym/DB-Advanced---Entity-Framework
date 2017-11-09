﻿using System;

public class Book
{
    private string author;
    private string title;
    private decimal price;

    public Book(string author, string title, decimal price)
    {       
        this.Author = author;
        this.Titile = title;
        this.Price = price;
    }

    public string Author
    {
        get
        {
            return this.author;
        }
        set
        {
            var authorNames = value.Split(' ');
            if (authorNames.Length == 2)
            {
                if (char.IsDigit(authorNames[1][0]))
                {
                    throw new ArgumentException("Author not valid!");
                }
            }            

            this.author = value;
        }
    }

    public string Titile
    {
        get
        {
            return this.title;
        }
        set
        {
            if (value.Length < 3)
            {
                throw new ArgumentException("Title not valid!");
            }

            this.title = value;
        }
    }

    public decimal Price
    {
        get
        {
            return this.price;
        }
        set
        {
            if (value <= 0)
            {
                throw new ArgumentException("Price not valid!");
            }

            this.price = value;
        }
    }

    public override string ToString()
    {
        return $"Type: {this.GetType().Name}" + Environment.NewLine +
               $"Title: {this.Titile}" + Environment.NewLine +
               $"Author: {this.Author}" + Environment.NewLine +
               $"Price: {this.Price:f2}";
    }
}
