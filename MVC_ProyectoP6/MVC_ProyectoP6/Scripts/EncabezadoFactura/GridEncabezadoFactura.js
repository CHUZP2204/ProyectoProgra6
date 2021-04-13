
$(function () {
    obtenerRegistros();
});


/// funcion que obtiene los registros
// del metodo del controlador
// RetornaEmpresas()
function obtenerRegistros() {
    /////construir la dirección del método del servidor
    var urlMetodo = '/EncabezadoFactura/RetornaEncabezadoFactura'
    var parametros = {};
    var funcion = creaGridKendo;
    ///ejecuta la función $.ajax utilizando un método genérico
    //para no declarar toda la instrucción siempre
    ejecutaAjax(urlMetodo, parametros, funcion);
}
///encargada de crear el grid de kendo y mostrar
//los datos obtenidos al llamar al método
// RetornaListaClientes
function creaGridKendo(data) {
    $("#divKendoGrid").kendoGrid({
        //asignar la fuente de datos al objeto
        //kendo grid
        dataSource: {
            data: data.resultado,
            pageSize: 4 //paginacion
        },
        pageable: true,  //pasar paginas numeracion 
        columns: [  //Mostrar las columnas
            /*{
                field: 'idCliente',
                title: 'Cliente '

            },*/
            /*{{
                field: 'idVehiculo',
                title: 'Vehiculo '

            },*/
            {
                field: 'Fecha',
                title: 'Fecha',
                template: "#= kendo.toString(kendo.parseDate(Fecha, 'yyyy-MM-dd'), 'MM/dd/yyyy') #"
            },
            {
                field: 'MontoTotalServicios', 
                title: 'Monto Total Servicios '

            },

            {
                field: 'EstadoFactura',
                title: 'Estado Factura '
            },
   
        ],
        filterable: true, //propiedad para filtrar

        toolbar: ["excel", "pdf"],//propiedad para exportar 
        excel: {
            fileName: "Lista Encabezados facturas.xlsx", //agregar nombre al archivo para descarga 
            filterable: true,
            allPages: true //mostrar todo 
        },

        pdf: {
            fileName: "Lista Encabezados facturas.pdf", //agregar nombre
            author: "UMCA", //NOMBRE AUTOR
            creator: "Wagner Diaz",//Nombre Creador
            date: new Date(), //fecha
        }
    });
}