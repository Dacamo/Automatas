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
                if (transicion != "{}" && !estados.Contains(transicion))
                {
                    estados.Add(transicion);
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
                

                cadena = Organizar(cadena);
                transiciones.Add(cadena);
                
            }

            return transiciones;
        }

        // se eliminan los elementos repetidos de una cadena
        // ejemplo la cadena "q1,q2,q2,q3,q3,q5" la retorna asi: "q1,q2,q3,q5"
        public static string Organizar(string cadena) => string.Join(
        ",", cadena.Split(',').Distinct()
    );
    }
}
