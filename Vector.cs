using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Progra2
{
    class Vect
    {
        private const int MAX = 10000;
        private int longitud;
        private int[] elementos = new int[MAX];

        public void ModificarLongitud(int nuevaLongitud)
        {
            if (nuevaLongitud >= 0 && nuevaLongitud <= MAX)
            {
                longitud = nuevaLongitud;
            }
            else
            {
                throw new ArgumentOutOfRangeException("nuevaLongitud", "La longitud debe estar entre 0 y " + MAX);
            }
        }

        public int ObtenerLongitud()
        {
            return longitud;
        }

        public void PonerElemento(int pos, int valor)
        {
            if (pos >= 0 && pos < longitud)
            {
                elementos[pos] = valor;
            }
            else
            {
                throw new IndexOutOfRangeException("La posición debe estar entre 0 y " + (longitud - 1));
            }
        }
//Funciones en clase
        public void InsertarElemento(int pos, int valor)
        {
            if (pos != longitud)
            {
                InsertarElemento(pos + 1, elementos[pos]);
                elementos[pos] = valor;
            }
            else
            {
                elementos[pos] = valor;
                longitud = longitud + 1;
            }
        }

        public int ObtenerElemento(int pos)
        {
            if (pos >= 0 && pos < longitud)
            {
                return elementos[pos];
            }
            else
            {
                throw new IndexOutOfRangeException("La posición debe estar entre 0 y " + (longitud - 1));
            }
        }
        public bool CompararVector(int[] vector2)
        {
            if (longitud != vector2.Length)
            {
                return false;
            }

            for (int i = 0; i < longitud; i++)
            {
                if (elementos[i] != vector2[i])
                {
                    return false;
                }
            }

            return true;
        }
        public void Union(int[] vector2)
        {
            for (int i = 0; i < vector2.Length; i++)
            {
                bool existe = false;
                for (int j = 0; j < longitud; j++)
                {
                    if (elementos[j] == vector2[i])
                    {
                        existe = true;
                        break;
                    }
                }

                if (!existe && longitud < MAX)
                {
                    elementos[longitud] = vector2[i];
                    longitud++;
                }
            }
        }
        public bool Subconjunto(int[] vector2)
        {
            for (int i = 0; i < vector2.Length; i++)
            {
                bool encontrado = false;
                for (int j = 0; j < longitud; j++)
                {
                    if (vector2[i] == elementos[j])
                    {
                        encontrado = true;
                        break;
                    }
                }

                if (!encontrado)
                {
                    return false;
                }
            }
            return true;
        }
        public void EliminarDuplicados()
        {
            int nuevaLongitud = 0;

            for (int i = 0; i < longitud; i++)
            {
                bool existe = false;

                for (int j = 0; j < nuevaLongitud; j++)
                {
                    if (elementos[i] == elementos[j])
                    {
                        existe = true;
                        break;
                    }
                }

                if (!existe)
                {
                    elementos[nuevaLongitud] = elementos[i];
                    nuevaLongitud++;
                }
            }

            longitud = nuevaLongitud;
        }

        //fin funciones en clase
        public void SelectionSort()
        {
            for (int i = 0; i < longitud - 1; i++)
            {
                int minIndex = i;
                for (int j = i + 1; j < longitud; j++)
                {
                    if (elementos[j] < elementos[minIndex])
                    {
                        minIndex = j;
                    }
                }
                int temp = elementos[minIndex];
                elementos[minIndex] = elementos[i];
                elementos[i] = temp;
            }
        }
    }

    class Program
    {
        static void Main()
        {
            Vect vector = new Vect();
            vector.ModificarLongitud(4);
            vector.PonerElemento(0, 11);
            vector.PonerElemento(1, 3);
            vector.PonerElemento(2, 8);
            vector.PonerElemento(3, 11);
            vector.InsertarElemento(2, 10);
            int[] vectorprueba = { 1, 2};

            vector.Union(vectorprueba);

            int[] otroVector = { 1, 2, 3, 4, 5 };

            vector.EliminarDuplicados();

            Console.WriteLine(vector.CompararVector(otroVector));
            Console.WriteLine(vector.Subconjunto(vectorprueba));
            Console.WriteLine("Antes de ordenar:");
            for (int i = 0; i < vector.ObtenerLongitud(); i++)
            {
                Console.Write(vector.ObtenerElemento(i) + " ");
            }

            vector.SelectionSort();

            Console.WriteLine("\nDespués de ordenar:");
            for (int i = 0; i < vector.ObtenerLongitud(); i++)
            {
                Console.Write(vector.ObtenerElemento(i) + " ");
            }
        }
    }
}
