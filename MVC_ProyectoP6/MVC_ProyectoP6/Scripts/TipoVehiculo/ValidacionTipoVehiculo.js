//document on ready de la view registro de vehiculos
$(function () {
    creaValidaciones();
});

//crea las validaciones
function creaValidaciones() {
    $("#frmNuevoTipoVehiculo").validate({
     // condiciones para que el formulario sea validado 
        rules: {
            CodigoTipoVehiculo: {
                required: true
            },
            TipoVehiculo: {
                required: true
            },
        }
    });
}