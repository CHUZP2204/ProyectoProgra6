///Document On ready
$(function () {
    cargarDatosUsuario();
});


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

///Metodo Que Modifca La Etiqueta Por Id #Bienvenida
///Muestra EL Nombre Del Usuario que Inicio Session
function procesarResultadoUsuario(data) {

    var resultadoFuncion = data.resultado;
    var ddlTexto = $("#Bienvenida");
    ddlTexto.text("Bienvenido Al Sistema: " + resultadoFuncion);


}