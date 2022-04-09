window.onload = function () {
    listarNominaActualizada();
    /*listarCombo();*/
}

var objGlobalNominaActualizada;
async function listarNominaActualizada() {

    objGlobalNominaActualizada = {
        popup: true,
        popupId: "staticBackdrop",
        url: "NominasActualizada/listarNominasActualizadas",
        divPintado: "divContenedor",
        cabeceras: ["Registro", "Año", "Mes", "Estatus"],
        propiedades: ["registro", "anio", "mesDescripcion", "estatusDescripcion"],
        divContenedorTabla: "contenedorTabla",
        editar: true,
        eliminar: true,
        propiedadId: "registro",
        paginar: true
    }
    pintar(objGlobalNominaActualizada)
}


//function listarCombo() {
//    fetchGet("Cargo/listarGrupos", "json", function (res) {
//        console.log(res.listaGrupo);
//        var listarGrupo = res.listaGrupo;
//        llenarCombo(listarGrupo, ["cboGrupo"], "descripcion", "codigo", "--Todos--", "0")
//    })
//}


function GuardarDatos() {

    var errores = ValidarDatos("frmGuardarNominaActualizada")
    if (errores != "") {
        Error(errores)
        return;
    }

    var frmGuardar = document.getElementById("frmGuardarNominaActualizada")
    var frm = new FormData(frmGuardar);
    Confirmacion(undefined, "Desea guardar la nomina actualizada?", function () {
        fetchPost("NominasActualizada/guardarNominaActualizada", "text", frm, function (data) {
            if (data == "1") {
                Exito();
                listarNominaActualizada();
                LimpiarDatos("frmGuardarNominaActualizada");
            } else Error();
        })
    })
}

function Editar(registro) {
    LimpiarDatos("frmGuardarNominaActualizada");
    if (registro == 0) {
        setI("lblTitulo", "Agregar Nominas Actualizadas")
    } else {
        setI("lblTitulo", "Editar Nominas Actualizadas")
        recuperarGenerico("NominasActualizada/recuperarNominasActualizada/?registro=" + registro, "frmGuardarNominaActualizada")
    }

}
