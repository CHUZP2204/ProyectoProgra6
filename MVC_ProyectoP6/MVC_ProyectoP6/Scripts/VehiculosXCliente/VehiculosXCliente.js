
$(function () {
    obtenerRegistros();
});


/// funcion que obtiene los registros
// del metodo del controlador
// RetornaEmpresas()
function obtenerRegistros() {
    /////construir la dirección del método del servidor
    var urlMetodo = '/Reportes/RetornaVehiculosXCliente'
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
            {
                //propiedad de la fuente de datos
                //caseSensitive
                field: 'NombreCompleto',
                //texto del encabezado
                title: 'Nombre Cliente '

            },
            {
                //propiedad de la fuente de datos
                //caseSensitive
                field: 'Cedula',
                //texto del encabezado
                title: 'Cedula '
            },
            {
                //propiedad de la fuente de datos
                //caseSensitive
                field: 'PlacaVehiculo',
                //texto del encabezado
                title: 'Placa Vehiculo '
            },
            {
                //propiedad de la fuente de datos
                //caseSensitive
                field: 'TipoVehiculo',
                //texto del encabezado
                title: 'Tipo  '
            },
            {
                //propiedad de la fuente de datos
                //caseSensitive
                field: 'TipoMarcaVehiculo',
                //texto del encabezado
                title: 'Marca  '
            },
        ],
        filterable: true, //propiedad para filtrar

        toolbar: ["excel", "pdf"],//propiedad para exportar 
        excel: {
            fileName: "Lista Vehiculos Por Cliente.xlsx", //agregar nombre al archivo para descarga 
            filterable: true,
            allPages: true //mostrar todo 
        },

        pdf: {
            fileName: "Lista Vehiculos Por Cliente.pdf", //agregar nombre
            author: "UMCA", //NOMBRE AUTOR
            creator: "Wagner Diaz",//Nombre Creador
            date: new Date(), //fecha
        }
    });
}