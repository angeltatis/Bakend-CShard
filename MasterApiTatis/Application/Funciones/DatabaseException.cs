﻿namespace MasterApiTatis.Application.Funciones
{
    public class DatabaseException : Exception
    {
        public DatabaseException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
