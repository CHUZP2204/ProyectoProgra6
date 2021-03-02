///document on ready del view Registro de Personas
$(function () {
    creaValidaciones();
});

///crea las validaciones para el formulario
function creaValidaciones() {
    $("#frmServicioOProducto").validate({
        ///objeto que contiene "las condiciones" que el formulario
        ///debe cumplir para ser considerado válido
        rules: {
            CodigoSOP: {
                required: true
            },
            PrecioSOP: {
                required: true
            },
            TipoSOP: {
                required: true
            },
            idCliente: {
                required: true
            },

        }
    });
}
