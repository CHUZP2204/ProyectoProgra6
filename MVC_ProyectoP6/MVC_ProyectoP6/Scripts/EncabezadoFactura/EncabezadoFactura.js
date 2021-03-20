$(function () {
    ///llamamos a la función que se encargará de crear los eventos
    //que nos permitirán controlar cuando se haga una selección en las respectivas listas
    estableceEventosChange();
});

//función que registrará los eventos necesarios para "monitorear"
//cuando se ejecute el método change de las respectivas listas
function estableceEventosChange() {
    ///Evento Change De La Lista Usuarios
    $("#idCliente").change(function () {
        ///Obtenemos el id del Usuario seleccionado
        var idCliente = $("#idCliente").val();
        ///Llamamos A la Funcion que nos permite cargar
        ///todos los cantones asociados a esa provincia seleccionada
        cargaDropdownListVehiculos(idCliente);
    });
}

///carga los registros de los Vehiculos Por Usuarios
function cargaDropdownListVehiculos(pIdVehiculo) {

    ///dirección a donde se enviarán los datos
    var url = '/EncabezadoFactura/RetornaUsersvehiculos';
    ///parámetros del método, es CASE-SENSITIVE
    var parametros = {
        idCliente: pIdVehiculo
    };
    ///invocar el método
    $.ajax({
        url: url,
        dataType: 'json',
        type: 'post',
        contentType: 'application/json',
        data: JSON.stringify(parametros),
        success: function (data, textStatus, jQxhr) {
            procesarResultadoVehiculosUsuario(data);
        },
        error: function (jQxhr, textStatus, errorThrown) {
            ///Si No Devuelve Datos
            alert(errorThrown + ' Escoge Un Cliente!');
            var ddlVehiculos = $("#idVehiculo");
            ddlVehiculos.empty();
        },
    });
}

function procesarResultadoVehiculosUsuario(data) {
    ///mediante un selector nos posicionamos sobre la lista de cantones
    var ddlVehiculos = $("#idVehiculo");
    ddlVehiculos.empty();
    ///Creamos la primera opcion de la lista, con valor vacio y el texto "Seleccion Un valor"
    var nuevaOpcion = "<option value=''>Seleccione la placa del vehiculo</option>";
    ddlVehiculos.append(nuevaOpcion);

    ///Validar Si El Usuario Seleccionado Posee Vehiculos
    if (Object.entries(data).length === 0) {
        ddlVehiculos.empty();
        var nuevaOpcion = "<option value=''>No Posees Vehiculos</option>";
        ddlVehiculos.append(nuevaOpcion);
    }
    else
    {
        ///Empezamos A Recorrer Los Registros Obtenidos
        $(data).each(function () {
            ///Obtenemos el objeto de tipo vehiculosXusuario haciendo uso de la clausula "this"
            ///Ahora podemos acceder a todas las propiedades
            ///Por ejemplo cantonActual.nombre nos retorna el nombre de la canton

            var vehiculosXusuario = this;

            ///Creamos la opcion de la lista, con el valor del id de la provincia y el texto con el nombre
            nuevaOpcion = "<option value='" + vehiculosXusuario.idVehiculo + "'>" + vehiculosXusuario.PlacaVehiculo + "</option>";
            ///Agregamos la Opcion Al DropDownList
            ddlVehiculos.append(nuevaOpcion);

        });
    }

}