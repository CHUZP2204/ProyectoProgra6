$(function () {
    obtenerRegistrosVehiculosCliente();
});


/// funcion que obtiene los registros
// del metodo del controlador
// RetornaPersonasLista()
function obtenerRegistrosVehiculosCliente() {
    /////construir la dirección del método del servidor
    var urlMetodo = '/Usuarios/VehiculoCliente'
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
    $("#gridListaVehiculosPorCliente").kendoGrid({
        ///Asignar La Fuente De Datos Al Objeto
        ///Kendo Grid
        dataSource: {
            data: data.resultado,
            pageSize: 10
        },
        pageable: true,
        columns: [
            ///Cada Columna Agregada Por Llaves
            {
                ///Propiedad De La Fuente De Datos A Mostrar
                field: 'NombreCompleto',
                ///Texto Del Encabezado
                title: 'Nombre'
            },
            {
                field: 'Cedula',
                title: 'Identificacion'
            },
            {
                field: 'PlacaVehiculo',
                title: 'Placa'
            },
            {
                field: 'TipoMarcaVehiculo',
                title: 'Marca Vehiculo'
            },
            {
                field: 'TipoVehiculo',
                title: 'Tipo Vehiculo'
            },
            {
                title: "Acciones",
                template: function (dataItem) {
                    return "<a class='btn btn-success' href='/Personas/PersonaModifica?id_Persona=" + dataItem.id_Persona + "'>Modificar</a> " +
                        "<a class='btn btn-danger'  href='/Personas/PersonaElimina?id_Persona=" + dataItem.id_Persona + "'>Eliminar</a > "
                }
            }
        ],
        filterable: true,
        toolbar: ["excel", "pdf"],
        excel: {
            fileName: "Lista De Personas.xlsx",
            filterable: true,
            allPages: true
        },
        pdf: {
            fileName: "Lista De Personas.pdf",
            author: "UMCA",
            creator: "Jesus Perez S",
            date: new Date(),
        }

    });
}