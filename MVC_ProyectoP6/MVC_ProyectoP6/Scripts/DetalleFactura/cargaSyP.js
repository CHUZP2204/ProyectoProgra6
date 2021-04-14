$(function () {
    ///llamamos a la función que se encargará de crear los eventos
    //que nos permitirán controlar cuando se haga una selección en las respectivas listas
    eventosChangeSOP();
});

//función que registrará los eventos necesarios para "monitorear"
//cuando se ejecute el método change de las respectivas listas
function eventosChangeSOP() {
    ///Evento Change De La Lista Usuarios
    $("#idSOP").change(function () {
        ///Obtenemos el id del Usuario seleccionado
        var idSOPobtenido = $("#idSOP").val();
        ///Llamamos A la Funcion que nos permite cargar
        ///todos los cantones asociados a esa provincia seleccionada
        cargaDropdownListPrecios(idSOPobtenido);
    });
}

function cargaDropdownListPrecios(pIdSOPobtenido) {

    ///dirección a donde se enviarán los datos
    var url = '/DetalleFactura/ObtenerSyp';
    ///parámetros del método, es CASE-SENSITIVE
    var parametros = {
        pIdSypObtenido: pIdSOPobtenido
    };
    ///invocar el método
    $.ajax({
        url: url,
        dataType: 'json',
        type: 'post',
        contentType: 'application/json',
        data: JSON.stringify(parametros),
        success: function (data, textStatus, jQxhr) {
            procesarResultadoPrecios(data);
        },
        error: function (jQxhr, textStatus, errorThrown) {
            ///Si No Devuelve Datos
            alert(errorThrown + ' Escoge Un Producto!');
            var ddlPrecios = $("#PrecioSOP");
            ddlPrecios.empty();
        },
    });
}

function procesarResultadoPrecios(data) {
    ///mediante un selector nos posicionamos sobre la lista de cantones
    var ddlPrecios = $("#PrecioSOP");
    ddlPrecios.empty();
    ///Creamos la primera opcion de la lista, con valor vacio y el texto "Seleccion Un valor"
    var nuevaOpcion = "<option value=''>Seleccione El Precio</option>";
    ddlPrecios.append(nuevaOpcion);

    ///Validar Si El Usuario No Selecciona Ningun Dato
    if (Object.entries(data).length === 0) {
        ddlPrecios.empty();
        var nuevaOpcion = "<option value=''>No Posees Precios</option>";
        ddlPrecios.append(nuevaOpcion);
    }
    else {
        ///Empezamos A Recorrer Los Registros Obtenidos
        $(data).each(function () {
            ///Obtenemos el objeto de tipo vehiculosXusuario haciendo uso de la clausula "this"
            ///Ahora podemos acceder a todas las propiedades
            ///Por ejemplo cantonActual.nombre nos retorna el nombre de la canton

            var precioXproducto = this;

            ///Creamos la opcion de la lista, con el valor del id de la provincia y el texto con el nombre
            nuevaOpcion = "<option value='" + precioXproducto.PrecioSOP + "'> ₡"+precioXproducto.PrecioSOP+"</option>";
            ///Agregamos la Opcion Al DropDownList
            ddlPrecios.append(nuevaOpcion);

        });
    }

}