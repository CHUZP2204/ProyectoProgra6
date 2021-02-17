/// document on ready del view registro de pais fabricacion

$(function () {
    creaValidaciones();
})

//crea las validaciones para el formulario
function creaValidaciones() {
    $("#frmPaisFabricante").validate(
        {
            //objeto que contiene "las condiciones" que el formulario
            //debe cumplir para ser validado
            rules: {

                CodigoPaisFabricante: {
                    required: true,
                },

                PaisFabricante: {
                    required: true,
                },
            }
        }
    );

}