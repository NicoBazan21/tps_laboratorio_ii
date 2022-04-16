using System;

namespace Entidades
{
    public static class Calculadora
    {
        /// <summary>
        /// Valida el operador recibido por parametro
        /// </summary>
        /// <param name="operador"></param> recibe un char de parametro para ser validado
        /// <returns></returns> retorna el operador correcto, en caso contrario, retorna +
        private static char ValidarOperador(char operador)
        {
            if (operador != '+'
            && operador != '-'
            && operador != '*'
            && operador != '/')
            {
                return operador = '+';
            }
            else
            {
                return operador;
            }
        }
        /// <summary>
        /// realiza la operacion seleccionada entre 2 objetos de tipo operando
        /// </summary>
        /// <param name="num1"></param>recibe el obj Operando num1
        /// <param name="num2"></param>recibe el obj Operando num2
        /// <param name="operador"></param>recibe el parametro de operacion a sumar
        /// <returns></returns>retorna la operacion realizada
        public static double Operar(Operando num1, Operando num2, char operador)
        {
            operador = ValidarOperador(operador);
            switch (operador)
            {
                case '-':
                    return num1 - num2;
                case '*':
                    return num1 * num2;
                case '/':
                    return num1 / num2;
                default:
                    return num1 + num2;
            }
        }
    }
}
