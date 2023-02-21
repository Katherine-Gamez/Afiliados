using AccesoDeDatos.Afiliacion;
using OBJ;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaDeNegocios.Afiliacion
{
    public class Afiliacion_LN : IAfiliacion_LN
    {
        private readonly IAfiliacion_AD _afiliacionad;
        public Afiliacion_LN (IAfiliacion_AD afiliacionad)
        {
            _afiliacionad = afiliacionad;
        }
        public string AgregarAfiliado(DatosAfiliacionOBJ datos)
        {
           

            return _afiliacionad.AgregarAfiliado(datos);

        }
        
        public string ActualizarAfiliado(DatosAfiliacionOBJ datos)
        {

            return _afiliacionad.ActualizarAfiliado(datos);

        }
        public List<DatosAfiliacionOBJ> BuscarAfiliado()
        {


            return _afiliacionad.BuscarAfiliado();
        }
        public string EliminarAfiliado(DatosAfiliacionOBJ datos)
        {
            return _afiliacionad.EliminarAfiliado(datos);
        }
    }
}
