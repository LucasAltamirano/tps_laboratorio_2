namespace Entidades
{
    public static class Calculadora
    {
        /// <summary>
        ///     Recibe un caracter y valida que el mismo corresponda a un operador matematico 
        /// </summary>
        /// <param name="operador"> recibe un valor del tipo char a validar</param>
        /// <returns>una vez validado retornara el operador correspondiente o retornara + por defecto </returns>
        private static char ValidarOperador(char operador)
        {
            char op;
           
            switch (operador)
            {
                case '-':
                    op = '-';
                    break;
                case '/':
                    op = '/';
                    break;

                case '*':
                    op = '*';
                    break;
                default:
                    op = '+';
                    break;
            }
            return op;
        }//end Switch
        /// <summary>
        /// realiza un calculo matematico correspondiente entre dos objetos de tipo operando
        /// </summary>
        /// <param name="num1">1er operando para el calculo matematico </param>
        /// <param name="num2">2do operando para el calculo matematico</param>
        /// <param name="operador">operador correspondiente para realizar el calculo</param>
        /// <returns>un valor double correspondiente al resultado de la operacion matematica</returns>
        public static double Operar(Operando num1, Operando num2, char operador)
        {
            double valor;
            switch (ValidarOperador(operador))
            {
                case '*':
                    valor = num1 * num2;
                    break;
                case '-':
                    valor = num1 - num2;
                    break;
                case '/':
                    valor = num1 / num2;
                    break;
                default:
                    valor = num1 + num2;
                    break;
            }

            return valor;

        }



    }// end Class
}// end Namespace
