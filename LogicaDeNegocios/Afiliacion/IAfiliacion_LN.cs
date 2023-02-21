using OBJ;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaDeNegocios.Afiliacion
{
    public interface IAfiliacion_LN
    {
        string AgregarAfiliado(DatosAfiliacionOBJ datos);
        string ActualizarAfiliado(DatosAfiliacionOBJ datos);
        List<DatosAfiliacionOBJ> BuscarAfiliado();
        string EliminarAfiliado(DatosAfiliacionOBJ datos);


    }
}
