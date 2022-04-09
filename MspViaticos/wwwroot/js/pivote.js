window.onload = function () {
    listarPivote();
    listarComboGrupoDesde();
    listarComboGrupoHasta();
}

var objGlobalGrupo;
async function listarPivote() {

    objGlobalGrupo = {
        popup: true,
        popupId: "staticBackdrop",
        url: "Pivote/listarPivotes",
        divPintado: "divContenedor",
        cabeceras: ["Desde", "Hasta",  "Desayuno", "Almuerzo", "Cena", "Alojamiento", "Estatus"],
        propiedades: ["desdeGrupoDescripcion", "hastaGrupoDescripcion", "desayuno", "almuerzo", "cena", "alojamiento", "estatusDescripcion"],
        divContenedorTabla: "contenedorTabla",
        editar: true,
        eliminar: true,
        propiedadId: "registro"
    }
    pintar(objGlobalGrupo)
}

function listarComboGrupoDesde() {
    fetchGet("Pivote/listarGrupos", "json", function (res) {
        console.log(res.listaGrupo);
        var listarGrupo = res.listaGrupo;
        llenarCombo(listarGrupo, ["cboGrupoDesde"], "descripcion", "codigo", "--Todos--", "0")
    })
}

function listarComboGrupoHasta() {
    fetchGet("Pivote/listarGrupos", "json", function (res) {
        console.log(res.listaGrupo);
        var listarGrupo = res.listaGrupo;
        llenarCombo(listarGrupo, ["cboGrupoHasta"], "descripcion", "codigo", "--Todos--", "0")
    })
}



function GuardarDatos() {

    var errores = ValidarDatos("frmGuardarPivote")
    if (errores != "") {
        Error(errores)
        return;
    }

    var frmGuardar = document.getElementById("frmGuardarPivote")
    var frm = new FormData(frmGuardar);
    Confirmacion(undefined, undefined, function (rpta) {
        fetchPost("Pivote/guardarPivotes", "text", frm, function (data) {
            if (data == "1") {
                Exito();
                listarGrupos();
                LimpiarDatos("frmGuardarPivote");
            } else Error();
        })
    })
}

function Limpiar() {
    LimpiarDatos("frmGuardarPivote")
}



function Editar(registro) {
    LimpiarDatos("frmGuardarPivote");
    if (registro == 0) {
        setI("lblTitulo", "Agregar Pivote")
    } else {
        setI("lblTitulo", "Editar Pivote")
        /*recuperarGenerico("Cargo/recuperarCargo/?registro=" + registro, "frmGuardarCargo")*/
    }

}
