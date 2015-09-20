using System;

namespace Projeto.Restaurante.Dominio.Exceptions
{
    [Serializable]
    public class MyException : Exception
    {
        #region Construtores
        public MyException() { }
        public MyException(string message) : base(message) { }
        #endregion
    }
}