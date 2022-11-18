using System;
using System.Text;
using System.Collections.Generic;


Programa.Rodar();

Ponto sortearPonto()
    {
        Ponto pontinho = new Ponto();
        pontinho.sortearPonto();
        return pontinho;
    }

public struct Ponto
{
    public double x { get; set; }
    public double y { get; set; }

    public void sortearPonto()
    {
        Random rand = new Random();

        this.x = rand.NextDouble() * 100;
        this.y = rand.NextDouble() * 100;
    }
}

public abstract class Figura
{
    public abstract bool EstaDentro(Ponto p);
}

public class LilSquare : Figura
{
    public override bool EstaDentro(Ponto p)
    {
        if(p.x <=50.0 & p.y <= 50.0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}

public class Triangle : Figura
{
    public override bool EstaDentro(Ponto p)
    {
        double dif = 100-p.x;
        if(p.y < dif)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}

public class Circle : Figura
{
    public override bool EstaDentro(Ponto p)
    {
        double termo1 = Math.Pow((p.x - 50),2.0);
        double termo2 = Math.Pow((p.y - 50),2.0);
        double dist = Math.Sqrt(termo1 + termo2);
        if(dist < 0){
            dist = -dist;
        }
        if(dist < 50)
        {
            return true;
        }
        else
        {
            return false;
        }

    }
}

public static class Programa
{
    public static int QtdPt = 10000;
    public static Ponto[] pontinhos { get; set; } = new Ponto[QtdPt];
    public static LilSquare quadradinho = new LilSquare();
    public static Triangle triangulinho = new Triangle();
    public static Circle circulinho = new Circle();
    public static int plilsquare { get; set; }
    public static int ptriangle { get; set; }
    public static int pcircle { get; set; }

    public static void Rodar()
    {
        for (int i = 0; i < QtdPt; i++)
        {
            pontinhos[i].sortearPonto();

            if(quadradinho.EstaDentro(pontinhos[i]))
            {
                plilsquare += 1;
            }
            if(triangulinho.EstaDentro(pontinhos[i]))
            {
                ptriangle += 1;
            }
            if(circulinho.EstaDentro(pontinhos[i]))
            {
                pcircle += 1;
            }
        }

        double divisor = (double)QtdPt/4;
        double piaprox = pcircle/divisor;

        Console.WriteLine($"{plilsquare} pontos no Lil Square");
        Console.WriteLine($"{ptriangle} pontos no Triangle");
        Console.WriteLine($"{pcircle} pontos no Circle");
        Console.Write($"Pi é aproximadamente ");
        Console.Write(piaprox);
    }
}