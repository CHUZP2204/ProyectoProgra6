﻿
$(function () {
    obtenerRegistros();
});


/// funcion que obtiene los registros
// del metodo del controlador
// RetornaEmpresas()
function obtenerRegistros() {
    /////construir la dirección del método del servidor
    var urlMetodo = '/VehiculoXcliente/RetornaVehiculosXCliente'
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
                field: 'idVehiculo',
                //texto del encabezado
                title: 'id Vehiculo '

            },

            {
                //propiedad de la fuente de datos
                //caseSensitive
                field: 'idCliente',
                //texto del encabezado
                title: 'id Cliente '
            },

            {
                title: "Acciones",
                template: function (dataItem) {
                    return "<a class='btn btn-primary' href='/VehiculoXcliente/ModificaVehCliente?idVehiculoXCliente=" + dataItem.idVehiculoXCliente + "'>Modificar</a>"
                        + " " + "<a class='btn btn-danger' href='/VehiculoXcliente/EliminaVehCliente?idVehiculoXCliente=" + dataItem.idVehiculoXCliente + "'>Elimimar</a>"


                }
            }
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