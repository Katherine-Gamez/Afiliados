using LogicaDeNegocios.Afiliacion;
using Microsoft.AspNetCore.Mvc;
using OBJ;

namespace Afiliados.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class AfiliadoController : Controller
    {
        private readonly IAfiliacion_LN _afiliacionln;
        public AfiliadoController (IAfiliacion_LN afiliacionln)
        {
            _afiliacionln = afiliacionln;
        }


        [HttpPost(Name = "Ins")]
        public string AgregarAfiliado (string nombre, string apellido, string direccion, string telefono)
        {
            DatosAfiliacionOBJ datos = new DatosAfiliacionOBJ();
            datos.Nombre = nombre;
            datos.Apellido = apellido;  
            datos.Direccion = direccion;    
            datos.Telefono = telefono;

            return _afiliacionln.AgregarAfiliado(datos);
        }

        [HttpPost(Name = "Upd")]
        public string ActualizarAfiliado(int id,string nombre, string apellido, string direccion, string telefono)
        {
            DatosAfiliacionOBJ datos = new DatosAfiliacionOBJ();
            datos.ID = id;
            datos.Nombre = nombre;
            datos.Apellido = apellido;
            datos.Direccion = direccion;
            datos.Telefono = telefono;

            return _afiliacionln.ActualizarAfiliado(datos);
        }

        [HttpPost(Name = "ReadAll")]
        public List<DatosAfiliacionOBJ> BuscarAfiliados()
        {
            return _afiliacionln.BuscarAfiliados();
        }
        [HttpGet(Name = "Read")]
        public List<DatosAfiliacionOBJ> BuscarUnAfiliado(int id)
        {
            return _afiliacionln.BuscarUnAfiliado(id);
        }

        [HttpPost(Name = "Delete")]
        public string EliminarAfiliado(int Id)
        {
            DatosAfiliacionOBJ datos = new DatosAfiliacionOBJ();
            datos.ID=Id;    

            return _afiliacionln.EliminarAfiliado(datos);
        }
    }
}
