using System.Collections.Generic;
using System;

App.Run();

//float[] dados = new float[5000];

public class Controller
{   

    float[] dados = new float[40];

    public float Control(float x)
    {

        for (int i = 39; i >= 1 ; i--)
        {
            dados[i] = dados[i-1];
        }

        dados[0] = x;

        int j=0;
        float soma = 0;
        float average = 0.0F;
        
        for (j = 0; j < dados.Length; j++)
        {
            soma += dados[j];
        }

        average = soma / dados.Length;

        float filtered = (float)((1.57*average) - 285);

        return filtered;
    }
}