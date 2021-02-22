$(document).ready(function () {
    creaValidaciones();

    ///Funcion Para Cambiar Evento De Los DropDownList
    ///A Partir De La Provincia Selecciona Asi Sucesivamente

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
});

///Validar Que Los Espacios NO Esten Vacios
function creaValidaciones() {
    $("#frmNuevoUsuario").validate({
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



