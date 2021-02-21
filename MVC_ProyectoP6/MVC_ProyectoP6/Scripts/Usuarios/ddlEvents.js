$(document).ready(function () {
    $("#idProvincia").change(function () {
        var url = '/Usuarios/AgregaCantones';


        var parametros = {
            id_Provincia: $("#idProvincia").val()
        }
        $("#id_Canton").empty();


        $.ajax({

            url: url,
            dataType: 'json',
            type: 'POST',
            contentType: 'application/json',
            data: JSON.stringify(parametros),

            success: function (modeloVista) {

                $.each(modeloVista, function (i, modelo) {
                    $("#id_Canton").append('<option value="' + modelo.Value + '">' +
                    modelo.Text + '</option>');
                // here we are adding option for States  

            });
            },
            ///Funcion que se ejecuta cuando la respuesta tuvo errores
            error: function (jQxhr, textStatus, errorThrown) {
                alert(errorThrown);
            }
        })
    });

    $("#id_Canton").change(function () {
        var url = '/Usuarios/AgregaDistritos';


        var parametros = {
            id_Canton: $("#id_Canton").val()
        }
        $("#id_Distrito").empty();


        $.ajax({

            url: url,
            dataType: 'json',
            type: 'POST',
            contentType: 'application/json',
            data: JSON.stringify(parametros),

            success: function (modeloVista) {

                $.each(modeloVista, function (i, modelo) {
                    $("#id_Distrito").append('<option value="' + modelo.Value + '">' +
                        modelo.Text + '</option>');
                    // here we are adding option for States  

                });
            },
            ///Funcion que se ejecuta cuando la respuesta tuvo errores
            error: function (jQxhr, textStatus, errorThrown) {
                alert(errorThrown);
            }
        })
    });
});



