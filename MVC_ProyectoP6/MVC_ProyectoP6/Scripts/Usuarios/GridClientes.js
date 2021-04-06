﻿
$(function () {
    obtenerRegistros();
});


/// funcion que obtiene los registros
// del metodo del controlador
// RetornaEmpresas()
function obtenerRegistros() {
    /////construir la dirección del método del servidor
    var urlMetodo = '/Usuarios/RetornaClientes'
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
                field: 'NombreCompleto',
                title: 'Nombre Completo '
            },
            {
                //propiedad de la fuente de datos
                //caseSensitive
                field: 'Cedula',
                //texto del encabezado
                title: 'Cedula  '
            },

            /*{  
                field: 'FechaNacimiento', 
                title: 'Fecha Nacimiento '
            },*/
            {
                field: 'Genero',
                title: 'Genero '
            },

            {
                field: 'Correo',
                title: 'Correo '
            },
            /* {
                    field: 'idProvincia',
                    title: 'Provincia '
                }, */

            /*  {
                    field: 'idCanton',
                    title: 'Canton '
                }, */
            /*  {
                    field: 'idDistrito',
                    title: 'Distrito '
                }, */

            {
                field: 'TipoUsuario',
                title: 'Tipo Usuario '
            },


            {
                title: "Acciones",
                template: function (dataItem) {
                    return "<a class='btn btn-primary' href='/Usuarios/ModificaUsuario?idCliente=" + dataItem.idCliente + "'>Modificar</a>"
                        + " " + "<a class='btn btn-danger' href='/Usuarios/EliminaUsuario?idCliente=" + dataItem.idCliente + "'>Elimimar</a>"


                }
            }
        ],
        filterable: true, //propiedad para filtrar

        toolbar: ["excel", "pdf"],//propiedad para exportar 
        excel: {
            fileName: "Lista de Clientes.xlsx", //agregar nombre al archivo para descarga 
            filterable: true,
            allPages: true //mostrar todo 
        },

        pdf: {
            fileName: "Lista de Clientes.pdf", //agregar nombre
            author: "UMCA", //NOMBRE AUTOR
            creator: "Wagner Diaz",//Nombre Creador
            date: new Date(), //fecha
        }
    });
}