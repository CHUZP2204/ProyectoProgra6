$(function () {
    cargaDatosDireccion()
    creaEventosRegistrar();
    creaValidacionesRegistrarse();
});
///Funcion Para Cambiar Evento De Los DropDownList
///A Partir De La Provincia Selecciona Asi Sucesivamente


function cargaDatosDireccion() {
    $("#idProvincia").change(function () {
        var url = '/Usuarios/AgregaCantones';///Url Del Controller y El Even

        ///Forma De Obtener El Objeto Seleccionado 
        var parametros = {
            id_Provincia: $("#idProvincia").val()
        }
        $("#id_Canton").empty();


        $.ajax({

            url: url,
            dataType: 'json',
            type: 'POST',
            contentType: 'application/json',
            data: JSON.stringify(parametros),///Enviar al Server Los datos 

            ///Funcion que Obtiene la respuesta del server
            success: function (modeloVista) {

                $.each(modeloVista, function (i, modelo) {
                    $("#id_Canton").append('<option value="' + modelo.Value + '">' +
                        modelo.Text + '</option>');
                });
            },
            ///Funcion que se ejecuta cuando la respuesta tuvo errores
            error: function (jQxhr, textStatus, errorThrown) {
                alert(errorThrown);
            }
        })
    });

    ///Funcion Para Cambiar Evento De Los DropDownList
    ///A Partir De La Provincia Selecciona Asi Sucesivamente
    $("#id_Canton").change(function () {
        var url = '/Usuarios/AgregaDistritos';///Url Del Controller y El Evento

        ///Forma De Obtener El Objeto Seleccionado 
        var parametros = {
            id_Canton: $("#id_Canton").val()
        }
        $("#id_Distrito").empty();


        $.ajax({

            url: url,
            dataType: 'json',
            type: 'POST',
            contentType: 'application/json',
            data: JSON.stringify(parametros),///Enviar al Server Los datos

            ///Funcion que Obtiene la respuesta del server
            success: function (modeloVista) {

                $.each(modeloVista, function (i, modelo) {
                    $("#id_Distrito").append('<option value="' + modelo.Value + '">' +
                        modelo.Text + '</option>');
                });
            },
            ///Funcion que se ejecuta cuando la respuesta tuvo errores
            error: function (jQxhr, textStatus, errorThrown) {
                alert(errorThrown);
            }
        })
    });

}



function creaEventosRegistrar() {
    $("#registrar").on("click", function () {
        ///Asignar a la variable formulario
        ///el resultado del selector
        var formulario = $("#frmRegistraUsuario");
        ///Ejecutar El MEtodo De Validacion
        formulario.validate();
        ///Si El Formulario Es Valido
        ///Ejecutar la funcion invocaMetodosPost
        if (formulario.valid()) {
            RegistraDatosCLiente();
        }
    });
}

///Validar Que Campos No Este Vacios
function creaValidacionesRegistrarse() {
    $("#frmRegistraUsuario").validate({
        ///objeto que contiene "las condiciones" que el formulario
        ///debe cumplir para ser considerado válido
        rules: {
            Cedula: {
                required: true
            },
            FechaNacimiento: {
                required: true
            },
            Genero: {
                required: true
            },
            NombreCompleto: {
                required: true
            },
            Correo: {
                required: true
            },
            idProvincia: {
                required: true
            },
            id_Canton: {
                required: true
            },
            id_Distrito: {
                required: true
            },
            TipoUsuario: {
                required: true
            },
            Contrasenia: {
                required: true
            }
        }
    });
}

/// Llamar Y Registrar Cliente Con Jquery

function RegistraDatosCLiente() {
    ///dirección a donde se enviarán los datos
    var urlMetodo = '/Home/RegistrarUsuario';
    ///parámetros del método, es CASE-SENSITIVE
    var parametros = {
        pCedula: $("#Cedula").val(),
        pFecha: $("#FechaNacimiento").val(),
        pGenero: $("#Genero").val(),
        pNombreC: $("#NombreCompleto").val(),
        pCorreo: $("#CorreoIngresado").val(),
        pIdProvincia: $("#idProvincia").val(),
        pIdCanton: $("#id_Canton").val(),
        pIdDistrito: $("#id_Distrito").val(),
        pTipoUsuario: $("#TipoUsuario").val(),
        pContrasenia: $("#Contrasenia").val()
    };

    var funcion = cargaMensaje;

    ///Llamar al Metodo Que Se Comunica con el servidor
    ejecutaAjax(urlMetodo, parametros, funcion)
}



function cargaMensaje(data) {
    var resultadoFuncion = data;
    $("#divDialog").dialog("close");

    //showMessageRegistrarse(resultadoFuncion);
    showMessageRegistrarse(resultadoFuncion);
    ///Pausa Para Redirigir De Pagina

}

//Modal Pequeño
function showMessageRegistrarse(msg) {

    const mensaje = document.querySelector("#messageRegistrarse");


    var html = "<div class='modal' data-backdrop='static' id='myModalRegistrar' tabindex='-1' role='dialog'> " +
        "      <div class='modal-dialog  modal-dialog-centered' >" +
        "        <div class='modal-content'>" +
        "            <div class='modal-header'>" +
        "                <h5 class='modal-title'>Validación</h5>" +
        "           <button type='button' class='close' data-dismiss='modal' aria-label='Close'>" +
        "               <span aria-hidden='true'>&times;</span>" +
        "            </button>" +
        "        </div>" +
        "        <div class='modal-body'>" +
        "            <p>" + msg + "</p>" +
        "        </div>" +
        "        <div class='modal-footer'>" +
        "            <button type='button' class='btn btn-primary' data-dismiss='modal'>Ok</button>" +
        "        </div>" +
        "    </div>" +
        "</div >" +
        "</div >";

    mensaje.innerHTML = html;

    $("#myModalRegistrar").modal('show');
    //no tiene funcion
    /* $(function () {
         $("#btnShow").click(function () {
             showModal();
         });
     });*/
}

function showMessageX(msg) {

    const message = document.querySelector("#mensaje");


    var html = "<div id='myModalEx' class='modal fade bd - example - modal - sm' tabindex=' - 1' role='dialog' aria-labelledby='mySmallModalLabel' aria-hidden='true'> " +
        "      <div class='modal-dialog  modal-dialog-centered' >" +
        "        <div class='modal-content'>" +
        "            <div class='modal-header' style='color: aliceblue; background - color: red'>" +
        "                <h5 class='modal-title'>Validación</h5>" +
        "           <button type='button' class='close' data-dismiss='modal' aria-label='Close'>" +
        "               <span aria-hidden='true'>&times;</span>" +
        "            </button>" +
        "        </div>" +
        "        <div class='modal-body'>" +
        "            <p>" + msg + "</p>" +
        "        </div>" +
        "        <div class='modal-footer'>" +
        "            <button type='button' class='btn btn-primary' data-dismiss='modal'>Cerrar</button>" +
        "        </div>" +
        "    </div>" +
        " </div >" +
        "</div >";


    message.innerHTML = html;

    $("#myModalEx").modal('show');
    //no tiene funcion
    /* $(function () {
         $("#btnShow").click(function () {
             showModal();
         });
     });*/
}