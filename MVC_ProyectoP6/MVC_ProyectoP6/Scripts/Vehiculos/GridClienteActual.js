﻿
$(function () {
    obtenerRegistros();
});



function obtenerRegistros() {

        ///dirección a donde se enviarán los datos
        var url = '/Home/MostrarInfoUsuario';
        ///parámetros del método, es CASE-SENSITIVE
        var parametros = {
        };
        ///invocar el método
        var usuarioIdObtenido;
        $.ajax({
            url: url,
            dataType: 'json',
            type: 'post',
            contentType: 'application/json',
            data: JSON.stringify(parametros),
            success: function (data, textStatus, jQxhr) {

                usuarioIdObtenido = data.usuarioActual;
                /////construir la dirección del método del servidor
                var urlMetodo = '/Vehiculos/RetornaVehiculosClienteActual'
                var parametros = {
                    idCliente: usuarioIdObtenido
                };
                var funcion = creaGridKendo;
                ///ejecuta la función $.ajax utilizando un método genérico
                //para no declarar toda la instrucción siempre
                ejecutaAjax(urlMetodo, parametros, funcion);
            },
            error: function (jQxhr, textStatus, errorThrown) {
                alert(errorThrown);
            },
        });
    

}

///encargada de crear el grid de kendo y mostrar
//los datos obtenidos al llamar al método
// RetornaListaClientes
function creaGridKendo(data) {
    $("#gridClienteVehiculos").kendoGrid({
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
                field: 'Cedula',
                //texto del encabezado
                title: 'Cedula'
            },
            {
                //propiedad de la fuente de datos
                //caseSensitive
                field: 'NombreCompleto',
                //texto del encabezado
                title: 'Nombre Cliente'
            },
            {
                //propiedad de la fuente de datos
                //caseSensitive
                field: 'PlacaVehiculo',
                //texto del encabezado
                title: 'Placa Vehiculo '

            },
            {
                title: "Acciones",
                template: function (dataItem) {
                    return "<a class='btn btn-primary' href='/Vehiculos/ModificaVehiculo?idVehiculo=" + dataItem.idVehiculo + "'>Modificar</a>"
                        + " " + "<a class='btn btn-danger' href='/Vehiculos/EliminaVehiculo?idVehiculo=" + dataItem.idVehiculo + "'>Elimimar</a>"
                }
            }
        ],
        filterable: true, //propiedad para filtrar

        toolbar: ["excel", "pdf"],//propiedad para exportar 
        excel: {
            fileName: "Lista de Vehiculos.xlsx", //agregar nombre al archivo para descarga 
            filterable: true,
            allPages: true //mostrar todo 
        },

        pdf: {
            fileName: "Lista de Vehiculos.pdf", //agregar nombre
            author: "UMCA", //NOMBRE AUTOR
            creator: "Wagner Diaz",//Nombre Creador
            date: new Date(), //fecha
        }
    });
}