///Document On ready
$(function () {
    creaValidaciones();
    creaEventosInicioSesion()
});

///crea las validaciones para el formulario
function creaValidaciones() {
    $("#frmInicioSesion").validate({
        ///objeto que contiene "las condiciones" que el formulario
        ///debe cumplir para ser considerado válido
        rules: {
            Correo: {
                required: true
            },
            Contrasenia: {
                required: true
            },
        }
    });
}

///Llamar Eventos 
///Al Iniciar Session
function creaEventosInicioSesion() {
    $("#btnAceptar").on("click", function () {
        ///Asignar a la variable formulario
        ///el resultado del selector
        var formulario = $("#frmInicioSesion");
        ///Ejecutar El MEtodo De Validacion
        formulario.validate();
        ///Si El Formulario Es Valido
        ///Ejecutar la funcion invocaMetodosPost
        if (formulario.valid()) {
            invocarMetodoPost();
        }
    });
}
///se encarga de llamar al método del controlador y procesar el resultado
///Pasamos Los Parametros Ingresados Por El Usuario
function invocarMetodoPost() {
    var url = '/Home/ValidarUsuario';
    ///Parametros del metodo, es CASE SENSITIVE
    var parametros = {
        pCorreo: $("#Correo").val(),
        pContrasenia: $("#Contrasenia").val()
    };
    ///Invocar al metodo
    $.ajax({
        url: url,///Direccion Del Metodo
        dataType: 'json', ///formato en lo que se envian y reciben los datos
        type: 'post',
        contentType: 'application/json',
        data: JSON.stringify(parametros),///parametros convertidos en formato JSON
        ///funcion que se ejecuta cuando la respuesta fue satisfactoria
        ///data: contiene el valor retornado por el metodo del servidor
        success: function (data, textStatus, jQxhr) {
            procesarResultadoMetodo(data);
        },
        ///Funcion que se ejecuta cuando la respuesta tuvo errores
        error: function (jQxhr, textStatus, errorThrown) {
            alert(errorThrown);
        }
    });
}

///carga los Datos Del Cliente Desde El Server
function cargarDatosUsuario() {
    ///dirección a donde se enviarán los datos
    var url = '/Home/MostrarInfoUsuario';
    ///parámetros del método, es CASE-SENSITIVE
    var parametros = {
    };
    ///invocar el método
    $.ajax({
        url: url,
        dataType: 'json',
        type: 'post',
        contentType: 'application/json',
        data: JSON.stringify(parametros),
        success: function (data, textStatus, jQxhr) {
            procesarResultadoUsuario(data);
        },
        error: function (jQxhr, textStatus, errorThrown) {
            alert(errorThrown);
        },
    });
}

/// A Partir De La Validacion De Usuario Desde El Server
/// INICIAR Session O Mandar Mensaje De Error
function procesarResultadoMetodo(data) {

    /// es resultado porque la funcion devuelve
    /// un objeto JSON que posee una propiedad
    /// llamada resultado
    var resultadoFuncion = data.resultado;

    if (resultadoFuncion == true) {
        //alert("Inico Sesion Exitoso");
        cargarDatosUsuario();
        $("#myModalExitoso").modal();

        ///Pausa Para Redirigir De Pagina
        setTimeout(function () {
            window.location.href = '/Home/PaginaPrincipal';
        }, 5000);

    }
    else {
        ///Inicio De Seion Fallido
        $("#myModalErrorSesion").modal();
    }
}

///Metodo Que Modifca La Etiqueta Por Id #Bienvenida
///Muestra EL Nombre Del Usuario que Inicio Session
function procesarResultadoUsuario(data) {

    var resultadoFuncion = data.resultado;
    var ddlTexto = $("#Bienvenida");
    ddlTexto.text("Bienvenido Al Sistema: " + resultadoFuncion);


}
