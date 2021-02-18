﻿///document on ready del view Registro de Personas
$(function () {
    creaValidaciones();
});

///crea las validaciones para el formulario
function creaValidaciones() {
    $("#frmNuevoPaisFabricante").validate({
        ///objeto que contiene "las condiciones" que el formulario
        ///debe cumplir para ser considerado válido
        rules: {
            CodigoPaisFabricante: {
                required: true
            },
          
            PaisFabricante: {
                required: true
            },
        }
    });
}