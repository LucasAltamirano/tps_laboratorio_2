using System;

namespace Entidades
{
    public class Operando
    {

        private double numero;
        /// <summary>
        ///     Constructor que al no recibir ningun parametro ,setea el valor por defecto a 0
        /// </summary>
        public Operando()
        {
            this.numero = 0;
        }
        /// <summary>
        ///     Constructor  sobrecargado que recibe  string por parametro   ,setea el valor a travez de la propiedad Numero,
        ///     la cual la convierte a Doule
        /// <param name="strNumero">  recibe un string como argumento ,para setear al atributo de la de clase  </param>
        public Operando(string strNumero)
        {
            Numero = strNumero;
        }
        /// <summary>
        /// Constructor  sobrecargado que recibe  Double por parametro  , que a su su ves llama al contructor sobrecargado con string
        /// para asi setear el valor a travez de la propiedad Numero,
        ///     
        /// </summary>
        /// <param name="numero">recibe un double como argumento ,para setear al atributo de la de clase  </param>
        public Operando(double numero) : this(numero.ToString())
        {

        }
        /// <summary>
        ///    Propiedad ( concepto de encapsulamiento) con sólo un descriptor de acceso ( set) que asigna un valor al atributo de clase "numero"
        /// utilizando el método ValidarOperando(); 
        /// </summary>
        private string Numero
        {
            set { numero = ValidarOperando(value); }
        }

        /// <summary>
        ///   Recibe un argumento del tipo string y lo convierte en un double
        /// </summary>
        /// <param name="strNumero">string para convertir en double </param>
        /// <returns> en caso de exito devuelve el valor en string convertido a tipo double , caso contrario retornara 0  </returns>
        private double ValidarOperando(string strNumero)
        {
            double numero;
            bool verificacion;
            verificacion = double.TryParse(strNumero, out numero);

            if (verificacion)
            {
                return numero;
            }
            else
            {
                return 0;
            }

        }
        /// <summary>
        ///    Sobrecarga del operador '+' para sumar dos objetos de tipo Operando.
        /// </summary>
        /// <param name="op1">1er objeto de tipo operando </param>
        /// <param name="op2">2sdo objeto de tipo operando</param>
        /// <returns> un valor del tipo double que es el resultado la suma de los 2 objetos </returns>
        public static double operator +(Operando op1, Operando op2)
        {
            return op1.numero + op2.numero;
        }
        /// <summary>
        ///    Sobrecarga del operador '-' para restar dos objetos de tipo Operando.
        /// </summary>
        /// <param name="op1">1er objeto de tipo operando </param>
        /// <param name="op2">2sdo objeto de tipo operando</param>
        /// <returns> un valor del tipo double que es el resultado la resta de los 2 objetos </returns>
        public static double operator -(Operando op1, Operando op2)
        {
            return op1.numero - op2.numero;
        }
        /// <summary>
        ///    Sobrecarga del operador '*' para multiplicar dos objetos de tipo Operando.
        /// </summary>
        /// <param name="op1">1er objeto de tipo operando </param>
        /// <param name="op2">2sdo objeto de tipo operando</param>
        /// <returns> un valor del tipo double que es el resultado la multiplicacion de los 2 objetos </returns>
        public static double operator *(Operando op1, Operando op2)
        {
            return op1.numero * op2.numero;
        }

        /// <summary>
        ///    Sobrecarga del operador '/' para dividir dos objetos de tipo Operando.
        /// </summary>
        /// <param name="op1">1er objeto de tipo operando </param>
        /// <param name="op2">2sdo objeto de tipo operando</param>
        /// <returns> un valor del tipo double que es el resultado la division de los 2 objetos , en caso del 2do operador sea 0
        /// retornara la constante double.MinValue; </returns>
        public static double operator /(Operando op1, Operando op2)
        {
            if (op2.numero == 0)
            {
                return double.MinValue;
            }
            else
            {
                return op1.numero / op2.numero;
            }

        }

        /// <summary>
        ///    verifica que el parametro recibido ,corresponda a un numero binario ,para eso recorre  cada posicion del string 
        ///    verificando que su valor sea 1 o 0 ;
        /// </summary>
        /// <param name="binario"> valor de tipo string  correspondiente a un numero binario </param>
        /// <returns> retornara true si corresponde a un numero binario ,caso contrario retornara false </returns>
        private static bool EsBinario(string binario)
        {
            for (int i = 0; i < binario.Length - 1; i++)
            {
                if (!(binario[i] == '0' || binario[i] == '1'))
                {
                    return false;
                }
            }
            return true;
        }//end method EsBinario

        /// <summary>
        ///     Convierte un numero binario a numero decimal 
        /// </summary>
        /// <param name="binario">argumento de tipo string para convertir </param>
        /// <returns> en caso de exito ,retornara como string numero convertido a decimal ,caso contrario retornara "valor invalido" , </returns>
        public static string BinarioDecimal(string binario)
        {

            if (EsBinario(binario))
            {

                char[] array = binario.ToCharArray();

                Array.Reverse(array);
                int sum = 0;

                for (int i = 0; i < array.Length; i++)
                {
                    if (array[i] == '1')
                    {

                        sum += (int)Math.Pow(2, i);
                    }
                }
                return sum.ToString();
            }
            else
            {
                return "valor invalido";
            }
        }
        /// <summary>
        ///      Convierte un numero decimal a numero binario
        /// </summary>
        /// <param name="numero">argumento de tipo double para convertir</param>
        /// <returns>en caso de exito ,retornara como string numero convertido a binario ,caso contrario retornara "valor invalido" </returns>

        public static string DecimalBinario(double numero)
        {
            int numEntero = (int)numero;

            if (numEntero > 0)
            {
                String cadena = "";
                while (numEntero > 0)
                {
                    if (numEntero % 2 == 0)
                    {
                        cadena = "0" + cadena;
                    }
                    else
                    {
                        cadena = "1" + cadena;
                    }
                    numEntero = (int)(numEntero / 2);
                }

                return cadena;
            }
            else
            {
                return "valor invalido";
            }


        }
        /// <summary>
        /// Convierte un numero decimal a numero binario (sobrecarga )
        /// </summary>
        /// <param name="numero">argumento de tipo string para convertir</param>
        /// <returns>en caso de exito ,retornara como string numero convertido a binario ,caso contrario retornara "valor invalido" </returns>

        public static string DecimalBinario(string numero)
        {
            if (int.TryParse(numero, out int resultado))
            {
                return DecimalBinario(resultado);
            }
            else
            {
                return "valor invalido";
            }



        }



    }//end Class


}//end Namespace
