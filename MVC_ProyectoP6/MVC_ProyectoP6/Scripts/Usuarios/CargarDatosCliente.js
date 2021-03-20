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

            var usuarioIdObtenido = data.usuarioActual;
            if (usuarioIdObtenido === 0) {
                var msj = 'Debes Iniciar Sesion Antes De Usar El Sistema';
                showMessageSm(msj);
                setTimeout(function () {
                    window.location.href = '/Home/Index';
                    
                }, 5000);
            }
            else {
                procesarResultadoUsuario(data);
            }

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

//Modal Pequeño
function showMessageSm(msg) {

    const message = document.querySelector("#message");

    var html = "<div class='modal' data-backdrop='static' id='myModal' tabindex='-1' role='dialog'> " +
        "      <div class='modal-dialog modal-sm modal-dialog-centered' >" +
        "        <div class='modal-content'>" +
        "            <div class='modal-header'>" +
        "                <h6 class='modal-title'>ALERTA!!!</h6>" +
        "            </button>" +
        "        </div>" +
        "        <div class='modal-body'>" +
        "            <p>" + msg + "</p>" +
        "        </div>" +
        "        <div class='modal-footer'>" +
        "        </div>" +
        "    </div>" +
        "</div >" +
        "</div >";

    message.innerHTML = html;

    $("#myModal").modal('show');
    //no tiene funcion
    /* $(function () {
         $("#btnShow").click(function () {
             showModal();
         });
     });*/
}