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
        public List<DatosAfiliacionOBJ> BuscarAfiliados()
        {


            return _afiliacionad.BuscarAfiliados();
        }
        public List<DatosAfiliacionOBJ> BuscarUnAfiliado(int id)
        {


            return _afiliacionad.BuscarUnAfiliado(id);
        }
        public string EliminarAfiliado(DatosAfiliacionOBJ datos)
        {
            return _afiliacionad.EliminarAfiliado(datos);
        }
    }
}
