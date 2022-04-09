window.onload = function () {
    listarProvinciaTuristicas();
    listarCombo();
}

var objGlobalCargo;
async function listarProvinciaTuristicas() {

    objGlobalCargo = {
        popup: true,
        popupId: "staticBackdrop",
        url: "ProvinciaTuristica/listarProvinciaTuristica",
        divPintado: "divContenedor",
        cabeceras: ["Codigo", "Provincia", "Porciento"],
        propiedades: ["provincia", "nombreProvincia", "porciento"],
        divContenedorTabla: "contenedorTabla",
        editar: true,
        eliminar: true,
        propiedadId: "registro",
        paginar: true
    }
    pintar(objGlobalCargo)
}


function listarCombo() {
    fetchGet("ProvinciaTuristica/listarProvincias", "json", function (res) {
        console.log(res);
        var listarProvincia = res.listaProvincia;
        llenarCombo(listarProvincia, ["cboProvinciaTuristica"], "nombre", "codigo", "--Todos--", "0")
    })
}


function GuardarDatos() {

    var errores = ValidarDatos("frmGuardarProvinciaTuristica")
    if (errores != "") {
        Error(errores)
        return;
    }

    var frmGuardar = document.getElementById("frmGuardarProvinciaTuristica")
    var frm = new FormData(frmGuardar);
    Confirmacion(undefined, "Desea guardar los cargos?", function () {
        fetchPost("ProvinciaTuristica/guardarProvinciaTuristica", "text", frm, function (data) {
            if (data == "1") {
                Exito();
                listarProvinciaTuristicas();
                LimpiarDatos("frmGuardarProvinciaTuristica");
            } else Error();
        })
    })
}

function Editar(registro) {
    LimpiarDatos("frmGuardarProvinciaTuristica");
    if (registro == 0) {
        setI("lblTitulo", "Agregar Provincia Turistica")
    } else {
        setI("lblTitulo", "Editar Provincia Turistica")
        recuperarGenerico("ProvinciaTuristica/recuperarProvinciaTuristica/?registro=" + registro, "frmGuardarProvinciaTuristica")
    }

}
