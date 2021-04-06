///document on ready del view Registro de Personas
$(function () {
    creaValidaciones();
});

///crea las validaciones para el formulario
function creaValidaciones() {
    $("#frmModificaVehiculo").validate({
        ///objeto que contiene "las condiciones" que el formulario
        ///debe cumplir para ser considerado válido
        rules: {
            PlacaVehiculo: {
                required: true
            },
            idTipoVehiculo: {
                required: true
            },
            idMarcaVehiculo: {
                required: true
            },
            NumeroPuertas: {
                required: true
            },
            NumeroRuedas: {
                required: true
            },
        }
    });
}
