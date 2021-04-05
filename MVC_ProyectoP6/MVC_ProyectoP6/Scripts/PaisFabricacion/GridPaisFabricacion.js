
$(function () {
    obtenerRegistros();
});


/// funcion que obtiene los registros
// del metodo del controlador
// RetornaEmpresas()
function obtenerRegistros() {
    /////construir la dirección del método del servidor
    var urlMetodo = '/PaisFabricacion/RetornaPaisFabricacion'
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
                field: 'CodigoPaisFabricante',
                //texto del encabezado
                title: 'Codigo Pais '

            },
             
              {
                //propiedad de la fuente de datos
                //caseSensitive
                field: 'PaisFabricante',
                //texto del encabezado
                title: 'Nombre Pais '
            },
              
            {
                title: "Acciones",
                template: function (dataItem) {
                    return "<a class='btn btn-primary' href='/PaisFabricacion/ModificaPaisFabricante?idPaisFabricante=" + dataItem.idPaisFabricante + "'>Modificar</a>" 
                        + " " + "<a class='btn btn-danger' href='/PaisFabricacion/EliminaPaisFabricante?idPaisFabricante=" + dataItem.idPaisFabricante + "'>Elimimar</a>"

                   
                }
            }            
        ],
        filterable: true, //propiedad para filtrar

        toolbar: ["excel", "pdf"],//propiedad para exportar 
        excel: {
            fileName: "Lista de Pais Fabricante.xlsx", //agregar nombre al archivo para descarga 
            filterable: true,
            allPages: true //mostrar todo 
        },

        pdf: {
            fileName: "Lista de Pais Fabricante.pdf", //agregar nombre
            author: "UMCA", //NOMBRE AUTOR
            creator: "Wagner Diaz",//Nombre Creador
            date: new Date(), //fecha
        }
    });
}