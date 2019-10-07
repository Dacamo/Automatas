﻿using System;
using System.Collections.Generic;

namespace Automatas
{
    class Program
    {
        static void Main(string[] args)
        {

            Recursos recursos = new Recursos();


            //se asginan todos los estados iniciales
            List<string> estados = new List<string>();
            
            estados.Add("q0");
            estados.Add("q1");
            estados.Add("q2");
            estados.Add("q3");
            estados.Add("q4");
            estados.Add("q5");


            estados.Add("q6");
            estados.Add("q7");
            estados.Add("q8");
            estados.Add("q9");
            estados.Add("q10");
            estados.Add("q11");
            estados.Add("q12");
            estados.Add("q13");
            

            //se asignan todas las transiciones para 0
            List<string> transiciones_0 = new List<string>();
            /*
            transiciones_0.Add("q1");
            transiciones_0.Add("q2");
            transiciones_0.Add("q3");
            transiciones_0.Add("q4");
            transiciones_0.Add("{}");
            transiciones_0.Add("{}");*/

            transiciones_0.Add("q4");
            transiciones_0.Add("{}");
            transiciones_0.Add("{}");
            transiciones_0.Add("q9");
            transiciones_0.Add("q5");
            transiciones_0.Add("q0");
            transiciones_0.Add("{}");
            transiciones_0.Add("{}");
            transiciones_0.Add("q10");
            transiciones_0.Add("q10");
            transiciones_0.Add("q3");
            transiciones_0.Add("{}");
            transiciones_0.Add("{}");
            transiciones_0.Add("q3");


            //se asignan todas las transiciones para 1
            List<string> transiciones_1 = new List<string>();
            /*
            transiciones_1.Add("{}");
            transiciones_1.Add("q1,q2");
            transiciones_1.Add("q2,q3");
            transiciones_1.Add("q3,q4");
            transiciones_1.Add("q4,q5");
            transiciones_1.Add("{}");*/


            transiciones_1.Add("q1,q4");
            transiciones_1.Add("q2");
            transiciones_1.Add("q3");
            transiciones_1.Add("q9");
            transiciones_1.Add("q5,q6");

            transiciones_1.Add("q0,q11");
            transiciones_1.Add("q7");
            transiciones_1.Add("q8");
            transiciones_1.Add("q10");
            transiciones_1.Add("q10");
            transiciones_1.Add("q3");
            transiciones_1.Add("q12");
            transiciones_1.Add("q13");
            transiciones_1.Add("q3");

            //
            for (int i = 0; i < 55555; i++)
            {
                //buscar los estados nuevos
                estados = recursos.BuscarEstadosNuevos(estados, transiciones_0);
                estados = recursos.BuscarEstadosNuevos(estados, transiciones_1);


                //asignar las nuevas transiciones
                transiciones_0 = recursos.AsignarNuevasTransiciones(estados, transiciones_0);
                transiciones_1 = recursos.AsignarNuevasTransiciones(estados, transiciones_1);
            }

            //imprimir el total de estados
             Console.WriteLine("el numero total de estados:" + " " + estados.Count);


            //imprimir los estados, con sus transiciones (organizar)
            /*for (int i = 0; i < estados.Count; i++)
            {
                Console.WriteLine(estados[i]+"                 " + transiciones_0[0] + "              " + transiciones_1[i]);
               
            }*/

            //imprimir todos los estados
            foreach (var item in estados)
            {
                Console.WriteLine(item);
            }
















        }

    }
}
