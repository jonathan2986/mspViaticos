window.onload = function () {
    listaDiasNoLaboralesFeriado();
}
var objGlobalDiaNoLaboralesFeriado;
async function listaDiasNoLaboralesFeriado() {

    objGlobalDiaNoLaboralesFeriado = {
        popup: true,
        popupId: "staticBackdrop",
        url: "DiasNoLaboralesFeriados/listaDiasNoLaboralesFeriados",
        divPintado: "divContenedor",
        cabeceras: ["Fecha", "Descripcion", "Descripcion de Dia"],
        propiedades: ["fecha", "descripcion", "tipoDes"],
        divContenedorTabla: "contenedorTabla",
        editar: true,
        eliminar: true,
        propiedadId: "registro",
        paginar: true
    }
    pintar(objGlobalDiaNoLaboralesFeriado)
}

function GuardarDatos() {

    var errores = ValidarDatos("frmGuardarDiaNoLaborale")
    if (errores != "") {
        Error(errores)
        return;
    }

    var frmGuardar = document.getElementById("frmGuardarDiaNoLaborale")
    var frm = new FormData(frmGuardar);
    Confirmacion(undefined, undefined, function (rpta) {
        fetchPost("DiasNoLaboralesFeriados/guardarDiasNoLaboralesFeriados", "text", frm, function (data) {
            if (data == "1") {
                Exito();
                listaDiasNoLaboralesFeriado();
                LimpiarDatos("frmGuardarDiaNoLaborale");
            } else Error();
        })
    })
}
