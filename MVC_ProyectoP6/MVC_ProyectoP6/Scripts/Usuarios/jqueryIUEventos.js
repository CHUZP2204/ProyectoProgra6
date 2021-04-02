//Document On Ready
$(function () {
    creaElementosJqueryUI();

});
///Función que crea los elementos de jqueryUI
function creaElementosJqueryUI() {

    ///creamos el div divDialog como elemento de tipo Dialog
    crearDialog();
    ///evento click del botón btMostrarDialog          
    $("#btMostrarDialog").click(function () {

        $("#divDialog").dialog("open");

    });
    //evento click del botón btCerrar   
    $("#btCerrar").click(function () {
        $("#divDialog").dialog("close");
    });

    ///creamos el control de tipo datepicker
    ///crearDatePicker();
    ///crearDatePicker1();
}




//crear y mostrar Div Dialog
function crearDialog() {
    $("#divDialog").dialog({
        autoOpen: false,
        height: 500,
        width: 600,
        modal: true,
        title: "Registro!!!",
        resizable: false,
        close: function () {
            alert("Ventana Cerrada");
        },
        open: function () {
            alert("Ventana Abierta");
        }
    });
}



