using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Automatas
{
    public static class Recursos
    {
        //busca los estados nuevos en las transiciones y los agrega a la lista de estados
        public static List<string> BuscarEstadosNuevos(List<string> estados, List<string> transiciones)
        {

            foreach (var transicion in transiciones)
            {   
                string transicionOrdenada = Ordenarcadena(transicion);
                if (transicionOrdenada != "{}" && !estados.Contains(transicionOrdenada))
                {
                    estados.Add(transicionOrdenada);
                }
            }

            return estados;
        }

        //a los estados nuevos se les asigna las nuevas transiciones 
        public static List<string> AsignarNuevasTransiciones(List<string> estados, List<string> transiciones)
        {

            for (int valoresRestantes = estados.Count -
                transiciones.Count; valoresRestantes > 0; --valoresRestantes)
            {
                int index = transiciones.Count;
                string estado = estados[index];
                string[] split = estado.Split(new char[] { ',' });
                string cadena = null;

                foreach (var item in split)
                {
                    int indice = estados.IndexOf(item);
                    string valor = transiciones[indice];
                    if (valor != "{}")
                    {
                        cadena = cadena + "," + valor;
                    }
                }
            
                if (cadena == null) {
                    cadena = "{}";
                }

                if (cadena != null)
                {
                    cadena = cadena.TrimStart(',');
                }

                cadena = Ordenarcadena(cadena);
                cadena = Organizar(cadena);
                transiciones.Add(cadena);
                
            }

            return transiciones;
        }

        // se eliminan los elementos repetidos de una cadena
        // ejemplo la cadena "q1,q2,q2,q3,q3,q5" la retorna asi: "q1,q2,q3,q5"
        public static string Organizar(string cadena) => string.Join(
        ",", cadena.Split(',').Distinct());


        //Refactorizar
        public static List<List<string>> EliminarEstadosSinUso(List<string> estados, List<string> transiciones_0, List<string> transiciones_1)
        {
            List<string> estadosOrganizados = new List<string>();
            List<string> transiciones_0_Organizadas = new List<string>();
            List<string> transiciones_1_Organizadas = new List<string>();
            List<List<string>> elementos = new List<List<string>>();

            //estado inicial
            estadosOrganizados.Add(estados[0]);
            transiciones_0_Organizadas.Add(transiciones_0[0]);
            transiciones_1_Organizadas.Add(transiciones_1[0]);

            //se recorren los demás estados
            for (int i = 1; i < estados.Count; i++)
            {
                if (transiciones_0.Contains(estados[i]) || transiciones_1.Contains(estados[i]))
                {
                    estadosOrganizados.Add(estados[i]);
                    transiciones_0_Organizadas.Add(transiciones_0[i]);
                    transiciones_1_Organizadas.Add(transiciones_1[i]);
                }
            }
            elementos.Add(estadosOrganizados);
            elementos.Add(transiciones_0_Organizadas);
            elementos.Add(transiciones_1_Organizadas);


            return elementos;
        }

        public static string Ordenarcadena(string cadena)
        {
            string[] split = cadena.Split(',').OrderBy(e => e).ToArray();

            string cadenaFinal = null;
            foreach (var item in split)
            {
                cadenaFinal = cadenaFinal + "," + item;
            }

            cadenaFinal = cadenaFinal.TrimStart(',');
            return cadenaFinal;
        }


    }
}
