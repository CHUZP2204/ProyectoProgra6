// document on ready del view Modifica Pais Fabricante

(function () {

    creaValidaciones();
});

//crea las validaciones para el formulario

function creaValidaciones() {
    $("#frmModificaPaisProcedencia").validate({
        //objeto que contiene las condiciones que el formulario
        //debe cumplir para considerarlo validado

        rules: {

            PaisFabricante: {
                required: true
            },

            CodigoPaisFabricante: {
                required: true
            }
        }

    });

}