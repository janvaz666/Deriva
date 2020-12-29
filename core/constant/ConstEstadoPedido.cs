using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace core.constant
{
    [SuppressMessage("ReSharper", "IdentifierTypo")]
    [SuppressMessage("ReSharper", "StringLiteralTypo")]
    public static class ConstEstadoPedido
    {
        public const int SinConfirmar = 1;
        public const int ProcesoEntrega = 2;
        public const int Entregado = 3;
        public const int Confirmado = 4;
        public const int DevueltoValidacion = 5;
        public const int Declinado = 6;
        
        private static readonly Dictionary<int, Array> Estados = new Dictionary<int, Array>()
        {
            {SinConfirmar, new string[]{ "Sin confirmar", "unconfirmed" }},
            {ProcesoEntrega, new string[]{ "en proceso de entrega", "in_delivery" }},
            {Entregado, new string[]{ "entregado", "delivered" }},
            {Confirmado, new string[]{ "confirmado", "confirmed" }},
            {DevueltoValidacion, new string[]{ "devuelto para validación", "returned_validation" }},
            {Declinado, new string[]{ "declinado", "declined" }}
        };

        public static string GetNombre(int estado)
        {
            return Estados[estado].GetValue(0)?.ToString();
        }
        
        public static string GetValue(int estado)
        {
            return Estados[estado].GetValue(1)?.ToString();
        }

        public static Dictionary<int, Array> GetEstados()
        {
            return Estados;
        }
    }
}