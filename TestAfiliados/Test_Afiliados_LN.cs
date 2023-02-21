using AccesoDeDatos.Afiliacion;
using LogicaDeNegocios.Afiliacion;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using OBJ;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assert = NUnit.Framework.Assert;

namespace TestAfiliados
{
    
    public class Test_Afiliados_LN
    {

        private IAfiliacion_AD _IAfiliacion_AD;


        [Test]
        public void CuandoHayAfiliados()
        {
            //Arrange
            var datosAfi = new DatosAfiliacionOBJ();
            datosAfi.Nombre = "Kathy";
            datosAfi.Apellido = "Santos";
            datosAfi.Direccion = "San Juan Opico";
            datosAfi.Telefono = "76167045";

            var arregloAfi = new List<DatosAfiliacionOBJ>();
            arregloAfi.Add(datosAfi);

            _IAfiliacion_AD = Substitute.For<IAfiliacion_AD>();
            _IAfiliacion_AD.BuscarAfiliado().ReturnsForAnyArgs(arregloAfi);

            Afiliacion_LN afiliacion_LN = new Afiliacion_LN(_IAfiliacion_AD);

            //Act
            var resutado = afiliacion_LN.BuscarAfiliado();

            //Assert
            Assert.IsNotNull(resutado);
        }

        [Test]
        public void CuandoNoHayAfiliados()
        {
            //Arrange
            
            var arregloAfi = new List<DatosAfiliacionOBJ>();
         
            _IAfiliacion_AD = Substitute.For<IAfiliacion_AD>();
            _IAfiliacion_AD.BuscarAfiliado().ReturnsForAnyArgs(arregloAfi);

            Afiliacion_LN afiliacion_LN = new Afiliacion_LN(_IAfiliacion_AD);

            //Act
            var resutado = afiliacion_LN.BuscarAfiliado();

            //Assert
            Assert.IsEmpty(resutado);
        }
    }
}
