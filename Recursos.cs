using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Automatas
{
    public class Recursos
    {
        //busca los estados nuevos en las transiciones y los agrega a la lista de estados
        public List<string> BuscarEstadosNuevos(List<string> estados, List<string> transiciones) {

            
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
        public List<string> AsignarNuevasTransiciones(List<string> estados, List<string> transiciones) {


            int valoresRestantes = estados.Count - transiciones.Count;
            
            for (int i = 0; i < valoresRestantes; i++)
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
                cadena = organizarCadena(cadena);
                transiciones.Add(cadena);
                
            }

            return transiciones;
        }

        // se eliminan los elementos repetidos de una cadena
        // ejemplo la cadena "q1,q2,q2,q3,q3,q5" la retorna asi: "q1,q2,q3,q5"
        public string organizarCadena(string cadena) {
            string[] split = cadena.Split(new char[] { ',' });
            List<string> cadenaNueva = new List<string>();
            foreach (var item in split)
            {
                cadenaNueva.Add(item);
            }

            string cadenaRetorno = null;
            foreach (var item in cadenaNueva.Distinct())
            {
                cadenaRetorno = cadenaRetorno + "," + item;
            }

            cadenaRetorno = cadenaRetorno.TrimStart(',');
            return cadenaRetorno;
        }
    }
}
