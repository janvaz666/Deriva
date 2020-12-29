using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using System.Text;

namespace core.helper
{
    public class DateFormatHelper<T> where T : class, new()
    {
        #region propiedades

        public string Message { get; set; }

        #endregion

        #region variables

        private CultureInfo mxCulture;
        private CultureInfo usCulture;
        private string mxFormat = "dd-MM-yyyy";
        private string usFormat = "MM-dd-yyyy";
        private string unFormat = "yyyy-MM-dd";
        private DateTime tempDate;
        private bool res;

        #endregion

        #region constructores

        public DateFormatHelper(){
            mxCulture = new CultureInfo("es-MX");
            usCulture = new CultureInfo("en-US");
        }

        #endregion

        #region métodos

        /// <summary>
        /// Aplica el formato de fecha yyyy-MM-dd a las propiedades
        /// de tipo de fecha de la lista proporcionada
        /// </summary>
        /// <param name="lista">Lista con los datos a procesar</param>
        /// <param name="campos">Lista con los campos de tipos fecha</param>
        /// <returns>Lista con la fecha formateada</returns>
        public List<T> AplicarFormatoFecha(List<T> lista, List<string> campos) {

            if(lista.Count > 0 && campos.Count > 0) { 
                foreach(var l in lista)
                {
                    foreach(var p in l.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance)) {
                        if (campos.Contains(p.Name))
                        {
                            if (null != p || p.CanWrite) {
                                res = false;
                                var currDate = p.GetValue(l).ToString().Replace('/', '-').Split(' ')[0];

                                // Validar si tiene el formato USA: MM-dd-yyyy
                                res = DateTime.TryParseExact(currDate, usFormat, usCulture, DateTimeStyles.None, out tempDate);
                                
                                if (!res)
                                {
                                    // No tiene el formato

                                    // Validar si la fecha corresponde a formato México: dd-MM-yyy
                                    res = DateTime.TryParseExact(currDate, mxFormat, mxCulture, DateTimeStyles.None, out tempDate);

                                    if (!res)
                                    {
                                        // No tiene el formato

                                        // Validar si la fecha corresponde a formato Universal: yyyy-MM-dd
                                        res = DateTime.TryParseExact(currDate, unFormat, mxCulture, DateTimeStyles.None, out tempDate);

                                    }
                                }

                                if (res) {
                                    p.SetValue(l, tempDate.ToString(unFormat));
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                Message = "La lista no contiene elementos";
            }

            return lista;
        }

        #endregion
    }
}
